CREATE FUNCTION udf_ProductWithClients(@name VARCHAR(30))
RETURNS INT
AS
BEGIN

    RETURN (SELECT COUNT(*)
	        FROM ProductsClients				
			WHERE ProductId = (SELECT Id FROM Products WHERE [Name] = @name))

END