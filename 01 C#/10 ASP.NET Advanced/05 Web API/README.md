# General
## JSON
Форматът JavaScript Object Notation (JSON) е отворен стандарт за файлове.

Използваме четим за хора текст, за да предаваме обекти с данни.

Обектите с данни се състоят от двойки атрибут-стойност или масиви от данни.

На практика може да съдържа всяка стойност, която може да бъде сериализирана.

```json
{
  "firstName": "Peter",
  "courses": ["C#", "JS", "ASP.NET"],
  "age": 23,
  "hasDriverLicense": true,
  "date": "2012-04-23T18:25:43.511Z"
  // Additional properties can be added here
}
```

Лесно е за хората да четат и пишат JSON.

Лесно е за машините да анализират и генерират JSON.

JSON произлиза от JavaScript. Въпреки това, той е независим от конкретен език за програмиране.

Сега много езици предоставят код за създаване и анализиране на JSON.

JSON е много често използван формат за данни при уеб комуникация.

Използваме го основно при комуникация между браузър и сървър или между два сървъра.

Официалният интернет медиен тип (MIME) за JSON е `application/json`.

Файловете с JSON използват разширението `.json`.

JSON често се използва като заместител на XML в AJAX системи.

JSON е по-кратък и по-лесен за разбиране.

JSON е по-бърз за четене и писане, и е по-интуитивен.

JSON не поддържа схеми и пространства от имена (namespaces).
## XML
XML дефинира набор от правила за кодиране на документи.

Съкращението означава Extensible Markup Language (разширяем език за маркиране).

Подобен е на JSON.

Става дума за сходство по отношение на четимост от хора и възможност за анализ от машини.

Също така и по отношение на йерархия (стойности в рамките на други стойности).

XML е текстов формат за данни.

Има силна поддръжка на различни човешки езици чрез Unicode.

Дизайнът му е силно насочен към работа с реални документи.

XML има много приложения.

Има два MIME типа за XML: `application/xml` и `text/xml`.

Файловете с XML използват разширението `.xml`.

Имаме много приложения за XML.

Широко се използва в SOA (например WCF).

Използваме го за конфигуриране на .NET приложения.

Ползва се във форматите на Microsoft Office.

XHTML е замислен като по-стриктна версия на HTML.

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<records>
  <record id="1">
    <name>Ivo</name>
    <email>ivo@softuni.bg</email>
    <company>Software University</company>
  </record>
  <record id="2">
    <name>Niki</name>
    <email>admin@Nikolay.it</email>
    <company>ZenCodeo</company>
  </record>
