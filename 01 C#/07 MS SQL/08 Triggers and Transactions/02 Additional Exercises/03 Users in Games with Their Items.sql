SELECT 
	u.Username,
	g.[Name] AS Game,
	COUNT(*) AS [Items Count],
	SUM(i.Price) AS [Items Price]
FROM UsersGames AS ug
	JOIN Games AS g ON ug.GameId = g.Id
	JOIN Users AS u ON ug.UserId = u.Id
	JOIN UserGameItems AS ugi ON  ug.Id = ugi.UserGameId
	JOIN Items AS i ON ugi.ItemId = i.Id
GROUP BY u.Username, g.[Name]
HAVING COUNT(*) >= 10
ORDER BY COUNT(*) DESC, SUM(i.Price) DESC, u.Username