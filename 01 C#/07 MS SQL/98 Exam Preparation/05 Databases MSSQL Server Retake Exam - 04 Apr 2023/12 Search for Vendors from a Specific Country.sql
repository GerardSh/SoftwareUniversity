CREATE PROC dbo.usp_SearchByCountry(@country VARCHAR(30))
AS
BEGIN
	SELECT v.[Name] AS Vendor,
	       v.NumberVAT AS VAT,
		   a.StreetName + ' ' + CONVERT(VARCHAR, a.StreetNumber) AS [Street Info],
		   a.City + ' ' + CONVERT(VARCHAR, a.PostCode) AS [City Info]
	FROM Vendors AS v
		JOIN Addresses AS a ON a.Id = v.AddressId
		JOIN Countries AS c ON c.Id = a.CountryId
	WHERE c.[Name] = @country
	ORDER BY Vendor, [City Info]
END