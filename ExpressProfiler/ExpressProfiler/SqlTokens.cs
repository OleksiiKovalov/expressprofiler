//Traceutils assembly
//writen by Locky, 2009. 
using System.Collections.Generic;
using System.Text;

namespace ExpressProfiler
{
    class Sqltokens
    {
        #region Keywords
        private const string Keywords = "ADD,ALTER,AS,ASC,AUTHORIZATION,BACKUP," +
                                        "BEGIN,BREAK,BROWSE,BULK,BY,CASCADE," +
                                        "CHECK,CHECKPOINT,CLOSE,CLUSTERED,COLLATE," +
                                        "COLUMN,COMMIT,COMPUTE,CONSTRAINT,CONTAINS,CONTAINSTABLE," +
                                        "CONTINUE,CREATE,CURRENT,CURSOR,DATABASE," +
                                        "DBCC,DEALLOCATE,DECLARE,DEFAULT,DELETE,DENY,DESC,DISK," +
                                        "DISTINCT,DISTRIBUTED,DOUBLE,DROP,DUMMY,DUMP,ELSE,END," +
                                        "ERRLVL,ESCAPE,EXCEPT,EXEC,EXECUTE,EXIT,FETCH,FILE," +
                                        "FILLFACTOR,FOR,FOREIGN,FORMSOF,FREETEXT,FREETEXTTABLE,FROM,FULL," +
                                        "FUNCTION,GOTO,GRANT,GROUP,HAVING,HOLDLOCK,IDENTITY," +
                                        "IDENTITYCOL,IDENTITY_INSERT,IF,INFLECTIONAL,INDEX,INNER,INSERT," +
                                        "INTERSECT,INTO,IS,ISABOUT,KEY,KILL,LINENO,LOAD," +
                                        "NATIONAL,NOCHECK,NONCLUSTERED,OF,OFF," +
                                        "OFFSETS,ON,OPEN,OPENDATASOURCE,OPENQUERY,OPENROWSET,OPENXML," +
                                        "OPTION,ORDER,OVER,PERCENT,PLAN,PRECISION," +
                                        "PRIMARY,PRINT,PROC,PROCEDURE,PUBLIC,RAISERROR,READ," +
                                        "READTEXT,RECONFIGURE,REFERENCES,REPLICATION,RESTORE," +
                                        "RESTRICT,RETURN,REVOKE,ROLLBACK,ROWCOUNT,ROWGUIDCOL," +
                                        "RULE,SAVE,SCHEMA,SELECT,SET,SETUSER,SHUTDOWN," +
                                        "STATISTICS,TABLE,TEXTSIZE,THEN,TO,TOP,TRAN,TRANSACTION," +
                                        "TRIGGER,TRUNCATE,TSEQUAL,UNION,UNIQUE,UPDATE,UPDATETEXT," +
                                        "USE,VALUES,VARYING,VIEW,WAITFOR,WEIGHT,WHEN,WHERE,WHILE," +
                                        "WITH,WRITETEXT,CURRENT_DATE,CURRENT_TIME" +
                                        ",OUT,NEXT,PRIOR,RETURNS,ABSOLUTE,ACTION,PARTIAL,FALSE" +
                                        ",PREPARE,FIRST,PRIVILEGES,AT,GLOBAL,RELATIVE,ROWS,HOUR,MIN,MAX" +
                                        ",SCROLL,SECOND,SECTION,SIZE,INSENSITIVE,CONNECT,CONNECTION" +
                                        ",ISOLATION,LEVEL,LOCAL,DATE,MINUTE,TRANSLATION" +
                                        ",TRUE,NO,ONLY,WORK,OUTPUT" +
                                        ",ABSOLUTE,ACTION,FREE,PRIOR,PRIVILEGES,AFTER,GLOBAL" +
                                        ",HOUR,RELATIVE,IGNORE,AT,RETURNS,ROLLUP,ROWS,SCROLL" +
                                        ",ISOLATION,SECOND,SECTION,SEQUENCE,LAST,SIZE,LEVEL" +
                                        ",CONNECT,CONNECTION,LOCAL,CUBE,MINUTE,MODIFY,STATIC" +
                                        ",DATE,TEMPORARY,TIME,NEXT,NO,TRANSLATION,TRUE,ONLY" +
                                        ",OUT,DYNAMIC,OUTPUT,PARTIAL,WORK,FALSE,FIRST,PREPARE,GROUPING,FORMAT,INIT,STATS" +
                                        "FORMAT,INIT,STATS,NOCOUNT,FORWARD_ONLY,KEEPFIXED,FORCE,KEEP,MERGE,HASH,LOOP,maxdop,nolock" +
                                        ",updlock,tablock,tablockx,paglock,readcommitted,readpast,readuncommitted,repeatableread,rowlock,serializable,xlock"
                                        + ",delay";

