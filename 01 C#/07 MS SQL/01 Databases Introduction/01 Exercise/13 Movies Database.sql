CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY,
	DirectorName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors VALUES
	(1, 'Name1', null),
	(2, 'Name2', null),
	(3, 'Name3', null),
	(4, 'Name4', null),
	(5, 'Name5', null)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY,
	GenreName VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Genres VALUES
	(1, 'Genre1', null),
	(2, 'Genre2', null),
	(3, 'Genre3', null),
	(4, 'Genre4', null),
	(5, 'Genre5', null)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Categories VALUES
	(1, 'Category1', null),
	(2, 'Category2', null),
	(3, 'Category3', null),
	(4, 'Category4', null),
	(5, 'Category5', null)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATE NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes VARCHAR(MAX)
)

INSERT INTO Movies VALUES
	(1, 'Title1', 1, '2001/01/01', '01:01', 1, 1, null, null),
	(2, 'Title2', 2, '2002/02/02', '02:02', 2, 2, null, null),
	(3, 'Title3', 3, '2003/03/03', '03:03', 3, 3, null, null),
	(4, 'Title4', 4, '2004/04/04', '04:04', 4, 4, null, null),
	(5, 'Title5', 5, '2005/05/05', '05:05', 5, 5, null, null)