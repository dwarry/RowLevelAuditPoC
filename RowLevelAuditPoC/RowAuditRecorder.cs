using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowLevelAuditPoC
{
    public static class RowAuditRecorder
    {
        [SqlFunction(DataAccess = DataAccessKind.None, IsDeterministic =false)]
        public static SqlBoolean WriteAuditLogToFile(SqlString userName, SqlString message)
        {
            try
            {
                using (var fs = new StreamWriter(Environment.GetEnvironmentVariable("SQL_ROW_AUDIT_FILE_LOCATION"), true, Encoding.UTF8))
                {
                    StringBuilder sb = new StringBuilder(1024);

                    sb.AppendFormat("{0}\t{1}\t{2}", DateTime.UtcNow.ToString("s"), userName, message);

                    fs.WriteLine(sb.ToString());
                }
            }
            catch
            {
                // do nothing
            }
            return true;
        }
    }
}
