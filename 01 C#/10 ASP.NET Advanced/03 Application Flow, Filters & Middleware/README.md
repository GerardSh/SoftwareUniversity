# General
## Application Flow
### Application Fundamentals
Уеб приложенията обработват заявки и произвеждат отговори.

Целият процес е естествено подреден в някакъв вид тръбопровод (pipeline). Pipeline-ът може да бъде модифициран – започва със заявка (request) и завършва с отговор (response). Самият тръбопровод има кранчета, от които започват разклонения. Ако решим, можем да отворим дадено кранче и да минем през неговото разклонение, което обикновено се връща обратно някъде в тръбопровода. 
В ASP.NET Core **application flow-ът** се реализира чрез **middleware pipeline**, който можем да си представим като тръбопровод. Microsoft са се погрижили да ни дадат **"кранчета"** (middleware hooks), които можем да „отвъртим“, за да прехванем заявката на точно определено място.

След като „отвъртим кранчето“ (т.е. добавим собствен middleware), **отговорността е наша** да:

- направим каквото трябва със „заявката“ (водата).
- евентуално я пренасочим.
- и най-важното – **да извикаме `next()`**, за да може заявката да продължи по останалата част от тръбата.

Ако не извикаме `next()`, водата просто остава в нашето разклонение и не стига до финала (няма отговор към клиента). Образът с водата и тръбите е полезен за разбиране как работи middleware архитектурата в ASP.NET Core. 

В повечето случаи процесът може да бъде разширяван и променян.

Уеб приложенията имат различни среди за разгръщане. В зависимост от това къде се намираме – дали разработваме локално, тестваме на staging сървър или вече сме в продукция – може да искаме приложението ни да се държи по различен начин.
Това означава, че не просто можем да контролираме "кранчетата" в тръбопровода, а можем да ги настройваме по различен начин според контекста, в който работим.
Можем да конфигурираме приложението така, че в една среда да логваме подробно всичко, да показваме грешки и диагностика, а в друга – да сме максимално пестеливи и сигурни.
Механизмът, чрез който приложението разбира в какъв контекст се намира, се нарича **среда** (_environment_).
Средата е изключително важна част от конструкцията на ASP.NET Core, защото върху нея лежи поведението на много компоненти – конфигурация, логване, изключения, сигурност и други

Средите в 99% от случаите засягат pipeline-a.

Уеб приложенията имат начална конфигурация.

Настройват се хост, сигурност, директории, конвенции и други.
### MVC Request Lifecycle
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250518142916.png)

Имаме заявка, която тръгва по pipeline-а. Първото нещо, през което минава, е Middleware – зеленото квадратче от схемата. Това не е един конкретен middleware, а по-скоро **placeholder за множество middlewares**, които може да сме регистрирали.

След това заявката стига до **Routing-а**, който определя кой е контролерът и кой е съответният action. Самият routing също е middleware и трябва да се намира на строго определено място в pipeline-а. След него можем да имаме и други middleware-и.

Когато се определи правилният път, **се вдига съответният контролер и action**, и се преминава през филтрите в Action Execution.

Преди да се случи **Model Binding**, първо се изпълнява **Authorization филтърът**, който проверява дали потребителят има права за достъп. След него идва **Resource филтърът**.

След това се изпълнява самият **action метод**, и накрая минаваме през **Result Execution**, където филтрите действат в обратен ред.

Когато резултатът е готов (независимо дали е View, JSON или нещо друго), **View Engine-ът** или съответният механизъм **рендерира отговора и го връща към клиента**.

Това е стандартният път, но имаме възможност **да съкратим процеса още в началото**, като напишем собствен middleware, който директно връща отговор.

Много често точно така работи **caching middleware-ът** – ако намерим отговора в кеша, **няма нужда** да минаваме през рутиране, контролери, филтри и т.н.

Всяка част от веригата е точка, в която можем да се "вмъкнем" и при нужда да върнем отговор веднага, без да продължаваме по целия pipeline.
### Controller Context
Контролерът е един от основните компоненти в потока на заявката (Request pipeline), който управлява целия процес.

Всеки контролер има собствено пропърти **`ControllerContext`**.

`ControllerContext` съдържа набор от полезни пропъртита, които предоставят информация за текущата заявка.

В `ControllerContext` можем да достъпим следните пропъртита:

`ActionDescriptor` – предоставя информация за текущия action, включително атрибути, параметри и мета-данни.

`HttpContext` – съдържа цялостния контекст на HTTP заявката, включително `Request` и `Response`.

`ModelState` – съхранява информация за резултата от опитите за обвързване (binding) на данни и валидирането им; тук можем да проверим дали входните данни са валидни.

`RouteData` – съдържа информация, извлечена от маршрута, като параметри от URL адреса и съответния маршрут, по който е минала заявката.

`ValueProviderFactories` – списък с фабрики, които доставят стойности за обвързване към параметрите на action метода (напр. от формуляри, query string, route и т.н.).
### Application Fundamentals
В ASP.NET Core използваме класа `Program.cs`, за да направим следното:

Конфигурираме HTTP request pipeline-а. Променяйки типа на проекта като примерно дали е individual accounts или е някакъв друг, това ще промени pipeline-a.

Определяме поведение за различни среди.

Основни концепции на приложението (Application Fundamentals):

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseMvcWithDefaultRoute();
```

Ако не сме в среда за разработка, настройваме централизирано обработване на грешки и използваме HTTP Strict Transport Security.

Пренасочваме HTTP заявките към HTTPS.

Позволяваме обслужване на статични файлове.

Прилагаме политика за бисквитки.

Регистрираме MVC с подразбиращ се маршрут.
### Application Environments
Деплоймънтът на софтуера обикновено се разпределя в няколко различни среди.

Многоетапният (multi-stage) деплоймънт е **задължителен** при enterprise приложения.

Всяка среда представлява компютърна система (виртуална или физическа), върху която пускаме нашия софтуер.

Повечето архитектури използват следните среди:

**Dev / Development**  – Средата, в която разработваме програмата или компонента.

**Test / Testing**  – Средата, в която тестваме и валидираме продукта (или компонента) като разработчици.

**Stage / Staging**  – Средата, в която клиентът проверява дали продуктът отговаря на неговите очаквания.

**Production**  – Средата, в която продуктът е официално достъпен за всички потребители.

ASP.NET Core конфигурира поведението на приложението според средата, в която се изпълнява.

Поддържа три основни среди – Development, Staging и Production. Staging обединява Test и Stage средите.

Чете променливата на средата с името `"ASPNETCORE_ENVIRONMENT"`.

Стойността на тази променлива се съхранява в свойството `EnvironmentName` на обекта `Environment`, който е част от `WebApplication`, върнат от метода `Build()` на `WebApplicationBuilder`.

Можем да зададем средата на произволна стойност. По подразбиране средата е Production.

```csharp
if(app.Environment.IsDevelopment()) // TODO: Do Development
if(app.Environment.IsStaging()) // TODO: Do Staging
if(app.Environment.IsProduction()) // TODO: Do Production
if(app.Environment.IsEnvironment("some_environment")) // TODO: Do Something
```

Не сме ограничени само до средите, които Microsoft е дефинирала по подразбиране.
Можем свободно да сменим стойността на `"ASPNETCORE_ENVIRONMENT"` с такава, каквато ни е необходима.
След това можем да използваме метода `IsEnvironment`, за да проверим дали текущата стойност съвпада с тази, която сме задали.
Ако съвпада, методът ще върне `true` и ще можем да вземем решения в кода в зависимост от конкретната стойност на средата.
### Application Configuration
Конфигурацията на приложението в ASP.NET Core е базирана на двойки ключ-стойност.

Конфигурациите на приложението се задават чрез конфигурационни доставчици (configuration providers).

Конфигурационните доставчици четат данни от конфигурационни източници.

Тези източници могат да бъдат Azure Key Vault или аргументи от командния ред.

Могат да бъдат и потребителски доставчици – инсталирани или създадени от нас.

Също така се използват файлове от директории, променливи на средата и други.

Един от източниците по подразбиране е файлът `appsettings.json`.

Можем да ползваме няколко конфигурационни провайдъра едновременно (например `appsettings.json`, environment variables, Azure Key Vault и други). Всички те се обединяват в общ конфигурационен store, който работи като речник от тип `Dictionary<string, string>`.

Може да конфигурираме някои провайдъри (като `appsettings.json`) да наблюдават за промени във файловете и **автоматично да презареждат настройките**, без нужда от рестартиране на приложението. Това става чрез `reloadOnChange: true`.

Пример:

```csharp
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
```

Файлът `launchSettings.json` се намира в папката `Properties` и се използва за конфигуриране на начина, по който приложението се стартира по време на разработка. Той задава профили, портове, URL-и и среда (например чрез променливата `ASPNETCORE_ENVIRONMENT`), която определя текущата среда (напр. Development). Въпреки това, `launchSettings.json` **не участва в основната конфигурация (`builder.Configuration`)** и се използва само при локално стартиране, като не се чете от приложението при runtime.
При стартиране на приложението чрез Visual Studio или `dotnet run` се избира един от профилите, дефинирани в `launchSettings.json`. Само конфигурацията на избрания профил се зарежда и прилага за текущата сесия на стартиране. Това означава, че ако изберем профила `IIS Express`, приложението ще стартира с настройките, описани само в този профил, а останалите профили ще бъдат игнорирани за тази сесия. По този начин можем да имаме различни конфигурации за различни сценарии на стартиране, като например локален IIS Express, HTTP или HTTPS, без те да се прилагат едновременно.

Конфигурацията на приложението се чете при стартиране от различни провайдъри.

Всички конфигурационни стойности се съхраняват и достъпват чрез интерфейса `IConfiguration`.

`IConfiguration` е регистриран в DI контейнера по подразбиране и може да се инжектира в контролери или други услуги.

Например, ако имаме в `appsettings.json`:

```json
{
  "Greeting": "Hello!",
  "Config": {
    "Secret": "Can’t touch this"
  }
}
```

в контролера можем да получим стойността така:

```csharp
public class HomeController : Controller
{
    private readonly IConfiguration config;
    
