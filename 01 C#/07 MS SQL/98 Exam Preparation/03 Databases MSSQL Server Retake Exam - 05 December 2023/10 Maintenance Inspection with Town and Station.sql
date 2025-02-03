SELECT TrainId,
	   tn.[Name] AS DepartureTown,
	   Details
FROM MaintenanceRecords AS mr
	JOIN Trains AS t ON t.Id = mr.TrainId
	JOIN Towns AS tn ON tn.Id = t.DepartureTownId
WHERE Details LIKE '%inspection%'
ORDER BY TrainId