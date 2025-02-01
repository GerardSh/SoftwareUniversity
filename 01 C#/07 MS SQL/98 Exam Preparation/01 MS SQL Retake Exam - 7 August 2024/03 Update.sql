UPDATE Shoes
   SET Price *= 1.15
WHERE BrandId = 
(
	SELECT Id FROM Brands
	WHERE [Name] = 'Nike'
)