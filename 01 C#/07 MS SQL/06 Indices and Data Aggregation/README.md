# General
## Indices
Базата данни позволява много бързо намиране на информация, когато данните са подредени с индекси. Индексите ускоряват търсенето на стойности в определени колони или групи от колони.

Обикновено индексите са имплементирани като двоични дървета за търсене (B-trees).

Индексите могат да бъдат вградени в таблицата (clustered) или запазени външно (non-clustered).

При **clustered** индексите самите данни са част от индекса, докато при **non-clustered** индексите имаме отделна структура.

Ако използваме **clustered индекс**, указателят на **non-clustered индекс** сочи към него. Ако няма **clustered индекс**, указателят сочи директно към данните, което е по-бавно.

**Предимства и недостатъци:**

Добавянето и триенето на записи в индексирани таблици е по-бавно, защото индексите трябва да се обновява, поради което не винаги са подходящи. Обикновено индексите се ползват за таблици с над 500 000 реда.

Важно е да се поставят индекси само на колоните, които често участват в заявките, като например в `WHERE`, `JOIN`, `GROUP BY` или `ORDER BY` клаузи. Няма смисъл да се индексират всички колони, тъй като това:

- Увеличава размера на базата данни. Индексите са допълнителни обекти, които растат заедно с таблицата и могат да заемат значително дисково пространство, особено при големи таблици с много индекси. Всеки индекс създава структура, която изисква място за съхранение. При добавяне, актуализиране или изтриване на данни, индексите също трябва да се обновяват, което увеличава натоварването.
- Забавя операциите за добавяне, обновяване и изтриване на записи, защото индексите трябва да се обновяват при всяка промяна.

Примерно ако имаме таблица със служители. Обикновено заявките към тази таблица ще търсят информация за служител:

- По **ID** (уникален идентификатор).
- По **Name**, ако често се налага търсене на служители по име.

В този случай е логично да добавим индекси върху колоните за **ID** и **Name**, тъй като те се използват редовно при търсене и филтриране.

Обаче, ако таблицата съдържа колони като **Address**, **Mobile Number** или **Hire Date, и тези колони не участват в заявки, няма смисъл да се индексират. Такива индекси биха довели до по-бавно записване и актуализиране на данни, без реална полза за изпълнението на заявките.

Индексите трябва да се прилагат стратегически, като се фокусираме върху колоните, които имат ключово значение за производителността на заявките. Това ще осигури баланс между бързодействие при четене и ефективност при записване и поддръжка на данните.

Ако знаем, че дадена колона винаги върви заедно с друга в заявки, можем да ги обединим в **съставен индекс** (composite index). Съставният индекс включва повече от една колона и може да подобри производителността на заявките, които използват тези колони заедно.
Съставният индекс ще бъде ефективен **само когато търсенето включва всички обединени колони или първата(ите) от тях**, в зависимост от реда на колоните в индекса. Ако търсенето е само по някоя от другите колони, индексът може да не бъде използван оптимално.

Добра практика е първоначално да не се създават индекси. Ако се наблюдава забавяне, анализът на заявките може да покаже къде да се добавят индекси за ускоряване на производителността.

Друг подход е данните първоначално да се записват в таблица без индекси. След това, с помощта на **background job**, записите се прехвърлят периодично в друга, предварително индексирана таблица.

Този метод позволява:

- По-бързо записване на данни, тъй като липсата на индекси намалява времето за операцията.
- Индексираната таблица да се оптимизира за четене и заявки, без да се влияе от постоянно обновяване.

Обикновено този подход се използва в системи с голям обем транзакции, където записите са много на брой и основният приоритет е бързото им записване. Индексирането се прави по-късно, за да се осигури по-добра производителност при четене.
### Clustered Indexes
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250117131432.png)

Изключително бърз – осигурява директен достъп до данните, тъй като подрежда физическата структура на таблицата по стойностите на колоната (или колоните), които са част от индекса.

Може да има само един на таблица, защото определя физическата подредба на данните.

Много полезен за бързо изпълнение на оператори като `WHERE`, `ORDER BY` и `GROUP BY`, както и за операции по филтриране, сортиране и групиране.

Обикновено `clustered index` е върху Primary Key колоната, тъй като тя често е уникална и използвана за достъп до редове.

Ако няма определен clustered index, таблицата се съхранява като heap – неподредена структура, където данните не са сортирани. Това прави операциите за търсене по-бавни в сравнение с таблици с clustered index.

