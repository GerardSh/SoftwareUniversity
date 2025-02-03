SELECT tns.[Name] AS TownName, COUNT(DISTINCT p.Id) AS PassengerCount
FROM Passengers AS p
	JOIN Tickets AS ti ON ti.PassengerId = p.Id
	JOIN Trains as t ON t.Id = ti.TrainId
	JOIN Towns AS tns ON tns.Id = t.ArrivalTownId
WHERE ti.Price > 76.99
GROUP BY tns.[Name]
ORDER BY tns.[Name]