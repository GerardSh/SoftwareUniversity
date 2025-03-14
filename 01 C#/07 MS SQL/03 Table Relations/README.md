# General
## Steps In Database Design
### Identify Entities
Ентитито е обект, който е важен за бизнеса. Най-лесния вариант да определим ентититата, когато започнем да правим дизайна на базата ни данни идва от DDD (Domain Driven Design), където domain-a е бизнес област в която работи нашия software. Трябва да започнем изграждането на речник като започнем разговор с експерти в областта. 

Примерно, ако правим приложение за градския транспорт, по време на разговора си изваждаме domain specific думи като спирки, автобуси, билети, контрольори, маршрути, разписание и тн. Тези думички са ентититата и съответстват на таблиците в базата данни. Най-често са съществителни във спецификацията и каквото и да прочетем в нея, трябва да говорим и със специалистите във въпросната област.

Друг пример - трябва да разработим система, която съхранява информация за студенти, обучаващи се в различни курсове. Курсовете се провеждат в различни градове. При регистриране на нов студент се въвежда следната информация: име, факултетен номер, снимка и дата.

Entities: Student, Course, Town.
### Identify Table Columns
Има колони, които са служебни и са задължителни. Домейн специфичните колони, се намират най-лесно отново в процеса на разговора като обсъдим ентититата, примерно спирката си има адрес, номерация, състояние, връзка с автобусите, които спират там и тн. 
В примера със студентите, всеки студент си има име, но има детайли, които трябва да се обсъдят, като това когато студента влиза в системата, дали тя се обръща към него с цялото му име или само фамилия и тн. 
Друг детайл е дали и трите имена да се включват в сертификатите. Ние като IT експерти, трябва да преценим как точно, къде, до каква степен имаме право да съхраняваме данните и тн.

Добре е да има допълнителни колони, примерно колона която пази датата на създаване на даден запис, кой го е създал и тн. Това са специални колони, които е добра практика да се създават.
### How to Choose a Primary Key
Първичния ключ е едно от най-важните неща в една таблица. Важен е защото, това е нещото, което еднозначно идентифицира записа. Той е абсолютно уникален и е начина, по който достъпваме правилните данни. Много хора правят грешката да използват бизнес термини. Това е голяма грешка, защото колкото и бизнеса да ни уверява че нещо е уникално и то ще остане винаги такова, не трябва да му се вярва. Затова бизнес данните, не трябва да се ползват като ключ, за да се избегне колизия.

В повечето случаи ключът трябва да бъде число, защото числата се обработват бързо. Понякога това не е достатъчно поради огромния обем на генерираните данни, и тогава дори `long` (64 бита) не е достатъчен. В краен случай може да се използва `GUID` (Globally Unique Identifier 128 бита). Той също работи бързо и не може да бъде отгатнат, което е важно, тъй като съществуват атаки, базирани на ID-та.

Ако ползваме цяло число, primary key-a задължително трябва да е `IDENTITY` с auto-increment. Базата данни е среда на силна конкурентност и ако ние даваме числата, може да се дублират, докато базата е проектирана в среда на конкурентост да ги създава сама, без да ги дублира. Може да се получи дупка в идентификатора, ако възникне грешка, но няма да има дублиране. 
При `GUID` `IDENTITY` не работи, защото `GUID` не е последователен тип данни. `GUID` стойностите са случайно или псевдослучайно генерирани и не се вписват в концепцията за автоматично увеличаване. Ако обаче искаме да използваме `GUID` като ключ, можем да използваме други механизми, като например:
- `NEWID()`: Функция, която генерира уникален `GUID` за всяка нова стойност.
- `NEWSEQUENTIALID()`: Функция, която генерира `GUID` с последователност, за да се оптимизира производителността при индексиране.

Primary key-a, е добре да бъде първа колона. След създаването на таблицата, колоните не може да се пренареждат.

Не е добре да се ползва текст, защото се създава по-неефективни индекси, а те са много важни, защото се търси бързина - много бързо да може да се изкарат данните. При текстови индекси, нещата са доста по-зле от колкото при числови индекси.
### Identify Entity Relationships
Често имаме зависимости между различните ентитита, примерно между автобуси и спирки или студенти, курсове и градове. Връзките са важни и трябва да бъдат дефинирани. 

