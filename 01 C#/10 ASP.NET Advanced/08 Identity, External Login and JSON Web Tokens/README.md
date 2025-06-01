# General
## Identity
### Extending ASP.NET Core Identity
`ApplicationUser.cs` – позволява добавяне на функционалност към потребителя. Името на класа може да бъде зададено според нуждите на проекта.

Разширява ASP.NET Core Identity.

```csharp
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }  // Stores the user's first name
    public string LastName { get; set; }   // Stores the user's last name
}
```

Разширява информацията за потребителя, дефинирана в ASP.NET Core `IdentityUser`.

Може да съдържа допълнителни полета.

Например: собствено име, фамилия, рождена дата.

За да се спазват различни регулации като GDPR, Microsoft не включва лична информация по подразбиране в класа `IdentityUser`. Поради това именно разширяването на този клас с лични полета често е една от първите стъпки при надграждане на ASP.NET Core Identity.
### Gaining Full Identity Control
Стандартното поведение на Identity се заменя с персонализирано.

```csharp
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    // services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
```

Използва се персонализиран потребител (`ApplicationUser`), вместо стандартния `IdentityUser`.

Ако има нужда и от персонализирани роли, се дефинира нов клас, който наследява `IdentityRole`. Например:

```csharp
public class ApplicationRole : IdentityRole
{
    public string Description { get; set; }  // Custom property for the role
}
```

След което регистрацията в `Program.cs` се заменя така:

```csharp
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
```

По този начин се дефинират както персонализиран потребител, така и персонализирана роля.

Следният код задава пътищата за Login, Logout и Access Denied. Това са настройки на application coocky-то.

```csharp
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
// Sets the custom paths for login, logout, and access denied actions
```
## Claims
Claim-базираната идентичност е често използвана техника в приложенията.

Приложенията получават информация за идентичността на потребителите чрез Claims.

Claim е твърдение, което даден субект прави относно себе си.

Твърдението може да се отнася до име, група, етнос, привилегия, принадлежност и др.

Субектът, който прави твърдението, е т.нар. provider.

Claim-базираната идентичност опростява логиката за автентикация.

Не е необходимо създаване или промяна на акаунти.

Когато преминем процеса на автентикация, можем да идентифицираме потребителя – тоест знаем кой е той. Тази идентичност (identity) представлява съвкупност от характеристики, които го описват.

**Claim-based identity** означава, че идентичността на потребителя се изгражда въз основа на **твърдения (claims)**. Примери за такива твърдения са: името му е `Pesho`, имейлът му е `pesho@gmail.com`, ролята му е `администратор` и т.н. Тези твърдения формират неговата claim-based идентичност.

В ASP.NET Core един потребител може да има **повече от една идентичност**, тъй като системата поддържа **списък от обекти `ClaimsIdentity`**. Всяка отделна идентичност може да съдържа свои собствени твърдения (claims).

Например:

- За да отвори банкова сметка, потребителят може да има идентичност „Driving License“ с claims: Name, Date of Birth и Address.

- За да ползва студентско намаление, той може да се идентифицира с друга идентичност – „Student Card“, съдържаща claims: Name, University, Department и Student Number.

Важно е, че **имаме доверие към източниците на тези твърдения** (claim issuers) – те са авторитети, които удостоверяват, че информацията е вярна.
### Claims in ASP.NET Core

# Misc
## Organizing `Program.cs`
Може да се създаде extension клас в `Microsoft.Extensions.DependencyInjection`, тъй като това е стандартният namespace, използван за DI (dependency injection) функционалността. Понеже разширява именно тази функционалност, е добра практика extension методите да бъдат в този namespace, за да избегнем добавяне на допълнителни `using` директиви.

Могат да се добавят методи като `AddApplicationDatabase`, `AddApplicationIdentity` и `AddApplicationServices`.

Тези методи могат при нужда да се разпределят в отделни класове, ако логиката в тях стане по-обемна.

Така се постига по-чист и структуриран `Program.cs` файл, тъй като конфигурацията се пренася в отделни extension методи.

Пример:

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IDServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationDatabase(this IServiceCollection services, IConfiguration config)
        {
            // Add services to the container.
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIDentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}

// Program.cs
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationDatabase(builder.Configuration)
    .AddApplicationIDentity(builder.Configuration)
    .AddApplicationServices(builder.Configuration);
