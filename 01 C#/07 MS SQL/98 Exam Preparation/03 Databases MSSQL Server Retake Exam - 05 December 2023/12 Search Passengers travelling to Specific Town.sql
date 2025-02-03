CREATE PROC dbo.usp_SearchByTown(@townName VARCHAR(30))
AS
BEGIN
	SELECT p.[Name] AS PassengerName,
		   DateOfDeparture,
		   HourOfDeparture
	FROM Trains AS t
		JOIN Towns AS tn ON tn.Id = t.ArrivalTownId
		JOIN Tickets AS ti ON ti.TrainId = t.Id
		JOIN Passengers AS p ON p.Id = ti.PassengerId
	WHERE tn.[Name] = @townName
	ORDER BY DateOfDeparture DESC, p.[Name]
END