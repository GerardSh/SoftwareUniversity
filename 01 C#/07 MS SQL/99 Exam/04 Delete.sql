DELETE FROM PlayerStats
WHERE PlayerId IN (
    SELECT p.Id
    FROM Players p
    JOIN PlayersTeams pt ON p.Id = pt.PlayerId
    JOIN Teams t ON pt.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    WHERE l.Name = 'Eredivisie' AND p.Name IN ('Luuk de Jong', 'Josip Sutalo')
)

DELETE FROM PlayersTeams
WHERE PlayerId IN (
    SELECT p.Id
    FROM Players p
    JOIN PlayersTeams pt ON p.Id = pt.PlayerId
    JOIN Teams t ON pt.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    WHERE l.Name = 'Eredivisie' AND p.Name IN ('Luuk de Jong', 'Josip Sutalo')
)

DELETE FROM Players
WHERE Id IN (
    SELECT p.Id
    FROM Players p
    JOIN PlayersTeams pt ON p.Id = pt.PlayerId
    JOIN Teams t ON pt.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    WHERE l.Name = 'Eredivisie' AND p.Name IN ('Luuk de Jong', 'Josip Sutalo')
)