    public HomeController(IConfiguration config)
    {
        this.config = config;
    }
    
    public IActionResult Config()
    {
        return Content(this.config["Greeting"] + " " + this.config["Config:Secret"]); // returns "Hello! Can’t touch this"
    }
}
```

Можем да достъпим конфигурация по два начина: с `configuration["Key"]`, който връща винаги `string?`, и с `configuration.GetValue<T>("Key")`, който връща стойността като даден тип (напр. `int`, `bool`) и позволява задаване на стойност по подразбиране. Вторият вариант е по-гъвкав и безопасен при нужда от типизирани данни.

Всички конфигурационни стойности, се обединяват във вътрешен конфигурационен речник от тип `IConfiguration`, който използва ключове от тип `string`. Когато имаме вложени обекти, достъпваме техните пропъртита с помощта на двоеточие (`:`) като разделител между нивата. Пример:

```json
{
  "ConnectionStrings": {
    "SQLServer": "Server=.;Database=MyDb;Trusted_Connection=True;"
  }
}
```

Можем да достъпим стойността със:

```csharp
config["ConnectionStrings:SQLServer"]
```

Това поведение е еднакво независимо дали стойността идва от JSON файл, XML файл, environment променлива или друг provider. Това позволява консистентен достъп до конфигурационни данни чрез ключове с двоеточие (`:`), които описват пътя до вложените стойности.

Когато извикаме `WebApplicationBuilder builder = WebApplication.CreateBuilder(args)`, се създава обект, който по подразбиране зарежда пълната конфигурация на приложението. В него са налични основни компоненти като `Services`, `Configuration`, `Environment`, `Logging` и други. Чрез свойството `builder.Configuration` имаме достъп до всички конфигурационни стойности и можем лесно да ги използваме за настройване на приложението или за извличане на конкретни данни, като например връзки към бази данни, ключове и други.
### Application Services Configuration
Конфигурацията на услугите обикновено се извършва в `Program.cs`, преди приложението да бъде изградено чрез `WebApplicationBuilder`. Услугите се добавят към DI контейнера чрез `builder.Services`, което позволява те да бъдат инжектирани в контролери и други компоненти. Има три основни типа живот на услугите:

- `AddTransient` – създава нова инстанция при всяка заявка.

- `AddScoped` – една и съща инстанция се използва в рамките на дадена HTTP заявка.

- `AddSingleton` – една и съща инстанция се използва през целия живот на приложението.

Услугите могат да се конфигурират по различен начин за внедряване чрез Dependency Injection (DI), в зависимост от това какъв lifetime желаем:

```csharp
// Transient objects are always different
// A new instance is provided to every controller and service
builder.Services.AddTransient<DataService>();

// Scoped objects are the same within a request
// They are different across different requests
builder.Services.AddScoped(typeof(DataService));

// Singleton objects are the same for every object and request.
builder.Services.AddSingleton<DataService>();
```

Ако не сме сигурни какъв да бъде lifecycle-ът на услугата ни – ползваме `Scoped`.

Всеки входящ HTTP request автоматично създава нов `IServiceScope`. Това означава, че рамките на един HTTP request представляват един _scope_ — независимо дали услугата е `Scoped`, `Transient` или `Singleton`, системата третира заявката като самостоятелен обхват (scope), в който се resolve-ват зависимостите. След края на заявката този scope се унищожава.

Това е мястото, където конфигурираме всички услуги за приложението чрез `builder.Services`. Microsoft предоставят **extension методи**, които обединяват всички нужни стъпки за конфигуриране на даден сървис — например `AddControllers()`, `AddDbContext()` и т.н. Ние също можем да създаваме такива методи, които започват с `Add`, и така правим конфигурацията по-чиста и лесна за повторна употреба.

Пример:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Register services here
builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddTransient<IMyService, MyService>();

// We can also use our own extension method
builder.Services.AddMyCustomServices();

var app = builder.Build();
```

Собствен Extension Метод (препоръчително за по-добър код и повторна употреба):

```csharp
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IMyService, MyService>();
        services.AddScoped<IOtherService, OtherService>();
        return services;
    }
}
```

В `Program.cs` просто извикваме:

```csharp
builder.Services.AddMyCustomServices();
```

Можем да добавим и конфигурация в този extension метод, като например да приемаме `IConfiguration` като параметър и да я използваме, за да конфигурираме услугите динамично според настройките в `appsettings.json` или други източници:

```csharp
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Get a setting from the configuration
        var mySetting = configuration.GetValue<string>("MySettings:SomeKey");

        // We can use this setting when configuring a service
        services.AddTransient<IMyService>(provider => new MyService(mySetting));

        services.AddScoped<IOtherService, OtherService>();

        return services;
    }
}
```

В `Program.cs` го използваме така:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMyCustomServices(builder.Configuration);

var app = builder.Build();
```

По този начин разширяваме услугите си и използваме конфигурацията за по-гъвкаво задаване на параметри.
## Diagnostics & Custom Error Handlers
### Error Handling
В ASP.NET Core има няколко подхода за конфигуриране на обработката на грешки:

- **Developer Exception Page** показва детайлна информация за грешките по време на разработка, като stack trace и източника на грешката. Трябва задължително да се изключва в продукционна среда, защото съдържа чувствителна информация, която може да бъде използвана от злонамерени потребители.

Пример как можем да добавим `DeveloperExceptionPage` само ако приложението е в среда на разработка:

```csharp
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // In production environment, we show a more general error page
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
```

Така гарантираме, че чувствителна информация за грешки се показва само в среда за разработка (Development), докато в Production потребителят вижда безопасно, обобщено съобщение. В Production среда използваме алтернативен `ExceptionHandler`, който може да пренасочва към Razor страница или конкретен Action в контролер. По подразбиране ASP.NET Core генерира уникален `TraceIdentifier` за всяка HTTP заявка. Това `TraceId` можем да достъпим чрез `HttpContext.TraceIdentifier` и да го логнем или покажем на потребителя в Error страница.

Така потребителят може да съобщи идентификатора, а ние да го използваме в логовете (напр. със `Serilog` или Application Insights), за да проследим конкретната грешка.
Добра практика е да логваме както `TraceId`, така и самата изключение (`Exception`) чрез `_logger.LogError(ex, "...")`, за да имаме пълна информация при анализ.  
Това ни позволява лесно да филтрираме логове по `TraceId` и да открием точната заявка и грешка, дори в натоварени среди.

Пример:

```csharp
app.UseExceptionHandler("/Home/Error");

public IActionResult Error()
{
    var traceId = HttpContext.TraceIdentifier;
    _logger.LogError($"Unhandled error occurred. Trace ID: {traceId}");
    return View(new ErrorViewModel { RequestId = traceId });
}
```

```html
<!-- Error.cshtml -->
<p>Request ID: @Model.RequestId</p>
```

Примерно съобщение към потребителя:  
_„Моля, изпратете този код: abc123, за да можем да проследим проблема.“_

- **Exception Handler Middleware** – глобален обработчик на изключения за production среда.

- **Status Code Pages** – позволява показване на потребителски страници за различни HTTP статус кодове (напр. 404, 500).

- **Exception Filters (в MVC)** – предоставят начин за улавяне на грешки на ниво контролер или действие.

- **`ModelState` Validation** – автоматично проверява дали входните данни отговарят на очакванията и генерира грешки при невалидни модели.
### Status Code Pages
ASP.NET Core приложенията не предоставят богати страници за статус кодове.

За да предоставим такива, трябва да използваме middleware компонента **Status Code Pages**.

`app.UseStatusCodePages();`

Middleware-ът може лесно да бъде персонализиран.

Поддържа няколко разширяващи метода. Например:

```csharp
app.UseStatusCodePagesWithRedirects("/error/{0}");
// Redirects the user to a custom error page based on the status code.
```

```csharp
app.UseStatusCodePagesWithReExecute("/error?code={0}");
// Re-executes the request pipeline with a modified path for the error page.
```

Важно е да направим разлика между `UseStatusCodePagesWithRedirects` и `UseStatusCodePagesWithReExecute`, защото макар и двете да водят до страница за грешка, начинът по който се случва това има значение за правилното отразяване на статус кода.
При `UseStatusCodePagesWithRedirects`, клиентът получава HTTP статус 302 (Redirect), след което следва нова заявка, която връща статус 200. Това означава, че в **Network** таба на браузъра няма да видим оригиналния статус код на грешката, като например 404 — виждаме само 302 и 200.
От друга страна, `UseStatusCodePagesWithReExecute` преизпълнява заявката вътрешно на сървъра, без да прави външен redirect. Така крайният отговор към клиента запазва оригиналния статус код на грешката, например 404, което е правилното поведение и по-адекватно за дебъгване, логване и SEO. Поради това е желателно винаги да ползваме `UseStatusCodePagesWithReExecute`.
## Middleware
Middleware е софтуерен компонент, който се сглобява във веригата на изпълнение на дадено приложение. Той отговаря на „кранчетата“ в нашия pipeline.

Всеки компонент:

Обработва заявки и отговори.

Избира дали да предаде заявката към следващия компонент във веригата.

Може да извърши работа преди или след като бъде извикан следващият компонент във веригата.

В ASP.NET Core, request делегатите изграждат веригата за обработка на заявки.

Когато дойде дадена заявка, тя минава през всички middleware компоненти два пъти — веднъж като **request**, преди да се обработи, и веднъж като **response**, когато отговорът се връща към клиента.
Можем да обработим определени неща при първото минаване (например логване на заявката) и други при второто (например модифициране на отговора).
За да не се прекъсне pipeline-ът, се вика методът `next()`, който извиква следващия middleware:

```csharp
app.Use(async (context, next) =>
{
    // Code before next() — runs during the request phase

    await next();

    // Code after next() — runs during the response phase
});
```

Ако някой middleware не извика `next()`, тогава изпълнението на pipeline-а спира дотам и отговорът се връща директно към клиента. Това означава, че нито един от следващите middleware-и няма да бъде извикан, нито ще се изпълнят действията, които са написани _след_ `await next()` в предходните компоненти.

Изграждането на pipeline-a започва след извикването на `WebApplication app = builder.Build();`. До този момент конфигурираме IoC контейнера и регистрираме нужните services.
### Request Delegates
Request делегатите обработват всяка HTTP заявка и се конфигурират чрез разширяващите методи `Run()`, `Map()` и `Use()`.

Request делегатите (наричани още middleware компоненти) могат да бъдат:

- Определени директно като анонимни методи (inline middleware).

- Дефинирани в преизползваем клас.

Всеки middleware компонент трябва:

- Да извика следващия компонент във веригата или да прекъсне изпълнението на pipeline-а.

```csharp
app.Use(async (context, next) =>
{
    // Logic before passing to the next middleware

    await next();

    // Logic after the next middleware has completed
});
```

Методът `Use()` се използва, за да свържем няколко делегата последователно. Той може да прекъсне pipeline-а, ако не извика `next()`.

Първият `Run()` делегат прекратява pipeline-а.

- `Run()` е по-скоро конвенция — някои middleware-и предоставят методи от типа `Run{Middleware}`, които се изпълняват в края на веригата.

Методът `Map()` се използва за разклоняване на pipeline-а.

```csharp
app.Map("/admin", adminApp =>
{
    adminApp.Run(async context =>
    {
        await context.Response.WriteAsync("Admin section");
    });
});
```

- Request pipeline-ът се разклонява според зададения път в заявката.

`Use()`, `Run()` и `Map()` се използват за изграждане на т.нар. **request pipeline** – това е последователността от middleware компоненти, които обработват всяка HTTP заявка.

**`Use()`**

`Use()` добавя middleware, който може да извърши действия **преди и/или след** останалите компоненти в pipeline-а. Той приема делегат с параметър `next`, който да извика следващия компонент. Ако не го извика, изпълнението се прекъсва. Най-често се използва, когато искаме да добавим логика, която да се изпълнява за всички заявки – например логване, проверка за автентикация и т.н.

**`Map()`**

`Map()` създава **разклонение** на pipeline-а – тоест определена логика ще се изпълнява само ако заявката съвпада с даден път (URL сегмент). Така можем да изградим различни „под-pipeline-и“ за различни пътища – например `/admin`, `/api`, и т.н. Вътре в `Map()` използваме отново `Use()` или `Run()`.

**`Run()`**

`Run()` се използва за добавяне на **краен middleware**. Той не приема `next`, тоест **не предава заявката нататък**. Обикновено го използваме в края на pipeline-а, когато искаме да изпратим финален отговор на клиента. След `Run()` нищо друго няма да се изпълни.
### Creating Your Own Middleware (Inline)
ASP.NET Core Request Pipeline представлява последователност от _Request Delegates_, които се извикват един след друг.

Ние създаваме свои собствени _Request Delegates_ чрез обекта `IApplicationBuilder`.

```csharp
app.Use(async (context, next) =>
{
    // Do work that doesn't write to the Response.
    
    await next();
    
    // Do logging or other work that doesn't write to the Response.
});

