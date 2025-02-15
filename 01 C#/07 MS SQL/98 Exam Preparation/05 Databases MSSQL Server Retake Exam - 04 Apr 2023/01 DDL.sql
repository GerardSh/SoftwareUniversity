CREATE DATABASE Accounting

GO

USE Accounting

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(20) NOT NULL,
	StreetNumber INT,
	PostCode INT NOT NULL,
	City VARCHAR(25) NOT NULL,
	CountryId INT REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Vendors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT REFERENCES Addresses(Id) NOT NULL
)


CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(35) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	VendorId INT REFERENCES Vendors(Id) NOT NULL
)

CREATE TABLE Invoices
(
	Id INT PRIMARY KEY IDENTITY,
	Number INT NOT NULL UNIQUE,
	IssueDate DATETIME2 NOT NULL,
	DueDate DATETIME2 NOT NULL,
	Amount DECIMAL(18,2) NOT NULL,
	Currency VARCHAR(5) NOT NULL,
	ClientId INT REFERENCES Clients(Id) NOT NULL
)

CREATE TABLE ProductsClients
(
	ProductId INT REFERENCES Products(Id),
	ClientId INT REFERENCES Clients(Id)
	PRIMARY KEY (ProductId, ClientId)
)