using System;
using System.Net;
using System.Net.Sockets;

namespace RatioMaster.BytesRoads {
  /// <summary>
  /// Summary description for Socket_None.
  /// </summary>
  internal class Socket_None : SocketBase {
    #region Async classes

    private class Bind_SO : AsyncResultBase {
      internal Bind_SO(AsyncCallback cb, object state) : base(cb, state) {
      }
    }

    private class Connect_SO : AsyncResultBase {
      internal Connect_SO(int port, AsyncCallback cb, object state) : base(cb, state) {
        Port = port;
      }

      internal int Port { get; }
    }

    #endregion

    internal Socket_None() {
    }

    internal Socket_None(Socket systemSocket) : base(systemSocket) {
    }

    #region Attributes

    internal override ProxyType ProxyType => ProxyType.None;

    internal override EndPoint LocalEndPoint => Socket.LocalEndPoint;

    internal override EndPoint RemoteEndPoint => Socket.RemoteEndPoint;

    #endregion

    #region Helpers

    #endregion

    #region Accept functions (overriden)

    internal override SocketBase Accept() {
      CheckDisposed();
      return new Socket_None(Socket.Accept());
    }

    internal override IAsyncResult BeginAccept(AsyncCallback callback, object state) {
      CheckDisposed();
      return Socket.BeginAccept(callback, state);
    }

    internal override SocketBase EndAccept(IAsyncResult asyncResult) {
      return new Socket_None(Socket.EndAccept(asyncResult));
    }

    #endregion

    #region Connect functions (overriden)

    internal override void Connect(EndPoint remoteEP) {
      CheckDisposed();
      Socket.Connect(remoteEP);
    }

    internal override IAsyncResult BeginConnect(
      EndPoint remoteEP,
      AsyncCallback callback,
      object state) {
      CheckDisposed();
      Connect_SO stateObj;
      SetProgress(true);
      try {
        stateObj = new Connect_SO(-1, callback, state);

        Socket.BeginConnect(
          remoteEP,
          Connect_End,
          stateObj);
      }
      catch (Exception) {
        SetProgress(false);
        throw;
      }

      return stateObj;
    }

    internal override IAsyncResult BeginConnect(
      string hostName,
      int port,
      AsyncCallback callback,
      object state) {
      CheckDisposed();
      SetProgress(true);
      Connect_SO stateObj;
      try {
        stateObj = new Connect_SO(port, callback, state);
        Dns.BeginGetHostEntry(hostName, GetHost_End, stateObj);
      }
      catch (Exception) {
        SetProgress(false);
        throw;
      }

      return stateObj;
    }

    private void GetHost_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        var host = Dns.EndGetHostEntry(ar);
        if (null == host)
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        // throw new HostNotFoundException("Unable to resolve host name.");

        EndPoint remoteEP = ConstructEndPoint(host, stateObj.Port);
        Socket.BeginConnect(
          remoteEP,
          Connect_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Connect_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        Socket.EndConnect(ar);
      }
      catch (Exception e) {
        stateObj.Exception = e;
      }

      stateObj.SetCompleted();
    }

    internal override void EndConnect(IAsyncResult asyncResult) {
      VerifyAsyncResult(asyncResult, typeof(Connect_SO), "EndConnect");
      HandleAsyncEnd(asyncResult, true);
    }

    #endregion

    #region Bind functions (overriden)

    internal override void Bind(SocketBase baseSocket) {
      CheckDisposed();
      var ep = (IPEndPoint) baseSocket.SystemSocket.LocalEndPoint;
      ep.Port = 0;
      Socket.Bind(ep);
    }

    internal override IAsyncResult BeginBind(
      SocketBase baseSocket,
      AsyncCallback callback,
      object state) {
      CheckDisposed();
      var stateObj = new Bind_SO(callback, state);
      try {
        var ep = (IPEndPoint) baseSocket.SystemSocket.LocalEndPoint;
        ep.Port = 0;
        Socket.Bind(ep);
      }
      catch (Exception e) {
        stateObj.Exception = e;
      }

      stateObj.SetCompleted();
      return stateObj;
    }

    internal override void EndBind(IAsyncResult ar) {
      VerifyAsyncResult(ar, typeof(Bind_SO), "EndBind");
      HandleAsyncEnd(ar, false);
    }

    #endregion

    #region Listen function (overriden)

    internal override void Listen(int backlog) {
      CheckDisposed();
      Socket.Listen(backlog);
    }

    #endregion
  }
}