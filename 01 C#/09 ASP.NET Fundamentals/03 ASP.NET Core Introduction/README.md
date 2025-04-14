# General
## Overview
ASP.NET Core е кросплатформен, с отворен код, фреймуърк за разработка на бекенд приложения с C#.

ASP.NET Core Web Pages: Това е опция за изграждане на прости уеб приложения, които използват Razor view engine за вграждане на C# код директно в HTML. Подходящо е за по-малки проекти и бързо създаване на динамично съдържание.

ASP.NET Core MVC: Тази опция следва архитектурния модел Model-View-Controller (MVC), който разделя приложението на три основни компонента: модел (данни и бизнес логика), изглед (UI) и контролер (обработва входа от потребителя). Подходящо е за по-сложни, големи приложения, които изискват добра структура и разделение на отговорностите.

ASP.NET Core Web API: Това е опция за изграждане на RESTful уеб услуги, които могат да се използват за комуникация между различни приложения и устройства, като мобилни приложения или уеб фронтенд решения. Подходящо е за създаване на API интерфейси за обмен на данни, обикновено чрез JSON формат.

Отлична документация: [ASP.NET documentation | Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-9.0)

ASP.NET Core предлага:

- Интеграция с модерни клиентски фреймуърци (Angular, React, Blazor и други): Това позволява лесно свързване на съвременни уеб технологии с ASP.NET Core, като осигурява по-добро взаимодействие между сървър и клиент и позволява изграждането на динамични и интерактивни уеб приложения.

- Работни потоци за разработка (MVC, WebAPI, Razor Pages, SignalR): Разработчиците имат избор от различни архитектурни подходи, в зависимост от типа приложение, което искат да изградят. MVC предлага структурирано разделение на компонентите, WebAPI е подходящо за RESTful услуги, Razor Pages е опростен начин за създаване на динамични уеб страници, а SignalR е подходящ за изграждане на реално време комуникация в приложенията.

ASP.NET Core приложенията могат да се изпълняват както на .NET Core, така и на .NET Framework: Това осигурява гъвкавост и възможност за стартиране на приложения както на модерната, кросплатформена среда .NET Core, така и на традиционната .NET Framework, което е важно за съществуващи проекти, които се нуждаят от съвместимост.
## Main Features
Единен фреймуърк за изграждане на уеб UI и уеб API, с архитектура за тестване – можем лесно да изграждаме, поддържаме и тестваме приложенията си в една обща структура.

Възможност да разработваме и стартираме на Windows, macOS и Linux – така избираме най-удобната за нас операционна система.
- Възможност да хостваме на IIS, Nginx, Apache, Docker или самостоятелно в собствен процес – това ни дава свобода при избора на инфраструктура.

Вградена dependency injection – внедряваме зависимости по чист и гъвкав начин, който подобрява тестването на нашите приложения.

Лек, високопроизводителен и модулен HTTP request pipeline (middlewares) – конфигурираме гъвкаво как се обработват HTTP заявките в нашето приложение.

Razor Pages е програмен модел, базиран на страници, който улеснява изграждането на уеб UI – така бързо структурираме потребителския интерфейс.

Blazor ни позволява да използваме C# в браузъра и да споделяме логика между сървъра и клиента – това ни спестява нуждата от JavaScript в много случаи.

Razor markup предоставя синтаксис за Razor Pages, MVC изгледи и Tag Helpers – така комбинираме C# и HTML в единен изразителен синтаксис.

Cloud-ready конфигурационна система, базирана на среди – задаваме настройки според средата, в която работим (например development, staging, production).

Side-by-side версии на приложения – стартираме няколко версии едновременно, когато ни е нужно да тестваме или поддържаме съвместимост.

Инструменти, които улесняват съвременната уеб разработка (Visual Studio, VS Code, CLI) – използваме ги, за да ускорим и опростим процеса на писане и поддръжка на код.
## The MVC Pattern
Формулиран е за първи път в края на 70-те години от Trygve Reenskaug като част от езика Smalltalk – обектно-ориентиран език, от който можем да проследим много от съвременните концепции.

Поддържа повторна употреба на кода и ясно разделение на отговорностите – това ни позволява да изграждаме по-модулярни и поддържани приложения.

Първоначално е създаден за настолни приложения, но впоследствие е адаптиран за интернет среди – така можем да го прилагаме успешно и в уеб разработката.
## The Model-View-Controller (MVC) Pattern
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250412214520.png)

**Controller (Контролер)**

Обработва действията на потребителя и връща отговор – реагира на входящите заявки и генерира съответните резултати.

Обработва заявките с помощта на изгледи и модели – използва View и Model, за да оформи крайния отговор.

Представлява набор от класове, чрез които:  
– приема комуникация от потребителя  
– управлява цялостния поток на приложението  
– съдържа специфичната логика на приложението

Всеки контролер съдържа едно или повече „действия“ (Actions), чрез които се изпълняват конкретни функционалности при дадени заявки.

**Model (Модел)**

Набор от класове, които описват данните, които показваме в потребителския интерфейс (UI).  
Може да съдържа правила за валидиране на данните, за да се осигури тяхната коректност.

