using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using sergiye.Common;

namespace RatioMaster {
  public partial class MainForm : Form {
    public static bool _24h_format_enabled;

    private readonly RMCollection<RM> data = new RMCollection<RM>();
    private string themeId;

    // RM current;
    private int items;

    // RM current;
    private int allit;
    private bool trayIconBalloonIsUp;

    internal MainForm() {
      InitializeComponent();
      Icon = System.Drawing.Icon.ExtractAssociatedIcon(typeof(MainForm).Assembly.Location);
      Text = Updater.ApplicationTitle;

      Updater.Subscribe(
              (message, isError) => { MessageBox.Show(message, Updater.ApplicationName, MessageBoxButtons.OK, isError ? MessageBoxIcon.Warning : MessageBoxIcon.Information); },
              (message) => { return MessageBox.Show(message, Updater.ApplicationName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK; },
              Application.Exit
            );
      var timer = new Timer();
      timer.Tick += async (s, eArgs) => {
        timer.Enabled = false;
        timer.Enabled = !await Updater.CheckForUpdatesAsync(true);
      };
      timer.Interval = 3000;
      timer.Enabled = true;

      LoadSettings();
      InitializeTheme();
    }

    private void InitializeTheme() {

      menu.Renderer = new ThemedToolStripRenderer();
      menuRightClickTray.Renderer = new ThemedToolStripRenderer();

      Theme.Current = new LightTheme();
      themeMenuItem.Visible = false;
      return;

      var currentItem = CustomTheme.FillThemesMenu((title, theme, onClick) => {
        if (theme == null && onClick == null) {
          themeMenuItem.DropDownItems.Add(title);
          return null;
        }
        var item = new ToolStripRadioButtonMenuItem(title, null, onClick);
        themeMenuItem.DropDownItems.Add(item);
        return item;
      }, () => { themeId = Theme.IsAutoThemeEnabled ? "auto" : Theme.Current.Id; }, 
      themeId, "RatioMaster.themes");
      currentItem?.PerformClick();
      Theme.Current.Apply(this);
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
      Updater.ShowAbout();
    }

    private void goToProgramSiteToolStripMenuItem_Click(object sender, EventArgs e) {
      Updater.VisitAppSite();
    }

    private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
      Updater.CheckForUpdates(false);
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e) {
      Add("");
    }

    private void MainForm_Load(object sender, EventArgs e) {
      // txtVersion.Text = VersionChecker.PublicVersion;
      // txtRemote.Text = versionChecker.RemoteVersion;
      // txtLocal.Text = VersionChecker.LocalVersion;
      // txtReleaseDate.Text = VersionChecker.ReleaseDate;
      // Log += versionChecker.Log;

      // lblSize.Text = this.Width + "x" + this.Height;

      // trayIcon.Text += versionChecker.PublicVersion;
      // trayIcon.BalloonTipTitle += " " + versionChecker.PublicVersion;
      Add("");
      lblIp.Text = Functions.GetIp();
      tab_TabIndexChanged(null, null);
      // tab.Size = new Size(Width - 8, Height - 80);
    }

    private void WinRestore() {
      if (WindowState == FormWindowState.Minimized) {
        Show();
        WindowState = FormWindowState.Normal;
        trayIcon.Visible = false;
      }

      // Activate the form.
      Activate();
      Focus();
    }

    private void MainForm_Move(object sender, EventArgs e) {
      // If we are minimizing the form then hide it so it doesn't show up on the task bar
      if (WindowState == FormWindowState.Minimized && chkMinimize.Checked) {
        Hide();
        trayIcon.Visible = true;
      }
      else {
        // any other windows state show it.
        Show();
      }

      // lblLocation.Text = this.Location.X + "x" + this.Location.Y;
    }

    private void Exit() {
      SaveSettings((RM) tab.SelectedTab.Controls[0]);
      foreach (TabPage tabb in tab.TabPages) {
        ((RM) tabb.Controls[0]).StopButton_Click(null, null);
      }

      Application.Exit();
      Process.GetCurrentProcess().Kill();
    }

    #region Tray items

    private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
      if (e.Button != MouseButtons.Right) {
        WinRestore();
      }
    }

    private void restoreToolStripMenuItem_Click(object sender, EventArgs e) {
      WinRestore();
    }

    private void trayIcon_MouseMove(object sender, MouseEventArgs e) {
      if (checkShowTrayBaloon.Checked && trayIconBalloonIsUp == false) {
        trayIcon.BalloonTipText = "";
        foreach (TabPage tabb in tab.TabPages) {
          try {
            trayIcon.BalloonTipText += tabb.Text + " - " + ((RM) tabb.Controls[0]).currentTorrentFile.Name + "\n";
          }
          catch {
            trayIcon.BalloonTipText += tabb.Text + " - Not opened!" + "\n";
          }
        }

        trayIcon.ShowBalloonTip(0);
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
      Exit();
    }

    private void trayIcon_BalloonTipClicked(object sender, EventArgs e) {
      trayIconBalloonIsUp = false;
    }

    private void trayIcon_BalloonTipClosed(object sender, EventArgs e) {
      trayIconBalloonIsUp = false;
    }

    private void trayIcon_BalloonTipShown(object sender, EventArgs e) {
      trayIconBalloonIsUp = true;
    }

    #endregion

    #region Tabs

    private void EditCurrent(string fileName) {
      ((RM) tab.SelectedTab.Controls[0]).LoadTorrentFileInfo(fileName);
    }

    private void Add(string fileName) {
      items++;
      allit++;
      var rm1 = new RM();
      data.Add(rm1);

      // current = rm1;
      var page1 = new TabPage("RM " + allit);
      page1.Name = "RM" + items;
      rm1.Dock = DockStyle.Fill;
      page1.Controls.Add(rm1);

      // page1.Enter += new EventHandler(this.TabPage_Enter);
      // page1.BorderStyle = BorderStyle.FixedSingle;
      // page1.BackColor = Color.White;
      tab.Controls.Add(page1);
      tab.SelectedTab = page1;
      lblTabs.Text = allit.ToString();
      if (fileName != "") {
        ((RM) tab.SelectedTab.Controls[0]).LoadTorrentFileInfo(fileName);
      }

      page1.ToolTipText = "Double click to rename this tab";
      tab.ShowToolTips = true;
    }

    private void Remove() {
      if (tab.TabPages.Count < 2) return;
      var last = tab.SelectedIndex;
      ((RM) tab.SelectedTab.Controls[0]).StopButton_Click(null, null);
      allit--;

      tab.TabPages.Remove(tab.SelectedTab);
      tab.SelectedIndex = last;
      lblTabs.Text = allit.ToString();
    }

    private void RenameTabs() {
      var curr = 0;
      foreach (TabPage thetab in tab.TabPages) {
        if (thetab.Text.Contains("RM ")) {
          curr++;
          thetab.Text = "RM " + curr;
        }
      }
    }

    private void renameCurrentToolStripMenuItem_Click(object sender, EventArgs e) {
      var prompt = new Prompt("Please select new tab name", "Type new tab name:", tab.SelectedTab.Text);
      if (prompt.ShowDialog() == DialogResult.OK) tab.SelectedTab.Text = prompt.Result;
    }

    private void removeCurrentToolStripMenuItem_Click(object sender, EventArgs e) {
      Remove();
      RenameTabs();
    }

    #endregion

    private void LoadSettings() {
      var reg = Registry.CurrentUser.OpenSubKey("Software\\RatioMaster", true);
      if (reg == null) {
        // The key doesn't exist; create it / open it
        Registry.CurrentUser.CreateSubKey("Software\\RatioMaster");
        return;
      }

      try {
        checkShowTrayBaloon.Checked = ItoB((int) reg.GetValue("BallonTip", false));
        chkMinimize.Checked = ItoB((int) reg.GetValue("MinimizeToTray", true));
        closeToTrayToolStripMenuItem.Checked = ItoB((int) reg.GetValue("CloseToTray", true));
        themeId = reg.GetValue("Theme")?.ToString();
      }
      catch {
      }
    }

    private void SaveSettings(RM rMdata) {
      try {
        var reg = Registry.CurrentUser.OpenSubKey("Software\\RatioMaster", true);
        if (reg == null) {
          // The key doesn't exist; create it / open it
          reg = Registry.CurrentUser.CreateSubKey("Software\\RatioMaster");
        }

        reg.SetValue("NewValues", BtoI(rMdata.chkNewValues.Checked), RegistryValueKind.DWord);
        reg.SetValue("BallonTip", BtoI(checkShowTrayBaloon.Checked), RegistryValueKind.DWord);
        reg.SetValue("MinimizeToTray", BtoI(chkMinimize.Checked), RegistryValueKind.DWord);
        reg.SetValue("CloseToTray", BtoI(closeToTrayToolStripMenuItem.Checked), RegistryValueKind.DWord);
        reg.SetValue("Theme", themeId, RegistryValueKind.String);

        reg.SetValue("Client", rMdata.cmbClient.SelectedItem, RegistryValueKind.String);
        reg.SetValue("ClientVersion", rMdata.cmbVersion.SelectedItem, RegistryValueKind.String);
        reg.SetValue("UploadRate", rMdata.uploadRate.Text, RegistryValueKind.String);
        reg.SetValue("DownloadRate", rMdata.downloadRate.Text, RegistryValueKind.String);
        reg.SetValue("Interval", rMdata.interval.Text, RegistryValueKind.String);
        reg.SetValue("fileSize", rMdata.fileSize.Text, RegistryValueKind.String);
        reg.SetValue("Directory", rMdata.DefaultDirectory, RegistryValueKind.String);
        reg.SetValue("TCPlistener", BtoI(rMdata.checkTCPListen.Checked), RegistryValueKind.DWord);
        reg.SetValue("ScrapeInfo", BtoI(rMdata.checkRequestScrap.Checked), RegistryValueKind.DWord);

        // Radnom value
        reg.SetValue("GetRandUp", BtoI(rMdata.chkRandUP.Checked), RegistryValueKind.DWord);
        reg.SetValue("GetRandDown", BtoI(rMdata.chkRandDown.Checked), RegistryValueKind.DWord);
        reg.SetValue("MinRandUp", rMdata.txtRandUpMin.Text, RegistryValueKind.String);
        reg.SetValue("MaxRandUp", rMdata.txtRandUpMax.Text, RegistryValueKind.String);
        reg.SetValue("MinRandDown", rMdata.txtRandDownMin.Text, RegistryValueKind.String);
        reg.SetValue("MaxRandDown", rMdata.txtRandDownMax.Text, RegistryValueKind.String);

        // Custom values
        reg.SetValue("CustomKey", rMdata.customKey.Text, RegistryValueKind.String);
        reg.SetValue("CustomPeerID", rMdata.customPeerID.Text, RegistryValueKind.String);
        reg.SetValue("CustomPeers", rMdata.customPeersNum.Text, RegistryValueKind.String);
        reg.SetValue("CustomPort", rMdata.customPort.Text, RegistryValueKind.String);

        // Stop after...
        reg.SetValue("StopWhen", rMdata.cmbStopAfter.SelectedItem, RegistryValueKind.String);
        reg.SetValue("StopAfter", rMdata.txtStopValue.Text, RegistryValueKind.String);

        // Proxy
        reg.SetValue("ProxyType", rMdata.comboProxyType.SelectedItem, RegistryValueKind.String);
        reg.SetValue("ProxyAdress", rMdata.textProxyHost.Text, RegistryValueKind.String);
        reg.SetValue("ProxyUser", rMdata.textProxyUser.Text, RegistryValueKind.String);
        reg.SetValue("ProxyPass", rMdata.textProxyPass.Text, RegistryValueKind.String);
        reg.SetValue("ProxyPort", rMdata.textProxyPort.Text, RegistryValueKind.String);

        // Radnom value on next
        reg.SetValue("GetRandUpNext", BtoI(rMdata.checkRandomUpload.Checked), RegistryValueKind.DWord);
        reg.SetValue("GetRandDownNext", BtoI(rMdata.checkRandomDownload.Checked), RegistryValueKind.DWord);
        reg.SetValue("MinRandUpNext", rMdata.RandomUploadFrom.Text, RegistryValueKind.String);
        reg.SetValue("MaxRandUpNext", rMdata.RandomUploadTo.Text, RegistryValueKind.String);
        reg.SetValue("MinRandDownNext", rMdata.RandomDownloadFrom.Text, RegistryValueKind.String);
        reg.SetValue("MaxRandDownNext", rMdata.RandomDownloadTo.Text, RegistryValueKind.String);
        reg.SetValue("IgnoreFailureReason", BtoI(rMdata.checkIgnoreFailureReason.Checked), RegistryValueKind.DWord);
      }
      catch (Exception e) {
        // Log += "Error in SetSettings(): " + e.Message + "\n";
      }
    }

    internal static Int64 ParseValidInt64(string str, Int64 defVal) {
      try {
        return Int64.Parse(str);
      }
      catch (Exception) {
        return defVal;
      }
    }

    internal static int ParseValidInt(string str, int defVal) {
      try {
        return int.Parse(str);
      }
      catch (Exception) {
        return defVal;
      }
    }

    internal static int BtoI(bool b) {
      if (b) return 1;
      else return 0;
    }

    internal static bool ItoB(int param) {
      if (param == 0) return false;
      if (param == 1) return true;
      return true;
    }

    internal void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
      if (closeToTrayToolStripMenuItem.Checked && chkMinimize.Checked) {
        e.Cancel = true;
        WindowState = FormWindowState.Minimized;
        Hide();
        trayIcon.Visible = true;
      }
      else Exit();
    }

    private void startToolStripMenuItem_Click(object sender, EventArgs e) {
      ((RM) tab.SelectedTab.Controls[0]).StartButton_Click(null, null);
    }

    private void manualUpdateToolStripMenuItem_Click(object sender, EventArgs e) {
      ((RM) tab.SelectedTab.Controls[0]).manualUpdateButton_Click(null, null);
    }

    private void stopToolStripMenuItem_Click(object sender, EventArgs e) {
      ((RM) tab.SelectedTab.Controls[0]).StopButton_Click(null, null);
    }

    #region Sessions

    private bool startthem;
    private bool stopthem;

    private static void AppendItem(XmlDocument aXmlDoc, XmlElement aXmlElement, string value, string name) {
      var itemElement = aXmlDoc.CreateElement(name);
      itemElement.InnerText = value;
      aXmlElement.AppendChild(itemElement);
    }

    private static void NewMainItem(XmlDocument aXmlDoc, XmlElement aXmlElement, RM data, string name) {
      AppendItem(aXmlDoc, aXmlElement, name, "Name");
      if (data.currentTorrent.filename != null)
        AppendItem(aXmlDoc, aXmlElement, data.currentTorrent.filename, "Address");
      else AppendItem(aXmlDoc, aXmlElement, data.torrentFile.Text, "Address");
      AppendItem(aXmlDoc, aXmlElement, data.trackerAddress.Text, "Tracker");
      AppendItem(aXmlDoc, aXmlElement, data.uploadRate.Text, "UploadSpeed");
      AppendItem(aXmlDoc, aXmlElement, data.chkRandUP.Checked.ToString(), "UploadRandom");
      AppendItem(aXmlDoc, aXmlElement, data.txtRandUpMin.Text, "UploadRandMin");
      AppendItem(aXmlDoc, aXmlElement, data.txtRandUpMax.Text, "UploadRandMax");
      AppendItem(aXmlDoc, aXmlElement, data.downloadRate.Text, "DownloadSpeed");
      AppendItem(aXmlDoc, aXmlElement, data.chkRandDown.Checked.ToString(), "DownloadRandom");
      AppendItem(aXmlDoc, aXmlElement, data.txtRandDownMin.Text, "DownloadRandMin");
      AppendItem(aXmlDoc, aXmlElement, data.txtRandDownMax.Text, "DownloadRandMax");
      AppendItem(aXmlDoc, aXmlElement, data.cmbClient.SelectedItem.ToString(), "Client");
      AppendItem(aXmlDoc, aXmlElement, data.cmbVersion.SelectedItem.ToString(), "Version");
      AppendItem(aXmlDoc, aXmlElement, data.fileSize.Text, "Finished");
      AppendItem(aXmlDoc, aXmlElement, data.cmbStopAfter.SelectedItem.ToString(), "StopType");
      AppendItem(aXmlDoc, aXmlElement, data.txtStopValue.Text, "StopValue");
      AppendItem(aXmlDoc, aXmlElement, data.customPort.Text, "Port");
      AppendItem(aXmlDoc, aXmlElement, data.checkTCPListen.Checked.ToString(), "UseTCP");
      AppendItem(aXmlDoc, aXmlElement, data.checkRequestScrap.Checked.ToString(), "UseScrape");
      AppendItem(aXmlDoc, aXmlElement, data.comboProxyType.SelectedItem.ToString(), "ProxyType");
      AppendItem(aXmlDoc, aXmlElement, data.textProxyUser.Text, "ProxyUser");
      AppendItem(aXmlDoc, aXmlElement, data.textProxyPass.Text, "ProxyPass");
      AppendItem(aXmlDoc, aXmlElement, data.textProxyHost.Text, "ProxyHost");
      AppendItem(aXmlDoc, aXmlElement, data.textProxyPort.Text, "ProxyPort");
      AppendItem(aXmlDoc, aXmlElement, data.checkRandomUpload.Checked.ToString(), "NextUpdateUpload");
      AppendItem(aXmlDoc, aXmlElement, data.RandomUploadFrom.Text, "NextUpdateUploadFrom");
      AppendItem(aXmlDoc, aXmlElement, data.RandomUploadTo.Text, "NextUpdateUploadTo");
      AppendItem(aXmlDoc, aXmlElement, data.checkRandomDownload.Checked.ToString(), "NextUpdateDownload");
      AppendItem(aXmlDoc, aXmlElement, data.RandomDownloadFrom.Text, "NextUpdateDownloadFrom");
      AppendItem(aXmlDoc, aXmlElement, data.RandomDownloadTo.Text, "NextUpdateDownloadTo");
      AppendItem(aXmlDoc, aXmlElement, data.checkIgnoreFailureReason.Checked.ToString(), "IgnoreFailureReason");
    }

