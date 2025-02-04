SELECT p.Id, 
	   p.[Name], 
	   Price, 
	   c.[Name] AS CategoryName
FROM Products AS p
	JOIN Categories AS c ON c.Id = p.CategoryId
WHERE c.[Name] = 'ADR' OR c.[Name] = 'Others'
ORDER BY Price DESC