DELETE CreatorsBoardgames
WHERE BoardgameId IN (SELECT Id FROM Boardgames WHERE PublisherId IN (SELECT Id From Publishers WHERE AddressId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%')))

DELETE Boardgames
WHERE PublisherId IN (SELECT Id From Publishers WHERE AddressId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%'))

DELETE Publishers
WHERE AddressId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%')

DELETE Addresses
WHERE Town LIKE 'L%'