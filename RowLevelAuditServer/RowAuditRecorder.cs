using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Server;

public static class RowAuditRecorder
{
    private static readonly string AuditLogPath = Environment.GetEnvironmentVariable("SQL_ROW_AUDIT_FILE_LOCATION");

    [SqlFunction(DataAccess = DataAccessKind.None, IsDeterministic = false)]
    public static SqlString WriteAuditLogToFile(SqlString userName, SqlString tableName, SqlString message)
    {
        try
        {
            var filename = tableName.Value + ".tsv";

            var fullName = Path.Combine(AuditLogPath, filename);

            using (var fs = new StreamWriter(fullName, true, Encoding.UTF8))
            {
                StringBuilder sb = new StringBuilder(1024);

                sb.AppendFormat("{0}\t{1}\t{2}", DateTime.UtcNow.ToString("s"), userName.Value, message.Value);

                fs.WriteLine(sb.ToString());
            }
            return null;
        }
        catch(Exception e)
        {
            return e.Message;
        }
    }
}
