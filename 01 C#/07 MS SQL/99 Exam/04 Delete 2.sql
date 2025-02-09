DELETE PlayersTeams
WHERE PlayerId IN (SELECT p.Id FROM Players AS p
	JOIN PlayersTeams AS pt ON pt.PlayerId = p.Id
	JOIN Teams AS t ON t.Id = pt.TeamId
	JOIN Leagues AS l ON l.Id = t.LeagueId
WHERE l.[Name] = 'Eredivisie' AND p.[Name] IN ('Luuk de Jong', 'Josip Sutalo'))

DELETE PlayerStats 
WHERE PlayerId IN (SELECT p.Id FROM Players AS p
	JOIN PlayersTeams AS pt ON pt.PlayerId = p.Id
	JOIN Teams AS t ON t.Id = pt.TeamId
	JOIN Leagues AS l ON l.Id = t.LeagueId
WHERE l.[Name] = 'Eredivisie' AND p.[Name] IN ('Luuk de Jong', 'Josip Sutalo'))

DELETE Players
WHERE Id IN (SELECT p.Id FROM Players AS p
	JOIN PlayersTeams AS pt ON pt.PlayerId = p.Id
	JOIN Teams AS t ON t.Id = pt.TeamId
	JOIN Leagues AS l ON l.Id = t.LeagueId
WHERE l.[Name] = 'Eredivisie' AND p.[Name] IN ('Luuk de Jong', 'Josip Sutalo'))