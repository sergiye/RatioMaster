namespace RatioMaster
{
    partial class RM
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        //internal System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.btnDefault = new System.Windows.Forms.Button();
      this.txtRemTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblUpdateIn = new System.Windows.Forms.ToolStripStatusLabel();
      this.timerValue = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblRemTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.RemaningWork = new System.Windows.Forms.Timer(this.components);
      this.SaveLog = new System.Windows.Forms.SaveFileDialog();
      this.info = new System.Windows.Forms.StatusStrip();
      this.uploadCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.uploadCount = new System.Windows.Forms.ToolStripStatusLabel();
      this.downloadCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.downloadCount = new System.Windows.Forms.ToolStripStatusLabel();
      this.lableTorrentRatio = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblTorrentRatio = new System.Windows.Forms.ToolStripStatusLabel();
      this.seedLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.leechLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblTotalTimeCap = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblTotalTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.serverUpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.manualUpdateButton = new System.Windows.Forms.Button();
      this.StartButton = new System.Windows.Forms.Button();
      this.StopButton = new System.Windows.Forms.Button();
      this.logWindow = new System.Windows.Forms.RichTextBox();
      this.panelControls = new System.Windows.Forms.Panel();
      this.customPeersNum = new System.Windows.Forms.TextBox();
      this.lblcustomPeersNum = new System.Windows.Forms.Label();
      this.lblGenStatus = new System.Windows.Forms.Label();
      this.customPort = new System.Windows.Forms.TextBox();
      this.portLabel = new System.Windows.Forms.Label();
      this.chkNewValues = new System.Windows.Forms.CheckBox();
      this.label4 = new System.Windows.Forms.Label();
      this.customPeerID = new System.Windows.Forms.TextBox();
      this.customKey = new System.Windows.Forms.TextBox();
      this.keyLabel = new System.Windows.Forms.Label();
      this.labelProxyType = new System.Windows.Forms.Label();
      this.labelProxyHost = new System.Windows.Forms.Label();
      this.textProxyPass = new System.Windows.Forms.TextBox();
      this.comboProxyType = new System.Windows.Forms.ComboBox();
      this.textProxyHost = new System.Windows.Forms.TextBox();
      this.labelProxyUser = new System.Windows.Forms.Label();
      this.textProxyPort = new System.Windows.Forms.TextBox();
      this.labelProxyPort = new System.Windows.Forms.Label();
      this.labelProxyPass = new System.Windows.Forms.Label();
      this.textProxyUser = new System.Windows.Forms.TextBox();
      this.checkIgnoreFailureReason = new System.Windows.Forms.CheckBox();
      this.checkRequestScrap = new System.Windows.Forms.CheckBox();
      this.checkTCPListen = new System.Windows.Forms.CheckBox();
      this.RandomDownloadTo = new System.Windows.Forms.TextBox();
      this.RandomDownloadFrom = new System.Windows.Forms.TextBox();
      this.checkRandomUpload = new System.Windows.Forms.CheckBox();
      this.checkRandomDownload = new System.Windows.Forms.CheckBox();
      this.lblRandomUploadFrom = new System.Windows.Forms.Label();
      this.RandomUploadTo = new System.Windows.Forms.TextBox();
      this.lblRandomUploadTo = new System.Windows.Forms.Label();
      this.lblRandomDownloadFrom = new System.Windows.Forms.Label();
      this.RandomUploadFrom = new System.Windows.Forms.TextBox();
      this.lblRandomDownloadTo = new System.Windows.Forms.Label();
      this.lblStopAfter = new System.Windows.Forms.Label();
      this.cmbStopAfter = new System.Windows.Forms.ComboBox();
      this.txtStopValue = new System.Windows.Forms.TextBox();
      this.intervalLabel = new System.Windows.Forms.Label();
      this.lblRemWork = new System.Windows.Forms.Label();
      this.fileSize = new System.Windows.Forms.TextBox();
      this.cmbVersion = new System.Windows.Forms.ComboBox();
      this.FileSizeLabel = new System.Windows.Forms.Label();
      this.cmbClient = new System.Windows.Forms.ComboBox();
      this.interval = new System.Windows.Forms.TextBox();
      this.ClientLabel = new System.Windows.Forms.Label();
      this.uploadRateLabel = new System.Windows.Forms.Label();
      this.uploadRate = new System.Windows.Forms.TextBox();
      this.txtRandDownMax = new System.Windows.Forms.TextBox();
      this.downloadRateLabel = new System.Windows.Forms.Label();
      this.txtRandUpMax = new System.Windows.Forms.TextBox();
      this.downloadRate = new System.Windows.Forms.TextBox();
      this.txtRandDownMin = new System.Windows.Forms.TextBox();
      this.chkRandUP = new System.Windows.Forms.CheckBox();
      this.txtRandUpMin = new System.Windows.Forms.TextBox();
      this.chkRandDown = new System.Windows.Forms.CheckBox();
      this.lblDownMax = new System.Windows.Forms.Label();
      this.lblUpMin = new System.Windows.Forms.Label();
      this.lblDownMin = new System.Windows.Forms.Label();
      this.lblUpMax = new System.Windows.Forms.Label();
      this.txtTorrentSize = new System.Windows.Forms.TextBox();
      this.trackerAddress = new System.Windows.Forms.TextBox();
      this.lblTorrentSize = new System.Windows.Forms.Label();
      this.TrackerLabel = new System.Windows.Forms.Label();
      this.shaHash = new System.Windows.Forms.TextBox();
      this.hashLabel = new System.Windows.Forms.Label();
      this.browseButton = new System.Windows.Forms.Button();
      this.torrentFile = new System.Windows.Forms.TextBox();
      this.gbxTorrent = new System.Windows.Forms.GroupBox();
      this.lblFile = new System.Windows.Forms.Label();
      this.gbxOptions = new System.Windows.Forms.GroupBox();
      this.gbxNextOptions = new System.Windows.Forms.GroupBox();
      this.gbxProxy = new System.Windows.Forms.GroupBox();
      this.gbxCustomClient = new System.Windows.Forms.GroupBox();
      this.panMain = new System.Windows.Forms.Panel();
      this.panAdvanced = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.info.SuspendLayout();
      this.panelControls.SuspendLayout();
      this.gbxTorrent.SuspendLayout();
      this.gbxOptions.SuspendLayout();
      this.gbxNextOptions.SuspendLayout();
      this.gbxProxy.SuspendLayout();
      this.gbxCustomClient.SuspendLayout();
      this.panMain.SuspendLayout();
      this.panAdvanced.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnDefault
      // 
      this.btnDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.btnDefault.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnDefault.Location = new System.Drawing.Point(351, 4);
      this.btnDefault.Name = "btnDefault";
      this.btnDefault.Size = new System.Drawing.Size(120, 34);
      this.btnDefault.TabIndex = 3;
      this.btnDefault.Text = "Set default values";
      this.btnDefault.UseVisualStyleBackColor = false;
      this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
      // 
      // txtRemTime
      // 
      this.txtRemTime.Name = "txtRemTime";
      this.txtRemTime.Size = new System.Drawing.Size(13, 17);
      this.txtRemTime.Text = "0";
      // 
      // lblUpdateIn
      // 
      this.lblUpdateIn.Name = "lblUpdateIn";
      this.lblUpdateIn.Size = new System.Drawing.Size(61, 17);
      this.lblUpdateIn.Text = "Update in:";
      // 
      // timerValue
      // 
      this.timerValue.Name = "timerValue";
      this.timerValue.Size = new System.Drawing.Size(13, 17);
      this.timerValue.Text = "0";
      // 
      // lblRemTime
      // 
      this.lblRemTime.Name = "lblRemTime";
      this.lblRemTime.Size = new System.Drawing.Size(64, 17);
      this.lblRemTime.Text = "Remaning:";
      this.lblRemTime.Visible = false;
      // 
      // RemaningWork
      // 
      this.RemaningWork.Interval = 1000;
      this.RemaningWork.Tick += new System.EventHandler(this.RemainingWork_Tick);
      // 
      // SaveLog
      // 
      this.SaveLog.Filter = "Text file|*.txt";
      this.SaveLog.Title = "Please select text file...";
      // 
      // info
      // 
      this.info.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUpdateIn,
            this.timerValue,
            this.uploadCountLabel,
            this.uploadCount,
            this.downloadCountLabel,
            this.downloadCount,
            this.lableTorrentRatio,
            this.lblTorrentRatio,
            this.seedLabel,
            this.leechLabel,
            this.lblTotalTimeCap,
            this.lblTotalTime,
            this.lblRemTime,
            this.txtRemTime});
      this.info.Location = new System.Drawing.Point(0, 402);
      this.info.Name = "info";
      this.info.Size = new System.Drawing.Size(963, 22);
      this.info.SizingGrip = false;
      this.info.TabIndex = 1;
      // 
      // uploadCountLabel
      // 
      this.uploadCountLabel.Name = "uploadCountLabel";
      this.uploadCountLabel.Size = new System.Drawing.Size(22, 17);
      this.uploadCountLabel.Text = "Up";
      // 
      // uploadCount
      // 
      this.uploadCount.Name = "uploadCount";
      this.uploadCount.Size = new System.Drawing.Size(13, 17);
      this.uploadCount.Text = "0";
      // 
      // downloadCountLabel
      // 
      this.downloadCountLabel.Name = "downloadCountLabel";
      this.downloadCountLabel.Size = new System.Drawing.Size(38, 17);
      this.downloadCountLabel.Text = "Down";
      // 
      // downloadCount
      // 
      this.downloadCount.Name = "downloadCount";
      this.downloadCount.Size = new System.Drawing.Size(13, 17);
      this.downloadCount.Text = "0";
      // 
      // lableTorrentRatio
      // 
      this.lableTorrentRatio.Name = "lableTorrentRatio";
      this.lableTorrentRatio.Size = new System.Drawing.Size(37, 17);
      this.lableTorrentRatio.Text = "Ratio:";
      // 
      // lblTorrentRatio
      // 
      this.lblTorrentRatio.Name = "lblTorrentRatio";
      this.lblTorrentRatio.Size = new System.Drawing.Size(22, 17);
      this.lblTorrentRatio.Text = "0.0";
      // 
      // seedLabel
      // 
      this.seedLabel.Name = "seedLabel";
      this.seedLabel.Size = new System.Drawing.Size(49, 17);
      this.seedLabel.Text = "Seeds: 0";
      // 
      // leechLabel
      // 
      this.leechLabel.Name = "leechLabel";
      this.leechLabel.Size = new System.Drawing.Size(47, 17);
      this.leechLabel.Text = "Peers: 0";
      // 
      // lblTotalTimeCap
      // 
      this.lblTotalTimeCap.Name = "lblTotalTimeCap";
      this.lblTotalTimeCap.Size = new System.Drawing.Size(36, 17);
      this.lblTotalTimeCap.Text = "Time:";
      // 
      // lblTotalTime
      // 
      this.lblTotalTime.Name = "lblTotalTime";
      this.lblTotalTime.Size = new System.Drawing.Size(34, 17);
      this.lblTotalTime.Text = "00:00";
      // 
      // serverUpdateTimer
      // 
      this.serverUpdateTimer.Interval = 1000;
      this.serverUpdateTimer.Tick += new System.EventHandler(this.serverUpdateTimer_Tick);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.Filter = "Torrent file|*.torrent";
      this.openFileDialog1.Title = "Open torrent file";
      this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
      // 
      // manualUpdateButton
      // 
      this.manualUpdateButton.BackColor = System.Drawing.SystemColors.Control;
      this.manualUpdateButton.Cursor = System.Windows.Forms.Cursors.Hand;
      this.manualUpdateButton.Enabled = false;
      this.manualUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.manualUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.manualUpdateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.manualUpdateButton.Location = new System.Drawing.Point(235, 4);
      this.manualUpdateButton.Name = "manualUpdateButton";
      this.manualUpdateButton.Size = new System.Drawing.Size(110, 34);
      this.manualUpdateButton.TabIndex = 2;
      this.manualUpdateButton.Text = "Manual Update";
      this.manualUpdateButton.UseVisualStyleBackColor = false;
      this.manualUpdateButton.Click += new System.EventHandler(this.manualUpdateButton_Click);
      // 
      // StartButton
      // 
      this.StartButton.BackColor = System.Drawing.Color.Silver;
      this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
      this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.StartButton.ForeColor = System.Drawing.Color.Blue;
      this.StartButton.Location = new System.Drawing.Point(3, 4);
      this.StartButton.Name = "StartButton";
      this.StartButton.Size = new System.Drawing.Size(110, 34);
      this.StartButton.TabIndex = 0;
      this.StartButton.Text = "START";
      this.StartButton.UseVisualStyleBackColor = false;
      this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
      // 
      // StopButton
      // 
      this.StopButton.BackColor = System.Drawing.SystemColors.Control;
      this.StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
      this.StopButton.Enabled = false;
      this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.StopButton.ForeColor = System.Drawing.Color.Red;
      this.StopButton.Location = new System.Drawing.Point(119, 4);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(110, 34);
      this.StopButton.TabIndex = 1;
      this.StopButton.Text = "STOP";
      this.StopButton.UseVisualStyleBackColor = false;
      this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
      // 
      // logWindow
      // 
      this.logWindow.BackColor = System.Drawing.Color.Black;
      this.logWindow.Dock = System.Windows.Forms.DockStyle.Fill;
      this.logWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.logWindow.Location = new System.Drawing.Point(0, 235);
      this.logWindow.Name = "logWindow";
      this.logWindow.ReadOnly = true;
      this.logWindow.Size = new System.Drawing.Size(963, 124);
      this.logWindow.TabIndex = 2;
      this.logWindow.Text = "------------------------------------- LOG -------------------------------------\n";
      // 
      // panelControls
      // 
      this.panelControls.Controls.Add(this.StartButton);
      this.panelControls.Controls.Add(this.btnDefault);
      this.panelControls.Controls.Add(this.manualUpdateButton);
      this.panelControls.Controls.Add(this.StopButton);
      this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControls.Location = new System.Drawing.Point(0, 359);
      this.panelControls.Margin = new System.Windows.Forms.Padding(2);
      this.panelControls.Name = "panelControls";
      this.panelControls.Size = new System.Drawing.Size(963, 43);
      this.panelControls.TabIndex = 0;
      // 
      // customPeersNum
      // 
      this.customPeersNum.Location = new System.Drawing.Point(423, 46);
      this.customPeersNum.Name = "customPeersNum";
      this.customPeersNum.Size = new System.Drawing.Size(51, 20);
      this.customPeersNum.TabIndex = 8;
      // 
      // lblcustomPeersNum
      // 
      this.lblcustomPeersNum.AutoSize = true;
      this.lblcustomPeersNum.Location = new System.Drawing.Point(329, 49);
      this.lblcustomPeersNum.Name = "lblcustomPeersNum";
      this.lblcustomPeersNum.Size = new System.Drawing.Size(88, 13);
      this.lblcustomPeersNum.TabIndex = 7;
      this.lblcustomPeersNum.Text = "Number of peers:";
      // 
      // lblGenStatus
      // 
      this.lblGenStatus.AutoSize = true;
      this.lblGenStatus.Location = new System.Drawing.Point(143, 98);
      this.lblGenStatus.Name = "lblGenStatus";
      this.lblGenStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.lblGenStatus.Size = new System.Drawing.Size(93, 13);
      this.lblGenStatus.TabIndex = 12;
      this.lblGenStatus.Text = "Generation status:";
      this.lblGenStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // customPort
      // 
      this.customPort.BackColor = System.Drawing.Color.White;
      this.customPort.Location = new System.Drawing.Point(274, 46);
      this.customPort.Name = "customPort";
      this.customPort.Size = new System.Drawing.Size(49, 20);
      this.customPort.TabIndex = 6;
      // 
      // portLabel
      // 
      this.portLabel.AutoSize = true;
      this.portLabel.Location = new System.Drawing.Point(239, 49);
      this.portLabel.Name = "portLabel";
      this.portLabel.Size = new System.Drawing.Size(29, 13);
      this.portLabel.TabIndex = 5;
      this.portLabel.Text = "Port:";
      // 
      // chkNewValues
      // 
      this.chkNewValues.AutoSize = true;
      this.chkNewValues.Checked = true;
      this.chkNewValues.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkNewValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chkNewValues.Location = new System.Drawing.Point(10, 96);
      this.chkNewValues.Name = "chkNewValues";
      this.chkNewValues.Size = new System.Drawing.Size(131, 17);
      this.chkNewValues.TabIndex = 11;
      this.chkNewValues.Text = "Always get new values";
      this.chkNewValues.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(7, 73);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(46, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Peer ID:";
      // 
      // customPeerID
      // 
      this.customPeerID.BackColor = System.Drawing.Color.White;
      this.customPeerID.Location = new System.Drawing.Point(70, 70);
      this.customPeerID.Name = "customPeerID";
      this.customPeerID.Size = new System.Drawing.Size(404, 20);
      this.customPeerID.TabIndex = 10;
      // 
      // customKey
      // 
      this.customKey.BackColor = System.Drawing.Color.White;
      this.customKey.Location = new System.Drawing.Point(70, 46);
      this.customKey.Name = "customKey";
      this.customKey.Size = new System.Drawing.Size(163, 20);
      this.customKey.TabIndex = 4;
      // 
      // keyLabel
      // 
      this.keyLabel.AutoSize = true;
      this.keyLabel.Location = new System.Drawing.Point(7, 49);
      this.keyLabel.Name = "keyLabel";
      this.keyLabel.Size = new System.Drawing.Size(57, 13);
      this.keyLabel.TabIndex = 3;
      this.keyLabel.Text = "Client Key:";
      // 
      // labelProxyType
      // 
      this.labelProxyType.AutoSize = true;
      this.labelProxyType.Location = new System.Drawing.Point(6, 27);
      this.labelProxyType.Name = "labelProxyType";
      this.labelProxyType.Size = new System.Drawing.Size(63, 13);
      this.labelProxyType.TabIndex = 0;
      this.labelProxyType.Text = "Proxy Type:";
      // 
      // labelProxyHost
      // 
      this.labelProxyHost.AutoSize = true;
      this.labelProxyHost.Location = new System.Drawing.Point(6, 51);
      this.labelProxyHost.Name = "labelProxyHost";
      this.labelProxyHost.Size = new System.Drawing.Size(61, 13);
      this.labelProxyHost.TabIndex = 6;
      this.labelProxyHost.Text = "Proxy Host:";
      // 
      // textProxyPass
      // 
      this.textProxyPass.BackColor = System.Drawing.Color.White;
      this.textProxyPass.Location = new System.Drawing.Point(404, 24);
      this.textProxyPass.Name = "textProxyPass";
      this.textProxyPass.Size = new System.Drawing.Size(68, 20);
      this.textProxyPass.TabIndex = 5;
      // 
      // comboProxyType
      // 
      this.comboProxyType.BackColor = System.Drawing.Color.White;
      this.comboProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboProxyType.FormattingEnabled = true;
      this.comboProxyType.Items.AddRange(new object[] {
            "None",
            "HTTP",
            "SOCKS4",
            "SOCKS4a",
            "SOCKS5"});
      this.comboProxyType.Location = new System.Drawing.Point(75, 23);
      this.comboProxyType.Name = "comboProxyType";
      this.comboProxyType.Size = new System.Drawing.Size(93, 21);
      this.comboProxyType.TabIndex = 1;
      // 
      // textProxyHost
      // 
      this.textProxyHost.BackColor = System.Drawing.Color.White;
      this.textProxyHost.Location = new System.Drawing.Point(75, 48);
      this.textProxyHost.Name = "textProxyHost";
      this.textProxyHost.Size = new System.Drawing.Size(255, 20);
      this.textProxyHost.TabIndex = 7;
      // 
      // labelProxyUser
      // 
      this.labelProxyUser.AutoSize = true;
      this.labelProxyUser.Location = new System.Drawing.Point(172, 27);
      this.labelProxyUser.Name = "labelProxyUser";
      this.labelProxyUser.Size = new System.Drawing.Size(61, 13);
      this.labelProxyUser.TabIndex = 2;
      this.labelProxyUser.Text = "Proxy User:";
      // 
      // textProxyPort
      // 
      this.textProxyPort.BackColor = System.Drawing.Color.White;
      this.textProxyPort.Location = new System.Drawing.Point(404, 48);
      this.textProxyPort.Name = "textProxyPort";
      this.textProxyPort.Size = new System.Drawing.Size(68, 20);
      this.textProxyPort.TabIndex = 9;
      // 
      // labelProxyPort
      // 
      this.labelProxyPort.AutoSize = true;
      this.labelProxyPort.Location = new System.Drawing.Point(336, 51);
      this.labelProxyPort.Name = "labelProxyPort";
      this.labelProxyPort.Size = new System.Drawing.Size(58, 13);
      this.labelProxyPort.TabIndex = 8;
      this.labelProxyPort.Text = "Proxy Port:";
      // 
      // labelProxyPass
      // 
      this.labelProxyPass.AutoSize = true;
      this.labelProxyPass.Location = new System.Drawing.Point(336, 27);
      this.labelProxyPass.Name = "labelProxyPass";
      this.labelProxyPass.Size = new System.Drawing.Size(62, 13);
      this.labelProxyPass.TabIndex = 4;
      this.labelProxyPass.Text = "Proxy Pass:";
      // 
      // textProxyUser
      // 
      this.textProxyUser.BackColor = System.Drawing.Color.White;
      this.textProxyUser.Location = new System.Drawing.Point(239, 24);
      this.textProxyUser.Name = "textProxyUser";
      this.textProxyUser.Size = new System.Drawing.Size(91, 20);
      this.textProxyUser.TabIndex = 3;
      // 
      // checkIgnoreFailureReason
      // 
      this.checkIgnoreFailureReason.AutoSize = true;
      this.checkIgnoreFailureReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.checkIgnoreFailureReason.Location = new System.Drawing.Point(217, 118);
      this.checkIgnoreFailureReason.Name = "checkIgnoreFailureReason";
      this.checkIgnoreFailureReason.Size = new System.Drawing.Size(123, 17);
      this.checkIgnoreFailureReason.TabIndex = 24;
      this.checkIgnoreFailureReason.Text = "Ignore \'failure reason\'";
      this.checkIgnoreFailureReason.UseVisualStyleBackColor = true;
      // 
      // checkRequestScrap
      // 
      this.checkRequestScrap.AutoSize = true;
      this.checkRequestScrap.Checked = true;
      this.checkRequestScrap.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkRequestScrap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.checkRequestScrap.Location = new System.Drawing.Point(117, 117);
      this.checkRequestScrap.Name = "checkRequestScrap";
      this.checkRequestScrap.Size = new System.Drawing.Size(94, 17);
      this.checkRequestScrap.TabIndex = 23;
      this.checkRequestScrap.Text = "Request Scrap";
      this.checkRequestScrap.UseVisualStyleBackColor = true;
      // 
      // checkTCPListen
      // 
      this.checkTCPListen.AutoSize = true;
      this.checkTCPListen.Checked = true;
      this.checkTCPListen.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkTCPListen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.checkTCPListen.Location = new System.Drawing.Point(9, 117);
      this.checkTCPListen.Name = "checkTCPListen";
      this.checkTCPListen.Size = new System.Drawing.Size(102, 17);
      this.checkTCPListen.TabIndex = 22;
      this.checkTCPListen.Text = "Use TCP listener";
      this.checkTCPListen.UseVisualStyleBackColor = true;
      // 
      // RandomDownloadTo
      // 
      this.RandomDownloadTo.BackColor = System.Drawing.Color.White;
      this.RandomDownloadTo.Location = new System.Drawing.Point(419, 18);
      this.RandomDownloadTo.Name = "RandomDownloadTo";
      this.RandomDownloadTo.Size = new System.Drawing.Size(37, 20);
      this.RandomDownloadTo.TabIndex = 9;
      this.RandomDownloadTo.Text = "50";
      // 
      // RandomDownloadFrom
      // 
      this.RandomDownloadFrom.BackColor = System.Drawing.Color.White;
      this.RandomDownloadFrom.Location = new System.Drawing.Point(340, 18);
      this.RandomDownloadFrom.Name = "RandomDownloadFrom";
      this.RandomDownloadFrom.Size = new System.Drawing.Size(37, 20);
      this.RandomDownloadFrom.TabIndex = 7;
      this.RandomDownloadFrom.Text = "10";
      // 
      // checkRandomUpload
      // 
      this.checkRandomUpload.AutoSize = true;
      this.checkRandomUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.checkRandomUpload.Location = new System.Drawing.Point(9, 19);
      this.checkRandomUpload.Name = "checkRandomUpload";
      this.checkRandomUpload.Size = new System.Drawing.Size(57, 17);
      this.checkRandomUpload.TabIndex = 0;
      this.checkRandomUpload.Text = "Upload";
      this.checkRandomUpload.UseVisualStyleBackColor = true;
      // 
      // checkRandomDownload
      // 
      this.checkRandomDownload.AutoSize = true;
      this.checkRandomDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.checkRandomDownload.Location = new System.Drawing.Point(227, 19);
      this.checkRandomDownload.Name = "checkRandomDownload";
      this.checkRandomDownload.Size = new System.Drawing.Size(74, 17);
      this.checkRandomDownload.TabIndex = 5;
      this.checkRandomDownload.Text = "Download:";
      this.checkRandomDownload.UseVisualStyleBackColor = true;
      // 
      // lblRandomUploadFrom
      // 
      this.lblRandomUploadFrom.AutoSize = true;
      this.lblRandomUploadFrom.Location = new System.Drawing.Point(72, 21);
      this.lblRandomUploadFrom.Name = "lblRandomUploadFrom";
      this.lblRandomUploadFrom.Size = new System.Drawing.Size(27, 13);
      this.lblRandomUploadFrom.TabIndex = 1;
      this.lblRandomUploadFrom.Text = "Min:";
      // 
      // RandomUploadTo
      // 
      this.RandomUploadTo.BackColor = System.Drawing.Color.White;
      this.RandomUploadTo.Location = new System.Drawing.Point(184, 18);
      this.RandomUploadTo.Name = "RandomUploadTo";
      this.RandomUploadTo.Size = new System.Drawing.Size(37, 20);
      this.RandomUploadTo.TabIndex = 4;
      this.RandomUploadTo.Text = "100";
      // 
      // lblRandomUploadTo
      // 
      this.lblRandomUploadTo.AutoSize = true;
      this.lblRandomUploadTo.Location = new System.Drawing.Point(148, 21);
      this.lblRandomUploadTo.Name = "lblRandomUploadTo";
      this.lblRandomUploadTo.Size = new System.Drawing.Size(30, 13);
      this.lblRandomUploadTo.TabIndex = 3;
      this.lblRandomUploadTo.Text = "Max:";
      // 
      // lblRandomDownloadFrom
      // 
      this.lblRandomDownloadFrom.AutoSize = true;
      this.lblRandomDownloadFrom.Location = new System.Drawing.Point(307, 21);
      this.lblRandomDownloadFrom.Name = "lblRandomDownloadFrom";
      this.lblRandomDownloadFrom.Size = new System.Drawing.Size(27, 13);
      this.lblRandomDownloadFrom.TabIndex = 6;
      this.lblRandomDownloadFrom.Text = "Min:";
      // 
      // RandomUploadFrom
      // 
      this.RandomUploadFrom.BackColor = System.Drawing.Color.White;
      this.RandomUploadFrom.Location = new System.Drawing.Point(105, 18);
      this.RandomUploadFrom.Name = "RandomUploadFrom";
      this.RandomUploadFrom.Size = new System.Drawing.Size(37, 20);
      this.RandomUploadFrom.TabIndex = 2;
      this.RandomUploadFrom.Text = "50";
      // 
      // lblRandomDownloadTo
      // 
      this.lblRandomDownloadTo.AutoSize = true;
      this.lblRandomDownloadTo.Location = new System.Drawing.Point(383, 21);
      this.lblRandomDownloadTo.Name = "lblRandomDownloadTo";
      this.lblRandomDownloadTo.Size = new System.Drawing.Size(30, 13);
      this.lblRandomDownloadTo.TabIndex = 8;
      this.lblRandomDownloadTo.Text = "Max:";
      // 
      // lblStopAfter
      // 
      this.lblStopAfter.AutoSize = true;
      this.lblStopAfter.Location = new System.Drawing.Point(399, 94);
      this.lblStopAfter.Name = "lblStopAfter";
      this.lblStopAfter.Size = new System.Drawing.Size(25, 13);
      this.lblStopAfter.TabIndex = 21;
      this.lblStopAfter.Text = "???";
      // 
      // cmbStopAfter
      // 
      this.cmbStopAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbStopAfter.FormattingEnabled = true;
      this.cmbStopAfter.Items.AddRange(new object[] {
            "Never",
            "After time:",
            "When seeders <",
            "When leechers <",
            "When uploaded >",
            "When downloaded >",
            "When leechers/seeders <"});
      this.cmbStopAfter.Location = new System.Drawing.Point(177, 91);
      this.cmbStopAfter.Name = "cmbStopAfter";
      this.cmbStopAfter.Size = new System.Drawing.Size(151, 21);
      this.cmbStopAfter.TabIndex = 19;
      this.cmbStopAfter.SelectedIndexChanged += new System.EventHandler(this.cmbStopAfter_SelectedIndexChanged);
      // 
      // txtStopValue
      // 
      this.txtStopValue.BackColor = System.Drawing.Color.White;
      this.txtStopValue.Location = new System.Drawing.Point(334, 91);
      this.txtStopValue.Name = "txtStopValue";
      this.txtStopValue.Size = new System.Drawing.Size(59, 20);
      this.txtStopValue.TabIndex = 20;
      this.txtStopValue.Text = "0";
      // 
      // intervalLabel
      // 
      this.intervalLabel.AutoSize = true;
      this.intervalLabel.Location = new System.Drawing.Point(6, 70);
      this.intervalLabel.Name = "intervalLabel";
      this.intervalLabel.Size = new System.Drawing.Size(97, 13);
      this.intervalLabel.TabIndex = 14;
      this.intervalLabel.Text = "Update Interval (s):";
      // 
      // lblRemWork
      // 
      this.lblRemWork.AutoSize = true;
      this.lblRemWork.Location = new System.Drawing.Point(132, 94);
      this.lblRemWork.Name = "lblRemWork";
      this.lblRemWork.Size = new System.Drawing.Size(39, 13);
      this.lblRemWork.TabIndex = 18;
      this.lblRemWork.Text = "STOP:";
      // 
      // fileSize
      // 
      this.fileSize.BackColor = System.Drawing.Color.White;
      this.fileSize.Location = new System.Drawing.Point(78, 91);
      this.fileSize.MaxLength = 5;
      this.fileSize.Name = "fileSize";
      this.fileSize.Size = new System.Drawing.Size(48, 20);
      this.fileSize.TabIndex = 17;
      this.fileSize.Text = "0";
      // 
      // cmbVersion
      // 
      this.cmbVersion.BackColor = System.Drawing.Color.White;
      this.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbVersion.FormattingEnabled = true;
      this.cmbVersion.Location = new System.Drawing.Point(242, 19);
      this.cmbVersion.Name = "cmbVersion";
      this.cmbVersion.Size = new System.Drawing.Size(128, 21);
      this.cmbVersion.TabIndex = 2;
      this.cmbVersion.SelectedValueChanged += new System.EventHandler(this.cmbVersion_SelectedValueChanged);
      // 
      // FileSizeLabel
      // 
      this.FileSizeLabel.AutoSize = true;
      this.FileSizeLabel.Location = new System.Drawing.Point(6, 94);
      this.FileSizeLabel.Name = "FileSizeLabel";
      this.FileSizeLabel.Size = new System.Drawing.Size(66, 13);
      this.FileSizeLabel.TabIndex = 16;
      this.FileSizeLabel.Text = "Finished (%):";
      // 
      // cmbClient
      // 
      this.cmbClient.BackColor = System.Drawing.Color.White;
      this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbClient.FormattingEnabled = true;
      this.cmbClient.IntegralHeight = false;
      this.cmbClient.Items.AddRange(new object[] {
            "uTorrent",
            "BitComet",
            "Azureus",
            "Vuze",
            "BitTorrent",
            "Transmission",
            "ABC",
            "BitLord",
            "BTuga",
            "BitTornado",
            "Burst",
            "BitTyrant",
            "BitSpirit",
            "Deluge",
            "KTorrent",
            "Gnome BT"});
      this.cmbClient.Location = new System.Drawing.Point(69, 19);
      this.cmbClient.Name = "cmbClient";
      this.cmbClient.Size = new System.Drawing.Size(164, 21);
      this.cmbClient.TabIndex = 1;
      this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
      // 
      // interval
      // 
      this.interval.BackColor = System.Drawing.Color.White;
      this.interval.Location = new System.Drawing.Point(136, 65);
      this.interval.Name = "interval";
      this.interval.Size = new System.Drawing.Size(55, 20);
      this.interval.TabIndex = 15;
      this.interval.Text = "300";
      // 
      // ClientLabel
      // 
      this.ClientLabel.AutoSize = true;
      this.ClientLabel.Location = new System.Drawing.Point(6, 24);
      this.ClientLabel.Name = "ClientLabel";
      this.ClientLabel.Size = new System.Drawing.Size(36, 13);
      this.ClientLabel.TabIndex = 0;
      this.ClientLabel.Text = "Client:";
      // 
      // uploadRateLabel
      // 
      this.uploadRateLabel.AutoSize = true;
      this.uploadRateLabel.Location = new System.Drawing.Point(6, 22);
      this.uploadRateLabel.Name = "uploadRateLabel";
      this.uploadRateLabel.Size = new System.Drawing.Size(110, 13);
      this.uploadRateLabel.TabIndex = 0;
      this.uploadRateLabel.Text = "Upload Speed (kB/s):";
      // 
      // uploadRate
      // 
      this.uploadRate.BackColor = System.Drawing.Color.White;
      this.uploadRate.Location = new System.Drawing.Point(136, 19);
      this.uploadRate.Name = "uploadRate";
      this.uploadRate.Size = new System.Drawing.Size(55, 20);
      this.uploadRate.TabIndex = 1;
      this.uploadRate.Text = "60";
      this.uploadRate.TextChanged += new System.EventHandler(this.uploadRate_TextChanged);
      // 
      // txtRandDownMax
      // 
      this.txtRandDownMax.BackColor = System.Drawing.Color.White;
      this.txtRandDownMax.Location = new System.Drawing.Point(430, 43);
      this.txtRandDownMax.Name = "txtRandDownMax";
      this.txtRandDownMax.Size = new System.Drawing.Size(43, 20);
      this.txtRandDownMax.TabIndex = 13;
      this.txtRandDownMax.Text = "10";
      // 
      // downloadRateLabel
      // 
      this.downloadRateLabel.AutoSize = true;
      this.downloadRateLabel.Location = new System.Drawing.Point(6, 46);
      this.downloadRateLabel.Name = "downloadRateLabel";
      this.downloadRateLabel.Size = new System.Drawing.Size(124, 13);
      this.downloadRateLabel.TabIndex = 7;
      this.downloadRateLabel.Text = "Download Speed (kB/s):";
      // 
      // txtRandUpMax
      // 
      this.txtRandUpMax.BackColor = System.Drawing.Color.White;
      this.txtRandUpMax.Location = new System.Drawing.Point(430, 19);
      this.txtRandUpMax.Name = "txtRandUpMax";
      this.txtRandUpMax.Size = new System.Drawing.Size(43, 20);
      this.txtRandUpMax.TabIndex = 6;
      this.txtRandUpMax.Text = "10";
      // 
      // downloadRate
      // 
      this.downloadRate.BackColor = System.Drawing.Color.White;
      this.downloadRate.Location = new System.Drawing.Point(136, 43);
      this.downloadRate.Name = "downloadRate";
      this.downloadRate.Size = new System.Drawing.Size(55, 20);
      this.downloadRate.TabIndex = 8;
      this.downloadRate.Text = "25";
      this.downloadRate.TextChanged += new System.EventHandler(this.downloadRate_TextChanged);
      // 
      // txtRandDownMin
      // 
      this.txtRandDownMin.BackColor = System.Drawing.Color.White;
      this.txtRandDownMin.Location = new System.Drawing.Point(345, 43);
      this.txtRandDownMin.Name = "txtRandDownMin";
      this.txtRandDownMin.Size = new System.Drawing.Size(43, 20);
      this.txtRandDownMin.TabIndex = 11;
      this.txtRandDownMin.Text = "1";
      // 
      // chkRandUP
      // 
      this.chkRandUP.AutoSize = true;
      this.chkRandUP.Checked = true;
      this.chkRandUP.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkRandUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chkRandUP.Location = new System.Drawing.Point(197, 20);
      this.chkRandUP.Name = "chkRandUP";
      this.chkRandUP.Size = new System.Drawing.Size(109, 17);
      this.chkRandUP.TabIndex = 2;
      this.chkRandUP.Text = "+ Random values:";
      this.chkRandUP.UseVisualStyleBackColor = true;
      // 
      // txtRandUpMin
      // 
      this.txtRandUpMin.BackColor = System.Drawing.Color.White;
      this.txtRandUpMin.Location = new System.Drawing.Point(345, 19);
      this.txtRandUpMin.Name = "txtRandUpMin";
      this.txtRandUpMin.Size = new System.Drawing.Size(43, 20);
      this.txtRandUpMin.TabIndex = 4;
      this.txtRandUpMin.Text = "1";
      // 
      // chkRandDown
      // 
      this.chkRandDown.AutoSize = true;
      this.chkRandDown.Checked = true;
      this.chkRandDown.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkRandDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chkRandDown.Location = new System.Drawing.Point(197, 44);
      this.chkRandDown.Name = "chkRandDown";
      this.chkRandDown.Size = new System.Drawing.Size(109, 17);
      this.chkRandDown.TabIndex = 9;
      this.chkRandDown.Text = "+ Random values:";
      this.chkRandDown.UseVisualStyleBackColor = true;
      // 
      // lblDownMax
      // 
      this.lblDownMax.AutoSize = true;
      this.lblDownMax.Location = new System.Drawing.Point(394, 46);
      this.lblDownMax.Name = "lblDownMax";
      this.lblDownMax.Size = new System.Drawing.Size(30, 13);
      this.lblDownMax.TabIndex = 12;
      this.lblDownMax.Text = "Max:";
      // 
      // lblUpMin
      // 
      this.lblUpMin.AutoSize = true;
      this.lblUpMin.Location = new System.Drawing.Point(312, 22);
      this.lblUpMin.Name = "lblUpMin";
      this.lblUpMin.Size = new System.Drawing.Size(27, 13);
      this.lblUpMin.TabIndex = 3;
      this.lblUpMin.Text = "Min:";
      // 
      // lblDownMin
      // 
      this.lblDownMin.AutoSize = true;
      this.lblDownMin.Location = new System.Drawing.Point(312, 46);
      this.lblDownMin.Name = "lblDownMin";
      this.lblDownMin.Size = new System.Drawing.Size(27, 13);
      this.lblDownMin.TabIndex = 10;
      this.lblDownMin.Text = "Min:";
      // 
      // lblUpMax
      // 
      this.lblUpMax.AutoSize = true;
      this.lblUpMax.Location = new System.Drawing.Point(394, 22);
      this.lblUpMax.Name = "lblUpMax";
      this.lblUpMax.Size = new System.Drawing.Size(30, 13);
      this.lblUpMax.TabIndex = 5;
      this.lblUpMax.Text = "Max:";
      // 
      // txtTorrentSize
      // 
      this.txtTorrentSize.Location = new System.Drawing.Point(402, 68);
      this.txtTorrentSize.Name = "txtTorrentSize";
      this.txtTorrentSize.ReadOnly = true;
      this.txtTorrentSize.Size = new System.Drawing.Size(71, 20);
      this.txtTorrentSize.TabIndex = 8;
      // 
      // trackerAddress
      // 
      this.trackerAddress.BackColor = System.Drawing.Color.White;
      this.trackerAddress.Location = new System.Drawing.Point(59, 44);
      this.trackerAddress.Name = "trackerAddress";
      this.trackerAddress.Size = new System.Drawing.Size(414, 20);
      this.trackerAddress.TabIndex = 4;
      // 
      // lblTorrentSize
      // 
      this.lblTorrentSize.AutoSize = true;
      this.lblTorrentSize.Location = new System.Drawing.Point(366, 71);
      this.lblTorrentSize.Name = "lblTorrentSize";
      this.lblTorrentSize.Size = new System.Drawing.Size(30, 13);
      this.lblTorrentSize.TabIndex = 7;
      this.lblTorrentSize.Text = "Size:";
      // 
      // TrackerLabel
      // 
      this.TrackerLabel.AutoSize = true;
      this.TrackerLabel.Location = new System.Drawing.Point(6, 47);
      this.TrackerLabel.Name = "TrackerLabel";
      this.TrackerLabel.Size = new System.Drawing.Size(47, 13);
      this.TrackerLabel.TabIndex = 3;
      this.TrackerLabel.Text = "Tracker:";
      // 
      // shaHash
      // 
      this.shaHash.Location = new System.Drawing.Point(59, 68);
      this.shaHash.Name = "shaHash";
      this.shaHash.ReadOnly = true;
      this.shaHash.Size = new System.Drawing.Size(301, 20);
      this.shaHash.TabIndex = 6;
      // 
      // hashLabel
      // 
      this.hashLabel.AutoSize = true;
      this.hashLabel.Location = new System.Drawing.Point(6, 71);
      this.hashLabel.Name = "hashLabel";
      this.hashLabel.Size = new System.Drawing.Size(40, 13);
      this.hashLabel.TabIndex = 5;
      this.hashLabel.Text = "HASH:\r\n";
      // 
      // browseButton
      // 
      this.browseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.browseButton.Cursor = System.Windows.Forms.Cursors.Hand;
      this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.browseButton.Location = new System.Drawing.Point(404, 16);
      this.browseButton.Name = "browseButton";
      this.browseButton.Size = new System.Drawing.Size(71, 24);
      this.browseButton.TabIndex = 2;
      this.browseButton.Text = "Browse...";
      this.browseButton.UseVisualStyleBackColor = false;
      this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
      // 
      // torrentFile
      // 
      this.torrentFile.BackColor = System.Drawing.Color.White;
      this.torrentFile.Location = new System.Drawing.Point(59, 19);
      this.torrentFile.Name = "torrentFile";
      this.torrentFile.ReadOnly = true;
      this.torrentFile.Size = new System.Drawing.Size(339, 20);
      this.torrentFile.TabIndex = 1;
      // 
      // gbxTorrent
      // 
      this.gbxTorrent.Controls.Add(this.lblFile);
      this.gbxTorrent.Controls.Add(this.txtTorrentSize);
      this.gbxTorrent.Controls.Add(this.browseButton);
      this.gbxTorrent.Controls.Add(this.TrackerLabel);
      this.gbxTorrent.Controls.Add(this.trackerAddress);
      this.gbxTorrent.Controls.Add(this.torrentFile);
      this.gbxTorrent.Controls.Add(this.hashLabel);
      this.gbxTorrent.Controls.Add(this.shaHash);
      this.gbxTorrent.Controls.Add(this.lblTorrentSize);
      this.gbxTorrent.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxTorrent.Location = new System.Drawing.Point(0, 0);
      this.gbxTorrent.Name = "gbxTorrent";
      this.gbxTorrent.Size = new System.Drawing.Size(481, 94);
      this.gbxTorrent.TabIndex = 0;
      this.gbxTorrent.TabStop = false;
      this.gbxTorrent.Text = "Torrent";
      // 
      // lblFile
      // 
      this.lblFile.AutoSize = true;
      this.lblFile.Location = new System.Drawing.Point(6, 26);
      this.lblFile.Name = "lblFile";
      this.lblFile.Size = new System.Drawing.Size(26, 13);
      this.lblFile.TabIndex = 0;
      this.lblFile.Text = "File:";
      // 
      // gbxOptions
      // 
      this.gbxOptions.Controls.Add(this.checkIgnoreFailureReason);
      this.gbxOptions.Controls.Add(this.checkTCPListen);
      this.gbxOptions.Controls.Add(this.checkRequestScrap);
      this.gbxOptions.Controls.Add(this.lblStopAfter);
      this.gbxOptions.Controls.Add(this.uploadRateLabel);
      this.gbxOptions.Controls.Add(this.intervalLabel);
      this.gbxOptions.Controls.Add(this.cmbStopAfter);
      this.gbxOptions.Controls.Add(this.uploadRate);
      this.gbxOptions.Controls.Add(this.lblUpMax);
      this.gbxOptions.Controls.Add(this.txtStopValue);
      this.gbxOptions.Controls.Add(this.txtRandDownMax);
      this.gbxOptions.Controls.Add(this.interval);
      this.gbxOptions.Controls.Add(this.lblDownMin);
      this.gbxOptions.Controls.Add(this.downloadRateLabel);
      this.gbxOptions.Controls.Add(this.lblRemWork);
      this.gbxOptions.Controls.Add(this.lblUpMin);
      this.gbxOptions.Controls.Add(this.FileSizeLabel);
      this.gbxOptions.Controls.Add(this.txtRandUpMax);
      this.gbxOptions.Controls.Add(this.fileSize);
      this.gbxOptions.Controls.Add(this.lblDownMax);
      this.gbxOptions.Controls.Add(this.downloadRate);
      this.gbxOptions.Controls.Add(this.chkRandDown);
      this.gbxOptions.Controls.Add(this.txtRandDownMin);
      this.gbxOptions.Controls.Add(this.txtRandUpMin);
      this.gbxOptions.Controls.Add(this.chkRandUP);
      this.gbxOptions.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxOptions.Location = new System.Drawing.Point(0, 94);
      this.gbxOptions.Name = "gbxOptions";
      this.gbxOptions.Size = new System.Drawing.Size(481, 140);
      this.gbxOptions.TabIndex = 0;
      this.gbxOptions.TabStop = false;
      this.gbxOptions.Text = "Options";
      // 
      // gbxNextOptions
      // 
      this.gbxNextOptions.Controls.Add(this.RandomDownloadTo);
      this.gbxNextOptions.Controls.Add(this.checkRandomUpload);
      this.gbxNextOptions.Controls.Add(this.RandomDownloadFrom);
      this.gbxNextOptions.Controls.Add(this.lblRandomDownloadTo);
      this.gbxNextOptions.Controls.Add(this.RandomUploadFrom);
      this.gbxNextOptions.Controls.Add(this.checkRandomDownload);
      this.gbxNextOptions.Controls.Add(this.lblRandomDownloadFrom);
      this.gbxNextOptions.Controls.Add(this.lblRandomUploadFrom);
      this.gbxNextOptions.Controls.Add(this.lblRandomUploadTo);
      this.gbxNextOptions.Controls.Add(this.RandomUploadTo);
      this.gbxNextOptions.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxNextOptions.Location = new System.Drawing.Point(0, 0);
      this.gbxNextOptions.Name = "gbxNextOptions";
      this.gbxNextOptions.Size = new System.Drawing.Size(480, 44);
      this.gbxNextOptions.TabIndex = 0;
      this.gbxNextOptions.TabStop = false;
      this.gbxNextOptions.Text = "On Next Update Get Random Speeds";
      // 
      // gbxProxy
      // 
      this.gbxProxy.Controls.Add(this.labelProxyType);
      this.gbxProxy.Controls.Add(this.labelProxyHost);
      this.gbxProxy.Controls.Add(this.textProxyUser);
      this.gbxProxy.Controls.Add(this.textProxyPass);
      this.gbxProxy.Controls.Add(this.labelProxyPass);
      this.gbxProxy.Controls.Add(this.comboProxyType);
      this.gbxProxy.Controls.Add(this.labelProxyPort);
      this.gbxProxy.Controls.Add(this.textProxyHost);
      this.gbxProxy.Controls.Add(this.textProxyPort);
      this.gbxProxy.Controls.Add(this.labelProxyUser);
      this.gbxProxy.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxProxy.Location = new System.Drawing.Point(0, 161);
      this.gbxProxy.Name = "gbxProxy";
      this.gbxProxy.Size = new System.Drawing.Size(480, 73);
      this.gbxProxy.TabIndex = 0;
      this.gbxProxy.TabStop = false;
      this.gbxProxy.Text = "Proxy Server Settings";
      // 
      // gbxCustomClient
      // 
      this.gbxCustomClient.Controls.Add(this.customPeersNum);
      this.gbxCustomClient.Controls.Add(this.ClientLabel);
      this.gbxCustomClient.Controls.Add(this.keyLabel);
      this.gbxCustomClient.Controls.Add(this.lblcustomPeersNum);
      this.gbxCustomClient.Controls.Add(this.customKey);
      this.gbxCustomClient.Controls.Add(this.lblGenStatus);
      this.gbxCustomClient.Controls.Add(this.customPeerID);
      this.gbxCustomClient.Controls.Add(this.customPort);
      this.gbxCustomClient.Controls.Add(this.label4);
      this.gbxCustomClient.Controls.Add(this.portLabel);
      this.gbxCustomClient.Controls.Add(this.chkNewValues);
      this.gbxCustomClient.Controls.Add(this.cmbVersion);
      this.gbxCustomClient.Controls.Add(this.cmbClient);
      this.gbxCustomClient.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxCustomClient.Location = new System.Drawing.Point(0, 44);
      this.gbxCustomClient.Name = "gbxCustomClient";
      this.gbxCustomClient.Size = new System.Drawing.Size(480, 117);
      this.gbxCustomClient.TabIndex = 1;
      this.gbxCustomClient.TabStop = false;
      this.gbxCustomClient.Text = "Custom Client Simulation";
      // 
      // panMain
      // 
      this.panMain.Controls.Add(this.gbxOptions);
      this.panMain.Controls.Add(this.gbxTorrent);
      this.panMain.Dock = System.Windows.Forms.DockStyle.Left;
      this.panMain.Location = new System.Drawing.Point(0, 0);
      this.panMain.Name = "panMain";
      this.panMain.Size = new System.Drawing.Size(481, 235);
      this.panMain.TabIndex = 32;
      // 
      // panAdvanced
      // 
      this.panAdvanced.Controls.Add(this.gbxProxy);
      this.panAdvanced.Controls.Add(this.gbxCustomClient);
      this.panAdvanced.Controls.Add(this.gbxNextOptions);
      this.panAdvanced.Dock = System.Windows.Forms.DockStyle.Left;
      this.panAdvanced.Location = new System.Drawing.Point(481, 0);
      this.panAdvanced.Name = "panAdvanced";
      this.panAdvanced.Size = new System.Drawing.Size(480, 235);
      this.panAdvanced.TabIndex = 33;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panAdvanced);
      this.panel1.Controls.Add(this.panMain);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(963, 235);
      this.panel1.TabIndex = 34;
      // 
      // RM
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.logWindow);
      this.Controls.Add(this.panelControls);
      this.Controls.Add(this.info);
      this.Controls.Add(this.panel1);
      this.Name = "RM";
      this.Size = new System.Drawing.Size(963, 424);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
      this.info.ResumeLayout(false);
      this.info.PerformLayout();
      this.panelControls.ResumeLayout(false);
      this.gbxTorrent.ResumeLayout(false);
      this.gbxTorrent.PerformLayout();
      this.gbxOptions.ResumeLayout(false);
      this.gbxOptions.PerformLayout();
      this.gbxNextOptions.ResumeLayout(false);
      this.gbxNextOptions.PerformLayout();
      this.gbxProxy.ResumeLayout(false);
      this.gbxProxy.PerformLayout();
      this.gbxCustomClient.ResumeLayout(false);
      this.gbxCustomClient.PerformLayout();
      this.panMain.ResumeLayout(false);
      this.panAdvanced.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        private System.Windows.Forms.Panel panelControls;

        #endregion

        internal System.Windows.Forms.TextBox txtRandDownMax;
        internal System.Windows.Forms.TextBox txtRandUpMax;
        internal System.Windows.Forms.TextBox txtRandDownMin;
        internal System.Windows.Forms.TextBox txtRandUpMin;
        internal System.Windows.Forms.Label lblDownMax;
        internal System.Windows.Forms.Label lblDownMin;
        internal System.Windows.Forms.Label lblUpMax;
        internal System.Windows.Forms.Label lblUpMin;
        internal System.Windows.Forms.CheckBox chkRandDown;
        internal System.Windows.Forms.CheckBox chkRandUP;
        internal System.Windows.Forms.ComboBox cmbVersion;
        internal System.Windows.Forms.ComboBox cmbClient;
        internal System.Windows.Forms.Label ClientLabel;
        internal System.Windows.Forms.TextBox interval;
        internal System.Windows.Forms.Label intervalLabel;
        internal System.Windows.Forms.Label FileSizeLabel;
        internal System.Windows.Forms.TextBox fileSize;
        internal System.Windows.Forms.TextBox downloadRate;
        internal System.Windows.Forms.Label downloadRateLabel;
        internal System.Windows.Forms.TextBox uploadRate;
        internal System.Windows.Forms.Label uploadRateLabel;
        internal System.Windows.Forms.TextBox txtTorrentSize;
        internal System.Windows.Forms.Label lblTorrentSize;
        internal System.Windows.Forms.TextBox shaHash;
        internal System.Windows.Forms.Label hashLabel;
        internal System.Windows.Forms.TextBox trackerAddress;
        internal System.Windows.Forms.Label TrackerLabel;
        internal System.Windows.Forms.Button browseButton;
        internal System.Windows.Forms.TextBox torrentFile;
        internal System.Windows.Forms.TextBox txtStopValue;
        internal System.Windows.Forms.Label lblRemWork;
        internal System.Windows.Forms.CheckBox checkTCPListen;
        internal System.Windows.Forms.CheckBox checkRequestScrap;
        internal System.Windows.Forms.Button btnDefault;
        internal System.Windows.Forms.Label labelProxyType;
        internal System.Windows.Forms.Label labelProxyHost;
        internal System.Windows.Forms.ComboBox comboProxyType;
        internal System.Windows.Forms.Label labelProxyUser;
        internal System.Windows.Forms.Label labelProxyPort;
        internal System.Windows.Forms.TextBox textProxyUser;
        internal System.Windows.Forms.Label labelProxyPass;
        internal System.Windows.Forms.TextBox textProxyPort;
        internal System.Windows.Forms.TextBox textProxyHost;
        internal System.Windows.Forms.TextBox textProxyPass;
        internal System.Windows.Forms.ToolStripStatusLabel txtRemTime;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdateIn;
        internal System.Windows.Forms.ToolStripStatusLabel timerValue;
        internal System.Windows.Forms.ToolStripStatusLabel lblRemTime;
        internal System.Windows.Forms.Timer RemaningWork;
        internal System.Windows.Forms.SaveFileDialog SaveLog;
        internal System.Windows.Forms.StatusStrip info;
        internal System.Windows.Forms.ToolStripStatusLabel uploadCountLabel;
        internal System.Windows.Forms.ToolStripStatusLabel uploadCount;
        internal System.Windows.Forms.ToolStripStatusLabel downloadCountLabel;
        internal System.Windows.Forms.ToolStripStatusLabel downloadCount;
        internal System.Windows.Forms.ToolStripStatusLabel lableTorrentRatio;
        internal System.Windows.Forms.ToolStripStatusLabel lblTorrentRatio;
        internal System.Windows.Forms.Timer serverUpdateTimer;
        internal System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.Button manualUpdateButton;
        internal System.Windows.Forms.Button StartButton;
        internal System.Windows.Forms.Button StopButton;
        internal System.Windows.Forms.RichTextBox logWindow;
        internal System.Windows.Forms.ToolStripStatusLabel seedLabel;
        internal System.Windows.Forms.ToolStripStatusLabel leechLabel;
        private System.ComponentModel.IContainer components;
        internal System.Windows.Forms.TextBox customPeersNum;
        internal System.Windows.Forms.Label lblcustomPeersNum;
        internal System.Windows.Forms.Label lblGenStatus;
        internal System.Windows.Forms.TextBox customPort;
        internal System.Windows.Forms.Label portLabel;
        internal System.Windows.Forms.CheckBox chkNewValues;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox customPeerID;
        internal System.Windows.Forms.TextBox customKey;
        internal System.Windows.Forms.Label keyLabel;
        internal System.Windows.Forms.TextBox RandomDownloadTo;
        internal System.Windows.Forms.TextBox RandomDownloadFrom;
        internal System.Windows.Forms.CheckBox checkRandomUpload;
        internal System.Windows.Forms.CheckBox checkRandomDownload;
        internal System.Windows.Forms.Label lblRandomUploadFrom;
        internal System.Windows.Forms.TextBox RandomUploadTo;
        internal System.Windows.Forms.Label lblRandomUploadTo;
        internal System.Windows.Forms.Label lblRandomDownloadFrom;
        internal System.Windows.Forms.TextBox RandomUploadFrom;
        internal System.Windows.Forms.Label lblRandomDownloadTo;
        internal System.Windows.Forms.ComboBox cmbStopAfter;
        private System.Windows.Forms.Label lblStopAfter;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalTimeCap;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalTime;
        internal System.Windows.Forms.CheckBox checkIgnoreFailureReason;
    private System.Windows.Forms.GroupBox gbxTorrent;
    private System.Windows.Forms.GroupBox gbxOptions;
    private System.Windows.Forms.GroupBox gbxNextOptions;
    private System.Windows.Forms.GroupBox gbxProxy;
    private System.Windows.Forms.GroupBox gbxCustomClient;
    private System.Windows.Forms.Panel panMain;
    internal System.Windows.Forms.Label lblFile;
    private System.Windows.Forms.Panel panAdvanced;
    private System.Windows.Forms.Panel panel1;
  }
}
