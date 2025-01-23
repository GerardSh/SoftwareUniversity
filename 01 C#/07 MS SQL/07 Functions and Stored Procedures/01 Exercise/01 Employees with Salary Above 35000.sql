CREATE PROC dbo.usp_GetEmployeesSalaryAbove35000
AS
	 SELECT
		   FirstName AS [First Name],
		    LastName AS [Last Name]
	   FROM Employees
      WHERE Salary > 35000