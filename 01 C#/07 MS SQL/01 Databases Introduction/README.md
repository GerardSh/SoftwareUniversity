# General
## Data Management
Базата данни съхранява множество данни на едно място и предоставя възможност за тяхното управление и манипулиране. Основната задача на базата данни не е само съхранението на данни, а и осигуряването на ефективно и организирано управление. Ако просто съхраняваме данни без система за управление, възникват различни проблеми:
- Size - когато данните не са правилно организирани, тяхното съхранение може да стане неефективно, като води до по-голямо натоварване на ресурсите и затруднения в обработката на големи обеми информация.
- Ease of updating - без система за управление актуализирането на данни може да бъде трудно и податливо на грешки. Без адекватен контрол върху данните, възможността за несъгласуваност и загуба на информация се увеличава.
- Searching - за ефективно търсене, базите данни използват различни методи като индексиране, което значително ускорява процеса. Индексите позволяват на системата да намира данни бързо без да се преглеждат всички записи. Това е особено полезно при работа с големи бази данни.
- Concurrency (Паралелност) - се отнася до способността на базата данни да обработва множество заявки или транзакции едновременно. Това е важно за поддържането на ефективността и скоростта в условия на голям брой потребители или процеси. За да се избегнат проблеми или конфликти при промени на данни, се използват механизми за управление на паралелността като транзакции и блокировки.
- Security - механизъм за споделен достъп и грануларност се отнася до възможността за прецизно управление на правата за достъп до данни на различни нива. Това позволява на различни потребители или групи да имат различни нива на достъп и видимост до данните, като осигурява защита и конфиденциалност.
- Consistency - отнася до принципа, че данните в базата трябва да бъдат валидни според зададените правила, ограничения и условия след всяка операция, като добавяне, актуализиране или изтриване на записи. SQL server е 100% ACID
## Databases and RDBMS (Relational Database Management System)
Базата данни е организирана колекция или колекции от информация, които се съхраняват и управляват по структуриран начин. Чрез прилагането на различни механизми и правила за управление на данните, се осигурява бързо намиране на необходимата информация, както и лесно добавяне, промяна и изтриване на данни. Тези операции се извършват ефективно и безопасно, като се използват технологии като индексиране, транзакции и интегритетни правила, които гарантират точността и последователността на данните.

За първи път през 1970 Edgar Codd предлага relational storage, с идеята да се оптимизира мястото за запис на информацията, защото съхранението е било много скъпо. В момента може да си позволим нерелационни бази данни, заради евтиния storage.

RDBMS предоставя инструментите за управление / работа с базите данни. Database engine-a който съдържа RDBMS-a, може да разчете нашите заявки, тоест имаме инструмент който може да кажем на RDBMS-a какво очакваме от него и той да го изпълни. Може да парсне нашия request, да разбере какво имаме предвид и да предприеме съответните действия. В DBMS системите, нямаме достъп до данните директно, но само management system.
## Database Engine Flow
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241218213017.png)

Engine-a е част от DBMS. SQL server използва client-server модела. Клиента се обръща към database engine-a, по стандартен начин - чрез език който позволява да се обръщаме към DBE. Езика е SQL (Structured Query Language), който е стандартен за изпращане на заявки. SQL работи основно за RDBMS системите, докато нерелационните бази данни, имат подобие, други като MongoDB работят с JS като език за заявки и манипулиране на данните. Всички системи имат език за правене на заявки.
Когато клиента изпрати заявка към DBE, той я parse-ва и проверява дали спазва определени правила и да я превърне в инструкции, които може да се изпълнят върху самите данни. В резултат на извършените действия от DBE към базата, се връщат данни към клиента. 
При всички случаи, към клиента се връща информация, дори заявките които имат за цел да променят / добавят данни, получават информация какво количество данни са променили / добавили.
## SQL Server Architecture
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241218212940.png)

