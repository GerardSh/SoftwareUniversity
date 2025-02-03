SELECT h.Name AS HotelName, SUM(DATEDIFF(day, ArrivalDate, DepartureDate) * Price) AS HotelRevenue
FROM Bookings AS b
	JOIN Rooms AS r ON r.Id = b.RoomId
	JOIN Hotels AS h ON h.Id = b.HotelId
GROUP BY h.[Name]
ORDER BY HotelRevenue DESC