    private void saveCurrentSessionToolStripMenuItem_Click(object sender, EventArgs e) {
      stopthem = true;
      saveSession.ShowDialog();
    }

    private void loadSessionToolStripMenuItem_Click(object sender, EventArgs e) {
      startthem = false;
      loadSession.ShowDialog();
    }

    private void loadSessionAndStartToolStripMenuItem_Click(object sender, EventArgs e) {
      startthem = true;
      loadSession.ShowDialog();
    }

    private void saveCurrentSessionToolStripMenuItem1_Click(object sender, EventArgs e) {
      stopthem = false;
      saveSession.ShowDialog();
    }

    private void SaveSession(string path) {
      var doc = new XmlDocument();
      var main = doc.CreateElement("main");
      doc.AppendChild(main);
      foreach (TabPage tabb in tab.TabPages) {
        if (stopthem) ((RM) tabb.Controls[0]).StopButton_Click(null, null);
        var child = doc.CreateElement("RatioMaster");
        main.AppendChild(child);
        NewMainItem(doc, child, (RM) tabb.Controls[0], tabb.Text);
      }

      doc.Save(path);
    }

    private void LoadSession(string path) {
      var doc = new XmlDocument();
      doc.Load(path);
      XmlNode root = doc.DocumentElement;
      foreach (XmlNode node in root.ChildNodes) {
        Add("");
        tab.SelectedTab.Text = node["Name"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).torrentFile.Text = node["Address"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).openFileDialog1.FileName = node["Address"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).openFileDialog1_FileOk(null, null);
        ((RM) tab.SelectedTab.Controls[0]).trackerAddress.Text = node["Tracker"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).uploadRate.Text = node["UploadSpeed"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).txtRandUpMin.Text = node["UploadRandMin"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).txtRandUpMax.Text = node["UploadRandMax"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).downloadRate.Text = node["DownloadSpeed"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).txtRandDownMin.Text = node["DownloadRandMin"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).txtRandDownMax.Text = node["DownloadRandMax"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).chkRandUP.Checked = bool.Parse(node["UploadRandom"].InnerText);
        ((RM) tab.SelectedTab.Controls[0]).chkRandDown.Checked = bool.Parse(node["DownloadRandom"].InnerText);
        ((RM) tab.SelectedTab.Controls[0]).cmbClient.SelectedItem = node["Client"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).cmbVersion.SelectedItem = node["Version"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).fileSize.Text = node["Finished"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).cmbStopAfter.SelectedItem = node["StopType"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).txtStopValue.Text = node["StopValue"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).customPort.Text = node["Port"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).checkTCPListen.Checked = bool.Parse(node["UseTCP"].InnerText);
        ((RM) tab.SelectedTab.Controls[0]).checkRequestScrap.Checked = bool.Parse(node["UseScrape"].InnerText);
        ((RM) tab.SelectedTab.Controls[0]).comboProxyType.SelectedItem = node["ProxyType"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).textProxyUser.Text = node["ProxyUser"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).textProxyPass.Text = node["ProxyPass"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).textProxyHost.Text = node["ProxyHost"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).textProxyPort.Text = node["ProxyPort"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).checkRandomUpload.Checked = bool.Parse(node["NextUpdateUpload"].InnerText);
        ((RM) tab.SelectedTab.Controls[0]).checkRandomDownload.Checked =
          bool.Parse(node["NextUpdateDownload"].InnerText);
        ((RM) tab.SelectedTab.Controls[0]).RandomUploadFrom.Text = node["NextUpdateUploadFrom"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).RandomUploadTo.Text = node["NextUpdateUploadTo"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).RandomDownloadFrom.Text = node["NextUpdateDownloadFrom"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).RandomDownloadTo.Text = node["NextUpdateDownloadTo"].InnerText;
        ((RM) tab.SelectedTab.Controls[0]).checkIgnoreFailureReason.Checked =
          bool.Parse(node["IgnoreFailureReason"].InnerText);
        if (startthem) ((RM) tab.SelectedTab.Controls[0]).StartButton_Click(null, null);
      }

      RenameTabs();
    }

