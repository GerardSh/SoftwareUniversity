CREATE PROC dbo.usp_GetTownsStartingWith
@startingString VARCHAR(30)
AS
	SELECT [Name] AS Town
	  FROM Towns
	  WHERE LEFT([Name], LEN(@startingString)) = @startingString