Когато инсталираме SQL server-a, той прави инстанция, като ние може да инсталираме повече от една инстанция. SQL по дизайн използва много RAM, когато е пуснат в server mode, използва целия RAM на машината, без значение колко е. Инстанциите са именувани, за да може да ги достъпваме.
Вътре в инстанциите, имаме много бази данни, като всяка от тях, може да бъде достъпвана отделно. Може да даваме видимост на потребителите, само върху определена база данни.
В базата данни, има schema (схема). Схемата е като папка, с главната цел да е организационна структура, но също влияе и на достъпа, защото някой може да има достъп до базата, но не и до конкретната схема. В отделна схема, може да отделим неща, които само определени хора, може да достъпват. Всички сървъри имат default схема, като при SQL server е DBO.
Всяка схема се състои от множество таблици.
Имаме и физически storage, това е Data File от тип ROWS Data с разширение `.mdf` в който се пазят данните от базата, като също имаме и Transaction Log File от тип LOG с разширение `.ldf`, където се пазят всички изменения на данните. В лога се записват последователно всяка една от изпълнените заявки. Може да се контролира степента на запазване, както и колко информацията да съдържат. Ако имаме full transaction log, тоест пази цялата информация без лимити, може да се ползва като машина на времето. Ако сме направили backup на базата, transaction лога се изчиства и новата информация след backup-a, отново се запазва в transaction log-a, който ще се изчисти, когато направим нов backup. Ако сме направили backup от преди три дни и по някаква причина, тя се corupt-ва в 12:00 часа, ние може да възстановим базата с версията от преди три дни и използвайки transaction log-a, ще се възстанови цялата информация до посоченото време, примерно в 11:59.

При механично копиране на файлове, може да доведе до проблем. Не винаги може да се вземат файловете и да се прехвърлят на друга машина. Ползва се log shipping, за синхронизация на два сървъра - възстановяват се последните backup-и на двата, след което се пуска изравняване на логовете. Един от сървърите е master, неговия лог сe ship-ва към slave-a, където се изпълняват всички транзакции, което води до изравняване на базите данни и се постига репликация.
## Database Table Elements
Таблицата е основната градивна единица на базите данни и се състои от редове и колони. 
Всеки ред в таблицата представлява уникален запис, а всяка колона съдържа конкретен тип информация за всеки запис. Всеки ред съдържа данни за конкретен обект или събитие. Редовете обикновено се наричат записи (records) и са уникални, като съдържат стойности за всяка от колоните на таблицата.
Колоните са структурирани категории данни.
Entity в контекста на базите данни, представлява конкретен обект или събитие, което е записано в реда на таблицата. Например, ако имаме таблица за служители, всеки ред може да представлява служител с данни като име, длъжност, заплата и т.н. Всяка колона в таблицата е свойство на даденото entity и съвкупността от всички колони, описва entity-то като цяло. Entity-то се вписва освен в релационния, но и в обектния модел, понеже обекта е съвкупност от свойства / пропъртита, точно както реда е съвкупност от колони.
Колекцията от entity-та прави таблицата, а колекцията от таблици, прави базата данни.
## Structured Query Language
Ползваме SQL за да комуникираме с DB Engine-a.
SQL е декларативен език, за разлика от повечето езици, които са процедурни. В SQL казваме какво трябва да се случи и engine-a го прави. Работата на engine-a е да знае как да свърши нещото, което сме му задали.

Логически е разделен на 4 раздела:
- Data Definition - среща се и като DDL, където L е language. Описва структурата на нашите данни.
- Data Manipulation - запазва и връща информация.
- Data Control - дефинира достъпите.
- Transaction Control - операции, които ни позволяват да използваме така наречените транзакции. Имаме нужда от транзакциите, за да си гарантираме консистентността на данните.
## Data Types in SQL Server
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241219202132.png)
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241219202652.png)
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241219203737.png)