Примерно студентите са обучават в курсове, което означава че щом имаме много студенти и те се обучават в много курсове, имаме връзка many-to-many. 

Курсовете се провеждат в градове, тук връзката може да е many-to-one или many-to-many, ако даден курс се провежда в различни градове. 
Спецификацията е placeholder-a за разговор - виждаме множественото число между курсове и градове, но за да може да определим със сигурност каква е връзката, трябва да говорим с някой който може да потвърди точно къде и как се провеждат курсовете.

Промяната на релациите в базата данни е трудна задача. Понеже релацията е нещо доста фундаментално и рядко има такива фундаментални промени в бизнеса.
## Database Normalization
Нормализацията е систематичен подход за де композиране на таблиците с цел да се премахне повторението на данните, както и ни пази от аномалии.

Това е организация на данните в определена структура. Първото нещо, което трябва да направим е данните да бъдат атомарни (atomicity), защото много по-лесно работим с тях и бързо намираме това, което ни трябва.
Атомарни означава, че не данните не би трябвало да може да бъдат разделяне повече от това до където сме ги разделили.

Релационните бази данни са проектирани, така че да минимизират размера на данните, които се пълнят вътре. Поради това има типове данни, като повечето от тях имат ограничения, за да може да се впишат в определени байтове. Примерно може да изберем `VARCHAR`, но ще го ограничим до даден брой символи. Така базата данни, знае колко място да запази.

Ако дублираме едни и същи данни много пъти, отново получаваме нарастване обема на данни. В този случай, може да заместим данните с нещо по-кратко, примерно да заместим дадено име и дори не само името, но и други свързани данни, като имейл и телефон, само с едно число. По този начин на всяко място, където се изисква тази информация, вместо да се въвеждат всички свързани данни, могат да бъдат заместени с един номер. Това е една от основните цели, справяне с дедупликацията на данни, да може да намали обема на записаните данни. Това води и до увеличаване на скоростта с която може да се прочетат и манипулират данните.

Това е многостъпков процес, като за нас са важни първите три, които са достатъчни да премахнем аномалиите и да достигнем достатъчна степен на дедуплициране на данните.
### Normal Forms
#### First Normal Form (1NF)
1. Таблицата трябва да има атомарна / единична стойност. Означава че в една колона, не може да запишем повече от една стойност. Примерно даден човек има повече от един имейл адрес, не трябва да ги записваме в една колона и ще наруши първата нормална форма. Това, което трябва да се направи е да се въведе същия човек като отделен запис за всеки различен имейл адрес, който има, като всички останали данни остават същите. Получават се дублирани данни, но това е първата стъпка, към нормализацията.
2. Стойностите записани в колоната, трябва да са от един и същи тип. Базата няма да го позволи, но това че сме избрали стринг, не значи че не може да запишем дадено число като стринг и ако в един запис сме записали име а в друг запис число в същата колона, не е правилно.
3. Всички колони в таблицата, трябва да имат уникални имена. Самата база няма да позволи да има дублиране на имената, но примерно ако имаме таблица в която съхраняваме специалности за хора, и използваме имена като Специалност 1, Специалност 2, това е нарушение на принципите на нормализация. 
4. Реда в който се съхраняват данните, не би трябвало да има значение.
#### Second Normal Form (2NF)
1. Трябва да изпълнява условията на първа нормална форма, понеже всяка следваща форма надгражда предишната.
2. Няма частични зависимости. Частична зависимост се появява, когато атрибут (колона) зависи само от част от съставен първичен ключ, а не от целия ключ.

**Съставен / композитен първичен ключ**

Съставен първичен ключ е ключ, който се състои от **две или повече колони** и заедно те уникално идентифицират всеки ред в таблицата.

Например:

| Студент ID | Курс ID | Оценка | Име на студент | Име на курс |
| ---------- | ------- | ------ | -------------- | ----------- |

- Тук **Студент ID + Курс ID** са съставен първичен ключ, защото само комбинацията от тези две стойности прави реда уникален.
- Колоната **Оценка** зависи от целия ключ (**Студент ID + Курс ID**).
- Но колоната **Име на студент** зависи само от **Студент ID**, а колоната **Име на курс** зависи само от **Курс ID**. Това са частични зависимости.

**Какво трябва да направим?**

