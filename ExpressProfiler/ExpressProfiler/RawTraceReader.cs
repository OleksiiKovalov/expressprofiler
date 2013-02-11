//Traceutils assembly
//writen by Locky, 2009. 
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ExpressProfiler
{
    // ReSharper disable UnusedMember.Global
    // ReSharper disable InconsistentNaming

    public static class ComparisonOperators
    {
        public const int Equal = 0;
        public const int NotEqual = 1;
        public const int GreaterThan = 2;
        public const int LessThan = 3;
        public const int GreaterThanOrEqual = 4;
        public const int LessThanOrEqual = 5;
        public const int Like = 6;
        public const int NotLike = 7;
    }

    public static class LogicalOperators
    {
        public const int AND = 0;
        public const int OR = 1;
    }

    public static class ProfilerEvents
    {

        /*
        select 'public static class '+replace(name,' ','')+'
        {
        }

        ' 
        from sys.trace_categories
        order by category_id


        select '/ *'+sc.name+'* / '+'public const int '+replace(replace(ev.name,' ',''),':','')+' = '+cast(trace_event_id as varchar)+';'
        from	sys.trace_categories sc inner join sys.trace_events ev on sc.category_id = ev.category_id
        order by sc.category_id,ev.trace_event_id
            */
// ReSharper disable RedundantExplicitArraySize
        public static readonly string[] Names = new string[202]
// ReSharper restore RedundantExplicitArraySize
                                                    {
                                                        ""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,"RPC:Completed"
                                                        ,"RPC:Starting"
                                                        ,"SQL:BatchCompleted"
                                                        ,"SQL:BatchStarting"
                                                        ,"Audit Login"
                                                        ,"Audit Logout"
                                                        ,"Attention"
                                                        ,"ExistingConnection"
                                                        ,"Audit Server Starts And Stops"
                                                        ,"DTCTransaction"
                                                        ,"Audit Login Failed"
                                                        ,"EventLog"
                                                        ,"ErrorLog"
                                                        ,"Lock:Released"
                                                        ,"Lock:Acquired"
                                                        ,"Lock:Deadlock"
                                                        ,"Lock:Cancel"
                                                        ,"Lock:Timeout"
                                                        ,"Degree of Parallelism (7.0 Insert)"
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,"Exception"
                                                        ,"SP:CacheMiss"
                                                        ,"SP:CacheInsert"
                                                        ,"SP:CacheRemove"
                                                        ,"SP:Recompile"
                                                        ,"SP:CacheHit"
                                                        ,"Deprecated"
                                                        ,"SQL:StmtStarting"
                                                        ,"SQL:StmtCompleted"
                                                        ,"SP:Starting"
                                                        ,"SP:Completed"
                                                        ,"SP:StmtStarting"
                                                        ,"SP:StmtCompleted"
                                                        ,"Object:Created"
                                                        ,"Object:Deleted"
                                                        ,""
                                                        ,""
                                                        ,"SQLTransaction"
                                                        ,"Scan:Started"
                                                        ,"Scan:Stopped"
                                                        ,"CursorOpen"
                                                        ,"TransactionLog"
                                                        ,"Hash Warning"
                                                        ,""
                                                        ,""
                                                        ,"Auto Stats"
                                                        ,"Lock:Deadlock Chain"
                                                        ,"Lock:Escalation"
                                                        ,"OLEDB Errors"
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,""
                                                        ,"Execution Warnings"
                                                        ,"Showplan Text (Unencoded)"
                                                        ,"Sort Warnings"
                                                        ,"CursorPrepare"
                                                        ,"Prepare SQL"
                                                        ,"Exec Prepared SQL"
                                                        ,"Unprepare SQL"
                                                        ,"CursorExecute"
                                                        ,"CursorRecompile"
                                                        ,"CursorImplicitConversion"
                                                        ,"CursorUnprepare"
                                                        ,"CursorClose"
                                                        ,"Missing Column Statistics"
                                                        ,"Missing Join Predicate"
                                                        ,"Server Memory Change"
                                                        ,"UserConfigurable:0"
                                                        ,"UserConfigurable:1"
                                                        ,"UserConfigurable:2"
                                                        ,"UserConfigurable:3"
                                                        ,"UserConfigurable:4"
                                                        ,"UserConfigurable:5"
                                                        ,"UserConfigurable:6"
                                                        ,"UserConfigurable:7"
                                                        ,"UserConfigurable:8"
                                                        ,"UserConfigurable:9"
                                                        ,"Data File Auto Grow"
                                                        ,"Log File Auto Grow"
                                                        ,"Data File Auto Shrink"
                                                        ,"Log File Auto Shrink"
                                                        ,"Showplan Text"
                                                        ,"Showplan All"
                                                        ,"Showplan Statistics Profile"
                                                        ,""
                                                        ,"RPC Output Parameter"
                                                        ,""
                                                        ,"Audit Database Scope GDR Event"
                                                        ,"Audit Schema Object GDR Event"
                                                        ,"Audit Addlogin Event"
                                                        ,"Audit Login GDR Event"
                                                        ,"Audit Login Change Property Event"
                                                        ,"Audit Login Change Password Event"
                                                        ,"Audit Add Login to Server Role Event"
                                                        ,"Audit Add DB User Event"
                                                        ,"Audit Add Member to DB Role Event"
                                                        ,"Audit Add Role Event"
                                                        ,"Audit App Role Change Password Event"
                                                        ,"Audit Statement Permission Event"
                                                        ,"Audit Schema Object Access Event"
                                                        ,"Audit Backup/Restore Event"
                                                        ,"Audit DBCC Event"
                                                        ,"Audit Change Audit Event"
                                                        ,"Audit Object Derived Permission Event"
                                                        ,"OLEDB Call Event"
                                                        ,"OLEDB QueryInterface Event"
                                                        ,"OLEDB DataRead Event"
                                                        ,"Showplan XML"
                                                        ,"SQL:FullTextQuery"
                                                        ,"Broker:Conversation"
                                                        ,"Deprecation Announcement"
                                                        ,"Deprecation Final Support"
                                                        ,"Exchange Spill Event"
                                                        ,"Audit Database Management Event"
                                                        ,"Audit Database Object Management Event"
                                                        ,"Audit Database Principal Management Event"
                                                        ,"Audit Schema Object Management Event"
                                                        ,"Audit Server Principal Impersonation Event"
                                                        ,"Audit Database Principal Impersonation Event"
                                                        ,"Audit Server Object Take Ownership Event"
                                                        ,"Audit Database Object Take Ownership Event"
                                                        ,"Broker:Conversation Group"
                                                        ,"Blocked process report"
                                                        ,"Broker:Connection"
                                                        ,"Broker:Forwarded Message Sent"
                                                        ,"Broker:Forwarded Message Dropped"
                                                        ,"Broker:Message Classify"
                                                        ,"Broker:Transmission"
                                                        ,"Broker:Queue Disabled"
                                                        ,"Broker:Mirrored Route State Changed"
                                                        ,""
                                                        ,"Showplan XML Statistics Profile"
                                                        ,""
                                                        ,"Deadlock graph"
                                                        ,"Broker:Remote Message Acknowledgement"
                                                        ,"Trace File Close"
                                                        ,""
                                                        ,"Audit Change Database Owner"
                                                        ,"Audit Schema Object Take Ownership Event"
                                                        ,""
                                                        ,"FT:Crawl Started"
                                                        ,"FT:Crawl Stopped"
                                                        ,"FT:Crawl Aborted"
                                                        ,"Audit Broker Conversation"
                                                        ,"Audit Broker Login"
                                                        ,"Broker:Message Undeliverable"
                                                        ,"Broker:Corrupted Message"
                                                        ,"User Error Message"
                                                        ,"Broker:Activation"
                                                        ,"Object:Altered"
                                                        ,"Performance statistics"
                                                        ,"SQL:StmtRecompile"
                                                        ,"Database Mirroring State Change"
                                                        ,"Showplan XML For Query Compile"
                                                        ,"Showplan All For Query Compile"
                                                        ,"Audit Server Scope GDR Event"
                                                        ,"Audit Server Object GDR Event"
                                                        ,"Audit Database Object GDR Event"
                                                        ,"Audit Server Operation Event"
                                                        ,""
                                                        ,"Audit Server Alter Trace Event"
                                                        ,"Audit Server Object Management Event"
                                                        ,"Audit Server Principal Management Event"
                                                        ,"Audit Database Operation Event"
                                                        ,""
                                                        ,"Audit Database Object Access Event"
                                                        ,"TM: Begin Tran starting"
                                                        ,"TM: Begin Tran completed"
                                                        ,"TM: Promote Tran starting"
                                                        ,"TM: Promote Tran completed"
                                                        ,"TM: Commit Tran starting"
                                                        ,"TM: Commit Tran completed"
                                                        ,"TM: Rollback Tran starting"
                                                        ,"TM: Rollback Tran completed"
                                                        ,"Lock:Timeout (timeout > 0)"
                                                        ,"Progress Report: Online Index Operation"
                                                        ,"TM: Save Tran starting"
                                                        ,"TM: Save Tran completed"
                                                        ,"Background Job Error"
                                                        ,"OLEDB Provider Information"
                                                        ,"Mount Tape"
                                                        ,"Assembly Load"
                                                        ,""
                                                        ,"XQuery Static Type"
                                                        ,"QN: Subscription"
                                                        ,"QN: Parameter table"
                                                        ,"QN: Template"
                                               
                                                    }
                                        ;
        public static class Cursors
        {
            /*Cursors*/
            public const int CursorOpen = 53;
            /*Cursors*/
            public const int CursorPrepare = 70;
            /*Cursors*/
            public const int CursorExecute = 74;
            /*Cursors*/
            public const int CursorRecompile = 75;
            /*Cursors*/
            public const int CursorImplicitConversion = 76;
            /*Cursors*/
            public const int CursorUnprepare = 77;
            /*Cursors*/
            public const int CursorClose = 78;
        }

        public static class Database
        {
            /*Database*/
            public const int DataFileAutoGrow = 92;
            /*Database*/
            public const int LogFileAutoGrow = 93;
            /*Database*/
            public const int DataFileAutoShrink = 94;
            /*Database*/
            public const int LogFileAutoShrink = 95;
            /*Database*/
            public const int DatabaseMirroringStateChange = 167;
        }

        public static class ErrorsAndWarnings
        {
            /*Errors and Warnings*/
            public const int Attention = 16;
            /*Errors and Warnings*/
            public const int EventLog = 21;
            /*Errors and Warnings*/
            public const int ErrorLog = 22;
            /*Errors and Warnings*/
            public const int Exception = 33;
            /*Errors and Warnings*/
            public const int HashWarning = 55;
            /*Errors and Warnings*/
            public const int ExecutionWarnings = 67;
            /*Errors and Warnings*/
            public const int SortWarnings = 69;
            /*Errors and Warnings*/
            public const int MissingColumnStatistics = 79;
            /*Errors and Warnings*/
            public const int MissingJoinPredicate = 80;
            /*Errors and Warnings*/
            public const int ExchangeSpillEvent = 127;
            /*Errors and Warnings*/
            public const int Blockedprocessreport = 137;
            /*Errors and Warnings*/
            public const int UserErrorMessage = 162;
            /*Errors and Warnings*/
            public const int BackgroundJobError = 193;
        }

        public static class Locks
        {
            /*Locks*/
            public const int LockReleased = 23;
            /*Locks*/
            public const int LockAcquired = 24;
            /*Locks*/
            public const int LockDeadlock = 25;
            /*Locks*/
            public const int LockCancel = 26;
            /*Locks*/
            public const int LockTimeout = 27;
            /*Locks*/
            public const int LockDeadlockChain = 59;
            /*Locks*/
            public const int LockEscalation = 60;
            /*Locks*/
            public const int Deadlockgraph = 148;
            /*Locks*/
            public const int LockTimeout100 = 189;
        }

        public static class Objects
        {
            /*Objects*/
            public const int ObjectCreated = 46;
            /*Objects*/
            public const int ObjectDeleted = 47;
            /*Objects*/
            public const int ObjectAltered = 164;
        }

        public static class Performance
        {
            /*Performance*/
            public const int DegreeofParallelism70Insert = 28;
            /*Performance*/
            public const int AutoStats = 58;
            /*Performance*/
            public const int ShowplanTextUnencoded = 68;
            /*Performance*/
            public const int ShowplanText = 96;
            /*Performance*/
            public const int ShowplanAll = 97;
            /*Performance*/
            public const int ShowplanStatisticsProfile = 98;
            /*Performance*/
            public const int ShowplanXML = 122;
            /*Performance*/
            public const int SQLFullTextQuery = 123;
            /*Performance*/
            public const int ShowplanXMLStatisticsProfile = 146;
            /*Performance*/
            public const int Performancestatistics = 165;
            /*Performance*/
            public const int ShowplanXMLForQueryCompile = 168;
            /*Performance*/
            public const int ShowplanAllForQueryCompile = 169;
        }

        public static class Scans
        {
            /*Scans*/
            public const int ScanStarted = 51;
            /*Scans*/
            public const int ScanStopped = 52;
        }

        public static class SecurityAudit
        {
            /*Security Audit*/
            public const int AuditLogin = 14;
            /*Security Audit*/
            public const int AuditLogout = 15;
            /*Security Audit*/
            public const int AuditServerStartsAndStops = 18;
            /*Security Audit*/
            public const int AuditLoginFailed = 20;
            /*Security Audit*/
            public const int AuditDatabaseScopeGDREvent = 102;
            /*Security Audit*/
            public const int AuditSchemaObjectGDREvent = 103;
            /*Security Audit*/
            public const int AuditAddloginEvent = 104;
            /*Security Audit*/
            public const int AuditLoginGDREvent = 105;
            /*Security Audit*/
            public const int AuditLoginChangePropertyEvent = 106;
            /*Security Audit*/
            public const int AuditLoginChangePasswordEvent = 107;
            /*Security Audit*/
            public const int AuditAddLogintoServerRoleEvent = 108;
            /*Security Audit*/
            public const int AuditAddDBUserEvent = 109;
            /*Security Audit*/
            public const int AuditAddMembertoDBRoleEvent = 110;
            /*Security Audit*/
            public const int AuditAddRoleEvent = 111;
            /*Security Audit*/
            public const int AuditAppRoleChangePasswordEvent = 112;
            /*Security Audit*/
            public const int AuditStatementPermissionEvent = 113;
            /*Security Audit*/
            public const int AuditSchemaObjectAccessEvent = 114;
            /*Security Audit*/
            public const int AuditBackupRestoreEvent = 115;
            /*Security Audit*/
            public const int AuditDBCCEvent = 116;
            /*Security Audit*/
            public const int AuditChangeAuditEvent = 117;
            /*Security Audit*/
            public const int AuditObjectDerivedPermissionEvent = 118;
            /*Security Audit*/
            public const int AuditDatabaseManagementEvent = 128;
            /*Security Audit*/
            public const int AuditDatabaseObjectManagementEvent = 129;
            /*Security Audit*/
            public const int AuditDatabasePrincipalManagementEvent = 130;
            /*Security Audit*/
            public const int AuditSchemaObjectManagementEvent = 131;
            /*Security Audit*/
            public const int AuditServerPrincipalImpersonationEvent = 132;
            /*Security Audit*/
            public const int AuditDatabasePrincipalImpersonationEvent = 133;
            /*Security Audit*/
            public const int AuditServerObjectTakeOwnershipEvent = 134;
            /*Security Audit*/
            public const int AuditDatabaseObjectTakeOwnershipEvent = 135;
            /*Security Audit*/
            public const int AuditChangeDatabaseOwner = 152;
            /*Security Audit*/
            public const int AuditSchemaObjectTakeOwnershipEvent = 153;
            /*Security Audit*/
            public const int AuditBrokerConversation = 158;
            /*Security Audit*/
            public const int AuditBrokerLogin = 159;
            /*Security Audit*/
            public const int AuditServerScopeGDREvent = 170;
            /*Security Audit*/
            public const int AuditServerObjectGDREvent = 171;
            /*Security Audit*/
            public const int AuditDatabaseObjectGDREvent = 172;
            /*Security Audit*/
            public const int AuditServerOperationEvent = 173;
            /*Security Audit*/
            public const int AuditServerAlterTraceEvent = 175;
            /*Security Audit*/
            public const int AuditServerObjectManagementEvent = 176;
            /*Security Audit*/
            public const int AuditServerPrincipalManagementEvent = 177;
            /*Security Audit*/
            public const int AuditDatabaseOperationEvent = 178;
            /*Security Audit*/
            public const int AuditDatabaseObjectAccessEvent = 180;
        }

        public static class Server
        {
            /*Server*/
            public const int ServerMemoryChange = 81;
            /*Server*/
            public const int TraceFileClose = 150;
            /*Server*/
            public const int MountTape = 195;
        }

        public static class Sessions
        {
            /*Sessions*/
            public const int ExistingConnection = 17;
        }

        public static class StoredProcedures
        {
            /*Stored Procedures*/
            public const int RPCCompleted = 10;
            /*Stored Procedures*/
            public const int RPCStarting = 11;
            /*Stored Procedures*/
            public const int SPCacheMiss = 34;
            /*Stored Procedures*/
            public const int SPCacheInsert = 35;
            /*Stored Procedures*/
            public const int SPCacheRemove = 36;
            /*Stored Procedures*/
            public const int SPRecompile = 37;
            /*Stored Procedures*/
            public const int SPCacheHit = 38;
            /*Stored Procedures*/
            public const int Deprecated = 39;
            /*Stored Procedures*/
            public const int SPStarting = 42;
            /*Stored Procedures*/
            public const int SPCompleted = 43;
            /*Stored Procedures*/
            public const int SPStmtStarting = 44;
            /*Stored Procedures*/
            public const int SPStmtCompleted = 45;
            /*Stored Procedures*/
            public const int RPCOutputParameter = 100;
        }

        public static class Transactions
        {
            /*Transactions*/
            public const int DTCTransaction = 19;
            /*Transactions*/
            public const int SQLTransaction = 50;
            /*Transactions*/
            public const int TransactionLog = 54;
            /*Transactions*/
            public const int TMBeginTranstarting = 181;
            /*Transactions*/
            public const int TMBeginTrancompleted = 182;
            /*Transactions*/
            public const int TMPromoteTranstarting = 183;
            /*Transactions*/
            public const int TMPromoteTrancompleted = 184;
            /*Transactions*/
            public const int TMCommitTranstarting = 185;
            /*Transactions*/
            public const int TMCommitTrancompleted = 186;
            /*Transactions*/
            public const int TMRollbackTranstarting = 187;
            /*Transactions*/
            public const int TMRollbackTrancompleted = 188;
            /*Transactions*/
            public const int TMSaveTranstarting = 191;
            /*Transactions*/
            public const int TMSaveTrancompleted = 192;
        }

        public static class TSQL
        {
            /*TSQL*/
            public const int SQLBatchCompleted = 12;
            /*TSQL*/
            public const int SQLBatchStarting = 13;
            /*TSQL*/
            public const int SQLStmtStarting = 40;
            /*TSQL*/
            public const int SQLStmtCompleted = 41;
            /*TSQL*/
            public const int PrepareSQL = 71;
            /*TSQL*/
            public const int ExecPreparedSQL = 72;
            /*TSQL*/
            public const int UnprepareSQL = 73;
            /*TSQL*/
            public const int SQLStmtRecompile = 166;
            /*TSQL*/
            public const int XQueryStaticType = 198;
        }

        public static class Userconfigurable
        {
            /*User configurable*/
            public const int UserConfigurable0 = 82;
            /*User configurable*/
            public const int UserConfigurable1 = 83;
            /*User configurable*/
            public const int UserConfigurable2 = 84;
            /*User configurable*/
            public const int UserConfigurable3 = 85;
            /*User configurable*/
            public const int UserConfigurable4 = 86;
            /*User configurable*/
            public const int UserConfigurable5 = 87;
            /*User configurable*/
            public const int UserConfigurable6 = 88;
            /*User configurable*/
            public const int UserConfigurable7 = 89;
            /*User configurable*/
            public const int UserConfigurable8 = 90;
            /*User configurable*/
            public const int UserConfigurable9 = 91;
        }

        public static class OLEDB
        {
            /*OLEDB*/
            public const int OLEDBErrors = 61;
            /*OLEDB*/
            public const int OLEDBCallEvent = 119;
            /*OLEDB*/
            public const int OLEDBQueryInterfaceEvent = 120;
            /*OLEDB*/
            public const int OLEDBDataReadEvent = 121;
            /*OLEDB*/
            public const int OLEDBProviderInformation = 194;
        }

        public static class Broker
        {
            /*Broker*/
            public const int BrokerConversation = 124;
            /*Broker*/
            public const int BrokerConversationGroup = 136;
            /*Broker*/
            public const int BrokerConnection = 138;
            /*Broker*/
            public const int BrokerForwardedMessageSent = 139;
            /*Broker*/
            public const int BrokerForwardedMessageDropped = 140;
            /*Broker*/
            public const int BrokerMessageClassify = 141;
            /*Broker*/
            public const int BrokerTransmission = 142;
            /*Broker*/
            public const int BrokerQueueDisabled = 143;
            /*Broker*/
            public const int BrokerMirroredRouteStateChanged = 144;
            /*Broker*/
            public const int BrokerRemoteMessageAcknowledgement = 149;
            /*Broker*/
            public const int BrokerMessageUndeliverable = 160;
            /*Broker*/
            public const int BrokerCorruptedMessage = 161;
            /*Broker*/
            public const int BrokerActivation = 163;
        }

        public static class Fulltext
        {
            /*Full text*/
            public const int FTCrawlStarted = 155;
            /*Full text*/
            public const int FTCrawlStopped = 156;
            /*Full text*/
            public const int FTCrawlAborted = 157;
        }

        public static class Deprecation
        {
            /*Deprecation*/
            public const int DeprecationAnnouncement = 125;
            /*Deprecation*/
            public const int DeprecationFinalSupport = 126;
        }

        public static class ProgressReport
        {
            /*Progress Report*/
            public const int ProgressReportOnlineIndexOperation = 190;
        }

        public static class CLR
        {
            /*CLR*/
            public const int AssemblyLoad = 196;
        }

        public static class QueryNotifications
        {
            /*Query Notifications*/
            public const int QNSubscription = 199;
            /*Query Notifications*/
            public const int QNParametertable = 200;
            /*Query Notifications*/
            public const int QNTemplate = 201;
            /*Query Notifications*/
            public const int QNDynamics = 202;
        }
    }

    public static class ProfilerEventColumns
    {
        /*
        select 'public const int '+Name + '= '+cast(trace_column_id as varchar)+';'
        from sys.trace_columns
        order by trace_column_id
         */
        public const int TextData = 1;
        public const int BinaryData = 2;
        public const int DatabaseID = 3;
        public const int TransactionID = 4;
        public const int LineNumber = 5;
        public const int NTUserName = 6;
        public const int NTDomainName = 7;
        public const int HostName = 8;
        public const int ClientProcessID = 9;
        public const int ApplicationName = 10;
        public const int LoginName = 11;
        public const int SPID = 12;
        public const int Duration = 13;
        public const int StartTime = 14;
        public const int EndTime = 15;
        public const int Reads = 16;
        public const int Writes = 17;
        public const int CPU = 18;
        public const int Permissions = 19;
        public const int Severity = 20;
        public const int EventSubClass = 21;
        public const int ObjectID = 22;
        public const int Success = 23;
        public const int IndexID = 24;
        public const int IntegerData = 25;
        public const int ServerName = 26;
        public const int EventClass = 27;
        public const int ObjectType = 28;
        public const int NestLevel = 29;
        public const int State = 30;
        public const int Error = 31;
        public const int Mode = 32;
        public const int Handle = 33;
        public const int ObjectName = 34;
        public const int DatabaseName = 35;
        public const int FileName = 36;
        public const int OwnerName = 37;
        public const int RoleName = 38;
        public const int TargetUserName = 39;
        public const int DBUserName = 40;
        public const int LoginSid = 41;
        public const int TargetLoginName = 42;
        public const int TargetLoginSid = 43;
        public const int ColumnPermissions = 44;
        public const int LinkedServerName = 45;
        public const int ProviderName = 46;
        public const int MethodName = 47;
        public const int RowCounts = 48;
        public const int RequestID = 49;
        public const int XactSequence = 50;
        public const int EventSequence = 51;
        public const int BigintData1 = 52;
        public const int BigintData2 = 53;
        public const int GUID = 54;
        public const int IntegerData2 = 55;
        public const int ObjectID2 = 56;
        public const int Type = 57;
        public const int OwnerID = 58;
        public const int ParentName = 59;
        public const int IsSystem = 60;
        public const int Offset = 61;
        public const int SourceDatabaseID = 62;
        public const int SqlHandle = 63;
        public const int SessionLoginName = 64;
        public const int PlanHandle = 65;
    }
    // ReSharper restore UnusedMember.Global
    // ReSharper restore InconsistentNaming

    public class ProfilerEvent
    {
        internal readonly Object[] m_Events = new object[65];
        internal ulong m_ColumnMask;
        // ReSharper disable UnusedMember.Global
        // ReSharper disable InconsistentNaming

        private int GetInt(int idx)
        {
            if (!ColumnIsSet(idx)) return 0;
            return m_Events[idx] == null ? 0 : (int)m_Events[idx];
        }

        private long GetLong(int idx)
        {
            if (!ColumnIsSet(idx)) return 0;
            return m_Events[idx] == null ? 0 : (long)m_Events[idx];
        }

        private string GetString(int idx)
        {
            if (!ColumnIsSet(idx)) return "";
            return m_Events[idx] == null ? "" : (string)m_Events[idx];
        }

        private  byte[] GetByte(int idx)
        {
            return ColumnIsSet(idx)?(byte[])m_Events[idx]:new byte[1];
        }

        private DateTime GetDateTime(int idx)
        {
            return ColumnIsSet(idx) ? (DateTime) m_Events[idx] : new DateTime(0);
        }

        private Guid GetGuid(int idx)
        {
            return ColumnIsSet(idx) ? (Guid) m_Events[idx] : Guid.Empty;
        }

// ReSharper disable MemberCanBePrivate.Global
        public bool ColumnIsSet(int columnId)
// ReSharper restore MemberCanBePrivate.Global
        {
            return (m_ColumnMask & (1UL << columnId)) != 0;
        }


        /*        
select 'public '+case Type_Name
						when 'text' then 'string'
						when 'int' then 'int'
						when 'bigint' then 'long'
						when 'nvarchar' then 'string'
						when 'datetime' then 'DateTime'
						when 'image' then 'byte[]'
						when 'uniqueidentifier' then 'GUID'
				end
+' '+Name + '{get{ return Get'+
case Type_Name
						when 'text' then 'String'
						when 'int' then 'Int'
						when 'bigint' then 'Long'
						when 'nvarchar' then 'String'
						when 'datetime' then 'DateTime'
						when 'image' then 'Byte'
						when 'uniqueidentifier' then 'Guid'
				end
+'(ProfilerEventColumns.'+Name+');}}'
from sys.trace_columns
order by trace_column_id
 
         * 
         */

        public string TextData { get { return GetString(ProfilerEventColumns.TextData); } }
        public byte[] BinaryData { get { return GetByte(ProfilerEventColumns.BinaryData); } }
        public int DatabaseID { get { return GetInt(ProfilerEventColumns.DatabaseID); } }
        public long TransactionID { get { return GetLong(ProfilerEventColumns.TransactionID); } }
        public int LineNumber { get { return GetInt(ProfilerEventColumns.LineNumber); } }
        public string NTUserName { get { return GetString(ProfilerEventColumns.NTUserName); } }
        public string NTDomainName { get { return GetString(ProfilerEventColumns.NTDomainName); } }
        public string HostName { get { return GetString(ProfilerEventColumns.HostName); } }
        public int ClientProcessID { get { return GetInt(ProfilerEventColumns.ClientProcessID); } }
        public string ApplicationName { get { return GetString(ProfilerEventColumns.ApplicationName); } }
        public string LoginName { get { return GetString(ProfilerEventColumns.LoginName); } }
        public int SPID { get { return GetInt(ProfilerEventColumns.SPID); } }
        public long Duration { get { return GetLong(ProfilerEventColumns.Duration); } }
        public DateTime StartTime { get { return GetDateTime(ProfilerEventColumns.StartTime); } }
        public DateTime EndTime { get { return GetDateTime(ProfilerEventColumns.EndTime); } }
        public long Reads { get { return GetLong(ProfilerEventColumns.Reads); } }
        public long Writes { get { return GetLong(ProfilerEventColumns.Writes); } }
        public int CPU { get { return GetInt(ProfilerEventColumns.CPU); } }
        public long Permissions { get { return GetLong(ProfilerEventColumns.Permissions); } }
        public int Severity { get { return GetInt(ProfilerEventColumns.Severity); } }
        public int EventSubClass { get { return GetInt(ProfilerEventColumns.EventSubClass); } }
        public int ObjectID { get { return GetInt(ProfilerEventColumns.ObjectID); } }
        public int Success { get { return GetInt(ProfilerEventColumns.Success); } }
        public int IndexID { get { return GetInt(ProfilerEventColumns.IndexID); } }
        public int IntegerData { get { return GetInt(ProfilerEventColumns.IntegerData); } }
        public string ServerName { get { return GetString(ProfilerEventColumns.ServerName); } }
        public int EventClass { get { return GetInt(ProfilerEventColumns.EventClass); } }
        public int ObjectType { get { return GetInt(ProfilerEventColumns.ObjectType); } }
        public int NestLevel { get { return GetInt(ProfilerEventColumns.NestLevel); } }
        public int State { get { return GetInt(ProfilerEventColumns.State); } }
        public int Error { get { return GetInt(ProfilerEventColumns.Error); } }
        public int Mode { get { return GetInt(ProfilerEventColumns.Mode); } }
        public int Handle { get { return GetInt(ProfilerEventColumns.Handle); } }
        public string ObjectName { get { return GetString(ProfilerEventColumns.ObjectName); } }
        public string DatabaseName { get { return GetString(ProfilerEventColumns.DatabaseName); } }
        public string FileName { get { return GetString(ProfilerEventColumns.FileName); } }
        public string OwnerName { get { return GetString(ProfilerEventColumns.OwnerName); } }
        public string RoleName { get { return GetString(ProfilerEventColumns.RoleName); } }
        public string TargetUserName { get { return GetString(ProfilerEventColumns.TargetUserName); } }
        public string DBUserName { get { return GetString(ProfilerEventColumns.DBUserName); } }
        public byte[] LoginSid { get { return GetByte(ProfilerEventColumns.LoginSid); } }
        public string TargetLoginName { get { return GetString(ProfilerEventColumns.TargetLoginName); } }
        public byte[] TargetLoginSid { get { return GetByte(ProfilerEventColumns.TargetLoginSid); } }
        public int ColumnPermissions { get { return GetInt(ProfilerEventColumns.ColumnPermissions); } }
        public string LinkedServerName { get { return GetString(ProfilerEventColumns.LinkedServerName); } }
        public string ProviderName { get { return GetString(ProfilerEventColumns.ProviderName); } }
        public string MethodName { get { return GetString(ProfilerEventColumns.MethodName); } }
        public long RowCounts { get { return GetLong(ProfilerEventColumns.RowCounts); } }
        public int RequestID { get { return GetInt(ProfilerEventColumns.RequestID); } }
        public long XactSequence { get { return GetLong(ProfilerEventColumns.XactSequence); } }
        public long EventSequence { get { return GetLong(ProfilerEventColumns.EventSequence); } }
        public long BigintData1 { get { return GetLong(ProfilerEventColumns.BigintData1); } }
        public long BigintData2 { get { return GetLong(ProfilerEventColumns.BigintData2); } }
        public Guid GUID { get { return GetGuid(ProfilerEventColumns.GUID); } }
        public int IntegerData2 { get { return GetInt(ProfilerEventColumns.IntegerData2); } }
        public long ObjectID2 { get { return GetLong(ProfilerEventColumns.ObjectID2); } }
        public int Type { get { return GetInt(ProfilerEventColumns.Type); } }
        public int OwnerID { get { return GetInt(ProfilerEventColumns.OwnerID); } }
        public string ParentName { get { return GetString(ProfilerEventColumns.ParentName); } }
        public int IsSystem { get { return GetInt(ProfilerEventColumns.IsSystem); } }
        public int Offset { get { return GetInt(ProfilerEventColumns.Offset); } }
        public int SourceDatabaseID { get { return GetInt(ProfilerEventColumns.SourceDatabaseID); } }
        public byte[] SqlHandle { get { return GetByte(ProfilerEventColumns.SqlHandle); } }
        public string SessionLoginName { get { return GetString(ProfilerEventColumns.SessionLoginName); } }
        public byte[] PlanHandle { get { return GetByte(ProfilerEventColumns.PlanHandle); } }
    }
    // ReSharper restore InconsistentNaming
    // ReSharper restore UnusedMember.Global

    public class RawTraceReader
    {
        private delegate void SetEventDelegate(ProfilerEvent evt, int columnid);
        private DbDataReader m_Reader;
        private readonly byte[] m_B16 = new byte[16];
        private readonly byte[] m_B8 = new byte[8];
        private readonly byte[] m_B2 = new byte[2];
        private readonly byte[] m_B4 = new byte[4];
        private readonly SqlConnection m_Conn;
        private int m_TraceId;
        public int TraceId
        {
            get { return m_TraceId; }
        }
        readonly SetEventDelegate[] m_Delegates = new SetEventDelegate[66];
        private bool m_LastRead;
        private bool Read()
        {
            m_LastRead = m_Reader.Read();
            return m_LastRead;
        }

        public bool TraceIsActive
        {
            get
            {
                return m_LastRead;
            }
        }
        public void Close()
        {
            if(m_Reader!=null){m_Reader.Close();}
            m_LastRead = false;
        }

        public RawTraceReader(SqlConnection con)
        {
            m_Conn = con;
            SetEventDelegate evtInt = SetIntColumn;
            SetEventDelegate evtLong = SetLongColumn;
            SetEventDelegate evtString = SetStringColumn;
            SetEventDelegate evtByte = SetByteColumn;
            SetEventDelegate evtDateTime = SetDateTimeColumn;
            SetEventDelegate evtGuid = SetGuidColumn;
            /*
            select 'm_Delegates[ProfilerEventColumns.'+Name+'] = evt'+
            case Type_Name
                                    when 'text' then 'String'
                                    when 'int' then 'Int'
                                    when 'bigint' then 'Long'
                                    when 'nvarchar' then 'String'
                                    when 'datetime' then 'DateTime'
                                    when 'image' then 'Byte'
                                    when 'uniqueidentifier' then 'Guid'
                            end+';'

            from sys.trace_columns
            order by trace_column_id
 
             */
            m_Delegates[ProfilerEventColumns.TextData] = evtString;
            m_Delegates[ProfilerEventColumns.BinaryData] = evtByte;
            m_Delegates[ProfilerEventColumns.DatabaseID] = evtInt;
            m_Delegates[ProfilerEventColumns.TransactionID] = evtLong;
            m_Delegates[ProfilerEventColumns.LineNumber] = evtInt;
            m_Delegates[ProfilerEventColumns.NTUserName] = evtString;
            m_Delegates[ProfilerEventColumns.NTDomainName] = evtString;
            m_Delegates[ProfilerEventColumns.HostName] = evtString;
            m_Delegates[ProfilerEventColumns.ClientProcessID] = evtInt;
            m_Delegates[ProfilerEventColumns.ApplicationName] = evtString;
            m_Delegates[ProfilerEventColumns.LoginName] = evtString;
            m_Delegates[ProfilerEventColumns.SPID] = evtInt;
            m_Delegates[ProfilerEventColumns.Duration] = evtLong;
            m_Delegates[ProfilerEventColumns.StartTime] = evtDateTime;
            m_Delegates[ProfilerEventColumns.EndTime] = evtDateTime;
            m_Delegates[ProfilerEventColumns.Reads] = evtLong;
            m_Delegates[ProfilerEventColumns.Writes] = evtLong;
            m_Delegates[ProfilerEventColumns.CPU] = evtInt;
            m_Delegates[ProfilerEventColumns.Permissions] = evtLong;
            m_Delegates[ProfilerEventColumns.Severity] = evtInt;
            m_Delegates[ProfilerEventColumns.EventSubClass] = evtInt;
            m_Delegates[ProfilerEventColumns.ObjectID] = evtInt;
            m_Delegates[ProfilerEventColumns.Success] = evtInt;
            m_Delegates[ProfilerEventColumns.IndexID] = evtInt;
            m_Delegates[ProfilerEventColumns.IntegerData] = evtInt;
            m_Delegates[ProfilerEventColumns.ServerName] = evtString;
            m_Delegates[ProfilerEventColumns.EventClass] = evtInt;
            m_Delegates[ProfilerEventColumns.ObjectType] = evtInt;
            m_Delegates[ProfilerEventColumns.NestLevel] = evtInt;
            m_Delegates[ProfilerEventColumns.State] = evtInt;
            m_Delegates[ProfilerEventColumns.Error] = evtInt;
            m_Delegates[ProfilerEventColumns.Mode] = evtInt;
            m_Delegates[ProfilerEventColumns.Handle] = evtInt;
            m_Delegates[ProfilerEventColumns.ObjectName] = evtString;
            m_Delegates[ProfilerEventColumns.DatabaseName] = evtString;
            m_Delegates[ProfilerEventColumns.FileName] = evtString;
            m_Delegates[ProfilerEventColumns.OwnerName] = evtString;
            m_Delegates[ProfilerEventColumns.RoleName] = evtString;
            m_Delegates[ProfilerEventColumns.TargetUserName] = evtString;
            m_Delegates[ProfilerEventColumns.DBUserName] = evtString;
            m_Delegates[ProfilerEventColumns.LoginSid] = evtByte;
            m_Delegates[ProfilerEventColumns.TargetLoginName] = evtString;
            m_Delegates[ProfilerEventColumns.TargetLoginSid] = evtByte;
            m_Delegates[ProfilerEventColumns.ColumnPermissions] = evtInt;
            m_Delegates[ProfilerEventColumns.LinkedServerName] = evtString;
            m_Delegates[ProfilerEventColumns.ProviderName] = evtString;
            m_Delegates[ProfilerEventColumns.MethodName] = evtString;
            m_Delegates[ProfilerEventColumns.RowCounts] = evtLong;
            m_Delegates[ProfilerEventColumns.RequestID] = evtInt;
            m_Delegates[ProfilerEventColumns.XactSequence] = evtLong;
            m_Delegates[ProfilerEventColumns.EventSequence] = evtLong;
            m_Delegates[ProfilerEventColumns.BigintData1] = evtLong;
            m_Delegates[ProfilerEventColumns.BigintData2] = evtLong;
            m_Delegates[ProfilerEventColumns.GUID] = evtGuid;
            m_Delegates[ProfilerEventColumns.IntegerData2] = evtInt;
            m_Delegates[ProfilerEventColumns.ObjectID2] = evtLong;
            m_Delegates[ProfilerEventColumns.Type] = evtInt;
            m_Delegates[ProfilerEventColumns.OwnerID] = evtInt;
            m_Delegates[ProfilerEventColumns.ParentName] = evtString;
            m_Delegates[ProfilerEventColumns.IsSystem] = evtInt;
            m_Delegates[ProfilerEventColumns.Offset] = evtInt;
            m_Delegates[ProfilerEventColumns.SourceDatabaseID] = evtInt;
            m_Delegates[ProfilerEventColumns.SqlHandle] = evtByte;
            m_Delegates[ProfilerEventColumns.SessionLoginName] = evtString;
            m_Delegates[ProfilerEventColumns.PlanHandle] = evtByte;

        }

        private static void SetGuidColumn(ProfilerEvent evt, int columnid)
        {
            throw new NotImplementedException();
        }

        private void SetDateTimeColumn(ProfilerEvent evt, int columnid)
        {
            //2 byte - year
            //2 byte - month
            //2 byte - ???
            //2 byte - day
            //2 byte - hour
            //2 byte - min
            //2 byte - sec
            //2 byte - msec
            m_Reader.GetBytes(2, 0, m_B16, 0, 16);
            int year = m_B16[0]|m_B16[1]<<8;
            int month = m_B16[2] | m_B16[3] << 8;
            int day = m_B16[6] | m_B16[7] << 8;
            int hour = m_B16[8] | m_B16[9] << 8;
            int min = m_B16[10] | m_B16[11] << 8;
            int sec = m_B16[12] | m_B16[13] << 8;
            int msec = m_B16[14] | m_B16[15] << 8;
            evt.m_Events[columnid] = new DateTime(year,month,day,hour,min,sec,msec);
            evt.m_ColumnMask |= (ulong)1 << columnid;

        }

        private void SetByteColumn(ProfilerEvent evt, int columnid)
        {
            byte[] b = new byte[(int)m_Reader[1]];
            evt.m_Events[columnid] = b;
            evt.m_ColumnMask |= 1UL << columnid;
        }

        private void SetStringColumn(ProfilerEvent evt, int columnid)
        {
            evt.m_Events[columnid] = Encoding.Unicode.GetString((byte[])m_Reader[2]);
            evt.m_ColumnMask |= 1UL << columnid;
        }

        private void SetIntColumn(ProfilerEvent evt, int columnid)
        {
            m_Reader.GetBytes(2, 0, m_B4, 0, 4);
            evt.m_Events[columnid] = ToInt32(m_B4);
            evt.m_ColumnMask |= 1UL << columnid;
        }

        private void SetLongColumn(ProfilerEvent evt, int columnid)
        {
            m_Reader.GetBytes(2, 0, m_B8, 0, 8);
            evt.m_Events[columnid] = ToInt64(m_B8);
            evt.m_ColumnMask |= 1UL << columnid;
        }

        private static long ToInt64(byte[] value)
        {
            int i1 = (value[0]) | (value[1] << 8) | (value[2] << 16) | (value[3] << 24);
            int i2 = (value[4]) | (value[5] << 8) | (value[6] << 16) | (value[7] << 24);
            return (uint)i1 | ((long)i2 << 32);
        }
        private static int ToInt32(byte[] value)
        {
            return (value[0]) | (value[1] << 8) | (value[2] << 16) | (value[3] << 24);
        }
        private static int ToInt16(byte[] value)
        {
            return (value[0]) | (value[1] << 8);
        }

// ReSharper disable UnusedMember.Global
        public static string BuildEventSql(int traceid, int eventId, params int[] columns)
// ReSharper restore UnusedMember.Global
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in columns)
            {
                sb.AppendFormat("\r\n exec sp_trace_setevent {0}, {1}, {2}, @on", traceid, eventId, i);
            }
            return sb.ToString();
        }

        public void SetEvent(int eventId, params int[] columns)
        {
            SqlCommand cmd = new SqlCommand{Connection = m_Conn,CommandText = "sp_trace_setevent",CommandType = CommandType.StoredProcedure};
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = m_TraceId;
            cmd.Parameters.Add("@eventid", SqlDbType.Int).Value = eventId;
            SqlParameter p = cmd.Parameters.Add("@columnid", SqlDbType.Int);
            cmd.Parameters.Add("@on", SqlDbType.Bit).Value = 1;
            foreach (int i in columns)
            {
                p.Value = i;
                cmd.ExecuteNonQuery();
            }
        }

