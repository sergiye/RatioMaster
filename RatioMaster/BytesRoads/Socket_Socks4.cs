using System;
using System.Net;
using System.Net.Sockets;

namespace RatioMaster.BytesRoads {
  /// <summary>
  /// Summary description for SocketEx_Socks4.
  /// </summary>
  internal class Socket_Socks4 : SocketBase {
    #region Async classes

    private class Connect_SO : AsyncResultBase {
      internal Connect_SO(
        EndPoint remoteEndPoint,
        int port,
        AsyncCallback cb,
        object state) : base(cb, state) {
        RemoteEndPoint = remoteEndPoint;
        Port = port;
      }

      internal int Port { get; } = -1;

      internal EndPoint RemoteEndPoint { get; set; }

      internal int ReadBytes { get; set; }
    }

    private class Bind_SO : AsyncResultBase {
      internal Bind_SO(
        SocketBase baseSocket,
        AsyncCallback cb,
        object state) : base(cb, state) {
        BaseSocket = baseSocket;
      }

      internal SocketBase BaseSocket { get; }

      internal int ReadBytes { get; set; }

      internal IPAddress ProxyIP { get; set; }
    }

    private class Accept_SO : AsyncResultBase {
      internal Accept_SO(
        AsyncCallback cb,
        object state) : base(cb, state) {
      }

      internal int ReadBytes { get; set; }
    }

    #endregion

    private byte[] _response = new byte[8];

    // End points
    private EndPoint _localEndPoint;
    private EndPoint _remoteEndPoint;

    internal Socket_Socks4(
      string proxyServer,
      int proxyPort,
      byte[] proxyUser)
      : base(
        proxyServer,
        proxyPort,
        proxyUser,
        null) {
    }

    #region Attributes

    internal override ProxyType ProxyType => ProxyType.Socks4;

    internal override EndPoint LocalEndPoint => _localEndPoint;

    internal override EndPoint RemoteEndPoint => _remoteEndPoint;

    #endregion

    #region Helper functions

    private void VerifyResponse() {
      string msg = null;

      //------------------------------------
      // Verify reply format. Pass 4 even it
      // against the RFC.
      //
      if (_response[0] != 0 && _response[0] != 4) {
        msg = string.Format("Socks4: Reply format is unknown ({0}).", _response[0]);
        throw new ProtocolViolationException(msg);
      }

      //------------------------------------
      // Verify the response
      //
      if (_response[1] != 90) {
        var err = _response[1];
        if (91 == err)
          msg = string.Format("Socks4: Request rejected or failed ({0}).", err);
        else if (92 == err)
          msg = string.Format(
            "Socks4: Request rejected because SOCKS server cannot connect to identd on the client ({0}).", err);
        else if (93 == err)
          msg = string.Format(
            "Socks4: Request rejected because the client program and identd report different user-ids ({0}).", err);
        else
          msg = string.Format("Socks4: Socks server return unknown error code ({0}).", err);
      }

      if (null != msg)
        throw new SocketException(SockErrors.WSAECONNREFUSED);

      // throw new ProxyErrorException(msg);
    }

    private byte[] PrepareCmd(EndPoint remoteEP, byte cmdVal) {
      var userLength = 0;
      if (ProxyUser != null)
        userLength = ProxyUser.Length;

      var ip = (IPEndPoint) remoteEP;
      var cmd = new byte[8 + userLength + 1];
      cmd[0] = 4;
      cmd[1] = cmdVal;
      cmd[2] = (byte) ((ip.Port & 0xFF00) >> 8);
      cmd[3] = (byte) (ip.Port & 0xFF);

      var ipAddr = ip.Address.Address;
      cmd[7] = (byte) ((ipAddr & 0xFF000000) >> 24);
      cmd[6] = (byte) ((ipAddr & 0x00FF0000) >> 16);
      cmd[5] = (byte) ((ipAddr & 0x0000FF00) >> 8);
      cmd[4] = (byte) (ipAddr & 0x000000FF);

      if (userLength > 0)
        Array.Copy(ProxyUser, 0, cmd, 8, userLength);
      cmd[8 + userLength] = 0;
      return cmd;
    }

    private byte[] PrepareBindCmd(SocketBase baseSocket) {
      return PrepareCmd(baseSocket.RemoteEndPoint, 2);
    }

    private byte[] PrepareConnectCmd(EndPoint remoteEP) {
      return PrepareCmd(remoteEP, 1);
    }

    private IPEndPoint ConstructBindEndPoint(IPAddress proxyIP) {
      var port = (_response[2] << 8) | _response[3];
      long ip = (_response[7] << 24) |
                (_response[6] << 16) |
                (_response[5] << 8) |
                _response[4];
      ip &= 0xFFFFFFFF;

      //------------------------------------
      // if ip addr all zeros we need to 
      // substitute address of the proxy
      // server
      if (0 == ip)
        return new IPEndPoint(proxyIP, port);

      return new IPEndPoint(new IPAddress(ip), port);
    }

