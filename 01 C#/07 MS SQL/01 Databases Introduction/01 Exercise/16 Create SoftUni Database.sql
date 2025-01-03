CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(50) NOT NULL,
	TownId INT NOT NULL,
	FOREIGN KEY (TownId) REFERENCES Towns ([Id])
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(25) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(15) NOT NULL,
	MiddleName VARCHAR(15) NOT NULL,
	LastName VARCHAR(15) NOT NULL,
	JobTitle VARCHAR(15) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(6,2) NOT NULL,
	AddressId INT,
	FOREIGN KEY (AddressId) REFERENCES Addresses (Id),
	FOREIGN KEY (DepartmentId) REFERENCES Departments (Id)
)