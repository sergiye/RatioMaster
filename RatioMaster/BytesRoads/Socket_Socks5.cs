using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RatioMaster.BytesRoads {
  internal enum AuthMethod {
    None,
    UsernamePassword,
    NoAcceptable
  }

  internal enum ATYP {
    IPv4 = 1,
    DomName = 3,
    IPv6 = 4
  }

  /// <summary>
  /// Summary description for Socket_Socks5.
  /// </summary>
  internal class Socket_Socks5 : SocketBase {
    #region Async classes

    private class ReadVerifyReply_SO : AsyncResultBase {
      internal ReadVerifyReply_SO(AsyncCallback cb, object state)
        : base(cb, state) {
      }

      internal byte[] Phase1Data { get; } = new byte[5];

      internal byte[] Reply { get; set; }
    }

    private class UsernamePassword_SO : AsyncResultBase {
      internal UsernamePassword_SO(AsyncCallback cb, object state)
        : base(cb, state) {
      }

      internal byte[] Reply { get; } = new byte[2];
    }

    private class DoAuthentication_SO : AsyncResultBase {
      internal DoAuthentication_SO(AsyncCallback cb, object state)
        : base(cb, state) {
      }
    }

    private class ReadWhole_SO : AsyncResultBase {
      internal ReadWhole_SO(
        byte[] buffer,
        int offset,
        int size,
        AsyncCallback cb,
        object state)
        : base(cb, state) {
        Buffer = buffer;
        Offset = offset;
        Size = size;
      }

      internal byte[] Buffer { get; }

      internal int Read { get; set; }

      internal int Size { get; }

      internal int Offset { get; }
    }

    private class Negotiation_SO : AsyncResultBase {
      internal Negotiation_SO(
        bool useCredentials,
        AsyncCallback cb,
        object state) : base(cb, state) {
        UseCredentials = useCredentials;
      }

      internal byte[] Reply { get; } = new byte[2];

      internal bool UseCredentials { get; set; }
    }

    private class Connect_SO : AsyncResultBase {
      internal Connect_SO(
        EndPoint remoteEndPoint,
        string hostName,
        int hostPort,
        AsyncCallback cb,
        object state) : base(cb, state) {
        RemoteEndPoint = remoteEndPoint;
        HostPort = hostPort;
        HostName = hostName;
      }

      internal int HostPort { get; } = -1;

      internal string HostName { get; }

      internal EndPoint RemoteEndPoint { get; set; }

      internal int ReadBytes { get; set; }
    }

    private class Bind_SO : AsyncResultBase {
      internal Bind_SO(
        Socket_Socks5 baseSocket,
        AsyncCallback cb,
        object state) : base(cb, state) {
        BaseSocket = baseSocket;
      }

      internal Socket_Socks5 BaseSocket { get; }

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

    // policy switches
    private bool _resolveHostEnabled = true;

    // remote host information
    private string _remoteHost;
    private int _remotePort = -1;

    // End points
    private EndPoint _localEndPoint;
    private EndPoint _remoteEndPoint;

    internal Socket_Socks5(
      string proxyServer,
      int proxyPort,
      byte[] proxyUser,
      byte[] proxyPassword)
      : base(proxyServer, proxyPort, proxyUser, proxyPassword) {
    }

    #region Attributes

    internal override ProxyType ProxyType => ProxyType.Socks5;

    internal override EndPoint LocalEndPoint => _localEndPoint;

    internal override EndPoint RemoteEndPoint => _remoteEndPoint;

    #endregion

    #region Helper functions

    private IPEndPoint ExtractReplyAddr(byte[] reply) {
      var atyp = reply[3];
      if (atyp != (byte) ATYP.IPv4) {
        var msg = string.Format("Socks5: Address type in reply is unknown ({0}).", atyp);
        throw new ArgumentException(msg, "reply");
      }

      var port = (reply[8] << 8) | reply[9];
      long ip = (reply[7] << 24) |
                (reply[6] << 16) |
                (reply[5] << 8) |
                reply[4];
      ip &= 0xFFFFFFFF;

      return new IPEndPoint(new IPAddress(ip), port);
    }

    private byte[] PrepareCmd(EndPoint remoteEP, byte cmdVal) {
      if (null == remoteEP)
        throw new ArgumentNullException("remoteEP", "The value cannot be null.");

      var cmd = new byte[10];
      var ip = (IPEndPoint) remoteEP;

      //------------------------------
      // Compose header
      //
      cmd[0] = 5; // version
      cmd[1] = cmdVal; // command
      cmd[2] = 0; // reserved
      cmd[3] = 1; // ATYPE - 1 for address as IP4

      //------------------------------
      // Store IP address
      //
      var ipAddr = ip.Address.Address;
      cmd[4] = (byte) (ipAddr & 0x000000FF);
      cmd[5] = (byte) ((ipAddr & 0x0000FF00) >> 8);
      cmd[6] = (byte) ((ipAddr & 0x00FF0000) >> 16);
      cmd[7] = (byte) ((ipAddr & 0xFF000000) >> 24);

      //------------------------------
      // Store port
      cmd[8] = (byte) ((ip.Port & 0xFF00) >> 8);
      cmd[9] = (byte) (ip.Port & 0xFF);

      return cmd;
    }

    private byte[] PrepareCmd(string remoteHost, int remotePort, byte cmdVal) {
      if (null == remoteHost)
        throw new ArgumentNullException("remoteHost", "The value cannot be null.");

      var hostLength = remoteHost.Length;
      if (hostLength > 255)
        throw new ArgumentException("Name of destination host cannot be more then 255 characters.", "remoteHost");

      var cmd = new byte[4 + 1 + hostLength + 2];

      //----------------------------------
      // Compose header
      //
      cmd[0] = 5; // version
      cmd[1] = cmdVal; // command
      cmd[2] = 0; // reserved
      cmd[3] = 3; // domain name as address

      //----------------------------------
      // Store host name as address
      //
      cmd[4] = (byte) hostLength;
      var name = Encoding.Default.GetBytes(remoteHost);
      Array.Copy(name, 0, cmd, 5, hostLength);

      //----------------------------------
      // Store the port
      //
      cmd[5 + hostLength] = (byte) ((remotePort & 0xFF00) >> 8);
      cmd[5 + hostLength + 1] = (byte) (remotePort & 0xFF);

      return cmd;
    }

    private byte[] PrepareBindCmd(Socket_Socks5 baseSocket) {
      if (null != baseSocket.RemoteEndPoint)
        return PrepareCmd(baseSocket.RemoteEndPoint, 2);
      else if (null != baseSocket._remoteHost)
        return PrepareCmd(baseSocket._remoteHost, baseSocket._remotePort, 2);
      else
        throw new InvalidOperationException("Unable to prepare bind command because of insufficient information.");
    }

    private byte[] PrepareConnectCmd(EndPoint remoteEP, string hostName, int hostPort) {
      if (null != remoteEP)
        return PrepareCmd(remoteEP, 1);
      else if (null != hostName)
        return PrepareCmd(hostName, hostPort, 1);
      else
        throw new InvalidOperationException("Unable to prepare connect command because of insufficient information.");
    }

    #endregion

    #region ReadWhole functions

    private void ReadWhole(byte[] buffer, int offset, int size) {
      var read = 0;
      while (read < size)
        read += NStream.Read(buffer, offset + read, size - read);
    }

    private IAsyncResult BeginReadWhole(
      byte[] buffer,
      int offset,
      int size,
      AsyncCallback cb,
      object state) {
      var stateObj = new ReadWhole_SO(buffer, offset, size, cb, state);

      NStream.BeginRead(buffer, offset, size,
        ReadWhole_Read_End,
        stateObj);

      return stateObj;
    }

    private void ReadWhole_Read_End(IAsyncResult ar) {
      var stateObj = (ReadWhole_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        stateObj.Read += NStream.EndRead(ar);
        if (stateObj.Read < stateObj.Size) {
          NStream.BeginRead(
            stateObj.Buffer,
            stateObj.Offset + stateObj.Read,
            stateObj.Size - stateObj.Read,
            ReadWhole_Read_End,
            stateObj);
        }
        else {
          stateObj.SetCompleted();
        }
      }
      catch (Exception e) {
        stateObj.Exception = e;

        stateObj.SetCompleted();
      }
    }

    private void EndReadWhole(IAsyncResult ar) {
      VerifyAsyncResult(ar, typeof(ReadWhole_SO));
      HandleAsyncEnd(ar, false);
    }

    #endregion

    #region Negotiation functions

    #region Username/password negotiation

    private void Validate_UsernamePasswordReply(byte[] reply) {
      if (1 != reply[0]) {
        var msg = string.Format("Socks5: Unknown reply format for username/password authentication ({0}).",
          reply[0]);
        throw new ProtocolViolationException(msg);
      }

      if (0 != reply[1]) {
        var msg = string.Format("Socks5: Username/password authentication failed ({0}).", reply[1]);
        msg.ToString();
        throw new SocketException(SockErrors.WSAECONNREFUSED);
      }
    }

    private byte[] Prepare_UsernamePasswordCmd() {
      if (null == ProxyUser)
        throw new ArgumentNullException("ProxyUser", "The value cannot be null.");

      var userLength = ProxyUser.Length;
      if (userLength > 255)
        throw new ArgumentException("Proxy user name cannot be more then 255 characters.", "ProxyUser");

      var passwordLength = 0;
      if (null != ProxyPassword) {
        passwordLength = ProxyPassword.Length;
        if (passwordLength > 255)
          throw new ArgumentException("Proxy password cannot be more then 255 characters.", "ProxyPassword");
      }

      var cmd = new byte[1 + 1 + userLength + 1 + passwordLength];

      //------------------------------
      // Compose the header
      cmd[0] = 1; // version

      //------------------------------
      // Store user name
      cmd[1] = (byte) userLength;
      Array.Copy(ProxyUser, 0, cmd, 2, userLength);

      //------------------------------
      // Store password if exists
      cmd[2 + userLength] = (byte) passwordLength;
      if (passwordLength > 0)
        Array.Copy(ProxyPassword, 0, cmd, 3 + userLength, passwordLength);

      return cmd;
    }

    private void SubNegotiation_UsernamePassword() {
      //---------------------------------------
      // Prepare authentication information
      var cmd = Prepare_UsernamePasswordCmd();

      //---------------------------------------
      // Send authentication information
      NStream.Write(cmd, 0, cmd.Length);

      //---------------------------------------
      // Read the response
      var res = new byte[2];
      ReadWhole(res, 0, 2);

      //---------------------------------------
      // Validate server response
      Validate_UsernamePasswordReply(res);
    }


    private IAsyncResult BeginSubNegotiation_UsernamePassword(
      AsyncCallback cb,
      object state) {
      //---------------------------------------
      // Prepare authentication information
      var cmd = Prepare_UsernamePasswordCmd();

      var stateObj = new UsernamePassword_SO(cb, state);

      //---------------------------------------
      // Send authentication information
      NStream.BeginWrite(
        cmd,
        0,
        cmd.Length,
        SubUsernamePassword_Write_End,
        stateObj);

      return stateObj;
    }

    private void SubUsernamePassword_Write_End(IAsyncResult ar) {
      var stateObj = (UsernamePassword_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        NStream.EndWrite(ar);

        //---------------------------------------
        // Send authentication information
        BeginReadWhole(
          stateObj.Reply,
          0,
          2,
          SubUsernamePassword_Read_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void SubUsernamePassword_Read_End(IAsyncResult ar) {
      var stateObj = (UsernamePassword_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        EndReadWhole(ar);

        //---------------------------------------
        // Validate server response
        Validate_UsernamePasswordReply(stateObj.Reply);
      }
      catch (Exception e) {
        stateObj.Exception = e;
      }

      stateObj.SetCompleted();
    }

    private void EndSubNegotiation_UsernamePassword(IAsyncResult ar) {
      VerifyAsyncResult(ar, typeof(UsernamePassword_SO));
      HandleAsyncEnd(ar, true);
    }

    #endregion

    private AuthMethod ExtractAuthMethod(byte[] reply) {
      //------------------------------------
      // Check the reply header
      if (reply[0] != 5) {
        var msg = string.Format("Socks5 server returns reply with unknown version ({0}).", reply[0]);
        throw new ProtocolViolationException(msg);
      }

      //------------------------------------
      // Dispatch method chosen to particular
      // sub negotiation or throw the 
      // exception.
      //
      var method = reply[1];
      if (0 == method) // no authentication required
      {
        return AuthMethod.None;
      }
      else if (2 == method) // Username/password
      {
        return AuthMethod.UsernamePassword;
      }
      else if (0xFF == method) // no acceptable methods
      {
        return AuthMethod.NoAcceptable;
      }
      else {
        // it is a violation of protocol
        var msg = string.Format("Socks5 server requires not declared authentication method ({0}).", method);
        throw new ProtocolViolationException(msg);
      }
    }

    private void DoAuthentication(AuthMethod method) {
      if (AuthMethod.None == method)
        return;

      if (AuthMethod.UsernamePassword == method) {
        SubNegotiation_UsernamePassword();
      }
      else if (AuthMethod.NoAcceptable == method) {
        // throw new AuthFailedException("No acceptable methods.");
        throw new SocketException(SockErrors.WSAECONNREFUSED);
      }
      else {
        // throw invalid operation because 
        // method is unknown and execution should be stoped proir
        // this point
        throw new InvalidOperationException("Unknown authentication requested.");
      }
    }

    private IAsyncResult BeginDoAuthentication(
      AuthMethod method,
      AsyncCallback cb,
      object state) {
      var stateObj = new DoAuthentication_SO(cb, state);
      if (AuthMethod.UsernamePassword == method) {
        BeginSubNegotiation_UsernamePassword(
          SubNegotiation_UsernamePassword_End,
          stateObj);
      }
      else if (AuthMethod.NoAcceptable == method) {
        // throw new AuthFailedException("No acceptable methods.");
        throw new SocketException(SockErrors.WSAECONNREFUSED);
      }
      else if (AuthMethod.None != method) {
        throw new InvalidOperationException("Unknown authentication requested.");
      }
      else {
        stateObj.SetCompleted();
      }

      return stateObj;
    }

    private void SubNegotiation_UsernamePassword_End(IAsyncResult ar) {
      var stateObj = (DoAuthentication_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        EndSubNegotiation_UsernamePassword(ar);
      }
      catch (Exception e) {
        stateObj.Exception = e;
      }

      stateObj.SetCompleted();
    }

    private void EndDoAuthentication(IAsyncResult ar) {
      VerifyAsyncResult(ar, typeof(DoAuthentication_SO));
      HandleAsyncEnd(ar, false);
    }

    private byte[] PrepareNegotiationCmd(bool useCredentials) {
      byte[] cmd;

      if (useCredentials) {
        cmd = new byte[4];
        cmd[0] = 5; // version
        cmd[1] = 2; // number of supported methods
        cmd[2] = 0; // no authentication
        cmd[3] = 2; // username/password
      }
      else {
        cmd = new byte[3];
        cmd[0] = 5; // version
        cmd[1] = 1; // number of supported methods
        cmd[2] = 0; // no authentication
      }

      return cmd;
    }

    private void Negotiate() {
      var useCredentials = PreAuthenticate;
      if (null == ProxyUser)
        useCredentials = false;

      AuthMethod authMethod;
      while (true) {
        //----------------------------------------------
        // Send negotiation request
        var cmd = PrepareNegotiationCmd(useCredentials);
        NStream.Write(cmd, 0, cmd.Length);

        //----------------------------------------------
        // Read negotiation reply with supported methods
        var reply = new byte[2];
        ReadWhole(reply, 0, 2);

        //----------------------------------------------
        // Extract demanded authentication method
        authMethod = ExtractAuthMethod(reply);
        if (AuthMethod.NoAcceptable == authMethod &&
            !useCredentials &&
            null != ProxyUser) {
          useCredentials = true;
          continue;
        }

        break;
      }

      //-------------------------------------------
      // Run appropriate authentication if required
      DoAuthentication(authMethod);
    }

    private IAsyncResult BeginNegotiate(AsyncCallback callback, object state) {
      var useCredentials = PreAuthenticate;
      if (null == ProxyUser)
        useCredentials = false;

      var stateObj = new Negotiation_SO(
        useCredentials,
        callback,
        state);

      //-----------------------------------
      // Send negotiation request
      var cmd = PrepareNegotiationCmd(stateObj.UseCredentials);
      NStream.BeginWrite(
        cmd,
        0,
        cmd.Length,
        Negotiate_Write_End,
        stateObj);

      return stateObj;
    }

    private void Negotiate_Write_End(IAsyncResult ar) {
      var stateObj = (Negotiation_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        NStream.EndWrite(ar);

        //-----------------------------------
        // Read negotiation reply with 
        // supported methods
        //
        BeginReadWhole(
          stateObj.Reply,
          0,
          2,
          Negotiate_ReadWhole_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Negotiate_ReadWhole_End(IAsyncResult ar) {
      var stateObj = (Negotiation_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        EndReadWhole(ar);

        //----------------------------------------------
        // Extract demanded authentication method
        var authMethod = ExtractAuthMethod(stateObj.Reply);
        if (AuthMethod.NoAcceptable == authMethod &&
            !stateObj.UseCredentials &&
            null != ProxyUser) {
          stateObj.UseCredentials = true;

          //-----------------------------------
          // Send negotiation request
          var cmd = PrepareNegotiationCmd(stateObj.UseCredentials);
          NStream.BeginWrite(
            cmd,
            0,
            cmd.Length,
            Negotiate_Write_End,
            stateObj);
        }
        else {
          //-----------------------------------
          // Run appropriate authentication 
          // method
          BeginDoAuthentication(
            authMethod,
            Negotiate_DoAuth_End,
            stateObj);
        }
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Negotiate_DoAuth_End(IAsyncResult ar) {
      var stateObj = (Negotiation_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        EndDoAuthentication(ar);
      }
      catch (Exception e) {
        stateObj.Exception = e;
      }

      stateObj.SetCompleted();
    }

    private void EndNegotiate(IAsyncResult ar) {
      VerifyAsyncResult(ar, typeof(Negotiation_SO));
      HandleAsyncEnd(ar, false);
    }

    #endregion

    #region ReadVerifyReply functions

    private void CheckReplyVer(byte[] reply) {
      if (5 != reply[0]) {
        var msg = string.Format("Socks5: Unknown format of reply ({0}).", reply[0]);
        throw new ProtocolViolationException(msg);
      }
    }

    private void CheckReplyForError(byte[] reply) {
      var rep = reply[1];
      if (0 == rep)
        return;

      string msg;
      if (1 == rep)
        msg = "Socks5: General SOCKS server failure.";
      else if (2 == rep)
        msg = "Socks5: Connection not allowed by rule set.";
      else if (3 == rep)
        msg = "Socks5: Network unreachable.";
      else if (4 == rep)
        msg = "Socks5: Host unreachable.";
      else if (5 == rep)
        msg = "Socks5: Connection refused.";
      else if (6 == rep)
        msg = "Socks5: TTL expired.";
      else if (7 == rep)
        msg = "Socks5: Command not supported.";
      else if (8 == rep)
        msg = "Socks5: Address type not supported.";
      else
        msg = string.Format("Socks5: Reply code is unknown ({0}).", rep);
      msg.ToString();
      throw new SocketException(SockErrors.WSAECONNREFUSED);

      // throw new ProxyErrorException(msg);
    }

    private int GetAddrFieldLength(byte[] reply) {
      var atyp = reply[3];
      if (1 == atyp) // IP4 address?
        return 4;
      else if (3 == atyp) // domain name?
        return 1 + reply[4];
      else if (4 == atyp)
        return 16;
      else {
        var msg = string.Format("Socks5: Unknown address type in reply ({0}).", atyp);
        throw new ProtocolViolationException(msg);
      }
    }

    private int VerifyReplyAndGetLeftBytes(byte[] reply) {
      //----------------------------------
      // Check reply version
      CheckReplyVer(reply);

      //------------------------------------------
      // Check for error condition
      CheckReplyForError(reply);

      //------------------------------------------
      // Calculate number of bytes left to read:
      // address length - 1(because one byte from
      // address field was read in phase 1) + port
      return GetAddrFieldLength(reply) - 1 + 2;
    }

    private byte[] ReadVerifyReply() {
      //-----------------------------------
      // Phase 1. Read 5 bytes
      var phase1Data = new byte[5];
      ReadWhole(phase1Data, 0, 5);


      var leftBytes = VerifyReplyAndGetLeftBytes(phase1Data);

      //-----------------------------------
      // Phase 2. Read left data 
      var reply = new byte[5 + leftBytes];
      phase1Data.CopyTo(reply, 0);
      ReadWhole(reply, 5, leftBytes);
      return reply;
    }

    private IAsyncResult BeginReadVerifyReply(AsyncCallback cb, object state) {
      var stateObj = new ReadVerifyReply_SO(cb, state);
      BeginReadWhole(stateObj.Phase1Data, 0, 5,
        Phase1_End, stateObj);
      return stateObj;
    }

    private void Phase1_End(IAsyncResult ar) {
      var stateObj = (ReadVerifyReply_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        EndReadWhole(ar);

        var leftBytes = VerifyReplyAndGetLeftBytes(stateObj.Phase1Data);

        //-----------------------------------
        // Phase 2. Read left data 
        stateObj.Reply = new byte[5 + leftBytes];
        stateObj.Phase1Data.CopyTo(stateObj.Reply, 0);
        BeginReadWhole(stateObj.Reply, 5, leftBytes,
          Phase2_End, stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Phase2_End(IAsyncResult ar) {
      var stateObj = (ReadVerifyReply_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        EndReadWhole(ar);
      }
      catch (Exception e) {
        stateObj.Exception = e;
      }

      stateObj.SetCompleted();
    }

    private byte[] EndReadVerifyReply(IAsyncResult ar) {
      VerifyAsyncResult(ar, typeof(ReadVerifyReply_SO));
      HandleAsyncEnd(ar, false);
      return ((ReadVerifyReply_SO) ar).Reply;
    }

    #endregion

    #region Accept functions (overriden)

    internal override SocketBase Accept() {
      CheckDisposed();
      SetProgress(true);
      try {
        var reply = ReadVerifyReply();
        _remoteEndPoint = ExtractReplyAddr(reply);
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
        BeginReadVerifyReply(Accept_Read_End, stateObj);
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
        var reply = EndReadVerifyReply(ar);
        _remoteEndPoint = ExtractReplyAddr(reply);
      }
      catch (Exception e) {
        stateObj.Exception = e;
      }

      stateObj.SetCompleted();
    }

    internal override SocketBase EndAccept(IAsyncResult asyncResult) {
      VerifyAsyncResult(asyncResult, typeof(Accept_SO), "EndAccept");
      HandleAsyncEnd(asyncResult, true);
      return this;
    }

    #endregion

    #region Connect functions (overriden)

    internal override void Connect(string hostName, int hostPort) {
      if (null == hostName)
        throw new ArgumentNullException("hostName", "The value cannot be null.");

      if (hostPort < IPEndPoint.MinPort || hostPort > IPEndPoint.MaxPort)
        throw new ArgumentOutOfRangeException("hostPort", "Value, specified for the port is out of the valid range.");

      Connect(null, hostName, hostPort);
    }

    internal override void Connect(EndPoint remoteEP) {
      if (null == remoteEP)
        throw new ArgumentNullException("remoteEP", "The value cannot be null.");

      Connect(remoteEP, null, -1);
    }

    private void Connect(EndPoint remoteEP, string hostName, int hostPort) {
      CheckDisposed();
      SetProgress(true);
      try {
        if (null == remoteEP) {
          if (_resolveHostEnabled) {
            var host = GetHostByName(hostName);
            if (null != host)
              remoteEP = ConstructEndPoint(host, hostPort);
          }

          if (null == hostName && null == remoteEP)
            throw new ArgumentNullException("hostName", "The value cannot be null.");
        }

        //------------------------------------
        // Get end point for the proxy server
        //
        var proxyEntry = GetHostByName(ProxyServer);
        if (null == proxyEntry)
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        // throw new HostNotFoundException("Unable to resolve proxy name.");

        var proxyEndPoint = ConstructEndPoint(proxyEntry, ProxyPort);

        //------------------------------------------
        // Connect to proxy server
        //
        Socket.Connect(proxyEndPoint);

        //------------------------------------------
        // Negotiate user
        Negotiate();

        //------------------------------------------
        // Send CONNECT command
        //
        var cmd = PrepareConnectCmd(remoteEP, hostName, hostPort);
        NStream.Write(cmd, 0, cmd.Length);

        //------------------------------------------
        // Read and verify reply from proxy the server. 
        //
        var reply = ReadVerifyReply();
        _localEndPoint = ExtractReplyAddr(reply);
        _remoteEndPoint = remoteEP;

        //---------------------------------------
        // I we unable to resolve remote host then
        // store information - it will required
        // later for BIND command.
        if (null == remoteEP) {
          _remotePort = hostPort;
          _remoteHost = hostName;
        }
      }
      finally {
        SetProgress(false);
      }
    }

    internal override IAsyncResult BeginConnect(
      string hostName,
      int hostPort,
      AsyncCallback callback,
      object state) {
      CheckDisposed();

      if (null == hostName)
        throw new ArgumentNullException("hostName", "The value cannot be null.");

      if (hostPort < IPEndPoint.MinPort || hostPort > IPEndPoint.MaxPort)
        throw new ArgumentOutOfRangeException("hostPort", "Value, specified for the port is out of the valid range.");

      Connect_SO stateObj;
      SetProgress(true);
      try {
        stateObj = new Connect_SO(null, hostName, hostPort, callback, state);
        if (_resolveHostEnabled) {
          //--------------------------------------
          // Trying to resolve host name locally
          BeginGetHostByName(
            hostName,
            Connect_GetHost_Host_End,
            stateObj);
        }
        else {
          //-------------------------------------
          // Get end point for the proxy server
          //
          BeginGetHostByName(
            ProxyServer,
            Connect_GetHost_Proxy_End,
            stateObj);
        }
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
        if (null != host)
          stateObj.RemoteEndPoint = ConstructEndPoint(host, stateObj.HostPort);

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
      if (null == remoteEP)
        throw new ArgumentNullException("remoteEP", "The value cannot be null.");

      Connect_SO stateObj;
      SetProgress(true);
      try {
        stateObj = new Connect_SO(remoteEP, null, -1, callback, state);

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

        //------------------------------------------
        // Negotiate user
        BeginNegotiate(Connect_Negotiate_End, stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Connect_Negotiate_End(IAsyncResult ar) {
      var stateObj = (Connect_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        EndNegotiate(ar);

        //------------------------------------
        // Send CONNECT command
        //
        var cmd = PrepareConnectCmd(
          stateObj.RemoteEndPoint,
          stateObj.HostName,
          stateObj.HostPort);

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
        BeginReadVerifyReply(Connect_Read_End, stateObj);
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
        var reply = EndReadVerifyReply(ar);

        _localEndPoint = ExtractReplyAddr(reply);
        _remoteEndPoint = stateObj.RemoteEndPoint;

        //---------------------------------------
        // I we unable to resolve remote host then
        // store information - it will required
        // later for BIND command.
        if (null == stateObj.RemoteEndPoint) {
          _remotePort = stateObj.HostPort;
          _remoteHost = stateObj.HostName;
        }
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

    internal override void Bind(SocketBase socket) {
      CheckDisposed();
      SetProgress(true);
      try {
        //-----------------------------------------
        // Get end point for the proxy server
        //
        var host = GetHostByName(ProxyServer);
        if (host == null)
          throw new SocketException(SockErrors.WSAHOST_NOT_FOUND);

        // throw new HostNotFoundException("Unable to resolve proxy host name.");

        var proxyEndPoint = ConstructEndPoint(host, ProxyPort);

        //-----------------------------------------
        // Connect to proxy server
        //
        Socket.Connect(proxyEndPoint);

        //------------------------------------------
        // Negotiate user
        Negotiate();

        //-----------------------------------------
        // Send BIND command
        //
        var cmd = PrepareBindCmd((Socket_Socks5) socket);
        NStream.Write(cmd, 0, cmd.Length);

        //-----------------------------------------
        // Read the reply from the proxy server. 
        var reply = ReadVerifyReply();
        _localEndPoint = ExtractReplyAddr(reply);

        // remote end point is unknown till accept
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

      if (null == baseSocket)
        throw new ArgumentNullException("baseSocket", "The value cannot be null");

      Bind_SO stateObj;
      SetProgress(true);
      try {
        stateObj = new Bind_SO((Socket_Socks5) baseSocket, callback, state);

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

        //------------------------------------------
        // Negotiate user
        BeginNegotiate(
          Bind_Negotiate_End,
          stateObj);
      }
      catch (Exception e) {
        stateObj.Exception = e;
        stateObj.SetCompleted();
      }
    }

    private void Bind_Negotiate_End(IAsyncResult ar) {
      var stateObj = (Bind_SO) ar.AsyncState;
      try {
        stateObj.UpdateContext();
        EndNegotiate(ar);

        //------------------------------------
        // Send BIND command
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
        BeginReadVerifyReply(Bind_Read_End, stateObj);
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
        var reply = EndReadVerifyReply(ar);
        _localEndPoint = ExtractReplyAddr(reply);
        _remoteEndPoint = null;
      }
      catch (Exception e) {
        stateObj.Exception = e;
      }

      stateObj.SetCompleted();
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