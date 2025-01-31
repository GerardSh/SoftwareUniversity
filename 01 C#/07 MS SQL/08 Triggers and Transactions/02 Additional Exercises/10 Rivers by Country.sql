SELECT CountryName,
	   co.ContinentName,
	   COUNT(r.RiverName) AS RiversCount,  
	   CASE 
			WHEN COUNT(r.RiverName) > 0
			THEN SUM(r.Length)
			ELSE 0
	   END  AS TotalLength   
FROM Countries AS c
     LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
     LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	 LEFT JOIN Continents AS co ON co.ContinentCode = c.ContinentCode
GROUP BY CountryName, ContinentName
ORDER BY RiversCount DESC,
         TotalLength DESC,
		 CountryName