```
# ChatGPT
## Authentication / Authorization
In ASP.NET, **Authentication** and **Authorization** are two separate but closely related concerns when it comes to security.

🔐 **Authentication Middleware**

**What it does:**  
Authentication middleware **verifies who the user is**. It checks the identity of the user based on credentials (like tokens, cookies, username/password, etc.).

**Steps it performs:**

1. **Reads credentials** from the HTTP request (e.g., JWT token, cookie, header).
    
2. **Validates the credentials** (e.g., check token signature, expiration, etc.).
    
3. If valid, it **creates a `ClaimsPrincipal` object** representing the user.
    
4. It **sets `HttpContext.User`** to this `ClaimsPrincipal`, so that downstream components (like controllers) know who the user is.

**Example Middleware:**

```csharp
app.UseAuthentication(); // Adds the Authentication middleware
```

> Without this, `HttpContext.User` will be empty, even if you send a valid token or cookie.

✅ **Authorization Middleware**

**What it does:**  
Authorization middleware **checks what the user is allowed to do**. It verifies whether the authenticated user has permission to access a resource or perform an action.

**Steps it performs:**

1. Looks at `HttpContext.User` (set by authentication).
    
2. Compares user’s claims/roles/policies against the requirements of the endpoint (like `[Authorize]` attributes).
    
3. If the user **is not authorized**, returns a **403 Forbidden** or **401 Unauthorized**.

**Example Middleware:**

```csharp
app.UseAuthorization(); // Adds the Authorization middleware
```

> Without this, your `[Authorize]` attributes won’t do anything — anyone can access protected endpoints.

🔁 **Summary in 1 Sentence Each:**

- **Authentication** = "Who are you?"
    
- **Authorization** = "Are you allowed to do this?"

**Real-World Flow:**

1. `UseAuthentication()` runs → sets `HttpContext.User`.
    
2. `UseAuthorization()` runs → checks if that user can access a resource.
## `ConfigureApplicationCookie(...)`
You **need `ConfigureApplicationCookie(...)`** _only if_ you're overriding the **default Identity redirect behavior**.

Here’s a clear breakdown of **when and why** you need it:

✅ **When you do need `ConfigureApplicationCookie(...)`**

If you’ve **replaced the default Razor Pages** (e.g., `/Identity/Account/Login`) with your **own controller actions**, like `/User/Login` or `/User/Register`, then:

- ASP.NET Identity still doesn't "know" you changed them.
    
- So when a user hits `[Authorize]`-protected content, it will redirect to the default `/Identity/Account/Login` **unless you explicitly change it** using:

```csharp
services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";     // <== You MUST tell it to redirect here instead
    options.LogoutPath = "/User/Logout";
});
```

So: `ConfigureApplicationCookie(...)` is what **connects your custom paths to the Identity cookie middleware**.

❌ **When you don't need it**

You don’t need `ConfigureApplicationCookie(...)` **only if**:

- You’re using the **default Razor Pages** (`/Identity/Account/...`), and
    
- You haven’t customized any login/logout/register paths.

But since in your case:

> ✅ You've replaced the default pages with controller-based login/register  
> ✅ You've updated `_LoginPartial` to use the new paths  
> ✅ You don’t want redirects going to `/Identity/Account/Login`

Then yes — you **do need** to configure the application cookie.

🧠 **Summary**

You’re replacing the Identity UI with your own controllers — so `ConfigureApplicationCookie(...)` is **required** to ensure:

- Authorization redirects go to `/User/Login`
    
- `SignOutAsync()` hits `/User/Logout`
    
- Identity cookie behavior aligns with your routing setup

Let me know if you want help verifying your `UserController` methods line up with these expectations!

**You said:**

Why does ASP.NET Core require a cookie in order to determine where to redirect unauthenticated users?

**ChatGPT said:**

Excellent question — and it touches on how authentication and navigation tie together in ASP.NET Core.

🧠 **Why Identity uses a cookie**

ASP.NET Core Identity uses **cookie-based authentication** to remember that a user is logged in. The cookie stores the **authentication ticket**, which contains information like:

- The user ID
    
- Roles/claims
    
- Expiration info

But it's not just about "remembering" who is logged in — the cookie is also tied to **middleware that controls redirection and access flow**.

🔑 **So why does `ConfigureApplicationCookie(...)` affect navigation?**

Here’s the key point:

When you access a `[Authorize]`-protected page:

1. **ASP.NET checks if you're authenticated** by looking for a valid authentication cookie.
    
2. If the cookie is **missing or invalid**, ASP.NET:
    
    - **Doesn't know where to redirect you**, unless you tell it.
        
    - By default, it redirects to `/Identity/Account/Login`.

That’s why we need to configure the cookie settings:

```csharp
services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login"; // <-- Tell it where to go when not authenticated
});
```

So this has nothing to do with **where the user wants to navigate**, but rather:

> Where ASP.NET Core will **redirect the user automatically** when they are **not authorized** and try to access something that requires authorization.

🧭 **Summary**

- The cookie is **how ASP.NET knows you're authenticated**.
    
- `ConfigureApplicationCookie` is **how ASP.NET knows where to redirect you** if you're not.
    
- Without configuring this, it assumes you're using the default Identity Razor Pages.

If you're using custom login pages (like `/User/Login`), this config is **essential**, even though it might seem unrelated to cookies at first glance.
# Bookmarks
Completion: 02.06.2025