//Other code below...
```

Това е пример за създаване на собствен middleware inline – тоест директно в кода, без отделен клас.

След този middleware може да има и друг код, който ще се изпълни, ако `await next()` бъде извикан.

Не трябва да пишем по response-a защото всяка промяна ще доведе до short-circuit.
### Creating Your Own Middleware (Class)
Request delegates могат също да бъдат дефинирани като класове.

Създаване на собствен Middleware (клас):

```csharp
public class CustomMiddleware
{
    // The next delegate in the pipeline
    private readonly RequestDelegate next;

    public CustomMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    // IMyService is injected into InvokeAsync through DI
    public async Task InvokeAsync(HttpContext httpContext, IMyService svc) 
    {
        svc.MyProperty = 1000;
        await this.next(httpContext);
    }
}
```

Когато създаваме middleware като клас, ние го правим по-организирано и подходящо за повторна употреба. Можем също така лесно да инжектираме зависимости директно в метода `InvokeAsync`. Това позволява да включим логика или поведение, което може да се използва в различни приложения или сценарии.

За да използваме собствен Middleware клас, трябва да го включим в pipeline-а.

```csharp
public static class CustomMiddlewareExtensions
{
    public static IApplicationBuilder UseCustom(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }
}
```

След това ние добавяме middleware-а в pipeline-а с:

```csharp
app.UseCustom();
```

Така нашият middleware се регистрира и ще бъде извикан за всяка заявка, минаваща през приложението.

С този метод разширяваме интерфейса `IApplicationBuilder`, за да можем удобно да добавим нашия `CustomMiddleware` в pipeline-а с просто извикване на `app.UseCustom()`.

Така правим регистрацията на middleware-а по-четлива и удобна, вместо да пишем директно `app.UseMiddleware<CustomMiddleware>()` навсякъде.
### Built-in Middleware
Някои от вградените middlewares в ASP.NET Core са:

| **Middleware Category** | **Middleware Usage**                |
| ----------------------- | ----------------------------------- |
| Authentication          | `app.UseAuthentication()`           |
| Cookie Policy           | `app.UseCookiePolicy()`             |
| CORS                    | `app.UseCors()`                     |
| Diagnostics             | `app.UseDevelopmentExceptionPage()` |
|                         | `app.UseExceptionHandler(...)`      |
|                         | `app.UseStatusCodePages()`          |
| HTTPS Redirection       | `app.UseHttpsRedirection()`         |
| HSTS                    | `app.UseHsts()`                     |
| Static Files            | `app.UseStaticFiles()`              |
| Response Caching        | `app.UseResponseCaching()`          |
| Response Compression    | `app.UseResponseCompression()`      |
| Request Localization    | `app.UseRequestLocalization(...)`   |
| Routing                 | `app.UseRouter(...)`                |
| Session                 | `app.UseSession()`                  |
| URL Rewriting           | `app.UseRewriter(...)`              |
| WebSockets              | `app.UseWebSockets(...)`            |
| Others                  | `app.UseWelcomePage()`              |

Много други middleware компоненти са достъпни чрез NuGet пакети.
## Filters
Филтрите позволяват да изпълним код преди или след определени етапи от pipeline-а за обработка на заявката.

Филтрите са подобни, но не са същите като Middleware.

Middleware работят на нивото на ASP.NET Core.

Филтрите работят само на нивото на MVC.

Когато build-нем приложението, към pipeline-а автоматично се добавя скрит компонент преди извикването на `Run()`. Това е т.нар. **MVC Action Invocation Pipeline (Filter Pipeline)**. Той е част от общия middleware pipeline, но се появява, защото предварително сме регистрирали `builder.Services.AddControllersWithViews()`.

Този компонент не го виждаме директно – конфигурирането му става при самата регистрация на услугата, чрез lambda израз, където подаваме филтри през `options.Filters.Add()`. Там се добавя съответният филтър, който ще бъде закачен в подходящия етап от изпълнението на Filter Pipeline-а.

Следната схема представлява **MVC Action Invocation Pipeline** – в този момент заявката вече е преминала през всички останали middleware-и, а отговорът след това се връща обратно през тях:

Това е схемата MVC Action Invocation Pipeline, в която request-а вече е преминал през всичките middlewares, а отговора се връща обратно към тях:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250522123728.png)

Използвайки различните типове филтри, можем да определим точно в кой момент от изпълнението да се включим. Когато подадем филтър в `builder.Services.AddControllersWithViews()`, ASP.NET Core знае къде да го постави, като разпознае неговия тип.

**Пример:**

```csharp
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new MyCustomActionFilter());
});

public class MyCustomActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Този код се изпълнява ПРЕДИ самия Action метод
        Console.WriteLine("Before executing action");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Този код се изпълнява СЛЕД като се изпълни Action методът
        Console.WriteLine("After executing action");
    }
}
```

- `AddControllersWithViews()` регистрира всички необходими услуги за използване на MVC контролери и Razor изгледи.
- С `options.Filters.Add(...)` добавяме филтър, който ще се прилага глобално за всички контролери и действия.
- `MyCustomActionFilter` е клас, който имплементира `IActionFilter`, и се вмъква автоматично в **Filter Pipeline**.

Има няколко типа филтри.

Всеки се изпълнява на различен етап от Filter pipeline-а.

Съществуват Authorization, Resource, Action, Exception и Result филтри.

| **Filter**        | **Description**                                                                                   |
| ----------------- | ------------------------------------------------------------------------------------------------- |
| **Authorization** | Runs first. Determines if the client is authorized to access the requested functionality.         |
| **Resource**      | Runs immediately after authorization. Can execute code before and after the rest of the pipeline. |
| **Action**        | Runs immediately before and after an individual action method is invoked.                         |
| **Exception**     | Used to apply global policies for unhandled errors that occur.                                    |
| **Result**        | Runs immediately before and after the execution of individual action results.                     |
### Implementing Custom Filters
ASP.NET Core MVC филтрите могат да бъдат както синхронни, така и асинхронни.

**Synchronous:**

```csharp
public class SampleActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Executed BEFORE the action method
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Executed AFTER the action method
    }
}
```

**Asynchronous:**

```csharp
public class SampleAsyncActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        // Executed BEFORE the action method
        var resultContext = await next(); // Invokes the action method
        // Executed AFTER the action method
        // resultContext.Result contains the action result
    }
}
```

[Filters in ASP.NET Core | Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-9.0)
### Adding Filters to the Pipeline (Global)
Филтрите се добавят глобално в `MvcOptions.Filters` и ще бъдат приложени към всички контролери и действия.

```csharp
builder.Services.AddMvc(options => {
    options.Filters.Add(new SampleActionFilter());   // instant
    options.Filters.Add(typeof(SampleActionFilter)); // by type
});
```
### Filter Attributes
ASP.NET Core поддържа **вградени филтри на базата на атрибути**, които може да използваме за добавяне на поведение към контролери и действия.

Не само че можем да се включим на всяко едно място в MVC Action Invocation Pipeline-а чрез съответния тип филтър (Authorization, Resource, Action, Result, Exception), но чрез **атрибутите** можем и да контролираме **кога** и **при кои действия или контролери** това да се случи.

Например, **атрибутът `[Authorize]`** е именно такъв филтър – **Authorization Filter**, който указва, че дадено действие или контролер изисква потребителят да бъде оторизиран. Ако не добавим този атрибут, филтърът не се изпълнява за съответния ресурс, дори да е регистриран глобално.

Пример: Създаване на филтър чрез атрибут

```csharp
public class AddHeaderAttribute : ResultFilterAttribute
{
    private readonly string name;
    private readonly string value;

