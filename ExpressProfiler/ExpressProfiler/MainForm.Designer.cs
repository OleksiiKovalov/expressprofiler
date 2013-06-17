namespace ExpressProfiler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbScroll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbStart = new System.Windows.Forms.ToolStripButton();
            this.tbPause = new System.Windows.Forms.ToolStripButton();
            this.tbStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.edServer = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAuth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.edUser = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.edPassword = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cbSelectEvents = new System.Windows.Forms.ToolStripSplitButton();
            this.mnExistingConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLoginLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnRPCStarting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRPCCompleted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnBatchStarting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBatchCompleted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.edDuration = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reTextData = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.extractAllEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractSelectedEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTraceWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSPStmtCompleted = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSPStmtStarting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(979, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator5,
            this.tbScroll,
            this.toolStripSeparator1,
            this.tbStart,
            this.tbPause,
            this.tbStop,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.edServer,
            this.toolStripSeparator4,
            this.tbAuth,
            this.toolStripLabel2,
            this.edUser,
            this.toolStripLabel3,
            this.edPassword,
            this.toolStripSeparator3,
            this.cbSelectEvents,
            this.toolStripLabel4,
            this.edDuration});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(979, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Silver;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Clear trace";
            this.toolStripButton1.ToolTipText = "Clear trace\r\nCtrl+Shift+Del";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbScroll
            // 
            this.tbScroll.Checked = true;
            this.tbScroll.CheckOnClick = true;
            this.tbScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbScroll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbScroll.Image = ((System.Drawing.Image)(resources.GetObject("tbScroll.Image")));
            this.tbScroll.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbScroll.Name = "tbScroll";
            this.tbScroll.Size = new System.Drawing.Size(23, 22);
            this.tbScroll.Text = "Auto scroll window";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbStart
            // 
            this.tbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbStart.Image = ((System.Drawing.Image)(resources.GetObject("tbStart.Image")));
            this.tbStart.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(23, 22);
            this.tbStart.Text = "Start trace";
            this.tbStart.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tbPause
            // 
            this.tbPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPause.Image = ((System.Drawing.Image)(resources.GetObject("tbPause.Image")));
            this.tbPause.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbPause.Name = "tbPause";
            this.tbPause.Size = new System.Drawing.Size(23, 22);
            this.tbPause.Text = "Pause trace";
            this.tbPause.Click += new System.EventHandler(this.tbPause_Click);
            // 
            // tbStop
            // 
            this.tbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbStop.Image = ((System.Drawing.Image)(resources.GetObject("tbStop.Image")));
            this.tbStop.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbStop.Name = "tbStop";
            this.tbStop.Size = new System.Drawing.Size(23, 22);
            this.tbStop.Text = "Stop trace";
            this.tbStop.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Server";
            // 
            // edServer
            // 
            this.edServer.Name = "edServer";
            this.edServer.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbAuth
            // 
            this.tbAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbAuth.Items.AddRange(new object[] {
            "Windows auth",
            "SQL Server auth"});
            this.tbAuth.Name = "tbAuth";
            this.tbAuth.Size = new System.Drawing.Size(121, 25);
            this.tbAuth.SelectedIndexChanged += new System.EventHandler(this.tbAuth_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel2.Text = "User";
            // 
            // edUser
            // 
            this.edUser.Name = "edUser";
            this.edUser.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel3.Text = "Password";
            // 
            // edPassword
            // 
            this.edPassword.Name = "edPassword";
            this.edPassword.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cbSelectEvents
            // 
            this.cbSelectEvents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cbSelectEvents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnExistingConnection,
            this.mnLoginLogout,
            this.toolStripMenuItem1,
            this.mnRPCStarting,
            this.mnRPCCompleted,
            this.mnSPStmtStarting,
            this.mnSPStmtCompleted,
            this.toolStripMenuItem2,
            this.mnBatchStarting,
            this.mnBatchCompleted,
            this.toolStripMenuItem6});
            this.cbSelectEvents.Image = ((System.Drawing.Image)(resources.GetObject("cbSelectEvents.Image")));
            this.cbSelectEvents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cbSelectEvents.Name = "cbSelectEvents";
            this.cbSelectEvents.Size = new System.Drawing.Size(56, 22);
            this.cbSelectEvents.Text = "Events";
            // 
            // mnExistingConnection
            // 
            this.mnExistingConnection.Name = "mnExistingConnection";
            this.mnExistingConnection.Size = new System.Drawing.Size(171, 22);
            this.mnExistingConnection.Text = "Existing connections";
            this.mnExistingConnection.Click += new System.EventHandler(this.existingConnectionsToolStripMenuItem_Click);
            // 
            // mnLoginLogout
            // 
            this.mnLoginLogout.Name = "mnLoginLogout";
            this.mnLoginLogout.Size = new System.Drawing.Size(171, 22);
            this.mnLoginLogout.Text = "Audit login/logout";
            this.mnLoginLogout.Click += new System.EventHandler(this.existingConnectionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // mnRPCStarting
            // 
            this.mnRPCStarting.Name = "mnRPCStarting";
            this.mnRPCStarting.Size = new System.Drawing.Size(171, 22);
            this.mnRPCStarting.Text = "RPC:Starting";
            this.mnRPCStarting.Click += new System.EventHandler(this.existingConnectionsToolStripMenuItem_Click);
            // 
            // mnRPCCompleted
            // 
            this.mnRPCCompleted.Checked = true;
            this.mnRPCCompleted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnRPCCompleted.Name = "mnRPCCompleted";
            this.mnRPCCompleted.Size = new System.Drawing.Size(171, 22);
            this.mnRPCCompleted.Text = "RPC:Completed";
            this.mnRPCCompleted.Click += new System.EventHandler(this.existingConnectionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
            // 
            // mnBatchStarting
            // 
            this.mnBatchStarting.Name = "mnBatchStarting";
            this.mnBatchStarting.Size = new System.Drawing.Size(171, 22);
            this.mnBatchStarting.Text = "Batch:Starting";
            this.mnBatchStarting.Click += new System.EventHandler(this.existingConnectionsToolStripMenuItem_Click);
            // 
            // mnBatchCompleted
            // 
            this.mnBatchCompleted.Checked = true;
            this.mnBatchCompleted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnBatchCompleted.Name = "mnBatchCompleted";
            this.mnBatchCompleted.Size = new System.Drawing.Size(171, 22);
            this.mnBatchCompleted.Text = "Batch:Completed";
            this.mnBatchCompleted.Click += new System.EventHandler(this.existingConnectionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel4.Text = "Duration, ms >=";
            // 
            // edDuration
            // 
            this.edDuration.Name = "edDuration";
            this.edDuration.Size = new System.Drawing.Size(100, 25);
            this.edDuration.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reTextData);
            this.splitContainer1.Size = new System.Drawing.Size(979, 439);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 4;
            // 
            // reTextData
            // 
            this.reTextData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reTextData.Location = new System.Drawing.Point(0, 0);
            this.reTextData.Name = "reTextData";
            this.reTextData.ReadOnly = true;
            this.reTextData.Size = new System.Drawing.Size(979, 154);
            this.reTextData.TabIndex = 4;
            this.reTextData.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToClipboardToolStripMenuItem,
            this.copySelectedToClipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(238, 48);
            // 
            // copyAllToClipboardToolStripMenuItem
            // 
            this.copyAllToClipboardToolStripMenuItem.Name = "copyAllToClipboardToolStripMenuItem";
            this.copyAllToClipboardToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.copyAllToClipboardToolStripMenuItem.Text = "Copy all events to clipboard";
            this.copyAllToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyAllToClipboardToolStripMenuItem_Click);
            // 
            // copySelectedToClipboardToolStripMenuItem
            // 
            this.copySelectedToClipboardToolStripMenuItem.Name = "copySelectedToClipboardToolStripMenuItem";
            this.copySelectedToClipboardToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.copySelectedToClipboardToolStripMenuItem.Text = "Copy selected events to clipboard";
            this.copySelectedToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copySelectedToClipboardToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(979, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTraceToolStripMenuItem,
            this.pauseTraceToolStripMenuItem,
            this.stopTraceToolStripMenuItem,
            this.toolStripMenuItem3,
            this.extractAllEventsToolStripMenuItem,
            this.extractSelectedEventsToolStripMenuItem,
            this.toolStripMenuItem5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startTraceToolStripMenuItem
            // 
            this.startTraceToolStripMenuItem.Name = "startTraceToolStripMenuItem";
            this.startTraceToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.startTraceToolStripMenuItem.Text = "Start trace";
            this.startTraceToolStripMenuItem.Click += new System.EventHandler(this.startTraceToolStripMenuItem_Click);
            // 
            // pauseTraceToolStripMenuItem
            // 
            this.pauseTraceToolStripMenuItem.Name = "pauseTraceToolStripMenuItem";
            this.pauseTraceToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.pauseTraceToolStripMenuItem.Text = "Pause trace";
            this.pauseTraceToolStripMenuItem.Click += new System.EventHandler(this.pauseTraceToolStripMenuItem_Click);
            // 
            // stopTraceToolStripMenuItem
            // 
            this.stopTraceToolStripMenuItem.Name = "stopTraceToolStripMenuItem";
            this.stopTraceToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.stopTraceToolStripMenuItem.Text = "Stop trace";
            this.stopTraceToolStripMenuItem.Click += new System.EventHandler(this.stopTraceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(234, 6);
            // 
            // extractAllEventsToolStripMenuItem
            // 
            this.extractAllEventsToolStripMenuItem.Name = "extractAllEventsToolStripMenuItem";
            this.extractAllEventsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.extractAllEventsToolStripMenuItem.Text = "Copy all events to clipboard";
            this.extractAllEventsToolStripMenuItem.Click += new System.EventHandler(this.extractAllEventsToolStripMenuItem_Click);
            // 
            // extractSelectedEventsToolStripMenuItem
            // 
            this.extractSelectedEventsToolStripMenuItem.Name = "extractSelectedEventsToolStripMenuItem";
            this.extractSelectedEventsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.extractSelectedEventsToolStripMenuItem.Text = "Copy selected events to clipboard";
            this.extractSelectedEventsToolStripMenuItem.Click += new System.EventHandler(this.extractSelectedEventsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(234, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.findToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.toolStripMenuItem4,
            this.clearTraceWindowToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.findToolStripMenuItem.Text = "Find...";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.findNextToolStripMenuItem.Text = "Find next";
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.findNextToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(244, 6);
            // 
            // clearTraceWindowToolStripMenuItem
            // 
            this.clearTraceWindowToolStripMenuItem.Name = "clearTraceWindowToolStripMenuItem";
            this.clearTraceWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.clearTraceWindowToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.clearTraceWindowToolStripMenuItem.Text = "Clear Trace Window";
            this.clearTraceWindowToolStripMenuItem.Click += new System.EventHandler(this.clearTraceWindowToolStripMenuItem_Click);
            // 
            // mnSPStmtCompleted
            // 
            this.mnSPStmtCompleted.Name = "mnSPStmtCompleted";
            this.mnSPStmtCompleted.Size = new System.Drawing.Size(171, 22);
            this.mnSPStmtCompleted.Text = "SP:StmtCompleted";
            this.mnSPStmtCompleted.Click += new System.EventHandler(this.existingConnectionsToolStripMenuItem_Click);
            // 
            // mnSPStmtStarting
            // 
            this.mnSPStmtStarting.Name = "mnSPStmtStarting";
            this.mnSPStmtStarting.Size = new System.Drawing.Size(171, 22);
            this.mnSPStmtStarting.Text = "SP:StmtStarting";
            this.mnSPStmtStarting.Click += new System.EventHandler(this.existingConnectionsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 510);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Express Profiler v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbStart;
        private System.Windows.Forms.ToolStripButton tbStop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox reTextData;
        private System.Windows.Forms.ToolStripButton tbScroll;
        private System.Windows.Forms.ToolStripButton tbPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox edServer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox edUser;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox edPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton cbSelectEvents;
        private System.Windows.Forms.ToolStripMenuItem mnExistingConnection;
        private System.Windows.Forms.ToolStripMenuItem mnLoginLogout;
        private System.Windows.Forms.ToolStripMenuItem mnRPCStarting;
        private System.Windows.Forms.ToolStripMenuItem mnRPCCompleted;
        private System.Windows.Forms.ToolStripMenuItem mnBatchStarting;
        private System.Windows.Forms.ToolStripMenuItem mnBatchCompleted;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox tbAuth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox edDuration;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyAllToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToClipboardToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTraceWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem extractAllEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractSelectedEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mnSPStmtCompleted;
        private System.Windows.Forms.ToolStripMenuItem mnSPStmtStarting;
    }
}