</records>
```
## JavaScript
JavaScript (JS) е скриптов език.

Изпълнява команди (скриптове).

Можем да го използваме в интерактивен режим.

Няма компилация, просто изпълняваме командите.

Заедно с HTML и CSS, JavaScript е една от трите основни технологии на Световната мрежа.

JavaScript позволява динамичност и интерактивност в уеб страниците.

Има достъп до DOM и браузърни API-та (като нотификации, геолокация и други).

JavaScript (JS) е нетипизиран език.

Нетипизиран (динамично типизиран) означава, че променливите нямат тип (но стойностите, които тези променливи съдържат, имат тип и могат да се променят по време на изпълнение). Това позволява на променливите да приемат различни типове данни в различни моменти.

Данните (стойностите) все пак имат тип.

JavaScript първоначално е бил имплементиран само от страната на клиента в уеб браузърите.

Днес JavaScript енджини са вградени в много видове софтуер.

Сървърно-страничен JavaScript, мобилни приложения, десктоп приложения и други.

JavaScript е една от най-популярните технологии в уеб пространството, ако не и най-популярната, всъщност...

Възходът на SPA приложенията и сайтовете, базирани силно на JavaScript, определено го доказва.

Една от най-важните техники, свързани с JavaScript, е AJAX.

Asynchronous JavaScript and XML (асинхронен JavaScript и XML).

TypeScript е типизиран superset от JavaScript, който се компилира до обикновен JavaScript.
## Asynchronous JavaScript and XML
### AJAX
AJAX не е програмен език (въпреки „индивидуалната“ му популярност).

AJAX е съвкупност от техники за уеб разработка.

Ползваме го, за да създаваме асинхронни уеб приложения.

С помощта на AJAX можем да изпращаме и получаваме данни от сървър асинхронно – във фонов режим чрез HTTP заявки.

AJAX е мечта за разработчиците, защото можем да:

Прочетем данни от уеб сървър – след като страницата вече е заредена.

Обновим уеб страница (или части от нея), без да презареждаме цялата страница.

Изпратим данни към уеб сървър – във фонов режим.

AJAX работи много просто, използвайки комбинация от:

`XMLHttpRequest`

За да заявим данни от сървър.

JavaScript и DOM.

За да визуализираме и / или използваме данните.

Името AJAX може да бъде подвеждащо.

AJAX приложенията може да използват XML за пренос на данни.

Но също толкова често се използва JSON за пренос на данни.
### AJAX: Workflow
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250527110015.png)
### AJAX in Plain JavaScript (Vanilla JS)
Пример за AJAX заявка:  

```javascript
function loadHtml()
{
  // Initializes a XMLHttpRequest object
  let xhttp = new XMLHttpRequest();

  xhttp.onreadystatechange = function() {
    // readyState holds the status of the XMLHttpRequest
    // (4) means Request finished and Response is ready
    // status holds the status code
    if (this.readyState == 4 && this.status == 200) {
      // Load the Response text into the body of the document
      document.body.innerHTML = this.responseText;
    }
  }; // Defines a function, called when the readyState Is changed

  // Specify the request (method, url, async, etc...)
  xhttp.open("GET", "/api/Data", true);
  // Send the request to the server
  xhttp.send();
}
```

```html
<button onclick="loadHtml()">
  Click
</button>
```
### AJAX in SPA
Single-Page Apps - SPA са доста често срещани в днешно време.

Основават се на динамична и асинхронна смяна на съдържанието.

Почти всяко SPA приложение използва AJAX.

SPA използва AJAX, за да осигури по-добри и динамични приложения, изпълнени с данни.

AJAX се използва, за да направим плавни промени по страницата.

Това гарантира по-добър потребителски интерфейс (UX) и по-динамичен дизайн на потребителския интерфейс (UI).
## jQuery - Write Less, Do More!
jQuery е JavaScript библиотека, съвместима с различни браузъри.

Може да се ползва свободно — популярна е и е с отворен код: [jQuery](https://jquery.com/)

Драматично улеснява манипулирането на DOM дървото. Основната цел на jQuery е да скрие разликите между браузърите, така че да можем да пишем JavaScript код **само веднъж**, без да се притесняваме как точно ще го изпълни Chrome, Firefox, Safari или стар Internet Explorer. jQuery "превежда" кода ни към съответния браузър, като използва вътрешно съвместими методи.
Например, без jQuery се е налагало да се проверява ръчно кой браузър се използва, за да се избере правилния DOM метод. С jQuery тези неща са скрити — той сам се грижи да използва правилния подход за всеки браузър.

```html
<script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
```

Зареждаме jQuery от официалния CDN.

```javascript
$('li').css('background', '#DDD');
```

Променя CSS фона на всички `<li>` елементи.
### Why jQuery
Много популярна библиотека.

Използва се в 83 000 000 сайта (68.8% от топ 1 милион сайта).

Лесна за научаване.

Голяма общност от потребители и разработчици.

Поддържа множество браузъри.

Официален уебсайт: [http://jquery.com](http://jquery.com)
### Selection with jQuery
Селекторите в jQuery връщат колекция от съвпадащи елементи.

Работи със CSS3 селектори, както и с няколко специфични за jQuery.

Дори когато има само един елемент, пак се връща колекция.

```javascript
$('div') // Gets all elements with the provided tag

