CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50))
RETURNS TABLE
AS
	RETURN (SELECT SUM(Cash) AS SumCash
              FROM (SELECT ug.Cash, ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS Arrangement
                      FROM Games AS g
                      JOIN UsersGames AS ug ON g.Id = ug.GameId
                     WHERE g.[Name] = @gameName) AS Temp
             WHERE Arrangement % 2 != 0)