using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace RatioMaster.BytesRoads {
  /// <summary>
  /// Summary description for Socket_HttpConnect.
  /// </summary>
  internal class Socket_HttpConnect : SocketBase {
    #region Async classes

    private class Receive_SO : AsyncResultBase {
      internal Receive_SO(AsyncCallback cb, object state) : base(cb, state) {
      }

      internal int Read { get; set; }
    }

    private class Connect_SO : AsyncResultBase {
      internal Connect_SO(
        string hostName,
        int hostPort,
        bool useCredentials,
        AsyncCallback cb,
        object state) : base(cb, state) {
        UseCredentials = useCredentials;
        HostName = hostName;
        HostPort = hostPort;
      }

      internal bool UseCredentials { get; set; }

      internal string HostName { get; }

      internal int HostPort { get; }
    }

    private class ReadReply_SO : AsyncResultBase {
      internal ReadReply_SO(
        AsyncCallback cb,
        object state) : base(cb, state) {
      }

      internal byte[] Buffer { get; } = new byte[512];

      internal ByteVector Reply { get; } = new ByteVector();
    }

    #endregion

    private ByteVector _recvBuffer = new ByteVector();
    private int _maxReplySize = 4096;

    private Regex _replyRegEx = new Regex(
      @"^HTTP/\d+\.\d+ (?<code>\d\d\d) ?(?<reason>[^\r\n]*)?(\r)?\n",
      RegexOptions.IgnoreCase | RegexOptions.Compiled);


    internal Socket_HttpConnect(
      string proxyServer,
      int proxyPort,
      byte[] proxyUser,
      byte[] proxyPassword)
      : base(proxyServer, proxyPort, proxyUser, proxyPassword) {
    }

    #region Attributes

    internal override int Available {
      get {
        var len = _recvBuffer.Size;
        if (len > 0)
          return len;
        return Socket.Available;
      }
    }

    internal override ProxyType ProxyType => ProxyType.HttpConnect;

    internal override EndPoint LocalEndPoint => null;

    internal override EndPoint RemoteEndPoint { get; } = null;

    #endregion

    #region Helpers

    private int AnalyzeReply(ByteVector reply, out string reason) {
      if (0 == reply.Size)
        throw new SocketException(SockErrors.WSAECONNREFUSED);

      // throw new ProxyErrorException("Web proxy close the connection.");

      // reply should be in following form:
      // "HTTP/x.x xxx reason(\r)?\n"
      var replyStr = Encoding.ASCII.GetString(reply.Data, 0, reply.Size);
      var m = _replyRegEx.Match(replyStr);

      if (reply.Size < 14 || m.Groups.Count != 4)
        throw new ProtocolViolationException("Web proxy reply is incorrect.");

      var code = int.Parse(m.Groups["code"].Value);
      reason = m.Groups["reason"].Value;

      return code;
    }

    private void ThrowUnsupportException(string method) {
      var msg = string.Format("'{0}' command is not possible with Web proxy.", method);
      throw new InvalidOperationException(msg);
    }

    private string GetBasicCredentials() {
      var length = 1; // ':'
      if (null != ProxyUser)
        length += ProxyUser.Length;

      if (null != ProxyPassword)
        length += ProxyPassword.Length;

      var cmd = new byte[length];
      length = 0;

      if (null != ProxyUser) {
        Array.Copy(ProxyUser, 0, cmd, 0, ProxyUser.Length);
        length += ProxyUser.Length;
      }

      cmd[length++] = (byte) ':';
      if (null != ProxyPassword) {
        Array.Copy(ProxyPassword, 0, cmd, length, ProxyPassword.Length);
        length += ProxyPassword.Length;
      }

      return Convert.ToBase64String(cmd);
    }

    private byte[] GetConnectCmd(string hostName, int hostPort, bool useCredentials) {
      var cmd = string.Format("CONNECT {0}:{1} HTTP/1.1\r\n", hostName, hostPort);
      cmd += string.Format("Host: {0}:{1}\r\n", hostName, hostPort);
      if (useCredentials) {
        var credentials = GetBasicCredentials();
        cmd += "Authorization: basic " + credentials + "\r\n";
        cmd += "Proxy-Authorization: basic " + credentials + "\r\n";
      }

      cmd += "\r\n";
      return Encoding.ASCII.GetBytes(cmd);
    }

    private int FetchBufferData(byte[] buffer, int offset, int size) {
      var length = _recvBuffer.Size;
      if (length <= 0)
        return 0;

      if (offset < 0)
        offset = 0;

      if (size < 0)
        size = buffer.Length;

      var num = length > size ? size : length;
      Array.Copy(_recvBuffer.Data, 0, buffer, offset, num);
      _recvBuffer.CutHead(num);
      return num;
    }

    private void PutBufferData(byte[] buffer, int offset, int size) {
      if (0 != _recvBuffer.Size)
        throw new InvalidOperationException("PutBufferData: buffer is not empty.");

      _recvBuffer.Add(buffer, offset, size);
    }

    private int FindReplyEnd(byte[] buf, int size) {
      const byte CR = 13;
      const byte LF = 10;

      // the end of the buffer can't be there
      if (size < 2)
        return -1;

      // here we need to find the end of http response
      // it identified either by <CRLF><CRLF> or by <LF><LF>
      for (var i = 0; i < size; i++) {
        var checkLong = false;
        var checkShort = false;
        var stillCheck = size - i;

        if (stillCheck >= 2) {
          checkShort = true;
          if (stillCheck >= 4)
            checkLong = true;
        }

        if (checkLong) {
          if (buf[i] == CR &&
              buf[i + 1] == LF &&
              buf[i + 2] == CR &&
              buf[i + 3] == LF) {
            return i + 4;
          }
        }
        else if (checkShort) {
          if (buf[i] == LF &&
              buf[i + 1] == LF) {
            return i + 2;
          }
        }
        else
          break;
      }

      return -1;
    }

    #endregion

    #region ReadReply functions

    private ByteVector ReadReply() {
      var reply = new ByteVector();
      var buf = new byte[512];
      while (true) {
        var num = Receive(buf);
        if (0 == num)
          break;

        reply.Add(buf, 0, num);

        // handle the end of reply
        var afterEndPos = FindReplyEnd(reply.Data, reply.Size);
        if (afterEndPos > 0) {
          if (afterEndPos < num) // read after reply finished?
          {
            // put data back into the buffer for further
            // processing in receive functions
            PutBufferData(buf, afterEndPos, num - afterEndPos);
            reply.CutTail(num - afterEndPos);
          }

          break;
        }

        if (reply.Size > _maxReplySize)
          throw new ProtocolViolationException("Web proxy reply exceed maximum length.");
      }

      return reply;
    }

    private IAsyncResult BeginReadReply(AsyncCallback cb, object state) {
      var stateObj = new ReadReply_SO(cb, state);
      BeginReceive(
        stateObj.Buffer,
        0,
        stateObj.Buffer.Length,
        ReadReply_Recv_End,
        stateObj);
      return stateObj;
    }

    private void ReadReply_Recv_End(IAsyncResult ar) {
      var stateObj = (ReadReply_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        var num = EndReceive(ar);
        if (0 == num) {
          stateObj.SetCompleted();
        }
        else {
          stateObj.Reply.Add(stateObj.Buffer, 0, num);

          // handle the end of reply
          var afterEndPos = FindReplyEnd(
            stateObj.Reply.Data,
            stateObj.Reply.Size);

          if (afterEndPos > 0) {
            if (afterEndPos < num) // read after reply finished?
            {
              // put data back into the buffer for further
              // processing in receive functions
              PutBufferData(stateObj.Buffer, afterEndPos, num - afterEndPos);
              stateObj.Reply.CutTail(num - afterEndPos);
            }

            stateObj.SetCompleted();
          }
          else {
            if (stateObj.Reply.Size > _maxReplySize)
              throw new ProtocolViolationException("Web proxy reply exceed maximum length.");

            BeginReceive(
              stateObj.Buffer,
              0,
              stateObj.Buffer.Length,
              ReadReply_Recv_End,
              stateObj);
          }
        }
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private ByteVector EndReadReply(IAsyncResult ar) {
      VerifyAsyncResult(ar, typeof(ReadReply_SO));
      HandleAsyncEnd(ar, false);
      return ((ReadReply_SO) ar).Reply;
    }

    #endregion

    #region Connect functions (overriden)

    internal override void Connect(string hostName, int hostPort) {
      CheckDisposed();

      SetProgress(true);
      try {
        if (null == hostName)
          throw new ArgumentNullException("hostName", "The value cannot be null.");

        if (hostPort < IPEndPoint.MinPort || hostPort > IPEndPoint.MaxPort)
          throw new ArgumentOutOfRangeException("hostPort", "Value, specified for the port is out of the valid range.");

        //------------------------------------
        // Get end point for the proxy server
        var proxyEntry = GetHostByName(ProxyServer);
        if (null == proxyEntry)
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        // throw new HostNotFoundException("Unable to resolve proxy name.");

        IPEndPoint proxyEndPoint;
        if (ProxyServer.Equals("127.0.0.1"))
          proxyEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), ProxyPort);
        else
          proxyEndPoint = ConstructEndPoint(proxyEntry, ProxyPort);

        //------------------------------------------
        // Connect to proxy server
        Socket.Connect(proxyEndPoint);

        var useCredentials = PreAuthenticate;
        while (true) {
          //------------------------------------------
          // Send CONNECT command
          var cmd = GetConnectCmd(hostName, hostPort, useCredentials);
          NStream.Write(cmd, 0, cmd.Length);

          //-----------------------------------------
          // Read the reply
          var reply = ReadReply();

          //------------------------------------------
          // Analyze reply
          string reason = null;
          var code = AnalyzeReply(reply, out reason);

          //------------------------------------------
          // is good return code?
          if (code >= 200 && code <= 299)
            return;

          //------------------------------------------
          // If Proxy Authentication Required
          // but we do not issued it, then try again
          if (407 == code &&
              !useCredentials &&
              ProxyUser != null) {
            useCredentials = true;
            continue;
          }

          // string msg = string.Format("Connection refused by web proxy: {0} ({1}).", reason, code);
          // throw new ProxyErrorException(msg);
          throw new SocketException(SockErrors.WSAECONNREFUSED);
        }
      }
      finally {
        SetProgress(false);
      }
    }

    internal override void Connect(EndPoint remoteEP) {
      if (null == remoteEP)
        throw new ArgumentNullException("remoteEP", "The value cannot be null.");

      var ipEP = (IPEndPoint) remoteEP;
      var hostName = ipEP.Address.ToString();
      var port = ipEP.Port;
      Connect(hostName, port);
    }

    internal override IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback callback, object state) {
      if (null == remoteEP)
        throw new ArgumentNullException("remoteEP", "The value cannot be null.");

      var ipEP = (IPEndPoint) remoteEP;
      var hostName = ipEP.Address.ToString();
      var port = ipEP.Port;
      return BeginConnect(hostName, port, callback, state);
    }

    internal override IAsyncResult BeginConnect(
      string hostName,
      int hostPort,
      AsyncCallback callback,
      object state) {
      Connect_SO stateObj;
      CheckDisposed();

      if (null == hostName)
        throw new ArgumentNullException("hostName", "The value cannot be null.");

      if (hostPort < IPEndPoint.MinPort || hostPort > IPEndPoint.MaxPort)
        throw new ArgumentOutOfRangeException("hostPort", "Value, specified for the port is out of the valid range.");

      SetProgress(true);
      try {
        stateObj = new Connect_SO(
          hostName,
          hostPort,
          PreAuthenticate,
          callback,
          state);

        //------------------------------------
        // Get end point for the proxy server
        BeginGetHostByName(
          ProxyServer,
          Connect_GetPrxHost_End,
          stateObj);
      }
      catch (Exception e) {
        SetProgress(false);
        throw e;
      }

      return stateObj;
    }

    private void Connect_GetPrxHost_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        var proxyEntry = EndGetHostByName(ar);
        if (null == proxyEntry)
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        // throw new HostNotFoundException("Unable to resolve proxy name.");

        var proxyEndPoint = ConstructEndPoint(proxyEntry, ProxyPort);

        //------------------------------------------
        // Connect to proxy server
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

        //------------------------------------------
        // Send CONNECT command
        var cmd = GetConnectCmd(
          stateObj.HostName,
          stateObj.HostPort,
          stateObj.UseCredentials);

        NStream.BeginWrite(cmd, 0, cmd.Length,
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

        //-----------------------------------------
        // Read the reply
        BeginReadReply(Connect_ReadReply_End, stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Connect_ReadReply_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        var reply = EndReadReply(ar);

        //------------------------------------------
        // Analyze reply
        string reason = null;
        var code = AnalyzeReply(reply, out reason);

        //------------------------------------------
        // is good return code?
        if (code >= 200 && code <= 299) {
          stateObj.SetCompleted();
        }
        else if (407 == code &&
                 !stateObj.UseCredentials &&
                 ProxyUser != null) {
          //------------------------------------------
          // If Proxy Authentication Required
          // but we do not issued it, then try again

          stateObj.UseCredentials = true;

          //------------------------------------------
          // Send CONNECT command
          var cmd = GetConnectCmd(
            stateObj.HostName,
            stateObj.HostPort,
            stateObj.UseCredentials);

          NStream.BeginWrite(cmd, 0, cmd.Length,
            Connect_Write_End,
            stateObj);
        }
        else {
          // string msg = string.Format("Connection refused by web proxy: {0} ({1}).", reason, code);
          // throw new ProxyErrorException(msg);
          throw new SocketException(SockErrors.WSAECONNREFUSED);
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

    #region Receive functions (override)

    internal override int Receive(byte[] buffer) {
      CheckDisposed();

      var num = FetchBufferData(buffer, -1, -1);
      if (num > 0)
        return num;

      return base.Receive(buffer);
    }

    internal override int Receive(byte[] buffer, int size) {
      CheckDisposed();

      var num = FetchBufferData(buffer, -1, size);
      if (num > 0)
        return num;

      return base.Receive(buffer, size);
    }

    internal override int Receive(byte[] buffer, int offset, int size) {
      CheckDisposed();

      var num = FetchBufferData(buffer, offset, size);
      if (num > 0)
        return num;

      return base.Receive(buffer, offset, size);
    }

    internal override IAsyncResult BeginReceive(
      byte[] buffer,
      int offset,
      int size,
      AsyncCallback callback,
      object state
    ) {
      Receive_SO stateObj;

      CheckDisposed();
      stateObj = new Receive_SO(callback, state);
      if ((stateObj.Read = FetchBufferData(buffer, offset, size)) > 0) {
        stateObj.SetCompleted();
      }
      else {
        Socket.BeginReceive(
          buffer,
          offset,
          size,
          SocketFlags.None,
          Receive_End,
          stateObj);
      }

      return stateObj;
    }

    private void Receive_End(IAsyncResult ar) {
      var stateObj = (Receive_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        stateObj.Read = Socket.EndReceive(ar);
      }
      catch (Exception e) {
        stateObj.Exception = e;
      }

      stateObj.SetCompleted();
    }

    internal override int EndReceive(IAsyncResult asyncResult) {
      VerifyAsyncResult(asyncResult, typeof(Receive_SO), "EndReceive");
      HandleAsyncEnd(asyncResult, false);
      return ((Receive_SO) asyncResult).Read;
    }

    #endregion

    #region Accept functions (overriden) - not supported

    internal override SocketBase Accept() {
      ThrowUnsupportException("Accept");
      return null;
    }

    internal override IAsyncResult BeginAccept(AsyncCallback callback, object state) {
      ThrowUnsupportException("BeginAccept");
      return null;
    }

    internal override SocketBase EndAccept(IAsyncResult asyncResult) {
      ThrowUnsupportException("EndAccept");
      return null;
    }

    #endregion

    #region Bind functions (overriden) - not supported

    internal override void Bind(SocketBase baseSocket) {
      ThrowUnsupportException("Bind");
    }

    internal override IAsyncResult BeginBind(SocketBase baseSocket, AsyncCallback callback, object state) {
      ThrowUnsupportException("BeginBind");
      return null;
    }

    internal override void EndBind(IAsyncResult ar) {
      ThrowUnsupportException("EndBind");
    }

    #endregion

    #region Listen function (overriden) - not supported

    internal override void Listen(int backlog) {
      ThrowUnsupportException("Listen");
    }

    #endregion
  }
}