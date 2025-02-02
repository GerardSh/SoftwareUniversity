CREATE PROC dbo.usp_SearchByGenre(@genreName NVARCHAR(30))
AS
 SELECT Title,
		YearPublished AS Year,
		ISBN,
		a.[Name] AS Author,
		@genreName AS Genre
 FROM Books AS b
	JOIN Genres AS g ON g.Id = b.GenreId
	JOIN Authors AS a ON a.Id = b.AuthorId
 WHERE g.[Name] = @genreName
 ORDER BY Title