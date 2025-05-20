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

ASP.NET Core creates a nested chain that looks like this conceptually:

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
        
- The framework wires up the chain and passes the correct `next` delegate each time.
    
- You control the pipeline flow by calling or skipping `await next()`.

7. **Extra tips**

- Middleware ordering is critical — it determines how requests and responses are handled.
    
- Middleware can modify requests before passing them on, or modify responses after calling `next()`.
    
- Short-circuiting (skipping `next()`) is useful for handling errors, returning early responses, or serving static files.
# Bookmarks
Completion: 20.05.2025