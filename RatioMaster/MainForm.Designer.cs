﻿namespace RatioMaster
{
    partial class MainForm
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.menu = new System.Windows.Forms.MenuStrip();
      this.currentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.manualUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.allRatioMastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.stopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.setUploadSpeedToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.setDownloadSpeedToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadSessionAndStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveCurrentSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveCurrentSessionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.chkMinimize = new System.Windows.Forms.ToolStripMenuItem();
      this.checkShowTrayBaloon = new System.Windows.Forms.ToolStripMenuItem();
      this.saveSettingsFromCurrentTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.enable24hformat = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.goToProgramPageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.menuRightClickTray = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.goToProgramSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
      this.tab = new System.Windows.Forms.TabControl();
      this.Status = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblTabs = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblIp = new System.Windows.Forms.ToolStripStatusLabel();
      this.saveSession = new System.Windows.Forms.SaveFileDialog();
      this.loadSession = new System.Windows.Forms.OpenFileDialog();
      this.menu.SuspendLayout();
      this.menuRightClickTray.SuspendLayout();
      this.Status.SuspendLayout();
      this.SuspendLayout();
      // 
      // menu
      // 
      this.menu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
      this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentToolStripMenuItem,
            this.allRatioMastersToolStripMenuItem,
            this.sessionsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menu.Location = new System.Drawing.Point(0, 0);
      this.menu.Name = "menu";
      this.menu.Size = new System.Drawing.Size(718, 36);
      this.menu.TabIndex = 0;
      this.menu.Text = "Menu";
      // 
      // currentToolStripMenuItem
      // 
      this.currentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.renameToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.startToolStripMenuItem,
            this.manualUpdateToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.currentToolStripMenuItem.Name = "currentToolStripMenuItem";
      this.currentToolStripMenuItem.Size = new System.Drawing.Size(54, 30);
      this.currentToolStripMenuItem.Text = "File";
      // 
      // newToolStripMenuItem1
      // 
      this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
      this.newToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItem1.Size = new System.Drawing.Size(233, 34);
      this.newToolStripMenuItem1.Text = "New";
      this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
      // 
      // renameToolStripMenuItem
      // 
      this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
      this.renameToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
      this.renameToolStripMenuItem.Text = "Rename";
      this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameCurrentToolStripMenuItem_Click);
      // 
      // removeToolStripMenuItem
      // 
      this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
      this.removeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
      this.removeToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
      this.removeToolStripMenuItem.Text = "Close";
      this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentToolStripMenuItem_Click);
      // 
      // startToolStripMenuItem
      // 
      this.startToolStripMenuItem.Name = "startToolStripMenuItem";
      this.startToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
      this.startToolStripMenuItem.Text = "Start";
      this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
      // 
      // manualUpdateToolStripMenuItem
      // 
      this.manualUpdateToolStripMenuItem.Name = "manualUpdateToolStripMenuItem";
      this.manualUpdateToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
      this.manualUpdateToolStripMenuItem.Text = "Manual update";
      this.manualUpdateToolStripMenuItem.Click += new System.EventHandler(this.manualUpdateToolStripMenuItem_Click);
      // 
      // stopToolStripMenuItem
      // 
      this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
      this.stopToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
      this.stopToolStripMenuItem.Text = "Stop";
      this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // allRatioMastersToolStripMenuItem
      // 
      this.allRatioMastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.stopToolStripMenuItem1,
            this.updateToolStripMenuItem,
            this.setUploadSpeedToToolStripMenuItem,
            this.setDownloadSpeedToToolStripMenuItem});
      this.allRatioMastersToolStripMenuItem.Name = "allRatioMastersToolStripMenuItem";
      this.allRatioMastersToolStripMenuItem.Size = new System.Drawing.Size(161, 30);
      this.allRatioMastersToolStripMenuItem.Text = "All RatioMasters ";
      // 
      // startToolStripMenuItem1
      // 
      this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
      this.startToolStripMenuItem1.Size = new System.Drawing.Size(299, 34);
      this.startToolStripMenuItem1.Text = "Start";
      this.startToolStripMenuItem1.Click += new System.EventHandler(this.startToolStripMenuItem1_Click);
      // 
      // stopToolStripMenuItem1
      // 
      this.stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
      this.stopToolStripMenuItem1.Size = new System.Drawing.Size(299, 34);
      this.stopToolStripMenuItem1.Text = "Stop";
      this.stopToolStripMenuItem1.Click += new System.EventHandler(this.stopToolStripMenuItem1_Click);
      // 
      // updateToolStripMenuItem
      // 
      this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
      this.updateToolStripMenuItem.Size = new System.Drawing.Size(299, 34);
      this.updateToolStripMenuItem.Text = "Update";
      this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
      // 
      // setUploadSpeedToToolStripMenuItem
      // 
      this.setUploadSpeedToToolStripMenuItem.Name = "setUploadSpeedToToolStripMenuItem";
      this.setUploadSpeedToToolStripMenuItem.Size = new System.Drawing.Size(299, 34);
      this.setUploadSpeedToToolStripMenuItem.Text = "Set upload speed to";
      this.setUploadSpeedToToolStripMenuItem.Click += new System.EventHandler(this.setUploadSpeedToToolStripMenuItem_Click);
      // 
      // setDownloadSpeedToToolStripMenuItem
      // 
      this.setDownloadSpeedToToolStripMenuItem.Name = "setDownloadSpeedToToolStripMenuItem";
      this.setDownloadSpeedToToolStripMenuItem.Size = new System.Drawing.Size(299, 34);
      this.setDownloadSpeedToToolStripMenuItem.Text = "Set download speed to";
      this.setDownloadSpeedToToolStripMenuItem.Click += new System.EventHandler(this.setDownloadSpeedToToolStripMenuItem_Click);
      // 
      // sessionsToolStripMenuItem
      // 
      this.sessionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSessionToolStripMenuItem,
            this.loadSessionAndStartToolStripMenuItem,
            this.saveCurrentSessionToolStripMenuItem,
            this.saveCurrentSessionToolStripMenuItem1});
      this.sessionsToolStripMenuItem.Name = "sessionsToolStripMenuItem";
      this.sessionsToolStripMenuItem.Size = new System.Drawing.Size(96, 30);
      this.sessionsToolStripMenuItem.Text = "Sessions";
      // 
      // loadSessionToolStripMenuItem
      // 
      this.loadSessionToolStripMenuItem.Name = "loadSessionToolStripMenuItem";
      this.loadSessionToolStripMenuItem.Size = new System.Drawing.Size(351, 34);
      this.loadSessionToolStripMenuItem.Text = "Load session";
      this.loadSessionToolStripMenuItem.Click += new System.EventHandler(this.loadSessionToolStripMenuItem_Click);
      // 
      // loadSessionAndStartToolStripMenuItem
      // 
      this.loadSessionAndStartToolStripMenuItem.Name = "loadSessionAndStartToolStripMenuItem";
      this.loadSessionAndStartToolStripMenuItem.Size = new System.Drawing.Size(351, 34);
      this.loadSessionAndStartToolStripMenuItem.Text = "Load session and Start";
      this.loadSessionAndStartToolStripMenuItem.Click += new System.EventHandler(this.loadSessionAndStartToolStripMenuItem_Click);
      // 
      // saveCurrentSessionToolStripMenuItem
      // 
      this.saveCurrentSessionToolStripMenuItem.Name = "saveCurrentSessionToolStripMenuItem";
      this.saveCurrentSessionToolStripMenuItem.Size = new System.Drawing.Size(351, 34);
      this.saveCurrentSessionToolStripMenuItem.Text = "Stop and Save current session";
      this.saveCurrentSessionToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentSessionToolStripMenuItem_Click);
      // 
      // saveCurrentSessionToolStripMenuItem1
      // 
      this.saveCurrentSessionToolStripMenuItem1.Name = "saveCurrentSessionToolStripMenuItem1";
      this.saveCurrentSessionToolStripMenuItem1.Size = new System.Drawing.Size(351, 34);
      this.saveCurrentSessionToolStripMenuItem1.Text = "Save current session";
      this.saveCurrentSessionToolStripMenuItem1.Click += new System.EventHandler(this.saveCurrentSessionToolStripMenuItem1_Click);
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkMinimize,
            this.checkShowTrayBaloon,
            this.saveSettingsFromCurrentTabToolStripMenuItem,
            this.closeToTrayToolStripMenuItem,
            this.enable24hformat});
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(92, 30);
      this.settingsToolStripMenuItem.Text = "Settings";
      // 
      // chkMinimize
      // 
      this.chkMinimize.Checked = true;
      this.chkMinimize.CheckOnClick = true;
      this.chkMinimize.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkMinimize.Name = "chkMinimize";
      this.chkMinimize.Size = new System.Drawing.Size(353, 34);
      this.chkMinimize.Text = "Minimize to tray";
      // 
      // checkShowTrayBaloon
      // 
      this.checkShowTrayBaloon.CheckOnClick = true;
      this.checkShowTrayBaloon.Name = "checkShowTrayBaloon";
      this.checkShowTrayBaloon.Size = new System.Drawing.Size(353, 34);
      this.checkShowTrayBaloon.Text = "Show baloon";
      // 
      // saveSettingsFromCurrentTabToolStripMenuItem
      // 
      this.saveSettingsFromCurrentTabToolStripMenuItem.Name = "saveSettingsFromCurrentTabToolStripMenuItem";
      this.saveSettingsFromCurrentTabToolStripMenuItem.Size = new System.Drawing.Size(353, 34);
      this.saveSettingsFromCurrentTabToolStripMenuItem.Text = "Save settings from current tab";
      this.saveSettingsFromCurrentTabToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsFromCurrentTabToolStripMenuItem_Click);
      // 
      // closeToTrayToolStripMenuItem
      // 
      this.closeToTrayToolStripMenuItem.CheckOnClick = true;
      this.closeToTrayToolStripMenuItem.Name = "closeToTrayToolStripMenuItem";
      this.closeToTrayToolStripMenuItem.Size = new System.Drawing.Size(353, 34);
      this.closeToTrayToolStripMenuItem.Text = "Close to tray";
      // 
      // enable24hformat
      // 
      this.enable24hformat.CheckOnClick = true;
      this.enable24hformat.Name = "enable24hformat";
      this.enable24hformat.Size = new System.Drawing.Size(353, 34);
      this.enable24hformat.Text = "Enable 24h format";
      this.enable24hformat.Click += new System.EventHandler(this.enable24hformat_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToProgramPageToolStripMenuItem1,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 30);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // goToProgramPageToolStripMenuItem1
      // 
      this.goToProgramPageToolStripMenuItem1.Name = "goToProgramPageToolStripMenuItem1";
      this.goToProgramPageToolStripMenuItem1.Size = new System.Drawing.Size(258, 34);
      this.goToProgramPageToolStripMenuItem1.Text = "Web site";
      this.goToProgramPageToolStripMenuItem1.Click += new System.EventHandler(this.goToProgramSiteToolStripMenuItem_Click);
      // 
      // checkForUpdatesToolStripMenuItem
      // 
      this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
      this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
      this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
      this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // trayIcon
      // 
      this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
      this.trayIcon.BalloonTipTitle = "RatioMaster";
      this.trayIcon.ContextMenuStrip = this.menuRightClickTray;
      this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
      this.trayIcon.Text = "RatioMaster";
      this.trayIcon.BalloonTipClicked += new System.EventHandler(this.trayIcon_BalloonTipClicked);
      this.trayIcon.BalloonTipClosed += new System.EventHandler(this.trayIcon_BalloonTipClosed);
      this.trayIcon.BalloonTipShown += new System.EventHandler(this.trayIcon_BalloonTipShown);
      this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
      this.trayIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseMove);
      // 
      // menuRightClickTray
      // 
      this.menuRightClickTray.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.menuRightClickTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.toolStripMenuItem1,
            this.goToProgramSiteToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4});
      this.menuRightClickTray.Name = "menuRightClickTray";
      this.menuRightClickTray.Size = new System.Drawing.Size(153, 150);
      // 
      // restoreToolStripMenuItem
      // 
      this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
      this.restoreToolStripMenuItem.Size = new System.Drawing.Size(152, 32);
      this.restoreToolStripMenuItem.Text = "Restore";
      this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
      // 
      // goToProgramSiteToolStripMenuItem
      // 
      this.goToProgramSiteToolStripMenuItem.Name = "goToProgramSiteToolStripMenuItem";
      this.goToProgramSiteToolStripMenuItem.Size = new System.Drawing.Size(152, 32);
      this.goToProgramSiteToolStripMenuItem.Text = "Web site";
      this.goToProgramSiteToolStripMenuItem.Click += new System.EventHandler(this.goToProgramSiteToolStripMenuItem_Click);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
      // 
      // aboutToolStripMenuItem1
      // 
      this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
      this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(152, 32);
      this.aboutToolStripMenuItem1.Text = "About";
      this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 32);
      this.toolStripMenuItem4.Text = "EXIT";
      this.toolStripMenuItem4.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // tab
      // 
      this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tab.Location = new System.Drawing.Point(0, 36);
      this.tab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tab.Name = "tab";
      this.tab.SelectedIndex = 0;
      this.tab.Size = new System.Drawing.Size(718, 730);
      this.tab.TabIndex = 1;
      this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_TabIndexChanged);
      this.tab.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.renameCurrentToolStripMenuItem_Click);
      // 
      // Status
      // 
      this.Status.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lblTabs,
            this.toolStripStatusLabel4,
            this.lblIp});
      this.Status.Location = new System.Drawing.Point(0, 766);
      this.Status.Name = "Status";
      this.Status.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
      this.Status.Size = new System.Drawing.Size(718, 28);
      this.Status.SizingGrip = false;
      this.Status.TabIndex = 2;
      this.Status.Text = "Status";
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Blue;
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(125, 21);
      this.toolStripStatusLabel2.Text = "Tabs opened:";
      // 
      // lblTabs
      // 
      this.lblTabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.lblTabs.ForeColor = System.Drawing.Color.Teal;
      this.lblTabs.Name = "lblTabs";
      this.lblTabs.Size = new System.Drawing.Size(21, 21);
      this.lblTabs.Text = "0";
      // 
      // toolStripStatusLabel4
      // 
      this.toolStripStatusLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Blue;
      this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
      this.toolStripStatusLabel4.Size = new System.Drawing.Size(85, 21);
      this.toolStripStatusLabel4.Text = "Local IP:";
      // 
      // lblIp
      // 
      this.lblIp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.lblIp.ForeColor = System.Drawing.Color.Teal;
      this.lblIp.Name = "lblIp";
      this.lblIp.Size = new System.Drawing.Size(91, 21);
      this.lblIp.Text = "127.0.0.1";
      // 
      // saveSession
      // 
      this.saveSession.Filter = "Sessions|*.session";
      this.saveSession.FileOk += new System.ComponentModel.CancelEventHandler(this.saveSession_FileOk);
      // 
      // loadSession
      // 
      this.loadSession.Filter = "Sessions|*.session";
      this.loadSession.FileOk += new System.ComponentModel.CancelEventHandler(this.loadSession_FileOk);
      // 
      // MainForm
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(718, 794);
      this.Controls.Add(this.tab);
      this.Controls.Add(this.menu);
      this.Controls.Add(this.Status);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menu;
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(740, 2000);
      this.MinimumSize = new System.Drawing.Size(740, 600);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
      this.Move += new System.EventHandler(this.MainForm_Move);
      this.menu.ResumeLayout(false);
      this.menu.PerformLayout();
      this.menuRightClickTray.ResumeLayout(false);
      this.Status.ResumeLayout(false);
      this.Status.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;

        #endregion

        internal System.Windows.Forms.MenuStrip menu;
        internal System.Windows.Forms.NotifyIcon trayIcon;
        internal System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem chkMinimize;
        internal System.Windows.Forms.ContextMenuStrip menuRightClickTray;
        internal System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem goToProgramSiteToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem checkShowTrayBaloon;
        internal System.Windows.Forms.TabControl tab;
        internal System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblTabs;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblIp;
        private System.Windows.Forms.ToolStripMenuItem currentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveSession;
        private System.Windows.Forms.OpenFileDialog loadSession;
        private System.Windows.Forms.ToolStripMenuItem loadSessionAndStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToProgramPageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentSessionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allRatioMastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUploadSpeedToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDownloadSpeedToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsFromCurrentTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enable24hformat;
    }
}