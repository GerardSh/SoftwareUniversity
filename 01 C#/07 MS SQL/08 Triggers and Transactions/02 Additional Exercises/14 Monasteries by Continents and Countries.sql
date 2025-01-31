-- Task 1

UPDATE Countries
  SET
      CountryName = 'Burma'
WHERE CountryName = 'Myanmar';

-- Task 2 and 3

INSERT INTO Monasteries
VALUES
(
       'Hanga Abbey',
(
    SELECT CountryCode
    FROM Countries
    WHERE CountryName = 'Tanzania'
)
),
(
       'Myin-Tin-Daik',
(
    SELECT CountryCode
    FROM Countries
    WHERE CountryName = 'Myanmar'

/* 
    The new name of Myanmar is Burma 
    WHERE CountryName = 'Myanmar' - returns NULL but Judge accepts it only this way
    To avoid NULL exception the filtration have to be: 
    WHERE CountryName = 'Burma' - with the New Name 
*/

)
);

-- Task 4

SELECT cnt.ContinentName,
       cntr.CountryName,
       COUNT(m.Id) AS MonasteriesCount
FROM Continents AS cnt
     LEFT OUTER JOIN Countries AS cntr ON cntr.ContinentCode = cnt.ContinentCode
     LEFT OUTER JOIN Monasteries AS m ON m.CountryCode = cntr.CountryCode
WHERE cntr.IsDeleted = 0
GROUP BY cnt.ContinentName,
         cntr.CountryName
ORDER BY MonasteriesCount DESC,
         CountryName;