`CREATE DATABASE DatabaseName` - за създаване на база данни.

Създаване на таблица:

```sql
CREATE TABLE People
(
Id INT NOT NULL,
Email VARCHAR(50) NOT NULL,
FirstName VARCHAR(50),
LastName VARCHAR(50),
[Date] DATE
)
```

`NOT NULL` означава че искаме полето да е задължително.

`SELECT * FROM MyTable` - взимане на всички записи в посочената таблица. Ако искаме определени колони, трябва да ги изредим.