Една от основните цели при работата с бази данни е оптималното съхранение на възможно най-много данни в минимален обем. Типовете данни играят ключова роля в това – те позволяват информацията да заема точно толкова място, колкото е необходимо. Затова е от съществено значение да се избират правилно типовете данни, за да се минимизира физическото пространство, което базата заема върху диска.
## Database Modelling - Data Definition Using SSMS
За да създадем нова база данни в SSMS, е необходимо да цъкнем с десен бутон върху Databases и да изберем New Database. След това трябва да зададем име на базата данни, собственик, както и местоположението за съхранение на файловете. Може да се конфигурира началният размер на файловете, стъпката на нарастване при достигане на зададените граници, както и да се определи таван за максималния растеж на файловете. Ако изберем базата да расте с малки стъпки и това се случва често, ще има значително забавяне. По-добре е да расте по-рядко, но с по-голям обем.

Може да се избере Collation, който в SQL Server определя как се сравняват и сортират текстови данни. То включва:
Чувствителност към големи и малки букви:
- CI (Case Insensitive): не разграничават "a" и "A".
- CS (Case Sensitive): разграничават "a" и "A".
Чувствителност към акценти:
- AI (Accent Insensitive): не разграничават "e" и "é".
- AS (Accent Sensitive): разграничават "e" и "é".

Collation се задава на ниво база данни, таблица или колона и влияе на сортирането и сравняването на текстови стойности.

Recovery model в SQL Server определя как се управляват и записват транзакциите в transaction log файла.
### Creating Tables
Когато създадем базата данни, трябва да й добавим таблици. Създават се с десен клик на папката Tables в базата данни  New => Table.
Името на таблицата се въвежда когато натиснем Save или да го въведем в Properties Window (F4). Добре е да се попълва и description, това помага и при генерирането на документация за базата данни.
Имената по конвенция, трябва да са в множествено число, защото са колекция. При SQL server се спазва PascalCase.

Желателно е да се въвежда description за всяка колона.

При имената на колоните отново са спазва PascalCase.
Трябва да се избере и типа на колоната, както и дали разрешаваме Nulls.

Създаването на таблиците, може да стане и чрез SQL. Ако натиснем десен бутон върху дадена таблица => Script Table as => CREATE To => New Query Editor Window ще ни генерира необходимия код за създаване на таблицата автоматично.

Когато създаваме нови бази и таблици, понякога може да не се появят в менюто и трябва да се натисне върху Databases папката => refresh, а ако е таблица трябва да се refresh-не папката с таблици.
#### Primary Key 
Когато създаваме колони, трябва да се избере една от тях като primary key. Primary key-a е нещо което идентифицира еднозначно entity-то. Mоже да имаме само един Primary Key в таблица, но той може да бъде съставен от повече от една колона. Това се нарича съставен (composite) primary key. При съставен Primary Key може да има дублиращи се стойности в една от колоните, но комбинацията от стойностите в колоните, които формират основния ключ, трябва да бъде уникална. 
По Primary Key-a винаги може да намерим конкретното entity, което ни трябва, защото винаги е уникален. От опциите на колоната, в Identity Specification => Is Identity трябва да изберем yes, като Increment и Seed отговарят от каква стойност да започнат и с колко да се увеличават, при добавяне на нов запис. Това са стъпките за всеки първичен ключ, ако той е цяло число.
Не може да задаваме стойности на Identity, освен чрез специална команда, но не се препоръчва.
#### Foreign Key
Чужд ключ (Foreign Key) е поле в една таблица, което се използва за създаване на връзка с друга таблица. Тази връзка помага да се поддържа референтна цялост в базата данни и да се избегне повторението на данни. Трябва да имаме съвпадение на типовете данни между двете Foreign Key-a и колоната към която сочи в другата таблица. Таблиците трябва да бъдат в същата база данни за да може да се направи връзка.  Може да имаме повече от един такъв ключ в една таблица.

Пример:

- Имаме таблица с информация за потребители, която съдържа поле за град. Вместо да записваме името на града (например, "София") за всеки потребител, можем да създадем втора таблица, която съдържа списък с градове, като всяко име на град е свързано с уникален идентификатор (ID).
- В първата таблица (с потребителите) вместо да записваме самото име на града, просто записваме идентификатора на града, който се съвпада с ID-то от втората таблица.

Таблица **Users** :

