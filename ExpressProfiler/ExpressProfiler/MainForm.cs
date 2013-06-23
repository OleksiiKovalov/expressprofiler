//sample application for demonstrating Sql Server Profiling
//writen by Locky, 2009.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;


namespace ExpressProfiler
{
    public partial class MainForm : Form
    {
        private enum ProfilingStateEnum { psStopped, psProfiling, psPaused }
        private RawTraceReader m_Rdr;

        private readonly  YukonLexer m_Lex = new YukonLexer();
        private SqlConnection m_Conn;
        private readonly SqlCommand m_Cmd = new SqlCommand();
        private Thread m_Thr;
        private bool m_NeedStop = true;
        private ProfilingStateEnum m_ProfilingState ;
        private int m_EventCount;
        private readonly ProfilerEvent m_EventStarted = new ProfilerEvent();
        private readonly ProfilerEvent m_EventStopped = new ProfilerEvent();
        private readonly ProfilerEvent m_EventPaused = new ProfilerEvent();
        internal readonly List<ListViewItem> m_Cached = new List<ListViewItem>(1024);
        private readonly Dictionary<string,ListViewItem> m_itembysql = new Dictionary<string, ListViewItem>();
        private string m_servername = "";
        private string m_username = "";
        private string m_userpassword = "";
        private int m_maxEvents = 1000;
        internal int lastpos = -1;
        internal string lastpattern = "";
        private ListViewNF lvEvents;
        Queue<ProfilerEvent> m_events = new Queue<ProfilerEvent>(10);
        private bool m_autostart;
        private bool dontUpdateSource;

        public MainForm()
        {
            InitializeComponent();
            InitLV();
            Text = "Express Profiler v1.5";
            edPassword.TextBox.PasswordChar = '*';
            m_servername = Properties.Settings.Default.ServerName;
            m_username = Properties.Settings.Default.UserName;
            edDuration.Text = Properties.Settings.Default.Duration.ToString(CultureInfo.InvariantCulture);
            int eventMask = Properties.Settings.Default.EventMask;
            mnExistingConnection.Checked = (eventMask & 1) != 0;
            mnLoginLogout.Checked = (eventMask & 2) != 0;
            mnRPCStarting.Checked = (eventMask & 4) != 0;
            mnRPCCompleted.Checked = (eventMask & 8) != 0;
            mnBatchStarting.Checked = (eventMask & 16) != 0;
            mnBatchCompleted.Checked = (eventMask & 32) != 0;
            mnSPStmtCompleted.Checked = (eventMask & 64) != 0;
            mnSPStmtStarting.Checked = (eventMask & 128) != 0;

            ParseCommandLine();
            edServer.Text = m_servername;
            edUser.Text = m_username;
            edPassword.Text = m_userpassword;
            tbAuth.SelectedIndex = String.IsNullOrEmpty(m_username)?0:1;
            if(m_autostart) StartProfiling();
            UpdateButtons();
        }

        private void ParseCommandLine()
        {
            string[] args = Environment.GetCommandLineArgs();
            int i = 1;
            while (i < args.Length)
            {
                string ep = i + 1 < args.Length ? args[i + 1] : "";
                switch (args[i].ToLower())
                {
                    case "-s":
                    case "-server":
                        m_servername = ep;
                        i++;
                        break;
                    case "-u":
                    case "-user":
                        m_username = ep;
                        i++;
                        break;
                    case "-p":
                    case "-password":
                        m_userpassword = ep;
                        i++;
                        break;
                    case "-m":
                    case "-maxevents":
                        if (!Int32.TryParse(ep, out m_maxEvents)) m_maxEvents = 1000;
                        break;
                    case "-d":
                    case "-duration":
                        int d;
                        if(Int32.TryParse(ep,out d)) edDuration.Text = d.ToString(CultureInfo.InvariantCulture);
                        break;
                    case "-start":
                        m_autostart = true;
                        break;
                }
                i++;
            }

            if (m_servername.Length == 0)
            {
                m_servername = @".\sqlexpress";
            }


        }
    
        private void tbStart_Click(object sender, EventArgs e)
        {
            StartProfiling();
        }

