CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(30))
RETURNS INT
AS
BEGIN

    RETURN (SELECT COUNT(*)
	        FROM CreatorsBoardgames				
			WHERE CreatorId = (SELECT Id FROM Creators WHERE FirstName = @name))

END