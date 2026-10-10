using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using sergiye.Common;

namespace RatioMaster {
  public partial class MainForm : Form {

    private readonly RMCollection<RM> data = new RMCollection<RM>();
    private string themeId;
    private bool shownOnce;

    // RM current;
    private int items;

    // RM current;
    private int allit;

    // The number in the title of the last tab made: the titles of the other tabs stay when one is closed.
    private int lastTabNumber;
    private bool trayIconBalloonIsUp;

    internal MainForm() {
      InitializeComponent();
      Icon = System.Drawing.Icon.ExtractAssociatedIcon(typeof(MainForm).Assembly.Location);
      Text = Updater.ApplicationTitle;

      Updater.Subscribe(
        (message, isError) => { MessageBox.Show(message, Updater.ApplicationTitle, MessageBoxButtons.OK, isError ? MessageBoxIcon.Warning : MessageBoxIcon.Information); },
        (message) => { return MessageBox.Show(message, Updater.ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK; },
        Exit
      );

      LoadSettings();
      InitializeTheme();

      // the first tab and the theme are made before the window has a handle: much cheaper than after it
      tab.ShowCloseOnSingleTab = false;
      tab.CloseRequested += (_, page) => {
        tab.SelectedTab = page;
        removeCurrentToolStripMenuItem_Click(null, null);
      };
      SuspendLayout();
      Add("");
      lblIp.Text = Functions.GetIp();
      tab_TabIndexChanged(null, null);
      ThemeSupport.Apply(this);
      ResumeLayout(false);
      Shown += (_, _) => shownOnce = true;
    }

    protected override void WndProc(ref Message m) {
      base.WndProc(ref m);
      if (m.Msg == WinApiHelper.WM_SHOWME) {
        if (WindowState == FormWindowState.Minimized)
          WindowState = FormWindowState.Normal;
        BringToFront();
        Activate();
      }
    }

    private void InitializeTheme() {
      ThemeSupport.StylesItself = (control, theme) => {
        if (!RM.IsMainButton(control)) return false;
        RM.StyleMainButton((Button) control, theme);
        return true;
      };
      ThemeSupport.Initialize(themeId, id => {
        themeId = id;
        SaveThemeId();
      }, "RatioMaster.themes");
      ThemedWindowTitle.Attach(this, menu, WindowTitleStyle.ThemeColors);

      var current = CustomTheme.FillThemesMenu<ToolStripMenuItem>((title, theme, onClick) => {
        if (theme == null && onClick == null) {
          themeMenuItem.DropDownItems.Add(new ToolStripSeparator());
          return null;
        }
        var item = new ToolStripRadioButtonMenuItem(title, null, onClick);
        themeMenuItem.DropDownItems.Add(item);
        return item;
      }, null, ThemeSupport.CurrentId, "RatioMaster.themes");
      if (current != null)
        current.Checked = true;

      ThemeSupport.Changed += ApplyStatusColors;
      ApplyStatusColors();
    }

    private void ApplyStatusColors() {
      foreach (var label in new[] {toolStripStatusLabel2, toolStripStatusLabel4})
        label.ForeColor = Theme.Current.ForegroundColor;
      foreach (var label in new[] {lblTabs, lblIp})
        label.ForeColor = Theme.Current.HyperlinkColor;
    }

    private static void SaveThemeId() {
      try {
        using (var reg = Registry.CurrentUser.CreateSubKey("Software\\RatioMaster"))
          reg?.SetValue("Theme", ThemeSupport.CurrentId, RegistryValueKind.String);
      }
      catch {
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
      Updater.ShowAbout();
    }

    private void goToProgramSiteToolStripMenuItem_Click(object sender, EventArgs e) {
      Updater.VisitAppSite();
    }

    private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
      Updater.CheckForUpdates(Updater.CheckUpdatesMode.AllMessages);
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
      // tab.Size = new Size(Width - 8, Height - 80);
      FitWindow();
    }

    // The window starts as wide as it can be and the log is hidden at the minimum height.
    private void FitWindow() {
      var rm = (RM) tab.SelectedTab.Controls[0];
      var chrome = new Size(Width - ClientSize.Width, Height - ClientSize.Height);
      var contentWidth = rm.ContentWidth;
      var workArea = Screen.FromPoint(Cursor.Position).WorkingArea;
      var maxWidth = Math.Max(MaximumSize.Width, contentWidth + chrome.Width);
      MaximumSize = new Size(maxWidth, MaximumSize.Height);
      var tabExtra = tab.Height - rm.Height;
      var minHeight = rm.HeightWithoutLog + tabExtra + Status.Height + chrome.Height;
      MinimumSize = new Size(MinimumSize.Width, minHeight);
      var height = Math.Min(Math.Max(Height + LogicalToDeviceUnits(100), minHeight), workArea.Height);
      Size = new Size(Math.Min(maxWidth, workArea.Width), height);
      Location = new Point(workArea.Left + (workArea.Width - Width) / 2, workArea.Top + (workArea.Height - Height) / 2);
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
      else if (shownOnce && !Visible) {
        // any other windows state show it.
        Show();
      }

      // lblLocation.Text = this.Location.X + "x" + this.Location.Y;
    }

    private void Exit() {
      SaveSettings((RM) tab.SelectedTab.Controls[0]);
      foreach (TabPage page in tab.TabPages) {
        ((RM) page.Controls[0]).StopButton_Click(null, null);
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
        foreach (TabPage page in tab.TabPages) {
          try {
            trayIcon.BalloonTipText += page.Text + " - " + ((RM) page.Controls[0]).currentTorrentFile.Name + "\n";
          }
          catch {
            trayIcon.BalloonTipText += page.Text + " - Not opened!" + "\n";
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
      lastTabNumber++;
      var rm1 = new RM();
      data.Add(rm1);

      // current = rm1;
      var page1 = new TabPage("RM " + lastTabNumber);
      page1.Name = "RM" + items;
      rm1.Dock = DockStyle.Fill;
      page1.Controls.Add(rm1);

      // page1.Enter += new EventHandler(this.TabPage_Enter);
      // page1.BorderStyle = BorderStyle.FixedSingle;
      // page1.BackColor = Color.White;
      tab.Controls.Add(page1);
      ThemeSupport.Apply(page1);
      tab.SelectedTab = page1;
      lblTabs.Text = allit.ToString();
      if (fileName != "") {
        ((RM) tab.SelectedTab.Controls[0]).LoadTorrentFileInfo(fileName);
      }

      page1.ToolTipText = "Double click to rename this tab";
    }

    private void Remove() {
      if (tab.TabPages.Count < 2) return;
      var last = tab.SelectedIndex;
      ((RM) tab.SelectedTab.Controls[0]).StopButton_Click(null, null);
      allit--;

      tab.TabPages.Remove(tab.SelectedTab);
      tab.SelectedIndex = Math.Min(last, tab.TabCount - 1);
      lblTabs.Text = allit.ToString();
    }

    private void renameCurrentToolStripMenuItem_Click(object sender, EventArgs e) {
      var prompt = new Prompt("Please select new tab name", "Type new tab name:", tab.SelectedTab.Text);
      if (prompt.ShowDialog() == DialogResult.OK) tab.SelectedTab.Text = prompt.Result;
    }

    private void removeCurrentToolStripMenuItem_Click(object sender, EventArgs e) {
      Remove();
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

    private void SaveSettings(RM rmData) {
      try {
        var reg = Registry.CurrentUser.OpenSubKey("Software\\RatioMaster", true);
        if (reg == null) {
          // The key doesn't exist; create it / open it
          reg = Registry.CurrentUser.CreateSubKey("Software\\RatioMaster");
        }

        reg.SetValue("NewValues", BtoI(rmData.chkNewValues.Checked), RegistryValueKind.DWord);
        reg.SetValue("BallonTip", BtoI(checkShowTrayBaloon.Checked), RegistryValueKind.DWord);
        reg.SetValue("MinimizeToTray", BtoI(chkMinimize.Checked), RegistryValueKind.DWord);
        reg.SetValue("CloseToTray", BtoI(closeToTrayToolStripMenuItem.Checked), RegistryValueKind.DWord);
        reg.SetValue("Theme", themeId, RegistryValueKind.String);

        reg.SetValue("Client", rmData.cmbClient.SelectedItem, RegistryValueKind.String);
        reg.SetValue("ClientVersion", rmData.cmbVersion.SelectedItem, RegistryValueKind.String);
        reg.SetValue("UploadRate", rmData.uploadRate.Text, RegistryValueKind.String);
        reg.SetValue("DownloadRate", rmData.downloadRate.Text, RegistryValueKind.String);
        reg.SetValue("Interval", rmData.interval.Text, RegistryValueKind.String);
        reg.SetValue("fileSize", rmData.fileSize.Text, RegistryValueKind.String);
        reg.SetValue("Directory", rmData.DefaultDirectory, RegistryValueKind.String);
        reg.SetValue("TCPlistener", BtoI(rmData.checkTCPListen.Checked), RegistryValueKind.DWord);
        reg.SetValue("ScrapeInfo", BtoI(rmData.checkRequestScrap.Checked), RegistryValueKind.DWord);

        // Random value
        reg.SetValue("GetRandUp", BtoI(rmData.chkRandUP.Checked), RegistryValueKind.DWord);
        reg.SetValue("GetRandDown", BtoI(rmData.chkRandDown.Checked), RegistryValueKind.DWord);
        reg.SetValue("MinRandUp", rmData.txtRandUpMin.Text, RegistryValueKind.String);
        reg.SetValue("MaxRandUp", rmData.txtRandUpMax.Text, RegistryValueKind.String);
        reg.SetValue("MinRandDown", rmData.txtRandDownMin.Text, RegistryValueKind.String);
        reg.SetValue("MaxRandDown", rmData.txtRandDownMax.Text, RegistryValueKind.String);

        // Custom values
        reg.SetValue("CustomKey", rmData.customKey.Text, RegistryValueKind.String);
        reg.SetValue("CustomPeerID", rmData.customPeerID.Text, RegistryValueKind.String);
        reg.SetValue("CustomPeers", rmData.customPeersNum.Text, RegistryValueKind.String);
        reg.SetValue("CustomPort", rmData.customPort.Text, RegistryValueKind.String);

        // Stop after...
        reg.SetValue("StopWhen", rmData.cmbStopAfter.SelectedItem, RegistryValueKind.String);
        reg.SetValue("StopAfter", rmData.txtStopValue.Text, RegistryValueKind.String);

        // Proxy
        reg.SetValue("ProxyType", rmData.comboProxyType.SelectedItem, RegistryValueKind.String);
        reg.SetValue("ProxyAdress", rmData.textProxyHost.Text, RegistryValueKind.String);
        reg.SetValue("ProxyUser", rmData.textProxyUser.Text, RegistryValueKind.String);
        reg.SetValue("ProxyPass", rmData.textProxyPass.Text, RegistryValueKind.String);
        reg.SetValue("ProxyPort", rmData.textProxyPort.Text, RegistryValueKind.String);

        // Random value on next
        reg.SetValue("GetRandUpNext", BtoI(rmData.checkRandomUpload.Checked), RegistryValueKind.DWord);
        reg.SetValue("GetRandDownNext", BtoI(rmData.checkRandomDownload.Checked), RegistryValueKind.DWord);
        reg.SetValue("MinRandUpNext", rmData.RandomUploadFrom.Text, RegistryValueKind.String);
        reg.SetValue("MaxRandUpNext", rmData.RandomUploadTo.Text, RegistryValueKind.String);
        reg.SetValue("MinRandDownNext", rmData.RandomDownloadFrom.Text, RegistryValueKind.String);
        reg.SetValue("MaxRandDownNext", rmData.RandomDownloadTo.Text, RegistryValueKind.String);
        reg.SetValue("IgnoreFailureReason", BtoI(rmData.checkIgnoreFailureReason.Checked), RegistryValueKind.DWord);
      }
      catch (Exception e) {
        // Log += "Error in SetSettings(): " + e.Message + "\n";
      }
    }

    internal static long ParseValidInt64(string str, long defVal) {
      try {
        return long.Parse(str);
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

    private bool startThem;
    private bool stopThem;

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
      stopThem = true;
      saveSession.ShowDialog();
    }

    private void loadSessionToolStripMenuItem_Click(object sender, EventArgs e) {
      startThem = false;
      loadSession.ShowDialog();
    }

    private void loadSessionAndStartToolStripMenuItem_Click(object sender, EventArgs e) {
      startThem = true;
      loadSession.ShowDialog();
    }

    private void saveCurrentSessionToolStripMenuItem1_Click(object sender, EventArgs e) {
      stopThem = false;
      saveSession.ShowDialog();
    }

    private void SaveSession(string path) {
      var doc = new XmlDocument();
      var main = doc.CreateElement("main");
      doc.AppendChild(main);
      foreach (TabPage page in tab.TabPages) {
        if (stopThem) ((RM) page.Controls[0]).StopButton_Click(null, null);
        var child = doc.CreateElement("RatioMaster");
        main.AppendChild(child);
        NewMainItem(doc, child, (RM) page.Controls[0], page.Text);
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
        if (startThem) ((RM) tab.SelectedTab.Controls[0]).StartButton_Click(null, null);
      }

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
      foreach (TabPage page in tab.TabPages) {
        ((RM) page.Controls[0]).StartButton_Click(null, null);
      }
    }

    private void stopToolStripMenuItem1_Click(object sender, EventArgs e) {
      foreach (TabPage page in tab.TabPages) {
        ((RM) page.Controls[0]).StopButton_Click(null, null);
      }
    }

    private void updateToolStripMenuItem_Click(object sender, EventArgs e) {
      foreach (TabPage page in tab.TabPages) {
        ((RM) page.Controls[0]).manualUpdateButton_Click(null, null);
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

        foreach (TabPage page in tab.TabPages) {
          ((RM) page.Controls[0]).UpdateTextBox(((RM) page.Controls[0]).uploadRate, value.ToString());
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

        foreach (TabPage page in tab.TabPages) {
          ((RM) page.Controls[0]).UpdateTextBox(((RM) page.Controls[0]).downloadRate, value.ToString());
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

    private static string GetFileExtension(string file) {
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
        // MessageBox.Show(fileName + "\n" + GetFileExtension(fileName), "Debug");
        if (GetFileExtension(fileName) == ".torrent") {
          if (MessageBox.Show(
                "You have successfully loaded this torrent file:\n" + fileName +
                "\nDo you want to load this torrent file in a new tab?", Updater.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
              DialogResult.Yes) Add(fileName);
          else EditCurrent(fileName);
        }
        else if (GetFileExtension(fileName) == ".session") {
          MessageBox.Show("You have successfuly loaded this session file:\n" + fileName, Updater.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
          startThem = false;
          LoadSession(fileName);
        }
      }
    }
  }
}