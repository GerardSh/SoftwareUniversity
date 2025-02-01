DECLARE @ShoeId INT = (SELECT Id FROM Shoes WHERE Model = 'Joyride Run Flyknit')

DELETE FROM Orders
WHERE ShoeId = @ShoeId

DELETE FROM ShoesSizes
WHERE ShoeId = @ShoeId

DELETE FROM Shoes
WHERE Id = @ShoeId