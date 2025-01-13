SELECT 
p.PeakName,
r.RiverName,
CONCAT(LOWER(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) -1)), LOWER(r.RiverName)) AS Mix
FROM Peaks AS p
JOIN Rivers AS r ON RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix