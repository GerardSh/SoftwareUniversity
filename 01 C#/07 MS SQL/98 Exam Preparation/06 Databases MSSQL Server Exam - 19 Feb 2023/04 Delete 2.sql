DECLARE @AddressesToDelete TABLE (Id INT PRIMARY KEY);
INSERT INTO @AddressesToDelete (Id)
SELECT Id
FROM Addresses
WHERE Town LIKE 'L%';

DECLARE @PublishersToDelete TABLE (Id INT PRIMARY KEY);
INSERT INTO @PublishersToDelete (Id)
SELECT Id
FROM Publishers
WHERE AddressId IN (SELECT Id FROM @AddressesToDelete);

DECLARE @BoardgamesToDelete TABLE (Id INT PRIMARY KEY);
INSERT INTO @BoardgamesToDelete (Id)
SELECT Id
FROM Boardgames
WHERE PublisherId IN (SELECT Id FROM @PublishersToDelete);

DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN (SELECT Id FROM @BoardgamesToDelete);

DELETE FROM Boardgames
WHERE Id IN (SELECT Id FROM @BoardgamesToDelete);

DELETE FROM Publishers
WHERE Id IN (SELECT Id FROM @PublishersToDelete);

DELETE FROM Addresses
WHERE Id IN (SELECT Id FROM @AddressesToDelete);