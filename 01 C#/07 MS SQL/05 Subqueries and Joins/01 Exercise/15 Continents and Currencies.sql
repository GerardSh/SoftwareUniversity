  SELECT ContinentCode,
         CurrencyCode,
		 CurrencyUsage
    FROM (SELECT ContinentCode,
	               CurrencyCode,
				   COUNT(CurrencyCode) AS CurrencyUsage,
		 		   DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
              FROM Countries
          GROUP BY ContinentCode, CurrencyCode) AS Temp
   WHERE CurrencyUsage > 1 AND Ranked = 1
ORDER BY ContinentCode