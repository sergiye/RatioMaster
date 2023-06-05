using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RatioMaster {
  internal class ProcessMemoryReader {
    [DllImport("kernel32.dll")]
    internal static extern int CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll")]
    internal static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

    [DllImport("kernel32.dll")]
    internal static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer,
      uint size, out IntPtr lpNumberOfBytesRead);

    private IntPtr m_hProcess;

    internal ProcessMemoryReader() {
      m_hProcess = IntPtr.Zero;
    }

    internal Process ReadProcess { get; set; }

    internal void CloseHandle() {
      if (CloseHandle(m_hProcess) == 0) {
        throw new Exception("CloseHandle failed");
      }
    }

    internal void OpenProcess() {
      m_hProcess = OpenProcess(0x10, 1, (uint) ReadProcess.Id);
    }

    internal byte[] ReadProcessMemory(IntPtr memoryAddress, uint bytesToRead, out int bytesRead) {
      var buffer = new byte[bytesToRead];
      ReadProcessMemory(m_hProcess, memoryAddress, buffer, bytesToRead, out var pointer);
      bytesRead = pointer.ToInt32();
      return buffer;
    }
  }
}