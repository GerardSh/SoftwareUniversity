DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = 'Stamat');

DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] = 'Safflower');

DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId);

DECLARE @stamatCash DECIMAL(15,2) = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);

DECLARE @itemsPrice DECIMAL(15,2) = (SELECT SUM(Price) FROM Items WHERE MinLevel IN (11, 12));

IF(@stamatCash >= @itemsPrice)
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
		   SET Cash -= @itemsPrice
		 WHERE Id = @userGameId;

		 INSERT INTO UserGameItems (ItemId, UserGameId) 
		 SELECT Id, @userGameId FROM Items WHERE MinLevel IN (11, 12);
	COMMIT
END;

SET @stamatCash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);

SET @itemsPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21);

IF(@stamatCash >= @itemsPrice)
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
		   SET Cash -= @itemsPrice
		 WHERE Id = @userGameId;

		 INSERT INTO UserGameItems (ItemId, UserGameId)
		 SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 19 AND 21;
	COMMIT
END

   SELECT i.[Name] 
     FROM Items AS i
     JOIN UserGameItems AS ugi ON i.Id = ugi.ItemId
    WHERE UserGameId = @userGameId
 ORDER BY i.[Name]