# General
## Authentication vs Authorization
**Удостоверяване (Authentication)**

Процесът на проверка на самоличността на потребител или компютър.

Предпоставка за оторизация, няма как да имаме оторизация без автентикация.

Въпроси: Кой си ти? Как го доказваш?

Удостоверяващи данни могат да бъдат парола, смарт карта, външен токен и др.

**Оторизация (Authorization)**

Процесът на определяне какво е позволено на потребителя да прави на компютър или мрежа.

Въпроси: Какво имаш право да правиш? Можеш ли да видиш тази страница?

Не можем да оторизираме потребител преди да го удостоверим.
## ASP.NET Core Identity
Това е система за удостоверяване и оторизация за ASP.NET Core. Можем да удостоверяваме и оторизираме потребителите, тоест да им разрешаваме да правят определени неща в нашата система. Най-лесният вариант е чрез роли, а по-сложният — чрез политики.

Поддържа ASP.NET Core MVC, Pages, Web API (JWT), SignalR.

Управлява потребителите, техните профили, вход/изход от системата, роли и други.

Управлява съгласието за бисквитки и съответствието с GDPR.

Поддържа външни доставчици за вход. Можем да използваме Facebook, Google, Twitter и други.

Системата поддържа работа с бази данни, Azure, Active Directory, Windows потребители и други.

Обикновено съхраняваме данните за ASP.NET Core Identity в релационна база данни.

Използваме Entity Framework Core за съхранение на данните.

Имаме известен контрол върху вътрешната структура на базата данни.
### Internal Database Schema
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250502181502.png)

**`AspNetUsers`**

Основната таблица е `AspNetUsers`, в която се съхраняват потребителите. Идентификаторът на таблицата е задължителен, а всичко останало може да бъде изтрито.

Имената се съхраняват в нормализиран вид, т.е. всички букви са или големи, или малки, за да се подобри бързината на търсенето.

В ASP.NET има готов механизъм за потвърждаване на имейли.

`ConcurrencyStamp` това е уникален идентификатор (обикновено GUID), който се използва за обработка на конкуренцията. Той помага да се избегнат проблеми при едновременни промени в базата данни, като гарантира, че само последната актуализация на данни ще бъде записана, ако има конфликти.

`SecurityStamp` това е стойност, която се използва за маркиране на състоянието на сигурността на потребителя. Той обикновено се променя при всяка значителна промяна в потребителския акаунт, като например при промяна на паролата или обновяване на информацията за потребителя. Това помага да се предотвратят сесии с изтекла автентикация, като например при отказ от сесия или за сигурност в процеса на удостоверяване.

`LockoutEnd`, `LockoutEnabled` и `AccessFailedCount` се използват за заключване на акаунта след прекалено много неуспешни опити за вход. Това осигурява защита срещу brute force атаки.

Ако искаме да свържем наша таблица с потребителската таблица `AspNetUsers`, трябва да добавим колона `UserId`, която да съхранява идентификатора на потребителя, и навигационно свойство от тип **`IdentityUser`** (или клас, който разширява `IdentityUser`, ако сме създали такъв, примерно `ApplicationUser`), за да реализираме връзката между двете таблици. Няма нужда да се създава навигационна колекция в `AspNetUsers`, тъй като по подразбиране таблицата за потребители (`AspNetUsers`) не съдържа колекции от свързани обекти.

**`AspNetRoles`**  
Съдържа ролите, които могат да бъдат присвоени на нашите потребители.

Всеки потребител може да има множество роли, като връзката между потребители и роли е от тип много към много.

**`AspNetRoleClaims`**  
Всяка роля може да съдържа клеймове. Това означава, че когато даден потребител получи определена роля (например „Администратор“), той автоматично получава и клеймовете, свързани с тази роля.

**`AspNetUserClaims`**  
Клеймове могат да бъдат задавани и директно на потребителя, без да е необходимо да минават през роля.

**`AspNetUserLogins`**  
Тази таблица е необходима за външните провайдъри. Когато потребител се впише чрез външен провайдър, системата използва тази таблица, за да направи съпоставяне по име и ключ на провайдъра.

Външен провайдър означава външна услуга, чрез която потребителите могат да се вписват (логват) в нашето приложение, вместо да използват локална регистрация с потребителско име и парола.

