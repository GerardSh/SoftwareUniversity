CREATE FUNCTION udf_GetProductCountByManufacturer(@manu VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN 
	(
		SELECT COUNT(*) FROM Manufacturers AS m
		JOIN Products AS p ON p.ManufacturerId = m.Id
		WHERE m.[Name] = @manu 
	)
END