Съществуват два основни типа модели: 

1. View model / binding model  
   Съответства на потребителския интерфейс на уеб страницата чрез C# клас.  
   Използва се за прехвърляне на данни между View и Controller.  
   Част е от архитектурата на MVC и помага за управлението на формата на данните, с които взаимодействаме в потребителския интерфейс.

2. Database model / domain model
   Съответства на таблица в базата данни чрез C# клас, използвайки ORM (напр. Entity Framework).  
   Представя реалната структура на данните, които се съхраняват в базата.

**View (Изглед)**

Дефинира как потребителският интерфейс на приложението ще бъде показан – определя визуалното оформление и структура на приложението.

Може да поддържа главни изгледи (layouts) и под-изгледи (partial views или контроли) – използва се за създаване на по-сложни и многократни елементи на интерфейса.

В уеб приложения: шаблон за динамично генериране на HTML – осигурява начин за създаване на съдържание, което се обновява в зависимост от данните.
## MVC Steps
1. Входящата заявка се насочва към Контролер.

2. Контролерът обработва заявката и създава модел (view model).
	- Също така избира подходящия резултат (например: View).

3. Моделът се подава към изгледа (View).

4. View преобразува модела в подходящ изходен формат (HTML).

5. Генерира се отговор (HTTP Response).

**View** – User clicks a button  
**Controller** – Handles the event and converts it into a request  
**Model** – Executes the request and retrieves the data  
**Controller** – Passes the retrieved data to the view  
**View** – Displays the data to the user
## Web MVC Frameworks
Уеб MVC frameworks се използват за изграждане на уеб приложения.

Осигуряват структурата и енджина на MVC за изграждане на уеб приложения.  

Контролерите обработват HTTP GET / POST заявки и връщат изглед.  

Изгледите визуализират HTML + CSS, базирани на моделите.  

Моделите съдържат данни на приложението за изгледите, подготвени от контролерите.

**Примери за уеб MVC frameworks:**

ASP.NET Core MVC (C#), Spring MVC (Java), Express (JavaScript), Django (Python), Laravel (PHP), Ruby on Rails (Ruby), Revel (Go)
## ASP.NET Core MVC
ASP.NET Core MVC предоставя функционалности за изграждане на уеб API и уеб приложения.

Използва дизайнерския шаблон Model-View-Controller (MVC).

Лек е, с отворен код, лесен за тестване и с добра поддръжка от инструменти.

Използва Razor синтаксис за Razor Pages и MVC изгледи.

Поддържа изграждането на RESTful услуги чрез ASP.NET Core Web API.
- Има вградена поддръжка за множество формати на данни, съдържателно договаряне (content negotiation) и CORS.

Позволява постигане на висококачествена архитектура и оптимизиране на работата ни като разработчици.
- Прилага принципа „Конвенции пред конфигурации“, което означава, че следваме общи правила вместо да правим излишни настройки.

Механизмът за свързване на модела (model binding) автоматично картографира данни от HTTP заявки.

ASP.NET поддържа валидация на модели както от страна на клиента, така и от страна на сървъра. Основният принцип, който трябва да спазваме, е че **всички лъжат** — не бива да вярваме на никого, дори на себе си. Затова платформата ни предоставя възможност за двустепенна валидация: първо на клиента, после на сървъра.
Клиентската валидация служи основно за подобряване на потребителското изживяване (UX), но не е сигурна, защото се изпълнява от самия клиент. Той може да променя HTML и JavaScript кода, да премахне `required` полета или да заобиколи ограничения чрез инструменти като browser developer tools или Postman. Затова сървърната валидация е задължителна и единствената, на която можем да разчитаме за сигурна обработка на данните.

Често го комбинираме с Entity Framework за обектно-релационно съпоставяне (ORM).
### Features
ASP.NET Core предоставя **routing механизъм** за съпоставяне на HTTP заявки към контролери и действия. 

**Dependency Injection** се използва за инжектиране на компоненти по време на изпълнение, което улеснява модулността и тестването на приложенията.

С **Razor view engine** можем да създаваме **строго типизирани изгледи**, които комбинират C# код с HTML по ясен и подреден начин. 

**Model binding** автоматично свързва данните от HTTP заявките с C# модели, а **валидацията** се извършва както на клиента, така и на сървъра за по-голяма сигурност.

Чрез **Tag Helpers** можем да вграждаме сървърен код директно в HTML елементи. ASP.NET Core поддържа и мощни инструменти като **филтри**, **зони (Areas)** и **middlewares**, които осигуряват гъвкавост в изграждането на архитектурата.

Вградените **системи за сигурност** включват **ASP.NET Identity**, чрез която можем да управляваме потребители, роли и автентикация. Има още множество възможности, които подпомагат разработката на модерни и сигурни уеб приложения.
## Creating an ASP.NET Core MVC App
1. Създаваме нов проект във Visual Studio и избираме шаблона **ASP.NET Core Web App (Model-View-Controller)**.

2. Избираме желаната .NET версия. Ако искаме функционалност за потребителски акаунти, на `Authentication type` избираме **Individual Accounts** и маркираме **Configure for HTTPS**.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250413171321.png)
### Static files
Всички **статични ресурси** на приложението – JavaScript файлове, CSS стилове, изображения, икони и др. – се обслужват директно от уеб сървъра, **без да минават през контролери**.  
За да могат да се зареждат правилно, **в middleware pipeline-a** на приложението **трябва да добавим**:

