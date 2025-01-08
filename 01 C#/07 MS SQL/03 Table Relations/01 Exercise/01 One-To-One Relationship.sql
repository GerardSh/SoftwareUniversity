CREATE TABLE Passports
(
  PassportID INT IDENTITY(101,1) PRIMARY KEY,
  PassportNumber NVARCHAR(30)
)

CREATE TABLE Persons
(
  PersonID INT IDENTITY PRIMARY KEY ,
  FirstName NVARCHAR(30),
  Salary MONEY,
  PassportID INT UNIQUE,
  CONSTRAINT FK_PersonsPassports FOREIGN KEY (PassportID) 
  REFERENCES Passports(PassportID)
)

INSERT INTO Passports VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)