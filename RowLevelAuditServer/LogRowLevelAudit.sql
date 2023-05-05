/****** Object:  UserDefinedFunction [rls].[LogRowLevelAudit2]    Script Date: 5/2/2023 4:24:14 PM ******/

CREATE FUNCTION [rls].[LogRowLevelAudit](@username [nvarchar](128), @tablename [nvarchar](128), @message [nvarchar](256))
RETURNS [nvarchar](256) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [RowLevelAudit].[RowAuditRecorder].[TestWriteAuditLogToFile]