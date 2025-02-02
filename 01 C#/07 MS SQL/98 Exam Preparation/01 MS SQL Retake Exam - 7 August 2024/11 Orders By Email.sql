CREATE FUNCTION udf_OrdersByEmail(@email VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN 
	(
		SELECT COUNT(*) FROM Orders AS o
		JOIN Users AS u ON u.Id = o.UserId
		WHERE u.EMAIL = @email
	)
END