    public AddHeaderAttribute(string name, string value)
    {
        this.name = name;
        this.value = value;
    }

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.Headers.Add(this.name, new[] { this.value });
        base.OnResultExecuting(context);
    }
}
```

**Употреба:**

```csharp
[AddHeader("Author", "Steve Smith @ardalis")]
public class SampleController : Controller
{
    public IActionResult Index()
    {
        return Content("Examine the headers using developer tools.");
    }

    public IActionResult Test()
    {
        return Content("Header will be present here too.");
    }
}
```

**Обяснение:**

- Атрибутите като `AddHeaderAttribute` са специални филтри, които:

    - Могат да се поставят върху контролери или методи.

    - Приемат аргументи (в конструктора).

    - Модифицират изпълнението — в този случай, добавят HTTP header.

- В примера горе, всеки отговор от `SampleController` ще включва HTTP header:

```
Author: Steve Smith @ardalis
```

Това е особено полезно за **кеширане, сигурност, логване** и други cross-cutting функционалности на ниво контролер/екшън.

Няколко от интерфейсите за филтри имат съответстващи атрибути.

Можем да ги използваме като базови класове за създаване на собствени имплементации.

Filter атрибути:

`ActionFilterAttribute`  
Имплементира `IActionFilter` или `IAsyncActionFilter`. Използва се за създаване на филтри, които се изпълняват преди и след дадено Action.

`ExceptionFilterAttribute`  
Имплементира `IExceptionFilter` или `IAsyncExceptionFilter`. Позволява ни да обработваме глобално изключения, възникнали по време на изпълнение на Action.

`ResultFilterAttribute`  
Имплементира `IResultFilter` или `IAsyncResultFilter`. Изпълнява се преди и след изпълнение на Action резултата (например ViewResult).

`FormatFilterAttribute`  
Имплементира `IResourceFilter`. Използва се за избор на изходен формат, базиран на данни от маршрута или заявката.

`ServiceFilterAttribute`  
Използва DI контейнера и интернално създава филтър, който имплементира съответния интерфейс (например `IActionFilter`).

`TypeFilterAttribute`  
Създава филтър по подаден тип и може да работи с всеки клас, който имплементира някой от Filter интерфейсите (например `IAuthorizationFilter`, `IResultFilter`, и т.н.).

`AuthorizeAttribute`  
Имплементира `IAuthorizationFilter`. Използва се за контрол на достъпа преди изпълнението на Action.
### Life cycle
| Етап                                     | Описание                                                                                                        |
| ---------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| **Request**                              | Началото на заявката                                                                                            |
| **Authorization Filters**                | Проверяват дали потребителят има права да достъпи ресурса (`IAuthorizationFilter`)                              |
| **Resource Filters (OnActionExecuting)** | Стартират се преди останалите етапи. Могат да кратко-циркулират заявката (`IResourceFilter`)                    |
| **Action Filters (OnActionExecuting)**   | Изпълняват се непосредствено преди Action метода (`IActionFilter`)                                              |
| **Action Execution**                     | Тук се изпълнява самият Action метод                                                                            |
| **Model Binding & Exception Filter**     | Извършва се обвързване на входните данни към модела и евентуално обработване на изключения (`IExceptionFilter`) |
| **Result Filter**                        | Манипулират или наблюдават резултата от Action метода (`IResultFilter`)                                         |
| **Action Filters (OnActionExecuted)**    | Изпълняват се непосредствено след Action метода (`IActionFilter`)                                               |
| **Resource Filters (OnActionExecuted)**  | Последни стъпки от `IResourceFilter` преди отговора                                                             |
| **Response**                             | Изпращане на отговора обратно към клиента                                                                       |
### Filter Dependency Injection
Не можем да използваме Dependency Injection в конструктора на филтър, който е атрибут, защото атрибутите в .NET изискват параметрите им да бъдат константи, стойности от enum или други компилаторно допустими стойности. Това е ограничение на самия .NET атрибутен механизъм, не само на ASP.NET Core. Затова не можем директно да подаваме услуги от DI контейнера като параметри в конструктора на атрибута.

Филтрите, които са имплементирани като атрибути, се добавят директно към контролерите или към техните методи.

Не можем да подаваме зависимости чрез Dependency Injection в техния конструктор.

Ако има параметри, те трябва да бъдат зададени директно на мястото, където прилагаме атрибута.

Това е ограничение, произтичащо от начина, по който работят атрибутите като филтри.

Има няколко подхода, чрез които все пак можем да включим Dependency Injection във филтри, дефинирани като атрибути.

`ServiceFilterAttribute` се използва, когато филтърът е регистриран като услуга в DI контейнера. При използването му се извлича инстанция на филтъра директно от DI.

`TypeFilterAttribute` е подобен, но не използва DI контейнера директно. Вместо това типът се инстанцира чрез `ObjectFactory`. 

Съществуват начини да контролираме повторната употреба на инстанциите, но няма гаранция, че ще бъде създадена само една.
#### Type Filter
```csharp
public class FeatureAuthFilter : IAuthorizationFilter
{
    private readonly IFeatureService _featureAuth;

    public FeatureAuthFilter(IFeatureService service)
    {
        _featureAuth = service;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Authorization logic here
    }
}
```

Зависимостта `IFeatureService` се подава чрез конструктора.

Този филтър не може да бъде използван като обикновен атрибут, защото атрибутите не поддържат подаване на зависимости чрез конструктора.

Използваме `TypeFilterAttribute`, за да осигурим достъп до DI контейнера.

**Контролер с `TypeFilter`**

```csharp
[TypeFilter(typeof(FeatureAuthFilter))]
public IActionResult Index()
{
    return View();
}
```
#### Service Filter
```csharp
public class FeatureAuthFilter : IAuthorizationFilter
{
    private readonly IFeatureService featureAuth;

    public FeatureAuthFilter(IFeatureService service)
    {
        this.featureAuth = service;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Authorization logic
    }
}
```

`FeatureAuthFilter` имплементира `IAuthorizationFilter`, като очаква `IFeatureService` чрез конструктора.

 **Регистриране в DI контейнера**

```csharp
builder.Services.AddSingleton<IFeatureService, FeatureService>();
builder.Services.AddSingleton<FeatureAuthFilter>();
```

И `FeatureService`, и `FeatureAuthFilter` се регистрират като Singleton услуги, така че DI контейнерът ще ги управлява.

**Използване в контролер с `ServiceFilter`**

```csharp
[ServiceFilter(typeof(FeatureAuthFilter))]
public IActionResult Index()
{
    return View();
}
```

Това указва на ASP.NET Core да вземе инстанция на `FeatureAuthFilter` **от DI контейнера**, а не да я създава ръчно.

**Какво става под капака?**

- **Инстанцията се управлява от Dependency Resolver (DI контейнера)**

- **`ServiceFilter` изпълнява филтъра при всяко извикване на Action-а**

- **Зависимостите се инжектират правилно и lifecycle-ът се спазва**

Този подход е най-препоръчителен, когато филтърът ви има зависимости, защото позволява пълен контрол върху създаването и управлението на инстанции.
# Misc
# ChatGPT
## Configuration Model
So at the beginning of an ASP.NET application, is the configuration being built and loaded into a key-value structure, similar to a dictionary, where both keys and values are strings?

**ChatGPT said:**

Yes, exactly — your understanding is correct.

Here’s what happens step by step:

1. **`WebApplication.CreateBuilder(args)`**  
    This initializes the **`WebApplicationBuilder`**, which:
    
    - Loads configuration from sources (like `appsettings.json`, environment variables, etc.).
        
    - Sets up the **dependency injection (DI) container**.
        
    - Prepares logging, environment info, and other infrastructure.
        
2. **`builder.Configuration.GetConnectionString("SQLServer")`**  
    This retrieves the connection string defined in your configuration (most often from `appsettings.json`).
    
3. **`builder.Services`**  
    This is where you register services (like `DbContexts`, identity, middleware-related services, custom services, etc.) into the **DI container**, so they can be injected and used throughout the app.

So in short:  
✅ The builder reads and prepares the configuration.  
✅ Then you register the services.  
✅ After that, you build and run the app.

**You said:**

All the configuration settings are available in the builder, and when we call `GetConnectionString("SQLServer")`, are we just retrieving the value associated with the "`SQLServer`" key from the configuration system?

**ChatGPT said:**

Yes — that's exactly how it works behind the scenes.

Here's the breakdown:

- When you call `WebApplication.CreateBuilder(args)`, the builder loads configuration from various sources (like `appsettings.json`, `environment variables`, `user secrets`, etc.).
    
- All these sources are merged into a **single configuration system**, which behaves like a **key-value dictionary** (`IConfiguration` under the hood).

So when you write:

```csharp
string connectionString = builder.Configuration.GetConnectionString("SQLServer");
```

You're effectively doing this:

- Look for a key named **"`ConnectionStrings:SQLServer`"** in the configuration data.
    
- If found, return its value.

The `.GetConnectionString("SQLServer")` method is just a helper that looks up the key using the prefix `ConnectionStrings:`.

**Example:**

In `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "SQLServer": "Server=.;Database=MyDb;Trusted_Connection=True;"
  }
}
```

This will be flattened into the key:

```
ConnectionStrings:SQLServer → "Server=.;Database=MyDb;Trusted_Connection=True;"
```

So yes — the `Configuration` is just a dictionary-like store, and you’re asking for a specific key when calling `.GetConnectionString()`.
## Two main ways to access configuration values in ASP.NET Core
✅ **Option 1: `configuration["KeyPath"]` (Indexer Access)**

**Example:**

```csharp
var value = configuration["Logging:LogLevel:Default"];
```

**Characteristics:**

- **Returns `string?`** (nullable string).
    
- Simple and direct.
    
- **No type conversion** – it's always a string or `null`.
    
- If the key doesn't exist → returns `null`.

✅ **Option 2: `configuration.GetValue<T>("KeyPath")`**

**Example:**

```csharp
var value = configuration.GetValue<string>("Logging:LogLevel:Default");
```

**Characteristics:**

- **Strongly typed** access.
    
- **Performs conversion** from string to the type you request (`int`, `bool`, etc).
    
- If the key doesn't exist → returns `default(T)` (e.g., `null` for `string`, `0` for `int`, etc).
    
- You can also specify a fallback default value:

```csharp
var level = configuration.GetValue("Logging:LogLevel:Default", "Info");
```

🔍 **Which One to Use?**

|Use Case|Prefer This|
|---|---|
|You just need a string|Either works|
|You need to convert to a number/bool|`GetValue<T>()`|
|You want to specify a fallback value|`GetValue<T>()`|
|You want to bind an entire section|`GetSection()` (separate topic)|
|You don’t care about null safety|Indexer is fine|

📝 **Summary**

- Use `configuration["Key"]` for **quick string access**.
    
- Use `configuration.GetValue<T>()` for **type-safe and fallback-friendly access**.
## Extension Methods on Interfaces
Extension methods defined for an interface are available on all classes that implement that interface. This means that whether a variable is typed as the interface or as a class implementing it, you can call the extension method on that variable. The compiler resolves extension methods based on the variable’s type and the interfaces it implements, allowing you to extend the functionality of all implementations without modifying their code.

Example:

```csharp
public interface IMyInterface
{
    void DoSomething();
}