$('.menu-item') // Gets all elements with the provided class

$('#navigation') // Gets the element with the provided id

$('ul.menu li') // Gets all elements corresponding to the query selector
```

[Selecting Elements | jQuery Learning Center](https://learn.jquery.com/using-jquery-core/selecting-elements/)

Избраните елементи могат да се обработват като група.

```javascript
$('div').css('background', 'blue'); // Make all DIVs blue
```
### Adding Elements with jQuery
Избира се родителският елемент, след което се използва:

`append()` / `prepend()`

`appendTo()` / `prependTo()`

Добавяне на елементи с jQuery:

Започва се със следния начален HTML:

```html
<div id="wrapper">
  <div>Hello, student!</div>
  <div>Goodbye, student!</div>
</div>
```

Този код избира и двата вътрешни `<div>` елемента в `#wrapper` и добавя по един `<p>` към всеки от тях:

```javascript
$('#wrapper div').append("<p>It's party time :)</p>");
```

Това създава елемент `<h1>` и го вмъква най-отгоре в елемента `<body>`:

```javascript
$('<h1>Greetings</h1>').prependTo('body');
```

Крайна HTML структура (вътре в `<body>`):

```html
<h1>Greetings</h1>

<div id="wrapper">
  <div>
    Hello, student!
    <p>It's party time :)</p>
  </div>
  <div>
    Goodbye, student!
    <p>It's party time :)</p>
  </div>
</div>
```
### Creating / Removing Elements
jQuery:

```javascript
// Create a new <div> element
let div = $('<div>');

// Set the text content of the div
div.text('I am a new div.');

// Set the background color to blue
div.css('background', 'blue');

// Set the text color to white
div.css('color', 'white');

// Append the div to the document body
$(document.body).append(div);

// Create a new <p> element with some text
let paragraph = $('<p>Some text</p>');

// Append the paragraph inside the div
paragraph.appendTo(div);

// Remove all <div> elements from the document
$('div').remove();
```

Съвременният JavaScript предоставя всички необходими методи за манипулация на DOM. jQuery е бил много полезен в миналото, защото е решавал проблемите с несъвместимостта между браузърите и е опростявал синтаксиса, но днес native JavaScript покрива почти всичко ефективно и чисто. Промяната е, че днес всички основни браузъри имат много по-добра и стандартизирана поддръжка на native JavaScript и DOM API-тата. Това означава, че вече няма нужда от допълнителен слой като jQuery, който да коригира разликите и несъвместимостите между браузърите. Native JavaScript сега работи гладко и еднакво в повечето среди.

Native JavaScript:

```javascript
// Create a new <div> element
const div = document.createElement('div');

// Set the text content
div.textContent = 'I am a new div.';

// Set CSS styles
div.style.background = 'blue';
div.style.color = 'white';

// Append the div to the body
document.body.appendChild(div);

// Create a new <p> element with text
const paragraph = document.createElement('p');
paragraph.textContent = 'Some text';

// Append the paragraph inside the div
div.appendChild(paragraph);

// Remove all <div> elements from the document
document.querySelectorAll('div').forEach(d => d.remove());
```
### jQuery` Events: Attach / Remove
Прикачване на събития към определени елементи.

Премахване на обработчик на събития от определени елементи.

Събития в jQuery: Прикачване / Премахване

```javascript
$('a.button').on('click', buttonClicked);

function buttonClicked() {
  $('.selected').removeClass('selected');
  $(this).addClass('selected');
  // "this" is the event source (the hyperlink clicked)
}

$('a.button').off('click', buttonClicked);
```
## jQuery AJAX - Simplified AJAX Calls with jQuery
### jQuery vs Native `XMLHttpRequest` – GET
jQuery значително улеснява начина, по който разработчиците правят AJAX заявки като опростява синтаксиса и обработката на успех и грешка, докато при native `XMLHttpRequest` трябва ръчно да се проследи състоянието и да се обработят отговорите и грешките.

