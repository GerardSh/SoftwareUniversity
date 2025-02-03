UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE IssueDate LIKE '2022-11%'

UPDATE Clients
SET AddressId = (SELECT Id 
				 FROM Addresses AS a 
				 WHERE a.StreetName = 'Industriestr' AND 
				       a.StreetNumber = 79 AND 
					   a.PostCode = 2353 AND 
					   a.City = 'Guntramsdorf' AND 
					   CountryId = (SELECT Id FROM Countries WHERE [Name] = 'Austria'))
WHERE [Name] LIKE '%CO%'