public class ClassA : IMyInterface
{
    public void DoSomething() { }
}

public class ClassB : IMyInterface
{
    public void DoSomething() { }
}

public static class MyInterfaceExtensions
{
    public static void MyExtension(this IMyInterface instance)
    {
        Console.WriteLine("Extension method called");
    }
}

// Usage:
IMyInterface a = new ClassA();
IMyInterface b = new ClassB();

a.MyExtension();  // Works!
b.MyExtension();  // Works too!
```

This way, you can add methods to all implementations of an interface easily through extension methods.
## Scope
In .NET Dependency Injection (DI), a **scope** is a **lifetime boundary** for services registered with `AddScoped`.

- A **scoped service** is created once **per scope**.
    
- In ASP.NET Core, **each HTTP request automatically creates a scope** behind the scenes.
    
- `CreateScope()` is how you **manually start a scope**, useful in:
    
    - background services
        
    - console apps
        
    - or places **outside** of the normal HTTP request pipeline

🧱 **What `CreateScope()` does:**

```csharp
using (var scope = serviceProvider.CreateScope())
{
    var myService = scope.ServiceProvider.GetRequiredService<IMyService>();
    myService.DoWork();
}
```

- `CreateScope()` gives you a **new `IServiceScope`**.
    
- `scope.ServiceProvider` gives access to services **within that scope**.
    
- When the scope is disposed (`using` block), all **scoped services are disposed**, ensuring proper cleanup.

✅ **When should you use it?**

Use `CreateScope()` when you:

- Need to resolve services that are `Scoped`, but you're **outside of a request**, such as:
    
    - In a `BackgroundService`
        
    - In `Main()` of a console app
        
    - In a long-running worker process

❗ **Don’t use it just anywhere**

If you're **already inside a controller or middleware**, you **don’t need to call `CreateScope()`** — the framework already handles it for each request.
##  Connection Pooling

**Connection pooling** is a technique to improve performance by reusing existing database connections instead of opening a new one every time.

Think of it like reusing the same taxi instead of calling a new one for every ride.

⚙️ **How It Works in ASP.NET & EF**

When you use **Entity Framework** (EF Core or EF6) with a database like SQL Server, the underlying **ADO.NET provider** (e.g., `SqlClient`) manages the connection pool **automatically**.

- When `DbContext.Database.OpenConnection()` or `context.SaveChanges()` is called, EF opens a connection.
    
- If a connection is available in the pool, it reuses it.
    
- If not, it opens a new one (up to the max pool size).

After the operation, the connection is **returned** to the pool, **not closed**.

✅ **Benefits**

- **Reduced overhead** of opening and closing connections.
    
- **Improved scalability** for web applications.
    
- **Better performance** under load.

🧠 **Important Parameters (Connection String)**

You can control connection pooling using parameters in your connection string:

```csharp
"Server=.;Database=MyDb;Trusted_Connection=True;Max Pool Size=100;Min Pool Size=5;"
```

|Parameter|Description|
|---|---|
|`Max Pool Size`|Maximum number of connections in the pool|
|`Min Pool Size`|Minimum number of connections kept alive|
|`Pooling=true`|Enables pooling (default is true)|
|`Connection Timeout`|Timeout for getting a connection from the pool|

💡 **Best Practices**

1. **Use `using` statements**  
    Always wrap your `DbContext` in `using` or dispose it properly so connections return to the pool:
    
```csharp
using (var context = new MyDbContext())
{
    // Your logic here
}
```
    
2. **Avoid long-lived contexts**  
    Don’t hold `DbContext` instances open too long (especially in ASP.NET apps).
    
3. **Minimize concurrent connection usage**  
    Use async operations when possible (`await context.SaveChangesAsync()`).

🔍 **How to Monitor It**

You can monitor connection pool behavior using:

- **Performance counters** (`.NET Data Provider for SqlServer`)
    
- **SQL Server Profiler**
    
- **EF logging** (`EnableSensitiveDataLogging`, `LogTo`)

🧪 **Troubleshooting Tips**

- **Timeout errors?** You might be exhausting the pool. Increase `Max Pool Size` or fix context disposal.
    
- **Too many open connections?** Check for missing `Dispose()` or `using`.

**You said:**

This is similar to how a thread pool operates in asynchronous programming, right?

**ChatGPT said:**

Great question! The concepts of **connection pooling** and **thread pooling** are related in that both aim to improve performance by reusing resources, but they are different in what exactly they manage and how they work. Here’s a quick comparison to clarify:

**Connection Pool vs Thread Pool — What’s Similar and What’s Different?**

|Aspect|Connection Pool|Thread Pool|
|---|---|---|
|**What is managed?**|Reuses **database connections** to avoid overhead opening/closing DB connections.|Reuses **threads** to avoid overhead creating/destroying threads for tasks.|
|**Purpose**|Reduce the expensive cost of opening DB connections multiple times.|Efficiently manage threads for parallel/asynchronous operations.|
|**When is it used?**|Whenever the app needs to talk to the database (via ADO.NET, EF).|Whenever async or parallel work is done (e.g., Task.Run, async/await).|
|**How reuse works?**|Connections are pooled and returned after use, ready for next DB call.|Threads are reused to run different tasks sequentially or in parallel.|
|**Pooling lifetime**|Pool is managed per connection string, lives as long as app runs.|Thread pool lives as long as the process runs and manages threads dynamically.|
|**Example in ASP.NET**|Reusing SQL Server connections via EF `DbContext`.|Reusing threads for asynchronous controller actions or background tasks.|

**So: Are They Similar?**

**Yes, conceptually** — both improve efficiency by avoiding costly resource creation.

**But practically, they are managing very different things:**

- **Connection pooling:** optimizes database connection management.
    
- **Thread pooling:** optimizes CPU-bound or async task execution.

**How Do They Work Together in ASP.NET?**

When you use async operations in ASP.NET with EF:

- Your code may run on a **thread from the thread pool**.
    
- EF uses **connection pooling** to get a DB connection quickly without waiting.
    
- Async frees up threads while waiting on I/O (like DB), improving throughput.
    
- Connection pool ensures fast DB access without waiting for new connections.

**Quick analogy:**

- **Thread pool** is like a pool of workers ready to do tasks.
    
- **Connection pool** is like a fleet of cars ready to drive workers around (DB calls).

Both make the system faster by **reusing resources efficiently**.
## Understanding `app.Use()` Middleware in ASP.NET Core
1. **What does `app.Use()` do?**

- The `Use` method lets you **add middleware components** to the ASP.NET Core HTTP request pipeline.
    
- Middleware are small pieces of code that can **inspect, modify, or short-circuit** HTTP requests and responses.
    
- Each middleware has this signature:

```csharp
Func<HttpContext, Func<Task>, Task>
```

This means:

- It accepts an `HttpContext` (current HTTP request and response info).
    
- It accepts a `Func<Task>` called `next`, which represents the **next middleware in the pipeline**.
    
- It returns a `Task` because the middleware typically performs asynchronous operations.

2. **What exactly is the `next` parameter (`Func<Task>`)?**

- **`next` is a delegate that ASP.NET Core provides for you.**
    
- It represents the **next middleware in the chain**, wrapped as a `Func<Task>` delegate.
    
- When you call:

```csharp
await next();
```

you’re telling ASP.NET Core:

> _“Run the next middleware in the pipeline now.”_

- You do **not** build or supply `next` yourself. The framework constructs and passes it in for you behind the scenes.

3. **How is the middleware pipeline built?**

When you write multiple middleware registrations:

```csharp
app.Use(MiddlewareA);
app.Use(MiddlewareB);
app.Use(MiddlewareC);
```

ASP.NET Core builds a **middleware pipeline** under the hood by **nesting each middleware inside the previous one**, kind of like this conceptually:

```csharp
context => MiddlewareA(context, 
    () => MiddlewareB(context, 
        () => MiddlewareC(context, 
            () => terminalMiddleware(context)
        )
    )
)
```

- Each `next()` is a delegate that calls the next middleware in the pipeline.
    
- So inside `MiddlewareA`, calling `await next()` executes `MiddlewareB`, and so on.

4. **What does a typical middleware look like?**

Example middleware:

```csharp
app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware A - Before");

    await next(); // Pass control to Middleware B

    Console.WriteLine("Middleware A - After");
});
```

- You can run code **before** and **after** calling `await next()`.
    
- If you choose **not to call** `next()`, the pipeline short-circuits and no later middleware runs.

5. **Visualizing the flow**

```csharp
Func<HttpContext, Func<Task>, Task> middleware = async (context, next) =>
{
    // Before
    await next(); // Invokes the *next* middleware in the chain
    // After
};
```

- ASP.NET Core **automatically constructs and injects** `next` for you.
    
- Your middleware just decides **when or if** to call `await next()`.

6. **Summary**

- `app.Use()` builds the middleware pipeline one step at a time.
    
- Each middleware receives:
    
    - The current `HttpContext`
        
    - A `next` delegate representing the next middleware
        
- The framework wires up the chain and passes the correct `next` delegate each time behind the scenes.
    
- You control the pipeline flow by calling or skipping `await next()`.

7. **Extra tips**

- Middleware ordering is critical — it determines how requests and responses are handled.
    
- Middleware can modify requests before passing them on, or modify responses after calling `next()`.
    
- Short-circuiting (skipping `next()`) is useful for handling errors, returning early responses, or serving static files.
### How the Framework Collects `Use(...)` Middleware into One Chain

When you write:

```csharp
app.Use(MiddlewareA);
app.Use(MiddlewareB);
app.Use(MiddlewareC);
app.Run(FinalHandler);
```

ASP.NET Core doesn’t execute those right away. Instead, it **stores them in order**, and only later **builds a single chain of middleware functions**.

Here’s what happens under the hood:

🧱 1. **`app.Use(...)` Adds Middleware to a List**

Every time you call `app.Use(...)`, it adds your delegate to an internal list inside `IApplicationBuilder`.

```csharp
public class ApplicationBuilder : IApplicationBuilder
{
    private readonly List<Func<RequestDelegate, RequestDelegate>> _components 
        = new List<Func<RequestDelegate, RequestDelegate>>();

