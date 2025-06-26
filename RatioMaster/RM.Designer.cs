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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.groupBox6 = new System.Windows.Forms.GroupBox();
      this.groupBox7 = new System.Windows.Forms.GroupBox();
      this.groupBox8 = new System.Windows.Forms.GroupBox();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tabPageMain = new System.Windows.Forms.TabPage();
      this.tabPageAdvanced = new System.Windows.Forms.TabPage();
      this.info.SuspendLayout();
      this.panelControls.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.tabPageMain.SuspendLayout();
      this.tabPageAdvanced.SuspendLayout();
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
      this.btnDefault.TabIndex = 11;
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
      this.RemaningWork.Tick += new System.EventHandler(this.RemaningWork_Tick);
      // 
      // SaveLog
      // 
      this.SaveLog.Filter = "Text file|*.txt";
      this.SaveLog.Title = "Please select text file...";
      // 
      // info
      // 
      this.info.BackColor = System.Drawing.SystemColors.Control;
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
      this.info.Location = new System.Drawing.Point(0, 35);
      this.info.Name = "info";
      this.info.Size = new System.Drawing.Size(489, 22);
      this.info.SizingGrip = false;
      this.info.TabIndex = 12;
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
      this.manualUpdateButton.TabIndex = 10;
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
      this.StartButton.TabIndex = 8;
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
      this.StopButton.TabIndex = 9;
      this.StopButton.Text = "STOP";
      this.StopButton.UseVisualStyleBackColor = false;
      this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
      // 
      // logWindow
      // 
      this.logWindow.BackColor = System.Drawing.Color.Black;
      this.logWindow.Dock = System.Windows.Forms.DockStyle.Fill;
      this.logWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.logWindow.Location = new System.Drawing.Point(0, 289);
      this.logWindow.Name = "logWindow";
      this.logWindow.ReadOnly = true;
      this.logWindow.Size = new System.Drawing.Size(489, 228);
      this.logWindow.TabIndex = 3;
      this.logWindow.Text = "------------------------------------- LOG -------------------------------------\n";
      // 
      // panelControls
      // 
      this.panelControls.Controls.Add(this.StartButton);
      this.panelControls.Controls.Add(this.btnDefault);
      this.panelControls.Controls.Add(this.manualUpdateButton);
      this.panelControls.Controls.Add(this.StopButton);
      this.panelControls.Controls.Add(this.info);
      this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControls.Location = new System.Drawing.Point(0, 517);
      this.panelControls.Margin = new System.Windows.Forms.Padding(2);
      this.panelControls.Name = "panelControls";
      this.panelControls.Size = new System.Drawing.Size(489, 57);
      this.panelControls.TabIndex = 29;
      // 
      // customPeersNum
      // 
      this.customPeersNum.Location = new System.Drawing.Point(422, 22);
      this.customPeersNum.Name = "customPeersNum";
      this.customPeersNum.Size = new System.Drawing.Size(51, 20);
      this.customPeersNum.TabIndex = 34;
      // 
      // lblcustomPeersNum
      // 
      this.lblcustomPeersNum.AutoSize = true;
      this.lblcustomPeersNum.Location = new System.Drawing.Point(328, 25);
      this.lblcustomPeersNum.Name = "lblcustomPeersNum";
      this.lblcustomPeersNum.Size = new System.Drawing.Size(88, 13);
      this.lblcustomPeersNum.TabIndex = 33;
      this.lblcustomPeersNum.Text = "Number of peers:";
      // 
      // lblGenStatus
      // 
      this.lblGenStatus.AutoSize = true;
      this.lblGenStatus.Location = new System.Drawing.Point(142, 71);
      this.lblGenStatus.Name = "lblGenStatus";
      this.lblGenStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.lblGenStatus.Size = new System.Drawing.Size(93, 13);
      this.lblGenStatus.TabIndex = 30;
      this.lblGenStatus.Text = "Generation status:";
      this.lblGenStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // customPort
      // 
      this.customPort.BackColor = System.Drawing.Color.White;
      this.customPort.Location = new System.Drawing.Point(273, 22);
      this.customPort.Name = "customPort";
      this.customPort.Size = new System.Drawing.Size(49, 20);
      this.customPort.TabIndex = 32;
      // 
      // portLabel
      // 
      this.portLabel.AutoSize = true;
      this.portLabel.Location = new System.Drawing.Point(238, 25);
      this.portLabel.Name = "portLabel";
      this.portLabel.Size = new System.Drawing.Size(29, 13);
      this.portLabel.TabIndex = 31;
      this.portLabel.Text = "Port:";
      // 
      // chkNewValues
      // 
      this.chkNewValues.AutoSize = true;
      this.chkNewValues.Checked = true;
      this.chkNewValues.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkNewValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chkNewValues.Location = new System.Drawing.Point(9, 69);
      this.chkNewValues.Name = "chkNewValues";
      this.chkNewValues.Size = new System.Drawing.Size(131, 17);
      this.chkNewValues.TabIndex = 29;
      this.chkNewValues.Text = "Always get new values";
      this.chkNewValues.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 49);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(46, 13);
      this.label4.TabIndex = 27;
      this.label4.Text = "Peer ID:";
      // 
      // customPeerID
      // 
      this.customPeerID.BackColor = System.Drawing.Color.White;
      this.customPeerID.Location = new System.Drawing.Point(69, 46);
      this.customPeerID.Name = "customPeerID";
      this.customPeerID.Size = new System.Drawing.Size(404, 20);
      this.customPeerID.TabIndex = 28;
      // 
      // customKey
      // 
      this.customKey.BackColor = System.Drawing.Color.White;
      this.customKey.Location = new System.Drawing.Point(69, 22);
      this.customKey.Name = "customKey";
      this.customKey.Size = new System.Drawing.Size(163, 20);
      this.customKey.TabIndex = 26;
      // 
      // keyLabel
      // 
      this.keyLabel.AutoSize = true;
      this.keyLabel.Location = new System.Drawing.Point(6, 25);
      this.keyLabel.Name = "keyLabel";
      this.keyLabel.Size = new System.Drawing.Size(57, 13);
      this.keyLabel.TabIndex = 25;
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
      this.comboProxyType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
      this.checkIgnoreFailureReason.Location = new System.Drawing.Point(214, 20);
      this.checkIgnoreFailureReason.Name = "checkIgnoreFailureReason";
      this.checkIgnoreFailureReason.Size = new System.Drawing.Size(123, 17);
      this.checkIgnoreFailureReason.TabIndex = 2;
      this.checkIgnoreFailureReason.Text = "Ignore \'failure reason\'";
      this.checkIgnoreFailureReason.UseVisualStyleBackColor = true;
      // 
      // checkRequestScrap
      // 
      this.checkRequestScrap.AutoSize = true;
      this.checkRequestScrap.Checked = true;
      this.checkRequestScrap.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkRequestScrap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.checkRequestScrap.Location = new System.Drawing.Point(114, 19);
      this.checkRequestScrap.Name = "checkRequestScrap";
      this.checkRequestScrap.Size = new System.Drawing.Size(94, 17);
      this.checkRequestScrap.TabIndex = 1;
      this.checkRequestScrap.Text = "Request Scrap";
      this.checkRequestScrap.UseVisualStyleBackColor = true;
      // 
      // checkTCPListen
      // 
      this.checkTCPListen.AutoSize = true;
      this.checkTCPListen.Checked = true;
      this.checkTCPListen.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkTCPListen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.checkTCPListen.Location = new System.Drawing.Point(6, 19);
      this.checkTCPListen.Name = "checkTCPListen";
      this.checkTCPListen.Size = new System.Drawing.Size(102, 17);
      this.checkTCPListen.TabIndex = 0;
      this.checkTCPListen.Text = "Use TCP listener";
      this.checkTCPListen.UseVisualStyleBackColor = true;
      // 
      // RandomDownloadTo
      // 
      this.RandomDownloadTo.BackColor = System.Drawing.Color.White;
      this.RandomDownloadTo.Location = new System.Drawing.Point(419, 27);
      this.RandomDownloadTo.Name = "RandomDownloadTo";
      this.RandomDownloadTo.Size = new System.Drawing.Size(37, 20);
      this.RandomDownloadTo.TabIndex = 9;
      this.RandomDownloadTo.Text = "50";
      // 
      // RandomDownloadFrom
      // 
      this.RandomDownloadFrom.BackColor = System.Drawing.Color.White;
      this.RandomDownloadFrom.Location = new System.Drawing.Point(340, 27);
      this.RandomDownloadFrom.Name = "RandomDownloadFrom";
      this.RandomDownloadFrom.Size = new System.Drawing.Size(37, 20);
      this.RandomDownloadFrom.TabIndex = 7;
      this.RandomDownloadFrom.Text = "10";
      // 
      // checkRandomUpload
      // 
      this.checkRandomUpload.AutoSize = true;
      this.checkRandomUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.checkRandomUpload.Location = new System.Drawing.Point(9, 28);
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
      this.checkRandomDownload.Location = new System.Drawing.Point(227, 28);
      this.checkRandomDownload.Name = "checkRandomDownload";
      this.checkRandomDownload.Size = new System.Drawing.Size(74, 17);
      this.checkRandomDownload.TabIndex = 5;
      this.checkRandomDownload.Text = "Download:";
      this.checkRandomDownload.UseVisualStyleBackColor = true;
      // 
      // lblRandomUploadFrom
      // 
      this.lblRandomUploadFrom.AutoSize = true;
      this.lblRandomUploadFrom.Location = new System.Drawing.Point(72, 30);
      this.lblRandomUploadFrom.Name = "lblRandomUploadFrom";
      this.lblRandomUploadFrom.Size = new System.Drawing.Size(27, 13);
      this.lblRandomUploadFrom.TabIndex = 1;
      this.lblRandomUploadFrom.Text = "Min:";
      // 
      // RandomUploadTo
      // 
      this.RandomUploadTo.BackColor = System.Drawing.Color.White;
      this.RandomUploadTo.Location = new System.Drawing.Point(184, 27);
      this.RandomUploadTo.Name = "RandomUploadTo";
      this.RandomUploadTo.Size = new System.Drawing.Size(37, 20);
      this.RandomUploadTo.TabIndex = 4;
      this.RandomUploadTo.Text = "100";
      // 
      // lblRandomUploadTo
      // 
      this.lblRandomUploadTo.AutoSize = true;
      this.lblRandomUploadTo.Location = new System.Drawing.Point(148, 30);
      this.lblRandomUploadTo.Name = "lblRandomUploadTo";
      this.lblRandomUploadTo.Size = new System.Drawing.Size(30, 13);
      this.lblRandomUploadTo.TabIndex = 3;
      this.lblRandomUploadTo.Text = "Max:";
      // 
      // lblRandomDownloadFrom
      // 
      this.lblRandomDownloadFrom.AutoSize = true;
      this.lblRandomDownloadFrom.Location = new System.Drawing.Point(307, 30);
      this.lblRandomDownloadFrom.Name = "lblRandomDownloadFrom";
      this.lblRandomDownloadFrom.Size = new System.Drawing.Size(27, 13);
      this.lblRandomDownloadFrom.TabIndex = 6;
      this.lblRandomDownloadFrom.Text = "Min:";
      // 
      // RandomUploadFrom
      // 
      this.RandomUploadFrom.BackColor = System.Drawing.Color.White;
      this.RandomUploadFrom.Location = new System.Drawing.Point(105, 27);
      this.RandomUploadFrom.Name = "RandomUploadFrom";
      this.RandomUploadFrom.Size = new System.Drawing.Size(37, 20);
      this.RandomUploadFrom.TabIndex = 2;
      this.RandomUploadFrom.Text = "50";
      // 
      // lblRandomDownloadTo
      // 
      this.lblRandomDownloadTo.AutoSize = true;
      this.lblRandomDownloadTo.Location = new System.Drawing.Point(383, 30);
      this.lblRandomDownloadTo.Name = "lblRandomDownloadTo";
      this.lblRandomDownloadTo.Size = new System.Drawing.Size(30, 13);
      this.lblRandomDownloadTo.TabIndex = 8;
      this.lblRandomDownloadTo.Text = "Max:";
      // 
      // lblStopAfter
      // 
      this.lblStopAfter.AutoSize = true;
      this.lblStopAfter.Location = new System.Drawing.Point(399, 49);
      this.lblStopAfter.Name = "lblStopAfter";
      this.lblStopAfter.Size = new System.Drawing.Size(25, 13);
      this.lblStopAfter.TabIndex = 26;
      this.lblStopAfter.Text = "???";
      // 
      // cmbStopAfter
      // 
      this.cmbStopAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbStopAfter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbStopAfter.FormattingEnabled = true;
      this.cmbStopAfter.Items.AddRange(new object[] {
            "Never",
            "After time:",
            "When seeders <",
            "When leechers <",
            "When uploaded >",
            "When downloaded >",
            "When leechers/seeders <"});
      this.cmbStopAfter.Location = new System.Drawing.Point(177, 46);
      this.cmbStopAfter.Name = "cmbStopAfter";
      this.cmbStopAfter.Size = new System.Drawing.Size(151, 21);
      this.cmbStopAfter.TabIndex = 25;
      this.cmbStopAfter.SelectedIndexChanged += new System.EventHandler(this.cmbStopAfter_SelectedIndexChanged);
      // 
      // txtStopValue
      // 
      this.txtStopValue.BackColor = System.Drawing.Color.White;
      this.txtStopValue.Location = new System.Drawing.Point(334, 46);
      this.txtStopValue.Name = "txtStopValue";
      this.txtStopValue.Size = new System.Drawing.Size(59, 20);
      this.txtStopValue.TabIndex = 24;
      this.txtStopValue.Text = "0";
      // 
      // intervalLabel
      // 
      this.intervalLabel.AutoSize = true;
      this.intervalLabel.Location = new System.Drawing.Point(6, 25);
      this.intervalLabel.Name = "intervalLabel";
      this.intervalLabel.Size = new System.Drawing.Size(97, 13);
      this.intervalLabel.TabIndex = 14;
      this.intervalLabel.Text = "Update Interval (s):";
      // 
      // lblRemWork
      // 
      this.lblRemWork.AutoSize = true;
      this.lblRemWork.Location = new System.Drawing.Point(132, 49);
      this.lblRemWork.Name = "lblRemWork";
      this.lblRemWork.Size = new System.Drawing.Size(39, 13);
      this.lblRemWork.TabIndex = 23;
      this.lblRemWork.Text = "STOP:";
      // 
      // fileSize
      // 
      this.fileSize.BackColor = System.Drawing.Color.White;
      this.fileSize.Location = new System.Drawing.Point(78, 46);
      this.fileSize.MaxLength = 5;
      this.fileSize.Name = "fileSize";
      this.fileSize.Size = new System.Drawing.Size(48, 20);
      this.fileSize.TabIndex = 20;
      this.fileSize.Text = "0";
      // 
      // cmbVersion
      // 
      this.cmbVersion.BackColor = System.Drawing.Color.White;
      this.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbVersion.FormattingEnabled = true;
      this.cmbVersion.Location = new System.Drawing.Point(345, 21);
      this.cmbVersion.Name = "cmbVersion";
      this.cmbVersion.Size = new System.Drawing.Size(128, 21);
      this.cmbVersion.TabIndex = 18;
      this.cmbVersion.SelectedValueChanged += new System.EventHandler(this.cmbVersion_SelectedValueChanged);
      // 
      // FileSizeLabel
      // 
      this.FileSizeLabel.AutoSize = true;
      this.FileSizeLabel.Location = new System.Drawing.Point(6, 49);
      this.FileSizeLabel.Name = "FileSizeLabel";
      this.FileSizeLabel.Size = new System.Drawing.Size(66, 13);
      this.FileSizeLabel.TabIndex = 19;
      this.FileSizeLabel.Text = "Finished (%):";
      // 
      // cmbClient
      // 
      this.cmbClient.BackColor = System.Drawing.Color.White;
      this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
      this.cmbClient.Location = new System.Drawing.Point(200, 21);
      this.cmbClient.Name = "cmbClient";
      this.cmbClient.Size = new System.Drawing.Size(139, 21);
      this.cmbClient.TabIndex = 17;
      this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
      // 
      // interval
      // 
      this.interval.BackColor = System.Drawing.Color.White;
      this.interval.Location = new System.Drawing.Point(109, 22);
      this.interval.Name = "interval";
      this.interval.Size = new System.Drawing.Size(43, 20);
      this.interval.TabIndex = 15;
      this.interval.Text = "1800";
      // 
      // ClientLabel
      // 
      this.ClientLabel.AutoSize = true;
      this.ClientLabel.Location = new System.Drawing.Point(158, 25);
      this.ClientLabel.Name = "ClientLabel";
      this.ClientLabel.Size = new System.Drawing.Size(36, 13);
      this.ClientLabel.TabIndex = 16;
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
      this.txtTorrentSize.Location = new System.Drawing.Point(399, 43);
      this.txtTorrentSize.Name = "txtTorrentSize";
      this.txtTorrentSize.ReadOnly = true;
      this.txtTorrentSize.Size = new System.Drawing.Size(71, 20);
      this.txtTorrentSize.TabIndex = 5;
      // 
      // trackerAddress
      // 
      this.trackerAddress.BackColor = System.Drawing.Color.White;
      this.trackerAddress.Location = new System.Drawing.Point(56, 19);
      this.trackerAddress.Name = "trackerAddress";
      this.trackerAddress.Size = new System.Drawing.Size(414, 20);
      this.trackerAddress.TabIndex = 1;
      // 
      // lblTorrentSize
      // 
      this.lblTorrentSize.AutoSize = true;
      this.lblTorrentSize.Location = new System.Drawing.Point(363, 46);
      this.lblTorrentSize.Name = "lblTorrentSize";
      this.lblTorrentSize.Size = new System.Drawing.Size(30, 13);
      this.lblTorrentSize.TabIndex = 4;
      this.lblTorrentSize.Text = "Size:";
      // 
      // TrackerLabel
      // 
      this.TrackerLabel.AutoSize = true;
      this.TrackerLabel.Location = new System.Drawing.Point(3, 22);
      this.TrackerLabel.Name = "TrackerLabel";
      this.TrackerLabel.Size = new System.Drawing.Size(47, 13);
      this.TrackerLabel.TabIndex = 0;
      this.TrackerLabel.Text = "Tracker:";
      // 
      // shaHash
      // 
      this.shaHash.Location = new System.Drawing.Point(56, 43);
      this.shaHash.Name = "shaHash";
      this.shaHash.ReadOnly = true;
      this.shaHash.Size = new System.Drawing.Size(301, 20);
      this.shaHash.TabIndex = 3;
      // 
      // hashLabel
      // 
      this.hashLabel.AutoSize = true;
      this.hashLabel.Location = new System.Drawing.Point(3, 46);
      this.hashLabel.Name = "hashLabel";
      this.hashLabel.Size = new System.Drawing.Size(40, 13);
      this.hashLabel.TabIndex = 2;
      this.hashLabel.Text = "HASH:\r\n";
      // 
      // browseButton
      // 
      this.browseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.browseButton.Cursor = System.Windows.Forms.Cursors.Hand;
      this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.browseButton.Location = new System.Drawing.Point(399, 17);
      this.browseButton.Name = "browseButton";
      this.browseButton.Size = new System.Drawing.Size(71, 24);
      this.browseButton.TabIndex = 1;
      this.browseButton.Text = "Browse...";
      this.browseButton.UseVisualStyleBackColor = false;
      this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
      // 
      // torrentFile
      // 
      this.torrentFile.BackColor = System.Drawing.Color.White;
      this.torrentFile.Location = new System.Drawing.Point(6, 19);
      this.torrentFile.Name = "torrentFile";
      this.torrentFile.ReadOnly = true;
      this.torrentFile.Size = new System.Drawing.Size(387, 20);
      this.torrentFile.TabIndex = 0;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.browseButton);
      this.groupBox1.Controls.Add(this.torrentFile);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(475, 46);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Torrent File";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txtTorrentSize);
      this.groupBox2.Controls.Add(this.TrackerLabel);
      this.groupBox2.Controls.Add(this.trackerAddress);
      this.groupBox2.Controls.Add(this.hashLabel);
      this.groupBox2.Controls.Add(this.lblTorrentSize);
      this.groupBox2.Controls.Add(this.shaHash);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox2.Location = new System.Drawing.Point(3, 49);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(475, 70);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Torrent Info";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.uploadRateLabel);
      this.groupBox3.Controls.Add(this.uploadRate);
      this.groupBox3.Controls.Add(this.lblUpMax);
      this.groupBox3.Controls.Add(this.txtRandDownMax);
      this.groupBox3.Controls.Add(this.lblDownMin);
      this.groupBox3.Controls.Add(this.downloadRateLabel);
      this.groupBox3.Controls.Add(this.lblUpMin);
      this.groupBox3.Controls.Add(this.txtRandUpMax);
      this.groupBox3.Controls.Add(this.lblDownMax);
      this.groupBox3.Controls.Add(this.downloadRate);
      this.groupBox3.Controls.Add(this.chkRandDown);
      this.groupBox3.Controls.Add(this.txtRandDownMin);
      this.groupBox3.Controls.Add(this.txtRandUpMin);
      this.groupBox3.Controls.Add(this.chkRandUP);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox3.Location = new System.Drawing.Point(3, 119);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(475, 70);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Speed Options";
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.lblStopAfter);
      this.groupBox4.Controls.Add(this.intervalLabel);
      this.groupBox4.Controls.Add(this.cmbStopAfter);
      this.groupBox4.Controls.Add(this.ClientLabel);
      this.groupBox4.Controls.Add(this.txtStopValue);
      this.groupBox4.Controls.Add(this.interval);
      this.groupBox4.Controls.Add(this.cmbClient);
      this.groupBox4.Controls.Add(this.lblRemWork);
      this.groupBox4.Controls.Add(this.FileSizeLabel);
      this.groupBox4.Controls.Add(this.fileSize);
      this.groupBox4.Controls.Add(this.cmbVersion);
      this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox4.Location = new System.Drawing.Point(3, 189);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(475, 70);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Options";
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.RandomDownloadTo);
      this.groupBox5.Controls.Add(this.checkRandomUpload);
      this.groupBox5.Controls.Add(this.RandomDownloadFrom);
      this.groupBox5.Controls.Add(this.lblRandomDownloadTo);
      this.groupBox5.Controls.Add(this.RandomUploadFrom);
      this.groupBox5.Controls.Add(this.checkRandomDownload);
      this.groupBox5.Controls.Add(this.lblRandomDownloadFrom);
      this.groupBox5.Controls.Add(this.lblRandomUploadFrom);
      this.groupBox5.Controls.Add(this.lblRandomUploadTo);
      this.groupBox5.Controls.Add(this.RandomUploadTo);
      this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox5.Location = new System.Drawing.Point(3, 3);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(475, 58);
      this.groupBox5.TabIndex = 4;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "On Next Update Get Random Speeds";
      // 
      // groupBox6
      // 
      this.groupBox6.Controls.Add(this.checkIgnoreFailureReason);
      this.groupBox6.Controls.Add(this.checkTCPListen);
      this.groupBox6.Controls.Add(this.checkRequestScrap);
      this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox6.Location = new System.Drawing.Point(3, 61);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new System.Drawing.Size(475, 40);
      this.groupBox6.TabIndex = 5;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Other Settings";
      // 
      // groupBox7
      // 
      this.groupBox7.Controls.Add(this.labelProxyType);
      this.groupBox7.Controls.Add(this.labelProxyHost);
      this.groupBox7.Controls.Add(this.textProxyUser);
      this.groupBox7.Controls.Add(this.textProxyPass);
      this.groupBox7.Controls.Add(this.labelProxyPass);
      this.groupBox7.Controls.Add(this.comboProxyType);
      this.groupBox7.Controls.Add(this.labelProxyPort);
      this.groupBox7.Controls.Add(this.textProxyHost);
      this.groupBox7.Controls.Add(this.textProxyPort);
      this.groupBox7.Controls.Add(this.labelProxyUser);
      this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox7.Location = new System.Drawing.Point(3, 101);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new System.Drawing.Size(475, 70);
      this.groupBox7.TabIndex = 6;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Proxy Server Settings";
      // 
      // groupBox8
      // 
      this.groupBox8.Controls.Add(this.customPeersNum);
      this.groupBox8.Controls.Add(this.keyLabel);
      this.groupBox8.Controls.Add(this.lblcustomPeersNum);
      this.groupBox8.Controls.Add(this.customKey);
      this.groupBox8.Controls.Add(this.lblGenStatus);
      this.groupBox8.Controls.Add(this.customPeerID);
      this.groupBox8.Controls.Add(this.customPort);
      this.groupBox8.Controls.Add(this.label4);
      this.groupBox8.Controls.Add(this.portLabel);
      this.groupBox8.Controls.Add(this.chkNewValues);
      this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox8.Location = new System.Drawing.Point(3, 171);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new System.Drawing.Size(475, 89);
      this.groupBox8.TabIndex = 7;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "Custom Client Simulation";
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tabPageMain);
      this.tabControl.Controls.Add(this.tabPageAdvanced);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(489, 289);
      this.tabControl.TabIndex = 31;
      // 
      // tabPageMain
      // 
      this.tabPageMain.Controls.Add(this.groupBox4);
      this.tabPageMain.Controls.Add(this.groupBox3);
      this.tabPageMain.Controls.Add(this.groupBox2);
      this.tabPageMain.Controls.Add(this.groupBox1);
      this.tabPageMain.Location = new System.Drawing.Point(4, 22);
      this.tabPageMain.Name = "tabPageMain";
      this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageMain.Size = new System.Drawing.Size(481, 263);
      this.tabPageMain.TabIndex = 0;
      this.tabPageMain.Text = "Main";
      this.tabPageMain.UseVisualStyleBackColor = true;
      // 
      // tabPageAdvanced
      // 
      this.tabPageAdvanced.Controls.Add(this.groupBox8);
      this.tabPageAdvanced.Controls.Add(this.groupBox7);
      this.tabPageAdvanced.Controls.Add(this.groupBox6);
      this.tabPageAdvanced.Controls.Add(this.groupBox5);
      this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
      this.tabPageAdvanced.Name = "tabPageAdvanced";
      this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageAdvanced.Size = new System.Drawing.Size(481, 263);
      this.tabPageAdvanced.TabIndex = 1;
      this.tabPageAdvanced.Text = "Advanced";
      this.tabPageAdvanced.UseVisualStyleBackColor = true;
      // 
      // RM
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.logWindow);
      this.Controls.Add(this.tabControl);
      this.Controls.Add(this.panelControls);
      this.Name = "RM";
      this.Size = new System.Drawing.Size(489, 574);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
      this.info.ResumeLayout(false);
      this.info.PerformLayout();
      this.panelControls.ResumeLayout(false);
      this.panelControls.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.groupBox8.ResumeLayout(false);
      this.groupBox8.PerformLayout();
      this.tabControl.ResumeLayout(false);
      this.tabPageMain.ResumeLayout(false);
      this.tabPageAdvanced.ResumeLayout(false);
      this.ResumeLayout(false);

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
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.GroupBox groupBox7;
    private System.Windows.Forms.GroupBox groupBox8;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabPageMain;
    private System.Windows.Forms.TabPage tabPageAdvanced;
  }
}
