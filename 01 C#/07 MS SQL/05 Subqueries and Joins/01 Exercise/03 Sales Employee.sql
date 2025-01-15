SELECT
EmployeeID,
FirstName,
LastName,
d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND [Name] = 'Sales'
ORDER BY EmployeeID