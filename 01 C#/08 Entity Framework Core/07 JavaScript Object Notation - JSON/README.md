# General
## JSON Data Format
JSON няма общо с JavaScript; той е платформено и езиково независим формат, валиден за повечето езици. Макар да наподобява синтаксиса на JavaScript обекти, JSON е самостоятелна нотация със съществени разлики.

JSON е четим за хора, за разлика от прото буфер-а, който изисква приложение за декодиране.

Форматът е по-компактен от XML, тъй като съдържа по-малко мета информация. Това го прави по-лек, по-четим и по-малък като обем данни, но с по-малки възможности.

JSON е текстови формат.

Данните в JSON се състоят от двойки ключ-стойност: `{ "key": value }`. Ключовете винаги са низове, а стойностите могат да бъдат няколко типа, които JSON поддържа.

```json
{
	 "firstName": "Pesho",
	 "courses": ["C#", "JS", "ASP.NET"],
	 "age": 23,
	 "hasDriverLicense": true,
	 "date": "2012-04-23T18:25:43.511Z",
}
```

JSON поддържа масиви, като самият масив също е валиден JSON. В JSON могат да се вграждат масиви, обекти и други структури рекурсивно, което го прави много гъвкав формат.

JSON следва определени правила, за да бъде валиден.

```json
"this is a string and is valid JSON" 3.14 true
```

Числата в JSON са просто числа — няма подразделяне на типове като `double`, `long`, `int` и т.н.

Масивът е валиден JSON и може да съдържа стойности от различни типове:

```json
[5, "text", true]
```

Обектите също са валиден JSON и се състоят от двойки ключ-стойност (key-value pairs). За разлика от JavaScript обектите, в JSON ключът задължително трябва да бъде в двойни кавички:

```json
{
    "firstName": "Svetlin",
    "lastName": "Nakov",
    "jobTitle": "Technical Trainer",
    "age": 40
}
```

>[!IMPORTANT]
>След последния елемент в обект или масив не се поставя запетая, за да остане форматът валиден. Нещо което е възможно при JS обектите.
### Object, Array and Value in JSON
Можем да имаме празен обект `{}`. Стринг, който изпълнява ролята на ключ и се разделя с `:` от стойността, която може да бъде различни типове. Между елементите може да имаме интервали (whitespaces), за да изглежда JSON-ът по-прегледен. Например, `{"firstName:"Svetlin"}` е по-трудно за четене от:

```json
{
	"firstName": "Svetlin"
}
```

Когато схемата на JSON е обект, тогава имаме отварящи и затварящи скоби, като може да имаме само whitespaces между тях, при празен масив или стойности изредени със запетайки:

```json
["text", "text2", 1, 2, "text3"]
```

Поддържаните типове данни включват:

- текстови данни (string)
- числа (number)
- булеви стойности (boolean)
- масиви (array)
- обекти (object)
- `null` (празна стойност)

По стандарт, `null` е разрешена стойност в JSON. Въпреки това, има голяма вероятност някой да поиска да премахнем `null` стойностите чрез настройка на JSON серилизатора.

Липсва стандарт за дата като тип в JSON, което означава, че датите обикновено се представят като текстови стойности (например, в ISO 8601 формат), но това не е част от спецификацията на JSON.
## Processing JSON
За да работим с JSON в .NET, имаме два основни варианта към момента: `System.Text.Json` и Json.NET.

До около 2012 година Microsoft са използвали JavaScript сериализатор и десериализатор за работа с JSON, но той е бил неефективен — бавен, с липса на гъвкавост и с множество бъгове. По това време 20-годишният програмист James Newton-King създава сериализатор и десериализатор, които работят в пъти по-бързо и предлагат значително повече възможности и настройки. Microsoft решават да се откажат от своя сериализатор и препоръчват този на James, като го наемат и на работа.
Json.NET бързо се превръща във фаворит на разработчиците и се разпространява като NuGet пакет. Популярността му нараства толкова бързо, че Microsoft са принудени да пуснат нова версия, за да повишат типа на числото за броя сваляния, тъй като предишният тип вече не е бил достатъчен.

 В един момент Microsoft започват да развиват `System.Text.Json`. Първоначално този проект не е особено успешен, до голяма степен копира API-то на Json.NET и малко хора го ползват. И двата подхода разчитат на reflection за сериализация и десериализация на информацията, но reflection е сравнително бавен.

