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
### Built-in JSON Support
Както всичко останало, така и `System.Text.Json` се разпространява като NuGet пакет. Това е философия, която Microsoft започват да възприемат от .NET Core 1 насам — практически всичко е NuGet пакети, а много малко неща са предварително включени. Обикновено това са основните библиотеки, които се включват в зависимост от използвания темплейт за Visual Studio. В зависимост от типа на приложението, има библиотеки, които са задължително включени, като останалите трябва да се добавят ръчно чрез NuGet пакети. Например, в по-новите версии на .NET (например .NET 5 и .NET 6), библиотеката `System.Text.Json` е част от основната рамка на .NET и се инсталира по подразбиране в `ConsoleApp` темплейта.
За да видим включените библиотеки в .NET проект, трябва да погледнем в `dependencies` секцията на `*.csproj` файла или в `dependencies` раздела в Solution Explorer в Visual Studio, където ще видим framework и `Microsoft.NETCore.App`, които показват включените библиотеки и таргетната рамка на проекта.

`System.Text.Json` поддържа сериализация на обекти и десериализация (parsing) на JSON стрингове.

Използва следните namespaces:

```csharp
using System.Text.Json;
using System.Text.Json.Serialization;
```
### Serializing JSON
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
	 
	 File.WriteAllText(file, weatherInfo); // Write the JSON string to file
}
```
### Deserializing JSON
Десериализиране на JSON string към обект, като може да прочетем стринга и от файл:

```csharp
static void Main()
{
	 string jsonString = File.ReadAllText(file);
	 WeatherForecast forecast =
	   JsonSerializer.Deserialize<WeatherForecast>(jsonString);
}
```
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
# Bookmarks
Completion: 09.03.2025