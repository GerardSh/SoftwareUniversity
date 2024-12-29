USE SoftUni

INSERT INTO Towns VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO Departments VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

	INSERT INTO Addresses VALUES
	('test1', 1)

--•	Employees:
--Name	                       Job Title	       Department           	Hire Date	   Salary
--Ivan Ivanov Ivanov	   .NET Developer	   Software Development	        01/02/2013	   3500.00
--Petar Petrov Petrov	   Senior Engineer	      Engineering	            02/03/2004	   4000.00
--Maria Petrova Ivanova	       Intern	      Quality Assurance          	28/08/2016	   525.25
--Georgi Teziev Ivanov	        CEO	                Sales	                09/12/2007	   3000.00
--Peter Pan Pan	               Intern	          Marketing             	28/08/2016	   599.88

INSERT INTO Employees VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013/02/01', 3500.00, 1),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004/03/02', 4000.00, null),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016/08/28', 525.25, null),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007/12/09', 3000.00, null),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016/08/28', 599.88, null)

	select * from Addresses