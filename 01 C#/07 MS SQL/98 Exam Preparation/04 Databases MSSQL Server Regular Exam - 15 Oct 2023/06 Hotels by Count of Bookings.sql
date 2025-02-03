SELECT h.Id, [Name]
FROM Hotels AS h
	JOIN Bookings AS b ON b.HotelId = h.Id
WHERE h.Id IN (SELECT hr.HotelId
FROM Hotels AS h
	JOIN HotelsRooms AS hr ON hr.HotelId = h.Id
	JOIN Rooms AS r ON r.Id = hr.RoomId
WHERE r.[Type] LIKE 'VIP Apartment')
GROUP BY h.Id, [Name]
ORDER BY COUNT(*) DESC