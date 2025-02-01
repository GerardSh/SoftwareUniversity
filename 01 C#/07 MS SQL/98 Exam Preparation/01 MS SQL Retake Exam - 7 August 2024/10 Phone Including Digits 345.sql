SELECT FullName,
	   PhoneNumber,
	   Price AS OrderPrice,
	   ss.ShoeId,
	   BrandId
FROM Orders as o
	JOIN Users as u ON u.Id = o.UserId
	JOIN Shoes as s ON s.Id = o.ShoeId
	JOIN ShoesSizes AS ss ON ss.ShoeId = s.Id
	JOIN Sizes AS sz ON sz.Id = ss.SizeId
WHERE PhoneNumber LIKE '%345%'
ORDER BY s.Model