**jQuery пример:**

```javascript
$.ajax({
  method: 'GET',
  url: 'myservice/username',
  data: { id: '42' }
})
.done(function success(data) {
  alert('User\'s name is ' + data);
})
.fail(function fail(data, status) {
  alert('Request failed. Returned status of ' + status);
});
```

**Native `XMLHttpRequest` пример:**

```javascript
var xhr = new XMLHttpRequest();
xhr.open('GET', 'myservice/username?id=42');
xhr.onload = function() {
  if (xhr.status === 200) {
    alert('User\'s name is ' + xhr.responseText);
  }
  else {
    alert('Request failed. Returned status of ' + xhr.status);
  }
};
xhr.send();
```
### jQuery AJAX
jQuery опростява начина, по който разработчиците изпращат AJAX заявки.

Осигурява ниско ниво на интерфейс.

`jQuery.ajax()` - Изпълнява асинхронна HTTP (Ajax) заявка.

`jQuery.ajaxPrefilter()` - Позволява обработка на персонализирани AJAX опции или модифициране на съществуващи преди заявката да бъде изпратена и преди да бъде обработена от `$.ajax()`.

`jQuery.ajaxSetup()` - Позволява задаване на стойности по подразбиране за бъдещи AJAX заявки. Не се препоръчва използването му.

`jQuery.ajaxTransport()` - Създава обект, който се грижи за реалното предаване на AJAX данните.
### jQuery AJAX – Shorthand Methods
Може да заместим `jQuery` с `$`.

`jQuery.get()` - Зарежда данни от сървъра чрез HTTP GET заявка.

`jQuery.getJSON()` - Зарежда JSON-кодирани данни от сървъра чрез HTTP GET заявка.

`jQuery.getScript()` - Зарежда JavaScript файл от сървъра чрез HTTP GET заявка и го изпълнява.

`jQuery.post()` - Зарежда данни от сървъра чрез HTTP POST заявка.

`.load()` - Зарежда данни от сървъра и поставя върнатия HTML в съвпадащия елемент.
## Web Services - Communication between Systems and Components
### What is API?
API означава Application Programming Interface.

Предназначен е за комуникация между компоненти на система.

Това е набор от функции и спецификации, които софтуерни програми и компоненти следват, за да могат да си взаимодействат.

Примери:

JDBC – Java API, чрез който приложенията комуникират с бази данни.

Windows API – позволява на Windows приложения да комуникират с операционната система Windows.

Web Audio API – дава възможност за възпроизвеждане на аудио в уеб браузър с JavaScript.
### What is Web Service?
Уеб услугите реализират комуникация между софтуерни системи или компоненти по мрежата.

Ползват стандартни протоколи като HTTP, JSON и XML.

Използват се за обмен на съобщения, данни и извършване на операции.

Всички уеб услуги са API, но не всички API са уеб услуги.
### Web Services and APIs
Уеб услугите предоставят достъп до бекенд API през мрежата.

Могат да ползват различни протоколи и формати за данни: HTTP, REST, GraphQL, gRPC, SOAP, JSON-RPC, JSON, BSON, XML, YML и други.

Хостват се на уеб сървър (HTTP сървър).

Предоставят набор от функции, които могат да бъдат извиквани през Web (Web API).

RESTful API е най-популярният стандарт за уеб услуги.
## Web API / Server-Side API
Web API означава интерфейс за програмиране на приложения, достъпен през Интернет.

Използва се от уеб браузъри (SPA), мобилни приложения, игри, настолни приложения, уеб сървъри и други.

Сървърните Web API съдържат публично достъпни крайни точки (endpoints).

Крайните точки съответстват на предварително дефинирана система от заявки и отговори.

Комуникацията обикновено се осъществява във формат JSON или XML.

