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
                return new TraceSettings
                           {
                               EventsColumns = new TraceEventsColumns
                                                   {
                                                BatchCompleted = true,
                                                RPCCompleted = true
                                            },
                               Filters = new TraceFilters
                                             {
                                                 MaximumEventCount = 5000,
                                                 CpuFilterCondition = IntFilterCondition.GreaterThan,
                                                 ReadsFilterCondition = IntFilterCondition.GreaterThan,
                                                 WritesFilterCondition = IntFilterCondition.GreaterThan,
                                                 DurationFilterCondition = IntFilterCondition.GreaterThan
                                             }
                           };
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
                                                Database = EventsColumns.Database,
                                                EndTime = EventsColumns.EndTime,
                                                ObjectName = EventsColumns.ObjectName,
                                                StartTime = EventsColumns.StartTime
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
                                                  LoginNameFilterCondition = Filters.LoginNameFilterCondition,
                                                  Reads = Filters.Reads,
                                                  ReadsFilterCondition = Filters.ReadsFilterCondition,
                                                  TextData = Filters.TextData,
                                                  TextDataFilterCondition = Filters.TextDataFilterCondition,
                                                  Writes = Filters.Writes,
                                                  WritesFilterCondition = Filters.WritesFilterCondition,
                                                  MaximumEventCount = Filters.MaximumEventCount

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
            [DefaultValue(false)]
            public bool ExistingConnection { get; set; }
            [Category(@"Events")]
            [DisplayName(@"LoginLogout")]
            [DefaultValue(false)]
            public bool LoginLogout { get; set; }
            [Category(@"Events")]
            [DisplayName(@"RPC:Starting")]
            [DefaultValue(false)]
            public bool RPCStarting { get; set; }
            [Category(@"Events")]
            [DisplayName(@"RPC:Completed")]
            [DefaultValue(false)]
            public bool RPCCompleted { get; set; }
            [Category(@"Events")]
            [DisplayName(@"Batch:Starting")]
            [DefaultValue(false)]
            public bool BatchStarting { get; set; }
            [Category(@"Events")]
            [DisplayName(@"Batch:Completed")]
            [DefaultValue(false)]
            public bool BatchCompleted { get; set; }
            [Category(@"Events")]
            [DisplayName(@"SP:StmtCompleted")]
            [DefaultValue(false)]
            public bool SPStmtCompleted { get; set; }
            [Category(@"Events")]
            [DisplayName(@"SP:StmtStarting")]
            [DefaultValue(false)]
            public bool SPStmtStarting { get; set; }
            [Category(@"Events")]
            [DisplayName(@"User Error Message")]
            [DefaultValue(false)]
            public bool UserErrorMessage { get; set; }

            [Category(@"Columns")]
            [DisplayName(@"Start time")]
            [DefaultValue(false)]
            public bool StartTime { get; set; }
            [Category(@"Columns")]
            [DisplayName(@"End time")]
            [DefaultValue(false)]
            public bool EndTime { get; set; }
            [Category(@"Columns")]
            [DisplayName(@"Database")]
            [DefaultValue(false)]
            public bool Database { get; set; }
            [Category(@"Columns")]
            [DisplayName(@"Application name")]
            [DefaultValue(false)]
            public bool ApplicationName { get; set; }
            [Category(@"Columns")]
            [DisplayName(@"Object name")]
            [DefaultValue(false)]
            public bool ObjectName { get; set; }

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
            [DefaultValue(5000)]
            public int MaximumEventCount { get; set; }

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

    }
}
