using PoorMansTSqlFormatterRedux;
using System;

namespace ExpressProfiler
{
	internal static class Extensions
	{
		static Lazy<SqlFormattingManager> SqlFormattingManager = new Lazy<PoorMansTSqlFormatterRedux.SqlFormattingManager>();

		public static string ParseSql(this string text)
		{
			const string SQL_PARSING_ERROR = "--WARNING! ERRORS ENCOUNTERED DURING SQL PARSING!";

			string sql = SqlFormattingManager.Value.Format(text);
			sql = sql.Replace(SQL_PARSING_ERROR, string.Empty);

			return sql;
		}
	}
}