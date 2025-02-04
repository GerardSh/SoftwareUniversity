SELECT c.[Name] AS Client,
	   MAX(Price) AS Price,
	   NumberVAT AS [VAT Number]
FROM Clients AS c
	JOIN ProductsClients AS pc ON pc.ClientId = c.Id
	JOIN Products AS p ON p.Id = pc.ProductId
WHERE c.[Name] NOT LIKE '%KG'
GROUP BY c.[Name], NumberVAT
ORDER BY Price DESC