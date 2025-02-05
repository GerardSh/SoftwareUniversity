SELECT LastName,
       CEILING(AVG(Rating)) AS AverageRating,
	   p.[Name] AS PublisherName
FROM Creators AS c
	JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
	JOIN Boardgames AS b ON b.Id = cb.BoardgameId
	JOIN Publishers AS p ON p.Id = b.PublisherId
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.Id, LastName, p.[Name]
ORDER BY AVG(Rating) DESC