```csharp
app.UseStaticFiles();
```
### `Program.cs`
Основният клас, чрез който се конфигурира приложението. Тук се задават настройките за **inversion of control container (IoC)**, конфигурира се **middleware pipeline-а**, и се стартира приложението. Имаме `builder`, който има пропърти `Services` – това е контейнерът за зависимостите (IoC), в който се регистрират услуги, включително `DbContext`. След като всички услуги са регистрирани (независимо в какъв ред), извикваме `builder.Build()`, за да изградим приложението.

След `Build()` започва конфигурирането на **middleware pipeline-а** – това е поредица от компоненти, които обработват HTTP заявките. Всеки ред в тази конфигурация има значение и редът на изпълнение е важен. Например, `app.UseAuthentication()` трябва да бъде извикан преди `app.UseAuthorization()`, за да може първо потребителят да бъде идентифициран (автентикация), и след това да му бъдат зададени права (авторизация). Ако тези две извиквания се разместят, `Identity` няма да функционира правилно. След като middleware-ите са конфигурирани, приложението се стартира с `app.Run()`.
### `appsettings.json`
Съдържа конфигурационни настройки за приложението, като например връзки към бази данни, логване и други параметри. Важно е да не се съхраняват чувствителни данни като пароли или API ключове в този файл, тъй като съдържанието му става публично при качване в GitHub. Разликата между този файл и **`secrets.json`** е, че **`appsettings.json`** се намира в директорията на проекта и се включва в source control системата, докато **`secrets.json`** се намира извън проекта – в потребителска папка на компютъра – и не се качва в source control. Проблемът при **`secrets.json`** е, че другите участници в проекта не разполагат с него по подразбиране, затова е необходимо да се измисли начин да им се предадат необходимите ключове и настройки – например чрез документ с инструкции или чрез използване на защитен vault.
### Areas 
Когато създадем ASP.NET Core MVC приложение с **Individual Accounts** (при избиране на тип автентикация), **Identity framework** се добавя автоматично. Той се намира в специална папка **`Areas/Identity`**, която следва архитектурата на Razor Pages. В тази папка се съдържат Razor страници (като Login, Register, Forgot Password и др.), чрез които се управляват потребителите, ролите и процесите по автентикация и авторизация.
### Controllers 
Папката, в която се съхраняват всички контролери на приложението. При създаване на проект с шаблона, по подразбиране имаме един контролер – `HomeController`. Контролер е клас, който наследява базовия клас `Controller`, като по конвенция името му завършва на `Controller` (например `ProductController`). Всеки публичен метод в него се нарича action – той обработва входящи HTTP заявки и връща отговор (обикновено HTML чрез View, JSON, redirect и други). Контролерите са отговорни за логиката на приложението – получават данни от модела и избират каква View да върнат на клиента.
Контролерът избира кое View да върне според името на action метода. По конвенция, в папката `Views` има подпапка с името на контролера (без наставката `Controller`), а в нея се намират `.cshtml` файловете с имената на съответните action-и. Например, `HomeController` с метод `Index()` ще върне View от `Views/Home/Index.cshtml`. Освен това, в метода може да се подаде и стринг с името на конкретното View, което да се върне, ако не следваме конвенцията за имената.

Ако контролерът не намери съответното View в папката с името на контролера, следващото място, където ще търси, е в папката **Shared**. Тази папка се използва, когато искаме да споделим дадено View между няколко контролера. В случай, че и там не бъде открито, ще бъде хвърлена грешка.

**Бизнес логиката** – това е основната логика на приложението, която описва какво то реално прави. Добра практика е тя да се изнася извън контролерите, защото ако остане в тях, контролерите стават твърде обемни и трудни за поддръжка. Вместо това, бизнес логиката се премества в отделни услуги (services), които се инжектират в контролерите чрез dependency injection. Това улеснява тестването, повторното използване на кода и подобрява структурата на проекта.
### Views
**View-то** има за цел да генерира HTML код, който се изпраща към браузъра. Макар че Razor view файловете не съдържат чист HTML, след като бъдат обработени от Razor View Engine-а, крайният резултат е валиден HTML. Основният шаблон за всички страници е файлът `_Layout.cshtml`, който дефинира общата структура на сайта – например header, footer, менюта и т.н. Всяко отделно view се вмъква в този шаблон чрез `@RenderBody()`.

Можем да подаваме променливи от view към layout файла чрез `ViewData`. Например, в `Index.cshtml` можем да зададем `ViewData["Title"] = "Начална страница";`, а в `_Layout.cshtml` да я покажем с `@ViewData["Title"]`. По този начин всяка страница може да задава собствено заглавие или други динамични стойности, които се показват в общия layout.

**`ViewData`** и **`ViewBag`** служат за предаване на данни от контролера към view-то, но се различават по синтаксис и тип:

