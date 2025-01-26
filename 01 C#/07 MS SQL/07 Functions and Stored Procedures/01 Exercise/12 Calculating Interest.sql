CREATE PROC dbo.usp_CalculateFutureValueForAccount
(@accountId INT, @interestRate FLOAT)
AS
 SELECT 
 ah.Id AS [Account Id],
 FirstName AS [First Name],
 LastName AS [Last Name],
 Balance AS [Current Balance],
 dbo.ufn_CalculateFutureValue(Balance, @interestRate, 5) AS [Balance in 5 years]
 FROM Accounts AS a
JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
WHERE a.Id = @accountId