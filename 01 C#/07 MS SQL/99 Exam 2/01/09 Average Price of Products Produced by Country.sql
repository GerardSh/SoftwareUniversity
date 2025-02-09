SELECT Country AS CountryName, 
COUNT(DISTINCT m.Id) AS ProducersCount,
FORMAT(AVG(p.Price), 'N2') AS AvgProductPrice
FROM Manufacturers AS m
JOIN Products AS p ON p.ManufacturerId = m.Id
GROUP BY m.Country
ORDER BY ProducersCount DESC, AvgProductPrice
