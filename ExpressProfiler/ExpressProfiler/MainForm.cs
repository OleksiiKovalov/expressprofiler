//sample application for demonstrating Sql Server Profiling
//writen by Locky, 2009.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;


namespace ExpressProfiler
{
    public partial class MainForm : Form
    {
        class EvtInfo
        {
            internal long Reads, Writes, Duration, Cpu, Count, LastDuration;
            internal string TextData,Caption;
        }
        private enum ProfilingStateEnum { psStopped, psProfiling, psPaused }
        private RawTraceReader m_Rdr;
        delegate void OnNewEventArrivedDelegate (ProfilerEvent evt);
        private readonly OnNewEventArrivedDelegate m_NewEventArriwedDelegate;
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
        private readonly List<ListViewItem> m_Cached = new List<ListViewItem>(1024);
        private readonly Dictionary<string,ListViewItem> m_itembysql = new Dictionary<string, ListViewItem>();
        private static readonly Dictionary<string, string> cursors = new Dictionary<string, string>(50);
        private static readonly Dictionary<string, string> statements = new Dictionary<string, string>(50);
        private string m_servername = "";
        private string m_username = "";
        private string m_userpassword = "";
        private int m_maxEvents = 1000;
        private ListViewNF lvEvents;
        Queue<ProfilerEvent> m_events = new Queue<ProfilerEvent>(10);

        public MainForm()
        {
            InitializeComponent();
            InitLV();
            Text = "Express Profiler v1.2";
            ParseCommandLine();
            edServer.Text = m_servername;
            edUser.Text = m_username;
            edPassword.Text = m_userpassword;
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
                }
                i++;
            }