За да приведем таблицата във втора нормална форма (2NF), трябва да **премахнем частичните зависимости**, като разделим таблицата на повече таблици.

**Пример: Таблица, която е в 1NF, но не е в 2NF**

|Студент ID|Курс ID|Оценка|Име на студент|Име на курс|
|---|---|---|---|---|
|1|101|5.50|Иван Иванов|Програмиране|
|1|102|4.50|Иван Иванов|Математика|
|2|101|6.00|Петър Петров|Програмиране|

**Проблем:**

- **Име на студент** зависи само от **Студент ID**.
- **Име на курс** зависи само от **Курс ID**.
- Това са частични зависимости, което означава, че таблицата не е в 2NF.

**Решение: Разделяне на таблицата**

1. **Таблица за студенти** (Информация за студентите):  
    | Студент ID | Име на студент |  
    |------------|----------------|  
    | 1 | Иван Иванов |  
    | 2 | Петър Петров |
    
2. **Таблица за курсове** (Информация за курсовете):  
    | Курс ID | Име на курс |  
    |---------|------------------|  
    | 101 | Програмиране |  
    | 102 | Математика |
    
3. **Таблица за записвания** (Връзката между студенти и курсове, включително оценките):  
    | Студент ID | Курс ID | Оценка |  
    |------------|---------|--------|  
    | 1 | 101 | 5.50 |  
    | 1 | 102 | 4.50 |  
    | 2 | 101 | 6.00 |

**Какво постигнахме?**

- Таблицата за студенти съхранява само информация, която зависи от **Студент ID**.
- Таблицата за курсове съхранява само информация, която зависи от **Курс ID**.
- Таблицата за записвания съхранява информация, която зависи от **комбинацията от Студент ID и Курс ID** (съставния ключ).

Така вече няма частични зависимости и таблиците са във втора нормална форма (2NF).

**Заключение:**

**Втора нормална форма (2NF)** е приложима само когато има съставен първичен ключ. Ако първичният ключ се състои от една единствена колона, концепцията за частични зависимости не се прилага и таблицата автоматично отговаря на изискванията за (2NF), стига да изпълнява правилата на първата нормална форма (1NF).
#### Third Normal Form (3NF)
1. Трябва да изпълнява условията за първа и втора нормална форма (1NF и 2NF).
2. Не трябва да има транситивни зависимости. Транзитивна зависимост възниква, когато една колона зависи от друга колона, която не е част от първичния ключ. 
   Например, ако `А` зависи от `B`, а `B` зависи от `C`, тогава `А` зависи транзитивно от `C`.
   
**Пример:**

**Ненормализирана таблица:**

|**id**|**name**|**department_id**|**department_name**|
|---|---|---|---|
|1|Иван|101|Маркетинг|
|2|Петър|102|Продажби|

**Транзитивна зависимост:**

`department_name` зависи от `department_id`, а не директно от `id`.
Това нарушава правилото за 3NF, защото `department_name` не зависи единствено от първичния ключ (`id`).

Това е проблем, защото `department_name` зависи от `department_id`, което означава, че ако променим името на отдела в един ред, трябва да го променим навсякъде в таблицата. Това е излишно дублиране на данни и увеличава риска от несъответствия.

**Решение: Разделяне на таблицата**

1. **Таблица: Служители (Employees):**  
    | **id** | **name** | **department_id** |  
    |--------|-----------|-------------------|  
    | 1 | Иван | 101 |  
    | 2 | Петър | 102 |
    
2. **Таблица: Отдели (Departments):**  
    | **department_id** | **department_name** |  
    |-------------------|---------------------|  
    | 101 | Маркетинг |  
    | 102 | Продажби |

**Обобщение:**

Третата нормална форма (3NF) гарантира, че няма излишни зависимости между колоните, освен тези, които пряко зависят от първичния ключ. Това се постига чрез елиминиране на транситивните зависимости. Ключовият принцип е, че **всяка колона в таблицата трябва да зависи само и единствено от първичния ключ и от нищо друго.**
### Denormalization
Денормализацията понякога е по-добро решение, особено при **data warehouse** бази, където целта е да се улесни достъпът до големи обеми данни. `JOIN` операциите са ресурсно натоварващи и когато трябва да се събира информация от множество таблици, това може да доведе до забавяне. Затова в **data warehouse** базите данните често са денормализирани, за да се улеснят справките и агрегациите.

