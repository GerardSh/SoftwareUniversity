SELECT FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate,
	   AdultsCount,
	   ChildrenCount
FROM Bookings AS b
	JOIN Rooms AS r ON r.Id = b.RoomId 
ORDER BY Price DESC, ArrivalDate
