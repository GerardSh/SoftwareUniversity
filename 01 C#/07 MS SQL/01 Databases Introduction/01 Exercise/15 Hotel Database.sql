CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(15) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
	(1, 'FirstName1', 'LastName1', 'Employee1', null),
	(2, 'FirstName2', 'LastName2', 'Employee2', null),
	(3, 'FirstName3', 'LastName3', 'Employee3', null)

CREATE TABLE Customers 
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	PhoneNumber CHAR(10),
	EmergencyName VARCHAR(20) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
	(1, 'FirstName1', 'LastName1', null, 'EmergencyName1', '1234567890', null),
	(2, 'FirstName2', 'LastName2', null, 'EmergencyName2', '2345678901', null),
	(3, 'FirstName3', 'LastName3', null, 'EmergencyName3', '3456789012', null)

CREATE TABLE RoomStatus 
(
	RoomStatus VARCHAR(15) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
	('Free', null),
	('Occupied', null),
	('Busy', null)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(15) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
	('SingleRoom', null),
	('DoubleRoom', null),
	('ChildRoom', null)

CREATE TABLE BedTypes
(
	BedType VARCHAR(15) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
	('SingleBed', null),
	('DoubleBed', null),
	('ChildBed', null)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(15) NOT NULL,
	BedType VARCHAR(15) NOT NULL,
	Rate INT,
	RoomStatus VARCHAR(15) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms VALUES
	(1, 'SingleRoom', 'SingleBed', null, 'Free', null),
	(2, 'DoubleRoom', 'DoubleBed', null, 'Occupied', null),
	(3, 'ChildRoom', 'ChildBed', null, 'Busy', null)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(10,2),
	TaxRate DECIMAL(10,2),
	TaxAmount DECIMAL(10,2),
	PaymentTotal DECIMAL(10,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments VALUES
	(1, 1, '2001/01/01', 1, '2001/01/10', '2001/01/20', 10, 10.25, 1.25, 11.25, 111.25, null),
	(2, 2, '2002/02/02', 2, '2002/02/10', '2002/02/20', 10, 20.25, 2.25, 21.25, 211.25, null),
	(3, 3, '2003/03/03', 3, '2003/03/10', '2003/03/20', 10, 30.25, 3.25, 31.25, 311.25, null)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(10,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
	(1, 1, '2001/01/01', 1, 1, null, null, null),
	(2, 2, '2002/02/02', 2, 2, null, null, null),
	(3, 3, '2003/03/03', 3, 3, null, null, null)