| UserID | UserName | CityID |
| ------ | -------- | ------ |
| 1      | Иван     | 1      |
| 2      | Петър    | 2      |
| 3      | Мария    | 1      |

Таблица **Cities** :

| CityID | CityName |
| ------ | -------- |
| 1      | София    |
| 2      | Пловдив  |
| 3      | Варна    |

- В първата таблица, вместо да повтаряме името на града за всеки потребител, записваме само идентификатора (например, 1 за София).
- Ако в бъдеще искаме да променим името на "София" на "Нова София", това може да стане само на едно място - в таблицата **Cities** (само в реда, където `CityID = 1`).
 
**Какво постига това:**

1. По-малко повторение на данни - вместо да записваме името на града многократно, използваме само ID.
2. Лесна промяна - ако името на града се промени, няма нужда да търсим и променяме всеки запис в таблицата с потребителите. Променяме името само на едно място - в таблицата с градовете.
3. По-добра организация - всяка таблица съдържа един вид информация (потребители или градове), което прави базата данни по-структурирана и по-лесна за управление.

Това е основната идея на **релационните бази данни**: използването на **чужди ключове** за свързване на различни таблици помага да се избегне излишно повторение на данни и улеснява поддържането на целостта на информацията.
Това е една от основните разлики между релационните и не-релационните бази данни е, че релационните бази данни използват таблици с релации чрез чужди ключове, което осигурява целостта и консистентността на данните, докато не-релационните бази данни не използват релации и предлагат по-гъвкав подход за съхранение на данни.
### Storing Data
Ръчното създаването на entity в таблицата става с десен бутон върху нея => Edit Top 200 Rows, въвеждане на данните.
Типовете данни в базите контролират не само размера на съхраняваните данни, но и каква информация може да бъде записана. Например, опитът да се въведе текст в колона от числов тип ще доведе до грешка, тъй като не е възможно автоматично конвертиране от текст към число. Обратно, числовите стойности могат да бъдат записани в колона от текстов тип, тъй като числата могат да бъдат интерпретирани като стринг.
Трябва да се има предвид, че в дадени ситуации може да прескочи Id номер, примерно ако се опитаме да въведем запис без цялата задължителна информация, ще даде грешка, но това ще се води като използван Id номер и следващия запис ще започне от следващия номер.
### Retrieving Data
С десен бутон върху таблицата => Select Top 1000 Rows.
### Altering Tables
С десен бутон върху таблицата => Design.
Може да се добавят колони, да се сменят типове данни и тн.
Ако искаме да добавим колони след като сме създали таблица и тя вече съдържа данни, трябва новите колони или да разрешават Null или да имат default стойност.
## SQL Queries
Може да комуникираме с database engine-a ползвайки SQL.
Заявките дават повече контрол и гъвкавост, поради което се използват много повече от ръчното въвеждане в SSMS.

Когато пишем SQL заявки, е задължително да сме избрали правилната база данни, защото заявката ще се изпълнява само в контекста на текущо избраната база. Ако не изберем правилната база, може да получим грешки или заявката да се изпълни върху друга база, което ще доведе до нежелани резултати. Това може да се направи през SSMS горе в ляво, като посочим дадена база от падащото меню или да напишем 

```sql
USE MyDatabase; 
GO
```

Тази команда ще настрои SQL Server да използва `MyDatabase` като активна база данни за всички следващи заявки. Заявките, които последват командата USE, ще работят с базата `MyDatabase`, докато не бъде изпълнена нова USE команда за друга база.

SQL keywords традиционно са с главни букви, въпреки че и с малки букви би работило.

Редът на ключовите думи в SQL заявката е строго определен. Ако ги разместим, заявката ще даде грешка.

Квадратните скоби около имената на колони и таблици не са задължителни, освен ако името съвпада със служебна дума или съдържа специални символи. Когато имаме дублиране между име на колона и служебна дума, примерно искаме да кръстим колоната Date, но понеже има и тип Date, тогава името на колоната трябва да е задължително в квадратни скоби.

