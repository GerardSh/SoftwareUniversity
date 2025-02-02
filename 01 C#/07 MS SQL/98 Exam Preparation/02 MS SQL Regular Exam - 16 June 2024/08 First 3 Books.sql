SELECT TOP 3 Title,
	         YearPublished AS [Year],
	         g.[Name] AS Genre
FROM Books AS b
	JOIN Genres AS g ON g.Id = b.GenreId
WHERE YearPublished > 2000 AND Title LIKE '%a%' OR YearPublished < 1950 AND g.[Name] LIKE '%Fantasy%'
ORDER BY Title, YearPublished DESC