**Видове бази:**

1. **Оперативни бази данни** – нормализирани, за да осигурят целостта и ефективността на транзакциите.
2. **Аналитични бази данни** – денормализирани, за да се оптимизират справките върху големи обеми информация.

Често базите данни първо се нормализират, за да се гарантира целостта и ефективността на транзакциите. Впоследствие данните преминават през процес на трансформация и денормализация, при който се създават отделни структури, оптимизирани за справки и анализи. Тези денормализирани данни обикновено се съхраняват в аналитични системи, като **data warehouse**, за да улеснят извличането на информация и агрегациите.
## Table Relations
### Foreign Key
Връзките между таблиците се изграждат чрез релации от тип primary key -> foreign key, където foreign key в една таблица обикновено препраща към primary key в друга таблица. Ако не е primary key в другата таблица, foreign key трябва да е поне уникален. Това осигурява референтна цялост и гарантира, че свързаните данни са консистентни.

Когато ползваме релация, ние не повтаряме данните, ако има нужда да се промени нещо, го променяме само на едно място.
### Custom Column Properties
**Primary Key**

```sql
Id INT NOT NULL PRIMARY KEY
```

При този вариант, сами трябва да си подаваме Id-то, като сървъра няма да ни позволи да го дублираме.

**Identity (auto-increment)**

```sql
Id INT PRIMARY KEY IDENTITY
```

**Unique constraint - no repeating values in entire table**

```sql
Email VARCHAR(50) UNIQUE
```

Когато искаме нещо да е уникално, но да не е първичен ключ, защото той при всички случаи е уникален, може да ползваме `UNIQUE` constraint-a. 
### Multiplicity
#### One-to-one
Example: person / passport
- един човек има само един паспорт.
- един паспорт принадлежи само на един човек.

```sql
CREATE TABLE People(
  PersonID INT PRIMARY KEY,
  PersonName VARCHAR(50)
);

CREATE TABLE Passports(
  PassportID INT PRIMARY KEY,
  PersonID INT UNIQUE,
  CONSTRAINT FK_Passports_People FOREIGN KEY
  (PersonId) REFERENCES People(PersonID)
);
```

Основната разлика с one-to-many е, че foreign key колоната е уникална.
Ползва се рядко.
#### One-to-many
Example: country / towns
 - една държава, много градове.

```sql
CREATE TABLE Countries(
  CountryID INT PRIMARY KEY,
  CountryName VARCHAR(50)
);

CREATE TABLE Towns(
  TownId INT PRIMARY KEY,
  CountryID INT,
  CONSTRAINT FK_Towns_Countries
  FOREIGN KEY (CountryID)
  REFERENCES Countries(CountryID)
);
```

Таблицата, която държи foreign key-a е child table, защото държавата съдържа градовете.
Таблицата, която държи реферирания primary key е parent / referenced table.
#### Many-to-many
Example: student / course  
 - един студент има много курсове.
 - един курс има много студенти.

```sql
CREATE TABLE Students (
   StudentID INT PRIMARY KEY,
   StudentName VARCHAR(50)
);

CREATE TABLE Courses (
   CourseID INT PRIMARY KEY,
   CourseName VARCHAR(50)
);

-- Mapping Table
CREATE TABLE StudentCourses (
   StudentID INT,
   CourseID INT,
   CONSTRAINT PK_StudentsCourses
   PRIMARY KEY (StudentID, CourseID),
   CONSTRAINT FK_StudentCourses_Students
   FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
   CONSTRAINT FK_StudentCourses_Courses
   FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
```

Трябва да се използва трета mapping / join таблица, в която има само две колони, всяка от които е foreign key към една от другите таблици, а двете заедно съставляват primary key-a за тяхната таблица.
Използвайки композитен primary key, гарантираме че няма да има повторение на комбинацията от двете таблици. 
Името на mapping таблицата е комбинация от имената на другите две таблици.
Когато разглеждаме many-to-many връзка, реално я преобразуваме в две one-to-many връзки чрез използването на mapping таблица.
## Retrieving Related Data
### JOIN Statements
При нормализация на базата данни, информацията се разпределя в различни таблици, а чрез `JOIN` statement тези таблици могат да бъдат обединени. `JOIN` комбинира таблиците, добавяйки техните колони една до друга според зададените в `SELECT` условия. Обикновено се използват връзки, базирани на foreign keys, но това не е задължително. Въпреки това, `JOIN` операции, които не са базирани на foreign keys, обикновено са неефективни, могат да създадат артефакти, да забавят производителността на приложението и често са индикатор за лош дизайн на базата данни.

