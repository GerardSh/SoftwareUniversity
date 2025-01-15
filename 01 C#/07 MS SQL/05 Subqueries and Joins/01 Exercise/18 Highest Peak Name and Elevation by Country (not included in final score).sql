SELECT TOP (5) Temp.CountryName, 
Temp.[Highest Peak Name], 
Temp.[Highest Peak Elevation], 
Temp.Mountain
FROM (SELECT c.CountryName, 
ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
ISNULL(p.Elevation, 0) AS [Highest Peak Elevation],
ISNULL(m.MountainRange, '(no mountain)') AS Mountain,
DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS Ranked
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId) AS Temp
WHERE Ranked = 1 
ORDER BY Temp.CountryName, Temp.[Highest Peak Name]