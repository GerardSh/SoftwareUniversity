UPDATE Tickets
SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
    DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE MONTH(DateOfDeparture) > 10