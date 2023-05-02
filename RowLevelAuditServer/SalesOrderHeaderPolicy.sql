CREATE SECURITY POLICY [rls].[SalesOrderHeaderLogPolicy] 
ADD FILTER PREDICATE [rls].[SalesOrderHeaderFilter]([CustomerID],[AccountNumber])
ON [Sales].[SalesOrderHeader]
WITH (STATE = ON, SCHEMABINDING = ON)
GO