- **`ViewData`** е речник (`Dictionary<string, object>`) и се достъпва чрез ключ: `ViewData["Title"]`.
    
- **`ViewBag`** е dynamic обект и се ползва с точкова нотация: `ViewBag.Title`.

И двете работят само по време на текущия HTTP request и не пазят данни между различни заявки. Реално правят едно и също, просто **`ViewBag`** е по-удобен за писане, а **`ViewData`** – по-подходящ, ако се използва в условия или цикли.
#### Razor View Engine
Razor синтаксисът съчетава HTML и C# код. Успява да се ориентира къде започва C# и къде е HTML. Ето как се използват различните конструкции:

1. **@{ }:** Използва се за блок с C# код. Вътре в тези скоби може да пишем C# логика, като променливи, цикли, условни изрази и т.н. Този код се изпълнява на сървъра преди генерирането на HTML. Вътре в блока може да смесваме C# код с HTML. Razor engine правилно интерпретира различията между C# логиката и HTML елементите.

```csharp
<div>
    @{
        string[] names = { "Ivan", "Maria", "Petar", "Anna" };

        foreach (var name in names)
        {
            <p>Your name is: @name</p>
        }
    }
</div>
```

2. **@ (без { }):** Това е C# expression. Използва се за внедряване на стойности директно в HTML. Може да бъде израз като променлива, метод или свойство, което връща стойност.

```csharp
<p>Добре дошли, @Model.UserName!</p>
```

Тук, `@Model.UserName` ще бъде изпълнен от сървъра и резултатът ще бъде поставен в HTML елемента `<p>`.

**Обобщение:**

- **@{ }:** Използва се за блокове с C# код (методи, цикли, променливи и т.н.).

- **@ (без { }):** Използва се за внедряване на резултати от C# изрази в HTML.

- Всичко останало без **@** е HTML код.

Това позволява динамично генериране на съдържание в HTML, като същевременно се използва мощността на C# за обработка на данни и логика.

В класическия ASP.NET се е ползвал синтаксиса `<%= DateTime.Now %>`, но в последствие е бил опростен.
### Dependencies
Показват зависимостите на проекта. Имаме **Frameworks**, които включват множество библиотеки, използвани от приложението. Вътре в един framework можем да видим всички включени библиотеки, които той използва. Освен тях, можем да добавим и допълнителни външни библиотеки според нуждите на проекта – те се изтеглят и съхраняват в папката **packages**.
## Controllers and Actions
### Controllers
Всички контролери трябва да се намират в папката **"Controllers"**. Това е приета конвенция в ASP.NET Core MVC и улеснява организацията и поддържането на проекта.

Имената на контролерите трябва да следват стандарта **{име}Controller** – например `HomeController`, `AccountController`, `ProductController` и т.н.

Всеки контролер трябва да **наследява класа `Controller`**, за да има достъп до всички MVC функционалности, като модели, изгледи и помощни методи.

Контролерите имат достъп до важни обекти като `Request`, `Response`, `HttpContext`, `RouteData`, `TempData` и други, които се използват за работа със заявките и състоянието на приложението.

Рутинг системата в ASP.NET Core избира подходящия контролер при всяка HTTP заявка, като съвпада URL пътя с имената на контролерите и техните действия (методи).

```csharp
public class UsersController : Controller
{
 public IActionResult All() => View(); // Mapped to URL "/Users/All"
}
```
### Actions
Action методите са крайната цел на всяка HTTP заявка в ASP.NET Core MVC приложението. Те съдържат логиката, която се изпълнява при достигане до даден URL адрес, и отговарят с резултат (например HTML изглед, JSON данни, пренасочване и др.).

Всеки **action** трябва да бъде **публичен метод** в контролера. Само публичните методи могат да бъдат достъпвани чрез уеб заявка – всички останали ще бъдат игнорирани от MVC рамката.

Action методите **не трябва да са статични**, защото се извикват върху инстанция на контролера, която се създава за всяка заявка.

Няма ограничения относно **типа на върнатата стойност** – action методите могат да връщат произволен тип, като `string`, `int`, `JsonResult`, `ViewResult` и други. Въпреки това, най-често връщат `IActionResult`, защото той предоставя гъвкав начин за връщане на различни типове резултати.

Използването на `IActionResult` позволява на един и същи метод да върне различен тип отговор в зависимост от логиката – например `View()` при успешна операция или `NotFound()` при липсващи данни.

```csharp
public IActionResult Details(int id)
{
 var viewModel = this.dataService.GetById(id).To<DetailsViewModel>();
 return this.View(viewModel);
}
```
#### Action Results
**Action Result** представлява **отговора на контролера към браузър заявка**. Това е обектът, който MVC рамката връща към клиента (браузъра), след като изпълни даден action метод.

Action резултатите **представляват различни HTTP статус кодове** – например `200 OK`, `404 Not Found`, `302 Redirect`, `500 Internal Server Error` и др. Те описват какъв е резултатът от обработката на заявката.

Всички Action резултати **наследяват базовия клас `ActionResult`**, който дефинира общото поведение за връщане на отговори в ASP.NET Core MVC. Някои от често използваните производни класове са:

