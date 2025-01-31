SELECT PeakName,
	   MountainRange AS Mointain,
	   Elevation
FROM Peaks AS p
	 JOIN Mountains AS m ON m.Id = p.MountainId
ORDER BY Elevation DESC,
		 PeakName