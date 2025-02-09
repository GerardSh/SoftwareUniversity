SELECT p.[Name], City
FROM Players AS p
	JOIN PlayersTeams AS pt ON pt.PlayerId = p.Id
	JOIN Teams AS t ON t.Id = pt.TeamId
WHERE p.[Name] LIKE '%Aaron%'
ORDER BY p.[Name]