    public IApplicationBuilder Use(Func<HttpContext, Func<Task>, Task> middleware)
    {
        // Wrap your middleware into a RequestDelegate factory
        _components.Add(next => context => middleware(context, () => next(context)));
        return this;
    }
}
```

So your middleware gets wrapped in a `Func<RequestDelegate, RequestDelegate>` (we'll return to this shortly).

🔨 2. **`app.Run(...)` Adds the Terminal Middleware**

`Run(...)` is also middleware, but it's meant to be the **end of the chain**. It doesn’t call `next()`, so nothing executes after it.

It also gets wrapped and added to the list.

🧩 3. **At `app.Build()` — All Middleware Get Composed into a Chain**

When the framework starts handling a request, it calls:

```csharp
var app = builder.Build(); // this triggers the actual pipeline construction
```

And this happens inside:

```csharp
public RequestDelegate Build()
{
    RequestDelegate app = context =>
    {
        // If no middleware is registered
        return Task.CompletedTask;
    };

    // Build in reverse order — last registered gets executed last
    foreach (var component in _components.Reverse())
    {
        app = component(app); // Each middleware wraps the current pipeline
    }

    return app; // Final pipeline delegate
}
```

So now you have a **single `RequestDelegate`**, like:

```csharp
context => MiddlewareA(context, 
    () => MiddlewareB(context, 
        () => MiddlewareC(context, 
            () => FinalHandler(context)
        )
    )
)
```

🎯 4. **When a Request Comes In**

The composed `RequestDelegate` is executed for each HTTP request. Each middleware:

- Receives `HttpContext`
    
- Does something **before**
    
- Calls `await next()` (which is just the next delegate)
    
- Does something **after**

📈 **Visual Flow**

```
Request
   ↓
MiddlewareA
   ↓
MiddlewareB
   ↓
MiddlewareC
   ↓
FinalHandler
```

Each `Use(...)` call builds a layer that wraps the one after it.

✅ **Summary**

- `app.Use(...)` calls are stored as delegate factories
    
- `app.Build()` reverses and chains them
    
- The result is a single delegate that ASP.NET Core invokes per request
    
- The `next()` parameter is created during this composition step
    
- This allows each middleware to control when and whether the next one runs

**You said:**

Lets follow the below code in detail.

```csharp
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Add routing to Identity Razor Pages

app.Use(async (context, next) =>
{
    Console.WriteLine("before");
    await next();
    Console.WriteLine("after");
});

app.Run();
```

**ChatGPT said:**

Let's walk through **exactly what happens** in the code you posted — step by step — so you can understand how ASP.NET Core builds and executes the middleware pipeline.

✅ **Full Code**

```csharp
app.UseAuthorization(); // 1. Middleware added: Who can access what?

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // 2. Adds endpoints for Razor Pages

app.Use(async (context, next) => { 
    Console.WriteLine("before"); 
    await next(); 
    Console.WriteLine("after"); 
});

app.Run();
```

🔄 **Step-by-Step Explanation**

1. **`app.UseAuthorization();`**

This is a **built-in middleware** that enforces authorization policies.

- It doesn’t know which endpoint the user is requesting yet.
    
- It waits until **routing has been done**, so it knows what endpoint was matched, then checks if the user is allowed to access it.

> ⚠️ **Important**: It depends on routing metadata, which means:

- You must call `UseAuthorization()` **after `UseRouting()`**, and
    
- **Before `Map*()` methods like `MapControllers()` or `MapRazorPages()`** — unless you're using endpoint routing, which auto-applies middleware.

In newer versions, `MapControllerRoute()` and `MapRazorPages()` call `UseRouting()` internally, so `UseAuthorization()` can be used slightly earlier.

2. `app.MapControllerRoute(...)` and `app.MapRazorPages();`

These are **endpoint mapping methods**. They register the actual routes/endpoints in the app.

- `MapControllerRoute(...)` says: “If the URL looks like `/Home/Index`, call the `HomeController.Index()` method.”
    
- `MapRazorPages()` adds routes for Razor Pages (e.g., `/Account/Login`, `/Register`, etc.)
    

Under the hood, these methods call `UseEndpoints(...)` to add endpoint execution to the pipeline.

**So now:**

- The middleware chain has something to route to (controllers or pages).
    
- `UseAuthorization()` can now work with the endpoints metadata.

3. `app.Use(...)` – Your custom middleware

```csharp
app.Use(async (context, next) => {
    Console.WriteLine("before"); 
    await next(); 
    Console.WriteLine("after"); 
});
```

This adds a **custom middleware** into the pipeline.

- It prints `before`
    
- Calls `await next()` → which continues the pipeline (eventually hitting the matched controller/page)
    
- Then prints `after` once the response is returning back up the chain
    

> This is a very common pattern for logging, performance measurement, error catching, etc.

4. `app.Run();`

This ends the middleware pipeline. It’s the **terminal middleware** — nothing after this will run.

> If `app.Run()` is empty, and the request has already been handled by an endpoint (like a controller), then it does nothing.
> 
> But if no endpoint handled the request, and no `Run()` was defined to handle fallback behavior (like 404), the request may return a default 404 response.

🧠 **Internal Chain (Visual)**

Let’s simulate what ASP.NET Core builds:

```csharp
context => 
    UseAuthorization(context, 
        () => YourCustomMiddleware(context, 
            () => EndpointMiddleware(context)
        )
    )
```

Or, to visualize:

```
↓ Request comes in
├── UseAuthorization() middleware
│   ├── checks if user is allowed to access matched endpoint
│   ↓
├── Your custom middleware
│   ├── prints "before"
│   ├── calls next()
│   │   ↓
│   └── eventually the endpoint handler is called (controller or Razor Page)
│   └── prints "after"
↓ Response goes out
```

✅ **Final Notes**

- `UseAuthorization()` expects routing metadata to already exist.
    
- Your `Use(...)` middleware runs _before and after_ the matched endpoint executes.
    
- `MapControllerRoute()` and `MapRazorPages()` register the actual endpoints.
    
- ASP.NET Core collects all middleware and endpoint mappings, then chains them in reverse order during app startup.
## `app.UseRouting()`

`app.UseRouting()` is a **middleware** that matches incoming HTTP requests to the **route definitions** in your app.

📌 **Purpose**

- It **analyzes the request URL** and **selects the matching endpoint** (e.g., controller action, Razor Page, minimal API).
    
- It **populates the `HttpContext` with route data** (like controller, action, parameters).

⚠️ **Why It’s Important**

- Without it, your app:
    
    - ❌ Can't find which action/controller to invoke.
        
    - ❌ Can’t apply attribute-based policies like `[Authorize]`, `[HttpPost]`, etc.
        
    - ❌ Can’t match URLs to endpoint definitions.

🧩 **Where It Goes**

It must come **before**:

- `app.UseAuthorization()` – because authorization depends on matched route data.
    
- `app.UseEndpoints()` (or `MapControllerRoute()` / `MapRazorPages()`), which actually executes the matched endpoint.

✅ **Correct Order Example**

```csharp
app.UseRouting();          // Matches the route
app.UseAuthentication();   // (optional) Identity
app.UseAuthorization();    // Uses route metadata for policies
app.MapControllers();      // Executes the controller action
```
## Endpoint
🔍 **In ASP.NET Core:**

An **endpoint** is the final destination that handles a request — this can be:

- A controller action method (e.g. `ProductsController.Get(int id)`)
    
- A Razor Page
    
- A minimal API handler
    
- A middleware endpoint (e.g. a `Run` delegate)

🧭 **Example:**

```csharp
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok($"Product {id}");
    }
}
```

When you call `/api/products/5`, the framework:

1. Matches the route using `UseRouting()`
    
2. Authorizes access using `UseAuthorization()`
    
3. Finds the **endpoint**: `Get(int id)` action method
    
4. Executes that action

In the context of MVC and Web API, **the endpoint is the matched action method that gets executed for a given route**.
## `MapControllerRoute()`
`MapControllerRoute()` sets up **conventional routing** for MVC controllers in ASP.NET Core.

✅ **Purpose:**

It defines a **pattern** that matches incoming URLs to controller actions, based on naming conventions.

🧩 **Syntax:**

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

⚙️ **What it does:**

- Matches URLs like `/Products/Details/5`
    
- Maps them to:
    
    - `ProductsController`
        
    - `Details` method
        
    - `id = 5` (optional)

🗺️ **Pattern Breakdown:**

- `{controller}` → Controller name (e.g., `Products`)
    
- `{action}` → Method name (e.g., `Details`)
    
- `{id?}` → Optional route parameter

🛠️ **When to use it:**

- You’re using traditional MVC with controllers and views.
    
- You want **convention-based** routing (no `[Route]` attributes needed).

🚫 **If you don’t use it:**

- URLs won't be routed to controllers unless you’re using **attribute routing** (`[Route]`, `[HttpGet]`, etc.).

🚫 **Important Notes:**

- ✅ **Not a middleware** — it's an **endpoint registration method** that configures the final routing table.
    
- ❌ If you skip it (and aren’t using attribute routing), the framework won’t know how to route requests to your controller actions.
    
- ✅ Requires `app.UseRouting()` and `app.UseEndpoints()` (or Razor/MVC maps) to be called beforehand.

⚙️ **Implicit Behavior:**

- ❗ **`app.UseEndpoints()` is implicitly called** behind the scenes when using **Minimal APIs** or `MapControllerRoute()` in ASP.NET Core 6.0+ (with top-level statements or simplified hosting).
    
- But in full hosting scenarios, you might still see it explicitly written in older templates.

**You said:**

In essence, `MapControllerRoute` registers route patterns used by the routing system to resolve incoming requests to controller actions. While it's possible to manually register each action with specific routes, the more efficient and maintainable approach is to define a dynamic pattern—such as `{controller}/{action}`—which allows the framework to dynamically match existing controllers and actions. If no match is found, a 404 is returned. This pattern-based routing saves the effort of explicitly listing every route.

**ChatGPT said:**

Yes — you're absolutely correct, and you've described the real mechanism behind `MapControllerRoute` quite well. Let's break it down clearly:

🔧 **What `MapControllerRoute` Does**

`MapControllerRoute` **registers a URL pattern** that the ASP.NET Core routing system uses to map incoming requests to **controller actions**.

Example:

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

- This tells ASP.NET Core:
    
    > "For any URL that looks like `/SomeController/SomeAction`, try to find a matching controller and action in the app."

✅ **Dynamic Pattern Matching — The Convenient Way**

You're spot-on here:

> We can define **a generic pattern** once, like `{controller}/{action}`, and ASP.NET Core will dynamically match existing controllers and actions.

Advantages:

- You **don’t have to list every action** manually.
    
- It scales automatically as you add new controllers and actions.
    
- Invalid routes (e.g., to nonexistent controllers/actions) automatically return **404**.

This is the **convention-based routing** system.

🧱 **Alternative: Manually Mapping Each Route**

Yes, you can do this too:

```csharp
app.MapControllerRoute(
    name: "homeIndex",
    pattern: "home/index",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "about",
    pattern: "info/about",
    defaults: new { controller = "Info", action = "About" });