- `ViewResult` – връща HTML изглед.

- `RedirectResult` / `RedirectToActionResult` – пренасочват към друг URL или action.

- `JsonResult` – връща данни във формат JSON.

- `ContentResult` – връща обикновен текст.

- `StatusCodeResult` – връща произволен HTTP статус код, например 404 или 500.


Използването на `IActionResult` или `ActionResult<T>` позволява лесно управление на различни типове отговори от един action метод.

| **Name**                  | **Framework Behavior**                              | **Helping Method**                                      |
| ------------------------- | --------------------------------------------------- | ------------------------------------------------------- |
| **StatusCodeResult**      | Returns an HTTP response result with a given status | `StatusCode()` / `Ok()` / `BadRequest()` / `NotFound()` |
| **JsonResult**            | Returns data in JSON format                         | `Json()`                                                |
| **RedirectResult**        | Redirects the client to a new URL                   | `Redirect()` / `RedirectPermanent()`                    |
| **RedirectToRouteResult** | Redirects to another action or controller’s action  | `RedirectToRoute()` / `RedirectToAction()`              |
| **ViewResult**            | Response is handled by the view engine              | `View()`                                                |
| **PartialViewResult**     | Returns a partial view                              | `PartialView()`                                         |
| **ContentResult**         | Returns a plain string literal                      | `Content()`                                             |
| **EmptyResult**           | No response, no content-type header                 | _(No method needed; return `new EmptyResult()`)_        |
| **FileContentResult**     | Returns the contents of a file from memory          | `File()`                                                |
| **FilePathResult**        | Returns the contents of a file by file path         | `PhysicalFile()`                                        |
| **FileStreamResult**      | Returns the contents of a file as a stream          | `File()`                                                |
#### Action Selectors
**Атрибути за контрол върху действията в контролерите (Actions):**

| **Атрибут**                      | **Описание**                                                                                       |
| -------------------------------- | -------------------------------------------------------------------------------------------------- |
| **`[ActionName(string name)]`**  | Позволява на метода да бъде извикан под различно име в рутинг системата.                           |
| **`[AcceptVerbs]`**              | Задава кои HTTP методи (GET, POST, PUT и др.) могат да достъпят дадено действие.                   |
| **`[HttpGet]`**                  | Посочва, че методът обработва **GET** заявки (по подразбиране).                                    |
| **`[HttpPost]`**                 | Посочва, че методът обработва **POST** заявки – използва се при изпращане на форма.                |
| **`[HttpDelete]`**               | Позволява на метода да обработва **DELETE** заявки – често използвано за изтриване на ресурси.     |
| **`[HttpOptions]`**              | Позволява на метода да отговаря на **OPTIONS** заявки, използвани често за конфигуриране на CORS.  |
| **`[NonAction]`**                | Указва, че методът **не е действие**, въпреки че е public, и не се използва в рутинг системата.    |
| **`[RequireHttps]`**             | Принуждава достъпа до метода да бъде само чрез HTTPS, осигурявайки защита.                         |
| **`[Authorize]`**                | Изисква потребителят да бъде автентикиран, за да може да изпълни действието.                       |
| **`[AllowAnonymous]`**           | Позволява на потребителите без автентикация да достъпват метода (противоположно на `[Authorize]`). |
| **`[ValidateAntiForgeryToken]`** | Защита срещу CSRF атаки, изисква наличието на валиден токен при изпращане на форма.                |

Тези атрибути осигуряват гъвкавост при управлението на поведението на методите в контролерите и тяхното взаимодействие със заявките в ASP.NET Core MVC.

Example:

```csharp
public class UsersController : Controller
{
    // Selectors' order doesn't matter
    [ActionName("UserLogin")]
    [HttpPost]
    [RequireHttps]
    public IActionResult Login(string username, string password)
    {
        return Content("Logged in!");
    }
}
```
#### Action Parameters
ASP.NET Core свързва данни от HTTP заявката с параметри на действия по няколко начина:

1. **Routing engine:**

Routing двигателя е отговорен за съвпадението на входящата заявка с конкретно действие на контролера.

Параметри могат да бъдат подадени директно чрез рутинния шаблон.

Пример:

```csharp
public IActionResult GetUserDetails(string username)
{
    return Content($"User: {username}");
}

// http://localhost/Users/Niki
```

**Routing pattern**: `/Users/{username}` ще свърже сегмента `{username}` от маршрута с параметъра `username` в действието.

**URL**: `/Users/ByUsername` автоматично ще подаде `ByUsername` като стойност на параметъра `username` в действието.

2. **Query String:**

 URL query string също може да съдържа параметри, обикновено се използват за GET заявки.

Пример:

```csharp
public IActionResult GetUserByUsername(string username)
{
    return Content($"User: {username}");
}

// http://localhost/Users/ByUsername?username=NikolayIT
```

3.  **HTTP POST Data:**

HTTP POST заявките могат да съдържат параметри в тялото на заявката.
## Views
**Views** са отговорни за рендирането на HTML кода, който се изпраща към браузъра.

**View naming**: Името на изгледа съвпада с името на действието и завършва с `.cshtml` (например, `Index.cshtml`).