`JOIN` изисква поне две таблици и условие за свързване (join condition):

```sql
SELECT *
FROM Towns
JOIN Countries ON Countries.Id = Towns.CountryId
```

При писане на SQL заявки е добра практика да се използват кратки имена (aliases) за таблиците. Тази практика е разпространена и в LINQ заявките в C#, тъй като LINQ черпи вдъхновение от SQL. Ето как горната заявка може да бъде опростена с помощта на алиаси:

```sql
SELECT *
FROM Towns AS t
JOIN Countries AS c ON c.Id = t.CountryId
```

Когато се налага филтрация, тя може да бъде включена директно в условието на `JOIN`, вместо да се използва `WHERE`. Това често е по-интуитивно и подобрява четимостта на заявката, особено ако филтърът е свързан с връзката между таблиците.

Пример:

```sql
SELECT *
FROM Towns AS t
JOIN Countries AS c ON c.Id = t.CountryId AND c.Name = 'Bulgaria'
```

Тук условието `c.Name = 'Bulgaria'` е част от `JOIN`, което означава, че заявката ще включи само градовете, свързани с държавата "Bulgaria".

Предимства на този подход:

- Намалява ненужната обработка на данни, като ограничава редовете, които участват във връзката.
- Подобрява четимостта, когато филтрацията е логически свързана с връзката между таблиците.

Забележка:
Филтрацията в `JOIN` и `WHERE` може да даде различни резултати в зависимост от типа на връзката (`INNER JOIN`, `LEFT JOIN` и т.н.). Например, ако използваме `LEFT JOIN` и филтърът е в `JOIN`, това може да елиминира редове, които иначе биха се показали с `NULL` стойности при филтриране в `WHERE`.
## Cascade Operations
Cascading (каскадни операции) е механизъм в базите данни, който позволява автоматично актуализиране или изтриване на свързани редове в зависимост от действията върху първичния ред в една таблица. Това се използва, за да се гарантира, че данните остават консистентни и няма редове без валиден reference. Каскадните операции са опции, които се задават като част от **foreign key constraint-а** в SQL. Те определят какво трябва да се случи в child таблицата, когато съответният ред в parent таблицата бъде актуализиран или изтрит.

**Предимства на каскадните операции:**

- **Автоматизация:** Намаляват ръчната работа и грешките при поддръжката на връзките между таблиците.
- **Консистентност:** Предотвратяват "сиротни" записи, които нямат валидна връзка с родителската таблица.
- **Улесняват управлението на данни:** По-лесно е да се управляват сложни структури с множество свързани таблици.

**Потенциални рискове:**

- **Непреднамерено изтриване:** Ако каскадното изтриване не се използва внимателно, може да доведе до загуба на много данни.
- **Сложност:** В много сложни структури каскадните операции могат да направят базата данни трудна за разбиране и поддръжка.

Затова е важно да се използват каскадните операции само когато са необходими и добре обмислени.

Видове каскадни операции:
### ON UPDATE CASCADE
Когато стойността на primary key в parent таблицата бъде актуализирана, всички свързани foreign key стойности в child таблицата автоматично се актуализират.

**Пример:**  
Ако промените `CountryID` в таблицата `Countries`, съответните редове в таблицата `Towns` също ще се актуализират.

```sql
CREATE TABLE Countries (
    CountryID INT PRIMARY KEY,
    CountryName VARCHAR(50)
);

CREATE TABLE Towns (
    TownID INT PRIMARY KEY,
    TownName VARCHAR(50),
    CountryID INT,
    CONSTRAINT FK_Towns_Countries FOREIGN KEY (CountryID)
    REFERENCES Countries (CountryID)
    ON UPDATE CASCADE
);
```