```

But this is:

- Verbose
    
- Harder to maintain
    
- Prone to errors

That’s why it’s usually reserved for:

- Special-case URLs
    
- SEO-friendly custom URLs
    
- Legacy systems

🧠 **Summary**

|Approach|What It Does|When To Use|
|---|---|---|
|✅ Generic pattern: `{controller}/{action}/{id?}`|Automatically maps to all existing controller/action pairs|Default, scalable approach|
|❌ Manual route mapping|You write specific routes for each action|Only when you need custom URLs or special handling|

So your observation is exactly right:

> ✔️ _We can register all actions one by one, but the more convenient, scalable, and idiomatic way is to use a dynamic pattern like `{controller}/{action}`._

**Final Notes**

`MapControllerRoute` is not middleware; instead, it **registers route patterns** with the application's endpoint routing system. These patterns define how incoming URLs should be matched to controller actions. The order in which `MapControllerRoute` is called doesn't affect the request pipeline, because it simply adds endpoints to an internal collection (`EndpointDataSource`) before the routing middleware (`UseRouting`) is executed. At runtime, the routing system uses these registered patterns to resolve requests. If a URL matches a defined pattern and corresponds to an existing controller/action, it's handled accordingly; otherwise, a 404 is returned.

- These `Map*` methods run **immediately during app startup**, when the app is building its internal routing table.
    
- This happens **before any HTTP requests are processed**.
    
- So no matter if you place them before or after `app.UseRouting()`, the routes are registered in time for the routing middleware to use.

**What really matters is:**

- `app.UseRouting()` must be in the middleware pipeline before middlewares like `UseAuthorization()` that rely on routing data.
    
- `MapControllerRoute()` (and other `Map*` methods) must be called **before the app starts handling requests** (which happens naturally during startup).

In practice, you almost always see this order for clarity and convention:

```csharp
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(...);
```

But the key point is: **the routes get registered at startup regardless of their position relative to `UseRouting()`.**

✅ **`app.Map()`

- **What it does:**  
    `app.Map()` **branches the middleware pipeline** based on the request path.  
    It allows you to define **sub-pipelines** that only run when the request path starts with a specific prefix.
    
- **Syntax example:**
    
```csharp
app.Map("/admin", adminApp =>
{
    adminApp.UseMiddleware<SomeMiddleware>();
    adminApp.Run(async ctx => await ctx.Response.WriteAsync("Admin area"));
});
```
    
- **Behavior:**
    
    - Requests to `/admin` or anything starting with `/admin/...` will be handled by this sub-pipeline.
        
    - All other requests **skip this branch entirely**.
        
- **Part of the pipeline:**  
    ✅ `Map()` **is a middleware**. It actively **alters the request pipeline** structure, unlike `MapControllerRoute()`.

🔄 **`Map()` vs `MapControllerRoute()`**

|Feature|`Map()`|`MapControllerRoute()`|
|---|---|---|
|Part of middleware pipeline|✅ Yes|❌ No – just registers routes at startup|
|Controls path branching|✅ Yes|❌ No|
|Used for|Custom logic for specific path roots|Routing to controller actions (MVC)|
|Runs during request?|✅ Yes – affects request flow|❌ No – registers before requests begin|

In short:

- `Map()` **controls** the flow of requests at runtime.
    
- `MapControllerRoute()` **registers** routes during app startup and is not itself a middleware.

**You said:**

So the purpose of `map()` is to define an endpoint for a request, effectively routing it to the appropriate action controller or page?

**ChatGPT said:**

✅ **Yes, exactly — you're spot on.**

The purpose of `app.MapControllerRoute(...)` and `app.MapRazorPages()` is to **create _endpoints_** — they tell ASP.NET Core:

> “When the middleware pipeline finishes its work, here’s where to send the request based on the URL.”

Let’s unpack this more clearly:

🔧 **What `MapControllerRoute()` Does**

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

This **registers an endpoint route** in the system that tells the framework:

> “If the URL looks like `/products/list/5`, then match:
> 
> - controller = `Products`
>     
> - action = `List`
>     
> - id = `5`.”
>     

So this is the **final destination** in the pipeline — it’s the part that says:  
“Based on the URL, call the correct controller action.”

🧭 **What `MapRazorPages()` Does**

This registers **Razor Page routes** (like `/Account/Login`) if you're using Identity UI or Razor Pages. So it wires up paths like `/Account/Register`, `/Identity/Account/Manage`, etc.

🚇 **How Middleware + Endpoints Work Together**

1. You register middlewares with `app.Use(...)`.
    
2. You end with `Map...()` to define **what will respond** to the request.
    
3. Behind the scenes, the framework builds a giant chain like:

```csharp
[UseAuthentication]
   → [UseAuthorization]
      → [Your Logging Middleware]
         → [Routing Middleware]
            → [Controller or Razor Page] 👈 endpoint
```

🧠 **Think of it like a subway**

- Each `Use()` is a station that can:
    
    - Inspect the request
        
    - Reject the request
        
    - Let it continue
        
- The `Map...()` at the end is your final **destination** — it dispatches the `HttpContext` to the **controller or page** that will handle it.

✅ **In summary:**

Yes — `MapControllerRoute()` and `MapRazorPages()` are how ASP.NET Core knows:

> “Which controller/page should respond to this request based on its URL?”

And all the middleware (`UseX`) runs **before the request reaches** that controller/page — like a filter tunnel.

Let me know if you want to build a minimal example together — it's the best way to _see_ it.
## Map()
`app.Map()` is a middleware branching method that lets you create a **branch in the request pipeline** based on a specific condition, usually a URL path prefix.

**Purpose**

- **Branch the middleware pipeline** so that requests matching a certain path (or condition) are handled by a separate, isolated pipeline.
    
- This helps you organize your middleware and endpoint routing **by URL path segments**, allowing different middleware sets, routing, or authorization rules on different app sections.

**How does `app.Map()` work?**

- `app.Map()` takes two parameters:
    
    1. **Path prefix** (string) or **predicate** (a function that evaluates the request)
        
    2. **A branch configuration action**, which receives a new `IApplicationBuilder` representing the branch pipeline
        
- When a request comes in:
    
    - The middleware pipeline checks if the request path matches the map condition (e.g., starts with the path prefix)
        
    - If **yes**, the request is routed into the branch pipeline you configure inside the `Map()` call
        
    - If **no**, the request continues down the main pipeline, skipping the branch entirely

**Signature examples**

```csharp
// Branch based on path prefix (e.g. "/admin")
app.Map("/admin", adminApp =>
{
    // Configure middlewares and endpoints for /admin requests here
});

// Branch based on a custom condition
app.Map(context => context.Request.Method == "POST", postApp =>
{
    // This pipeline handles POST requests only
});
```

**What happens inside the branch pipeline?**

- The branch pipeline is a **new middleware pipeline**, isolated from the main one starting at the branch point.
    
- Middlewares registered in the main pipeline **before** the `Map()` call **run first**.
    
- When the request reaches the `Map()` middleware:
    
    - If the request matches the branch condition, it jumps into the branch pipeline **and runs only middlewares registered inside it**.
        
    - The branch pipeline does **not run middleware registered in the main pipeline after the `Map()` call**.
        
- This means you often need to **repeat middlewares like `UseRouting()`, `UseAuthentication()`, or `UseAuthorization()` inside the branch** if those middlewares are needed for requests in that branch.

**Can a middleware branch return to the root branch after it finishes?**

Once the request enters a branch via `app.Map("/something", ...)`, it is **isolated** to that sub-pipeline. The root (parent) pipeline is **not revisited**.

Think of it like this:

```
Root pipeline
 ├── Map("/admin") → [ admin middleware1 → middleware2 → Run() ]
 └── All other requests → continue in root pipeline
