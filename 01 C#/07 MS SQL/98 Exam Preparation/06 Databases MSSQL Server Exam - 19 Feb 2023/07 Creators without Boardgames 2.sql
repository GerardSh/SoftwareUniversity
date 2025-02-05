SELECT Id,
       CONCAT_WS(' ', FirstName, LastName) AS CreatorName,
	   Email
FROM Creators
WHERE Id NOT IN (SELECT DISTINCT CreatorId FROM CreatorsBoardgames)
ORDER BY CreatorName