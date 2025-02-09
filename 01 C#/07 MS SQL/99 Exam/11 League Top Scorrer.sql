CREATE FUNCTION udf_LeagueTopScorer (@LeagueName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    WITH LeagueTopScorers AS (
        SELECT 
            p.Name AS PlayerName,
            ps.Goals AS TotalGoals,
            RANK() OVER (ORDER BY ps.Goals DESC) AS GoalRank
        FROM Players p
        JOIN PlayerStats ps ON p.Id = ps.PlayerId
        JOIN PlayersTeams pt ON p.Id = pt.PlayerId
        JOIN Teams t ON pt.TeamId = t.Id
        JOIN Leagues l ON t.LeagueId = l.Id
        WHERE l.Name = @LeagueName
    )
    SELECT 
        PlayerName,
        TotalGoals
    FROM LeagueTopScorers
    WHERE GoalRank = 1
)