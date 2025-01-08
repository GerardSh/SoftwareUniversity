SELECT
m.MountainRange,
p.PeakName,
p.Elevation
FROM Mountains AS m
JOIN Peaks AS p ON m.Id = p.MountainId AND m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC