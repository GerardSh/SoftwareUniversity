`CREATE DATABASE DatabaseName` - за създаване на база данни.

---
Създава таблицa. С `PRIMARY KEY` се прави дадена колона да е primary key-a, а `NOT NULL` означава че искаме полето да е задължително.

```sql
CREATE TABLE People
(
Id INT PRIMARY KEY,
Email VARCHAR(50) NOT NULL,
FirstName VARCHAR(50),
LastName VARCHAR(50),
[Date] DATE
)
```

---

`SELECT * FROM MyTable` - взимане на всички записи в посочената таблица. Ако искаме определени колони, трябва да ги изредим.

---
Взима първите 10 рекорда подредени по подразбиране (ако няма `ORDER BY`), като ги показва с изброените колони, от тях филтрираме чрез `WHERE` само записите, в които стойността на колоната `FirstName` е `'Gerard'`. Чрез `AS` може да сменим името на колоната и ако новото име съдържа интервали, трябва да е в квадратни скоби или двойни кавички.

```sql
SELECT TOP(10) 
	LastName, 
	FirstName,
	Id AS [Employee Identifier]
FROM Employees 
WHERE FirstName = 'Gerard'
ORDER BY LastName ASC;
```

---

`ALTER TABLE` позволява промени в структурата на съществуваща таблица.

- **Добавяне на колона**

```sql
ALTER TABLE TableName
ADD ColumnName DataType;
```

- **Модифициране на колона**

```sql
ALTER TABLE TableName
ALTER COLUMN ColumnName NewDataType;
```

- **Изтриване на колона**

```sql
ALTER TABLE TableName
DROP COLUMN ColumnName;
```

- **Добавяне на ограничение**

```sql
ALTER TABLE TableName
ADD CONSTRAINT ConstraintName ConstraintType (ColumnName);
```

- **Изтриване на ограничение**

```sql
ALTER TABLE TableName
DROP CONSTRAINT ConstraintName;
```

- **Add a Foreign Key Constraint**

```sql
ALTER TABLE TableName
ADD FOREIGN KEY (ColumnName) REFERENCES ReferencedTableName(ReferencedColumnName);
```

- **Add a Named Foreign Key Constraint**

```sql
ALTER TABLE TableName
ADD CONSTRAINT FK_ConstraintName
FOREIGN KEY (ColumnName) REFERENCES ReferencedTableName(ReferencedColumnName);
```

---
