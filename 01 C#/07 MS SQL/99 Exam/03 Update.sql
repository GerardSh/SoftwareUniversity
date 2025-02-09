UPDATE ps
SET Goals = Goals + 1 
FROM PlayerStats AS ps
	JOIN Players AS p ON p.Id = ps.PlayerId
	JOIN PlayersTeams AS pt ON pt.PlayerId = p.Id
	JOIN Teams AS t ON t.Id = pt.TeamId
	JOIN Leagues AS l ON l.Id = t.LeagueId
WHERE l.[Name] = 'La Liga' AND p.Position = 'Forward'