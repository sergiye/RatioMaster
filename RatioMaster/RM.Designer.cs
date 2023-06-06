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
            this.magneticPanelNextSpeed = new RatioMaster.MagneticPanel();
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
            this.logWindow = new System.Windows.Forms.RichTextBox();
            this.magneticPanelSimulation = new RatioMaster.MagneticPanel();
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
            this.magneticPanelOptions = new RatioMaster.MagneticPanel();
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
            this.magneticPanelSpeed = new RatioMaster.MagneticPanel();
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
            this.magneticPanelInfo = new RatioMaster.MagneticPanel();
            this.txtTorrentSize = new System.Windows.Forms.TextBox();
            this.trackerAddress = new System.Windows.Forms.TextBox();
            this.lblTorrentSize = new System.Windows.Forms.Label();
            this.TrackerLabel = new System.Windows.Forms.Label();
            this.shaHash = new System.Windows.Forms.TextBox();
            this.hashLabel = new System.Windows.Forms.Label();
            this.magneticPanelProxy = new RatioMaster.MagneticPanel();
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
            this.magneticPanelOther = new RatioMaster.MagneticPanel();
            this.checkIgnoreFailureReason = new System.Windows.Forms.CheckBox();
            this.checkRequestScrap = new System.Windows.Forms.CheckBox();
            this.checkTCPListen = new System.Windows.Forms.CheckBox();
            this.magneticPanelFile = new RatioMaster.MagneticPanel();
            this.browseButton = new System.Windows.Forms.Button();
            this.torrentFile = new System.Windows.Forms.TextBox();
            this.panelControls = new System.Windows.Forms.Panel();
            this.info.SuspendLayout();
            this.magneticPanelNextSpeed.SuspendLayout();
            this.magneticPanelSimulation.SuspendLayout();
            this.magneticPanelOptions.SuspendLayout();
            this.magneticPanelSpeed.SuspendLayout();
            this.magneticPanelInfo.SuspendLayout();
            this.magneticPanelProxy.SuspendLayout();
            this.magneticPanelOther.SuspendLayout();
            this.magneticPanelFile.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDefault
            // 
            this.btnDefault.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (255)))), ((int) (((byte) (255)))));
            this.btnDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.btnDefault.Location = new System.Drawing.Point(526, 6);
            this.btnDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(180, 52);
            this.btnDefault.TabIndex = 11;
            this.btnDefault.Text = "Set default values";
            this.btnDefault.UseVisualStyleBackColor = false;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // txtRemTime
            // 
            this.txtRemTime.Name = "txtRemTime";
            this.txtRemTime.Size = new System.Drawing.Size(22, 25);
            this.txtRemTime.Text = "0";
            // 
            // lblUpdateIn
            // 
            this.lblUpdateIn.Name = "lblUpdateIn";
            this.lblUpdateIn.Size = new System.Drawing.Size(93, 25);
            this.lblUpdateIn.Text = "Update in:";
            // 
            // timerValue
            // 
            this.timerValue.Name = "timerValue";
            this.timerValue.Size = new System.Drawing.Size(22, 25);
            this.timerValue.Text = "0";
            // 
            // lblRemTime
            // 
            this.lblRemTime.Name = "lblRemTime";
            this.lblRemTime.Size = new System.Drawing.Size(95, 25);
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
            this.info.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.lblUpdateIn, this.timerValue, this.uploadCountLabel, this.uploadCount, this.downloadCountLabel, this.downloadCount, this.lableTorrentRatio, this.lblTorrentRatio, this.seedLabel, this.leechLabel, this.lblTotalTimeCap, this.lblTotalTime, this.lblRemTime, this.txtRemTime});
            this.info.Location = new System.Drawing.Point(0, 58);
            this.info.Name = "info";
            this.info.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.info.Size = new System.Drawing.Size(713, 30);
            this.info.SizingGrip = false;
            this.info.TabIndex = 12;
            // 
            // uploadCountLabel
            // 
            this.uploadCountLabel.Name = "uploadCountLabel";
            this.uploadCountLabel.Size = new System.Drawing.Size(35, 25);
            this.uploadCountLabel.Text = "Up";
            // 
            // uploadCount
            // 
            this.uploadCount.Name = "uploadCount";
            this.uploadCount.Size = new System.Drawing.Size(22, 25);
            this.uploadCount.Text = "0";
            // 
            // downloadCountLabel
            // 
            this.downloadCountLabel.Name = "downloadCountLabel";
            this.downloadCountLabel.Size = new System.Drawing.Size(59, 25);
            this.downloadCountLabel.Text = "Down";
            // 
            // downloadCount
            // 
            this.downloadCount.Name = "downloadCount";
            this.downloadCount.Size = new System.Drawing.Size(22, 25);
            this.downloadCount.Text = "0";
            // 
            // lableTorrentRatio
            // 
            this.lableTorrentRatio.Name = "lableTorrentRatio";
            this.lableTorrentRatio.Size = new System.Drawing.Size(57, 25);
            this.lableTorrentRatio.Text = "Ratio:";
            // 
            // lblTorrentRatio
            // 
            this.lblTorrentRatio.Name = "lblTorrentRatio";
            this.lblTorrentRatio.Size = new System.Drawing.Size(36, 25);
            this.lblTorrentRatio.Text = "0.0";
            // 
            // seedLabel
            // 
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(78, 25);
            this.seedLabel.Text = "Seeds: 0";
            // 
            // leechLabel
            // 
            this.leechLabel.Name = "leechLabel";
            this.leechLabel.Size = new System.Drawing.Size(72, 25);
            this.leechLabel.Text = "Peers: 0";
            // 
            // lblTotalTimeCap
            // 
            this.lblTotalTimeCap.Name = "lblTotalTimeCap";
            this.lblTotalTimeCap.Size = new System.Drawing.Size(54, 25);
            this.lblTotalTimeCap.Text = "Time:";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(56, 25);
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
            this.manualUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.manualUpdateButton.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (0)))), ((int) (((byte) (64)))));
            this.manualUpdateButton.Location = new System.Drawing.Point(352, 6);
            this.manualUpdateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.manualUpdateButton.Name = "manualUpdateButton";
            this.manualUpdateButton.Size = new System.Drawing.Size(165, 52);
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
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.StartButton.ForeColor = System.Drawing.Color.Blue;
            this.StartButton.Location = new System.Drawing.Point(4, 6);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(165, 52);
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
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.StopButton.ForeColor = System.Drawing.Color.Red;
            this.StopButton.Location = new System.Drawing.Point(178, 6);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(165, 52);
            this.StopButton.TabIndex = 9;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // magneticPanelNextSpeed
            // 
            this.magneticPanelNextSpeed.BevelStyle = RatioMaster.BevelStyles.Flat;
            this.magneticPanelNextSpeed.Controls.Add(this.RandomDownloadTo);
            this.magneticPanelNextSpeed.Controls.Add(this.RandomDownloadFrom);
            this.magneticPanelNextSpeed.Controls.Add(this.checkRandomUpload);
            this.magneticPanelNextSpeed.Controls.Add(this.checkRandomDownload);
            this.magneticPanelNextSpeed.Controls.Add(this.lblRandomUploadFrom);
            this.magneticPanelNextSpeed.Controls.Add(this.RandomUploadTo);
            this.magneticPanelNextSpeed.Controls.Add(this.lblRandomUploadTo);
            this.magneticPanelNextSpeed.Controls.Add(this.lblRandomDownloadFrom);
            this.magneticPanelNextSpeed.Controls.Add(this.RandomUploadFrom);
            this.magneticPanelNextSpeed.Controls.Add(this.lblRandomDownloadTo);
            this.magneticPanelNextSpeed.Dock = System.Windows.Forms.DockStyle.Top;
            this.magneticPanelNextSpeed.ExpandSize = new System.Drawing.Size(713, 89);
            this.magneticPanelNextSpeed.Location = new System.Drawing.Point(0, 395);
            this.magneticPanelNextSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.magneticPanelNextSpeed.Name = "magneticPanelNextSpeed";
            this.magneticPanelNextSpeed.Size = new System.Drawing.Size(713, 89);
            this.magneticPanelNextSpeed.TabIndex = 28;
            this.magneticPanelNextSpeed.Text = "On Next Update Get Random Speeds";
            // 
            // RandomDownloadTo
            // 
            this.RandomDownloadTo.BackColor = System.Drawing.Color.White;
            this.RandomDownloadTo.Location = new System.Drawing.Point(626, 43);
            this.RandomDownloadTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RandomDownloadTo.Name = "RandomDownloadTo";
            this.RandomDownloadTo.Size = new System.Drawing.Size(54, 26);
            this.RandomDownloadTo.TabIndex = 9;
            this.RandomDownloadTo.Text = "50";
            // 
            // RandomDownloadFrom
            // 
            this.RandomDownloadFrom.BackColor = System.Drawing.Color.White;
            this.RandomDownloadFrom.Location = new System.Drawing.Point(507, 43);
            this.RandomDownloadFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RandomDownloadFrom.Name = "RandomDownloadFrom";
            this.RandomDownloadFrom.Size = new System.Drawing.Size(54, 26);
            this.RandomDownloadFrom.TabIndex = 7;
            this.RandomDownloadFrom.Text = "10";
            // 
            // checkRandomUpload
            // 
            this.checkRandomUpload.AutoSize = true;
            this.checkRandomUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkRandomUpload.Location = new System.Drawing.Point(10, 45);
            this.checkRandomUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkRandomUpload.Name = "checkRandomUpload";
            this.checkRandomUpload.Size = new System.Drawing.Size(81, 24);
            this.checkRandomUpload.TabIndex = 0;
            this.checkRandomUpload.Text = "Upload";
            this.checkRandomUpload.UseVisualStyleBackColor = true;
            // 
            // checkRandomDownload
            // 
            this.checkRandomDownload.AutoSize = true;
            this.checkRandomDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkRandomDownload.Location = new System.Drawing.Point(338, 45);
            this.checkRandomDownload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkRandomDownload.Name = "checkRandomDownload";
            this.checkRandomDownload.Size = new System.Drawing.Size(105, 24);
            this.checkRandomDownload.TabIndex = 5;
            this.checkRandomDownload.Text = "Download:";
            this.checkRandomDownload.UseVisualStyleBackColor = true;
            // 
            // lblRandomUploadFrom
            // 
            this.lblRandomUploadFrom.AutoSize = true;
            this.lblRandomUploadFrom.Location = new System.Drawing.Point(105, 48);
            this.lblRandomUploadFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandomUploadFrom.Name = "lblRandomUploadFrom";
            this.lblRandomUploadFrom.Size = new System.Drawing.Size(38, 20);
            this.lblRandomUploadFrom.TabIndex = 1;
            this.lblRandomUploadFrom.Text = "Min:";
            // 
            // RandomUploadTo
            // 
            this.RandomUploadTo.BackColor = System.Drawing.Color.White;
            this.RandomUploadTo.Location = new System.Drawing.Point(273, 43);
            this.RandomUploadTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RandomUploadTo.Name = "RandomUploadTo";
            this.RandomUploadTo.Size = new System.Drawing.Size(54, 26);
            this.RandomUploadTo.TabIndex = 4;
            this.RandomUploadTo.Text = "100";
            // 
            // lblRandomUploadTo
            // 
            this.lblRandomUploadTo.AutoSize = true;
            this.lblRandomUploadTo.Location = new System.Drawing.Point(219, 48);
            this.lblRandomUploadTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandomUploadTo.Name = "lblRandomUploadTo";
            this.lblRandomUploadTo.Size = new System.Drawing.Size(42, 20);
            this.lblRandomUploadTo.TabIndex = 3;
            this.lblRandomUploadTo.Text = "Max:";
            // 
            // lblRandomDownloadFrom
            // 
            this.lblRandomDownloadFrom.AutoSize = true;
            this.lblRandomDownloadFrom.Location = new System.Drawing.Point(458, 48);
            this.lblRandomDownloadFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandomDownloadFrom.Name = "lblRandomDownloadFrom";
            this.lblRandomDownloadFrom.Size = new System.Drawing.Size(38, 20);
            this.lblRandomDownloadFrom.TabIndex = 6;
            this.lblRandomDownloadFrom.Text = "Min:";
            // 
            // RandomUploadFrom
            // 
            this.RandomUploadFrom.BackColor = System.Drawing.Color.White;
            this.RandomUploadFrom.Location = new System.Drawing.Point(154, 43);
            this.RandomUploadFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RandomUploadFrom.Name = "RandomUploadFrom";
            this.RandomUploadFrom.Size = new System.Drawing.Size(54, 26);
            this.RandomUploadFrom.TabIndex = 2;
            this.RandomUploadFrom.Text = "50";
            // 
            // lblRandomDownloadTo
            // 
            this.lblRandomDownloadTo.AutoSize = true;
            this.lblRandomDownloadTo.Location = new System.Drawing.Point(572, 48);
            this.lblRandomDownloadTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandomDownloadTo.Name = "lblRandomDownloadTo";
            this.lblRandomDownloadTo.Size = new System.Drawing.Size(42, 20);
            this.lblRandomDownloadTo.TabIndex = 8;
            this.lblRandomDownloadTo.Text = "Max:";
            // 
            // logWindow
            // 
            this.logWindow.BackColor = System.Drawing.Color.Black;
            this.logWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logWindow.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
            this.logWindow.Location = new System.Drawing.Point(0, 791);
            this.logWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logWindow.Name = "logWindow";
            this.logWindow.ReadOnly = true;
            this.logWindow.Size = new System.Drawing.Size(713, 108);
            this.logWindow.TabIndex = 3;
            this.logWindow.Text = "------------------------------------- LOG -------------------------------------\n";
            // 
            // magneticPanelSimulation
            // 
            this.magneticPanelSimulation.BevelStyle = RatioMaster.BevelStyles.Flat;
            this.magneticPanelSimulation.Controls.Add(this.customPeersNum);
            this.magneticPanelSimulation.Controls.Add(this.lblcustomPeersNum);
            this.magneticPanelSimulation.Controls.Add(this.lblGenStatus);
            this.magneticPanelSimulation.Controls.Add(this.customPort);
            this.magneticPanelSimulation.Controls.Add(this.portLabel);
            this.magneticPanelSimulation.Controls.Add(this.chkNewValues);
            this.magneticPanelSimulation.Controls.Add(this.label4);
            this.magneticPanelSimulation.Controls.Add(this.customPeerID);
            this.magneticPanelSimulation.Controls.Add(this.customKey);
            this.magneticPanelSimulation.Controls.Add(this.keyLabel);
            this.magneticPanelSimulation.Dock = System.Windows.Forms.DockStyle.Top;
            this.magneticPanelSimulation.ExpandSize = new System.Drawing.Size(713, 137);
            this.magneticPanelSimulation.Location = new System.Drawing.Point(0, 654);
            this.magneticPanelSimulation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.magneticPanelSimulation.Name = "magneticPanelSimulation";
            this.magneticPanelSimulation.Size = new System.Drawing.Size(713, 137);
            this.magneticPanelSimulation.TabIndex = 26;
            this.magneticPanelSimulation.Text = "Custom Client Simulation";
            // 
            // customPeersNum
            // 
            this.customPeersNum.Location = new System.Drawing.Point(628, 32);
            this.customPeersNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.customPeersNum.Name = "customPeersNum";
            this.customPeersNum.Size = new System.Drawing.Size(74, 26);
            this.customPeersNum.TabIndex = 34;
            // 
            // lblcustomPeersNum
            // 
            this.lblcustomPeersNum.AutoSize = true;
            this.lblcustomPeersNum.Location = new System.Drawing.Point(488, 37);
            this.lblcustomPeersNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcustomPeersNum.Name = "lblcustomPeersNum";
            this.lblcustomPeersNum.Size = new System.Drawing.Size(131, 20);
            this.lblcustomPeersNum.TabIndex = 33;
            this.lblcustomPeersNum.Text = "Number of peers:";
            // 
            // lblGenStatus
            // 
            this.lblGenStatus.AutoSize = true;
            this.lblGenStatus.Location = new System.Drawing.Point(208, 108);
            this.lblGenStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenStatus.Name = "lblGenStatus";
            this.lblGenStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGenStatus.Size = new System.Drawing.Size(141, 20);
            this.lblGenStatus.TabIndex = 30;
            this.lblGenStatus.Text = "Generation status:";
            this.lblGenStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // customPort
            // 
            this.customPort.BackColor = System.Drawing.Color.White;
            this.customPort.Location = new System.Drawing.Point(405, 32);
            this.customPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.customPort.Name = "customPort";
            this.customPort.Size = new System.Drawing.Size(72, 26);
            this.customPort.TabIndex = 32;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(352, 37);
            this.portLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(42, 20);
            this.portLabel.TabIndex = 31;
            this.portLabel.Text = "Port:";
            // 
            // chkNewValues
            // 
            this.chkNewValues.AutoSize = true;
            this.chkNewValues.Checked = true;
            this.chkNewValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNewValues.Location = new System.Drawing.Point(9, 105);
            this.chkNewValues.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkNewValues.Name = "chkNewValues";
            this.chkNewValues.Size = new System.Drawing.Size(188, 24);
            this.chkNewValues.TabIndex = 29;
            this.chkNewValues.Text = "Always get new values";
            this.chkNewValues.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Peer ID:";
            // 
            // customPeerID
            // 
            this.customPeerID.BackColor = System.Drawing.Color.White;
            this.customPeerID.Location = new System.Drawing.Point(99, 69);
            this.customPeerID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.customPeerID.Name = "customPeerID";
            this.customPeerID.Size = new System.Drawing.Size(604, 26);
            this.customPeerID.TabIndex = 28;
            // 
            // customKey
            // 
            this.customKey.BackColor = System.Drawing.Color.White;
            this.customKey.Location = new System.Drawing.Point(99, 32);
            this.customKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.customKey.Name = "customKey";
            this.customKey.Size = new System.Drawing.Size(242, 26);
            this.customKey.TabIndex = 26;
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(4, 37);
            this.keyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(83, 20);
            this.keyLabel.TabIndex = 25;
            this.keyLabel.Text = "Client Key:";
            // 
            // magneticPanelOptions
            // 
            this.magneticPanelOptions.BevelStyle = RatioMaster.BevelStyles.Flat;
            this.magneticPanelOptions.Controls.Add(this.lblStopAfter);
            this.magneticPanelOptions.Controls.Add(this.cmbStopAfter);
            this.magneticPanelOptions.Controls.Add(this.txtStopValue);
            this.magneticPanelOptions.Controls.Add(this.intervalLabel);
            this.magneticPanelOptions.Controls.Add(this.lblRemWork);
            this.magneticPanelOptions.Controls.Add(this.fileSize);
            this.magneticPanelOptions.Controls.Add(this.cmbVersion);
            this.magneticPanelOptions.Controls.Add(this.FileSizeLabel);
            this.magneticPanelOptions.Controls.Add(this.cmbClient);
            this.magneticPanelOptions.Controls.Add(this.interval);
            this.magneticPanelOptions.Controls.Add(this.ClientLabel);
            this.magneticPanelOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.magneticPanelOptions.ExpandSize = new System.Drawing.Size(713, 108);
            this.magneticPanelOptions.Location = new System.Drawing.Point(0, 287);
            this.magneticPanelOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.magneticPanelOptions.Name = "magneticPanelOptions";
            this.magneticPanelOptions.Size = new System.Drawing.Size(713, 108);
            this.magneticPanelOptions.TabIndex = 25;
            this.magneticPanelOptions.Text = "Options";
            // 
            // lblStopAfter
            // 
            this.lblStopAfter.AutoSize = true;
            this.lblStopAfter.Location = new System.Drawing.Point(594, 74);
            this.lblStopAfter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStopAfter.Name = "lblStopAfter";
            this.lblStopAfter.Size = new System.Drawing.Size(36, 20);
            this.lblStopAfter.TabIndex = 26;
            this.lblStopAfter.Text = "???";
            // 
            // cmbStopAfter
            // 
            this.cmbStopAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopAfter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStopAfter.FormattingEnabled = true;
            this.cmbStopAfter.Items.AddRange(new object[] {"Never", "After time:", "When seeders <", "When leechers <", "When uploaded >", "When downloaded >", "When leechers/seeders <"});
            this.cmbStopAfter.Location = new System.Drawing.Point(261, 69);
            this.cmbStopAfter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStopAfter.Name = "cmbStopAfter";
            this.cmbStopAfter.Size = new System.Drawing.Size(224, 28);
            this.cmbStopAfter.TabIndex = 25;
            this.cmbStopAfter.SelectedIndexChanged += new System.EventHandler(this.cmbStopAfter_SelectedIndexChanged);
            // 
            // txtStopValue
            // 
            this.txtStopValue.BackColor = System.Drawing.Color.White;
            this.txtStopValue.Location = new System.Drawing.Point(496, 69);
            this.txtStopValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStopValue.Name = "txtStopValue";
            this.txtStopValue.Size = new System.Drawing.Size(86, 26);
            this.txtStopValue.TabIndex = 24;
            this.txtStopValue.Text = "0";
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(4, 37);
            this.intervalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(144, 20);
            this.intervalLabel.TabIndex = 14;
            this.intervalLabel.Text = "Update Interval (s):";
            // 
            // lblRemWork
            // 
            this.lblRemWork.AutoSize = true;
            this.lblRemWork.Location = new System.Drawing.Point(194, 74);
            this.lblRemWork.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemWork.Name = "lblRemWork";
            this.lblRemWork.Size = new System.Drawing.Size(55, 20);
            this.lblRemWork.TabIndex = 23;
            this.lblRemWork.Text = "STOP:";
            // 
            // fileSize
            // 
            this.fileSize.BackColor = System.Drawing.Color.White;
            this.fileSize.Location = new System.Drawing.Point(112, 69);
            this.fileSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileSize.MaxLength = 5;
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(70, 26);
            this.fileSize.TabIndex = 20;
            this.fileSize.Text = "0";
            // 
            // cmbVersion
            // 
            this.cmbVersion.BackColor = System.Drawing.Color.White;
            this.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Location = new System.Drawing.Point(513, 31);
            this.cmbVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(190, 28);
            this.cmbVersion.TabIndex = 18;
            this.cmbVersion.SelectedValueChanged += new System.EventHandler(this.cmbVersion_SelectedValueChanged);
            // 
            // FileSizeLabel
            // 
            this.FileSizeLabel.AutoSize = true;
            this.FileSizeLabel.Location = new System.Drawing.Point(4, 74);
            this.FileSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FileSizeLabel.Name = "FileSizeLabel";
            this.FileSizeLabel.Size = new System.Drawing.Size(101, 20);
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
            this.cmbClient.Items.AddRange(new object[] {"uTorrent", "BitComet", "Azureus", "Vuze", "BitTorrent", "Transmission", "ABC", "BitLord", "BTuga", "BitTornado", "Burst", "BitTyrant", "BitSpirit", "Deluge", "KTorrent", "Gnome BT"});
            this.cmbClient.Location = new System.Drawing.Point(296, 31);
            this.cmbClient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(206, 28);
            this.cmbClient.TabIndex = 17;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // interval
            // 
            this.interval.BackColor = System.Drawing.Color.White;
            this.interval.Location = new System.Drawing.Point(159, 32);
            this.interval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.interval.Name = "interval";
            this.interval.Size = new System.Drawing.Size(62, 26);
            this.interval.TabIndex = 15;
            this.interval.Text = "1800";
            // 
            // ClientLabel
            // 
            this.ClientLabel.AutoSize = true;
            this.ClientLabel.Location = new System.Drawing.Point(232, 37);
            this.ClientLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ClientLabel.Name = "ClientLabel";
            this.ClientLabel.Size = new System.Drawing.Size(53, 20);
            this.ClientLabel.TabIndex = 16;
            this.ClientLabel.Text = "Client:";
            // 
            // magneticPanelSpeed
            // 
            this.magneticPanelSpeed.BevelStyle = RatioMaster.BevelStyles.Flat;
            this.magneticPanelSpeed.Controls.Add(this.uploadRateLabel);
            this.magneticPanelSpeed.Controls.Add(this.uploadRate);
            this.magneticPanelSpeed.Controls.Add(this.txtRandDownMax);
            this.magneticPanelSpeed.Controls.Add(this.downloadRateLabel);
            this.magneticPanelSpeed.Controls.Add(this.txtRandUpMax);
            this.magneticPanelSpeed.Controls.Add(this.downloadRate);
            this.magneticPanelSpeed.Controls.Add(this.txtRandDownMin);
            this.magneticPanelSpeed.Controls.Add(this.chkRandUP);
            this.magneticPanelSpeed.Controls.Add(this.txtRandUpMin);
            this.magneticPanelSpeed.Controls.Add(this.chkRandDown);
            this.magneticPanelSpeed.Controls.Add(this.lblDownMax);
            this.magneticPanelSpeed.Controls.Add(this.lblUpMin);
            this.magneticPanelSpeed.Controls.Add(this.lblDownMin);
            this.magneticPanelSpeed.Controls.Add(this.lblUpMax);
            this.magneticPanelSpeed.Dock = System.Windows.Forms.DockStyle.Top;
            this.magneticPanelSpeed.ExpandSize = new System.Drawing.Size(713, 108);
            this.magneticPanelSpeed.Location = new System.Drawing.Point(0, 179);
            this.magneticPanelSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.magneticPanelSpeed.Name = "magneticPanelSpeed";
            this.magneticPanelSpeed.Size = new System.Drawing.Size(713, 108);
            this.magneticPanelSpeed.TabIndex = 25;
            this.magneticPanelSpeed.Text = "Speed Options";
            // 
            // uploadRateLabel
            // 
            this.uploadRateLabel.AutoSize = true;
            this.uploadRateLabel.Location = new System.Drawing.Point(4, 37);
            this.uploadRateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uploadRateLabel.Name = "uploadRateLabel";
            this.uploadRateLabel.Size = new System.Drawing.Size(160, 20);
            this.uploadRateLabel.TabIndex = 0;
            this.uploadRateLabel.Text = "Upload Speed (kB/s):";
            // 
            // uploadRate
            // 
            this.uploadRate.BackColor = System.Drawing.Color.White;
            this.uploadRate.Location = new System.Drawing.Point(200, 32);
            this.uploadRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uploadRate.Name = "uploadRate";
            this.uploadRate.Size = new System.Drawing.Size(80, 26);
            this.uploadRate.TabIndex = 1;
            this.uploadRate.Text = "60";
            this.uploadRate.TextChanged += new System.EventHandler(this.uploadRate_TextChanged);
            // 
            // txtRandDownMax
            // 
            this.txtRandDownMax.BackColor = System.Drawing.Color.White;
            this.txtRandDownMax.Location = new System.Drawing.Point(640, 69);
            this.txtRandDownMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRandDownMax.Name = "txtRandDownMax";
            this.txtRandDownMax.Size = new System.Drawing.Size(62, 26);
            this.txtRandDownMax.TabIndex = 13;
            this.txtRandDownMax.Text = "10";
            // 
            // downloadRateLabel
            // 
            this.downloadRateLabel.AutoSize = true;
            this.downloadRateLabel.Location = new System.Drawing.Point(4, 74);
            this.downloadRateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.downloadRateLabel.Name = "downloadRateLabel";
            this.downloadRateLabel.Size = new System.Drawing.Size(180, 20);
            this.downloadRateLabel.TabIndex = 7;
            this.downloadRateLabel.Text = "Download Speed (kB/s):";
            // 
            // txtRandUpMax
            // 
            this.txtRandUpMax.BackColor = System.Drawing.Color.White;
            this.txtRandUpMax.Location = new System.Drawing.Point(640, 32);
            this.txtRandUpMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRandUpMax.Name = "txtRandUpMax";
            this.txtRandUpMax.Size = new System.Drawing.Size(62, 26);
            this.txtRandUpMax.TabIndex = 6;
            this.txtRandUpMax.Text = "10";
            // 
            // downloadRate
            // 
            this.downloadRate.BackColor = System.Drawing.Color.White;
            this.downloadRate.Location = new System.Drawing.Point(200, 69);
            this.downloadRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.downloadRate.Name = "downloadRate";
            this.downloadRate.Size = new System.Drawing.Size(80, 26);
            this.downloadRate.TabIndex = 8;
            this.downloadRate.Text = "25";
            this.downloadRate.TextChanged += new System.EventHandler(this.downloadRate_TextChanged);
            // 
            // txtRandDownMin
            // 
            this.txtRandDownMin.BackColor = System.Drawing.Color.White;
            this.txtRandDownMin.Location = new System.Drawing.Point(513, 69);
            this.txtRandDownMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRandDownMin.Name = "txtRandDownMin";
            this.txtRandDownMin.Size = new System.Drawing.Size(62, 26);
            this.txtRandDownMin.TabIndex = 11;
            this.txtRandDownMin.Text = "1";
            // 
            // chkRandUP
            // 
            this.chkRandUP.AutoSize = true;
            this.chkRandUP.Checked = true;
            this.chkRandUP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRandUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRandUP.Location = new System.Drawing.Point(291, 34);
            this.chkRandUP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRandUP.Name = "chkRandUP";
            this.chkRandUP.Size = new System.Drawing.Size(157, 24);
            this.chkRandUP.TabIndex = 2;
            this.chkRandUP.Text = "+ Random values:";
            this.chkRandUP.UseVisualStyleBackColor = true;
            // 
            // txtRandUpMin
            // 
            this.txtRandUpMin.BackColor = System.Drawing.Color.White;
            this.txtRandUpMin.Location = new System.Drawing.Point(513, 32);
            this.txtRandUpMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRandUpMin.Name = "txtRandUpMin";
            this.txtRandUpMin.Size = new System.Drawing.Size(62, 26);
            this.txtRandUpMin.TabIndex = 4;
            this.txtRandUpMin.Text = "1";
            // 
            // chkRandDown
            // 
            this.chkRandDown.AutoSize = true;
            this.chkRandDown.Checked = true;
            this.chkRandDown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRandDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRandDown.Location = new System.Drawing.Point(291, 71);
            this.chkRandDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRandDown.Name = "chkRandDown";
            this.chkRandDown.Size = new System.Drawing.Size(157, 24);
            this.chkRandDown.TabIndex = 9;
            this.chkRandDown.Text = "+ Random values:";
            this.chkRandDown.UseVisualStyleBackColor = true;
            // 
            // lblDownMax
            // 
            this.lblDownMax.AutoSize = true;
            this.lblDownMax.Location = new System.Drawing.Point(586, 74);
            this.lblDownMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownMax.Name = "lblDownMax";
            this.lblDownMax.Size = new System.Drawing.Size(42, 20);
            this.lblDownMax.TabIndex = 12;
            this.lblDownMax.Text = "Max:";
            // 
            // lblUpMin
            // 
            this.lblUpMin.AutoSize = true;
            this.lblUpMin.Location = new System.Drawing.Point(464, 37);
            this.lblUpMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpMin.Name = "lblUpMin";
            this.lblUpMin.Size = new System.Drawing.Size(38, 20);
            this.lblUpMin.TabIndex = 3;
            this.lblUpMin.Text = "Min:";
            // 
            // lblDownMin
            // 
            this.lblDownMin.AutoSize = true;
            this.lblDownMin.Location = new System.Drawing.Point(464, 74);
            this.lblDownMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownMin.Name = "lblDownMin";
            this.lblDownMin.Size = new System.Drawing.Size(38, 20);
            this.lblDownMin.TabIndex = 10;
            this.lblDownMin.Text = "Min:";
            // 
            // lblUpMax
            // 
            this.lblUpMax.AutoSize = true;
            this.lblUpMax.Location = new System.Drawing.Point(586, 37);
            this.lblUpMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpMax.Name = "lblUpMax";
            this.lblUpMax.Size = new System.Drawing.Size(42, 20);
            this.lblUpMax.TabIndex = 5;
            this.lblUpMax.Text = "Max:";
            // 
            // magneticPanelInfo
            // 
            this.magneticPanelInfo.BevelStyle = RatioMaster.BevelStyles.Flat;
            this.magneticPanelInfo.Controls.Add(this.txtTorrentSize);
            this.magneticPanelInfo.Controls.Add(this.trackerAddress);
            this.magneticPanelInfo.Controls.Add(this.lblTorrentSize);
            this.magneticPanelInfo.Controls.Add(this.TrackerLabel);
            this.magneticPanelInfo.Controls.Add(this.shaHash);
            this.magneticPanelInfo.Controls.Add(this.hashLabel);
            this.magneticPanelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.magneticPanelInfo.ExpandSize = new System.Drawing.Size(713, 108);
            this.magneticPanelInfo.Location = new System.Drawing.Point(0, 71);
            this.magneticPanelInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.magneticPanelInfo.Name = "magneticPanelInfo";
            this.magneticPanelInfo.Size = new System.Drawing.Size(713, 108);
            this.magneticPanelInfo.TabIndex = 25;
            this.magneticPanelInfo.Text = "Torrent Info";
            // 
            // txtTorrentSize
            // 
            this.txtTorrentSize.Location = new System.Drawing.Point(598, 69);
            this.txtTorrentSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTorrentSize.Name = "txtTorrentSize";
            this.txtTorrentSize.ReadOnly = true;
            this.txtTorrentSize.Size = new System.Drawing.Size(104, 26);
            this.txtTorrentSize.TabIndex = 5;
            // 
            // trackerAddress
            // 
            this.trackerAddress.BackColor = System.Drawing.Color.White;
            this.trackerAddress.Location = new System.Drawing.Point(84, 32);
            this.trackerAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackerAddress.Name = "trackerAddress";
            this.trackerAddress.Size = new System.Drawing.Size(619, 26);
            this.trackerAddress.TabIndex = 1;
            // 
            // lblTorrentSize
            // 
            this.lblTorrentSize.AutoSize = true;
            this.lblTorrentSize.Location = new System.Drawing.Point(544, 74);
            this.lblTorrentSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTorrentSize.Name = "lblTorrentSize";
            this.lblTorrentSize.Size = new System.Drawing.Size(44, 20);
            this.lblTorrentSize.TabIndex = 4;
            this.lblTorrentSize.Text = "Size:";
            // 
            // TrackerLabel
            // 
            this.TrackerLabel.AutoSize = true;
            this.TrackerLabel.Location = new System.Drawing.Point(4, 37);
            this.TrackerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TrackerLabel.Name = "TrackerLabel";
            this.TrackerLabel.Size = new System.Drawing.Size(66, 20);
            this.TrackerLabel.TabIndex = 0;
            this.TrackerLabel.Text = "Tracker:";
            // 
            // shaHash
            // 
            this.shaHash.Location = new System.Drawing.Point(84, 69);
            this.shaHash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.shaHash.Name = "shaHash";
            this.shaHash.ReadOnly = true;
            this.shaHash.Size = new System.Drawing.Size(450, 26);
            this.shaHash.TabIndex = 3;
            // 
            // hashLabel
            // 
            this.hashLabel.AutoSize = true;
            this.hashLabel.Location = new System.Drawing.Point(4, 74);
            this.hashLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hashLabel.Name = "hashLabel";
            this.hashLabel.Size = new System.Drawing.Size(59, 20);
            this.hashLabel.TabIndex = 2;
            this.hashLabel.Text = "HASH:\r\n";
            // 
            // magneticPanelProxy
            // 
            this.magneticPanelProxy.BevelStyle = RatioMaster.BevelStyles.Flat;
            this.magneticPanelProxy.Controls.Add(this.labelProxyType);
            this.magneticPanelProxy.Controls.Add(this.labelProxyHost);
            this.magneticPanelProxy.Controls.Add(this.textProxyPass);
            this.magneticPanelProxy.Controls.Add(this.comboProxyType);
            this.magneticPanelProxy.Controls.Add(this.textProxyHost);
            this.magneticPanelProxy.Controls.Add(this.labelProxyUser);
            this.magneticPanelProxy.Controls.Add(this.textProxyPort);
            this.magneticPanelProxy.Controls.Add(this.labelProxyPort);
            this.magneticPanelProxy.Controls.Add(this.labelProxyPass);
            this.magneticPanelProxy.Controls.Add(this.textProxyUser);
            this.magneticPanelProxy.Dock = System.Windows.Forms.DockStyle.Top;
            this.magneticPanelProxy.ExpandSize = new System.Drawing.Size(713, 108);
            this.magneticPanelProxy.Location = new System.Drawing.Point(0, 546);
            this.magneticPanelProxy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.magneticPanelProxy.Name = "magneticPanelProxy";
            this.magneticPanelProxy.Size = new System.Drawing.Size(713, 108);
            this.magneticPanelProxy.TabIndex = 6;
            this.magneticPanelProxy.Text = "Proxy Server Settings";
            // 
            // labelProxyType
            // 
            this.labelProxyType.AutoSize = true;
            this.labelProxyType.Location = new System.Drawing.Point(4, 37);
            this.labelProxyType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProxyType.Name = "labelProxyType";
            this.labelProxyType.Size = new System.Drawing.Size(89, 20);
            this.labelProxyType.TabIndex = 0;
            this.labelProxyType.Text = "Proxy Type:";
            // 
            // labelProxyHost
            // 
            this.labelProxyHost.AutoSize = true;
            this.labelProxyHost.Location = new System.Drawing.Point(4, 74);
            this.labelProxyHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProxyHost.Name = "labelProxyHost";
            this.labelProxyHost.Size = new System.Drawing.Size(89, 20);
            this.labelProxyHost.TabIndex = 6;
            this.labelProxyHost.Text = "Proxy Host:";
            // 
            // textProxyPass
            // 
            this.textProxyPass.BackColor = System.Drawing.Color.White;
            this.textProxyPass.Location = new System.Drawing.Point(602, 32);
            this.textProxyPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textProxyPass.Name = "textProxyPass";
            this.textProxyPass.Size = new System.Drawing.Size(100, 26);
            this.textProxyPass.TabIndex = 5;
            // 
            // comboProxyType
            // 
            this.comboProxyType.BackColor = System.Drawing.Color.White;
            this.comboProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProxyType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboProxyType.FormattingEnabled = true;
            this.comboProxyType.Items.AddRange(new object[] {"None", "HTTP", "SOCKS4", "SOCKS4a", "SOCKS5"});
            this.comboProxyType.Location = new System.Drawing.Point(108, 31);
            this.comboProxyType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboProxyType.Name = "comboProxyType";
            this.comboProxyType.Size = new System.Drawing.Size(138, 28);
            this.comboProxyType.TabIndex = 1;
            // 
            // textProxyHost
            // 
            this.textProxyHost.BackColor = System.Drawing.Color.White;
            this.textProxyHost.Location = new System.Drawing.Point(108, 69);
            this.textProxyHost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textProxyHost.Name = "textProxyHost";
            this.textProxyHost.Size = new System.Drawing.Size(380, 26);
            this.textProxyHost.TabIndex = 7;
            // 
            // labelProxyUser
            // 
            this.labelProxyUser.AutoSize = true;
            this.labelProxyUser.Location = new System.Drawing.Point(254, 37);
            this.labelProxyUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProxyUser.Name = "labelProxyUser";
            this.labelProxyUser.Size = new System.Drawing.Size(89, 20);
            this.labelProxyUser.TabIndex = 2;
            this.labelProxyUser.Text = "Proxy User:";
            // 
            // textProxyPort
            // 
            this.textProxyPort.BackColor = System.Drawing.Color.White;
            this.textProxyPort.Location = new System.Drawing.Point(602, 69);
            this.textProxyPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textProxyPort.Name = "textProxyPort";
            this.textProxyPort.Size = new System.Drawing.Size(100, 26);
            this.textProxyPort.TabIndex = 9;
            // 
            // labelProxyPort
            // 
            this.labelProxyPort.AutoSize = true;
            this.labelProxyPort.Location = new System.Drawing.Point(500, 74);
            this.labelProxyPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProxyPort.Name = "labelProxyPort";
            this.labelProxyPort.Size = new System.Drawing.Size(84, 20);
            this.labelProxyPort.TabIndex = 8;
            this.labelProxyPort.Text = "Proxy Port:";
            // 
            // labelProxyPass
            // 
            this.labelProxyPass.AutoSize = true;
            this.labelProxyPass.Location = new System.Drawing.Point(500, 37);
            this.labelProxyPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProxyPass.Name = "labelProxyPass";
            this.labelProxyPass.Size = new System.Drawing.Size(90, 20);
            this.labelProxyPass.TabIndex = 4;
            this.labelProxyPass.Text = "Proxy Pass:";
            // 
            // textProxyUser
            // 
            this.textProxyUser.BackColor = System.Drawing.Color.White;
            this.textProxyUser.Location = new System.Drawing.Point(354, 32);
            this.textProxyUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textProxyUser.Name = "textProxyUser";
            this.textProxyUser.Size = new System.Drawing.Size(134, 26);
            this.textProxyUser.TabIndex = 3;
            // 
            // magneticPanelOther
            // 
            this.magneticPanelOther.BevelStyle = RatioMaster.BevelStyles.Flat;
            this.magneticPanelOther.Controls.Add(this.checkIgnoreFailureReason);
            this.magneticPanelOther.Controls.Add(this.checkRequestScrap);
            this.magneticPanelOther.Controls.Add(this.checkTCPListen);
            this.magneticPanelOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.magneticPanelOther.ExpandSize = new System.Drawing.Size(713, 62);
            this.magneticPanelOther.Location = new System.Drawing.Point(0, 484);
            this.magneticPanelOther.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.magneticPanelOther.Name = "magneticPanelOther";
            this.magneticPanelOther.Size = new System.Drawing.Size(713, 62);
            this.magneticPanelOther.TabIndex = 6;
            this.magneticPanelOther.Text = "Other Settings";
            // 
            // checkIgnoreFailureReason
            // 
            this.checkIgnoreFailureReason.AutoSize = true;
            this.checkIgnoreFailureReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkIgnoreFailureReason.Location = new System.Drawing.Point(316, 32);
            this.checkIgnoreFailureReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkIgnoreFailureReason.Name = "checkIgnoreFailureReason";
            this.checkIgnoreFailureReason.Size = new System.Drawing.Size(182, 24);
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
            this.checkRequestScrap.Location = new System.Drawing.Point(166, 31);
            this.checkRequestScrap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkRequestScrap.Name = "checkRequestScrap";
            this.checkRequestScrap.Size = new System.Drawing.Size(137, 24);
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
            this.checkTCPListen.Location = new System.Drawing.Point(4, 31);
            this.checkTCPListen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkTCPListen.Name = "checkTCPListen";
            this.checkTCPListen.Size = new System.Drawing.Size(148, 24);
            this.checkTCPListen.TabIndex = 0;
            this.checkTCPListen.Text = "Use TCP listener";
            this.checkTCPListen.UseVisualStyleBackColor = true;
            // 
            // magneticPanelFile
            // 
            this.magneticPanelFile.BevelStyle = RatioMaster.BevelStyles.Flat;
            this.magneticPanelFile.Controls.Add(this.browseButton);
            this.magneticPanelFile.Controls.Add(this.torrentFile);
            this.magneticPanelFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.magneticPanelFile.ExpandSize = new System.Drawing.Size(713, 71);
            this.magneticPanelFile.Location = new System.Drawing.Point(0, 0);
            this.magneticPanelFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.magneticPanelFile.Name = "magneticPanelFile";
            this.magneticPanelFile.Size = new System.Drawing.Size(713, 71);
            this.magneticPanelFile.TabIndex = 6;
            this.magneticPanelFile.Text = "Torrent File";
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
            this.browseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.browseButton.Location = new System.Drawing.Point(598, 29);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(106, 37);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // torrentFile
            // 
            this.torrentFile.BackColor = System.Drawing.Color.White;
            this.torrentFile.Location = new System.Drawing.Point(9, 32);
            this.torrentFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.torrentFile.Name = "torrentFile";
            this.torrentFile.ReadOnly = true;
            this.torrentFile.Size = new System.Drawing.Size(578, 26);
            this.torrentFile.TabIndex = 0;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.StartButton);
            this.panelControls.Controls.Add(this.btnDefault);
            this.panelControls.Controls.Add(this.manualUpdateButton);
            this.panelControls.Controls.Add(this.StopButton);
            this.panelControls.Controls.Add(this.info);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 899);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(713, 88);
            this.panelControls.TabIndex = 29;
            // 
            // RM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logWindow);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.magneticPanelSimulation);
            this.Controls.Add(this.magneticPanelProxy);
            this.Controls.Add(this.magneticPanelOther);
            this.Controls.Add(this.magneticPanelNextSpeed);
            this.Controls.Add(this.magneticPanelOptions);
            this.Controls.Add(this.magneticPanelSpeed);
            this.Controls.Add(this.magneticPanelInfo);
            this.Controls.Add(this.magneticPanelFile);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RM";
            this.Size = new System.Drawing.Size(713, 987);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.info.ResumeLayout(false);
            this.info.PerformLayout();
            this.magneticPanelNextSpeed.ResumeLayout(false);
            this.magneticPanelNextSpeed.PerformLayout();
            this.magneticPanelSimulation.ResumeLayout(false);
            this.magneticPanelSimulation.PerformLayout();
            this.magneticPanelOptions.ResumeLayout(false);
            this.magneticPanelOptions.PerformLayout();
            this.magneticPanelSpeed.ResumeLayout(false);
            this.magneticPanelSpeed.PerformLayout();
            this.magneticPanelInfo.ResumeLayout(false);
            this.magneticPanelInfo.PerformLayout();
            this.magneticPanelProxy.ResumeLayout(false);
            this.magneticPanelProxy.PerformLayout();
            this.magneticPanelOther.ResumeLayout(false);
            this.magneticPanelOther.PerformLayout();
            this.magneticPanelFile.ResumeLayout(false);
            this.magneticPanelFile.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
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
        private RatioMaster.MagneticPanel magneticPanelFile;
        private RatioMaster.MagneticPanel magneticPanelOther;
        private RatioMaster.MagneticPanel magneticPanelProxy;
        private RatioMaster.MagneticPanel magneticPanelInfo;
        private RatioMaster.MagneticPanel magneticPanelSpeed;
        private RatioMaster.MagneticPanel magneticPanelOptions;
        private RatioMaster.MagneticPanel magneticPanelSimulation;
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
        private RatioMaster.MagneticPanel magneticPanelNextSpeed;
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
    }
}
