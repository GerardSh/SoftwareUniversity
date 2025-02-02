SELECT FullName,
	   PhoneNumber,
	   Price AS OrderPrice,
	   o.ShoeId,
	   BrandId,
	   CONCAT_WS('/', CONVERT(VARCHAR, sz.EU) + 'EU', CONVERT(VARCHAR, sz.US) + 'US', CONVERT(VARCHAR, sz.UK) + 'UK') AS ShoeSize
FROM Orders AS o
	JOIN Users AS u ON u.Id = o.UserId
	JOIN Shoes AS s ON s.Id = o.ShoeId
	JOIN Sizes AS sz ON sz.Id = o.SizeId
WHERE PhoneNumber LIKE '%345%'
ORDER BY s.Model