# General
## User-Defined Functions
В основната си дефиниция, функцията е блок от код, който приема входни данни (_input_), обработва ги, и връща резултат (_output_).
### Scalar functions
Скаларните функции връщат единична стойност (`INT`, `VARCHAR`, `DECIMAL` и т.н.) като резултат. Те се използват обикновено за изчисления или трансформации върху входните параметри. Могат да се извикват директно в `SELECT`, `WHERE`, `ORDER BY` и други.

**Syntax:**

```sql
CREATE FUNCTION udf_ProjectDurationWeeks (@StartDate DATETIME,
@EndDate DATETIME)
RETURNS INT
AS
BEGIN
 DECLARE @projectWeeks INT;
 IF(@EndDate IS NULL)
 BEGIN
 SET @EndDate = GETDATE()
 END
 SET @projectWeeks = DATEDIFF(WEEK, @StartDate, @EndDate)
 RETURN @projectWeeks;
END
```

Когато правим наши функции, имената им трябва да започват с `udf_` (user defined function), след което самото име е PascalCase.

Първо се изписва името на параметъра, след което неговия тип.

След това следва типа на резултата, като няма `void`, ако искаме да не връща нищо, трябва да се направи процедура.

Имената на променливите започват с `@`.

Понеже нямаме разграничение кое е параметър и кое е променлива вътре в самата функция, конвенцията е че параметрите се изписват с PascalCase а променливите с camelCase.

`BEGIN` и `END` са нещо като отваряща и затваряща скоба за тялото на метода. Желателно е да се ползва и в `IF ELSE` конструкция.
### Table-valued functions
Връщат цяла таблица като резултат от един `SELECT`. Подобни са на view-тата но с параметри.
#### Inline table-valued functions (TVF)
#### Multi-statement table-valued functions (MSTVF)
## Functions: Limitations
SQL сървър прави голяма разлика между функции и процедури.

User-defined функциите не могат да се ползват за модифициране на базата данни, но са изцяло за четене.

Не могат да връщат повече от един сет данни.

Не може да се ползва динамичен SQL (генериране на заявки в нашите заявки) и временни таблици, но може да се ползват table variables.

Не може да се влагат повече от 32 функции една в друга.

Error handling-a е ограничен и не може да се ползва `TRY CATCH`, `@ERROR` or `RAISERROR`.
# Misc
# ChatGPT
# Bookmarks
Completion: 22.01.2025