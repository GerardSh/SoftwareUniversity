SELECT TOP 5 b.[Name],
             Rating,
             c.[Name] AS CategoryName
FROM Boardgames AS b
	JOIN Categories AS c ON c.Id = b.CategoryId
	JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
WHERE Rating > 7 AND b.[Name] LIKE '%a%' OR
      Rating > 7.5 AND pr.PlayersMin >= 2 AND pr.PlayersMax <= 5
ORDER BY b.[Name], Rating DESC