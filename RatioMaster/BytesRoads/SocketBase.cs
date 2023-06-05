using System;
using System.Net;
using System.Net.Sockets;

namespace RatioMaster.BytesRoads {
  /// <summary>
  /// Summary description for SocketBase.
  /// </summary>
  public abstract class SocketBase : AsyncBase, IDisposable {
    protected readonly Socket Socket;

    private NetworkStream _stream;
    // private static Random rand = new Random(unchecked((int) DateTime.Now.Ticks));

    private bool _disposed = false;

    // Proxy attributes
    protected readonly string ProxyServer;
    protected readonly int ProxyPort = -1;
    protected readonly byte[] ProxyUser;
    protected readonly byte[] ProxyPassword;

    protected SocketBase() {
      Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      Socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, 1);
    }

    protected SocketBase(
      string proxyServer,
      int proxyPort,
      byte[] proxyUser,
      byte[] proxyPassword) {
      ProxyServer = proxyServer;
      ProxyPort = proxyPort;
      ProxyUser = proxyUser;
      ProxyPassword = proxyPassword;
      Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    protected SocketBase(Socket systemSocket) {
      Socket = systemSocket ?? throw new ArgumentNullException(nameof(systemSocket));
    }

    #region Attributes

    internal virtual int Available => Socket.Available;

    internal bool Connected => Socket.Connected;

    protected NetworkStream NStream => _stream ?? (_stream = new NetworkStream(Socket, false));

    internal Socket SystemSocket => Socket;

    internal bool PreAuthenticate { get; set; } = true;

    internal abstract ProxyType ProxyType { get; }

    internal abstract EndPoint LocalEndPoint { get; }

    internal abstract EndPoint RemoteEndPoint { get; }

    #endregion

    #region DNS helpers

    internal static IPHostEntry GetHostByName(string hostName) {
      IPHostEntry host;
      try {
        host = Dns.GetHostEntry(hostName);
      }
      catch (Exception) {
        host = null;
      }

      return host;
    }

    internal static IAsyncResult BeginGetHostByName(string hostName, AsyncCallback cb, object state) {
      return Dns.BeginGetHostEntry(hostName, cb, state);
    }

    internal static IPHostEntry EndGetHostByName(IAsyncResult ar) {
      IPHostEntry host;
      try {
        host = Dns.EndGetHostEntry(ar);
      }
      catch (Exception) {
        host = null;
      }

      return host;
    }

    #endregion

    #region Helpers

    internal static IPEndPoint ConstructEndPoint(IPHostEntry host, int port) {
      if (0 >= host.AddressList.Length) {
        NsTrace.WriteLineError("Provided host structure do not contains addresses.");
        throw new ArgumentException("Provided host structure do not contains addresses.", nameof(host));
      }

      foreach (var addr in host.AddressList) {
        if (addr.AddressFamily == AddressFamily.InterNetwork)
          return new IPEndPoint(addr, port);
      }

      return new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
    }

    protected void CheckDisposed() {
      if (_disposed)
        throw new ObjectDisposedException(GetType().FullName);
    }

    #endregion

    #region Accept functions (abstract)

    internal abstract SocketBase Accept();

    internal abstract IAsyncResult BeginAccept(AsyncCallback callback, object state);

    internal abstract SocketBase EndAccept(IAsyncResult asyncResult);

    #endregion

    #region Connect functions (virtual and abstract)

    internal virtual void Connect(string hostName, int port) {
      CheckDisposed();

      var msg = string.Format("S: Resolving name '{0}'...", hostName);
      NsTrace.WriteLineInfo(msg);

      var host = GetHostByName(hostName);
      if (null == host) {
        NsTrace.WriteLineInfo("S: Hostname not found, throwing exception...");
        throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);
      }

      NsTrace.WriteLineInfo("S: Hostname found, connecting ...");
      Connect(ConstructEndPoint(host, port));
      NsTrace.WriteLineInfo("S: Connection established.");
    }