Примери за външни провайдъри са: Google, Facebook, Microsoft, Twitter, GitHub, Apple и тн.

Когато потребител избере да се впише чрез външен провайдър, приложението ни го пренасочва към съответния сайт (напр. Google), където той потвърждава самоличността си. След това външният провайдър ни връща потвърдена информация (напр. имейл), която използваме, за да създадем или заредим потребителски профил.

Това улеснява входа за потребителите и премахва нуждата да запомнят нова парола.

**`AspNetUserTokens`**  
Таблица за съхранение на токени. Въпреки това, по принцип не е препоръчително токените да се съхраняват в базата.
### System Setup
Добре е, когато създаваме ASP.NET проекта, да изберем `Authentication type` => `Individual Accounts`, което ще активира Identity, след което можем лесно да го персонализираме. Добавянето на Identity впоследствие, след като проектът вече е създаден е по-трудно.

Може да се направи и ръчно. Тогава трябва да инсталираме нужните NuGet пакети, да направим конфигурациите.

Необходимият NuGet пакет е: `Microsoft.AspNetCore.Identity.EntityFrameworkCore`.

Когато изберем Identity, out of the box получаваме папка `Data` с файла `ApplicationDbContext.cs`, който отговаря за нашата база данни. Той наследява `IdentityDbContext`, където се намират таблиците на Identity, и това е достатъчно, за да можем да достъпваме данните на нашите потребители. Създава се и папка `Migrations`, в която се намира миграцията, създаваща необходимите таблици.
### Template Authentication
**`ApplicationDbContext.cs`**

Съдържа EF data context-а.

Осигурява достъп до данните на приложението чрез моделни обекти.

Принципно не би трябвало да използваме Identity таблиците директно чрез контекста. Контекстът трябва да се използва само за достъп до нашите собствени таблици. Таблиците на Identity не се достъпват директно, а чрез специални помощни класове, наречени мениджъри.

**`Program.cs`**

Може да конфигурираме автентикация чрез бисквитки (или JWT). Има предварителна настройка, но се налага да направим допълнителни настройки.

Може да активираме вход чрез външни провайдъри (напр. Facebook).

Можем да променяме настройките по подразбиране на Identity.

Password settings:

```csharp
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    // Password, lockout, emails, etc.
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 10;
}).AddEntityFrameworkStores<ApplicationDbContext>();
```

Тези настройки могат да бъдат изнесени в конфигурационен файл като например `appsettings.json`, за да не се налага спиране на приложението, ако се правят промени.

По подразбиране `SignIn.RequireConfirmedAccount = true`, но докато разработваме нашето приложение, няма реален механизъм, който да изпраща мейли. Поради това, след като създадем акаунт, не можем да се впишем. Освен да изключим тази настройка за цялото приложение, при регистрация на акаунт се показва линк, чрез който можем автоматично да потвърдим акаунта. Този линк е добавен само за етапа на разработка и трябва да бъде премахнат, когато приложението премине в продукционна среда.
## Scaffolding Identity
### Razor Pages
Razor Pages в ASP.NET Core се различават от традиционния MVC модел, като в тях не се използва контролер за всяка страница. Вместо това, всяка Razor Page (с разширение `.cshtml`) има свързан `.cshtml.cs` файл, който изпълнява ролята на контролер.

По същество, Razor Page е комбинация от изглед (view) и код-бихейвиор (code-behind). Тази структура позволява на логиката за обработка на заявките да бъде интегрирана директно с изгледа.

- `.cshtml` файлът съдържа HTML и Razor синтаксис, както и компоненти за визуализиране на данни.
- `.cshtml.cs` файлът съдържа код, който обработва HTTP заявките и връща резултати (обработване на формуляри, извличане на данни от база данни и т.н.).

Когато използваме Razor Page, реално имаме два файла: един за визуализация (`cshtml`) и един за логиката (`cshtml.cs`), като втората част съдържа логиката, която обикновено би била в контролера в класическите MVC приложения.

Това прави Razor Pages по-малко зависими от контролери и предоставя по-интуитивен начин за структуриране на приложения, особено когато не е нужно разделение на логиката между множество контролери и изгледи.
### Scaffolding ASP.NET Core Identity
От ASP.NET Core 2.2, Identity е предоставен като Razor Class Library. Това означава, че част от функционалността за удостоверяване и оторизация е обвита в Razor библиотека, която може да бъде използвана в приложенията. 