        private void UpdateButtons()
        {
            tbStart.Enabled = m_ProfilingState==ProfilingStateEnum.psStopped||m_ProfilingState==ProfilingStateEnum.psPaused;
            startTraceToolStripMenuItem.Enabled = tbStart.Enabled;
            tbStop.Enabled = m_ProfilingState==ProfilingStateEnum.psPaused||m_ProfilingState==ProfilingStateEnum.psProfiling;
            stopTraceToolStripMenuItem.Enabled = tbStop.Enabled;
            tbPause.Enabled = m_ProfilingState == ProfilingStateEnum.psProfiling;
            pauseTraceToolStripMenuItem.Enabled = tbPause.Enabled;
            timer1.Enabled = m_ProfilingState == ProfilingStateEnum.psProfiling;
            edServer.Enabled = m_ProfilingState == ProfilingStateEnum.psStopped;
            tbAuth.Enabled = m_ProfilingState == ProfilingStateEnum.psStopped;
            edDuration.Enabled = m_ProfilingState == ProfilingStateEnum.psStopped;
            edUser.Enabled = edServer.Enabled&&(tbAuth.SelectedIndex==1);
            edPassword.Enabled = edServer.Enabled && (tbAuth.SelectedIndex == 1);
            cbSelectEvents.Enabled = edServer.Enabled;
            mnBatchStarting.Enabled = mnBatchCompleted.Enabled;
            mnExistingConnection.Enabled = mnBatchCompleted.Enabled;
            mnRPCCompleted.Enabled = mnBatchCompleted.Enabled;
            mnLoginLogout.Enabled  = mnBatchCompleted.Enabled;
            mnRPCStarting.Enabled = mnBatchCompleted.Enabled;
            mnSPStmtCompleted.Enabled = mnBatchCompleted.Enabled;
            mnSPStmtStarting.Enabled = mnBatchCompleted.Enabled;
        }


        private void InitLV()
        {
            lvEvents = new ListViewNF
                           {
                               Dock = DockStyle.Fill,
                               Location = new System.Drawing.Point(0, 0),
                               Name = "lvEvents",
                               Size = new System.Drawing.Size(979, 297),
                               TabIndex = 0,
                               VirtualMode = true,
                               UseCompatibleStateImageBehavior = false,
                               BorderStyle = BorderStyle.None,
                               FullRowSelect = true,
                               View = View.Details,
                               GridLines = true,
                               HideSelection = false,
                               MultiSelect = false,
                               AllowColumnReorder = false
                           };
            lvEvents.RetrieveVirtualItem += lvEvents_RetrieveVirtualItem;
            lvEvents.KeyDown += lvEvents_KeyDown;
            lvEvents.ItemSelectionChanged += listView1_ItemSelectionChanged_1;
            lvEvents.Columns.Add("Event Class", 122);
            lvEvents.Columns.Add("Text Data", 255);
            lvEvents.Columns.Add("Login Name", 79);
            lvEvents.Columns.Add("CPU", 82).TextAlign = HorizontalAlignment.Right;
            lvEvents.Columns.Add("Reads", 78).TextAlign = HorizontalAlignment.Right;
            lvEvents.Columns.Add("Writes", 78).TextAlign = HorizontalAlignment.Right;
            lvEvents.Columns.Add("Duration, ms", 82).TextAlign = HorizontalAlignment.Right;
            lvEvents.Columns.Add("SPID", 50).TextAlign = HorizontalAlignment.Right;
            lvEvents.Columns.Add("Start time", 140).TextAlign = HorizontalAlignment.Left;
            lvEvents.Columns.Add("End time", 140).TextAlign = HorizontalAlignment.Left;
            lvEvents.Columns.Add("#", 53).TextAlign = HorizontalAlignment.Right;
            lvEvents.ColumnClick += lvEvents_ColumnClick;
            lvEvents.SelectedIndexChanged += lvEvents_SelectedIndexChanged;
            lvEvents.VirtualItemsSelectionRangeChanged += LvEventsOnVirtualItemsSelectionRangeChanged;
            lvEvents.MultiSelect = true;
            lvEvents.ContextMenuStrip = contextMenuStrip1;
            splitContainer1.Panel1.Controls.Add(lvEvents);
        }

        private void LvEventsOnVirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs listViewVirtualItemsSelectionRangeChangedEventArgs)
        {
            UpdateSourceBox();
        }