    #endregion

    #region Accept functions (overriden)

    internal override SocketBase Accept() {
      CheckDisposed();
      SetProgress(true);
      try {
        var read = 0;
        while (read < 8) {
          read += NStream.Read(
            _response,
            read,
            _response.Length - read);
        }

        VerifyResponse();
      }
      finally {
        SetProgress(false);
      }

      return this;
    }

    internal override IAsyncResult BeginAccept(
      AsyncCallback callback,
      object state) {
      CheckDisposed();

      Accept_SO stateObj;
      SetProgress(true);
      try {
        stateObj = new Accept_SO(callback, state);

        //------------------------------------
        // Read the second response from proxy server. 
        //
        NStream.BeginRead(
          _response,
          0,
          8,
          Accept_Read_End,
          stateObj);
      }
      catch {
        SetProgress(false);
        throw;
      }

      return stateObj;
    }

    private void Accept_Read_End(IAsyncResult ar) {
      var stateObj = (Accept_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        stateObj.ReadBytes += NStream.EndRead(ar);

        if (stateObj.ReadBytes < 8) {
          //------------------------------------
          // Continue read the response from proxy server. 
          //
          NStream.BeginRead(
            _response,
            stateObj.ReadBytes,
            8 - stateObj.ReadBytes,
            Accept_Read_End,
            stateObj);
        }
        else {
          VerifyResponse();
          stateObj.SetCompleted();
        }
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    internal override SocketBase EndAccept(IAsyncResult asyncResult) {
      VerifyAsyncResult(asyncResult, typeof(Accept_SO), "EndAccept");
      HandleAsyncEnd(asyncResult, true);
      return this;
    }

    #endregion

    #region Connect functions (overriden)

    internal override void Connect(EndPoint remoteEP) {
      CheckDisposed();
      SetProgress(true);
      try {
        //------------------------------------
        // Get end point for the proxy server
        //
        var proxyEntry = GetHostByName(ProxyServer);
        if (null == proxyEntry)

          // throw new HostNotFoundException("Unable to resolve proxy name.");
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        var proxyEndPoint = ConstructEndPoint(proxyEntry, ProxyPort);

        //------------------------------------------
        // Connect to proxy server
        //
        Socket.Connect(proxyEndPoint);

        _localEndPoint = null; // CONNECT command doesn't provide us with local end point
        _remoteEndPoint = remoteEP;

        //------------------------------------------
        // Send CONNECT command
        //
        var cmd = PrepareConnectCmd(remoteEP);
        NStream.Write(cmd, 0, cmd.Length);

        //------------------------------------------
        // Read the response from proxy the server. 
        //
        var read = 0;
        while (read < 8) {
          read += NStream.Read(
            _response,
            read,
            _response.Length - read);
        }

        VerifyResponse();
      }
      finally {
        SetProgress(false);
      }
    }


    internal override IAsyncResult BeginConnect(
      string hostName,
      int port,
      AsyncCallback callback,
      object state) {
      CheckDisposed();
      Connect_SO stateObj;

      SetProgress(true);
      try {
        stateObj = new Connect_SO(null, port, callback, state);
        BeginGetHostByName(
          hostName,
          Connect_GetHost_Host_End,
          stateObj);
      }
      catch (Exception) {
        SetProgress(false);
        throw;
      }

      return stateObj;
    }

    private void Connect_GetHost_Host_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        var host = EndGetHostByName(ar);
        if (null == host)
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        // throw new HostNotFoundException("Unable to resolve host name.");

        stateObj.RemoteEndPoint = ConstructEndPoint(host, stateObj.Port);

        //------------------------------------
        // Get end point for the proxy server
        //
        BeginGetHostByName(
          ProxyServer,
          Connect_GetHost_Proxy_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    internal override IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback callback, object state) {
      CheckDisposed();

      Connect_SO stateObj;

      SetProgress(true);
      try {
        stateObj = new Connect_SO(remoteEP, -1, callback, state);

        //------------------------------------
        // Get end point for the proxy server
        //
        BeginGetHostByName(
          ProxyServer,
          Connect_GetHost_Proxy_End,
          stateObj);
      }
      catch (Exception) {
        SetProgress(false);
        throw;
      }

      return stateObj;
    }

    private void Connect_GetHost_Proxy_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        var host = EndGetHostByName(ar);
        if (null == host)
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        // throw new HostNotFoundException("Unable to resolve proxy name.");

        var proxyEndPoint = ConstructEndPoint(host, ProxyPort);

        //------------------------------------
        // Connect to proxy server
        //
        Socket.BeginConnect(
          proxyEndPoint,
          Connect_Connect_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Connect_Connect_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        Socket.EndConnect(ar);

        _localEndPoint = null;
        _remoteEndPoint = stateObj.RemoteEndPoint;

        //------------------------------------
        // Send CONNECT command
        //
        var cmd = PrepareConnectCmd(stateObj.RemoteEndPoint);

        NStream.BeginWrite(
          cmd,
          0,
          cmd.Length,
          Connect_Write_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Connect_Write_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        NStream.EndWrite(ar);

        //------------------------------------
        // Read the response from proxy server. 
        //
        NStream.BeginRead(
          _response,
          0,
          8,
          Connect_Read_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Connect_Read_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        var num = NStream.EndRead(ar);
        stateObj.ReadBytes += num;

        if (stateObj.ReadBytes < 8) {
          //------------------------------------
          // Read the response from proxy server. 
          //
          NStream.BeginRead(
            _response,
            stateObj.ReadBytes,
            8 - stateObj.ReadBytes,
            Connect_Read_End,
            stateObj);
        }
        else {
          VerifyResponse();
          stateObj.SetCompleted();
        }
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    internal override void EndConnect(IAsyncResult asyncResult) {
      VerifyAsyncResult(asyncResult, typeof(Connect_SO), "EndConnect");
      HandleAsyncEnd(asyncResult, true);
    }

    #endregion

    #region Bind functions (overriden)

    internal override void Bind(SocketBase socket) {
      CheckDisposed();
      SetProgress(true);
      try {
        //-----------------------------------------
        // Get end point for the proxy server
        var host = GetHostByName(ProxyServer);
        if (host == null)
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        // throw new HostNotFoundException("Unable to resolve proxy host name.");

        var proxyEndPoint = ConstructEndPoint(host, ProxyPort);

        //-----------------------------------------
        // Connect to proxy server
        //
        Socket.Connect(proxyEndPoint);

        //-----------------------------------------
        // Send BIND command
        //
        var cmd = PrepareBindCmd(socket);
        NStream.Write(cmd, 0, cmd.Length);

        //-----------------------------------------
        // Read the response from the proxy server. 
        //
        var read = 0;
        while (read < 8) {
          read += NStream.Read(
            _response,
            read,
            _response.Length - read);
        }

        VerifyResponse();
        _localEndPoint = ConstructBindEndPoint(proxyEndPoint.Address);

        // remote end point doesn't provided for BIND command
        _remoteEndPoint = null;
      }
      finally {
        SetProgress(false);
      }
    }


    internal override IAsyncResult BeginBind(
      SocketBase baseSocket,
      AsyncCallback callback,
      object state) {
      CheckDisposed();

      Bind_SO stateObj;

      SetProgress(true);
      try {
        stateObj = new Bind_SO(baseSocket, callback, state);

        //------------------------------------
        // Get end point for the proxy server
        //
        BeginGetHostByName(
          ProxyServer,
          Bind_GetHost_End,
          stateObj);
      }
      catch (Exception) {
        SetProgress(false);
        throw;
      }

      return stateObj;
    }

    private void Bind_GetHost_End(IAsyncResult ar) {
      var stateObj = (Bind_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        var host = EndGetHostByName(ar);
        if (host == null)
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        // throw new HostNotFoundException("Unable to resolve proxy host name.");

        var proxyEndPoint = ConstructEndPoint(host, ProxyPort);
        stateObj.ProxyIP = proxyEndPoint.Address;

        //------------------------------------
        // Connect to proxy server
        //
        Socket.BeginConnect(
          proxyEndPoint,
          Bind_Connect_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Bind_Connect_End(IAsyncResult ar) {
      var stateObj = (Bind_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        Socket.EndConnect(ar);

        //------------------------------------
        // Send CONNECT command
        //
        var cmd = PrepareBindCmd(stateObj.BaseSocket);

        NStream.BeginWrite(
          cmd,
          0,
          cmd.Length,
          Bind_Write_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Bind_Write_End(IAsyncResult ar) {
      var stateObj = (Bind_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        NStream.EndWrite(ar);

        //------------------------------------
        // Read the response from proxy server. 
        //
        NStream.BeginRead(
          _response,
          0,
          8,
          Bind_Read_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Bind_Read_End(IAsyncResult ar) {
      var stateObj = (Bind_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        var num = NStream.EndRead(ar);
        stateObj.ReadBytes += num;

        if (stateObj.ReadBytes < 8) {
          //------------------------------------
          // Read the response from proxy server. 
          //
          NStream.BeginRead(
            _response,
            stateObj.ReadBytes,
            8 - stateObj.ReadBytes,
            Bind_Read_End,
            stateObj);
        }
        else {
          VerifyResponse();
          _localEndPoint = ConstructBindEndPoint(stateObj.ProxyIP);
          _remoteEndPoint = null;
          stateObj.SetCompleted();
        }
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    internal override void EndBind(IAsyncResult asyncResult) {
      VerifyAsyncResult(asyncResult, typeof(Bind_SO), "EndBind");
      HandleAsyncEnd(asyncResult, true);
    }

    #endregion

    #region Listen functions (overriden)

    internal override void Listen(int backlog) {
      CheckDisposed();
      if (null == _localEndPoint)
        throw new ArgumentException("Attempt to listen on socket which has not been bound with Bind.");
    }

    #endregion
  }
}