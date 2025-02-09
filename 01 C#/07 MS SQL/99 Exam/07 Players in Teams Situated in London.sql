SELECT * 
FROM Players AS p
WHERE p.Id IN (SELECT PlayerId FROM PlayersTeams AS pt
					JOIN Teams AS t ON t.Id = pt.TeamId
			   WHERE t.City = 'London')
ORDER BY p.[Name]