CREATE FUNCTION udf_LeagueTopScorer (@LeagueName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
SELECT p.[Name], ps.Goals
FROM PlayerStats AS ps
	JOIN Players AS p ON p.Id = ps.PlayerId
	JOIN PlayersTeams AS pt ON pt.PlayerId = p.Id
	JOIN Teams AS t ON t.Id = pt.TeamId
	JOIN Leagues AS l ON l.Id = t.LeagueId
WHERE l.[Name] = @LeagueName AND
	  ps.Goals = (SELECT MAX(ps.Goals)
				  FROM PlayerStats AS ps
					   JOIN Players AS p ON p.Id = ps.PlayerId
					   JOIN PlayersTeams AS pt ON pt.PlayerId = p.Id
					   JOIN Teams AS t ON t.Id = pt.TeamId
					   JOIN Leagues AS l ON l.Id = t.LeagueId
					   JOIN Matches AS m ON m.LeagueId = l.Id
				   WHERE l.[Name] =  @LeagueName)
)