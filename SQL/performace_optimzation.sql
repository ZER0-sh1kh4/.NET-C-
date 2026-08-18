CREATE NONCLUSTERED INDEX Orders_CustomerId_OrderDate
ON Orders (CustomerId, OrderDate);
/*
Why?
CustomerId is used with an equality condition (CustomerId = 1254), so it should come first.
OrderDate is used with a range condition (OrderDate > '2024-01-01'), so it should come after CustomerId.
This allows SQL Server to quickly locate the customer's orders and then filter by date instead of scanning all 20 million rows.
A nonclustered index is suitable because the table may already have a clustered primary key, usually on OrderId.
I would not create another clustered index just for this query because a table can have only one clustered index.
*/