С напредъка на C# се появяват source генератори, които представляват по-дълбока част от езика. За разлика от reflection, който работи по време на изпълнение (runtime), source генераторите работят по време на компилация (compile time). Reflection се ползва, когато не знаем предварително какви обекти ще обработваме, затова по време на изпълнение се анализират мета данните на обекта и се достъпват неговите пропъртита и методи, което е доста бавно. При source генераторите този анализ се извършва по време на компилация, което значително подобрява производителността.
Microsoft пренаписват `System.Text.Json` изцяло със source генератори, което води до значително подобрение в скоростта и така `System.Text.Json` изпреварва Json.NET.
Към момента е препоръчително да ползваме `System.Text.Json`, ако е възможно.
### `System.Text.Json`
#### Built-in JSON Support
Както всичко останало, така и `System.Text.Json` се разпространява като NuGet пакет. Това е философия, която Microsoft започват да възприемат от .NET Core 1 насам — практически всичко е NuGet пакети, а много малко неща са предварително включени. Обикновено това са основните библиотеки, които се включват в зависимост от използвания темплейт за Visual Studio. В зависимост от типа на приложението, има библиотеки, които са задължително включени, като останалите трябва да се добавят ръчно чрез NuGet пакети. Например, в по-новите версии на .NET (например .NET 5 и .NET 6), библиотеката `System.Text.Json` е част от основната рамка на .NET и се инсталира по подразбиране в `ConsoleApp` темплейта.
За да видим включените библиотеки в .NET проект, трябва да погледнем в `dependencies` секцията на `*.csproj` файла или в `dependencies` раздела в Solution Explorer в Visual Studio, където ще видим framework и `Microsoft.NETCore.App`, които показват включените библиотеки и таргетната рамка на проекта.

`System.Text.Json` поддържа сериализация на обекти и десериализация (parsing) на JSON стрингове.

Използва следните namespaces:

```csharp
using System.Text.Json;
using System.Text.Json.Serialization;
```
#### Serializing JSON
Сериализиране на обект към JSON string:

```csharp
class WeatherForecast
{
	 public DateTime Date { get; set; } = DateTime.Now;
	 public int TemperatureC { get; set; } = 30;
	 public string Summary { get; set; } = "Hot summer day";
}

static void Main()
{
	 WeatherForecast forecast = new WeatherForecast();
	 string weatherInfo = JsonSerializer.Serialize(forecast);
	 Console.WriteLine(weatherInfo);

     // Optionally, we can write the JSON string to a file
     string file = "weather.json"; // Define the file path
     File.WriteAllText(file, weatherInfo); // Write the JSON string to file
}
```
#### Deserializing JSON
Десериализиране на JSON string обратно в обект:

```csharp
static void Main()
{
     // We can read the string from a file
	 string jsonString = File.ReadAllText(file);
	 WeatherForecast forecast =
	   JsonSerializer.Deserialize<WeatherForecast>(jsonString);
}
```
#### `JsonSerializerOptions`
Това е клас, който позволява конфигуриране на процеса на сериализация и десериализация. Ако сериализираме обект, който съдържа пропъртита на кирилица, можем да ползваме пропъртито `Encoder`, за да гарантираме, че текстът ще се изписва коректно. Без тази настройка, текстът се визуализира като Unicode escape кодове (`\uXXXX`), вместо да се показва в човешки четим формат.

Чрез пропъртито `WriteIndented` можем да определим дали сериализираният текст да съдържа интервали и нови редове за по-добра четимост. Ако текстът ще се чете от хора, е препоръчително да се добави. Ако обаче размерът е важен и текстът няма да се чете от хора, по-добре е да не се използва, за да се спести място.

>[!TIP]
>Добра идея е да направим статичен extension клас, който да улесни работата със сериализация и десериализация. Така можем директно да извикваме методи за конвертиране на обекти към JSON и обратно, без излишна повторяемост на кода. Примерен такъв клас има във файла за EF Core в папката с ресурси.
#### Attributes
Атрибутите са много полезни. Например, можем да посочим какво име да има дадено пропърти при сериализация и десериализация. Това ни позволява в C# да ползваме удобни и ясни имена за пропъртита, а към външния свят да подаваме различни наименования, ако е необходимо.

Също така можем да посочим кои пропъртита да бъдат игнорирани по време на сериализация и десериализация:

