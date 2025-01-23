CREATE PROC dbo.usp_GetEmployeesFromTown
@townName VARCHAR(30)
AS
 SELECT 
		FirstName AS [First Name],
		LastName AS [Last Name]
 FROM Employees AS e
 JOIN Addresses AS a ON e.AddressID = a.AddressID
 JOIN Towns AS t ON a.TownID = t.TownID
 WHERE t.[Name] = @townName