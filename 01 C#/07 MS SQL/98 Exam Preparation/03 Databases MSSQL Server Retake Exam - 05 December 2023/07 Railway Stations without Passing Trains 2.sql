SELECT t.[Name] AS Town, rs.[Name] AS RailwayStation
FROM RailwayStations AS rs
	JOIN Towns AS t ON t.Id = rs.TownId
	LEFT JOIN TrainsRailwayStations AS ts ON ts.RailwayStationId = rs.Id
WHERE ts.RailwayStationId IS NULL
ORDER BY t.[Name], rs.[Name]