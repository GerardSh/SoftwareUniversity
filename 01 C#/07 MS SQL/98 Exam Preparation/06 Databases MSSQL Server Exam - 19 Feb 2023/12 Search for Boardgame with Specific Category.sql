CREATE PROC usp_SearchByCategory(@category VARCHAR(30))
AS
BEGIN
	SELECT b.[Name],
		   YearPublished,
		   Rating,
		   c.[Name] AS CategoryName,
		   p.[Name] AS PublisherName,
		   CONCAT_WS(' ', pr.PlayersMin, 'people') AS MinPlayers,
		   CONCAT_WS(' ', pr.PlayersMax, 'people') AS MaxPlayers
	FROM Boardgames AS b
		JOIN Categories AS c ON c.Id = b.CategoryId
		JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
		JOIN Publishers AS p ON p.Id = b.PublisherId
    WHERE c.[Name] = @category
	ORDER BY PublisherName, YearPublished DESC
END