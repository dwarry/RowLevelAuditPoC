# Using Row Level Security to Log Access

This repo comprises an attempt to (ab)use the Row-Level Security (RLS) functionality in SQL Server 2016 to log
access to the data in a table. For familiarity, it's based on the AdventureWorks2016 sample database. 

## RowAuditRecorder.cs
Contains a fairly trivial static class that contains a method that logs
a message to a text file. The location of the text file is specified by 
an environment variable `SQL_ROW_AUDIT_FILE_LOCATION`, so this will need to be
set at the system level and the SQL Server service restarted before running it
for the first time. 

The function takes three parameters - the user name, the table name being
logged, and a message. The table name is used for the filename, and each call
writes a line to this file containing the ISO8601 timestamp, the user name and
the message, with tab as the delimiter. 

As the Assembly that will be built to hold this is going to be registered with
SQL Server as an assembly with External Access permission (probably has to be
Unsafe in later versions of SQL Server), it will need to be signed with a key
with a password set.

## CodeAsymmetricKey.sql
This creates an asymmetric key from the assembly, and a server-level login associated with it which has permission to use external access assemblies.

## CreateAssembly.sql
This loads the assembly into the target database.

## LogRowLevelAudit.sql
This creates a wrapper T-SQL function that invokes the C# method. 

