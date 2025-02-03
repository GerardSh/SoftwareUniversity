UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE Id IN (SELECT Id FROM Bookings
			 WHERE ArrivalDate LIKE '2023-12%')

UPDATE Tourists
SET Email = NULL
WHERE [Name] LIKE ('%MA%')