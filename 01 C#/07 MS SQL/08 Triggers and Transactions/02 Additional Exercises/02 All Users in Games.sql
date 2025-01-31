SELECT 
	g.[Name],
	gt.[Name],
	u.Username,
	ug.[Level],
	ug.Cash,
	c.[Name]
FROM UsersGames AS ug
	JOIN Games AS g ON ug.GameId = g.Id
	JOIN Users AS u ON ug.UserId = u.Id
	JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
	JOIN Characters AS c ON ug.CharacterId = c.Id
ORDER BY ug.[Level] DESC, Username, g.[Name]