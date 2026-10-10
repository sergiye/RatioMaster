using System;
using System.Net;
using System.Net.Sockets;

namespace RatioMaster {
  internal static class Functions {
    internal static string GetIp() {
      try {
        foreach (var address in Dns.GetHostEntry(string.Empty).AddressList) {
          if (address.AddressFamily == AddressFamily.InterNetwork) {
            return address.ToString();
          }
        }
      }
      catch (Exception) {
      }

      return "127.0.0.1";
    }
  }
}