В ASP.NET Core Identity страниците се намират в библиотеката Razor Class Library и не могат да се променят директно, освен ако не използваме процеса на "scaffolding" (генериране на код).

Процесът на scaffolding позволява да генерираме и персонализираме Identity страниците (като логин, регистрация, потвърждение на имейл, и т.н.) според нуждите на нашето приложение. Ето как работи процесът:

1. Щракваме с десен бутон върху проекта в **Solution Explorer**.

2. Избираме **Add** -> **New Scaffolded Item**.

3. В отвореното меню избираме **Identity**.

4. Трябва да посочим **DbContext** клас, който да използва страниците, кои точно Identity Razor страници искаме да добавим (можем да изберем всички или да посочим конкретни), както и да изберем **Layout** файл.

5. След като завърши процесът на scaffolding, избраните Razor Pages ще се появят в директорията **Areas/Identity/Pages/Account**.

След като сме добавили и персонализирали тези страници, можем да ги променяме както искаме. В този процес се генерират файлове за изгледите и код-бихейвиора, които можем да модифицираме спрямо изискванията на проекта.

С помощта на скелетния генератор (scaffolder) може да бъде конфигуриран за генериране на изходен код. Това е полезно, ако трябва да променим или персонализираме част от логиката, свързана с Identity.

Повечето от необходимите кодови структури за Identity се генерират автоматично чрез скелетния генератор, като това улеснява внедряването и настройката на потребителската автентикация и оторизация.
## `IdentityUser`
### Extending Identity Models
В ASP.NET Core не работим директно с Identity таблиците в базата. Вместо това използваме специализирани мениджъри:

- `UserManager<TUser>` – за управление на потребителите.
- `SignInManager<TUser>` – за логване и излизане от системата.
- `RoleManager<TRole>` – за работа с роли.

Чрез техните методи можем да:

- създаваме, намираме, променяме или изтриваме потребители.
- проверяваме пароли, добавяме роли и т.н.

Макар че имаме достъп до таблиците, **не трябва да ги променяме директно**, а да използваме тези мениджъри.
### Customizing `IdentityUser`
По подразбиране ASP.NET Core Identity използва класа `IdentityUser`, който **отговаря на таблицата `AspNetUsers`** в базата. Ако искаме да добавим нови полета към потребителите (например **име**, **фамилия** и тн), трябва да си създадем собствен клас:

```csharp
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [MaxLength(255)]
    [Comment("The first name of the user.")]
    public string? FirstName { get; set; }

    [PersonalData]
    [MaxLength(255)]
    [Comment("The last name of the user.")]
    public string? LastName { get; set; }
}
```

- **Името на класа може да е произволно**, важното е да **наследява `IdentityUser`**.

След това трябва да го регистрираме:

- В `Program.cs`:

```csharp
builder.Services.AddDefaultIdentity<ApplicationUser>(...)  
```

- В `ApplicationDbContext`:

```csharp
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
```

>[!WARNING]
>Ако планираме да направим scaffold на базовите Identity страници и същевременно искаме да разширим Identity таблиците (напр. с `ApplicationUser`), трябва първо да направим разширението, а чак след това да изпълним scaffolding-a.
>
>Когато първо направим scaffold преди да създадем `ApplicationUser`, автоматично генерираният код използва `IdentityUser`. Ако след това променим DI конфигурацията да използва `ApplicationUser`, ще възникнат **грешки при внедряване на зависимости (dependency injection)**, защото ASP.NET вече не знае как да подаде `UserManager<IdentityUser>`, а в системата съществува само `UserManager<ApplicationUser>`.
### Customizing Other Identity Tables
Ако искаме да **разширим и други Identity таблици** (напр. роли, claim-и, login-и), трябва да използваме пълната форма на `IdentityDbContext`, която приема повече generic параметри:

```csharp
public class ApplicationDbContext : IdentityDbContext<
    ApplicationUser,       // User
    ApplicationRole,       // Role
    string,                 // Primary key type
    IdentityUserClaim<string>,
    IdentityUserRole<string>,
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
```

- В този случай можем да създадем и собствен клас `ApplicationRole : IdentityRole` и да добавим допълнителни свойства (напр. описание на ролята).