```csharp
public class User
{
    [JsonPropertyName("user")]
    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
}
```

Допълнително можем да ползваме:

- **`[JsonInclude]`** – Показва, че дадено поле (не само пропърти) трябва да се включи в сериализацията.
- **`[JsonConverter]`** – Позволява персонализирано конвертиране на специфични типове данни.
### JSON.NET
JSON.NET е open source framework за .NET, който предоставя множество функционалности, като основната му употреба е за парсване на JSON данни, както и сериализация и десериализация на обекти в JSON формат.

Той поддържа `LINQ-to-JSON`, което позволява лесно манипулиране на JSON данни чрез LINQ заявки.

JSON.NET също така предлага възможност за конвертиране на XML към JSON и обратно. Въпреки това, този процес не е особено препоръчителен, защото XML съдържа мета информация, която трябва да бъде прехвърлена към JSON, което може да доведе до загуба на структурирани данни, тъй като JSON не поддържа същия начин на представяне на мета информация.

JSON.NET се инсталира като NuGet пакет - **`Newtonsoft.Json`**.
#### Serializing JSON
Сериализиране на обект към JSON string:

```csharp
var jsonProduct = JsonConvert.SerializeObject(product);
```

Ако искаме да добавим идентиране (с цел по-добра четимост), можем да добавим аргумент `Formatting.Indented` при сериализацията.

Пример:

```csharp
JsonConvert.SerializeObject(products, Formatting.Indented);
```

Result:

```json
{
  "pump": {
  "Id": 0,
  "Name": "Oil Pump",
  "Description": null,
  "Cost": 25.0
  },
  "filter": {
  "Id": 0,
  "Name": "Oil Filter",
  "Description": null,
  "Cost": 15.0
 }
} 
```
#### Deserializing JSON
Десериализиране на JSON string обратно в обект:

```csharp
var objProduct = JsonConvert.DeserializeObject<Product>(jsonProduct);
```

Можем да десериализираме JSON стринг към анонимен обект. За тази цел създаваме темплейт, който съдържа същите пропъртита като тези в JSON данните, но без стойности. Този подход се ползва понякога, когато ни трябват само част от пропъртитата в обекта.

Пример:

```csharp
// Incoming JSON
var json = @"{ 'firstName': 'Svetlin',
 'lastName': 'Nakov',
 'jobTitle': 'Technical Trainer' }";

// Template objects
var template = new
{
 FirstName = string.Empty,
 LastName = string.Empty,
 JobTitle = string.Empty
};

var person = JsonConvert.DeserializeAnonymousType(json, template);
```
#### Features
Може да се конфигурират, част от настройките:
- Идентиране на output-а (форматиране с отстъпи).
- Конвертиране на JSON към анонимни типове.
- Контролиране на casing-а и на пропъртитата, които да бъдат парсвани.
- Пропускане на грешки при парсване.
#### Attributes
И в `JSON.NET` имаме атрибути, които се ползват по подобен начин на тези в `System.Text.Json`:

```csharp
public class User
{
  [JsonProperty("user")]
  public string Username { get; set; }
  [JsonIgnore]
  public string Password { get; set; }
}
```

Важно е да отбележим, че `JSON.NET` предоставя и допълнителни опции за контрол върху сериализацията, като:

- **`[JsonConverter]`** – За персонализирани конвертори
- **`[JsonRequired]`** – За изискване на стойност при десериализация
- **`[JsonDefaultValueHandling]`** – За контрол върху стойности по подразбиране
#### Parsing of Objects
По подразбиране `JSON.NET` взема всяко пропърти или поле от класа и го парсва.

Това поведение може да се контролира чрез `ContractResolver`, който ни позволява да зададем конкретна стратегия за именуване на пропъртита при сериализация.

Пример за сериализация със `SnakeCaseNamingStrategy`:

```csharp
DefaultContractResolver contractResolver = 
    new DefaultContractResolver()
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
    };

var serialized = JsonConvert.SerializeObject(person, 
    new JsonSerializerSettings()
    {
        ContractResolver = contractResolver,
        Formatting = Formatting.Indented
    });
```

В този случай всяко пропърти ще бъде преобразувано в `snake_case` (например `FirstName` → `first_name`).

Този подход е особено полезен при работа с външни API-та, които следват различен стил на именуване.