Обикновено се извършва чрез интернет протокол.

Най-често използваният протокол е HTTP – чрез уеб сървър, базиран на HTTP.
### ASP.NET Core Web API
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250527173712.png)

Създаването на Web API с ASP.NET Core е сравнително директно.

Създават се контролери, които съдържат действия (actions).

В този случай действията изпълняват ролята на крайни точки (endpoints).

Основната разлика между MVC и Web API е, че при MVC може да се връща изглед (view) – тоест готов HTML. При Web API обикновено се връща JSON или XML. Все пак може да се върне каквото се прецени – просто е необходимо то да бъде създадено и върнато ръчно.
### ASP.NET Core Web API Controller
```csharp
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    ...
}
```

Класът `ControllerBase` съдържа **общите, базови функционалности**, които и MVC, и Web API споделят — например работа с HTTP отговори, моделиране на заявки, връщане на JSON, статус кодове и т.н.

Класът `Controller` наследява `ControllerBase` и добавя специфичните за MVC **възможности за работа с изгледи (views)** — като връщане на `View()`, използване на `ViewBag`, `ViewData`, `TempData` и други помощни методи за манипулиране и подаване на данни към HTML страниците.

- `ControllerBase` е основата за API контролерите — фокусира се върху HTTP и връщане на данни.

- `Controller` разширява това с допълнителните възможности, нужни за класически уеб приложения с UI.

Основната логика и обработка на заявки е в `ControllerBase`.

API контролера трябва да наследява `ControllerBase` и да има атрибута `[ApiController]`. Това го прави специален контролер, който е оптимизиран за уеб API-та — автоматично обработва неща като валидация, маршрутизация и форматиране на отговори (например JSON).

Web API няма default route по подразбиране, затова се използват атрибути като `[Route("api/[controller]")]`, за да се дефинира ясно пътят към отделните действия и контролери. Това позволява по-гъвкаво и изрично задаване на маршрутизацията спрямо нуждите на API-то.

```csharp
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService productService;

    public ProductController(IProductService productService)
    {
        this.productService = productService;
    }
}
```

Моделът и услугата могат да бъдат всякакви. Това, което е съществено, са техниките около контролера, тъй като именно те дефинират API-то.

Можем да направим `BaseApiController`, който да наследява `ControllerBase` и да има атрибута `[ApiController]` и `[Route("api/[controller]")]`. След това другите ни API контролери просто наследяват този базов клас, за да не повтаряме кода и атрибутите във всеки контролер.

Можем да върнем модела с `return Ok(model);` и това ще върне HTTP статус 200 OK, като по подразбиране моделът се сериализира като JSON, освен ако не сме конфигурирали друго.
Клиентът може да реши в какъв формат иска да получи отговора, като изпрати HTTP header `Accept` със стойност, например, `application/json` или `application/xml`. Това позволява на сървъра да върне съответния формат според заявката на клиента.

`[ApiController]` анотацията предоставя няколко удобни функции.

Автоматично връщане на HTTP 400 отговори при грешки в състоянието на модела.

Автоматично определяне на източника на данни за параметрите (binding source inference)  .

Разпознаване на заявки с тип Multipart / Form-data.

Задължително използване на маршрутизиране чрез атрибути.

