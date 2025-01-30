CREATE TABLE Deleted_Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	MiddleName VARCHAR(50) NOT NULL, 
	JobTitle VARCHAR(50) NOT NULL, 
	DepartmentId INT NOT NULL, 
	Salary MONEY NOT NULL
)

GO

CREATE TRIGGER tr_DeletedEmployees
ON Employees FOR DELETE
AS 
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted;