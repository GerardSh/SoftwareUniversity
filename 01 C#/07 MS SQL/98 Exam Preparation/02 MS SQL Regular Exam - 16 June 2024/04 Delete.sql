DECLARE @AuthorId INT = (SELECT Id FROM Authors WHERE [Name] =  'Alex Michaelides')

DELETE lb
FROM LibrariesBooks AS lb
JOIN Books AS b ON b.Id = lb.BookId
WHERE b.Id = @AuthorId

DELETE FROM Books
WHERE AuthorId = @AuthorId

DELETE FROM Authors
WHERE Id = @AuthorId