```

When a request enters `/admin`, it **jumps entirely into the `/admin` branch**, and **never returns** to the outer pipeline.

Quick analogy:

Think of `Map()` like a **toll booth split**:

- Once you take the `/admin` path, you’re on a **separate road**.
    
- That road has **its own signs and logic** (`Use`, `Run`, `MapControllers()` etc.).
    
- You **won’t rejoin** the main highway unless you manually re-route requests (which is rare and complex).

**Important notes**

- `app.Map()` only matches requests based on **path prefixes or custom predicates**. The rest of the URL (after the prefix) is still available inside the branch.
    
- The middleware pipeline inside the branch **does not automatically inherit** middleware registered after the branch point in the main pipeline.
    
- The middleware pipeline inside the branch can have **its own routing and endpoint setup**.

- When you create a new branch pipeline with `app.Map()`, it acts as a separate, isolated pipeline that handles requests matching its condition. This branch **does not merge back** into the main pipeline—once a request enters the branch, it only runs the middleware configured inside that branch and skips any middleware registered after the `Map()` call in the main pipeline. In other words, the branch pipeline is independent and does not continue or combine with the main pipeline’s middleware.

**Why use `app.Map()`?**

- To **separate concerns**: e.g., an admin area with different authentication or policies.
    
- To **isolate functionality** or middleware chains for a part of the app.
    
- To create **mini applications** inside your bigger app with different middleware and endpoints.

**Example**

```csharp
app.UseRouting();

app.Map("/admin", adminApp =>
{
    adminApp.UseAuthentication();
    adminApp.UseAuthorization();

    adminApp.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "admin",
            pattern: "admin/{controller=Dashboard}/{action=Index}/{id?}");
    });
});

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
```

- Requests to `/admin/...` go to the branch pipeline with its own routing and authorization.
    
- Requests to other URLs go through the main pipeline.
### Why does the branch pipeline need to add middleware again, even if it was already added before the branching point?
**Short answer:**  
The branch pipeline **starts at the point of the `app.Map()` call**, and **does not continue executing middleware registered before it** again — it _starts fresh_ there.

**How the middleware pipeline actually works under the hood**

Imagine the middleware pipeline like a chain of handlers that process requests one after another.

When you do this:

```csharp
app.UseMiddlewareA();    // #1
app.UseMiddlewareB();    // #2
app.Map("/branch", branchApp =>
{
    branchApp.UseMiddlewareC(); // #3
});
app.UseMiddlewareD();    // #4
```

Requests flow like this:

- For non-branch requests:
    
    - MiddlewareA (#1) → MiddlewareB (#2) → MiddlewareD (#4)
        
- For branch requests (e.g., `/branch/whatever`):
    
    - MiddlewareA (#1) → MiddlewareB (#2) → **jump to branch pipeline starting at #3** → MiddlewareC (#3)
        

Notice that:

- MiddlewareA and MiddlewareB run _before_ the branch pipeline
    
- But the branch pipeline starts at `MiddlewareC` (#3) and **does NOT run `MiddlewareD` (#4)**

So what about middleware like routing and authentication registered before `app.Map()`?

- **Those middlewares are already run before the branch pipeline.**
    
- So your branch **does get the effect** of those middlewares (because they were executed earlier in the main pipeline).

**Then why do we have to add routing/auth _again_ in the branch?**

Because:

- **Routing middleware (`UseRouting`) builds the routing table for the current pipeline.**
    
- The routing middleware registered _before_ the branch is invoked _before_ the branch pipeline starts, but it only knows about endpoints registered in that pipeline up to that point.
    
- The **branch pipeline needs its own routing middleware and endpoint registrations to handle its own endpoints** because it's a separate sub-pipeline.
    
- Same for authorization/authentication middleware that rely on routing info and endpoint metadata — **the branch needs to re-run them to apply policies based on the branch's routes**.

**Another way to see it:**

- **Middleware before the branch modifies the request and sets up things for the branch.**
    
- **But the branch pipeline needs to build its own routing table and apply authorization logic relevant to its own endpoints.**
    
- So even though `UseAuthentication()` was called before `app.Map()`, **the branch pipeline still needs to call it again to enforce auth on its own endpoints** because the authorization middleware uses routing information that is only available _after_ routing middleware runs inside that branch.

**To summarize:**

|Middleware type|Registered before `app.Map()`|Registered inside branch pipeline?|Reason|
|---|---|---|---|
|`UseRouting()`|Yes|Yes|Branch needs routing table for its own endpoints|
|`UseAuthentication()`|Yes|Yes|Authorization depends on routing metadata, so branch must apply it again|
|`UseAuthorization()`|Yes|Yes|Authorization policies must run with branch routes|
|Other middlewares|Yes|No or optional|Some modify request globally and run once (e.g., logging)|

**Example:**

```csharp
app.UseRouting();           // Builds main routing table (without branch endpoints)
app.UseAuthentication();    // Authenticates user for all requests before branching

app.Map("/branch", branchApp =>
{
    branchApp.UseRouting();           // Branch builds routing table for branch endpoints
    branchApp.UseAuthentication();   // Auth middleware re-applies for branch endpoints
    branchApp.UseAuthorization();    // Authorization middleware re-applies policies based on branch routes

    branchApp.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();  // Map controllers in branch
    });
});

app.UseAuthorization();     // Runs only for main pipeline endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();      // Map controllers in main pipeline
});
```

If you think about the routing & authorization middlewares as "building and applying policies based on routes", then **each pipeline has its own routing table and policy application**, so you must set them up _in every pipeline you create_.
### How `app.Map()` Branches and Strips the Path in ASP.NET Core

- The `app.Map("/prefix", branch => { ... })` middleware **creates a branch** in the request pipeline that is only executed when the incoming request path **starts with** the specified prefix (`/prefix`).
    
- When a request matches the prefix, the middleware **removes that prefix segment from the request path** (`HttpContext.Request.Path`) before executing the branch middleware.
    
- Inside the branch, the request path (`HttpContext.Request.Path`) is **adjusted to the remainder after the prefix**, usually starting at `/` or some sub-path, relative to the branch root.
    
- The removed prefix is normally stored in `HttpContext.Request.PathBase`, which represents the "base path" of the application or branch. However, depending on the middleware setup or nested branches, `PathBase` may sometimes remain empty.
    
- Because the branch middleware pipeline sees a modified request path (with the prefix removed), **all routing inside the branch is relative to the stripped path**, not the original full URL.
    
- This behavior allows you to isolate and handle different URL segments with different middleware pipelines or routing rules.

**Example**

Request URL:

```
/cinema/admin
```

With branch:

```csharp
app.Map("/cinema/admin", adminApp =>
{
    // Inside here, Request.Path = "/" (prefix "/cinema/admin" is stripped)
    // So routing patterns and controllers should be relative to "/"
});
```

Result inside the branch:

| Property           | Value                                        | Explanation                                           |
| ------------------ | -------------------------------------------- | ----------------------------------------------------- |
| `Request.Path`     | `/`                                          | The part of the path **after** `/cinema/admin` prefix |
| `Request.PathBase` | `/cinema/admin` (usually) or sometimes empty | The matched prefix (base path)                        |

**Why is this useful?**

- You can **compose modular request pipelines** for different URL prefixes.
    
- You isolate routing and middleware logic specific to a prefix without needing to handle the prefix manually.
    
- You write routing inside the branch **as if the prefix was the application root**.
## `app.Run()` – The Application Start Button vs Middleware Terminator

🟢 **1. `app.Run()` (no parameters)**

This is like the **start button** for your application.  
It **starts the web server** and begins listening for HTTP requests.

- ✔️ Mandatory to start the app.
    
- ❗Without it, the app will build but **won’t start** or respond to requests.
    
- Placed at the **very end** of `Program.cs` or `Startup.cs`.

```csharp
var app = builder.Build();
// ... middleware setup
app.Run(); // Starts the app
```

🟡 **2. `app.Run(delegate)` – Final Middleware (terminating)**

This version **adds a terminal middleware** to the request pipeline.

- It **handles requests** and **prevents any further middleware** from executing after it.
    
- Used to provide **custom responses** like:

```csharp
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello!");
});
```

- This is **NOT the same** as the empty `app.Run()` above.

⚠️ **Important Differences**

|Purpose|`app.Run()` (no args)|`app.Run(delegate)`|
|---|---|---|
|Role|Starts the server|Ends the request pipeline|
|Required?|✅ Yes|❌ Optional|
|Executes middleware?|❌ No|✅ Yes (but terminates the pipeline)|
|Placement|Last line of `Program.cs`|Anywhere in pipeline, often last logic|

🔁 **Summary**

- ✅ `app.Run()` (no delegate) is **mandatory** – it starts your app.
    
- 🚧 `app.Run(delegate)` is **a middleware** – it ends request processing and should be used carefully to not block MVC or Razor routing.

**You said:**

When we use a request delegate with the `Use` method, and we don't invoke the `next` delegate, it behaves like the `Run` method by terminating the request pipeline.

**ChatGPT said:**

Yes, exactly — your understanding is correct.

In ASP.NET Core middleware, when you use the `app.Use(...)` method **without calling `next()`**, it behaves **like `app.Run(...)`**, effectively **short-circuiting** the pipeline.

**Quick Overview:**

- `app.Use(...)` is used to **add middleware to the pipeline**. Middleware added with `Use` **can call `next()` to pass control** to the next middleware.
    
- `app.Run(...)` is used to **terminate** the pipeline. It’s typically the last middleware and **does not call `next()`**.

**Example:**

```csharp
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Before\n");
    await next(); // Passes to the next middleware
    await context.Response.WriteAsync("After\n");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Inside Second Middleware\n");
    // next() is NOT called here, so pipeline stops here
});
```

This behaves **as if the second `Use` is a `Run`**, because it **doesn't call `next()`**.

**Equivalent to:**

```csharp
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Before\n");
    await next();
    await context.Response.WriteAsync("After\n");
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Inside Second Middleware\n");
});
```

So yes — if you don’t call `next()` in a `Use` delegate, it **acts like `Run`**, stopping further middleware from executing.
# Bookmarks
[Filters in ASP.NET Core | Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-9.0)

Completion: 22.05.2025