SELECT [Name] AS PassangerName,
	   Price AS TicketPrice,
	   DateOfDeparture,
	   TrainId
FROM Tickets AS t
	JOIN Passengers AS p ON p.Id = t.PassengerId
ORDER BY Price DESC, [Name]