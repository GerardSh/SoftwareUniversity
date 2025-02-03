SELECT t.Id, [Name], PhoneNumber
FROM Tourists AS t
	LEFT JOIN Bookings AS b ON t.Id = b.TouristId
WHERE b.Id IS NULL
ORDER BY [Name]