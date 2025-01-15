SELECT TOP 5
EmployeeID,
FirstName,
Salary,
d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND Salary > 15000
ORDER BY e.DepartmentID