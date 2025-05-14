# General
## Model Binding
Мост между HTTP заявката и параметрите на action метода. В самата HTTP заявка има множество различни източници, откъдето могат да се подават данни – като route параметри, query string, form полета, headers и тн. 

Целта на байндърите е да извлекат тези данни и да ни ги предоставят в обработен и удобен за използване вид в C#.

Байндърът извлича наличните данни от заявката – например от query string, където данните са представени като двойки _име=стойност_, или от form data, където структурата също е на базата на име и стойност.

След това байндърът търси дали има параметри в action метода или пропъртита в по-сложен обект (като клас), които съвпадат по име с получените данни, и автоматично ги запълва.

При route параметрите процесът е малко по-специфичен – проверява се дали URL пътят на заявката съвпада с този, който е дефиниран в маршрута на контролера. Ако имената в route шаблона съвпадат с имената на параметрите в метода, тогава стойностите от пътя се мапват към тези параметри.

Данните от HTTP заявките се използват от контролерите.

Ако свързването не е успешно, не се хвърля грешка, но се записва error message.

Поведението на модела за свързване може да бъде персонализирано и да си направим собствени.

Основната идея на **model binder-а** в ASP.NET Core е да **вземе данни от HTTP заявката** (които винаги пристигат като **string-ове**) и да ги **преобразува в обекти или типове**, с които **да работим директно в нашия код**.

Работата на model binder-а е:

Взима стойности от различни източници на заявката (route, query string, form, body и т.н.)

Съпоставя имената на тези стойности с параметрите или пропъртитата, които очакваме

Конвертира string-овете към съответните типове – като `int`, `DateTime`, `bool`, обекти и други

Връща ни готов обект, който можем да ползваме веднага в контролера

Идеята на байндъра е да ни преобразува string-овете от заявката в смислени C# типове, с които можем да работим удобно.
### Attributes
Вграденото поведение на Model Binding може да бъде насочено към конкретен източник. Реално байндърът проверява няколко източника на данни в заявката и търси съвпадения по име между тях и параметрите на метода или пропъртитата в моделите.

По подразбиране той обхожда източници като route, query string, form data и headers, за да намери стойности, които съвпадат по име.

Можем обаче да ограничим този процес и да укажем изрично откъде да се извличат данните, като използваме атрибути.

Така избягваме неясноти и контролираме по-точно как да се обработва входът.

Фреймуъркът предоставя няколко атрибута за тази цел:

`[BindRequired]` – добавя грешка в `ModelState`, ако байндингът не може да се извърши.

`[BindNever]` – указва на байндъра никога да не свързва този параметър.

`[From{source}]` – използва се за указване на точния източник на данните: `[FromHeader]`,`[FromQuery]`, `[FromRoute]`, `[FromForm]`

`[FromServices]` – се използва за **Dependency Injection** (DI) и позволява на параметрите в метода да бъдат попълнени от регистрирани услуги в контейнера на DI. Данните за тези параметри не идват от HTTP заявката, а се предоставят от DI контейнера, който управлява зависимостите в приложението.

`[FromBody]` – използва конфигурираните formatters, за да байндне данни от тялото на заявката. Formatter-a се избира на база **Content-Type** header-а на заявката.

`[ModelBinder]` – използва се за презаписване на стандартния байндър, източника на данни и името на параметъра.

Пример:

Ако имаме параметър `id` в контролер и използваме `[FromRoute]`, тогава **само стойността от маршрута (URL пътя)** ще бъде използвана за байндинг.

Пример:

```csharp
[HttpGet("products/{id}")]
public IActionResult GetProduct([FromRoute] int id)
{
    // here id will come only from the URL path, e.g. /products/5
}
```

В този случай, дори ако в заявката има `id` в query string (`?id=5`) или в тялото (ако е POST), **то няма да бъде взето под внимание** – байндърът ще погледне **само в route параметрите**.

Това е полезно, защото така се избягват неясноти или конфликти, ако `id` се подава на повече от едно място. Използването на `[FromRoute]` (или друг конкретен атрибут) гарантира, че се гледа точно определения източник.
### Custom Model Binder
Персонализираното байндиране на модел може да бъде напълно настроено. То може да бъде добавено като глобален филтър, като така ще важи за всички, или да се добави с атрибут **model binder** там, където е необходимо.
Трябва да създадем `BindingProvider` и Binder:

```csharp
[ModelBinder(BinderType = typeof(StudentEntityBinder))]
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class StudentEntityBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        // TODO: Do Magic ...
        bindingContext.Result = ModelBindingResult.Success(model);
        return Task.CompletedTask;
    }
}

public class StudentEntityBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        if (context.Metadata.ModelType == typeof(Student))
        {
            return new BinderTypeModelBinder(typeof(StudentEntityBinder));
        }
        return null;
    }
}

services.AddControllerWithViews(options =>
{
    options.ModelBinderProviders
        .Insert(0, new StudentEntityBinderProvider());
    // Add custom binder to beginning
});
```
## Model Validation
Валидирането на модела се извършва след байндирането на модела.

