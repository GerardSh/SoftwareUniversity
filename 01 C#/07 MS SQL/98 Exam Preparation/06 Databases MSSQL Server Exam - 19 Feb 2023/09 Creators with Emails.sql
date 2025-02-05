SELECT CONCAT_WS(' ', FirstName, LastName) AS FullName,
       Email,
	   MAX(Rating) AS Rating
FROM Creators AS c
	JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
	JOIN Boardgames AS b ON b.Id = cb.BoardgameId
WHERE Email LIKE '%.com'
GROUP BY c.Id, FirstName, LastName, Email
ORDER BY FullName