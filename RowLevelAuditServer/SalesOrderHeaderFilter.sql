CREATE FUNCTION [rls].[SalesOrderHeaderFilter](@CustomerID int, @AccountNumber nvarchar(15)) 
RETURNS TABLE
WITH SCHEMABINDING
AS
  RETURN (
    SELECT 1 AS SalesOrderHeaderFilter
    WHERE rls.LogRowLevelAudit2(SYSTEM_USER, 
                                'Sales.SalesOrderHeader', 
                                CONCAT(@CustomerID, char(9), @AccountNumber))
         IS NULL
)
                
GO
