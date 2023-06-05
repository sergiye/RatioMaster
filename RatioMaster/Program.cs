using System;
using System.Windows.Forms;

namespace RatioMaster {
  internal static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    internal static void Main() {
      Application.EnableVisualStyles();
      //// Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}