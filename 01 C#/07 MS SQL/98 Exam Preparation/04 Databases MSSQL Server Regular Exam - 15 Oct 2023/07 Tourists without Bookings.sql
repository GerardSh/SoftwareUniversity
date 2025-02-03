SELECT Id, [Name], PhoneNumber
FROM Tourists
WHERE Id NOT IN (SELECT TouristId FROM Bookings)
ORDER BY [Name]