        #endregion
        #region Functions
        private const string Functions = "@@CONNECTIONS,@@CPU_BUSY,@@CURSOR_ROWS,@@DATEFIRST,@@DBTS,@@ERROR," +
                                         "@@FETCH_STATUS,@@IDENTITY,@@IDLE,@@IO_BUSY,@@LANGID,@@LANGUAGE," +
                                         "@@LOCK_TIMEOUT,@@MAX_CONNECTIONS,@@MAX_PRECISION,@@NESTLEVEL,@@OPTIONS," +
                                         "@@PACKET_ERRORS,@@PACK_RECEIVED,@@PACK_SENT,@@PROCID,@@REMSERVER," +
                                         "@@ROWCOUNT,@@SERVERNAME,@@SERVICENAME,@@SPID,@@TEXTSIZE,@@TIMETICKS," +
                                         "@@TOTAL_ERRORS,@@TOTAL_READ,@@TOTAL_WRITE,@@TRANCOUNT,@@VERSION," +
                                         "ABS,ACOS,APP_NAME,ASCII,ASIN,ATAN,ATN2,AVG,BINARY_CHECKSUM,CAST," +
                                         "CEILING,CHARINDEX,CHECKSUM,CHECKSUM_AGG,COLLATIONPROPERTY," +
                                         "COLUMNPROPERTY,COL_LENGTH,COL_NAME,COS,COT,COUNT," +
                                         "COUNT_BIG," +
                                         "CURSOR_STATUS,DATABASEPROPERTY,DATABASEPROPERTYEX," +
                                         "DATALENGTH,DATEADD,DATEDIFF,DATENAME,DATEPART,DAY,DB_ID,DB_NAME,DEGREES," +
                                         "DIFFERENCE,EXP,FILEGROUPPROPERTY,FILEGROUP_ID,FILEGROUP_NAME,FILEPROPERTY," +
                                         "FILE_ID,FILE_NAME,FLOOR" +
                                         "" +
                                         "FORMATMESSAGE,FULLTEXTCATALOGPROPERTY,FULLTEXTSERVICEPROPERTY," +
                                         "GETANSINULL,GETDATE,GETUTCDATE,HAS_DBACCESS,HOST_ID,HOST_NAME," +
                                         "IDENT_CURRENT,IDENT_INCR,IDENT_SEED,INDEXKEY_PROPERTY,INDEXPROPERTY," +
                                         "INDEX_COL,ISDATE,ISNULL,ISNUMERIC,IS_MEMBER,IS_SRVROLEMEMBER,LEN,LOG," +
                                         "LOG10,LOWER,LTRIM,MONTH,NEWID,OBJECTPROPERTY,OBJECT_ID," +
                                         "OBJECT_NAME,PARSENAME,PATINDEX," +
                                         "PERMISSIONS,PI,POWER,QUOTENAME,RADIANS,RAND,REPLACE,REPLICATE,REVERSE," +
                                         "ROUND,ROWCOUNT_BIG,RTRIM,SCOPE_IDENTITY,SERVERPROPERTY,SESSIONPROPERTY," +
                                         "SIGN,SIN,SOUNDEX,SPACE,SQL_VARIANT_PROPERTY,SQRT,SQUARE," +
                                         "STATS_DATE,STDEV,STDEVP,STR,STUFF,SUBSTRING,SUM,SUSER_SID,SUSER_SNAME," +
                                         "TAN,TEXTPTR,TEXTVALID,TYPEPROPERTY,UNICODE,UPPER," +
                                         "USER_ID,USER_NAME,VAR,VARP,YEAR";

        #endregion
        #region Types
        private const string Types = "bigint,binary,bit,char,character,datetime," +
                                     "dec,decimal,float,image,int," +
                                     "integer,money,nchar,ntext,nvarchar,real," +
                                     "rowversion,smalldatetime,smallint,smallmoney," +
                                     "sql_variant,sysname,text,timestamp,tinyint,uniqueidentifier," +
                                     "varbinary,varchar,NUMERIC";
        #endregion
        private const string Greykeywords = "AND,EXISTS,ALL,ANY,BETWEEN,IN,SOME,JOIN,CROSS,OR,NULL,OUTER,NOT,LIKE";
        private const string Fukeywords = "CASE,RIGHT,COALESCE,SESSION_USER,CONVERT,SYSTEM_USER,LEFT,CURRENT_TIMESTAMP,CURRENT_USER,NULLIF,USER";
        private readonly Dictionary<string, YukonLexer.TokenKind> m_Words = new Dictionary<string, YukonLexer.TokenKind>();
        public YukonLexer.TokenKind this[string token] { get { token = token.ToLower(); return m_Words.ContainsKey(token) ? m_Words[token] : YukonLexer.TokenKind.tkUnknown; } }
        private void AddTokens(string tokens, YukonLexer.TokenKind tokenkind)
        {
            StringBuilder curtoken = new StringBuilder();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == ',')
                {
                    string s = curtoken.ToString().ToLower();
                    if (!m_Words.ContainsKey(s))
                        m_Words.Add(s, tokenkind);
                    curtoken = new StringBuilder();
                }
                else
                {
                    curtoken.Append(tokens[i]);
                }
            }
            if (curtoken.Length != 0) m_Words.Add(curtoken.ToString(), tokenkind);
        }
        public Sqltokens()
        {
            AddTokens(Keywords, YukonLexer.TokenKind.tkKey);
            AddTokens(Functions, YukonLexer.TokenKind.tkFunction);
            AddTokens(Types, YukonLexer.TokenKind.tkDatatype);
            AddTokens(Greykeywords, YukonLexer.TokenKind.tkGreyKeyword);
            AddTokens(Fukeywords, YukonLexer.TokenKind.tkFuKeyword);
        }
    }
}