SELECT s.[Name], COUNT(*) AS ProductCount, FORMAT(AVG(p.Price), 'N2') AS AveragePrice
FROM Stores AS s
JOIN StoresProducts AS sp ON sp.StoreId = s.Id
JOIN Products AS p ON p.Id = sp.ProductId
WHERE p.Price > 800
GROUP BY s.[Name]
HAVING COUNT(*) >=4
ORDER BY AveragePrice DESC