using sergiye.Common;
using System;
using System.Windows.Forms;

namespace RatioMaster {
  internal static class Program {
 
    [STAThread]
    internal static void Main() {

      if (!VersionCompatibility.IsCompatible()) {
        MessageBox.Show("The application is not compatible with your region.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        Environment.Exit(0);
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}