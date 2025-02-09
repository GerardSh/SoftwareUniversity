SELECT DISTINCT c.[Name] AS CustomerName, PhoneNumber, Email FROM Customers AS c
JOIN Orders AS o ON o.CustomerId = c.Id
JOIN Products AS p ON p.Id = o.ProductId
JOIN Manufacturers AS m ON m.Id = p.ManufacturerId
WHERE Country = 'China' AND NOT c.Email IS NULL
ORDER BY c.[Name]