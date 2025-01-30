--1:
CREATE TRIGGER tr_RestrictItems
ON UserGameItems INSTEAD OF INSERT
AS
	DECLARE @itemId INT = (SELECT ItemId FROM inserted);
	DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId);

	DECLARE @userGameId INT = (SELECT UserGameId FROM inserted);
	DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId);

	IF(@userGameLevel >= @itemLevel)
	BEGIN
		INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
		(@itemId, @userGameId)
	END

GO

SELECT * FROM UserGameItems 

--2:
SELECT u.Username, g.[Name], ug.Cash
  FROM Users AS u
  JOIN UsersGames AS ug ON u.Id = ug.UserId
  JOIN Games AS g ON ug.GameId = g.Id
 WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')    AND g.[Name] = 'Bali';

 DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] = 'Bali');

 UPDATE UsersGames
    SET Cash += 50000
  WHERE GameId = @gameId AND UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'));

  SELECT u.Username, g.[Name], ug.Cash
  FROM Users AS u
  JOIN UsersGames AS ug ON u.Id = ug.UserId
  JOIN Games AS g ON ug.GameId = g.Id
 WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')    AND g.[Name] = 'Bali';

 GO

 --3:
CREATE PROC usp_BuyItem (@username VARCHAR(MAX), @itemId INT, @gameName VARCHAR(MAX))
AS
BEGIN TRANSACTION
	DECLARE @userIdVerified INT = (SELECT Id FROM Users WHERE Username = @username);

	IF(@userIdVerified IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid username!', 1
	END;

	DECLARE @itemIdVerified INT = (SELECT Id FROM Items WHERE Id = @itemId);

	IF(@itemIdVerified IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Invalid item id!', 1
	END;

	DECLARE @gameIdVerified INT = (SELECT Id FROM Games WHERE [Name] = @gameName);

	IF(@gameIdVerified IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50003, 'Invalid game name!',1
	END;

	DECLARE @userCash DECIMAL(15,2) = (SELECT Cash FROM UsersGames WHERE GameId = @gameIdVerified AND UserId = @userIdVerified);

	DECLARE @itemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @itemIdVerified);

	IF(@userCash < @itemPrice)
	BEGIN
		ROLLBACK;
		THROW 50004, 'Not enough money!', 1
	END;

	UPDATE UsersGames
	   SET Cash -= @itemPrice
	 WHERE UserId = @userIdVerified AND GameId = @gameIdVerified;

	 DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE GameId = @gameIdVerified AND UserId = @userIdVerified);

	 INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
		(@itemIdVerified, @userGameId);
COMMIT

GO

DECLARE @itemId INT = 251;

WHILE(@itemId <= 299 OR (@itemId >= 501 AND @itemId <= 539))
BEGIN
	EXEC usp_BuyItem 'baleremuda', @itemId, 'Bali';
	EXEC usp_BuyItem 'loosenoise', @itemId, 'Bali';
	EXEC usp_BuyItem 'inguinalself', @itemId, 'Bali';
	EXEC usp_BuyItem 'buildingdeltoid', @itemId, 'Bali';
	EXEC usp_BuyItem 'monoxidecos', @itemId, 'Bali';

	SET @itemId += 1;

	IF(@itemId = 300)
	BEGIN
		SET @itemId = 501;
	END;

	IF(@itemId = 540)
	BEGIN
		BREAK;
	END;
END;

GO

--4:
   SELECT u.Username, g.[Name], ug.Cash, i.[Name] AS [Item Name]
     FROM Users AS u
     JOIN UsersGames AS ug ON u.Id = ug.UserId
     JOIN Games AS g ON ug.GameId = g.Id
     JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
     JOIN Items AS i ON ugi.ItemId = i.Id
    WHERE g.[Name] = 'Bali'
 ORDER BY u.Username, i.[Name]