    internal abstract void Connect(EndPoint remoteEp);

    internal abstract IAsyncResult BeginConnect(string hostName, int port, AsyncCallback callback, object state);

    internal abstract IAsyncResult BeginConnect(EndPoint remoteEp, AsyncCallback callback, object state);

    internal abstract void EndConnect(IAsyncResult asyncResult);

    #endregion

    #region Bind functions (abstract)

    internal abstract void Bind(SocketBase socket);

    internal abstract IAsyncResult BeginBind(SocketBase socket, AsyncCallback callback, object state);

    internal abstract void EndBind(IAsyncResult ar);

    #endregion

    #region Listen function (abstract)

    internal abstract void Listen(int backlog);

    #endregion

    #region Shutdown function (virtual)

    internal virtual void Shutdown(SocketShutdown how) {
      CheckDisposed();
      Socket.Shutdown(how);
    }

    #endregion

    #region Receive functions (virtual)

    internal virtual int Receive(byte[] buffer) {
      CheckDisposed();
      return Socket.Receive(buffer);
    }

    internal virtual int Receive(byte[] buffer, int size) {
      CheckDisposed();
      return Socket.Receive(buffer, size, SocketFlags.None);
    }

    internal virtual int Receive(byte[] buffer, int offset, int size) {
      CheckDisposed();
      return Socket.Receive(buffer, offset, size, SocketFlags.None);
    }

    internal virtual IAsyncResult BeginReceive(
      byte[] buffer,
      int offset,
      int size,
      AsyncCallback callback,
      object state
    ) {
      CheckDisposed();
      return Socket.BeginReceive(buffer, offset, size, SocketFlags.None, callback, state);
    }

    internal virtual int EndReceive(IAsyncResult asyncResult) {
      return Socket.EndReceive(asyncResult);
    }

    #endregion

    #region Send functions (virtual)

    internal virtual int Send(byte[] buffer) {
      CheckDisposed();
      return Socket.Send(buffer);
    }

    internal virtual int Send(byte[] buffer, int size) {
      CheckDisposed();
      return Socket.Send(buffer, size, SocketFlags.None);
    }

    internal virtual int Send(byte[] buffer, int offset, int size) {
      CheckDisposed();
      return Socket.Send(buffer, offset, size, SocketFlags.None);
    }

    internal virtual IAsyncResult BeginSend(
      byte[] buffer,
      int offset,
      int size,
      AsyncCallback callback,
      object state
    ) {
      CheckDisposed();
      return Socket.BeginSend(buffer, offset, size,
        SocketFlags.None, callback, state);
    }

    internal virtual int EndSend(IAsyncResult asyncResult) {
      return Socket.EndSend(asyncResult);
    }

    #endregion

    #region SetSocketOption functions (virtual)

    internal virtual void SetSocketOption(
      SocketOptionLevel optionLevel,
      SocketOptionName optionName,
      byte[] optionValue
    ) {
      CheckDisposed();
      Socket.SetSocketOption(optionLevel, optionName, optionValue);
    }


    internal virtual void SetSocketOption(
      SocketOptionLevel optionLevel,
      SocketOptionName optionName,
      int optionValue
    ) {
      CheckDisposed();
      Socket.SetSocketOption(optionLevel, optionName, optionValue);
    }

    internal virtual void SetSocketOption(
      SocketOptionLevel optionLevel,
      SocketOptionName optionName,
      object optionValue
    ) {
      CheckDisposed();
      Socket.SetSocketOption(optionLevel, optionName, optionValue);
    }

    #endregion


    #region Disposing pattern

    ~SocketBase() {
      Dispose(false);
    }

    internal void Close() {
      Dispose();
    }

    public void Dispose() {
      GC.SuppressFinalize(this);
      Dispose(true);
    }

    protected virtual void Dispose(bool disposing) {
      lock (this) {
        if (disposing) {
        }

        Socket.Close();
      }
    }

    #endregion
  }
}