using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using sergiye.Common;

namespace RatioMaster {
  public partial class MainForm : Form {

    private readonly PersistentSettings settings = new PersistentSettings();
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

      settings.Load();
      LoadSettings();
      InitializeTheme();

      // the first tab and the theme are made before the window has a handle: much cheaper than after it
      tab.ShowCloseOnSingleTab = false;
      tab.CloseRequested += (_, page) => {
        tab.SelectedTab = page;
        removeCurrentToolStripMenuItem_Click(null, null);
      };
      SuspendLayout();
      if (!RestoreTabs()) Add("");
      Shown += async (_, _) => {
        var ip = await Task.Run(() => Functions.GetIp());
        if (!IsDisposed) lblIp.Text = ip;
      };
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

    private void SaveThemeId() {
      settings.SetValue("Theme", ThemeSupport.CurrentId);
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

    private bool exiting;

    private void Exit() {
      if (exiting) return;
      exiting = true;
      SaveSettings((RM) tab.SelectedTab.Controls[0]);
      SaveTabs();
      foreach (TabPage page in tab.TabPages) {
        ((RM) page.Controls[0]).StopButton_Click(null, null);
      }

      // the tabs send "stopped" to their trackers at the same time: wait for them, but not for long
      var deadline = DateTime.UtcNow.AddSeconds(3);
      foreach (TabPage page in tab.TabPages) {
        var left = (int) (deadline - DateTime.UtcNow).TotalMilliseconds;
        ((RM) page.Controls[0]).WaitForStop(Math.Max(left, 0));
      }

      trayIcon.Visible = false;
      Application.Exit();
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
      var rm1 = new RM(settings);
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
      try {
        var settings = this.settings;
        checkShowTrayBaloon.Checked = settings.GetValue("BallonTip", false);
        chkMinimize.Checked = settings.GetValue("MinimizeToTray", true);
        closeToTrayToolStripMenuItem.Checked = settings.GetValue("CloseToTray", true);
        themeId = settings.GetValue("Theme", null);
      }
      catch (Exception) {
      }
    }

    private void SaveSettings(RM rmData) {
      var settings = this.settings;
      try {
        settings.WaitCommit = true;
        settings.SetValue("Version", Application.ProductVersion);
        settings.SetValue("NewValues", rmData.chkNewValues.Checked);
        settings.SetValue("BallonTip", checkShowTrayBaloon.Checked);
        settings.SetValue("MinimizeToTray", chkMinimize.Checked);
        settings.SetValue("CloseToTray", closeToTrayToolStripMenuItem.Checked);
        settings.SetValue("Theme", themeId);

        settings.SetValue("Client", rmData.cmbClient.SelectedItem as string);
        settings.SetValue("ClientVersion", rmData.cmbVersion.SelectedItem as string);
        settings.SetValue("UploadRate", rmData.uploadRate.Text);
        settings.SetValue("DownloadRate", rmData.downloadRate.Text);
        settings.SetValue("Interval", rmData.interval.Text);
        settings.SetValue("fileSize", rmData.fileSize.Text);
        settings.SetValue("Directory", rmData.DefaultDirectory);
        settings.SetValue("TCPlistener", rmData.checkTCPListen.Checked);
        settings.SetValue("ScrapeInfo", rmData.checkRequestScrap.Checked);

        // Random value
        settings.SetValue("GetRandUp", rmData.chkRandUP.Checked);
        settings.SetValue("GetRandDown", rmData.chkRandDown.Checked);
        settings.SetValue("MinRandUp", rmData.txtRandUpMin.Text);
        settings.SetValue("MaxRandUp", rmData.txtRandUpMax.Text);
        settings.SetValue("MinRandDown", rmData.txtRandDownMin.Text);
        settings.SetValue("MaxRandDown", rmData.txtRandDownMax.Text);

        // Custom values
        settings.SetValue("CustomKey", rmData.customKey.Text);
        settings.SetValue("CustomPeerID", rmData.customPeerID.Text);
        settings.SetValue("CustomPeers", rmData.customPeersNum.Text);
        settings.SetValue("CustomPort", rmData.customPort.Text);

        // Stop after...
        settings.SetValue("StopWhen", rmData.cmbStopAfter.SelectedItem as string);
        settings.SetValue("StopAfter", rmData.txtStopValue.Text);

        // Proxy
        settings.SetValue("ProxyType", rmData.comboProxyType.SelectedItem as string);
        settings.SetValue("ProxyAdress", rmData.textProxyHost.Text);
        settings.SetValue("ProxyUser", rmData.textProxyUser.Text);
        settings.SetValue("ProxyPass", rmData.textProxyPass.Text);
        settings.SetValue("ProxyPort", rmData.textProxyPort.Text);

        // Random value on next
        settings.SetValue("GetRandUpNext", rmData.checkRandomUpload.Checked);
        settings.SetValue("GetRandDownNext", rmData.checkRandomDownload.Checked);
        settings.SetValue("MinRandUpNext", rmData.RandomUploadFrom.Text);
        settings.SetValue("MaxRandUpNext", rmData.RandomUploadTo.Text);
        settings.SetValue("MinRandDownNext", rmData.RandomDownloadFrom.Text);
        settings.SetValue("MaxRandDownNext", rmData.RandomDownloadTo.Text);
        settings.SetValue("IgnoreFailureReason", rmData.checkIgnoreFailureReason.Checked);
      }
      catch (Exception e) {
        rmData.AddLogLine("Error in SaveSettings(): " + e.Message);
      }
      finally {
        settings.Save(true);
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

    private void SaveSession(string path, bool stop) {
      var doc = new XmlDocument();
      var main = doc.CreateElement("main");
      doc.AppendChild(main);
      foreach (TabPage page in tab.TabPages) {
        if (stop) ((RM) page.Controls[0]).StopButton_Click(null, null);
        var child = doc.CreateElement("RatioMaster");
        main.AppendChild(child);
        NewMainItem(doc, child, (RM) page.Controls[0], page.Text);
      }

      doc.Save(path);
    }

    // The tabs of a session file; returns the number of tabs made. A tab that cannot be restored is reported, the others are loaded.
    private int LoadSession(string path, bool start) {
      var doc = new XmlDocument();
      try {
        doc.Load(path);
      }
      catch (Exception ex) {
        MessageBox.Show("Cannot read the session file:\n" + ex.Message, Updater.ApplicationName, MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
        return 0;
      }

      var loaded = 0;
      var errors = new List<string>();
      foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
        if (node.NodeType != XmlNodeType.Element) continue;
        Add("");
        loaded++;
        var data = (RM) tab.SelectedTab.Controls[0];
        try {
          ApplySession(data, node);
          if (start) data.StartButton_Click(null, null);
        }
        catch (Exception ex) {
          errors.Add(tab.SelectedTab.Text + ": " + ex.Message);
        }
      }

      if (errors.Count > 0)
        MessageBox.Show("Some tabs of the session were not restored completely:\n\n" + string.Join("\n", errors),
          Updater.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return loaded;
    }

    private static string Item(XmlNode node, string name, string defaultValue) {
      return node[name]?.InnerText ?? defaultValue;
    }

    private static bool Flag(XmlNode node, string name, bool defaultValue) {
      return bool.TryParse(node[name]?.InnerText, out var value) ? value : defaultValue;
    }

    // A value that is missing in the file leaves what the tab has.
    private void ApplySession(RM data, XmlNode node) {
      tab.SelectedTab.Text = Item(node, "Name", tab.SelectedTab.Text);
      var address = Item(node, "Address", "");
      data.torrentFile.Text = address;
      data.openFileDialog1.FileName = address;
      data.openFileDialog1_FileOk(null, null);
      data.trackerAddress.Text = Item(node, "Tracker", data.trackerAddress.Text);
      data.uploadRate.Text = Item(node, "UploadSpeed", data.uploadRate.Text);
      data.txtRandUpMin.Text = Item(node, "UploadRandMin", data.txtRandUpMin.Text);
      data.txtRandUpMax.Text = Item(node, "UploadRandMax", data.txtRandUpMax.Text);
      data.downloadRate.Text = Item(node, "DownloadSpeed", data.downloadRate.Text);
      data.txtRandDownMin.Text = Item(node, "DownloadRandMin", data.txtRandDownMin.Text);
      data.txtRandDownMax.Text = Item(node, "DownloadRandMax", data.txtRandDownMax.Text);
      data.chkRandUP.Checked = Flag(node, "UploadRandom", data.chkRandUP.Checked);
      data.chkRandDown.Checked = Flag(node, "DownloadRandom", data.chkRandDown.Checked);
      data.cmbClient.SelectedItem = Item(node, "Client", (string) data.cmbClient.SelectedItem);
      data.cmbVersion.SelectedItem = Item(node, "Version", (string) data.cmbVersion.SelectedItem);
      data.fileSize.Text = Item(node, "Finished", data.fileSize.Text);
      data.cmbStopAfter.SelectedItem = Item(node, "StopType", (string) data.cmbStopAfter.SelectedItem);
      data.txtStopValue.Text = Item(node, "StopValue", data.txtStopValue.Text);
      data.customPort.Text = Item(node, "Port", data.customPort.Text);
      data.checkTCPListen.Checked = Flag(node, "UseTCP", data.checkTCPListen.Checked);
      data.checkRequestScrap.Checked = Flag(node, "UseScrape", data.checkRequestScrap.Checked);
      data.comboProxyType.SelectedItem = Item(node, "ProxyType", (string) data.comboProxyType.SelectedItem);
      data.textProxyUser.Text = Item(node, "ProxyUser", data.textProxyUser.Text);
      data.textProxyPass.Text = Item(node, "ProxyPass", data.textProxyPass.Text);
      data.textProxyHost.Text = Item(node, "ProxyHost", data.textProxyHost.Text);
      data.textProxyPort.Text = Item(node, "ProxyPort", data.textProxyPort.Text);
      data.checkRandomUpload.Checked = Flag(node, "NextUpdateUpload", data.checkRandomUpload.Checked);
      data.checkRandomDownload.Checked = Flag(node, "NextUpdateDownload", data.checkRandomDownload.Checked);
      data.RandomUploadFrom.Text = Item(node, "NextUpdateUploadFrom", data.RandomUploadFrom.Text);
      data.RandomUploadTo.Text = Item(node, "NextUpdateUploadTo", data.RandomUploadTo.Text);
      data.RandomDownloadFrom.Text = Item(node, "NextUpdateDownloadFrom", data.RandomDownloadFrom.Text);
      data.RandomDownloadTo.Text = Item(node, "NextUpdateDownloadTo", data.RandomDownloadTo.Text);
      data.checkIgnoreFailureReason.Checked =
        Flag(node, "IgnoreFailureReason", data.checkIgnoreFailureReason.Checked);
    }

    // The tabs are kept between the runs of the program in a session file of its own.
    private static string TabsFile {
      get {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RatioMaster",
          "tabs.xml");
      }
    }

    private void SaveTabs() {
      try {
        Directory.CreateDirectory(Path.GetDirectoryName(TabsFile));
        SaveSession(TabsFile, false);
      }
      catch (Exception ex) {
        ((RM) tab.SelectedTab.Controls[0]).AddLogLine("Error saving the tabs: " + ex.Message);
      }
    }

    // False when there is nothing to restore.
    private bool RestoreTabs() {
      try {
        if (!File.Exists(TabsFile) || LoadSession(TabsFile, false) == 0) return false;
        foreach (TabPage page in tab.TabPages) {
          var match = Regex.Match(page.Text, @"^RM (\d+)$");
          if (match.Success && int.TryParse(match.Groups[1].Value, out var number))
            lastTabNumber = Math.Max(lastTabNumber, number);
        }

        tab.SelectedIndex = 0;
        return true;
      }
      catch (Exception) {
        return false;
      }
    }

    private void saveSession_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      SaveSession(saveSession.FileName, stopThem);
    }

    private void loadSession_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      LoadSession(loadSession.FileName, startThem);
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
          LoadSession(fileName, false);
        }
      }
    }
  }
}