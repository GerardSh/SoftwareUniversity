SELECT TOP 5
e.EmployeeID,
FirstName,
p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID 
AND p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY EmployeeID