// ReSharper disable UnusedMember.Global
        public void SetFilter(int columnId, int logicalOperator,int comparisonOperator,long? value)
// ReSharper restore UnusedMember.Global
        {
            SqlCommand cmd = new SqlCommand { Connection = m_Conn, CommandText = "sp_trace_setfilter", CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = m_TraceId;
            cmd.Parameters.Add("@columnid", SqlDbType.Int).Value = columnId;
            cmd.Parameters.Add("@logical_operator", SqlDbType.Int).Value = logicalOperator;
            cmd.Parameters.Add("@comparison_operator", SqlDbType.Int).Value = comparisonOperator;
            if (value == null)
            {
                cmd.Parameters.Add("@value", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                switch (columnId)
                {
                    case ProfilerEventColumns.BigintData1:
                    case ProfilerEventColumns.BigintData2:
                    case ProfilerEventColumns.Duration:
                    case ProfilerEventColumns.EventSequence:
                    case ProfilerEventColumns.ObjectID2:
                    case ProfilerEventColumns.Permissions:
                    case ProfilerEventColumns.Reads:
                    case ProfilerEventColumns.RowCounts:
                    case ProfilerEventColumns.TransactionID:
                    case ProfilerEventColumns.Writes:
                    case ProfilerEventColumns.XactSequence:
                        cmd.Parameters.Add("@value", SqlDbType.BigInt).Value = value;
                        break;
                    case ProfilerEventColumns.ClientProcessID:
                    case ProfilerEventColumns.ColumnPermissions:
                    case ProfilerEventColumns.CPU:
                    case ProfilerEventColumns.DatabaseID:
                    case ProfilerEventColumns.Error:
                    case ProfilerEventColumns.EventClass:
                    case ProfilerEventColumns.EventSubClass:
                    case ProfilerEventColumns.Handle:
                    case ProfilerEventColumns.IndexID:
                    case ProfilerEventColumns.IntegerData:
                    case ProfilerEventColumns.IntegerData2:
                    case ProfilerEventColumns.IsSystem:
                    case ProfilerEventColumns.LineNumber:
                    case ProfilerEventColumns.Mode:
                    case ProfilerEventColumns.NestLevel:
                    case ProfilerEventColumns.ObjectID:
                    case ProfilerEventColumns.ObjectType:
                    case ProfilerEventColumns.Offset:
                    case ProfilerEventColumns.OwnerID:
                    case ProfilerEventColumns.RequestID:
                    case ProfilerEventColumns.Severity:
                    case ProfilerEventColumns.SourceDatabaseID:
                    case ProfilerEventColumns.SPID:
                    case ProfilerEventColumns.State:
                    case ProfilerEventColumns.Success:
                    case ProfilerEventColumns.Type:
                        cmd.Parameters.Add("@value", SqlDbType.Int).Value = value;
                        break;
                    default:
                        throw new Exception(String.Format("Unsupported column_id: {0}",columnId));
                }
            }
            cmd.ExecuteNonQuery();
        }

        public void SetFilter(int columnId, int logicalOperator, int comparisonOperator, string value)
        {
            SqlCommand cmd = new SqlCommand { Connection = m_Conn, CommandText = "sp_trace_setfilter", CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = m_TraceId;
            cmd.Parameters.Add("@columnid", SqlDbType.Int).Value = columnId;
            cmd.Parameters.Add("@logical_operator", SqlDbType.Int).Value = logicalOperator;
            cmd.Parameters.Add("@comparison_operator", SqlDbType.Int).Value = comparisonOperator;
            if (value == null)
            {
                cmd.Parameters.Add("@value", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@value", SqlDbType.NVarChar,value.Length).Value = value;
            }
            cmd.ExecuteNonQuery();
        }


        public void CreateTrace()
        {
            SqlCommand cmd = new SqlCommand { Connection = m_Conn, CommandText = "sp_trace_create", CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@options", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@trace_file", SqlDbType.NVarChar, 245).Value=DBNull.Value;
            cmd.Parameters.Add("@maxfilesize", SqlDbType.BigInt).Value = DBNull.Value;
            cmd.Parameters.Add("@stoptime", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@filecount", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int result = (int)cmd.Parameters["@result"].Value;
            m_TraceId = result != 0 ? -result : (int)cmd.Parameters["@traceid"].Value;
        }

        private void ControlTrace(SqlConnection con,int status)
        {
            SqlCommand cmd = new SqlCommand { Connection = con, CommandText = "sp_trace_setstatus", CommandType = CommandType.StoredProcedure,CommandTimeout = 0};
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = m_TraceId;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = status;
            cmd.ExecuteNonQuery();
        }

        public void CloseTrace(SqlConnection con)
        {
            ControlTrace(con,2);
        }

        public void StopTrace(SqlConnection con)
        {
            ControlTrace(con,0);
        }

        public void StartTrace()
        {
            ControlTrace(m_Conn,1);
            GetReader();
            Read();
        }

        private void GetReader()
        {
            SqlCommand cmd = new SqlCommand { Connection = m_Conn, CommandText = "sp_trace_getdata", CommandType = CommandType.StoredProcedure,CommandTimeout = 0};
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = m_TraceId;
            cmd.Parameters.Add("@records", SqlDbType.Int).Value = 0;
            m_Reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
        }

        public ProfilerEvent Next()
        {
            if (!TraceIsActive) return null;
            int columnid = (int)m_Reader[0];
            //skip to begin of new event
            while (columnid != 65526 && Read() && TraceIsActive)
            {
                columnid = (int)m_Reader[0];
            }
            //start of new event
            if (columnid != 65526) return null;
            if (!TraceIsActive) return null;
            //get potential event class
            m_Reader.GetBytes(2, 0, m_B2, 0, 2);
            int eventClass = ToInt16(m_B2);

            //we got new event
            if (eventClass >= 0 && eventClass < 255)
            {
                ProfilerEvent evt = new ProfilerEvent();
                evt.m_Events[27] = eventClass;
                evt.m_ColumnMask |= 1 << 27;
                while (Read())
                {
                    columnid = (int)m_Reader[0];
                    if (columnid > 64) return evt;
                    m_Delegates[columnid](evt, columnid);
                }
            }
            Read();
            return null;
        }

    }
}