Това е необходимо **само ако искаме да модифицираме други Identity таблици**, не само `AspNetUsers`.

>[!IMPORTANT]
>Ако разширяваме само `AspNetUsers`, ползваме `IdentityDbContext<ApplicationUser>`.  
>Ако разширяваме друга таблица, дори само една (например `AspNetRoles`), трябва да преминем към пълната форма с всички generic типове.
### `AddDefaultIdentity<TUser>()` vs `AddIdentity<TUser, TRole>()`
Разликата между `AddDefaultIdentity<TUser>()` и `AddIdentity<TUser, TRole>()` е **ключова**, когато решаваме дали ще разширим само `AspNetUsers` или и други Identity таблици.

1. **Ако разширяваме само `AspNetUsers`**

```csharp
builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    // options.Password.RequireDigit = ...
})
.AddEntityFrameworkStores<ApplicationDbContext>();
```

`AddDefaultIdentity<TUser>()` е **съкратен вариант**, удобен когато **разширяваме само потребителите**.

2. **Ако разширяваме и други таблици** (напр. `AspNetRoles`, `UserClaims` и т.н.)

**Не можем да ползваме `AddDefaultIdentity()`** – трябва да преминем към:

```csharp
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
    // options.Password.RequireDigit = ...
})
.AddEntityFrameworkStores<ApplicationDbContext>()
```

`AddIdentity<TUser, TRole>()` е **по-гъвкав**, когато имаме нужда да работим с повече от една Identity таблица.
### GDPR и лични данни
- Добра практика е **допълнителните полета да не са задължителни**, за да могат лесно да се премахват при GDPR заявки, като може чрез програмна логика да задължаваме потребителя да ги въведе.
- Слагаме атрибута `[PersonalData]` на полетата, които се считат за лични – така те ще се изтриват автоматично при изискване за „правото да бъдеш забравен“.
- Можем да добавим и `[Comment("...")]`, за да опишем предназначението на полето – тази информация се използва при създаване на базата.
## Accessing Identity via Managers
Идеята на мениджърите е, че когато искаме да достъпваме данни от Identity базата, не го правим директно през `DbContext`, а използваме методите на съответния мениджър. Те предоставят подходящи методи, които са изградени така, че да предотвратят възможни проблеми при манипулирането на данни.

**Не е необходимо ръчно да добавяме `UserManager`, `SignInManager`, `RoleManager` и подобни в `builder.Services`** — те се регистрират автоматично при извикване на `AddIdentity` или `AddDefaultIdentity`.

Списък с налични методи се намира във файла за ASP.NET в папката с ресурси.

**User Manager:**

Предоставя множество методи за управление на потребителите в база данни.  

**SignIn Manager:**

Използва се, когато трябва да се направи login или logout на потребител. Освен това предоставя редица допълнителни функционалности — например:

- Проверка дали даден потребител е в определена роля.
- Потвърждение на имейл.
- Промяна и нулиране (reset) на парола.
- Управление на състоянието на вход.

**Role Manager:**

Използва се за управление на роли в приложението — създаване, изтриване, преименуване и проверка за съществуване на роли.
### Check the Currently Logged-In User
Може да проверим дали даден потребител е логнат, чрез атрибута `[Authorize]`. 

```csharp
// GET: /Account/Roles (for logged-in users only)
[Authorize]
public async Task<ActionResult> Roles()
{
    var currentUser = await userManager.GetUserAsync(this.User);
    var roles = await userManager.GetRolesAsync(currentUser);
    // Additional logic for roles...
}

// GET: /Account/Data (for logged-in users only)
[Authorize]
public async Task<ActionResult> Data()
{
    var currentUser = await userManager.GetUserAsync(this.User);
    var currentUserUsername = await userManager.GetUserNameAsync(currentUser);
    var currentUserId = await userManager.GetUserIdAsync(currentUser);
    // Additional logic for user data...
}
```
### Authorization
`[Authorize]` -  Позволява достъп само на автентикирани потребители. Може да се приложи както на контролер, така и на отделни действия, за да се ограничи достъпът само за логнати потребители.

`[AllowAnonymous]` - Позволява достъп на анонимни потребители (т.е. потребители, които не са логнати), като се използва за действия, които трябва да са достъпни без логване, като например логин страница.

