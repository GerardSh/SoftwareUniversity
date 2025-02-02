UPDATE c
SET c.Website = 'www.' + LOWER(REPLACE(a.[Name], ' ', '')) + '.com'
FROM Contacts AS c
JOIN Authors AS a ON a.ContactId = c.Id
WHERE c.Website IS NULL