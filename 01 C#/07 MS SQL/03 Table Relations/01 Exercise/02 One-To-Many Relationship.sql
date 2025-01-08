CREATE TABLE Manufacturers
(
  ManufacturerID INT IDENTITY PRIMARY KEY,
  [Name] NVARCHAR(30) NOT NULL UNIQUE,
  EstablishedOn DATE
)

CREATE TABLE Models
(
  ModelID INT IDENTITY(101,1) PRIMARY KEY,
  [Name] NVARCHAR(30) NOT NULL,
  ManufacturerID INT REFERENCES Manufacturers(ManufacturerID)
  --,CONSTRAINT UQ_Models_ManufacturerID_Name UNIQUE (ManufacturerID, [Name])
)

INSERT INTO Manufacturers VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/01/2003')

INSERT INTO Models VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)