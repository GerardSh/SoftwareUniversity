SELECT c.[Name] AS CustomerName, COUNT(*) AS OrdersCount
FROM Customers AS c
JOIN Orders AS o ON o.CustomerId = c.Id
GROUP BY CustomerId, [Name]
HAVING COUNT(*) > 1
ORDER BY OrdersCount DESC, c.[Name]