-- Task 1

CREATE TABLE Monasteries
(
             Id INT PRIMARY KEY IDENTITY NOT NULL,
             [Name] NVARCHAR(100) NOT NULL,
             CountryCode CHAR(2) NOT NULL REFERENCES Countries(CountryCode)
);

-- Task 2

INSERT INTO Monasteries([Name], CountryCode)
VALUES
(
       'Rila Monastery “St. Ivan of Rila”',
       'BG'
),
(
       'Bachkovo Monastery “Virgin Mary”',
       'BG'
),
(
       'Troyan Monastery “Holy Mother''s Assumption”',
       'BG'
),
(
       'Kopan Monastery',
       'NP'
),
(
       'Thrangu Tashi Yangtse Monastery',
       'NP'
),
(
       'Shechen Tennyi Dargyeling Monastery',
       'NP'
),
(
       'Benchen Monastery',
       'NP'
),
(
       'Southern Shaolin Monastery',
       'CN'
),
(
       'Dabei Monastery',
       'CN'
),
(
       'Wa Sau Toi',
       'CN'
),
(
       'Lhunshigyia Monastery',
       'CN'
),
(
       'Rakya Monastery',
       'CN'
),
(
       'Monasteries of Meteora',
       'GR'
),
(
       'The Holy Monastery of Stavronikita',
       'GR'
),
(
       'Taung Kalat Monastery',
       'MM'
),
(
       'Pa-Auk Forest Monastery',
       'MM'
),
(
       'Taktsang Palphug Monastery',
       'BT'
),
(
       'Sümela Monastery',
       'TR'
);

-- Task 3 
/* NOT FOR JUDGE
ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT 0;

UPDATE Countries
  SET
      IsDeleted = 0;
*/


-- Task 4

UPDATE Countries
  SET
      IsDeleted = 1
WHERE CountryCode IN
(
    SELECT c.CountryCode
    FROM Countries AS c
         JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
    GROUP BY c.CountryCode
    HAVING COUNT(cr.RiverId) > 3
);

-- Task 5

SELECT m.[Name] AS Monastery,
       c.CountryName AS Country
FROM Monasteries AS m
     JOIN Countries AS c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY Monastery;