            if (m_servername.Length == 0)
            {
                m_servername = @".\sqlexpress";
            }


        }
    
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StartProfiling();
        }

        private void UpdateButtons()
        {
            tbStart.Enabled = m_ProfilingState==ProfilingStateEnum.psStopped||m_ProfilingState==ProfilingStateEnum.psPaused;
            tbStop.Enabled = m_ProfilingState==ProfilingStateEnum.psPaused||m_ProfilingState==ProfilingStateEnum.psProfiling;
            tbPause.Enabled = m_ProfilingState == ProfilingStateEnum.psProfiling;
            timer1.Enabled = m_ProfilingState == ProfilingStateEnum.psProfiling;
            edServer.Enabled = m_ProfilingState == ProfilingStateEnum.psStopped;
            edUser.Enabled = edServer.Enabled;
            edPassword.Enabled = edServer.Enabled;
            cbSelectEvents.Enabled = edServer.Enabled;
            mnBatchStarting.Enabled = mnBatchCompleted.Enabled;
            mnExistingConnection.Enabled = mnBatchCompleted.Enabled;
            mnRPCCompleted.Enabled = mnBatchCompleted.Enabled;
            mnLoginLogout.Enabled  = mnBatchCompleted.Enabled;
            mnRPCStarting.Enabled = mnBatchCompleted.Enabled;
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
            lvEvents.Columns.Add("Duration", 82).TextAlign = HorizontalAlignment.Right;
            lvEvents.Columns.Add("SPID", 80);
            lvEvents.Columns.Add("#", 53);
            lvEvents.Columns.Add("Cnt", 53).TextAlign = HorizontalAlignment.Right;
            lvEvents.Columns.Add("Avg duration", 82).TextAlign = HorizontalAlignment.Right;
            lvEvents.Columns.Add("Last duration", 82).TextAlign = HorizontalAlignment.Right;
            lvEvents.ColumnClick += new ColumnClickEventHandler(lvEvents_ColumnClick);
            splitContainer1.Panel1.Controls.Add(lvEvents);
        }

        void lvEvents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
        }

        private void SetLVItemInfo(ListViewItem lvi, EvtInfo i)
        {
            lvi.SubItems[3].Text = i.Cpu.ToString("#,0");
            lvi.SubItems[4].Text = i.Reads.ToString("#,0");
            lvi.SubItems[5].Text = i.Writes.ToString("#,0");
            lvi.SubItems[6].Text = (i.Duration / 1000).ToString("#,0");
            lvi.SubItems[9].Text = i.Count.ToString("#,0");
            lvi.SubItems[10].Text = (i.Count == 0 ? "" : (i.Duration / 1000.0 / i.Count).ToString("#,0"));
            lvi.SubItems[11].Text = (i.LastDuration / 1000).ToString("#,0"); ;
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

                            textData, evt.LoginName, evt.CPU.ToString(), evt.Reads.ToString()
                            , evt.Writes.ToString(), (evt.Duration/1000).ToString("#,0"), evt.SPID.ToString()
                            , m_EventCount.ToString(),"","",""
                        }
                    );
                lvi.Tag = new ProfilerEvent();
                m_Cached.Add(lvi);
                if (last)
                {
                    lvEvents.VirtualListSize = m_Cached.Count;
                    if (tbScroll.Checked)
                    {
                        lvEvents.Items[m_Cached.Count - 1].Focused = true;
                        lvEvents.Items[m_Cached.Count - 1].Selected = true;
                        listView1_ItemSelectionChanged_1(lvEvents, null);
                        lvEvents.EnsureVisible(m_Cached.Count - 1);
                    }

                    lvEvents.Invalidate(lvi.Bounds);
                }
            }
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
                           edUser.Text==""?String.Format(@"Data Source = {0}; Initial Catalog = master; Integrated Security=SSPI;Application Name=Express Profiler",edServer.Text)
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
                                   ProfilerEventColumns.SPID);
                }

                if (mnExistingConnection.Checked)
                {
                    m_Rdr.SetEvent(ProfilerEvents.Sessions.ExistingConnection,
                                   ProfilerEventColumns.TextData, ProfilerEventColumns.SPID);
                }
                if (mnBatchCompleted.Checked)
                {
                    m_Rdr.SetEvent(ProfilerEvents.TSQL.SQLBatchCompleted,
                                   ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                                   ProfilerEventColumns.CPU, ProfilerEventColumns.Reads,
                                   ProfilerEventColumns.Writes, ProfilerEventColumns.Duration,
                                   ProfilerEventColumns.SPID,
                                   ProfilerEventColumns.StartTime);
                }
                if (mnBatchStarting.Checked)
                {
                    m_Rdr.SetEvent(ProfilerEvents.TSQL.SQLBatchStarting,
                                   ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                                   ProfilerEventColumns.SPID);
                }
                if (mnRPCStarting.Checked)
                {
                    m_Rdr.SetEvent(ProfilerEvents.StoredProcedures.RPCStarting,
                                   ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                                   ProfilerEventColumns.SPID);
                }
            }
            if (mnRPCCompleted.Checked)
            {
                m_Rdr.SetEvent(ProfilerEvents.StoredProcedures.RPCCompleted,
                               ProfilerEventColumns.TextData, ProfilerEventColumns.LoginName,
                               ProfilerEventColumns.CPU, ProfilerEventColumns.Reads,
                               ProfilerEventColumns.Writes, ProfilerEventColumns.Duration,
                               ProfilerEventColumns.SPID);
            }
            m_Cmd.Connection = m_Conn;
            m_Cmd.CommandTimeout = 0;
            m_Rdr.SetFilter(ProfilerEventColumns.ApplicationName, LogicalOperators.AND, ComparisonOperators.NotLike, "Express Profiler");
            m_Cached.Clear();
            m_events.Clear();
            m_itembysql.Clear();
            lvEvents.VirtualListSize = 0;
            StartProfilerThread();
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

        private void toolStripButton2_Click(object sender, EventArgs e)
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
            ListViewItem lvi = lvEvents.FocusedItem;
            if (lvi == null)
            {
                reTextData.Text = "";
            }
            else
            {
                m_Lex.FillRichEdit(reTextData, lvi.SubItems[1].Text);            
            }

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

        private void lvEvents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control &&e.Shift && e.KeyCode == Keys.Delete)
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

        }

        private class EventComparer:IComparer<EvtInfo>
        {
            private readonly int m_idx;
            public EventComparer(int idx)
            {
                m_idx = idx;
            }

            public int Compare(EvtInfo x, EvtInfo y)
                {
                double xa, ya;
                switch (m_idx)
                {
                    case 4:
                        xa = x.Reads;
                        ya = y.Reads;
                        break;
                    case 5:
                        xa = x.Writes;
                        ya = y.Writes;
                        break;
                    case 6:
                        xa = x.Duration;
                        ya = y.Duration;
                        break;
                    case 9:
                        xa = x.Count;
                        ya = y.Count;
                        break;
                    case 10:
                         xa = x.Count == 0 ? 0 : (x.Duration*1.0 / x.Count);
                         ya = y.Count == 0 ? 0 : (y.Duration*1.0 / y.Count);
                        break;
                    default:
                        return 0;
                }
                    return xa == ya ? String.Compare(x.TextData,y.TextData) : (xa > ya ? -1 : 1);
                }

        }


        private void Resort(int idx)
        {
            lock (m_Cached)
            {
                List<EvtInfo> lst = new List<EvtInfo>(m_itembysql.Count);
                foreach (ListViewItem lvi in m_itembysql.Values)
                {
                    lst.Add((EvtInfo)lvi.Tag);
                }
                lst.Sort(new EventComparer(idx));
                lvEvents.Items.Clear();
                m_Cached.Clear();
                m_itembysql.Clear();

                foreach(EvtInfo evt in lst)
                {
                    ListViewItem lvi = new ListViewItem("");
                    m_itembysql[evt.TextData] = lvi;
                    lvi.SubItems.AddRange(
                        new[]
                            {

                                evt.TextData, "", evt.Cpu.ToString(), evt.Reads.ToString()
                                , evt.Writes.ToString(), (evt.Duration/1000).ToString("#,0"), ""
                                , "","1",(evt.Duration/1000).ToString("#,0"),(evt.Duration/1000).ToString("#,0")
                            }
                        );
                    m_Cached.Add(lvi);
                    lvi.Tag = evt;
                    SetLVItemInfo(lvi,evt);
                }
                lvEvents.Invalidate();
            }
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
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            UpdateButtons();
        }
    }
}
