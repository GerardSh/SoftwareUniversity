SELECT t.Id, t.[Name], SUM(m.AwayTeamGoals) AS TotalAwayGoals
FROM Matches AS m
	JOIN Teams AS t ON t.Id = m.AwayTeamId
GROUP BY AwayTeamId, t.[Name], t.Id
HAVING SUM(m.AwayTeamGoals) >=6
ORDER BY TotalAwayGoals DESC, t.[Name]