Отчита грешки, които произлизат от процеса на байндинг.

Съществуват два вида валидация - сървърна и клиентска. Клиентската валидация повишава качеството на потребителското изживяване (UX), като предоставя по-бърза и интерактивна обратна връзка.

Свойството `ModelState.IsValid` показва дали валидацията на модела е успешна.

Обхожда се списъкът с грешки.
### Custom Model Validation
Атрибутите за валидация покриват повечето нужди, но не всички.

Понякога се налага да създадем собствени атрибути за валидация.

**Пример за персонализирана валидация:**

```csharp
public class IsBefore : ValidationAttribute
{
    private const string DateTimeFormat = "dd/MM/yyyy";
    private readonly DateTime date;

    public IsBefore(string dateInput)
    {
        date = DateTime.ParseExact(dateInput, DateTimeFormat, CultureInfo.InvariantCulture);
        ErrorMessage = "The date must be before " + date.ToString(DateTimeFormat); // Custom error message
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value >= date)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
```

След това може да се използва в модела:

```csharp
public class RegisterUserModel 
{
    [Required]
    public string Username { get; set; }

    [Required]
    [StringLength(20)]
    public string Password { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [IsBefore("01/01/2000")]
    public DateTime BirthDate { get; set; }
}
```

**Какво се случва зад кулисите:**

Когато ASP.NET извършва **валидация на модел**, той използва **reflection**, за да обиколи всички свойства на модела и провери дали върху тях има атрибути, наследени от `ValidationAttribute`.

За всеки такъв атрибут:

- ASP.NET **извиква метода `IsValid()`**, като му подава стойността на съответното property и `ValidationContext`.

- Ако `IsValid()` върне `ValidationResult.Success`, значи стойността е валидна.

- Ако върне `ValidationResult` с грешка, тя се добавя в `ModelState`.

Това важи както за вградените атрибути (`[Required]`, `[Range]`, `[StringLength]`), така и за всички **потребителски (custom)**, които си създадем сами.

**Важно:** методът `IsValid()` се изпълнява **автоматично** – не се налага ръчно да го извикваме никъде. Единственото изискване е атрибутът да бъде поставен върху свойство или параметър.
#### `IValidatableObject`
Можем също така да добавим валидация директно в binding модела, като използваме интерфейса `IValidatableObject`. Това е подходящо в случаите, когато валидацията е по-сложна и стандартните атрибути не са достатъчни. В такъв случай моделът трябва да имплементира интерфейса `IValidatableObject`, за да може да съдържа собствена логика за проверка на валидността.

```csharp
public class RegisterUserModel : IValidatableObject
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Username)) 
            yield return new ValidationResult("Username cannot be empty");

        if (string.IsNullOrEmpty(Password)) 
            yield return new ValidationResult("Password cannot be empty");

        if (ConfirmPassword != Password) 
            yield return new ValidationResult("Passwords do not match");
    }
}
```
## Uploading and Downloading Files
### Uploading Files
ASP.NET Core MVC позволява лесно качване на файлове чрез стандартен model binding. При работа с по-големи файлове се използва стрийминг за по-ефективна обработка. 

```csharp
<form method="post" enctype="multipart/form-data"
      asp-controller="Files" asp-action="Upload">
    <input type="file" name="file">
    <button type="submit" value="Upload" />
</form>
```

Системата поддържа и качване на няколко файла едновременно.

```csharp
<form method="post" enctype="multipart/form-data"
      asp-controller="Files" asp-action="Upload">
    <input type="file" name="files" multiple>
    <button type="submit" value="Upload" />
</form>
```

Когато качваме файлове чрез model binding, екшън методът трябва да приема.

`IFormFile` (за единичен файл) или `IEnumerable<IFormFile>` (или `List<IFormFile>`) за множество файлове.

Качване на файлове:

```csharp
[HttpPost("Upload")]
public async Task<IActionResult> Upload(List<IFormFile> files)
{
    var filePath = Path.GetTempFileName(); // Full path to file in temp location

    foreach (var formFile in files.Where(f => f.Length > 0))
    {
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
        }
    } // Copy files to FileSystem using Streams

    var bytes = files.Sum(f => f.Length);
    return Ok(new { count = files.Count, bytes, filePath });
}
```
# Misc
# ChatGPT
# Bookmarks
[C# Web Basics - Workshop - Web Application. Advanced CSS - Bootstrap - май 2019 - Николай Костов - YouTube](https://www.youtube.com/watch?v=iG2UBr2fAqg)

[Polyglot Persistence - YouTube](https://www.youtube.com/watch?v=T9h9SlVn8rw)

Completion: 15.05.2025