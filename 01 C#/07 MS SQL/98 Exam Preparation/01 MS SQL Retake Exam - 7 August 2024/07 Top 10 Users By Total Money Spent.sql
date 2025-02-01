SELECT TOP 10 
	u.Id AS UserId,
	FullName,
	SUM(s.Price) AS TotalSpent
FROM Users AS u
	JOIN Orders AS o ON o.UserId = u.Id
	JOIN Shoes AS s ON s.Id = o.ShoeId
GROUP BY u.Id, FullName
ORDER BY TotalSpent DESC, FullName