SELECT
c.CountryCode,
COUNT(MountainRange) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
AND c.CountryCode IN ('US', 'RU', 'BG')
JOIN Mountains AS m ON mc.MountainId = m.Id
GROUP BY c.CountryCode