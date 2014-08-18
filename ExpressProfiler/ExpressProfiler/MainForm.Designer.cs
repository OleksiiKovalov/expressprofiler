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
            this.slEPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbScroll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbStart = new System.Windows.Forms.ToolStripSplitButton();
            this.tbRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tbRunWithFilters = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tbStayOnTop = new System.Windows.Forms.ToolStripButton();
            this.tbTransparent = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reTextData = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToXlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRunWithFilters = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.extractAllEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractSelectedEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllForExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTraceWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slEPS});
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(979, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slEPS
            // 
            this.slEPS.Name = "slEPS";
            this.slEPS.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbClear,
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
            this.tbStayOnTop,
            this.tbTransparent});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(979, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbClear
            // 
            this.tbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbClear.Image = global::ExpressProfiler.Properties.Resources.imClear;
            this.tbClear.ImageTransparentColor = System.Drawing.Color.Silver;
            this.tbClear.Name = "tbClear";
            this.tbClear.Size = new System.Drawing.Size(23, 22);
            this.tbClear.Text = "Clear trace";
            this.tbClear.ToolTipText = "Clear trace\r\nCtrl+Shift+Del";
            this.tbClear.Click += new System.EventHandler(this.tbClear_Click);
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
            this.tbScroll.Image = global::ExpressProfiler.Properties.Resources.imScroll;
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
            this.tbStart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbRun,
            this.tbRunWithFilters});
            this.tbStart.Image = global::ExpressProfiler.Properties.Resources.imStart;
            this.tbStart.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(32, 22);
            this.tbStart.Text = "Start trace";
            // 
            // tbRun
            // 
            this.tbRun.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbRun.Name = "tbRun";
            this.tbRun.Size = new System.Drawing.Size(146, 22);
            this.tbRun.Text = "Run";
            this.tbRun.Click += new System.EventHandler(this.tbStart_Click);
            // 
            // tbRunWithFilters
            // 
            this.tbRunWithFilters.Name = "tbRunWithFilters";
            this.tbRunWithFilters.Size = new System.Drawing.Size(146, 22);
            this.tbRunWithFilters.Text = "Run with filters";
            this.tbRunWithFilters.Click += new System.EventHandler(this.tbRunWithFilters_Click);
            // 
            // tbPause
            // 
            this.tbPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPause.Image = global::ExpressProfiler.Properties.Resources.imPause;
            this.tbPause.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbPause.Name = "tbPause";
            this.tbPause.Size = new System.Drawing.Size(23, 22);
            this.tbPause.Text = "Pause trace";
            this.tbPause.Click += new System.EventHandler(this.tbPause_Click);
            // 
            // tbStop
            // 
            this.tbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbStop.Image = global::ExpressProfiler.Properties.Resources.imStop;
            this.tbStop.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbStop.Name = "tbStop";
            this.tbStop.Size = new System.Drawing.Size(23, 22);
            this.tbStop.Text = "Stop trace";
            this.tbStop.Click += new System.EventHandler(this.tbStop_Click);
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
            // tbStayOnTop
            // 
            this.tbStayOnTop.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbStayOnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbStayOnTop.Image = ((System.Drawing.Image)(resources.GetObject("tbStayOnTop.Image")));
            this.tbStayOnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbStayOnTop.Name = "tbStayOnTop";
            this.tbStayOnTop.Size = new System.Drawing.Size(23, 22);
            this.tbStayOnTop.Text = "Stay on top";
            this.tbStayOnTop.Click += new System.EventHandler(this.tbStayOnTop_Click);
            // 
            // tbTransparent
            // 
            this.tbTransparent.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbTransparent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbTransparent.Image = ((System.Drawing.Image)(resources.GetObject("tbTransparent.Image")));
            this.tbTransparent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbTransparent.Name = "tbTransparent";
            this.tbTransparent.Size = new System.Drawing.Size(23, 22);
            this.tbTransparent.Text = "Transparent";
            this.tbTransparent.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            this.copySelectedToClipboardToolStripMenuItem,
            this.toolStripMenuItem1,
            this.copyToXlsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(238, 76);
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(234, 6);
            // 
            // copyToXlsToolStripMenuItem
            // 
            this.copyToXlsToolStripMenuItem.Name = "copyToXlsToolStripMenuItem";
            this.copyToXlsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.copyToXlsToolStripMenuItem.Text = "Copy all for Excel";
            this.copyToXlsToolStripMenuItem.Click += new System.EventHandler(this.copyToXlsToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.mnAbout,
            this.viewToolStripMenuItem});
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
            this.copyAllForExcelToolStripMenuItem,
            this.toolStripMenuItem5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // startTraceToolStripMenuItem
            // 
            this.startTraceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnRun,
            this.mnRunWithFilters});
            this.startTraceToolStripMenuItem.Image = global::ExpressProfiler.Properties.Resources.imStart;
            this.startTraceToolStripMenuItem.Name = "startTraceToolStripMenuItem";
            this.startTraceToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.startTraceToolStripMenuItem.Text = "&Start trace";
            // 
            // mnRun
            // 
            this.mnRun.Name = "mnRun";
            this.mnRun.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.mnRun.Size = new System.Drawing.Size(146, 22);
            this.mnRun.Text = "Run";
            this.mnRun.Click += new System.EventHandler(this.tbStart_Click);
            // 
            // mnRunWithFilters
            // 
            this.mnRunWithFilters.Name = "mnRunWithFilters";
            this.mnRunWithFilters.Size = new System.Drawing.Size(146, 22);
            this.mnRunWithFilters.Text = "Run with filters";
            this.mnRunWithFilters.Click += new System.EventHandler(this.tbRunWithFilters_Click);
            // 
            // pauseTraceToolStripMenuItem
            // 
            this.pauseTraceToolStripMenuItem.Image = global::ExpressProfiler.Properties.Resources.imPause;
            this.pauseTraceToolStripMenuItem.Name = "pauseTraceToolStripMenuItem";
            this.pauseTraceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.pauseTraceToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.pauseTraceToolStripMenuItem.Text = "&Pause trace";
            this.pauseTraceToolStripMenuItem.Click += new System.EventHandler(this.pauseTraceToolStripMenuItem_Click);
            // 
            // stopTraceToolStripMenuItem
            // 
            this.stopTraceToolStripMenuItem.Image = global::ExpressProfiler.Properties.Resources.imStop;
            this.stopTraceToolStripMenuItem.Name = "stopTraceToolStripMenuItem";
            this.stopTraceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.stopTraceToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.stopTraceToolStripMenuItem.Text = "S&top trace";
            this.stopTraceToolStripMenuItem.Click += new System.EventHandler(this.stopTraceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(302, 6);
            // 
            // extractAllEventsToolStripMenuItem
            // 
            this.extractAllEventsToolStripMenuItem.Name = "extractAllEventsToolStripMenuItem";
            this.extractAllEventsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Insert)));
            this.extractAllEventsToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.extractAllEventsToolStripMenuItem.Text = "Copy all events to clipboard";
            this.extractAllEventsToolStripMenuItem.Click += new System.EventHandler(this.extractAllEventsToolStripMenuItem_Click);
            // 
            // extractSelectedEventsToolStripMenuItem
            // 
            this.extractSelectedEventsToolStripMenuItem.Name = "extractSelectedEventsToolStripMenuItem";
            this.extractSelectedEventsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Insert)));
            this.extractSelectedEventsToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.extractSelectedEventsToolStripMenuItem.Text = "Copy selected events to clipboard";
            this.extractSelectedEventsToolStripMenuItem.Click += new System.EventHandler(this.extractSelectedEventsToolStripMenuItem_Click);
            // 
            // copyAllForExcelToolStripMenuItem
            // 
            this.copyAllForExcelToolStripMenuItem.Name = "copyAllForExcelToolStripMenuItem";
            this.copyAllForExcelToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.copyAllForExcelToolStripMenuItem.Text = "Copy all for Excel";
            this.copyAllForExcelToolStripMenuItem.Click += new System.EventHandler(this.copyToXlsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(302, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.findToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.toolStripMenuItem4,
            this.clearTraceWindowToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem,
            this.keepSelectedToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
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
            this.clearTraceWindowToolStripMenuItem.Image = global::ExpressProfiler.Properties.Resources.imClear;
            this.clearTraceWindowToolStripMenuItem.Name = "clearTraceWindowToolStripMenuItem";
            this.clearTraceWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.clearTraceWindowToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.clearTraceWindowToolStripMenuItem.Text = "Clear Trace Window";
            this.clearTraceWindowToolStripMenuItem.Click += new System.EventHandler(this.clearTraceWindowToolStripMenuItem_Click);
            // 
            // mnAbout
            // 
            this.mnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnAbout.Name = "mnAbout";
            this.mnAbout.Size = new System.Drawing.Size(48, 20);
            this.mnAbout.Text = "About";
            this.mnAbout.Click += new System.EventHandler(this.mnAbout_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stayOnTopToolStripMenuItem,
            this.transparentToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // stayOnTopToolStripMenuItem
            // 
            this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
            this.stayOnTopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.stayOnTopToolStripMenuItem.Text = "Stay on top";
            this.stayOnTopToolStripMenuItem.Click += new System.EventHandler(this.stayOnTopToolStripMenuItem_Click);
            // 
            // transparentToolStripMenuItem
            // 
            this.transparentToolStripMenuItem.Name = "transparentToolStripMenuItem";
            this.transparentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.transparentToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.transparentToolStripMenuItem.Text = "Transparent";
            this.transparentToolStripMenuItem.Click += new System.EventHandler(this.transparentToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // keepSelectedToolStripMenuItem
            // 
            this.keepSelectedToolStripMenuItem.Name = "keepSelectedToolStripMenuItem";
            this.keepSelectedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.keepSelectedToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.keepSelectedToolStripMenuItem.Text = "Keep selected";
            this.keepSelectedToolStripMenuItem.Click += new System.EventHandler(this.keepSelectedToolStripMenuItem_Click);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Express Profiler v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox tbAuth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbClear;
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
        private System.Windows.Forms.ToolStripSplitButton tbStart;
        private System.Windows.Forms.ToolStripMenuItem tbRun;
        private System.Windows.Forms.ToolStripMenuItem tbRunWithFilters;
        private System.Windows.Forms.ToolStripMenuItem mnRun;
        private System.Windows.Forms.ToolStripMenuItem mnRunWithFilters;
        private System.Windows.Forms.ToolStripStatusLabel slEPS;
        private System.Windows.Forms.ToolStripMenuItem copyToXlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnAbout;
        private System.Windows.Forms.ToolStripMenuItem copyAllForExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tbStayOnTop;
        private System.Windows.Forms.ToolStripButton tbTransparent;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepSelectedToolStripMenuItem;
    }
}

