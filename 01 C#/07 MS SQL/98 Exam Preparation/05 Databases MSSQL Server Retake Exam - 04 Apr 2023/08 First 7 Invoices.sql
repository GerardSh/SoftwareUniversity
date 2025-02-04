SELECT TOP 7 Number,
	   Amount,
	   c.[Name] AS Client
FROM Invoices AS i
	JOIN Clients AS c ON c.Id = i.ClientId
WHERE IssueDate < '2023-01-01' AND Currency = 'EUR' OR
      Amount > 500 AND NumberVAT LIKE 'DE%'
ORDER BY Number, Amount DESC