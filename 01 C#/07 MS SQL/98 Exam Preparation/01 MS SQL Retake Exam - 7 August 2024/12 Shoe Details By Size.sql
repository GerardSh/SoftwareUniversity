CREATE PROC dbo.usp_SearchByShoeSize(@shoeSize DECIMAL(5,2))
AS
 SELECT s.Model AS ModelName,
		u.FullName,
		CASE 
			WHEN s.Price < 100 THEN 'Low'
			WHEN s.Price <= 200 THEN 'Medium'
			ELSE 'High'
	    END AS PriceLevel,
		b.[Name] AS BrandName,
		sz.EU AS SizeEU
 FROM Orders AS o
	JOIN Users AS u ON u.Id = o.UserId
	JOIN Shoes AS s ON s.Id = o.ShoeId
	JOIN Sizes AS sz ON sz.Id = o.SizeId
	JOIN Brands AS b ON b.Id = s.BrandId
 WHERE sz.EU = @shoeSize
 ORDER BY b.[Name], u.FullName