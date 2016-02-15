using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ExpressProfiler
{



    public partial class TraceProperties : Form
    {


        public enum StringFilterCondition
        {
            Like,
            NotLike
        }

        public enum IntFilterCondition
        {
            Equal,
            NotEqual,
            GreaterThan,
            LessThan
        }


        public static StringFilterCondition ParseStringCondition(string value)
        {
            switch(value.ToLower())
            {
                case "like":
                case "eq":
                case "=":       return StringFilterCondition.Like;
                case "notlike": return StringFilterCondition.NotLike;
            }
            throw new Exception("Unknown filter condition:"+value);
        }
        public static IntFilterCondition ParseIntCondition(string value)
        {
            switch (value.ToLower())
            {
                case "equal":
                case "eq":
                case "=":
                    return IntFilterCondition.Equal;
                case "notequal":
                case "ne":
                case "!=":
                case "<>": return IntFilterCondition.NotEqual;
                case "greaterthan":
                case "ge":
                case ">": return IntFilterCondition.GreaterThan;
                case "lessthan":
                case "le":
                case "<": return IntFilterCondition.LessThan;
            }
            throw new Exception("Unknown filter condition:" + value);
        }
        /*
         declare @xml xml
        set @xml = '<root>
        <r text="LoginName" type = "String" />
        <r text="TextData"  type = "String"/>
        <r text="DatabaseName"  type = "String"/>
        <r text="Duration"  type = "Int"/>
        <r text="Reads"  type = "Int"/>
        <r text="Writes"  type = "Int"/>
        <r text="CPU"  type = "Int"/>
        </root>'

        select		'
                    [Category(@"'+b.value('@text','varchar(512)')+'")]
                    [DisplayName(@"Condition")]
                    public '+b.value('@type','varchar(512)')+'FilterComparison '+replace(b.value('@text','varchar(512)'),' ','')+'FilterComparison { get; set; }
                    [Category(@"'+b.value('@text','varchar(512)')+'")]
                    [DisplayName(@"Value")]
                    public '+lower(b.value('@type','varchar(512)'))+' '+replace(b.value('@text','varchar(512)'),' ','')+ '{ get; set; }'

        from @xml.nodes('/root/r') a(b)
        order by b.value('@text','varchar(512)')
         */

        [Serializable]
        public class TraceSettings
        {
            public TraceEventsColumns EventsColumns;
            public TraceFilters Filters;

            public TraceSettings()
            {

                EventsColumns = new TraceEventsColumns
                                    {
                                        BatchCompleted = true,
                                        RPCCompleted = true,
                                        StartTime =  true,
                                        EndTime = true
                                    };
                Filters = new TraceFilters
                              {
                                  MaximumEventCount = 5000,
                                  CpuFilterCondition = IntFilterCondition.GreaterThan,
                                  ReadsFilterCondition = IntFilterCondition.GreaterThan,
                                  WritesFilterCondition = IntFilterCondition.GreaterThan,
                                  DurationFilterCondition = IntFilterCondition.GreaterThan
                              };
            }

            public string GetAsXmlString()
            {
                XmlSerializer x = new XmlSerializer(typeof(TraceSettings));
                using (StringWriter sw = new StringWriter())
                {
                    x.Serialize(sw,this);
                    return sw.ToString();
                }
            }

            public static TraceSettings GetDefaultSettings()
            {
                return new TraceSettings{};
            }

            public TraceSettings GetCopy()
            {
                return new TraceSettings
                           {
                               
                               EventsColumns = new TraceEventsColumns
                                                   {
                                                BatchCompleted = EventsColumns.BatchCompleted,
                                                BatchStarting = EventsColumns.BatchStarting,
                                                ExistingConnection = EventsColumns.ExistingConnection,
                                                LoginLogout = EventsColumns.LoginLogout,
                                                RPCCompleted = EventsColumns.RPCCompleted,
                                                RPCStarting = EventsColumns.RPCStarting,
                                                SPStmtCompleted = EventsColumns.SPStmtCompleted,
                                                SPStmtStarting = EventsColumns.SPStmtStarting,
                                                UserErrorMessage = EventsColumns.UserErrorMessage,
                                                ApplicationName = EventsColumns.ApplicationName,
                                                HostName = EventsColumns.HostName,
                                                DatabaseName = EventsColumns.DatabaseName,
                                                EndTime = EventsColumns.EndTime,
                                                ObjectName = EventsColumns.ObjectName,
                                                StartTime = EventsColumns.StartTime,
                                                BlockedProcessPeport =  EventsColumns.BlockedProcessPeport,
                                                SQLStmtStarting = EventsColumns.SQLStmtStarting,
                                                SQLStmtCompleted = EventsColumns.SQLStmtCompleted
                                            }
                               ,Filters =  new TraceFilters
                                               {
                                                  CPU = Filters.CPU,
                                                  CpuFilterCondition = Filters.CpuFilterCondition,
                                                  DatabaseName = Filters.DatabaseName,
                                                  DatabaseNameFilterCondition = Filters.DatabaseNameFilterCondition,
                                                  Duration = Filters.Duration,
                                                  DurationFilterCondition = Filters.DurationFilterCondition,
                                                  LoginName = Filters.LoginName,
                                                  HostName = Filters.HostName,
                                                  HostNameFilterCondition = Filters.HostNameFilterCondition,
                                                  LoginNameFilterCondition = Filters.LoginNameFilterCondition,
                                                  Reads = Filters.Reads,
                                                  ReadsFilterCondition = Filters.ReadsFilterCondition,
                                                  TextData = Filters.TextData,
                                                  TextDataFilterCondition = Filters.TextDataFilterCondition,
                                                  Writes = Filters.Writes,
                                                  WritesFilterCondition = Filters.WritesFilterCondition,
                                                  MaximumEventCount = Filters.MaximumEventCount,
                                                  SPID = Filters.SPID,
                                                  SPIDFilterCondition =  Filters.SPIDFilterCondition,
                                                  ApplicationName = Filters.ApplicationName,
                                                  ApplicationNameFilterCondition = Filters.ApplicationNameFilterCondition,

                                              }
                           }
                    ;
            }

        }

        internal TraceSettings m_currentsettings;
        [Serializable]
        public class TraceEventsColumns
        {
            [Category(@"Events")]
            [DisplayName(@"ExistingConnection")]
            [Description(@"The ExistingConnection event class indicates the properties of existing user connections when the trace was started. The server raises one ExistingConnection event per existing user connection.")]
            [DefaultValue(false)]
            public bool ExistingConnection { get; set; }
            [Category(@"Events")]
            [DisplayName(@"LoginLogout")]
            [Description(@"The Audit Login event class indicates that a user has successfully logged in to SQL Server. Events in this class are fired by new connections or by connections that are reused from a connection pool. The Audit Logout event class indicates that a user has logged out of (logged off) Microsoft SQL Server. Events in this class are fired by new connections or by connections that are reused from a connection pool.")]
            [DefaultValue(false)]
            public bool LoginLogout { get; set; }
            [Category(@"Events")]
            [DisplayName(@"RPC:Starting")]
            [Description(@"The RPC:Starting event class indicates that a remote procedure call has started.")]
            [DefaultValue(false)]
            public bool RPCStarting { get; set; }
            [Category(@"Events")]
            [DisplayName(@"RPC:Completed")]
            [Description(@"The RPC:Completed event class indicates that a remote procedure call has been completed. ")]
            [DefaultValue(false)]
            public bool RPCCompleted { get; set; }
            [Category(@"Events")]
            [DisplayName(@"SQL:BatchStarting")]
            [Description(@"The SQL:BatchStarting event class indicates that a Transact-SQL batch is starting.")]
            [DefaultValue(false)]
            public bool BatchStarting { get; set; }
            [Category(@"Events")]
            [DisplayName(@"SQL:BatchCompleted")]
            [Description(@"The SQL:BatchCompleted event class indicates that the Transact-SQL batch has completed. ")]
            [DefaultValue(false)]
            public bool BatchCompleted { get; set; }
            [Category(@"Events")]
            [DisplayName(@"SP:StmtCompleted")]
            [Description(@"The SP:StmtCompleted event class indicates that a Transact-SQL statement within a stored procedure has completed. ")]
            [DefaultValue(false)]
            public bool SPStmtCompleted { get; set; }
            [Category(@"Events")]
            [DisplayName(@"SP:StmtStarting")]
            [Description(@"The SP:StmtStarting event class indicates that a Transact-SQL statement within a stored procedure has started. ")]
            [DefaultValue(false)]
            public bool SPStmtStarting { get; set; }
            [Category(@"Events")]
            [DisplayName(@"User Error Message")]
            [Description(@"The User Error Message event class displays the error message as seen by the user in the case of an error or exception. The error message text appears in the TextData field.")]
            [DefaultValue(false)]
            public bool UserErrorMessage { get; set; }
            [Category(@"Events")]
            [DisplayName(@"Blocked process report")]
            [Description(@"The Blocked Process Report event class indicates that a task has been blocked for more than a specified amount of time. This event class does not include system tasks or tasks that are waiting on non deadlock-detectable resources.")]
            [DefaultValue(false)]
            public bool BlockedProcessPeport { get; set; }
            [Category(@"Events")]
            [DisplayName(@"SQL:StmtStarting")]
            [Description(@"The SQL:StmtStarting event class indicates that a Transact-SQL statement has started.")]
            [DefaultValue(false)]
            public bool SQLStmtStarting { get; set; }
            [Category(@"Events")]
            [DisplayName(@"SQL:StmtCompleted")]
            [Description(@"The SQL:StmtCompleted event class indicates that a Transact-SQL statement has completed. ")]
            [DefaultValue(false)]
            public bool SQLStmtCompleted { get; set; }




            [Category(@"Columns")]
            [DisplayName(@"Start time")]
            [Description(@"The time at which the event started, when available.")]
            [DefaultValue(false)]
            public bool StartTime { get; set; }
            [Category(@"Columns")]
            [DisplayName(@"End time")]
            [Description(@"The time at which the event ended. This column is not populated for event classes that refer to an event that is starting, such as SQL:BatchStarting or SP:Starting.")]
            [DefaultValue(false)]
            public bool EndTime { get; set; }
            [Category(@"Columns")]
            [DisplayName(@"DatabaseName")]
            [Description(@"The name of the database in which the user statement is running.")]
            [DefaultValue(false)]
            public bool DatabaseName { get; set; }
            [Category(@"Columns")]
            [DisplayName(@"Application name")]
            [Description(@"The name of the client application that created the connection to an instance of SQL Server. This column is populated with the values passed by the application and not the name of the program.")]
            [DefaultValue(false)]
            public bool ApplicationName { get; set; }
            [Category(@"Columns")]
            [DisplayName(@"Object name")]
            [Description(@"The name of the object that is referenced.")]
            [DefaultValue(false)]
            public bool ObjectName { get; set; }
            [Category(@"Columns")]
            [DisplayName(@"Host name")]
            [Description(@"Name of the client computer that originated the request.")]
            [DefaultValue(false)]
            public bool HostName { get; set; }

        }
        
        

                [Serializable]
        public class TraceFilters
        {

            [Category(@"CPU")]
            [DisplayName(@"Condition")]
            public IntFilterCondition CpuFilterCondition { get; set; }
            [Category(@"CPU")]
            [DisplayName(@"Value")]
            public int? CPU { get; set; }

            [Category(@"DatabaseName")]
            [DisplayName(@"Condition")]
            public StringFilterCondition DatabaseNameFilterCondition { get; set; }
            [Category(@"DatabaseName")]
            [DisplayName(@"Value")]
            public string DatabaseName { get; set; }

            [Category(@"Duration")]
            [DisplayName(@"Condition")]
            public IntFilterCondition DurationFilterCondition { get; set; }
            [Category(@"Duration")]
            [DisplayName(@"Value")]
            public int? Duration { get; set; }

            [Category(@"LoginName")]
            [DisplayName(@"Condition")]
            public StringFilterCondition LoginNameFilterCondition { get; set; }
            [Category(@"LoginName")]
            [DisplayName(@"Value")]
            public string LoginName { get; set; }

            [Category(@"HostName")]
            [DisplayName(@"Condition")]
            public StringFilterCondition HostNameFilterCondition { get; set; }
            [Category(@"HostName")]
            [DisplayName(@"Value")]
            public string HostName { get; set; }


            [Category(@"Reads")]
            [DisplayName(@"Condition")]
            public IntFilterCondition ReadsFilterCondition { get; set; }
            [Category(@"Reads")]
            [DisplayName(@"Value")]
            public int? Reads { get; set; }

            [Category(@"TextData")]
            [DisplayName(@"Condition")]
            public StringFilterCondition TextDataFilterCondition { get; set; }
            [Category(@"TextData")]
            [DisplayName(@"Value")]
            public string TextData { get; set; }

            [Category(@"Writes")]
            [DisplayName(@"Condition")]
            public IntFilterCondition WritesFilterCondition { get; set; }

            [Category(@"Writes")]
            [DisplayName(@"Value")]
            public int? Writes { get; set; }

            [Category(@"Maximum events count")]
            [DisplayName(@"Maximum events count")]
//            [DefaultValue(5000)]
            public int MaximumEventCount { get; set; }

            [Category(@"SPID")]
            [DisplayName(@"Condition")]
            public IntFilterCondition SPIDFilterCondition { get; set; }
            [Category(@"SPID")]
            [DisplayName(@"Value")]
            public int? SPID { get; set; }

            [Category(@"ApplicationName")]
            [DisplayName(@"Condition")]
            public StringFilterCondition ApplicationNameFilterCondition { get; set; }
            [Category(@"ApplicationName")]
            [DisplayName(@"Value")]
            public string ApplicationName { get; set; }

        }

        public TraceProperties()
        {
            InitializeComponent();
        }

        public void SetSettings(TraceSettings st)
        {
            m_currentsettings = st;
            edEvents.SelectedObject = m_currentsettings.EventsColumns;
            edFilters.SelectedObject = m_currentsettings.Filters;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SetSettings(TraceSettings.GetDefaultSettings());
        }

        private void btnSaveAsDefault_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TraceSettings = m_currentsettings.GetAsXmlString();
            Properties.Settings.Default.Save();
        }


        internal static bool AtLeastOneEventSelected(TraceSettings ts)
        {
            return ts.EventsColumns.BatchCompleted 
                    || ts.EventsColumns.BatchStarting 
                    || ts.EventsColumns.LoginLogout 
                    || ts.EventsColumns.ExistingConnection
                    || ts.EventsColumns.RPCCompleted 
                    || ts.EventsColumns.RPCStarting 
                    || ts.EventsColumns.SPStmtCompleted 
                    || ts.EventsColumns.SPStmtStarting
                    || ts.EventsColumns.UserErrorMessage
                    || ts.EventsColumns.BlockedProcessPeport
                    || ts.EventsColumns.SQLStmtStarting
                    || ts.EventsColumns.SQLStmtCompleted;

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!AtLeastOneEventSelected(m_currentsettings))
            {
                MessageBox.Show("You should select at least 1 event","Starting trace",MessageBoxButtons.OK,MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage2;
                return;
            }
            DialogResult = DialogResult.OK;
        }

	    public bool IsIncluded(ListViewItem lvi)
	    {
			bool included = true;

			//Fragile here to hard coding the columns, but they are currently this way.
			included &= IsIncluded(m_currentsettings.Filters.ApplicationNameFilterCondition, m_currentsettings.Filters.ApplicationName, lvi.SubItems[0].Text);
			included &= IsIncluded(m_currentsettings.Filters.TextDataFilterCondition, m_currentsettings.Filters.TextData, lvi.SubItems[1].Text);
			included &= IsIncluded(m_currentsettings.Filters.LoginNameFilterCondition, m_currentsettings.Filters.LoginName, lvi.SubItems[2].Text);
			included &= IsIncluded(m_currentsettings.Filters.CpuFilterCondition, m_currentsettings.Filters.CPU, lvi.SubItems[3].Text);
			included &= IsIncluded(m_currentsettings.Filters.ReadsFilterCondition, m_currentsettings.Filters.Reads, lvi.SubItems[4].Text);
			included &= IsIncluded(m_currentsettings.Filters.WritesFilterCondition, m_currentsettings.Filters.Writes, lvi.SubItems[5].Text);
			included &= IsIncluded(m_currentsettings.Filters.DurationFilterCondition, m_currentsettings.Filters.Duration, lvi.SubItems[6].Text);
			included &= IsIncluded(m_currentsettings.Filters.SPIDFilterCondition, m_currentsettings.Filters.SPID, lvi.SubItems[7].Text);

			return included;
	    }

		private bool IsIncluded(StringFilterCondition filterCondition, string filter, string entryToCheck)
		{
			bool included = true; //Until removed.  Negative logic is applied here.
			if (String.IsNullOrEmpty(filter)==false)
			{
				if (filterCondition == StringFilterCondition.Like)
				{
					if (entryToCheck.Contains(filter) == false)
					{
						included = false;
					}
				}
				else if (filterCondition == StringFilterCondition.NotLike)
				{
					if (entryToCheck.Contains(filter) == true)
					{
						included = false;
					}
				}
			}
			return included;
		}


		private bool IsIncluded(IntFilterCondition filterCondition, int? filter, string entryToCheck)
	    {
			bool included = true; //Until removed.  Negative logic is applied here.

			int intEntry;
			if ((Int32.TryParse(entryToCheck, out intEntry))&&(filter.HasValue))
			{
				if (filterCondition == IntFilterCondition.Equal)
				{
					if (filter != intEntry)
					{
						included = false;
					}
				}
				else if (filterCondition == IntFilterCondition.GreaterThan)
				{
					if (filter >= intEntry) // <= because we are using negative logic here.
					{
						included = false;
					}
				}
				else if (filterCondition == IntFilterCondition.LessThan)
				{
					if (filter <= intEntry) // >= because we are using negative logic here.
					{
						included = false;
					}
				}
				else if (filterCondition == IntFilterCondition.NotEqual)
				{
					if (filter == intEntry)
					{
						included = false;
					}
				}
			}
			return included;
	    }
    }
}