>[!TIP]
>Както и при System.Text.Json, може да си направим статичен extension клас.
#### `LINQ-to-JSON`
`LINQ-to-JSON` е подход за работа с JSON данни, който се базира на класовете от пространството `Newtonsoft.Json.Linq`. Той позволява директна работа с JSON обекти без нужда от предварително дефинирани класове.

С помощта на класа `JObject` можем лесно да:

- Създаваме обекти от JSON стринг
- Четем JSON данни от файл
- Обхождаме JSON структура с `foreach` цикъл

Пример за създаване на `JObject` от JSON стринг:

```csharp
using using System.Text.Json.Nodes;

JObject obj = JObject.Parse(jsonProduct);
```

Пример за четене на JSON данни от файл и обхождане на обектите:

```csharp
using using System.Text.Json.Nodes;;

// Четене на JSON от файл
var people = JObject.Parse(File.ReadAllText(@"c:\people.json"));

// Обхождане на JSON обекта
foreach (JToken person in people)
{
    Console.WriteLine(person["FirstName"]); // Ivan
    Console.WriteLine(person["LastName"]);  // Petrov
}
```

Този подход е особено полезен, когато структурата на JSON данните не е фиксирана или предварително известна.

Можем да използваме LINQ за извличане на данни от `JObject`. Това ни позволява да манипулираме JSON структури по начин, подобен на използването на LINQ за колекции в .NET.

Пример за използване на LINQ-to-JSON в JSON.NET:

```csharp
using Newtonsoft.Json.Linq;

// Creating JObject from JSON string
var json = JObject.Parse(@"{'products': [
   {'name': 'Fruits', 'products': ['apple', 'banana']},
   {'name': 'Vegetables', 'products': ['cucumber']}]}"
);

var products = json["products"]
    .Select(t =>
        string.Format("{0} ({1})",
            t["name"],
            string.Join(", ", t["products"].Select(p => p.ToString()))
        )
    ).ToList();

// Output the result
foreach (var product in products)
{
    Console.WriteLine(product);
}

// Output:
// Fruits (apple, banana)
// Vegetables (cucumber)
```
#### `XML-to-JSON`
Пример:

```csharp
string xml = @"<?xml version=""1.0"" standalone=""no""?>
 <root>
    <person id=""1"">
        <name>Alan</name>
        <url>www.google.com</url>
    </person>
    <person id=""2"">
        <name>Louis</name>
        <url>www.yahoo.com</url>
    </person>
</root>";

XmlDocument doc = new XmlDocument();
doc.LoadXml(xml);
string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);

Console.WriteLine(jsonText);

// Output:
// {
//   "?xml": {
//     "@version": "1.0",
//     "@standalone": "no"
//   },
//   "root": {
//     "person": [
//       {
//         "@id": "1",
//         "name": "Alan",
//         "url": "www.google.com"
//       },
//       {
//         "@id": "2",
//         "name": "Louis",
//         "url": "www.yahoo.com"
//       }
//     ]
//   }
// }
```

- XML мета информацията (например `?xml`) се преобразува в JSON обект, като атрибутите се добавят с `@` пред тях.
- За премахване на мета информацията можем да зададем параметъра `omitRootObject: true` в `SerializeXmlNode`:

```csharp
string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, omitRootObject: true);
```

- Ако XML съдържа празни тагове като `<tag />`, те се преобразуват в `"tag": null`.
- При JSON → XML преобразуване, `@` също указва атрибут в XML структурата.
# Misc
## Browser Wars
Microsoft с Internet Explorer е имала тотална доминация в началото, но след появата на Netscape Navigator нещата се променят. Основната причина е JavaScript, благодарение на който уеб страниците стават по-интерактивни и интересни.

Internet Explorer е браузърът, който често не е следвал стриктно стандартите, а е въвеждал свои собствени решения. Това създавало проблеми за разработчиците, които трябвало да пишат специфичен код, за да осигурят коректно визуализиране в IE. За разлика от него, браузъри като Netscape Navigator (който по-късно става основа за Firefox) се стремят да следват стандартите по-прецизно и също така започват да интерпретират по-гъвкаво грешки в кода.

Например, ако програмист забрави да затвори HTML таг, Internet Explorer в някои случаи се затруднявал с визуализацията, докато други браузъри автоматично поправяли грешката и показвали съдържанието правилно. Това важи и за много други дребни грешки, които програмистите често допускат.