Връщане на подробна информация за проблема при статус кодове, показващи грешка.

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
  "title": "Not Found",
  "status": 404,
  "traceId": "0HLHLV31KRN83:00000001"
}
```

Автоматично връщане на HTTP 400 отговори.

Грешки при валидирането на модела автоматично водят до HTTP 400 отговор.

```csharp
if (!ModelState.IsValid)
{
    return BadRequest(ModelState); // This is no longer necessary
}
```

Автоматично разпознаване откъде да се вземат стойностите за параметрите (Binding Source Attributes).

Атрибутите определят откъде да се извлече стойността на параметъра.

```csharp
[FromBody]
[FromForm]
[FromHeader]
[FromQuery]
[FromRoute]
[FromServices]
```

Пример:

```csharp
[HttpPost]
public IActionResult Create(
    Product product, // [FromBody] is inferred
    string name)     // [FromQuery] is inferred
{
}
```

Автоматично разпознаване на заявки от тип Multipart / Form-data.

Постига се чрез поставяне на атрибута `[FromForm]` върху параметрите на метода.

`multipart/form-data` типът съдържание на заявката се разпознава автоматично.

Необходимо е използване на маршрутизиране чрез атрибути.

Маршрутизирането чрез атрибути става задължително.

Връщане на отговори с подробности за проблема при статус кодове, показващи грешка.

От версия ASP.NET Core 2.2, MVC автоматично преобразува резултатите при грешки.

Грешките се преобразуват в обекти от тип `ProblemDetails`.

`ProblemDetails` е:

Тип, базиран на HTTP API спецификация за представяне на грешки.

Стандартизиран формат за машинно четими детайли за грешката.

```csharp
if (product == null)
{
    return NotFound();
}
```

Автоматично генерираният отговор изглежда така:

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
  "title": "Not Found",
  "status": 404,
  "traceId": "0HLHLV31KRN83:00000001"
}
```

Този формат улеснява клиентските приложения при анализиране и обработка на грешки.

Тези функции са вградени и активни по подразбиране.

По подразбиране поведението е включено, но може да бъде променено.

```csharp
builder.Services.AddControllersWithViews()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Suppress Multipart/form-data inference
        options.SuppressConsumesConstraintForFormFileParameters = true;

        // Suppress binding source attributes
        options.SuppressInferBindingSourcesForParameters = true;

        // Suppress automatic HTTP 400 errors
        options.SuppressModelStateInvalidFilter = true;

        // Suppress problem details responses
        options.SuppressMapClientErrors = true;

        // ...
    });
```
### ASP.NET Core Web API (Return Types)
ASP.NET Core предлага няколко възможности за типовете на връщаните резултати от API методи.

Конкретен тип.

Най-простият вид тип за действие, при който методът винаги връща конкретен обект или колекция.

Тип `IActionResult`.

Подходящ е, когато в дадено действие е възможно връщане на различни типове резултати в зависимост от условието.

ASP.NET Core Web API (Return Types):

```csharp
[HttpGet]
public IEnumerable<Product> Get()
{
    return this.productService.GetAllProducts();
}

[HttpGet("{id}")]
[ProducesResponseType(200, Type = typeof(Product))]
[ProducesResponseType(404)]
public IActionResult GetById(int id)
{
    var product = this.productService.GetById(id);
    if (product == null) return NotFound();
    return Ok(product);
}
```

Първият метод винаги връща списък от продукти, затова е използван конкретен тип.

Вторият метод може да върне обект или грешка 404, затова е използван `IActionResult`.

Препоръчва се да се използва `ActionResult<T>` като тип за връщане.

```csharp
[HttpGet]
public ActionResult<IEnumerable<Product>> Get()
{
    return this.productService.GetAllProducts();
}
```

```csharp
[HttpGet("{id}")]
[ProducesResponseType(200)]
[ProducesResponseType(404)]
public ActionResult<Product> GetById(int id)
{
    var product = this.productService.GetById(id);
    if (product == null) return NotFound();
    return product;
}
```

Използването на `ActionResult<T>` дава възможност методът да връща както конкретен тип, така и стандартни HTTP отговори, като например 404 при липса на ресурс.
## Web API Methods
### Angular
Angular е фреймуърк за изграждане на сложни фронт-енд приложения.

Фокусира се върху цялостен набор от инструменти и добри практики.

Разработва се от екипа на Angular в Google.

```typescript
import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `<h1>Hello {{name}}</h1>`
})
export class AppComponent {
  name = 'Angular';
}
```

Angular е изцяло пренаписан на езика TypeScript, разработен от Microsoft.

