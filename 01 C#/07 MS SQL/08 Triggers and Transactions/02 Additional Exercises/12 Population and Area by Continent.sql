SELECT ContinentName,
	   SUM(CONVERT(BIGINT,cntr.AreaInSqKm)) AS CountriesArea,
	   SUM(CONVERT(BIGINT, cntr.[Population])) AS CountriesPopulation
FROM Continents AS cont
	 JOIN Countries As cntr ON cntr.ContinentCode = cont.ContinentCode
GROUP BY ContinentName
ORDER BY CountriesPopulation DESC