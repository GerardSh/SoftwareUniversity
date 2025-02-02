SELECT b.Id,
	   Title,
	   ISBN,
	   g.[Name] AS Genre  
FROM Books AS b
	JOIN Genres AS g ON g.Id = b.GenreId
WHERE g.[Name] = 'Biography' OR g.[Name] = 'Historical Fiction'
ORDER BY g.[Name], Title