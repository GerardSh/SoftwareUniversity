SELECT a.[Name] AS Author,
	   Title,
	   l.[Name] AS [Library],
	   PostAddress AS [Library Address]
FROM Books AS b
	JOIN Authors AS a ON a.Id = b.AuthorId
	JOIN LibrariesBooks AS lb ON lb.BookId = b.Id
	JOIN Libraries AS l ON l.Id = lb.LibraryId
	JOIN Contacts AS c ON c.Id = l.ContactId
	JOIN Genres AS g ON g.Id = b.GenreId
WHERE g.[Name] = 'Fiction' AND c.PostAddress LIKE '%Denver%'
ORDER BY Title