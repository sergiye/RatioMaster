using sergiye.Common;
using System;
using System.Windows.Forms;

namespace RatioMaster {
  internal static class Program {
 
    [STAThread]
    internal static void Main() {

      if (!OperatingSystemHelper.IsCompatible(false, out var errorMessage, out var fixAction)) {
        if (fixAction != null) {
          if (MessageBox.Show(errorMessage, Updater.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
            fixAction?.Invoke();
          }
        }
        else {
          MessageBox.Show(errorMessage, Updater.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        Environment.Exit(0);
      }

      if (WinApiHelper.CheckRunningInstances(true, true)) {
        MessageBox.Show($"{Updater.ApplicationName} is already running.", Updater.ApplicationName,
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}