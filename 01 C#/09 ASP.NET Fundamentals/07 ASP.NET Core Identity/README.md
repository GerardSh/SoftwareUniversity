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
    
- `SignInManager` is a similar service, but for **login/authentication logic.**
## Razor Pages vs MVC Controllers
✅ **What’s the Same:**

- **Model Binding**: Both Razor Pages and Controllers use model binding to map form values to C# objects.
    
- **Validation**: Both support `ModelState`, data annotations, and validation errors.
    
- **Return Views**: Both return views (`View()` or `Page()`) that use the provided model.

❗️**What’s Different:**

1. **Where the Model Ends Up**

- **In Razor Pages**:
    
- You typically define a property like:
        
```csharp
[BindProperty]
public RegisterInputModel Input { get; set; }
```
        
- The framework binds the form data _directly to this property_.
        
- When you return `Page()`, the Razor view gets the entire `PageModel` instance — so `@model` refers to the class containing `Input`.
        
- **In MVC Controllers**:
    
- You usually pass the model as a method parameter:
        
```csharp
public IActionResult Register(RegisterInputModel model)
```
        
- If validation fails, you need to return the view with:
        
```csharp
return View(model);
```
        
- If you don’t pass it manually, the view has no way of knowing what model to use.

2. **Return Value Mechanics**

- `return Page();` in Razor Pages automatically gives the view access to `this` (i.e., the PageModel instance and its properties).
    
