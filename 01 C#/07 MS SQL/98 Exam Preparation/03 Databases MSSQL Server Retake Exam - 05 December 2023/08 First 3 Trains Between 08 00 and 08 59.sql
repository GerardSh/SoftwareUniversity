SELECT TOP 3 tts.TrainId,
			  HourOfDeparture,
			  Price AS TicketPrice,
			  tns.[Name] AS Destination
FROM Trains AS t
	JOIN Tickets AS tts ON tts.TrainId = t.Id
	JOIN Towns AS tns ON tns.Id = t.ArrivalTownId
WHERE LEFT(HourOfDeparture,2) = 8 AND tts.Price > 50
ORDER BY Price, CONVERT(INT, RIGHT(HourOfDeparture, 2))
--WHERE t.HourOfDeparture LIKE '08:%' AND ti.Price > 50.00
--ORDER BY Price