TypeScript е типизиран надсет от JavaScript, който се компилира до обикновен JavaScript.

Може да работи във всеки браузър, на всяка платформа и операционна система. Напълно с отворен код.

В Angular няма концепция за "scope" или контролери.

Вместо това се използва йерархия от компоненти.

Това е основната разлика спрямо AngularJS (първата версия на Angular).

Повечето съвременни фронт-енд фреймуърци също следват тази архитектура.
### Angular Features
Кросплатформена поддръжка.

Едностранични приложения (SPA).

Прогресивни уеб приложения.

Нативни мобилни приложения (чрез Cordova, Ionic).

Десктоп приложения (чрез Electron).

Отличен набор от инструменти (CLI, среди за разработка, шаблони).

Голяма общност.

Лесно тестване, поддръжка на анимации и достъпност.

Може да работи с всякакъв тип бекенд (Web API, Node.js и други).
# Misc
# ChatGPT
## MVC vs SPA
🔁 **MVC (Model-View-Controller)**

- Each page change or action triggers a **full HTTP request** to the server.
    
- The server returns a **full HTML view**, and the browser reloads the whole page (causing flashing).
    
- `<a href="/something">` directly tells the browser to navigate to a new page.

⚡ **SPA (Single Page Application)**

- The app loads once; then all updates happen **within the same page** using **JavaScript**.
    
- Uses **AJAX (or fetch)** to make **HTTP requests in the background** to get data (usually JSON).
    
- The browser doesn’t reload or flash because only **specific parts of the DOM are updated**.
    
- Links are handled by a **client-side router** that intercepts navigation.

🔗 **Links in SPA vs MVC**

|Feature|Classic `<a>` (HTML)|SPA `<Link>` (React/Vue/etc.)|
|---|---|---|
|Is it standard HTML?|✅ Yes|❌ No (framework component)|
|Behavior|Triggers full page reload|Intercepts click, updates view without reload|
|Under the hood|Plain `<a>` with `href`|Renders `<a>` + uses `onClick` + `pushState`|
|Navigation type|Server-side routing|Client-side routing|

✅ **Additional Clarifications**

- **AJAX uses HTTP**, just like regular page requests, but it runs **in the background** using JavaScript, so the page doesn’t reload.
    
- `<Link>` (capital L) is **not an HTML tag** — it's a **helper component** from SPA frameworks (like `react-router-dom`) that enhances navigation behavior.
## API
An **API (Application Programming Interface)** is a set of defined rules that enable different software systems to communicate with each other. In the context of web development, the term typically refers to a **Web API**, which is a server application designed to receive and respond to HTTP requests.

A Web API exposes various **endpoints** — specific URLs that correspond to particular operations or resources (such as `/api/products` or `/api/users`). Each endpoint can handle different HTTP methods like `GET`, `POST`, `PUT`, and `DELETE`, allowing clients to perform actions like retrieving data, creating new entries, updating existing ones, or deleting records.

When a client application — such as a web app, mobile app, or another server — makes a request to one of these endpoints, the API processes the request and returns a response, most commonly in **JSON** format. The structure and content of this response depend on the endpoint accessed and the parameters or headers provided with the request.

While many APIs provide the same data and functionality to all clients, it's also possible to tailor responses based on the type of client or its needs. For instance, a mobile app and a web dashboard might receive slightly different data from the same API, either through distinct endpoints or by including information in the request that tells the API what version or type of response is needed.

In essence, a Web API acts as a structured interface between the backend logic and any number of client-facing applications, handling requests and serving data in a predictable, scalable manner.
## `IActionResult`
`IActionResult` is an **interface** in ASP.NET Core MVC that represents the result of an action method. It's part of the `Microsoft.AspNetCore.Mvc` namespace.

🔍 **What Is `IActionResult`?**

`IActionResult` is used as a **return type** for controller action methods in ASP.NET Core. It allows you to return **different types of results** (like a view, JSON, redirect, status code, etc.) from a single action method.

