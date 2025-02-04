UPDATE PlayersRanges
SET PlayersMax = 3
WHERE Id = 1

UPDATE Boardgames
SET [Name] = [Name] + 'V2'
WHERE YearPublished >= 2020