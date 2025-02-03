CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(30))
RETURNS INT
AS
BEGIN

 RETURN (
 SELECT COUNT(*) 
 FROM Trains AS t
	JOIN Towns AS ta ON ta.Id = t.ArrivalTownId
	JOIN Towns AS td ON td.Id = t.DepartureTownId
 WHERE ta.Name = @name OR td.Name = @name)

END