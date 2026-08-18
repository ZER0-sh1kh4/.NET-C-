SELECT OI.* FROM OrderItems OI LEFT JOIN Orders O ON OI.OrderId = O.OrderId
WHERE O.OrderId IS NULL;
