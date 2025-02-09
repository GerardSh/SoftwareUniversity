SELECT TOP 10 ht.[Name] AS HomeTeamName,
	   awt.[Name] AS AwayTeamName,
	   l.[Name] AS LeagueName,
	   FORMAT(m.MatchDate, 'yyyy-MM-dd') AS MatchDate
FROM Matches AS m
	JOIN Leagues AS l ON l.Id = m.LeagueId
	JOIN Teams AS ht ON ht.Id = m.HomeTeamId
	JOIN Teams AS awt ON awt.Id = m.AwayTeamId
WHERE l.Id % 2 = 0 AND m.MatchDate BETWEEN '2024-09-01' AND '2024-09-15'
ORDER BY m.MatchDate, ht.[Name]