Списък със заявки има в папката с ресурси във файла за SQL.

IntelliSense в SSMS е инструмент за подпомагане при писането на SQL код. Той автоматизира и улеснява програмирането, като предлага функционалности за подсказване, autocomplete и откриване на грешки в реално време.
IntelliSense не се обновява автоматично, когато се добави нова таблица или промени структурата на базата данни.
За да се обнови трябва да се натисне - `Ctrl + Shift + R` или `Edit > IntelliSense > Refresh Local Cache`, ако това не помогне, трябва да се рестартира SSMS.

Когато изберем само част от заявка SSMS и я изпълним, SSMS ще изпълни само избраната част, при условие че тя е валидна самостоятелно. Например, ако селектираме само колоните в **SELECT** частта, тя ще бъде изпълнена, но ако част от заявката липсва и не е валидна (например **WHERE**), ще получим грешка.
## Constraints
(Ограничения) в SQL са правила, които се прилагат върху данните в таблиците, за да се осигури целостта и валидността им. Те дефинират какви стойности могат да бъдат въведени в дадена колона или какви отношения могат да съществуват между таблиците. Основните видове ограничения включват:

1. **PRIMARY KEY**: Уникален идентификатор за всяка редица в таблицата. Не позволява дублиране на стойности и NULL стойности в колоната.
2. **FOREIGN KEY**: Използва се за създаване на връзка между две таблици, като посочва колона в една таблица, която се отнася към първичния ключ в друга таблица.
3. **UNIQUE**: Осигурява, че стойностите в дадена колона ще бъдат уникални, т.е. няма да се повтарят.
4. **CHECK**: Налага определени условия върху стойностите в дадена колона (например, стойностите да са по-големи от 0).
5. **NOT NULL**: Забранява колоната да съдържа NULL стойности, което означава, че за всяка редица трябва да има стойност в тази колона.
6. **DEFAULT**: Определя стойност по подразбиране за дадена колона, когато не е посочена стойност при вмъкване на нови данни.

Тези ограничения помагат да се гарантира, че данните в базата данни отговарят на определени правила и не нарушават целостта на информацията.
# Misc
# ChatGPT
## SQL
**SQL (Structured Query Language)** is the standard language used by most relational database servers like **PostgreSQL**, **MySQL**, **SQL Server**, **Oracle**, and others. These databases use SQL as the primary way to interact with and manage the data, but there are some differences in how they implement the SQL standard.

**Key Points About SQL in Different Database Servers:**

1. **SQL is Standardized**:  
    The SQL language has a standard defined by organizations like ANSI (American National Standards Institute) and ISO. This standard includes basic operations like querying, inserting, updating, and deleting data.
2. **Dialect Variations**:  
    Each database server has its own SQL **dialect** with unique extensions or features that go beyond the standard:
    - **PostgreSQL**: Offers advanced features like window functions, JSON support, and full-text search.
    - **MySQL**: Known for its simplicity and popularity in web applications, with features like replication.
    - **SQL Server**: Extends SQL with **Transact-SQL (T-SQL)**, offering features like stored procedures and triggers.
    - **Oracle**: Uses **PL/SQL**, a powerful procedural language for complex operations.
3. **Core SQL Features**:  
    Despite dialect differences, the fundamental SQL operations (like `SELECT`, `INSERT`, `UPDATE`, and `DELETE`) are consistent across most databases.
4. **Non-Relational Databases**:  
    While SQL is dominant in relational databases, some non-relational (NoSQL) databases, like MongoDB, use other languages or query methods.

**Example of Differences:**

A simple query like this works almost identically in most databases:

```sql
SELECT * FROM Employees WHERE Age > 30;
```

However, advanced queries or features, such as querying JSON data, might differ:

- **PostgreSQL**:

```sql
SELECT data->>'name' FROM employees WHERE data->>'age' > '30';
```

- **MySQL**:

```sql
SELECT JSON_UNQUOTE(JSON_EXTRACT(data, '$.name')) FROM employees WHERE JSON_EXTRACT(data, '$.age') > 30;
```