Постепенно хората започват да не харесват Internet Explorer, защото страниците в него често изглеждат "лошо". Истината е, че IE понякога е показвал съдържанието по начин, който не отговаря на стандарта, докато останалите браузъри, които са компенсирали тези грешки, улеснявали работата на разработчиците.

Подобна история се случва и с JSON. Първоначално той е бил строг стандарт със стриктен валидатор. Стандартът на JSON обаче остава сравнително строг и до днес — например двойните кавички около ключове и стрингове все още са задължителни. Въпреки това, по-неформални формати като JSON5 въвеждат по-гъвкави правила, като позволяват единични кавички и пропускане на кавичките при ключове. Това не е промяна в самия JSON стандарт, а по-скоро алтернатива, създадена за удобство при разработката.

Тази еволюция напомня на практиката в Япония, където при изграждането на паркове първоначално не правят пътеки. Вместо това наблюдават откъде хората най-често минават и именно там поставят плочките.
# ChatGPT
## DLLs and NuGet Packages in .NET

In .NET, both core libraries and optional libraries are provided as **DLL files** (Dynamic-Link Libraries).

- **Core DLLs** (e.g., `System.Console.dll`) are **preinstalled** with the .NET runtime and automatically available. They include essential functionality like console I/O, collections, and basic types.
- **Optional DLLs** (e.g., `System.Text.Json.dll`) are delivered through **NuGet packages**. These are added separately when additional functionality is required.

**Key Differences**

- **Core DLLs** are referenced automatically, while **NuGet packages** require explicit installation.
- **Core DLLs** are versioned alongside the .NET runtime, while **NuGet packages** can evolve independently with newer features or fixes.

**Relationship to Source Code**

- Both core DLLs and NuGet packages are compiled from source code.
- The compiler integrates these DLLs during the build process, ensuring their methods and classes are accessible in your application.

In essence, DLLs — whether core or optional — provide reusable functionality, while NuGet packages offer a flexible way to expand your project’s capabilities when needed.

**Analogy**

Think of .NET as a **toolbox**:

- **Core DLLs** (like `System.Console.dll`) are the **essential tools** already included in the toolbox — hammer, screwdriver, etc.
- **NuGet packages** (like `System.Text.Json.dll`) are **specialized tools** that you only add when needed — like a torque wrench or soldering iron.

Both are equally important, but core DLLs are built-in, while NuGet packages are added based on your project's needs.
### .NET Development
When we refer to **new versions of .NET**, we're essentially talking about changes in the **DLLs** that make up the framework. These changes can involve:

- **New DLLs** — Introducing new libraries to provide additional functionality (e.g., `System.Text.Json.dll` in .NET Core 3.0).
- **Updated DLLs** — Enhancing existing libraries with improved performance, security, or new methods.
- **Removed DLLs** — Deprecating outdated libraries or merging their functionality into other DLLs.

For example:

- In **.NET Core**, `System.Web.dll` (from the old .NET Framework) was removed in favor of the modern `Microsoft.AspNetCore.*` libraries.
- With **.NET 5**, many APIs that were previously NuGet packages (like `System.Text.Json`) became part of the default SDK, simplifying integration.

So, when we talk about .NET evolving, it's largely about how its collection of DLLs — both **core** and **optional** — is managed, improved, or restructured.

**The core libraries differ based on the type of application** you are building. The project templates are designed to include only the libraries that are necessary for the type of application you're working on, ensuring that the development process is as efficient as possible. For instance, a console app won’t need the web-related libraries that an ASP.NET Core app would require, and vice versa. This modular approach helps keep projects lightweight and focused on their specific needs.
## Type Inference in C# Generic Methods
In C#, when using a generic method, you can skip specifying the type if the compiler can automatically determine it from the arguments. This is called **type inference**.

**Example**

```csharp
public static void PrintType<T>(T value)
{
    Console.WriteLine($"Type: {typeof(T)}, Value: {value}");
}
```

✅ With explicit type:

```csharp
PrintType<int>(42); // Type: System.Int32, Value: 42
```

✅ With type inference (simpler):

```csharp
PrintType(42); // Type: System.Int32, Value: 42
```

If the compiler can't determine the type (e.g., `default` without context), you'll need to specify it explicitly.
# Bookmarks
Completion: 10.03.2025