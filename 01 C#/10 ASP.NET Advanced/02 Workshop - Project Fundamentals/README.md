# General
This workshop focuses on developing and improving the `CinemaApp` project. Below are some useful notes.
## AutoMapper
Идеята на AutoMapper е чрез предварително зададена конфигурация и конвенции да можем лесно да мапнем обект от един клас към друг, само чрез извикване на метод като `.MapTo`.

Това се постига чрез използване на няколко интерфейса, които трябва да си създадем.

`IHaveCustomMappings` — този интерфейс се използва, когато нещо не може да се мапне автоматично по конвенция. Например: в entity модела имаме цена като `decimal`, а във view модела тя е `string`, или искаме да я форматираме по определен начин — например цената да се показва с два знака след десетичната запетая:  
`Price = h.Price.ToString("F2");`

За да работи AutoMapper, трябва да добавим и съответния NuGet пакет.
## Repository Pattern
Repository патърнът е софтуерен дизайн патърн, който абстрахира достъпа до данните чрез интерфейс, скривайки детайлите на базата данни или ORM-а. Той улеснява управлението на данните, подобрява тестируемостта и позволява лесна смяна на технологията за съхранение без промяна в бизнес логиката. По този начин разделя отговорностите и осигурява по-чист и поддържан код.

**Без Repository Pattern:**

В даден проект директно се използва `DbContext` в приложението. Това обаче води до някои проблеми:

- **Тестване:** Как да тестваме `DbContext`?
    
- **Повтарящ се код:** Трябва да се създава репозитори за всеки `DbSet`.
    
- **Директна зависимост:** Приложението зависи директно от `DbContext`, нарушавайки принципа за инверсия на зависимостите.
    
- **Смяна на ORM:** Ако искаме да сменим EF Core с Dapper, ще трябва да направим много промени.

**Защо да използваме Repository Pattern?**

Идеята е да абстрахираме достъпа до данните чрез един интерфейс.

Предимства:

- **Тестване:** Можем да тестваме `DbContext` чрез интерфейса.
    
- **DRY (Don't Repeat Yourself):** Имаме един обект с няколко имплементации.
    
- **Разделяне на отговорностите:** Данните и бизнес логиката са разделени, зависимостите се управляват чрез Dependency Injection.
    
- **Смяна на ORM:** Лесно можем да сменим ORM без да променяме бизнес логиката.

**Недостатъци:**

- **Сложност:** Въвежда ново ниво на абстракция и усложнява кода.
    
- **Оркестрация:** Нужно е правилно имплементиране и регистрация на интерфейсите в DI контейнера.
    
- **Мапинг:** Инструменти като AutoMapper може да не работят добре с generic изрази.
    
- **Поръчка на операции:** Трябва да гарантираме правилен ред на запазване на данните (чрез Unit of Work).
# Misc
# ChatGPT
## Middleware

Middleware in ASP.NET Core is just **a component in the request pipeline** that can:

- Do something with the **incoming request**

- Optionally **pass it down** to the next middleware

- Do something with the **outgoing response**


Think of it like a **series of steps** every HTTP request goes through before reaching your controller.

🧱 **Pipeline Analogy**

Imagine this:

```
Client → [ Middleware A ] → [ Middleware B ] → [ Controller ]
                        ← Response ← Response ←
```

Each middleware can:

- Log
    
- Modify headers
    
- Check authentication
    
- Short-circuit the request (e.g., return early)
    
- Catch exceptions, etc.

🔧 **Example: Simple Custom Middleware**

Let’s make a middleware that logs every request time.

**Step 1: Create it**

```csharp
public class RequestTimeMiddleware
{
    private readonly RequestDelegate _next;

    public RequestTimeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var start = DateTime.UtcNow;

        await _next(context); // Call next middleware/controller

        var duration = DateTime.UtcNow - start;
        Console.WriteLine($"Request took {duration.TotalMilliseconds} ms");
    }
}
```

**Step 2: Register it in `Program.cs`**

```csharp
app.UseMiddleware<RequestTimeMiddleware>();
```

That’s it — now this runs for every request and logs how long it took.

🧠 **Middleware Order Matters**

Middleware is called **in the order it’s added**. For example:

```csharp
app.UseMiddleware<Middleware1>();
app.UseMiddleware<Middleware2>();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
```

That’s the real **pipeline**.

📝 **Summary**

Middleware in ASP.NET Core is a fundamental part of the request pipeline. Each middleware can inspect, modify, or short-circuit the HTTP request and response. Middleware components are executed **in the order they're registered**, making their position in the pipeline crucial. Custom middleware is easy to create and can be used for logging, headers, authentication checks, and more.

Once understood, middleware unlocks deeper control over how your application processes requests.
# Bookmarks
Completion: 17.05.2025