SELECT
	u.Username,
	EMAIL AS Email,
	CONVERT(DECIMAL(10,2), ROUND(AVG(s.Price), 2)) AS AvgPrice
FROM Users AS u
	JOIN Orders AS o ON o.UserId = u.Id
	JOIN Shoes AS s ON s.Id = o.ShoeId
GROUP BY u.Username, EMAIL
HAVING COUNT(*) > 2
ORDER BY AvgPrice DESC