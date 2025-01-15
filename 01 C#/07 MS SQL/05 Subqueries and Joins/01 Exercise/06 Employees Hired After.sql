SELECT
FirstName,
LastName,
HireDate,
[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON
e.DepartmentID = d.DepartmentID
AND HireDate > '1.1.1999'
AND [Name] IN ('Finance', 'Sales')
ORDER BY HireDate