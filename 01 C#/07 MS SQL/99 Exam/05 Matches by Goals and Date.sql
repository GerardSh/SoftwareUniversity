SELECT FORMAT(MatchDate, 'yyyy-MM-dd') AS MatchDate,
       HomeTeamGoals,
	   AwayTeamGoals,
	   HomeTeamGoals + AwayTeamGoals AS TotalGoals
FROM Matches AS m
WHERE HomeTeamGoals + AwayTeamGoals >= 5
ORDER BY ToTalGoals DESC, MatchDate