- `return View();` in MVC needs a model to be explicitly passed (unless you're using `ViewBag` or `ViewData`).

🧠 **Summary**

|Feature|Razor Pages|MVC Controllers|
|---|---|---|
|Where model is stored|As a property on `PageModel`|As a parameter in action method|
|Model binding target|Bound to `[BindProperty]` field|Bound to method parameter|
|How model reaches the view|Via `PageModel` (`@model`)|Must pass explicitly to `View()`|
|Code + View separation|Mixed (code-behind + view)|Separated (Controller + View)|

_Conceptually_ they do the same thing, but Razor Pages streamline the pattern by tightly coupling the model and view into one unit.
## Razor Pages Routing
**Razor Pages do _not_ use the `MapControllerRoute` mapping**.

Here’s the breakdown:

✅ **Razor Pages**

- **Routing is file- and folder-based**.
    
- Defined by:
    
    - The physical location of `.cshtml` files inside the `Pages` or `Areas/.../Pages` folder.
        
    - The `@page` directive (which can also accept a route template, like `@page "{id?}"`).
        
- Razor Pages routing is enabled by calling:

```csharp
app.MapRazorPages();
```

- `MapControllerRoute` **does not affect Razor Pages** at all.

✅ **MVC Controllers**

- Routing is defined by templates like:

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

- This is used **only** for controllers and their actions.

**In short:**

|Feature|Razor Pages|MVC Controllers|
|---|---|---|
|Uses `MapControllerRoute`?|❌ No|✅ Yes|
|Uses `MapRazorPages()`?|✅ Yes|❌ No|
|Routing based on file structure?|✅ Yes|❌ No|
|Uses `[Controller]` + `[Action]`?|❌ No|✅ Yes|

So if you’re using Razor Pages and want to use custom route parameters, they must be defined directly using `@page` in the `.cshtml` file — **the MVC route map won't apply**. The **Area** is like the **Controller**, and the **Page** is like the **Action** in the MVC world.

**To Recap:**

- **Area** = **Controller** in MVC (group of related pages).
    
- **Page** = **Action** in MVC (a specific page that handles a route).

This analogy helps you map out how to work with both Razor Pages and MVC within your application.
## Generic Type Specialization with Defaults
In ASP.NET, `IdentityUser` uses `string` as the default key type. Since it's actually a generic class, why don't we write `IdentityUser<string>` instead of just `IdentityUser`?

**ChatGPT said:**

Excellent question — you're thinking about this **very precisely**, and you’ve spotted something many overlook.

Let’s break it down clearly:

🧱 **`IdentityUser` – What's Actually Going On?**

Yes, you're right:  
By default, `IdentityUser` **uses a `string` as the primary key type** — but it’s done **via inheritance**.

Here’s what actually happens under the hood:

```csharp
public class IdentityUser : IdentityUser<string>
{
    public IdentityUser() : base() { }
}
```

So `IdentityUser` is a _convenience class_ that simply wraps the generic `IdentityUser<TKey>` with `string` as the default key.

That’s why **you don’t need to write `IdentityUser<string>`** — because the framework **already provides that as `IdentityUser`**.

🧩 **Custom Key Types (like `Guid`)**

If you want to change the key type (e.g., to `Guid`), you then **have to drop the convenience wrapper** and explicitly write:

```csharp
public class ApplicationUser : IdentityUser<Guid>
{
    // Add your custom props
}
```

And then your context must match:

```csharp
public class WarehouseDbContext 
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    // ...
}
```

🧠 **Summary**

|Goal|Inherit From|Why|
|---|---|---|
|Use string as primary key (default)|`IdentityUser`|It wraps `IdentityUser<string>`|
|Use custom key like `Guid`|`IdentityUser<Guid>`|You must specify the key explicitly|
|Same applies to roles and context|`IdentityRole<Guid>`, etc.|Everything must use the same key|

So your insight is spot-on:

> `IdentityUser` is just a shorthand for `IdentityUser<string>`, and when you use other types like `Guid`, you must write it explicitly.

**You said:**

We have an identity class which inherits from the generic identity class and provides a concrete implementation of it — string. Basically `IdentityUser` is a concrete class that inherits from the generic `IdentityUser<TKey>` with `string` as the default key. When we want a different key type, like `Guid`, we use the generic version. But how can both classes have the same name?

**ChatGPT said:**

Gerard — that is _an excellent observation_. Let's unpack this in a clear and complete way.

✅ **You're Exactly Right:**

> “We have an identity class which inherits from the generic identity class and provides a concrete implementation of it — string.”

Yes! That’s exactly what this is doing:

```csharp
public class IdentityUser : IdentityUser<string>
{
    public IdentityUser() : base() { }
}
```

❓**But... How Do They Have the Same Name?**

This might seem like a naming conflict at first, but it **doesn’t break anything**, because of how **.NET generics and type overloading** work.

Here’s the key:

- `IdentityUser` → non-generic class
    
- `IdentityUser<TKey>` → _generic_ class

.NET (C# specifically) **treats them as two separate types** internally:

|Type Syntax|Treated As Internally|
|---|---|
|`IdentityUser`|`IdentityUser` (arity = 0)|
|`IdentityUser<TKey>`|`IdentityUser` (arity = 1)|

This is called **type overloading by arity** — where `IdentityUser` and `IdentityUser<T>` are different symbols because they have different _numbers of generic parameters_.

So C# allows:

```csharp
public class IdentityUser : IdentityUser<string> { }
public class IdentityUser<TKey> { /* generic base */ }
```

Even though they look like the “same name,” the compiler sees one as:

- `IdentityUser` (no generics), and
    
- the other as `IdentityUser<T>` (one generic).

🧠 **Real-World Analogy**

Think of this like method overloading:

```csharp
void Print() { }
void Print(string message) { }
```

Different parameters = different methods.

Same with types: different _generic arity_ = different types.

✅ **In Summary**

- `IdentityUser<TKey>` is the base class.
    
- `IdentityUser` is a convenience class that just sets `TKey = string`.
    
- They can both exist because C# treats them as different due to arity (generic parameter count).

**You said:**

So `IdentityDbContext` is a generic type with different type parameters — it's essentially using generic overloading through inheritance.

**ChatGPT said:**

Yes — exactly right!

`IdentityDbContext` is a **generic class**, and just like `IdentityUser`, it uses **type overloading by arity**.

There are several overloads like:

```csharp
public class IdentityDbContext : IdentityDbContext<IdentityUser>
public class IdentityDbContext<TUser> : IdentityDbContext<TUser, IdentityRole, string>
public class IdentityDbContext<TUser, TRole, TKey> : DbContext
```

Each layer provides more customization:

- **`IdentityDbContext`** → default `IdentityUser`, `IdentityRole`, and `string` key
    
- **`IdentityDbContext<TUser>`** → custom user class
    
- **`IdentityDbContext<TUser, TRole, TKey>`** → full control over user, role, and key type

So yes — it’s the same technique: generic overloading with different arities.

**You said:**

`IdentityDbContext<TUser>` is a specialized version of the main generic class `IdentityDbContext<TUser, TRole, TKey>`, where only the user type is customizable, and the role and key types default to `IdentityRole` and `string`.

**ChatGPT said:**

Exactly — you're spot on again.

To clarify your statement just a bit more precisely:

> `public class IdentityDbContext<TUser> : IdentityDbContext<TUser, IdentityRole, string>`

This means:

- It's a **specialization** (or shortcut) of the main generic class:

```csharp
public class IdentityDbContext<TUser, TRole, TKey> : DbContext
```

So yes — both are **the same base class**, but the first version allows you to specify only `TUser`, while it **defaults** the role type to `IdentityRole` and key type to `string`.

Think of it like this:

```csharp
// Full control
IdentityDbContext<CustomUser, CustomRole, Guid>

// Partial control
IdentityDbContext<CustomUser> // uses IdentityRole and string as defaults

// No control (fully default)
IdentityDbContext // uses IdentityUser, IdentityRole, string
```

It's a clean way to give developers flexibility without always forcing them to supply all three types.

Would you like me to summarize all these overloads into a small table or hierarchy?

**You said:**

Basically, we start with the fully customizable generic class, and then create convenient presets on top of it for common use cases.

**ChatGPT said:**

Yes — exactly! You’ve nailed the concept.

The ASP.NET Identity team designed it like this:

- **Start with the full version**:

```csharp
public class IdentityDbContext<TUser, TRole, TKey> : DbContext
```

This is the most flexible base.
    
- **Then create convenient presets** that:
    
    - Reduce boilerplate
        
    - Cover common scenarios (like using `string` as a key)
        
    - Are easier to use for most developers

So:

```csharp
// Preset: default role and key type
public class IdentityDbContext<TUser> : IdentityDbContext<TUser, IdentityRole, string>

// Preset: default user, role, and key
public class IdentityDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
```

This pattern is common in .NET to balance **customization** with **ease of use**.

Want to see the same idea applied in other .NET types too (like `Dictionary`, `Task`, etc.)?
## Services Lifecycle
In .NET (and many other DI frameworks), services can be registered with different **lifetimes**, which determine whether a new instance is created each time or not.

Here are the common lifetimes in .NET:

🔁 **Transient**

- **Behavior:** A new instance is created **every time** the service is requested.
    
- **Effect:** Yes, two classes will get **two different instances**.
    
- **Register with:** `services.AddTransient<IMyService, MyService>();`

♻️ **Scoped**

- **Behavior:** A single instance is created per **request** (in web apps).
    
- **Effect:** Two classes in the **same HTTP request** will share the **same instance**. In **different requests**, they get different instances.
    
- **Register with:** `services.AddScoped<IMyService, MyService>();`

🛑 **Singleton**

- **Behavior:** Only **one instance** is created for the **entire application lifetime**.
    
- **Effect:** All classes that depend on this service get the **same instance**, even across requests.
    
- **Register with:** `services.AddSingleton<IMyService, MyService>();`

**In Summary:**

If you register your service as `Transient` each class gets its own instance.  
If it's `Scoped` or `Singleton`, the same instance can be reused depending on scope.

**You said:**

These injections mainly happen in the controller classes? That's why we can have different instances across different requests?

**ChatGPT said:**

Exactly — injections _typically_ happen in **controller classes**, **middleware**, or **services** that are registered in the DI container. Here's the key idea:

✅ **Where injections happen**

- **Controllers** (most common): injected via constructor when a request comes in
    
- **Services**: injected into other services or controllers
    
- **Middleware components**: also can receive services via constructor

🔁 **Why instances can differ across requests**

Each HTTP request creates a **new controller instance**, and depending on the **lifetime** of the injected service:

- **Transient**: a _new instance every time it's injected_, even within the same request
    
- **Scoped**: _one instance per request_, shared among everything in that request
    
- **Singleton**: _one instance for the entire app lifetime_, shared across all requests

🧠 **Example scenario**

```csharp
// Registered as Scoped
services.AddScoped<IMyService, MyService>();
```

- Request A: Controller gets `MyService` with `ID = X`
    
- Request B: Controller gets `MyService` with `ID = Y`
    
- Same request (e.g., multiple services injected): all use `ID = X`

**You said:**

Is the controller object recreated each time in our app when a different HTTP request hits?

**ChatGPT said:**

Yes, the **controller object** is recreated for each HTTP request that hits your application.

When a new request comes in, the **ASP.NET Core framework** creates a new instance of the controller class to handle that request. This ensures that each request is handled independently, and controllers can manage their own state across requests.

**Key details:**

- **New Controller Per Request**: Every time a request comes in, a new instance of the controller is created to handle that request.
    
- **Dependency Injection (DI)**: While the controller is recreated for each request, the **services** injected into the controller (such as scoped or singleton services) may have different lifetimes, depending on their registration in the DI container.
    
    - **Scoped services**: Created once per request, shared within that request across the controller and other services.
        
    - **Singleton services**: Created once when the application starts and used across all requests.

**Example:**

Let's say we have a controller and a scoped service:

```csharp
public class MyController : Controller
{
    private readonly IMyService _myService;

    public MyController(IMyService myService)
    {
        _myService = myService;
    }

    public IActionResult Index()
    {
        var result = _myService.GetData();
        return View(result);
    }
}
```

And the `IMyService` is registered as scoped:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IMyService, MyService>();
}
```

**What happens when a request comes in?**

- A **new instance of `MyController`** is created for each request.
    
- The **`IMyService`** is injected and a **new instance of `MyService`** is created once per request and shared within the request.

This allows each request to have its own instance of the controller and ensures that scoped services (like `IMyService`) are created and managed independently for each request.
## `UserStore`
The **`UserStore`** in ASP.NET Core Identity is a class that provides the **persistence logic** for user-related data. It's the bridge between the `UserManager<TUser>` and your **data source** (like a database).

**🔧 What it does:**

`UserStore` implements interfaces like `IUserStore<TUser>`, `IUserPasswordStore<TUser>`, `IUserEmailStore<TUser>`, etc., which define methods for CRUD operations on user properties.

For example:

- `CreateAsync()` → adds a user to the database.
    
- `FindByNameAsync()` → fetches a user by username.
    
- `SetPasswordHashAsync()` → sets a hashed password.
    
- `GetRolesAsync()` → gets user roles.

🧱 **Where is it used?**

It's typically registered with dependency injection during Identity setup:

```csharp
services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
```

In this example:

- `AddEntityFrameworkStores<ApplicationDbContext>()` registers `UserStore<ApplicationUser>` and `RoleStore<IdentityRole>` using EF Core under the hood.
    
- `UserManager` then uses this registered `UserStore` to save and retrieve user data.

📝 **Custom `UserStore`?**

You can implement your own `IUserStore<TUser>` if you're **not using Entity Framework** or want to persist users in:

- MongoDB
    
- Azure Table Storage
    
- A web API
    
- Flat files, etc.

✅ **Why we need `UserStore` in ASP.NET Core Identity**

Think of **`UserManager<TUser>`** like a manager that handles higher-level user operations (like creating users, changing passwords, adding roles), but **it doesn’t know how to actually talk to the database**. That's the job of the `UserStore`.

**Analogy:**

Imagine `UserManager` is a **hotel receptionist**, and the `UserStore` is the **key cabinet** where the room keys (data) are actually stored. The receptionist knows how to handle a guest but always uses the cabinet to get or set anything.

👇 **What would happen without a `UserStore`?**

Without `UserStore`, `UserManager` wouldn’t know **how to fetch a user**, **how to save one**, or even **how to update their password**. It delegates those low-level operations to the `UserStore`, which contains **database-specific logic**.

So:

- `UserManager.CreateAsync(user, password)`  
    → Calls `UserStore.CreateAsync(user)`  
    → Saves the user in the DB (via EF Core or other)

- `UserManager.FindByNameAsync(username)`  
    → Calls `UserStore.FindByNameAsync(username)`  
    → Retrieves the user from the DB

⚙️ **Why is this separation useful?**

It allows ASP.NET Identity to:

- Be **storage-agnostic**: it doesn't care if you're using EF Core, MongoDB, or something else.
    
- Be **testable**: you can mock the store in unit tests.
    
- Be **extensible**: you can write a custom `UserStore` for any kind of data source.

Let’s walk through what happens internally when you call:

```csharp
await userManager.CreateAsync(user, "Password123!");
```

🧠 **Step-by-step breakdown**

1. **Password gets hashed**

`UserManager.CreateAsync(user, password)` first hashes the password using a configured password hasher:

```csharp
var hash = _passwordHasher.HashPassword(user, password);
user.PasswordHash = hash;
```

So now your user object has a `PasswordHash`.

2. **Validation is performed**

It checks:

- Is the username unique?
    
- Does the password meet the policy?
    
- Are all required fields filled?

```csharp
var errors = ValidateUser(user);
var pwdErrors = ValidatePassword(password);
```

If any validations fail, the method returns `IdentityResult.Failed(...)`.

3. **User is saved using the `UserStore`**

If validation passes, `UserManager` calls:

```csharp
await _userStore.CreateAsync(user, cancellationToken);
```

This is where the real storage happens.

🔍 **And what is `_userStore`?**

Usually, it’s an instance of:

```csharp
UserStore<IdentityUser> : IUserStore<IdentityUser>, IUserPasswordStore<IdentityUser>, ...
```

That means it knows how to:

- Insert a user into your database (usually with Entity Framework Core)
    
- Set and retrieve passwords, emails, roles, etc.

Under the hood, this line typically looks like:

```csharp
_context.Users.Add(user); // _context is your EF DbContext
await _context.SaveChangesAsync();
```

4. **Final result is returned**

After the store saves the user, `UserManager` returns:

```csharp
IdentityResult.Success
```

**In other words:**

**`UserManager`** is the primary class you work with, but it does not handle how or where the data is stored. It delegates that responsibility to **UserStore**. For example, when you create a new user, **UserManager** will say to **UserStore**, _"I have a new user that needs to be saved. I don't know where or how you’ll save it, just take care of it."_

The **`UserStore`** is responsible for the actual storage operations, including where the data is saved, which database is used, and how the data is handled. The default **UserStore** implementation uses **Entity Framework** and **SQL Server**, but if you need to use a different database like **MySQL**, you would need to use a different **UserStore** implementation.

This flexibility is one of the key features added in ASP.NET Core Identity, which allows it to work with different data stores. In contrast, **ASP.NET Membership** was tightly coupled to **SQL Server** and didn't provide this level of abstraction.

A similar concept applies to **`RoleManager`** and **`RoleStore`**, where **`RoleManager`** works with **`RoleStore`** to handle role data storage, maintaining the same separation of concerns.

he **`UserStore`** and **`RoleStore`** serve as **abstractions** that hide the complexities of how and where the data is actually stored. They act like **service layers** or **middlemen**, handling all the low-level data operations (like saving, retrieving, or deleting users and roles) without the **`UserManager`** or **`RoleManager`** needing to know the specific details about the database or data store being used.

This makes it easy to switch out the underlying storage system (for example, from SQL Server to MongoDB) without having to rewrite the logic in **`UserManager`** or **`RoleManager`**. You just plug in a new **`UserStore`** or **`RoleStore`** implementation that knows how to interact with the new database.

In short, they're like **service layer**: they handle the specifics, while the **`UserManager`** and **`RoleManager`** focus on the high-level logic of user and role management.

💡**Summary**

|Layer|Responsibility|
|---|---|
|`UserManager`|Handles rules, validation, workflows|
|`UserStore`|Handles database logic (Create, Find, Update, etc.)|
|`DbContext`|The actual EF Core connection to your SQL Server|
## Cookies
✅ What Happens When a User Logs In:

1. **User credentials are validated** (e.g., via `SignInManager.PasswordSignInAsync(...)`).
    
2. If the login is successful:
    
    - Identity **creates a cookie** that represents the authenticated user.
        
    - This is an **authentication cookie** and is **stored in the user's browser**.
        
3. On every subsequent request (GET, POST, etc.):
    
    - The browser **automatically sends this cookie** with the request.
        
    - The server **reads the cookie**, validates it, and knows which user is making the request.

🔐 **What's Inside the Cookie?**

- It's **not** storing the entire user object.
    
- It contains an **encrypted and signed ticket** with user claims (like user ID, roles, etc.).
    
- ASP.NET Core uses middleware to **decrypt and validate** this on every request.

🧠 **Summary:**

|Aspect|Details|
|---|---|
|Where the auth info is stored|In a **secure cookie** in the browser|
|When it is sent|Automatically with **every request** to the same domain|
|Who reads it|ASP.NET Core authentication middleware (before controller/page code)|
|Security|Encrypted, signed, uses HTTPS-only settings by default|

This is why once a user logs in, their identity is available through `User.Identity` in controllers or Razor Pages without needing to pass anything manually.
## User Object
The `User` object is **automatically injected** and is available by default in both **MVC controllers** and **Razor Pages** without any special configuration. This is part of the ASP.NET Core framework's built-in functionality to handle authentication and authorization.

- **In MVC controllers**, the `User` property is available on every action, giving you access to the authenticated user's information (such as their identity and claims).

- **In Razor Pages**, the `User` property is also available in the `PageModel` and in Razor views.

In both cases, the `User` property automatically provides access to the authenticated user's information, and you don't need to inject anything manually. It's part of the `HttpContext` that ASP.NET Core provides for each request. This makes it super convenient to use user-related data across your actions, pages, and views.
## Partial Views
Partial views in Razor are indeed just regular Razor views, but they are used to inject reusable UI elements into other views. The key difference is that partial views are not meant to be standalone pages. Instead, they are designed to be rendered as part of a larger view.

**Here's how partial views work:**

1. **Reusable UI Elements**: You can think of partial views as smaller pieces of a webpage—like a header, footer, sidebar, or any other UI section that appears on multiple pages. These are components that are shared across different pages.
    
2. **Injected into Parent Views**: The partial view is rendered wherever you include the `<partial />` tag in the parent Razor page. The content of the partial view gets injected into the place where the `<partial />` tag is located.
    
3. **Rendering Mechanism**: When the page containing the `<partial />` tag is rendered, the Razor engine looks for the partial view (e.g., `_Privacy.cshtml`), and includes its content inside the parent view at the location of the tag.

**Example:**

Let’s break down an example:

`Home.cshtml` (Main View):

```html
<h1>Welcome to Our Website</h1>

<p>This is the main content of the page.</p>

<!-- Including the partial view here -->
<partial name="_Privacy" />
```

`_Privacy.cshtml` (Partial View):

```html
<div class="privacy-policy">
    <h2>Privacy Policy</h2>
    <p>This is our privacy policy content.</p>
</div>
```

**What Happens:**

- When the `Home.cshtml` view is rendered, it will include the content from `_Privacy.cshtml` where the `<partial name="_Privacy" />` tag is placed.
    
- The `_Privacy.cshtml` view will not be a standalone page but will be rendered as part of the larger `Home.cshtml` page.

**Key Points:**

- **Partial views** are **not full pages**; they are just fragments or reusable parts of a page.
    
- The `<partial />` tag is used to **render these fragments** within the parent view.
    
- They help you keep your views DRY (Don't Repeat Yourself) by allowing you to reuse common elements across multiple pages.

In summary: partial views allow you to inject specific parts of a page into a parent Razor page, which helps with reusability and modular design.
# Bookmarks
[Introduction to Identity on ASP.NET Core | Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=visual-studio)

Completion: 03.05.2025