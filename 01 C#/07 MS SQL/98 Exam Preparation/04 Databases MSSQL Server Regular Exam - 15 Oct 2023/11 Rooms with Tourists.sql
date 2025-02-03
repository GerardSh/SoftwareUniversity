CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(30))
RETURNS INT
AS
BEGIN

    RETURN (SELECT SUM(b.AdultsCount + b.ChildrenCount) 
	        FROM Bookings AS b
				JOIN Rooms AS r ON r.Id = b.RoomId
			WHERE r.Type = @name)
     
END