    private void saveSession_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      SaveSession(saveSession.FileName);
    }

    private void loadSession_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      LoadSession(loadSession.FileName);
    }

    #endregion

    #region All RatioMasters menu

    private void startToolStripMenuItem1_Click(object sender, EventArgs e) {
      foreach (TabPage tabb in tab.TabPages) {
        ((RM) tabb.Controls[0]).StartButton_Click(null, null);
      }
    }

    private void stopToolStripMenuItem1_Click(object sender, EventArgs e) {
      foreach (TabPage tabb in tab.TabPages) {
        ((RM) tabb.Controls[0]).StopButton_Click(null, null);
      }
    }

    private void updateToolStripMenuItem_Click(object sender, EventArgs e) {
      foreach (TabPage tabb in tab.TabPages) {
        ((RM) tabb.Controls[0]).manualUpdateButton_Click(null, null);
      }
    }

    private void setUploadSpeedToToolStripMenuItem_Click(object sender, EventArgs e) {
      var prompt = new Prompt("Please type valid integer value", "Type new upload speed for all tabs:", "100");
      if (prompt.ShowDialog() == DialogResult.OK) {
        int value;
        try {
          value = int.Parse(prompt.Result);
        }
        catch {
          MessageBox.Show("Invalid value!\nTry again!", Updater.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
        }

        foreach (TabPage tabb in tab.TabPages) {
          ((RM) tabb.Controls[0]).UpdateTextBox(((RM) tabb.Controls[0]).uploadRate, value.ToString());
        }
      }
    }

    private void setDownloadSpeedToToolStripMenuItem_Click(object sender, EventArgs e) {
      var prompt = new Prompt("Please type valid integer value", "Type new download speed for all tabs:", "100");
      if (prompt.ShowDialog() == DialogResult.OK) {
        int value;
        try {
          value = int.Parse(prompt.Result);
        }
        catch {
          MessageBox.Show("Invalid value!\nTry again!", Updater.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
        }

        foreach (TabPage tabb in tab.TabPages) {
          ((RM) tabb.Controls[0]).UpdateTextBox(((RM) tabb.Controls[0]).downloadRate, value.ToString());
        }
      }
    }

    #endregion

    private void saveSettingsFromCurrentTabToolStripMenuItem_Click(object sender, EventArgs e) {
      SaveSettings((RM) tab.SelectedTab.Controls[0]);
    }

    private void tab_TabIndexChanged(object sender, EventArgs e) {
      /*
      if (GetTabType(tab.SelectedTab) == TabType.RatioMaster)
      {
          currentToolStripMenuItem.Enabled = true;
          allRatioMastersToolStripMenuItem.Enabled = true;
          saveSettingsFromCurrentTabToolStripMenuItem.Enabled = true;
          newToolStripMenuItem.Enabled = true;
          browserToolStripMenuItem.Enabled = false;
      }
      else if (GetTabType(tab.SelectedTab) == TabType.Browser)
      {
          currentToolStripMenuItem.Enabled = false;
          allRatioMastersToolStripMenuItem.Enabled = false;
          saveSettingsFromCurrentTabToolStripMenuItem.Enabled = false;
          newToolStripMenuItem.Enabled = false;
          browserToolStripMenuItem.Enabled = true;
      }
       */
    }

    private static string GetFileExtenstion(string file) {
      var info = new FileInfo(file);
      return info.Extension;
    }

    private void MainForm_DragEnter(object sender, DragEventArgs e) {
      if (e.Data.GetDataPresent(DataFormats.FileDrop, false)) {
        e.Effect = DragDropEffects.All;
      }
    }

    private void MainForm_DragDrop(object sender, DragEventArgs e) {
      foreach (var fileName in (string[]) e.Data.GetData(DataFormats.FileDrop)) {
        // MessageBox.Show(fileName + "\n" + GetFileExtenstion(fileName), "Debug");
        if (GetFileExtenstion(fileName) == ".torrent") {
          if (MessageBox.Show(
                "You have successfuly loaded this torrent file:\n" + fileName +
                "\nDo you want to load this torrent file in a new tab?", Updater.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
              DialogResult.Yes) Add(fileName);
          else EditCurrent(fileName);
        }
        else if (GetFileExtenstion(fileName) == ".session") {
          MessageBox.Show("You have successfuly loaded this session file:\n" + fileName, Updater.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
          startthem = false;
          LoadSession(fileName);
        }
      }
    }

    private void enable24hformat_Click(object sender, EventArgs e) {
      _24h_format_enabled = enable24hformat.Checked;
    }
  }
}