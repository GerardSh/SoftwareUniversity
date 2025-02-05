SELECT Id,
       CONCAT_WS(' ', FirstName, LastName) AS CreatorName,
	   Email
FROM Creators AS c
	LEFT JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
WHERE CreatorId IS NULL
ORDER BY CreatorName