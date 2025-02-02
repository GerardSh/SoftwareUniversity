SELECT 
l.[Name] AS [Library],
Email
FROM Libraries AS l
	JOIN Contacts AS c ON c.Id = l.ContactId
WHERE l.Id NOT IN ( 
	SELECT lb.LibraryId
    FROM LibrariesBooks AS lb 
		JOIN Books AS b ON b.Id = lb.BookId
    WHERE b.GenreId = (SELECT Id FROM Genres WHERE [Name] = 'Mystery')
)
ORDER BY [Library]