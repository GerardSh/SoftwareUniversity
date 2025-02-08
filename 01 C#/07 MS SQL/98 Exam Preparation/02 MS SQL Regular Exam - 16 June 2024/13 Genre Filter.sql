CREATE FUNCTION udf_GenreFilter(@genre VARCHAR(30))
RETURNS TABLE
AS
RETURN
(
	SELECT b.Id AS BookId,
	       Title, 
		   YearPublished, 
		   ISBN, 
		   a.[Name] AS Author, 
		   l.[Name] AS [Library] 
	FROM Books As b
		JOIN Genres AS g ON g.Id = b.GenreId
		JOIN Authors AS a ON a.Id = b.AuthorId
		JOIN LibrariesBooks AS lb ON lb.BookId = b.Id
		JOIN Libraries AS l ON l.Id = lb.LibraryId
	WHERE g.[Name] = @genre
)