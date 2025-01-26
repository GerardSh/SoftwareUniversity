CREATE PROC usp_GetHoldersWithBalanceHigherThan
@number MONEY
AS
SELECT FirstName AS [First Name], LastName AS [Last Name] FROM AccountHolders AS ah
JOIN Accounts AS a ON ah.Id = a.AccountHolderId
GROUP BY FirstName, LastName
HAVING SUM(Balance) > @number
ORDER BY FirstName, LastName