**Conclusion:**

SQL is the backbone of relational databases, but understanding the specific dialect of the database server you are using is essential for leveraging its full capabilities.
## Tables Similar to Arrays with Objects
When we create tables, can we look at them as objects with properties inside an array?

**ChatGPT said:**

Yes, you can think of database tables as objects with properties (or fields) inside an array when working with programming concepts or ORM (Object-Relational Mapping) systems. Here's how this analogy works:
1. **Table as an Array**:
    - A table is conceptually similar to an array (or list in C#).
    - Each row in the table is equivalent to an element in the array.
2. **Row as an Object**:
    - Each row in the table can be represented as an object.
    - The columns in the table act as properties of the object, with the column values being the property values.

**Table Representation:**

|ID|Name|Age|
|---|---|---|
|1|John|30|
|2|Alice|25|

**JavaScript Equivalent:**

```javascript
const table = [
  { ID: 1, Name: "John", Age: 30 },
  { ID: 2, Name: "Alice", Age: 25 }
];
```

**C# Equivalent:**

```csharp
var table = new List<dynamic>
{
    new { ID = 1, Name = "John", Age = 30 },
    new { ID = 2, Name = "Alice", Age = 25 }
};
```

**Why This Analogy Works:**

- **Table = Collection of Rows:** Tables group data in rows, just like an array groups objects or elements.
- **Row = Object:** Each row encapsulates specific data, just like an object encapsulates properties.
- **Column = Property:** Columns define the schema (structure) of the data, just like properties define an object's shape.

**Practical Use:**

- **JavaScript with Arrays of Objects**:
    - When fetching data from a database (e.g., via `SELECT * FROM`), you'll often work with arrays of objects in JavaScript.
- **C# with Entity Framework**:
    - Tables map to classes, rows to objects, and columns to class properties.

This perspective is especially useful when working with APIs, ORMs, or modern frameworks, as it aligns the relational data with object-oriented or JSON-based paradigms.
## Docker
**Docker** is a platform that allows developers to automate the deployment, scaling, and management of applications by using **containers**. Containers are lightweight, portable, and isolated environments that package applications and all their dependencies into a single, consistent unit. This helps ensure that the application runs the same way, regardless of where it is deployed.

**Key Docker Components:**

1. **Docker Engine**: The Docker Engine is the core component of Docker. It consists of a **client-server** architecture:
    - The **client** allows users to interact with Docker (via the command line or API).
    - The **server (Docker Daemon)** is responsible for building, running, and managing containers.
2. **Docker Image**: A Docker image is a **read-only template** that contains all the necessary files and instructions to run an application, such as the operating system, application code, libraries, and other dependencies. Images are used to create containers.
3. **Docker Container**: A Docker container is a **running instance** of a Docker image. It is a lightweight, standalone, and executable package that contains everything needed to run a piece of software. Containers are isolated from each other and the host system, which improves security and ensures consistency across environments.
4. **Docker Hub**: Docker Hub is a **cloud-based registry** that stores Docker images. It is a public repository where you can find and download ready-made images for various applications like **MySQL**, **Nginx**, **Node.js**, and more. Users can also upload their own images to share with others.
5. **Dockerfile**: A **Dockerfile** is a script consisting of a series of commands to automate the creation of a Docker image. It defines the base image, software dependencies, configurations, and other instructions needed to build the environment.
6. **Docker Compose**: **Docker Compose** is a tool for defining and running multi-container Docker applications. Using a `docker-compose.yml` file, you can define how containers should interact, including their networks, volumes, and dependencies, making it easier to manage complex applications with multiple services.

**Key Advantages of Docker:**

- **Isolation**: Each application runs in its own container, ensuring that there are no conflicts between different applications and their dependencies.
- **Portability**: Containers can be run on any machine with Docker installed, regardless of the underlying operating system, making it easy to move applications between different environments (development, testing, production).
- **Fast Startup**: Containers are much faster to start compared to traditional virtual machines because they don’t require a full operating system to boot.
- **Easy Dependency Management**: Docker containers allow for consistent and reproducible environments by packaging all necessary dependencies along with the application.
- **Version Control and Repeatability**: Docker images can be versioned, enabling developers to maintain consistent environments and easily roll back to previous versions if needed.

**Common Docker Workflow:**

1. **Create a Dockerfile**: Define the environment and application setup.
2. **Build the Image**: Use the command `docker build` to create a Docker image from the Dockerfile.
3. **Run the Container**: Use `docker run` to create a container from the image and run the application.
4. **Manage and Scale**: Use Docker’s tools to manage, scale, and deploy containers in various environments.

Docker simplifies the development, testing, and deployment processes, making applications more portable, scalable, and easy to maintain. It provides a consistent environment for developers, reducing the "it works on my machine" problem.
### Docker Image
An image is a ready-to-use copy of a system (virtual machine or container) that can be started directly. It is pre-configured, set up, and ready for use, containing the operating system, software, settings, and other necessary resources for a specific task.  
In the context of **Docker**, an image is a core concept. A Docker image is a **template** that contains everything needed to start a container, including:
- A base operating system (or a minimal one).
- Applications, dependencies, and libraries.
- Configuration files and scripts.

In other words, the image contains a specific product, such as **MS SQL Server**, along with the necessary parts of the operating system required to run SQL Server. This may include essential libraries, configurations, and other components that are either part of the operating system or needed to run SQL Server.
## Projects, Solutions, and Database Relations in SQL and SSMS
- **Solution**:
    - In **SQL Server Management Studio (SSMS)** or Visual Studio, a **solution** is a container used to organize and manage multiple related **SQL Server projects**.
    - A solution doesn't directly contain a database but organizes different database-related tasks, such as development, testing, and deployment.
    - A **solution** can include multiple **SQL Server database projects** or other project types that interact with databases, such as application projects (e.g., backend services).
- **Project**:
    - A **project** in SSMS or Visual Studio represents a specific database or a part of a database system that you are working on. This can include database schemas, SQL queries, stored procedures, tables, or views.
    - A **SQL Server database project** contains scripts and resources to define, manage, and deploy the database structure (such as creating tables, views, and stored procedures).
    - You can have different database projects within a solution, each focusing on different aspects of a database system or even different databases.
- **Database**:
    - A **database** is a real, operational instance of a data storage system, such as **SQL Server**. It holds the data and database objects like tables, indexes, stored procedures, and views.
    - A **database** is managed and accessed by **SQL Server** but is independent of the solution or project structure. However, the **SQL Server database project** in Visual Studio or SSMS is used to deploy and modify the database.
    - Multiple **projects** within a solution can interact with the same database, or a database can be shared between different **solutions** and **projects**.

**Key Points:**

- **Solution**: A higher-level organizational unit that groups related **SQL Server database projects** together.
- **Project**: A specific SQL database-related task within a solution, which can include database definitions (tables, views, stored procedures), queries, and other SQL resources.
- **Database**: The actual data storage system (like SQL Server) that is accessed and modified by projects, holding the real data used by applications.

**Relationships:**

- **Solutions** help manage multiple **SQL Server database projects**, providing an organized structure for database development.
- **SQL Server database projects** contain SQL scripts and resources that define and manage the database structure, which can be deployed to an actual **database**.
- A **database** can be shared by multiple **projects**, allowing them to interact with the data and perform operations on it. Each **project** can access, modify, and query the data stored in the **database**, while the **solution** helps manage and organize the related projects.
# Bookmarks
[DBeaver Community | Free Universal Database Tool](https://dbeaver.io/) - безплатен, универсален инструмент за управление на бази данни, който предоставя мощни функции за администриране, разработка и анализ на данни. Той е създаден за работа с различни релационни и нерелационни бази данни.

[What is SQL Server? - SQL Server | Microsoft Learn](https://learn.microsoft.com/en-us/sql/sql-server/what-is-sql-server?view=sql-server-ver16) - официалната документация за Microsoft SQL Server.

Completion: 22.12.2024