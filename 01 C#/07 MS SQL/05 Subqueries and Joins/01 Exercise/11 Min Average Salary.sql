SELECT
MIN(Temp.MinAverageSalary) AS MinAverageSalary
FROM (
SELECT 
AVG(Salary) AS MinAverageSalary
FROM Employees
GROUP BY DepartmentID
) AS Temp




--2
SELECT TOP (1) AVG(Salary) AS MinAverageSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary