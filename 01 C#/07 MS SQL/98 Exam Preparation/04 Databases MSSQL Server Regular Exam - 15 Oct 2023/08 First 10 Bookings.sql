SELECT TOP 10
 h.[Name] AS HotelName,
 d.[Name] AS DestinationName,
 c.[Name] AS CountryName
FROM Bookings AS b
	JOIN Hotels AS h ON h.Id = b.HotelId
	JOIN Destinations AS d ON d.Id = h.DestinationId
	JOIN Countries AS c ON c.Id = d.CountryId
WHERE ArrivalDate < '2023-12-31' AND h.Id % 2 = 1
ORDER BY c.Name, ArrivalDate