**ON UPDATE CASCADE** може да се използва, когато основният ключ не е `IDENTITY` и може да бъде променян. Това е полезно, когато имаме уникален ключ, който може да се актуализира, и искаме да се осигури автоматично актуализиране на свързаните редове в child таблицата. Най-добре е да се използва с `UNIQUE` constraint, за да се гарантира, че новото значение ще бъде валидно и няма да нарушава уникалността.

Не трябва да се използва **ON UPDATE CASCADE**, когато основният ключ е `IDENTITY`, тъй като стойностите на `IDENTITY` обикновено се генерират автоматично от базата данни и не трябва да се променят. Променянето на стойността на идентичност може да води до непредвидими резултати и проблеми със съответствието на данните.

Като цяло **ON UPDATE CASCADE** има ограничена употреба и може да се избегне чрез използване на **triggers** или **procedures**, които ще изпълнят необходимите актуализации по конкретни правила и условия, осигурявайки по-голяма гъвкавост и контрол върху процеса.

**Освен каскадното актуализиране (ON UPDATE CASCADE), имаме и следните допълнителни възможности:**

**ON UPDATE SET NULL**  
Когато се актуализира стойността на родителския ключ в родителската таблица, колоната в child таблицата, съдържаща външен ключ, се задава на `NULL`. Това е полезно, ако не искаме да запазим невалидни стойности в child таблицата след промяна на родителската стойност. Например, ако променим идентификатора на държава в таблицата `Countries`, свързаните градове в таблицата `Towns` ще имат стойността `NULL` в колоната `CountryID`, ако старият `CountryID` вече не е валиден.

**ON UPDATE SET DEFAULT**  
При актуализиране на стойността на родителския ключ в родителската таблица, колоната в child таблицата ще бъде зададена на стойността по подразбиране (`DEFAULT`). Това осигурява възстановяване на предварително дефинирана стойност в child таблицата при промяна на стойността в родителската таблица. Например, ако променим идентификатора на студент в таблицата `Students`, таксите му в таблицата `Fees` могат да бъдат зададени на стойност по подразбиране (например "служебен студент"), ако старият идентификатор вече не е валиден.
### ON DELETE CASCADE
Когато ред в parent таблицата бъде изтрит, всички свързани редове в child таблицата автоматично се изтриват.

**Пример:**  
Ако изтрием дадена държава от таблицата `Countries`, всички градове в таблицата `Towns`, които принадлежат на тази държава, ще бъдат изтрити.

```sql
CREATE TABLE Countries (
    CountryID INT PRIMARY KEY,
    CountryName VARCHAR(50)
);

CREATE TABLE Towns (
    TownID INT PRIMARY KEY,
    TownName VARCHAR(50),
    CountryID INT,
    CONSTRAINT FK_Towns_Countries FOREIGN KEY (CountryID)
    REFERENCES Countries (CountryID)
    ON DELETE CASCADE
);
```

Не трябва да се използва **ON DELETE CASCADE** при логическо изтриване, когато ентитетите са маркирани като изтрити, но не са реално изтрити от базата. В такива случаи е по-добре да се използват специални механизми за логическо изтриване (например поле `IsDeleted`), вместо да се разчита на каскадно изтриване.

Освен това, в по-сложни ситуации, когато има **циркулярни зависимости** между таблиците, каскадното изтриване може да не работи правилно. Циркулярните зависимости възникват, когато таблица A има външен ключ към таблица B, а таблица B има външен ключ към таблица A. Това води до цикъл, който може да причини затруднения при извършване на каскадно изтриване, тъй като базата данни не знае в какъв ред да изтрие редовете.

Можем да комбинираме **ON DELETE CASCADE** с **ON UPDATE CASCADE** на един и същи foreign key. Това осигурява:

- Автоматично изтриване на свързани редове при премахване на parent реда.
- Автоматично актуализиране на свързаните редове при промяна на parent реда.

**Приложение:** Използва се в ситуации, когато child данните губят смисъл без съответния родителски ред.

**Освен каскадното изтриване (ON DELETE CASCADE), можем да използваме и следните опции:**

**ON DELETE SET NULL**  
Когато редът в родителската таблица бъде изтрит, колоната в child таблицата, съдържаща външен ключ, ще бъде зададена на `NULL`. Това означава, че запазваме самия ред в child таблицата, но прекратяваме връзката му с родителския ред. Така, например, ако изтрием студент от таблицата `Students`, неговите свързани такси в таблицата `Fees` ще бъдат оставени със стойност `NULL` за `StudentID`.

