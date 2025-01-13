# General
## SQL Functions
Имаме различни типове функции в SQL и когато ги ползваме е добре да знаем върху какви данни го правим.
Функциите може да бъдат вграждани една в друга. 
Списък с функции и начина им на работа има във файла за MS SQL в папката с ресурси.
### Aggregate
SQL е език, който не само трябва да се грижи за CRUD операциите в нашата база данни, но до голяма степен да ни дава възможност и да използваме тези данни. Има в себе си вградена функционалност за по-сложни анализи на данните, като агрегацията е една от тях. Когато правим агрегации, трябва да ги правим върху правилните данни.
Такива агрегиращи функции са: `AVG()`, `COUNT()`, `MIN()`, `MAX()`, `SUM()` и други.
### Analytic
Предоставят възможност да се изчисляват стойности въз основа на група редове, но за разлика от стандартните агрегиращи функции, те не свеждат резултата само до една стойност за групата, а запазват оригиналните редове в резултатите. Тези функции са мощни инструменти за анализ на данни. Много рядко са необходими.
### Ranking
Аналитични функции, които подреждат редовете в рамките на дефиниран прозорец.
Такива функции са: `RANK()`, `ROW_NUMBER()`, `DENSE_RANK()`, `NTILE()` и други, като `ROW_NUMBER()` е най-често използваната.
### Rowset
Връщат набор от редове (result set) и обикновено се използват за работа с таблици, представяне на външни данни или генериране на данни. Те могат да се използват в `FROM` или `JOIN` клаузите на заявките.
### Scalar
Задължително връщат единична стойност, което означава, че може да ги ползваме в `SELECT`.
### String
Функции за обработка на стрингове.
### Math
SQL Server поддържа базовите аритметични операции.
### Date
Позволяват извличане на компоненти (като година, месец, ден), изчисления (добавяне или разлика от дати) и форматиране. Често използвани са `GETDATE()` за текуща дата, `DATEPART()` за конкретна част, `DATEDIFF()` за разлика и `FORMAT()` за персонализиран изглед.
## Wildcards
Wildcards в SQL са подобни на REGEX, но с по-ограничени възможности. Те се използват за филтриране на текстови стойности, когато не знаем точния текст или търсим частични съвпадения. 
Wildcards могат да се използват с оператора `LIKE`, както и да се комбинират с други оператори като `NOT`, `AND` и `OR` за създаване на по-сложни условия за търсене. 
Примери и повече информация има във файла за MS SQL в папката с ресурси.
# Misc
# ChatGPT
## Functions Mostly Used in SELECT
SQL functions are most commonly used in `SELECT` statements because they allow for the manipulation and transformation of data directly in the database. These functions are applied to each record in a column, making them highly efficient for tasks like formatting, calculations, and conditional logic.

**Key Reasons for Using Functions in `SELECT`:**

- **Efficiency**: Operations are performed directly on the database server, reducing the need for client-side processing.
- **Scalability**: Functions process all records in a column simultaneously.
- **Flexibility**: They support various transformations, such as text manipulation, mathematical computations, and handling `NULL` values.

While `SELECT` is the primary use case, functions can also be employed in:

- **`WHERE`**: Filtering rows.
- **`ORDER BY`**: Sorting data.
- **`GROUP BY`**: Aggregating results.

**Comparison to LINQ's `Select` in C#:**

SQL's `SELECT` is conceptually similar to LINQ's `Select` in C#, as both are used to project and transform data. However, SQL operates at the database level, processing records directly on the server, whereas LINQ works in-memory or generates database queries via providers like Entity Framework.
## Backend vs Database Transformation
Using SQL functions directly within the database has several key advantages, even if similar operations can be performed in the backend. Here are some reasons why SQL functions might still be beneficial:

1. **Performance**: SQL functions can be optimized by the database engine, which is often faster than processing data in the backend, especially when dealing with large datasets. This minimizes the need to load large amounts of data into the application for processing.
2. **Reduced Network Overhead**: When you perform data transformations in the database, you're reducing the amount of data transferred over the network. You only send the final result, not the raw data.
3. **Centralized Logic**: Using SQL functions allows you to centralize certain business logic at the database level, ensuring consistency across different applications or microservices that access the same database.
4. **Simplicity**: For simple operations like string manipulation, date formatting, or mathematical computations, performing them directly in SQL is often more concise and readable than handling them in the backend code.
5. **Database-specific Optimizations**: Many databases have specific optimizations for built-in functions. Using these functions can take advantage of optimizations that might not be possible with custom backend code.
6. **Security and Access Control**: You can restrict access to sensitive data or operations by using database functions, as these can be controlled with database permissions, adding an extra layer of security.
7. **Scalability**: Offloading computations to the database can help scale the application more easily. The database is designed to handle complex queries efficiently, while the backend can focus on business logic.

In summary, SQL functions can reduce complexity, improve performance, and leverage the full power of the database engine. In conclusion, while it's feasible to handle all data projection and transformation in the backend, using SQL functions in the database can still be an efficient, scalable, and more performance-friendly approach in many cases. It's about finding the right balance for your application’s specific needs. Backend transformations are necessary in many cases, combining both approaches can offer the best of both worlds. 
# Bookmarks
Completion: 12.01.2025