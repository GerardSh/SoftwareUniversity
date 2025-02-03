SELECT h.[Name] AS HotelName, Price AS RoomPrice 
FROM Tourists AS t
	JOIN Bookings AS b ON b.TouristId = t.Id
	JOIN Rooms AS r ON r.Id = b.RoomId
	JOIN Hotels AS h ON h.Id = b.HotelId
WHERE t.[Name] NOT LIKE '%EZ'
ORDER BY Price DESC