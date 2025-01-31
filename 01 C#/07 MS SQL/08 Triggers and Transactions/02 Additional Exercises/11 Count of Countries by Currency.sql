SELECT crr.CurrencyCode,
       crr.[Description] AS Currency,
       COUNT(cntr.CountryCode) AS NumberOfCountries
FROM Currencies AS crr
     LEFT JOIN Countries AS cntr ON cntr.CurrencyCode = crr.CurrencyCode
GROUP BY crr.CurrencyCode,
         crr.[Description]
ORDER BY NumberOfCountries DESC,
         Currency;