```csharp
// The controller is accessible only to authenticated users
[Authorize]
public class AccountController : Controller
{
    // This action is accessible to anonymous users
    // GET: /Account/Login (for anonymous users)
    [AllowAnonymous]
    public async Task<IActionResult> Login(string returnUrl)
    {
        // Logic for login...
        return View();
    }

    // This action is accessible only to logged-in users
    // POST: /Account/LogOff (for logged-in users only)
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        // Logic for logging out...
        return RedirectToAction("Index", "Home");
    }
}
```

**Обяснение на примера:**

- **[Authorize]**: Прилагаме го към контролера, което означава, че всички действия в контролера изискват автентикация, освен ако не е указано друго.

- **[AllowAnonymous]**: Прилагаме го към действието `Login`, което позволява достъп до логин страницата без изискване за логване. По този начин можем да контролираме кои действия са публични, а кои изискват вход.

Когато изискваме потребителят да бъде логнат, получаваме самия `User`, но той не е пълен. Типът му е `ClaimsPrincipal`, а не `IdentityUser`. Ако искаме достъп до всички пропъртита на потребителя, можем да използваме метода `GetUserAsync()`:

```csharp
public async Task<IActionResult> Privacy()
{
    // Get the current ClaimsPrincipal object (authenticated user)
    var user = this.User;

    // Retrieve the full IdentityUser object (with all properties like email, user ID, etc.)
    var identityUser = await userManager.GetUserAsync(user);

    // You can now access properties of IdentityUser like identityUser.Email, identityUser.UserName, etc.

    return View();
}
```