В SQL Server данните в таблица с `clustered index` са винаги подредени по стойностите в индекса. Ако няма такъв индекс, данните остават несортирани (heap).

Данните не са автоматично подредени по ID, освен ако изрично не създадем `clustered index` върху ID колоната (например чрез Primary Key). Ако няма такъв индекс, редовете ще бъдат съхранявани в произволен ред в heap структурата.
Ако създадем Primary Key върху `ID`, SQL Server автоматично създава `clustered index` върху него.
В този случай редовете ще бъдат физически подредени по ID. Ако премахнем Primary Key или не зададем clustered index, таблицата ще се държи като heap.
### Non-Clustered Indexes
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250117133841.png)

Позволява множество индекси върху една таблица.

Представлява отделна структура, която се обновява при всяка промяна в данните.

Работи с указатели, които насочват към данните.

Не е толкова ефективен, ако таблицата няма clustered index.

**Syntax:**

```sql
CREATE NONCLUSTERED INDEX
IX_Employees_FirstName_LastName
ON Employees(FirstName, LastName)
```
## Grouping
Групирането в SQL е процес, при който се събират редове в таблица, които имат еднакви стойности в определени колони. Това обикновено се прави с помощта на командата **GROUP BY**, като резултатът от групирането може да бъде използван за прилагане на агрегиращи функции като **COUNT()**, **SUM()**, **AVG()**, които извършват изчисления върху всяка група. Групирането позволява да се работи с подмножества на данни и да се извършват анализи или статистики въз основа на тези групи.
Когато използваме **GROUP BY** в SQL, можем да изброяваме в **SELECT** само тези колони, които са част от **GROUP BY** клаузата или тези, които са използвани в агрегираща функция.

**Принципът е:**

- Ако една колона не е в **GROUP BY** и не е използвана в агрегираща функция (като **COUNT()**, **SUM()**, **AVG()** и т.н.), SQL няма да знае как да я групира и ще хвърли грешка.
- Групирането се прави по уникалните комбинации от стойности на колоните, изброени в **GROUP BY**.
### GROUP BY vs DISTINCT
Основната разлика между **DISTINCT** и **GROUP BY** е възможността да използваме агрегиращи функции. **DISTINCT** премахва дублиращите се редове в резултата, докато **GROUP BY** групира редовете по уникални стойности и позволява използването на агрегиращи функции (като **COUNT()**, **SUM()** и др.). Разликата се появява, когато използваме агрегати – **GROUP BY** е необходим за тях, докато **DISTINCT** не позволява агрегации. **GROUP BY** на практика **групира редовете**, като запазва информацията за тях в рамките на групите. Това е причината да можем да използваме агрегиращи функции върху тези групи, защото **всички редове в групата се съхраняват логически**, дори ако в резултата виждаме само една обобщена стойност за групата. 

**DISTINCT** премахва дубликатите напълно и не съхранява информация за премахнатите редове.
**GROUP BY** **групира** редовете и позволява да се използват всички данни вътре в групите чрез агрегиращи функции като `COUNT`, `SUM`, `AVG` и т.н.

**DISTINCT** се използва, когато искаме да премахнем дубликати, без да прилагаме агрегации. 
**GROUP BY** е необходим, когато искаме да използваме агрегиращи функции за групираните данни.
## Aggregate Functions
Агрегиращите функции работят върху групи от данни, като ако не се използва групиране, те се прилагат върху целия резултантен набор от данни. Важно е да се отбележи, че **`NULL`** стойностите се игнорират от агрегиращите функции.

Целта на тези функции е да се извършва анализ на данните, като те обобщават и изчисляват стойности върху групи или целия набор от записи.

Списък с агрегиращи функции и начина им на работа има във файла за MS SQL в папката с ресурси.
## HAVING
**`HAVING`** е предикат, който се използва след **`GROUP BY`** за филтриране на групираните резултати. Той е подобен на **`WHERE`**, но има ключова разлика: **`WHERE`** филтрира редовете преди агрегацията, докато **`HAVING`** филтрира резултатите след групирането.

- **`HAVING`** не може да се използва без да има групиране чрез **`GROUP BY`**.
- Агрегатните функции (като **`COUNT`**, **`SUM`**, **`AVG`**) се изпълняват само веднъж върху групите, не многократно за всеки ред.
- Ако не използваме **`HAVING`**, трябва да вложим групата в допълнителен **`SELECT`**, в който да използваме **`WHERE`** за филтриране на резултатите.

