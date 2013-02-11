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
            this.tbStart = new System.Windows.Forms.ToolStripButton();
            this.tbPause = new System.Windows.Forms.ToolStripButton();
            this.tbStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbScroll = new System.Windows.Forms.ToolStripButton();
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reTextData = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.edDuration = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tbStart,
            this.tbPause,
            this.tbStop,
            this.toolStripSeparator1,
            this.tbScroll,
            this.toolStripSeparator5,
            this.toolStripButton1,
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(979, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.toolStripMenuItem2,
            this.mnBatchStarting,
            this.mnBatchCompleted});
            this.cbSelectEvents.Image = ((System.Drawing.Image)(resources.GetObject("cbSelectEvents.Image")));
            this.cbSelectEvents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cbSelectEvents.Name = "cbSelectEvents";
            this.cbSelectEvents.Size = new System.Drawing.Size(60, 22);
            this.cbSelectEvents.Text = "Options";
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reTextData);
            this.splitContainer1.Size = new System.Drawing.Size(979, 463);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 4;
            // 
            // reTextData
            // 
            this.reTextData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reTextData.Location = new System.Drawing.Point(0, 0);
            this.reTextData.Name = "reTextData";
            this.reTextData.ReadOnly = true;
            this.reTextData.Size = new System.Drawing.Size(979, 162);
            this.reTextData.TabIndex = 4;
            this.reTextData.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 510);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "Express Profiler v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
    }
}

