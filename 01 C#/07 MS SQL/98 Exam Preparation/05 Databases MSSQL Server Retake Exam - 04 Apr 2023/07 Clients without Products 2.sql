SELECT c.Id,
       c.[Name] AS Client,
	   CONCAT_WS(', ', a.Streetname + ' ' + CONVERT(VARCHAR, a.StreetNumber), a.City, a.PostCode, ctr.[Name]) AS [Address]
FROM CLients AS c
	JOIN Addresses AS a ON a.Id = c.AddressId
	JOIN Countries AS ctr ON ctr.Id = a.CountryId
WHERE c.Id NOT IN (SELECT ClientId FROM ProductsClients)
ORDER BY Client