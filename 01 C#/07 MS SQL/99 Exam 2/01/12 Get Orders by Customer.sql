CREATE PROC usp_GetOrdersByCustomer(@customerName NVARCHAR(80))
AS
 SELECT p.[Name] AS ProductName, s.[Name] AS StoreName, FORMAT(OrderDate, 'MM-dd-yyyy'), FORMAT(Price, 'N2')
 FROM Customers AS c
 JOIN Orders AS o ON o.CustomerId = c.Id
 JOIN Stores AS s ON s.Id = o.StoreId
 JOIN Products AS p ON p.Id = o.ProductId
 WHERE c.[Name] = @customerName
 ORDER BY o.OrderDate DESC, p.[Name]
