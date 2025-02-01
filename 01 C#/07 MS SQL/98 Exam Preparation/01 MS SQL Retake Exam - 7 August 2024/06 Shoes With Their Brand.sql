SELECT b.[Name] AS BrandName,
	   s.Model AS ShoeModel
FROM Shoes AS s
	JOIN  Brands AS b ON b.Id = s.BrandId
ORDER BY b.[Name], Model