Пример:

```sql
SELECT DepartmentID, COUNT(EmployeeID) AS EmployeeCount
FROM Employees
GROUP BY DepartmentID
HAVING COUNT(EmployeeID) > 5;
```

Тук **`HAVING`** филтрира отделите, които имат повече от 5 служители след като групирането е извършено.

Пример без `HAVING`

```sql
SELECT DepartmentID, EmployeeCount
FROM (
    SELECT DepartmentID, COUNT(EmployeeID) AS EmployeeCount
    FROM Employees
    GROUP BY DepartmentID
) AS GroupedDepartments
WHERE EmployeeCount > 5;
```
# Misc
# ChatGPT
## GROUP BY
1. **Groups by Unique Combinations**: `GROUP BY` takes all unique combinations of values in the specified column(s).
    
2. **Orders Data by Groups (Conceptually)**: While it may appear that records are "ordered" into groups, the main purpose is to logically group them, not necessarily to sort them.
    
3. **Preserves Grouped Data for Aggregation**: Within each group, the rows are preserved, allowing aggregate functions (like `SUM`, `COUNT`, etc.) to operate **only on the rows within each group**.
    
4. **Displays One Row per Group**: The result includes one row per group, showing:
    
    - The values of the grouped columns (unique combinations).
    - The results of any aggregate functions applied to the group.

**Example:**

|Name|Age|Salary|
|---|---|---|
|Alice|30|5000|
|Bob|30|7000|
|Alice|25|6000|

**Query:**

```sql
SELECT Name, SUM(Salary)
FROM Employees
GROUP BY Name;
```

**Process:**

1. Groups by the `Name` column's unique values: `Alice`, `Bob`.
2. Aggregates the `Salary` column within each group.
3. Outputs one row per group.

**Result:**

|Name|SUM(Salary)|
|---|---|
|Alice|11000|
|Bob|7000|

**Key Difference from `DISTINCT`:**

- `GROUP BY` groups rows and allows aggregation within each group.
- `DISTINCT` only removes duplicate rows without grouping or aggregation.

**Simplified Takeaway:**

`GROUP BY` logically organizes rows into unique groups based on the specified columns and enables aggregation on those groups. Each resulting group is represented by a single row in the final output.
## WHERE / GROUP BY / HAVING
**`WHERE`** can only be used **before** **`GROUP BY`**. It filters the result set **before** the grouping occurs, removing rows that do not meet the specified conditions. After that, **`GROUP BY`** groups the already filtered data into different groups based on the selected columns.

- **`WHERE`** filters data before aggregation and grouping.
- **`GROUP BY`** groups the filtered data into different groups.

- To filter the results **after** grouping, **`HAVING`** should be used.
- **`WHERE`** filters individual rows **before** grouping.
- **`HAVING`** filters grouped data **after** the grouping.
## Custom Groupings in SQL
Custom groupings in SQL allow you to categorize data into specific groups based on defined conditions. This is typically done using the **`CASE`** expression, which evaluates conditions and assigns group labels accordingly.

- **Purpose**: Create meaningful categories (e.g., age ranges, income brackets) for analysis.
- **How It Works**:
    1. Use a **`CASE`** expression in the **`SELECT`** clause to define conditions and assign group names.
    2. Use the same **`CASE`** expression in the **`GROUP BY`** clause to group the data.
    3. Apply aggregate functions (e.g., **`COUNT`**, **`SUM`**) to analyze the grouped data.

**Example:**

```sql
SELECT 
    CASE 
        WHEN Age < 18 THEN 'Under 18'
        WHEN Age BETWEEN 18 AND 29 THEN '18-29'
        ELSE '30+'
    END AS AgeGroup,
    COUNT(*) AS PeopleCount
FROM People
GROUP BY 
    CASE 
        WHEN Age < 18 THEN 'Under 18'
        WHEN Age BETWEEN 18 AND 29 THEN '18-29'
        ELSE '30+'
    END;
```

**Key Points:**

- **Flexibility**: Custom groupings are not limited to existing column values; they can be dynamic.
- **Reusability**: The same **`CASE`** expression is used in **`SELECT`** and **`GROUP BY`**.
- **Aggregate Analysis**: Combine custom groupings with aggregate functions for detailed insights.

Custom groupings are powerful for creating tailored analyses that fit specific business or reporting needs.
# Bookmarks
Completion: 18.01.2025