Тази структура е стандартен начин за управление на достъпа в ASP.NET Core приложения.
# Misc
# ChatGPT
## Razor Pages
Razor Pages is a **server-side** programming model in **ASP.NET Core**. It combines the **view** (`.cshtml`) with its corresponding **logic** (in a C# class). The core idea is that each page has its own **logic** and **UI** bundled together, so it's easier to work with in scenarios where you don’t need the full overhead of the MVC (Model-View-Controller) pattern.

So, while a **Razor Page** refers to the **`.cshtml` file**, it's **tightly coupled** with a **PageModel** (C# class) that contains the logic for handling requests to that page.

**Key Concepts of Razor Pages:**

1. **Razor Page (`.cshtml`)**: This is the view, just like an MVC view, and contains HTML mixed with Razor syntax (to make it dynamic). However, the main difference is that this view is tied to a specific **PageModel**, not a controller.
    
2. **PageModel (`.cshtml.cs`)**: This is the C# class that contains the logic (like what happens when the page loads or when a form is submitted). The PageModel acts like a **controller** but is directly tied to a specific page.

**How Does Razor Pages Work?**

1. **Request to a URL**: When a user visits a page, like `/Product/Details`, the server looks for a Razor Page in the `Pages` directory, such as `Pages/Product/Details.cshtml`.
    
2. **PageModel Class**: If the Razor Page exists, ASP.NET Core looks for a **PageModel class** associated with it. The class will be named `DetailsModel` if the page is `Details.cshtml`. This class contains methods like `OnGet()` for handling GET requests or `OnPost()` for handling POST requests.
    
3. **Binding Data**: The **PageModel** class can receive data (like form submissions or route parameters), process it, and provide it to the view. For example, it can receive an `id` from the URL query string (`/Product/Details?id=1`), fetch data, and pass it to the Razor view for rendering.
    
4. **Rendering the View**: The Razor view (`Details.cshtml`) is rendered with any dynamic data (from the PageModel) and returned to the browser.

**Comparing Razor Pages to MVC**

|**Aspect**|**Razor Pages**|**MVC (Model-View-Controller)**|
|---|---|---|
|**Routing**|Routes to a file (e.g., `/Product/Details`)|Routes to a controller action (e.g., `HomeController.Index`)|
|**Logic and View**|Logic is in the `PageModel` (same folder)|Logic is in the controller (separate from the view)|
|**File Structure**|`.cshtml` (view) + `.cshtml.cs` (logic)|`.cshtml` (view) + controller (logic)|
|**Page-specific logic**|Each page has its own `PageModel` for handling logic|Logic is shared across multiple views (controllers)|
|**Data Binding**|Uses `@Model` to bind data from the PageModel|Uses `ViewModel` or `ViewBag` to bind data to the view|

**Example Walkthrough of Razor Pages**

Let’s walk through a basic example of a Razor Page.

**File Structure:**

```css
Pages/
├── Product/
│   ├── Details.cshtml          ← Razor Page (UI)
│   └── Details.cshtml.cs       ← PageModel (logic)
```

`Details.cshtml` (View):

```csharp
@page
@model DetailsModel

<h1>Product Details</h1>
<p>Product ID: @Model.ProductId</p>
```

`Details.cshtml.cs` (PageModel):

```csharp
public class DetailsModel : PageModel
{
    // This property will be automatically populated with data
    public int ProductId { get; set; }

    // The OnGet method handles GET requests
    public void OnGet(int id)
    {
        // Simulate fetching data based on 'id'
        ProductId = id;
    }
}
```

**The Flow:**

1. **When a user visits `/Product/Details?id=5`:**
    
    - The Razor Page `Details.cshtml` is rendered.
        
    - The `DetailsModel` class is used to handle the request.
        
    - The `OnGet` method receives the `id` parameter from the URL and assigns it to `ProductId`.
        
    - `ProductId` is then available in the Razor view (`Details.cshtml`), and the page shows "Product ID: 5".

**Key Points to Remember:**

- Razor Pages are like **MVC Views**, but each page has its own **logic** and **view** bundled together in the same folder.
    
- Instead of having a separate controller and view, the logic for handling requests (like processing a form or reading a URL parameter) is handled in a **PageModel** class, which is closely associated with a specific Razor Page.

**Conclusion:**

So, to summarize:

- **Razor Pages** **are** `.cshtml` files, but they're not static like regular HTML files. They combine both **dynamic logic** (handled by the `PageModel`) and **UI** (the Razor view) into one cohesive page.
    
- The **PageModel** class contains the logic (like receiving parameters, processing data, etc.), and it’s tied directly to the Razor Page itself.
## Razor Pages Model Structure
In **Razor Pages**, models are typically declared **inside the `PageModel` class itself**, such as with `InputModel` for form binding. This differs from **MVC**, where models (especially view models) are usually defined in **separate classes**, encouraging a more modular structure. Razor Pages favor a more **page-centric** and **self-contained** approach.

**Example:**

```csharp
[BindProperty]
public InputModel Input { get; set; }

public class InputModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
```

**✅ Key Differences from MVC:**

| Aspect             | Razor Pages                            | MVC                                                    |
| ------------------ | -------------------------------------- | ------------------------------------------------------ |
| **ViewModel**      | Often nested inside `PageModel`        | Usually a **separate class** in a `ViewModels` folder  |
| **Binding**        | Uses `[BindProperty]`                  | Uses method parameters or `[Bind]`, `[FromForm]`, etc. |
| **File structure** | `.cshtml` + `.cshtml.cs` in one folder | `.cshtml` view + Controller action elsewhere           |
| **Approach**       | Page-focused (one page = one handler)  | Controller-focused (routes to actions)                 |

**🔍 Why Razor Pages Do This**

The goal of Razor Pages is **simplification**. Instead of having a separate controller and a separate view model file, you often keep the model and logic **together** — more like a "code-behind" model in WebForms or Blazor.

Would you like an example where we refactor the `InputModel` out into a separate class, as in traditional MVC?
## `UserManager<TUser>` is like a service layer
You can think of `UserManager` as a **built-in service class** provided by ASP.NET Core Identity. Just like you'd create your own service class to encapsulate business logic for an entity (e.g., `ProductService` for `Product`), `UserManager` encapsulates all the logic related to **managing users**.

**What `UserManager` does:**

It handles:

- Creating users (`CreateAsync`)
    
- Updating users
    
- Deleting users
    
- Adding/removing roles
    
- Managing claims
    
- Checking passwords
    
- Confirming emails
    
- And much more...

All this is done **through abstraction** — it talks to the database under the hood via EF Core, so **you don’t have to manually write queries**.

**In short:**

- **Controller** → calls → **UserManager** → performs logic and database operations.
    
- You don’t touch the `DbContext` directly for user management.
    
- `SignInManager` is a similar service, but for **login/authentication logic**.
# Bookmarks
[Introduction to Identity on ASP.NET Core | Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=visual-studio)

Completion: 03.05.2025