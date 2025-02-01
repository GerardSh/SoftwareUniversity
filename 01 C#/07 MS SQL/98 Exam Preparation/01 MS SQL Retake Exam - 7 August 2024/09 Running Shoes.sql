SELECT Model,
	   COUNT(*) AS CountOfSizes,
	   b.[Name] AS BrandName
FROM Shoes AS s
JOIN Brands AS b ON b.Id = s.BrandId
JOIN ShoesSizes AS ss ON ss.ShoeId = s.Id
WHERE b.[Name] = 'Nike' AND s.Model LIKE '%Run%'
GROUP BY s.Model, b.[Name]
HAVING  COUNT(*) > 5
ORDER BY s.Model DESC
