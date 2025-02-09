 SELECT m.Country AS CountryName,
		(SELECT COUNT(*) FROM Manufacturers AS m2 WHERE m2.Country = m.Country) AS ProducersCount,
		FORMAT(AVG(Price), 'N2') AS AvgProductPrice
 FROM Manufacturers AS m
 JOIN Products AS p ON p.ManufacturerId = m.Id
 GROUP BY m.Country
 ORDER BY ProducersCount DESC, AvgProductPrice