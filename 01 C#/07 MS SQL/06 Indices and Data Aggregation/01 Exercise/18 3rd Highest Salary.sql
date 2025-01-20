WITH RankedSalaries AS
(
    SELECT 
        DepartmentID,
        Salary,
        ROW_NUMBER() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
    FROM Employees
    GROUP BY DepartmentID, Salary
)
SELECT DepartmentID, Salary AS ThirdHighestSalary
FROM RankedSalaries
WHERE Rank = 3;




--2
SELECT DISTINCT Temp.DepartmentID, Temp.Salary AS ThirdHighestSalary
  FROM (SELECT DepartmentID, 
               Salary, 
			   DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranked]
          FROM Employees) AS Temp
 WHERE Ranked = 3