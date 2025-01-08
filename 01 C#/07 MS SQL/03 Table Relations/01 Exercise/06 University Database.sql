CREATE TABLE Majors
(
	MajorID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(30)
)

CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	StudentNumber INT,
	StudentName NVARCHAR(30),
	MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT IDENTITY PRIMARY KEY,
	PaymentDate DATE,
	PaymentAmount MONEY,
	StudentID INT REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
	SubjectID INT IDENTITY PRIMARY KEY,
	SubjectName NVARCHAR(30)
)

CREATE TABLE Agenda
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID),

	CONSTRAINT PK_StudentSubject PRIMARY KEY(StudentID, SubjectID)
)