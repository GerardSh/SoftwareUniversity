SELECT l.[Name],
	   ROUND(CAST(SUM(m.HomeTeamGoals + m.AwayTeamGoals) AS FLOAT) / COUNT(m.Id), 2) AS AvgScoringRate
FROM Matches AS m
	JOIN Leagues AS l ON l.Id = m.LeagueId
GROUP BY l.[Name]
ORDER BY AvgScoringRate DESC