**Views location**: Изгледите се поставят в папката `/Views/{ControllerName}` (например, `/Views/Home/Index.cshtml`).

**View engines**: Най-често използваният двигател е **Razor**, който позволява вграждане на C# код в HTML чрез синтаксис `@`.

**HTML Helpers**: Razor предоставя хелпери като `@Html.EditorFor()`, `@Html.ActionLink()` за лесно генериране на HTML елементи.
### Passing Data to a View
В ASP.NET Core MVC както `ViewBag`, така и `ViewData` се използват за предаване на данни от контролера към изгледа, но те се различават по начина на имплементация.

1. **`ViewBag`** (динамичен тип):

**Действие**: В контролера задаваме стойност на `ViewBag` като динамично свойство.

```csharp
ViewBag.Message = "Hello!";
```

 **Изглед**: В изгледа можем да достъпим свойството на `ViewBag` директно чрез `@ViewBag.Message`.

```csharp
@ViewBag.Message
```

2. **`ViewData`** (Речник):

**Действие**: В контролера задаваме стойност на `ViewData` чрез ключ-стойност.

```csharp
ViewData["message"] = "Hello!";
```

 **Изглед**: В изгледа достъпваме стойността на `ViewData` чрез ключа.

```csharp
@ViewData["message"]
```

И `ViewBag`, и `ViewData` в ASP.NET Core MVC могат да се разглеждат като динамични обекти, които се държат подобно на JavaScript обекти и могат да бъдат достъпвани по два начина – чрез скоби или точкова нотация, като също няма нужда от предварително дефиниране на типа на стойността или пропъртито.

**Основни разлики:**

- `ViewBag` е динамичен тип, което означава, че не е необходимо предварително да дефинираме неговите свойства.
- `ViewData` е речник (ключ-стойност), така че трябва да зададем ключа като стринг, когато присвояваме или извличаме стойности.

И двата подхода се използват за предаване на данни към изгледа, като основната разлика е в синтаксиса и начинът, по който се достъпват. `ViewBag` предлага по-гъвкав, динамичен подход, докато `ViewData` е по-структуриран с ключове в речника.
### Passing Data to a View - Strongly Typed
В ASP.NET Core можем да създадем **силно типизирано (strongly typed) View**, което получава конкретен модел (клас) от контролера. За целта първо си създаваме C# клас – например `CustomerViewModel`, който описва нужните данни. След това в контролера създаваме обект от този клас и го подаваме на `View()` метода.

Във View-то използваме директивата `@model`, за да укажем какъв тип данни очакваме. Така получаваме пълна IntelliSense поддръжка и компилационна проверка. Това е по-сигурен и структуриран начин за работа спрямо `ViewBag` или `ViewData`.

```csharp
// Models\CustomerViewModel.cs

public class CustomerViewModel
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

```csharp
// Controllers\CustomerController.cs

public IActionResult Show()
{
    CustomerViewModel customer = new CustomerViewModel()
    {
        Name = "Pesho",
        Age = 20
    };

    return View(customer);
}
```

```csharp
// Views\Customer\Show.cshtml

@model CustomerViewModel
@{ ViewBag.Title = "View Customer"; }

<h2>Current customer: @Model.Name (@Model.Age)</h2>
```

Така View-то работи директно с типизиран модел, вместо с динамични обекти. 
`@Model.Property` във View-то е **аналогично на достъп до инстанция на обект** в C#. `Model` е обектът (инстанцията), който сме подали от контролера чрез `return View(model)`, а `Property` е негово пропърти — например `Name`, `Age`, `Email` и т.н.
## ASP.NET Core MVC Routing
ASP.NET Core MVC използва middleware за **рутиране на клиентските заявки**.

ASP.NET Core MVC Routing

Рутингът описва **как пътищата от URL адреса** трябва да бъдат съпоставени към действия (Actions) в контролерите.

Съществуват два основни типа рутинг към Action методи:

- **Конвенционален рутинг (Conventional Routing)**
    
- **Атрибутен рутинг (Attribute Routing)**
### Conventional Routing
Нарича се "конвенционално", защото задава **конвенция** (стандартизиран шаблон) за URL адресите.

Използва се по подразбиране.

```csharp
routes.MapControllerRoute(
    name: "default",
    template: "{controller=Home}/{action=Index}/{id?}"
);
```

Този маршрут ще съвпадне с URL като `/Cats/Show/1`  
Ще извлече стойностите така:

```csharp
{
	controller = "Cats",
    action = "Show",
    id = "1"
}
```

Това означава, че заявката ще бъде насочена към `CatsController`, метод `Show`, със стойност на параметъра `id = 1`.
### Middleware
В ASP.NET Core **middleware** е компонент в _pipeline-а_ (верига от обработващи компоненти), който обработва HTTP заявки и отговори. Всеки middleware може да:

- провери, промени или прекрати заявката

- я предаде нататък към следващия middleware

**Routing Middleware** е точно такъв компонент, който **отговаря за разпознаването на URL адреса** и **намирането на подходящия контролер и негов метод (action)**, който трябва да отговори на тази заявка.

Примерен pipeline:  

`[HttpRequest] → Routing Middleware → MVC Middleware → Controller/Action → [HttpResponse]`

**Без Routing Middleware**, приложението няма да знае **кой контролер и действие да извика**, когато дойде заявка от браузъра.
## Dependency Injection
**Dependency Injection (DI)** е техника, при която обекти (зависимости) се предоставят на класовете **автоматично от системата** по време на изпълнение, вместо сами да ги създаваме.

Как става това в ASP.NET Core:

- **Регистрираме класа като услуга** в `Program.cs` (или `Startup.cs` при по-стари версии):

```
services.AddTransient<DataService>();
```

**Инжектираме го** в конструктора на контролера:

```csharp
public class ProductController : Controller
{
    public ProductController(DataService ds) {
        // Use the injected object "ds"
    }
}
```

Това позволява лесна поддръжка, тестване и слабо свързани компоненти.
## Model Binding
**Model binding** в ASP.NET Core MVC свързва данни от HTTP заявките с параметрите на action методите. Докато **Router-ът** определя кой action да се извика според URL-а, **Model Binder-ът** отговаря за попълването на неговите параметри със стойности от route, query string, формуляри и други източници на данни.

Параметрите могат да бъдат примитивни типове или сложни класове.

Това е имплементирано абстрактно, което позволява повторна употреба в различни приложения.

Фреймуъркът търси стойности за параметрите по **име** – първо по име на параметъра, а при класове – по имена на публичните set пропъртита.

Пример: 
URL заявка `https://mysite.com/posts/edit/6`

