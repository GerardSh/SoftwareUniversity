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
# Bookmarks
[jQuery](https://jquery.com/)

[Selecting Elements | jQuery Learning Center](https://learn.jquery.com/using-jquery-core/selecting-elements/)

Completion: 27.05.2025