✅ **Why Use `IActionResult`?**

**1. Flexibility:**  
You can return different result types depending on conditions.

```csharp
public IActionResult GetItem(int id)
{
    var item = _repository.Find(id);

    if (item == null)
        return NotFound(); // returns 404

    return Ok(item); // returns 200 with data
}
```

If you used a concrete type like `JsonResult` or `ViewResult`, you would be limited to just that type.

🧱 **Common Implementations of `IActionResult`**

|Return Helper|Description|
|---|---|
|`Ok(object)`|Returns 200 OK with data|
|`NotFound()`|Returns 404 Not Found|
|`BadRequest()`|Returns 400 Bad Request|
|`Redirect(string url)`|Returns a redirect to a URL|
|`View()`|Returns a view result (for Razor views)|
|`Json(object)`|Returns JSON data (for legacy)|
|`StatusCode(int)`|Custom status codes|

🧪 **Example**

```csharp
public IActionResult Login(string username, string password)
{
    if (username == "admin" && password == "123")
        return Redirect("/dashboard");

    return Unauthorized();
}
```

Here, `IActionResult` makes it easy to return **different responses** without changing the method signature.

🔁 **Alternative: `ActionResult<T>`**

In ASP.NET Core 2.1+, you can use `ActionResult<T>` for strongly typed responses, e.g.:

```csharp
public ActionResult<UserDto> GetUser(int id)
{
    var user = _service.GetUser(id);
    if (user == null)
        return NotFound();

    return user; // implicitly returns Ok(user)
}
```

This combines the **flexibility of `IActionResult`** with **strong typing**.

**Summary**

- `IActionResult` is an interface that allows you to return various kinds of responses from a controller method.
    
- It improves flexibility and separation of concerns.
    
- It’s commonly used in **REST APIs** and **MVC controllers**.
## Swagger
Swagger in ASP.NET API is a framework and set of tools that help you design, build, document, and consume RESTful web APIs easily.

**More specifically:**

**Swagger** provides:

- **Interactive API documentation** — It generates a web page (usually at `/swagger` endpoint) where you can see all your API endpoints listed with details like HTTP methods, parameters, request bodies, and response types.
    
- **API specification** — Swagger uses the OpenAPI Specification (formerly called Swagger Specification), a standard format (usually JSON or YAML) that describes your API structure, routes, parameters, data models, and more.
    
- **Try-it-out feature** — From the generated documentation UI, you can directly test API endpoints by sending requests and seeing responses without needing external tools like Postman.
    
- **Code generation and client SDKs** — From the Swagger/`OpenAPI` spec, you can generate client code in many languages or even server stub code.

**In ASP.NET Core, using Swagger means:**

- You add **`Swashbuckle.AspNetCore`** NuGet package (most common tool for Swagger integration).
    
- In your Startup class, you configure Swagger generation and the Swagger UI middleware.
    
- When you run your API project, Swagger scans your controllers and actions, builds an `OpenAPI` description, and exposes a UI to explore and test your API.

**Why is Swagger useful?**

- Helps frontend and backend developers understand and collaborate on the API.
    
- Makes testing and debugging easier.
    
- Acts as live documentation that updates automatically as your API code changes.

**Quick example (ASP.NET Core minimal setup):**

```csharp
// In Program.cs or Startup.cs

builder.Services.AddSwaggerGen();

app.UseSwagger();
app.UseSwaggerUI();
```

After running the app, navigate to `https://localhost:<port>/swagger` to see the interactive documentation.

**Summary:**  
Swagger is a powerful tool that automatically creates interactive, standardized documentation for your ASP.NET APIs and helps you test and share your API easily.
# Bookmarks
[jQuery](https://jquery.com/)

[Selecting Elements | jQuery Learning Center](https://learn.jquery.com/using-jquery-core/selecting-elements/)

Completion: 27.05.2025