using PoorMansTSqlFormatterRedux;

namespace ExpressProfiler
{
    internal static class Extensions
    {
        public static string ParseSql(this string text)
        {
            const string SQL_PARSING_ERROR = "--WARNING! ERRORS ENCOUNTERED DURING SQL PARSING!";

            string sql = (new SqlFormattingManager()).Format(text).ToString();
            sql = sql.Replace(SQL_PARSING_ERROR, string.Empty);

            return sql;
        }
    }
}