**ON DELETE SET DEFAULT**  
При изтриване на ред в родителската таблица, колоната в child таблицата ще бъде зададена на стойността по подразбиране, дефинирана предварително. Това е полезно, когато искаме да заменим изтрития външен ключ с предварително зададена стойност. Например, ако изтрием студент от таблицата `Students`, таксите му в таблицата `Fees` могат да бъдат свързани с фиксирана стойност, като "служебен студент".

**Пример:** Ако изтрием студент, таксите му в таблицата за такси ще се свържат със стойност по подразбиране (например "служебен студент"). Това е полезно, когато искаме да поддържаме данни, свързани с изтритите редове, но да променим стойността на foreign key на фиксирана стойност.
## E/R Diagrams
Релационната схема на база данни представлява колекция от:

- Структурата на всички таблици в базата данни.
- Връзките между таблиците.
- Всички обекти на базата данни, като например **constraints** (ограничения).

**Релационната схема** описва архитектурата на базата данни, като съдържа метаданни, които дефинират как данните са организирани, но не включва самите данни.

Релационните схеми могат да бъдат графично представени чрез **Entity-Relationship диаграми** (E/R диаграми), които показват връзките и зависимостите между различните елементи на базата данни.

Промените направени в диаграмата, се отразяват и в самата база данни.

Ако отворим пропъртис, ще видим повече информация за обекта, като например неговите настройки, атрибути или стойности.
### SSMS E/R Diagram: Usage
Expand a database in Object Explorer -> Right click 'Database Diagrams" -> "New Database Diagram'  -> 'Add'
# Misc
## SSMS
В **SQL Server Management Studio (SSMS)**, е удобно да pin-нем **Object Explorer** и **Properties** за лесен и бърз достъп:
- **Object Explorer**: Показва структурата на базата данни и позволява навигация през таблици, процедури и други обекти.
- **Properties**: Показва детайли и настройки за избран обект, като таблици, колони, индекси и т.н.
# ChatGPT
## Comparison: Entities, Tables, and Classes
Tables in a database are analogous to **classes** in C#, and **entities** in a database usually correspond to tables. Here's the comparison:

1. **Entities**
    
    - Represent real-world objects or concepts in a domain (e.g., Bus, Stop, Route).
    - **In a database, entities are typically modeled as tables.**
2. **Tables (Database)**
    
    - Represent structures for storing data about specific entities.
    - Example: The `Buses` table corresponds to the **Bus entity**.
