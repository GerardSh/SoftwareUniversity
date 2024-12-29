CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(20) NOT NULL,
	DailyRate DECIMAL(5,2) NOT NULL,
	WeeklyRate DECIMAL(5,2) NOT NULL,
	MonthlyRate DECIMAL(6,2) NOT NULL,
	WeekendRate DECIMAL(5,2) NOT NULL
)

INSERT INTO Categories VALUES
	(1, 'Category1', 100.01, 500.05, 2000.55, 180.88),
	(2, 'Category2', 120.02, 600.06, 2200.88, 200.55),
	(3, 'Categiry3', 150.05, 700.07, 2500.99, 220.75)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY,
	PlateNumber CHAR(8) NOT NULL,
	Manufacturer VARCHAR(15) NOT NULL,
	Model VARCHAR(15) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARCHAR(MAX) NOT NULL,
	Condition VARCHAR(MAX),
	Available BIT NOT NULL
)

INSERT INTO Cars VALUES
	(1, 'BG1111BG', 'Manufacturer1', 'Model1', '2001/01/01', 1, 1, 'https://www.google.com/imgres?imgurl=https%3A%2F%2Fimageio.forbes.com%2Fspecials-images%2Fimageserve%2F5d35eacaf1176b0008974b54%2F2020-Chevrolet-Corvette-Stingray%2F0x0.jpg%3Ffit%3Dcrop%26format%3Djpg%26crop%3D4560%2C2565%2Cx790%2Cy784%2Csafe&imgrefurl=https%3A%2F%2Fwww.forbes.com%2Fsites%2Fjimgorzelany%2F2019%2F07%2F23%2Fhere-are-the-coolest-new-cars-for-2020%2F&tbnid=8g-t95qhDcTJnM&vet=12ahUKEwiWkbDr86X3AhXaIMUKHUBBArMQMygAegUIARC8AQ..i&docid=HZLLyFhoQjvNCM&w=4560&h=2565&q=CARS&client=firefox-b-d&ved=2ahUKEwiWkbDr86X3AhXaIMUKHUBBArMQMygAegUIARC8AQ', null, 0),
	(2, 'BG2222BG', 'Manufacturer2', 'Model2', '2002/02/02', 2, 2, 'https://www.google.com/imgres?imgurl=https%3A%2F%2Fcdn.motor1.com%2Fimages%2Fmgl%2Fmrz1e%2Fs3%2Fcoolest-cars-feature.jpg&imgrefurl=https%3A%2F%2Fwww.motor1.com%2Fcar-lists%2Fcoolest-cars%2F&tbnid=iKHd7iHaURskjM&vet=12ahUKEwiWkbDr86X3AhXaIMUKHUBBArMQMygBegUIARC-AQ..i&docid=sRjt3evgEkKkZM&w=1280&h=720&q=CARS&client=firefox-b-d&ved=2ahUKEwiWkbDr86X3AhXaIMUKHUBBArMQMygBegUIARC-AQ', null, 1),
	(3, 'BG3333BG', 'Manufacturer3', 'Model3', '2003/03/03', 3, 3, 'https://www.google.com/imgres?imgurl=https%3A%2F%2Fichef.bbci.co.uk%2Fnews%2F976%2Fcpsprodpb%2FBE5A%2Fproduction%2F_123303784_gettyimages-524191066.jpg&imgrefurl=https%3A%2F%2Fwww.bbc.com%2Fnews%2Fbusiness-60579640&tbnid=JuXIiZSQr__UAM&vet=12ahUKEwiWkbDr86X3AhXaIMUKHUBBArMQMygGegUIARDIAQ..i&docid=rvgXXQNb2A5j8M&w=976&h=549&q=CARS&client=firefox-b-d&ved=2ahUKEwiWkbDr86X3AhXaIMUKHUBBArMQMygGegUIARDIAQ', null, 0)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(15) NOT NULL,
	LastName VARCHAR(15) NOT NULL,
	Title VARCHAR(15) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
	(1, 'FirstName1', 'LastName1', 'Employee1', null),
	(2, 'FirstName2', 'LastName2', 'Employee2', null),
	(3, 'FirstName3', 'LastName3', 'Employee3', null)

CREATE TABLE Customers 
(
	Id INT PRIMARY KEY,
	DriverLicenceNumber INT NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(50), 
	City VARCHAR(20),
	ZIPCode CHAR(4),
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
	(1, 1, 'Name1', null, null, null, null),
	(2, 2, 'Name2', null, null, null, null),
	(3, 3, 'Name3', null, null, null, null)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(5,2) NOT NULL,
	TaxRate DECIMAL(5,2) NOT NULL,
	OrderStatus VARCHAR(15) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders VALUES
	(1, 1, 1, 1, 10, 100, 110, 10, '2001/01/01', '2001/01/10', 10, 100.11, 111.11, 'Done', null),
	(2, 2, 2, 2, 20, 200, 220, 20, '2002/02/01', '2002/02/20', 20, 200.22, 222.22, 'Done', null),
	(3, 3, 3, 3, 30, 300, 330, 30, '2003/03/01', '2003/03/30', 30, 300.33, 333.33, 'Done', null)