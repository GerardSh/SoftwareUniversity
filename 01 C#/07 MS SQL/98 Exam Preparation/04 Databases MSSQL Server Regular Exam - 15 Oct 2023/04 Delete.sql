DELETE Bookings
WHERE TouristId IN (SELECT Id FROM Tourists WHERE [Name] LIKE '%Smith%')

DELETE Tourists
WHERE [Name] LIKE '%Smith%'