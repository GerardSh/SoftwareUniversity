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
![](Pasted%20image%2020250518142916.png)

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
`string connectionString = builder.Configuration.GetConnectionString("SQLServer");`
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
# Bookmarks
Completion: 19.05.2025