3. **Classes (C#)**
    
    - Represent templates for creating objects that mirror the data and behavior of entities.
    - Example: A `Bus` class defines the properties and behavior of the Bus entity.

**Similarities**

|**Entity**|**Table (Database)**|**Class (C#)**|
|---|---|---|
|Conceptual model|Physical structure for data|Logical structure for objects|
|Attributes|Columns|Properties|
|Instances|Rows|Objects|

**Example:**

**Entity:** Bus (concept)  
**Table in Database:**

```
Buses
| ID  | Number  | Brand | Capacity |
|-----|---------|-------|----------|
| 1   | 123     | MAN   | 50       |
| 2   | 456     | Volvo | 60       |
```

**C# Class:**

```csharp
public class Bus
{
    public int ID { get; set; }
    public string Number { get; set; }
    public string Brand { get; set; }
    public int Capacity { get; set; }
}
```

**C# Instances:**

```csharp
var bus1 = new Bus { ID = 1, Number = "123", Brand = "MAN", Capacity = 50 };
var bus2 = new Bus { ID = 2, Number = "456", Brand = "Volvo", Capacity = 60 };
```

**Differences**

- **Entities** are abstract concepts that describe objects in the real world.
- **Tables** implement entities as structured data in a database.
- **Classes** model entities in code for use in an application during runtime.

**Conclusion**

Entities in a database are most often represented as **tables**, while their attributes are modeled as columns. In C#, entities are mirrored by **classes** that define their properties and behavior. This analogy helps connect database design with object-oriented programming.
## Foreign Key Placement
**Inline Constraints**

The foreign key is declared directly within the column definition.

**Example 1:**

```sql
CREATE TABLE Persons (
    PersonId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(25),
    Salary MONEY,
    PassportID INT CONSTRAINT FK_PersonsPassports FOREIGN KEY REFERENCES Passports(PassportID)
);
```

**Example 2:**

```sql
CREATE TABLE Persons (
    PersonId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(25),
    Salary MONEY,
    PassportID INT REFERENCES Passports(PassportID)
);
```

**Table-Level Constraints**

The foreign key is defined after all columns are declared.

**Example:**

```sql
CREATE TABLE Persons (
    PersonId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(25),
    Salary MONEY,
    PassportID INT,
    CONSTRAINT FK_PersonsPassports FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)
);
```

**Position Matters**

- **Inline constraints** must be placed alongside the relevant column.
- **Table-level constraints** must appear after all columns are defined.

**Key Takeaway**

All three methods achieve the same result, but **table-level constraints** are more flexible for composite keys or complex relationships. The `NOT NULL` constraint is optional for creating foreign keys but ensures that the column cannot contain `NULL` values.
## One-to-One Purpose
What's the purpose of having one-to-one tables when we can have all the columns in just one table, there won't be any duplication either way?

**ChatGPT said:**

Using one-to-one tables in a database is generally about **design decisions** aimed at improving flexibility, maintainability, and performance. While it may seem redundant to split data into multiple tables if there is no duplication, there are valid reasons for this approach:

**Separation of Concerns**

- By splitting data into different tables, you keep related data organized. For example:
    - A `Users` table could store general user information (e.g., name, email).
    - A `UserDetails` table could store less frequently accessed or sensitive information (e.g., bio, preferences, social security number).
- This makes the schema cleaner and easier to maintain.

2. **Performance Optimization**

- Having frequently accessed columns in one table and less-used columns in another can improve query performance.
- For example, if your application mostly queries user names and emails, it avoids scanning through additional columns that are rarely needed.

3. **Optional Data**

- If certain fields are not always required, having a separate table allows you to avoid null values in the main table.
- Example:
    - Main table: `Users` with columns like `id`, `name`, `email`.
    - Optional table: `UserDetails` for optional fields like `profile_photo` or `address`.

4. **Sensitive or Secure Data**

- Storing sensitive data (e.g., payment info or medical records) in a separate table with restricted access can improve security.
- You can apply different access controls or encryption at the table level.

5. **Future Extensibility**

- If you need to expand or modify certain fields, a separate table reduces the risk of breaking existing relationships or functionality in the main table.
- It also makes schema migrations easier for specific subsets of data.

6. **Avoiding Table Locking**

- In some databases, large rows can lead to locking and slower performance during updates.
- Splitting tables reduces row size, improving update performance.

**When Should You Avoid One-to-One Tables?**

If the separation doesn't provide any of these benefits—e.g., if all columns are always accessed together and there are no optional or sensitive fields—keeping everything in one table can simplify your design.

In summary, **one-to-one tables are used for clarity, efficiency, security, and maintainability**. However, whether to use them depends on your application's specific requirements.
## Adding Constraint Difference
The primary difference between adding a constraint during table creation and altering the table later to add a constraint is the **`ADD` keyword**.

Here’s a breakdown of the differences:

**1. Adding Constraint During Table Creation:**

When creating the table, you define the constraint **within** the `CREATE TABLE` statement. No `ADD` keyword is used here.

**Example:**

```sql
CREATE TABLE Users (
    id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    CONSTRAINT unique_name UNIQUE (first_name, last_name)
);
```

**2. Altering Table to Add a Constraint:**

If the table already exists, you can **alter** it to add a constraint. In this case, you use the `ALTER TABLE` statement along with the `ADD` keyword to introduce the constraint.

**Example:**

```sql
ALTER TABLE Users
ADD CONSTRAINT unique_name UNIQUE (first_name, last_name);
```

**Key Difference:**

- **Table Creation**: You include the constraint **directly in the `CREATE TABLE` statement**.
- **Altering Table**: You **add the constraint after the table is created** using `ALTER TABLE` with the `ADD` keyword.

In both cases, the constraint enforces uniqueness on the combination of the two columns (`first_name`, `last_name`), but the method of adding the constraint differs based on whether you're creating the table or modifying an existing one.
# Bookmarks
Completion: 07.01.2025