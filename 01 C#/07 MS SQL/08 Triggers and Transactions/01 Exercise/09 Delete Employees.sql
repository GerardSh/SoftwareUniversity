CREATE TABLE Deleted_Employees
(
EmployeeId INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
MiddleName VARCHAR(30),
JobTitle VARCHAR(30) NOT NULL,
DepartmentId INT,
Salary MONEY NOT NULL
)

CREATE TRIGGER tr_DeletedEmployees
ON Employees FOR DELETE
AS
 INSERT INTO Deleted_Employees
 SELECT 
 FirstName,
 LastName,
 MiddleName,
 JobTitle,
 DepartmentID,
 Salary
 FROM deleted