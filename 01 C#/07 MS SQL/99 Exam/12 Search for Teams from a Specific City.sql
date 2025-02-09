CREATE PROC usp_SearchTeamsByCity(@CityName VARCHAR(30))
AS
BEGIN
	SELECT t.[Name] AS TeamName,
		   l.[Name] AS Leaguename,
		   t.City
	FROM Teams AS t
		JOIN Leagues AS l ON l.Id = t.LeagueId
	WHERE t.City = @CityName 
	ORDER BY t.[Name]
END