        void lvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSourceBox();
        }

        void lvEvents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
        }

        private void NewEventArrived(ProfilerEvent evt,bool last)
        {
            {
                m_EventCount++;
                string caption;
                if(evt==m_EventStarted)
                {
                    caption = "Trace started";
                }
                else
                    if(evt==m_EventPaused)
                {
                    caption = "Trace paused";
                }
                    else
                        if(evt==m_EventStopped)
                        {
                            caption = "Trace stopped";
                        }
                        else
                        {
                            caption = ProfilerEvents.Names[evt.EventClass];
                        }
                ListViewItem lvi = new ListViewItem(caption);
                string textData = evt.TextData;
                lvi.SubItems.AddRange(
                    new[]
                        {

                            textData, evt.LoginName, evt.CPU.ToString("#,0",CultureInfo.InvariantCulture), evt.Reads.ToString("#,0",CultureInfo.InvariantCulture)
                            , evt.Writes.ToString("#,0",CultureInfo.InvariantCulture), (evt.Duration/1000).ToString("#,0"), evt.SPID.ToString(CultureInfo.InvariantCulture)
                            ,evt.StartTime.Year==1?"":evt.StartTime.ToString("yyyy-MM-dd hh:mm:ss.ffff")
                            ,evt.EndTime.Year==1?"":evt.EndTime.ToString("yyyy-MM-dd hh:mm:ss.ffff")
                            , m_EventCount.ToString(CultureInfo.InvariantCulture),"","",""
                        }
                    );
                lvi.Tag = evt;//new ProfilerEvent();
                m_Cached.Add(lvi);
                if (last)
                {
                    lvEvents.VirtualListSize = m_Cached.Count;
                    lvEvents.SelectedIndices.Clear();
                    if (tbScroll.Checked)
                    {
                        FocusLVI(lvEvents.Items[m_Cached.Count - 1]);
//                        lvEvents.EnsureVisible(m_Cached.Count - 1);
                    }

                    lvEvents.Invalidate(lvi.Bounds);
                }
            }
        }

        internal void FocusLVI(ListViewItem lvi)
        {
            lvi.Focused = true;
            lvi.Selected = true;
            listView1_ItemSelectionChanged_1(lvEvents, null);
            lvEvents.EnsureVisible(lvEvents.Items.IndexOf(lvi));
        }

        private void ProfilerThread(Object state)
        {
            while (!m_NeedStop&&m_Rdr.TraceIsActive)
            {
                ProfilerEvent evt = m_Rdr.Next();
                if (evt != null)
                {
                    lock(this)
                    {
                        m_events.Enqueue(evt);
                    }
                }
            }
        }

        private  SqlConnection GetConnection()
        {
            return new SqlConnection
                       {
                           ConnectionString =
                           tbAuth.SelectedIndex==0?String.Format(@"Data Source = {0}; Initial Catalog = master; Integrated Security=SSPI;Application Name=Express Profiler",edServer.Text)
                           : String.Format(@"Data Source={0};Initial Catalog=master;User Id={1};Password={2};;Application Name=Express Profiler", edServer.Text, edUser.Text, edPassword.Text)
                       };
        }

        private void StartProfiling()
        {
            if(m_ProfilingState==ProfilingStateEnum.psPaused)
            {
                ResumeProfiling();
                return;
            }
            if(m_Conn!=null&&m_Conn.State==ConnectionState.Open)
            {
                m_Conn.Close();
            }
            m_EventCount = 0;
            m_Conn = GetConnection();
            m_Conn.Open();
            m_Rdr = new RawTraceReader(m_Conn);

            m_Rdr.CreateTrace();
            if (true)
            {
                if (mnLoginLogout.Checked)
                {
                    m_Rdr.SetEvent(ProfilerEvents.SecurityAudit.AuditLogin,
                                   ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                                   ProfilerEventColumns.SPID
                                   ,ProfilerEventColumns.StartTime,ProfilerEventColumns.EndTime
                                   );
                    m_Rdr.SetEvent(ProfilerEvents.SecurityAudit.AuditLogout,
                                   ProfilerEventColumns.CPU, ProfilerEventColumns.Reads,
                                   ProfilerEventColumns.Writes, ProfilerEventColumns.Duration,
                                   ProfilerEventColumns.LoginName,
                                   ProfilerEventColumns.SPID
                                   , ProfilerEventColumns.StartTime, ProfilerEventColumns.EndTime
                                   );
                }

                if (mnExistingConnection.Checked)
                {
                    m_Rdr.SetEvent(ProfilerEvents.Sessions.ExistingConnection,
                                   ProfilerEventColumns.TextData, ProfilerEventColumns.SPID
                                   , ProfilerEventColumns.StartTime, ProfilerEventColumns.EndTime
                                   );
                }
                if (mnBatchCompleted.Checked)
                {
                    m_Rdr.SetEvent(ProfilerEvents.TSQL.SQLBatchCompleted,
                                   ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                                   ProfilerEventColumns.CPU, ProfilerEventColumns.Reads,
                                   ProfilerEventColumns.Writes, ProfilerEventColumns.Duration,
                                   ProfilerEventColumns.SPID
                                   , ProfilerEventColumns.StartTime, ProfilerEventColumns.EndTime
                                   );
                }
                if (mnBatchStarting.Checked)
                {
                    m_Rdr.SetEvent(ProfilerEvents.TSQL.SQLBatchStarting,
                                   ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                                   ProfilerEventColumns.SPID
                                   ,ProfilerEventColumns.StartTime,ProfilerEventColumns.EndTime
                                   );
                }
                if (mnRPCStarting.Checked)
                {
                    m_Rdr.SetEvent(ProfilerEvents.StoredProcedures.RPCStarting,
                                   ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                                   ProfilerEventColumns.SPID
                                   ,ProfilerEventColumns.StartTime,ProfilerEventColumns.EndTime
                                   );
                }

            }
            if (mnRPCCompleted.Checked)
            {
                m_Rdr.SetEvent(ProfilerEvents.StoredProcedures.RPCCompleted,
                               ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                               ProfilerEventColumns.CPU, ProfilerEventColumns.Reads,
                               ProfilerEventColumns.Writes, ProfilerEventColumns.Duration,
                               ProfilerEventColumns.SPID
                               ,ProfilerEventColumns.StartTime,ProfilerEventColumns.EndTime
                               );
            }
            if (mnSPStmtCompleted.Checked)
            {
                m_Rdr.SetEvent(ProfilerEvents.StoredProcedures.SPStmtCompleted,
                               ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                               ProfilerEventColumns.CPU, ProfilerEventColumns.Reads,
                               ProfilerEventColumns.Writes, ProfilerEventColumns.Duration,
                               ProfilerEventColumns.SPID
                               , ProfilerEventColumns.StartTime, ProfilerEventColumns.EndTime
                    );
            }
            if (mnSPStmtStarting.Checked)
            {
                m_Rdr.SetEvent(ProfilerEvents.StoredProcedures.SPStmtStarting,
                               ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                               ProfilerEventColumns.CPU, ProfilerEventColumns.Reads,
                               ProfilerEventColumns.Writes, ProfilerEventColumns.Duration,
                               ProfilerEventColumns.SPID
                               , ProfilerEventColumns.StartTime, ProfilerEventColumns.EndTime
                    );
            }
            int dur;
            if (Int32.TryParse(edDuration.Text, out dur))
            {
                if (dur > 0)
                {
                    m_Rdr.SetFilter(ProfilerEventColumns.Duration, LogicalOperators.AND, ComparisonOperators.GreaterThanOrEqual, dur*1000);
                }
                Properties.Settings.Default.Duration = dur >= 0 ? dur : 0;
            }
            m_Cmd.Connection = m_Conn;
            m_Cmd.CommandTimeout = 0;
            m_Rdr.SetFilter(ProfilerEventColumns.ApplicationName, LogicalOperators.AND, ComparisonOperators.NotLike, "Express Profiler");
            m_Cached.Clear();
            m_events.Clear();
            m_itembysql.Clear();
            lvEvents.VirtualListSize = 0;
            StartProfilerThread();
            m_servername = edServer.Text;
            m_username = edUser.Text;
            Properties.Settings.Default.ServerName = m_servername;
            Properties.Settings.Default.UserName = tbAuth.SelectedIndex==0?"":m_username;
            int eventMask = 0;
            if (mnExistingConnection.Checked) eventMask |= 1;
            if (mnLoginLogout.Checked) eventMask |= 2;
            if (mnRPCStarting.Checked) eventMask |= 4;
            if (mnRPCCompleted.Checked) eventMask |= 8;
            if (mnBatchStarting.Checked) eventMask |= 16;
            if (mnBatchCompleted.Checked) eventMask |= 32;
            if (mnSPStmtCompleted.Checked) eventMask |= 64;
            if (mnSPStmtStarting.Checked) eventMask |= 128;
            Properties.Settings.Default.EventMask = eventMask;
            Properties.Settings.Default.Save();
            UpdateButtons();
        }

        private void StartProfilerThread()
        { 
            if(m_Rdr!=null)
            {
                m_Rdr.Close();
            }
            m_Rdr.StartTrace();
            m_Thr = new Thread(ProfilerThread) {IsBackground = true, Priority = ThreadPriority.Lowest};
            m_NeedStop = false;
            m_ProfilingState = ProfilingStateEnum.psProfiling;
            NewEventArrived(m_EventStarted,true);
            m_Thr.Start();
        }

        private void ResumeProfiling()
        {
            StartProfilerThread();
            UpdateButtons();
        }

        private void tbStop_Click(object sender, EventArgs e)
        {
            StopProfiling();
        }

        private void StopProfiling()
        {
            tbStop.Enabled = false;
            using (SqlConnection cn = GetConnection())
            {
                cn.Open();
                m_Rdr.StopTrace(cn);
                m_Rdr.CloseTrace(cn);
                cn.Close();
            }
            m_NeedStop = true;
            if (m_Thr.IsAlive)
            {
                m_Thr.Abort();
            }
            m_Thr.Join();
            m_ProfilingState = ProfilingStateEnum.psStopped;
            NewEventArrived(m_EventStopped,true);
            UpdateButtons();
        }

        private void listView1_ItemSelectionChanged_1(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            UpdateSourceBox();
        }

        private void UpdateSourceBox()
        {
            if (dontUpdateSource) return;
            StringBuilder sb = new StringBuilder();
            foreach (int i in lvEvents.SelectedIndices)
            {
                ListViewItem lv = m_Cached[i];
                if (lv.SubItems[1].Text != "")
                {
                    sb.AppendFormat("{0}\r\ngo\r\n", lv.SubItems[1].Text);
                }
            }
            m_Lex.FillRichEdit(reTextData, sb.ToString());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_ProfilingState==ProfilingStateEnum.psPaused||m_ProfilingState==ProfilingStateEnum.psProfiling)
            {
                StopProfiling();
            }
        }

        private void lvEvents_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = m_Cached[e.ItemIndex];
        }

        private void tbPause_Click(object sender, EventArgs e)
        {
            PauseProfiling();
        }

        private void PauseProfiling()
        {
            using (SqlConnection cn = GetConnection())
            {
                cn.Open();
                m_Rdr.StopTrace(cn);
                cn.Close();
            }
            m_ProfilingState = ProfilingStateEnum.psPaused;
            NewEventArrived(m_EventPaused,true);
            UpdateButtons();
        }


        internal void SelectAllEvents(bool select)
        {
            lock (m_Cached)
            {
                lvEvents.BeginUpdate();
                dontUpdateSource = true;
                try
                {

                    foreach (ListViewItem lv in m_Cached)
                    {
                        lv.Selected = select;
                    }
                }
                finally
                {
                    dontUpdateSource = false;
                    UpdateSourceBox();
                    lvEvents.EndUpdate();
                }
            }
        }

        private void lvEvents_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Queue<ProfilerEvent> saved;
            lock (this)
            {
                saved = m_events;
                m_events = new Queue<ProfilerEvent>(10);
            }
            lock (m_Cached)
            {
                while (0 != saved.Count)
                {
                    NewEventArrived(saved.Dequeue(), 0 == saved.Count);
                }
                if (m_Cached.Count > m_maxEvents)
                {
                    while (m_Cached.Count > m_maxEvents)
                    {
                        m_Cached.RemoveAt(0);
                    }
                    lvEvents.VirtualListSize = m_Cached.Count;
                    lvEvents.Invalidate();
                }
            }
        }

        private void existingConnectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem) sender).Checked = !((ToolStripMenuItem) sender).Checked;
            UpdateButtons();
        }

        private void tbAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void ClearTrace()
        {
            lock (lvEvents)
            {
                m_Cached.Clear();
                m_itembysql.Clear();
                lvEvents.VirtualListSize = 0;
                listView1_ItemSelectionChanged_1(lvEvents, null);
                lvEvents.Invalidate();
            }
        }

        private void tbClear_Click(object sender, EventArgs e)
        {
            ClearTrace();
        }

        private void NewAttribute(XmlNode node, string name, string value)
        {
            XmlAttribute attr = node.OwnerDocument.CreateAttribute(name);
            attr.Value = value;
            node.Attributes.Append(attr);
        }

        private void copyAllToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyEventsToClipboard(false);
        }

        private void CopyEventsToClipboard(bool copySelected)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("events");
            lock (m_Cached)
            {
                if (copySelected)
                {
                    foreach (int i in lvEvents.SelectedIndices)
                    {
                        CreateEventRow((ProfilerEvent)(m_Cached[i]).Tag, root);
                    }
                }
                else
                {
                    foreach (var i in m_Cached)
                    {
                        CreateEventRow((ProfilerEvent)i.Tag, root);
                    }
                }
            }
            doc.AppendChild(root);
            doc.PreserveWhitespace = true;
            using (StringWriter writer = new StringWriter())
            {
                XmlTextWriter textWriter = new XmlTextWriter(writer) {Formatting = Formatting.Indented};
                doc.Save(textWriter);
                Clipboard.SetText(writer.ToString());
            }
            MessageBox.Show("Event(s) data copied to clipboard", "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void CreateEventRow(ProfilerEvent evt, XmlNode root)
        {
            XmlNode row = root.OwnerDocument.CreateElement("event");
            NewAttribute(row, "EventClass", evt.EventClass.ToString(CultureInfo.InvariantCulture));
            NewAttribute(row, "CPU", evt.CPU.ToString(CultureInfo.InvariantCulture));
            NewAttribute(row, "Reads", evt.Reads.ToString(CultureInfo.InvariantCulture));
            NewAttribute(row, "Writes", evt.Writes.ToString(CultureInfo.InvariantCulture));
            NewAttribute(row, "Duration", evt.Duration.ToString(CultureInfo.InvariantCulture));
            NewAttribute(row, "SPID", evt.SPID.ToString(CultureInfo.InvariantCulture));
            NewAttribute(row, "LoginName", evt.LoginName);
            row.InnerText = evt.TextData;
            root.AppendChild(row);
        }

        private void copySelectedToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyEventsToClipboard(true);
        }

        private void clearTraceWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTrace();
        }

        private void extractAllEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyEventsToClipboard(false);
        }

        private void extractSelectedEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyEventsToClipboard(true);
        }

        private void startTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartProfiling();
        }

        private void pauseTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseProfiling();
        }

        private void stopTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopProfiling();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoFind();
        }

        private void DoFind()
        {
            if (m_ProfilingState == ProfilingStateEnum.psProfiling)
            {
                MessageBox.Show("You cannot find when trace is running", "ExpressProfiler", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            using (FindForm f = new FindForm())
            {
                f.mainForm = this;
                f.ShowDialog();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvEvents.Focused && (m_ProfilingState!=ProfilingStateEnum.psProfiling))
            {
                SelectAllEvents(true);
            }
            else
            if (reTextData.Focused)
            {
                reTextData.SelectAll();
            }
        }

        internal void PerformFind()
        {
            if(String.IsNullOrEmpty(lastpattern)) return;
            for (int i = lastpos = lvEvents.Items.IndexOf(lvEvents.FocusedItem) + 1; i < m_Cached.Count; i++)
            {
                ListViewItem lvi = m_Cached[i];
                ProfilerEvent evt = (ProfilerEvent)lvi.Tag;
                if (evt.TextData.Contains(lastpattern))
                {
                    lvi.Focused = true;
                    lastpos = i;
                    SelectAllEvents(false);
                    FocusLVI(lvi);
                    return;
                }
            }
            MessageBox.Show(String.Format("Failed to find \"{0}\". Searched to the end of data. ", lastpattern), "ExpressProfiler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_ProfilingState == ProfilingStateEnum.psProfiling)
            {
                MessageBox.Show("You cannot find when trace is running", "ExpressProfiler", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            PerformFind();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