Action метод:

```csharp
public IActionResult Edit(int? id)
```

Тук `id = 6` ще бъде подадено автоматично.

Model binding може да проверява няколко източника на данни в рамките на една заявка – като route данни, query string, form полета и други.

Model binding може да търси стойности в няколко източника при всяка заявка:

Формови стойности – параметри от POST заявки.
Route стойности – стойностите, предоставени от Routing-а.
Query низове – параметри в URL-а.
Дори в headers, cookies, сесии и др. чрез custom model binders.
Данните от тези източници се съхраняват като двойки **име-стойност**.

Фреймуъркът проверява източниците в този ред, и ако не намери параметъра в един, преминава към следващия.
# Misc
# ChatGPT
## .NET as a Platform vs. Frameworks – Key Concepts and Relationship
**.NET is a platform**, not just a framework. It provides a complete development environment that includes a **runtime** (like the .NET CLR), various **tools** (such as compilers, debuggers, and IDEs), and a rich set of **libraries** (like the Base Class Library - BCL). It supports multiple **frameworks** for building different kinds of applications—such as **ASP.NET Core** for web development, **EF Core** for data access, and **MAUI** for cross-platform mobile and desktop apps.

A **framework** is typically a specialized set of **libraries** designed to help developers build specific types of applications. It operates within the platform. In general, frameworks are **collections of libraries** that enforce certain patterns and conventions. They often provide a structure to the application and call your code as part of the execution flow (inversion of control).

For example:

- **ASP.NET Core** is a web framework built on the .NET platform.
    
- **Entity Framework Core** is a framework for working with databases using ORM techniques.

In summary:

- **.NET** is a broad platform with tools, runtime, and libraries.
    
- **Frameworks** are focused tools built on top of the platform, essentially structured libraries designed for specific tasks.
## Views
Instead of using a static HTML file, we create a **View** (usually a `.cshtml` file) in ASP.NET Core MVC. This view still contains standard HTML, but it's processed by the **Razor view engine**, which allows us to embed C# code directly into the HTML.

This makes it much more flexible because we can:

- Dynamically insert values from the model or `ViewBag`/`ViewData`.
    
- Loop through collections (`foreach`, `for`).
    
- Add conditions (`if`, `else`).
    
- Reuse layouts and partial views.

So we get a dynamic, data-driven HTML output instead of a static file.
## `ViewData` / `ViewBag`
**In ASP.NET Core MVC:**

- **`ViewData`** and **`ViewBag`** are both used to pass data from the controller to the view.
    
- If you set the same variable in both the controller and the view, **the value set in the view will override the value set in the controller**.

**Here's how it works:**

**In the Controller:**

You can set values in `ViewBag` (or `ViewData`) inside your controller’s action method. For example:

```csharp
public IActionResult Index()
{
    ViewBag.Title = "Title from Controller";  // Set in Controller
    ViewBag.Message = "Message from Controller";  // Set in Controller
    return View();
}
```

**In the View:**

You can override these values in the view file itself:

```csharp
@{
    ViewBag.Title = "Title from View";  // Override in View
    ViewBag.Message = "Message from View";  // Override in View
}
```

**Example of Override Priority:**

- In the **controller**, you set `ViewBag.Title = "Title from Controller"`.
    
- In the **view**, you set `ViewBag.Title = "Title from View"`.

The final value used in the view will be `"Title from View"`, because **the view’s value takes priority**.

**Summary:**

- **Controller**: Sets default values for `ViewBag` and `ViewData`.
    
- **View**: Can override any values from the controller for that specific view.

