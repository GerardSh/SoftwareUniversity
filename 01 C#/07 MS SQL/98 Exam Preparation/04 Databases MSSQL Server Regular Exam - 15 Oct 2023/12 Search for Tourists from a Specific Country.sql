CREATE PROC dbo.usp_SearchByCountry(@country VARCHAR(30))
AS
BEGIN
	SELECT t.[Name], PhoneNumber, Email, COUNT(*) AS CountOfBookings
	FROM Tourists AS t
		JOIN Countries AS c ON c.Id = t.CountryId
		JOIN Bookings AS b ON b.TouristId = t.Id
	WHERE c.[Name] = @country
	GROUP BY t.[Name], PhoneNumber, Email
	ORDER BY t.[Name], CountOfBookings DESC
END