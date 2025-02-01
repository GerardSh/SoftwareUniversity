SELECT Model AS ShoeModel,
	   Price
FROM Orders AS o
	JOIN Shoes AS s ON s.Id = o.ShoeId
ORDER BY Price DESC,
		 Model