This behavior applies to both `ViewData` and `ViewBag`. Therefore, if you set a value in both the controller and the view, **the view’s value will override the controller’s value**, whether you’re using `ViewBag` or `ViewData`.
## Custom Styles
When working with views in an ASP.NET Core MVC application—especially when using a framework like Bootstrap—there are typically two main approaches to applying custom styles to elements in your layout:

**1. Overriding existing framework classes**

Frameworks like Bootstrap come with predefined CSS classes (e.g., `border-bottom`, `navbar`, etc.). If you want to change how one of these behaves—like making a border red instead of its default—you can override it in your own CSS file, usually `site.css`. This works by using the exact same CSS selector but redefining its properties. To make sure your custom styles take priority over Bootstrap’s, you might need to increase specificity or use `!important` if necessary. This method is suitable when you want to globally change how a built-in class behaves across your app.

**2. Adding your own custom classes**

Another approach is to leave the Bootstrap classes as they are and simply add your own custom class to the element you want to style differently. You then define this new class in your CSS file and apply the desired styles. This is a cleaner approach when you only want to style a specific instance without affecting all other uses of the Bootstrap class throughout your site. It also makes your changes easier to manage and avoids conflicts with future updates to the framework.

Both methods are valid—it depends on whether you want to globally override default behavior or apply a local, more controlled style. In many real-world projects, developers use a combination of both approaches to keep things flexible and maintainable.
## Bootstrap
By default, ASP.NET Core MVC projects come with Bootstrap included when you create a new project using certain templates, like the Web Application template. Bootstrap is a popular front-end framework that helps with designing responsive and mobile-first websites quickly.

In the default template, you'll often see Bootstrap's CSS and JavaScript files included in the layout file (`_Layout.cshtml`). These files are typically loaded from the `lib` folder, which uses NuGet package management to retrieve and update Bootstrap. This allows developers to easily use the built-in Bootstrap classes for layout, styling, and responsive design features without having to manually download or configure the framework.

However, if you prefer, you can replace Bootstrap with another CSS framework or even use custom CSS by adjusting the references in your project. But, out-of-the-box, Bootstrap is the default.
## cshtml
**CSHTML files** are a way to combine **HTML** and **C#** logic in **ASP.NET Core MVC**. These files allow you to write **HTML for the structure and presentation**, while embedding **C# code** for dynamic behavior or data manipulation. This is achieved through a special syntax that blends both worlds.

**Key Points About CSHTML Files:**

1. **Combining HTML and C#**:
    
- You can write **standard HTML tags** to build the layout and content of the page.
        
- You can also insert **C# code** within the HTML using the `@` symbol. This allows you to work with C# variables, objects, and methods directly in the HTML structure.
        
2. **C# Code in Razor Syntax**:
    
- You use `@` to signal that the following code is C#.
        
- Razor allows you to **embed C# variables**, methods, and logic inside HTML. For example:
        
```csharp
<h1>@ViewBag.Title</h1>  <!-- Renders the Title passed from the controller -->
```
        
3. **Variables and Objects in CSHTML**:
    
- You can declare variables and set them in **C# code blocks** (e.g., using `@{ }`), and these can be used in your HTML layout.
        
- Razor code executes on the server side before the page is sent to the browser. This means that by the time the page reaches the client, **the C# code has already been processed**, and only the HTML is rendered.
        
4. **Razor and C# Objects**:
    
- Razor allows you to work with C# objects and **manipulate them dynamically**. For example, setting `ViewBag` or `ViewData` values directly within the Razor file:
        
```csharp
@{
    ViewBag.Title = "Title from View";  // This is C# code setting a value
    ViewBag.Message = "Message from View";  // Another C# variable
}
```
        
In this example:
    
- `ViewBag` is a **C# object** that you can modify in your view.
            
- You can then access these variables inside HTML:
            
```csharp
<h1>@ViewBag.Title</h1>  <!-- Renders "Title from View" -->
<p>@ViewBag.Message</p>  <!-- Renders "Message from View" -->
```
            
5. **Control Flow and Logic**:
    
- Razor allows you to add **logic in your views**, such as **loops** and **conditionals**, which isn't possible in pure HTML. For example:
        
```csharp
@if (ViewBag.IsLoggedIn)
{
    <p>Welcome, @ViewBag.UserName</p>
}
else
{
    <p>Please log in to continue.</p>
}
```
        
- Here, the Razor syntax (`@if`, `@else`) is used to inject logic directly into the HTML structure based on the values in `ViewBag`.

**Summary:**

**CSHTML files** are like **HTML templates** that integrate **C# code** using Razor syntax. They allow you to:

- **Embed dynamic data** into your static HTML (like variables, method calls, and logic).
    
- **Render C# objects**, such as `ViewBag`, `ViewData`, or model data, in the HTML.
    
- **Merge server-side logic and client-side presentation**, giving you a powerful way to create dynamic web pages.

Razor, the view engine used by **ASP.NET Core MVC**, handles the parsing and execution of C# code in these files, so you can focus on both **design and logic** in the same place.
# Bookmarks
[ASP.NET documentation | Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-9.0)

Completion: 14.04.2025