USE Minions

CREATE TABLE People
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(50),
[Height] DECIMAL(3,2),
[Weight] DECIMAL(5,2),
[Gender] CHAR(1) NOT NULL,
	 CHECK(Gender in('m', 'f')),
[Birthdate] DATETIME2 NOT NULL,
[Biography] VARCHAR(MAX)
)

INSERT INTO People ([Name], [Gender], [Birthdate])
VALUES
	('Pesho', 'm', '1998-05-05'),
	('Gosho', 'm', '1980-12-11'),
	('Tosho', 'm', '2008-03-02'),
	('Maria', 'f', '2003-02-12'),
	('Tania', 'f', '2008-06-23')