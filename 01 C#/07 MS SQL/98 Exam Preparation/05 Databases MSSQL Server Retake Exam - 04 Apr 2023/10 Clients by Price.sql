SELECT c.[Name] AS Client,
	   CONVERT(INT, AVG(Price)) AS [Average Price]
FROM Clients AS c
	JOIN ProductsClients AS pc ON pc.ClientId = c.Id
	JOIN Products AS p ON p.Id = pc.ProductId
	JOIN Vendors AS v ON v.Id = p.VendorId
WHERE v.NumberVAT LIKE '%FR%'
GROUP BY c.[Name]
ORDER BY [Average Price], c.[Name] DESC