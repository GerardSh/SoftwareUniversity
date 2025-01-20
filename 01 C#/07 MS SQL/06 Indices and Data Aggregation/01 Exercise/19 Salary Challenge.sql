  SELECT TOP (10) FirstName, LastName, DepartmentID
    FROM Employees AS emp1
   WHERE Salary > (SELECT AVG(Salary) 
                     FROM Employees AS emp2
					WHERE emp1.DepartmentID = emp2.DepartmentID
			     GROUP BY emp2.DepartmentID)
ORDER BY DepartmentID