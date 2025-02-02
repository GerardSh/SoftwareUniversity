SELECT [Name] AS Author,
	   Email,
	   c.[PostAddress] AS [Address]
FROM Authors AS a
JOIN Contacts AS c ON c.Id = a.ContactId
WHERE c.PostAddress LIKE '%UK%'
ORDER BY [Name]