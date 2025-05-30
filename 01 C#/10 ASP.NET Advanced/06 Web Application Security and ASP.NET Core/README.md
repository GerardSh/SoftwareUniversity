# General
## Common Web App Security Problems
**XSS, SQL Injection, CSRF, Parameter Tampering**

SQL инжекция.

Cross-site Scripting (XSS).

Манипулации на URL / HTTP заявки (Parameter Tampering).

Cross-site Request Forgery (CSRF).

DoS, DDoS и Brute Force атаки. DoS и DDoS атаките обикновено **не са на приложно ниво**, а действат на **мрежово или транспортно ниво** (напр. Layer 3/4 от OSI модела). Те целят да претоварят сървъра, мрежовата връзка или инфраструктурата чрез голям брой заявки, често без значение от съдържанието им. Brute Force атаките, от друга страна, **се извършват на приложно ниво** (Layer 7), защото включват опити за достъп чрез логически заявки към самото приложение (например многократни опити за вход с различни пароли).

Прекалено много информация в съобщенията за грешки.

Проблеми със сигурността в допълнителния софтуер и използваните NuGet пакети.

Най-често срещани проблеми със сигурността в уеб приложенията.

[OWASP Top Ten | OWASP Foundation](https://owasp.org/www-project-top-ten/)

[Exploit Database - Exploits for Penetration Testers, Researchers, and Ethical Hackers](https://www.exploit-db.com/)

[DotNet Security - OWASP Cheat Sheet Series](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html)
## Other Security Threats
Семантични атаки чрез URL/HTTP манипулации. Данните винаги трябва да се валидират от сървър страна.

Man in the Middle атаки. Препоръчва се използване на SSL във всички случаи.

Недостатъчен контрол на достъпа.

Различни форми на инжектиране на данни. Необходимо е данните да се пречистват преди обработка.

Phishing и социално инженерство. Добра практика е потребителите да бъдат обучени и информирани.

Проблеми със сигурността в използвания софтуер. Препоръчва се работа с най-новите налични версии.
## Security Fundamentals
Съществува широк набор от добре познати типове заплахи и атаки.

| Category              | Category Threats / Attacks                                                                                         |
| --------------------- | ------------------------------------------------------------------------------------------------------------------ |
| Input Validation      | Buffer overflow, cross-site scripting, SQL injection, canonicalization                                             |
| Parameter Tampering   | Query string manipulation, form field manipulation, cookie manipulation, HTTP header manipulation                  |
| Session Management    | Session hijacking, session replay, man-in-the-middle                                                               |
| Cryptography          | Poor key generation or key management, weak or custom encryption                                                   |
| Sensitive Information | Access sensitive code or data in storage, network eavesdropping, code/data tampering, Admin password in exceptions |
| Exception Management  | Information disclosure, denial of service                                                                          |

Съществува още по-широк набор от непознати заплахи и атаки.
## Cross Site Scripting (XSS)
**Injecting Unsafe HTML Code (with Scripts)**

XSS атаките позволяват на атакуващи да инжектират клиентски скриптове в уеб страници, които се разглеждат от потребителите.

Примерно: 

Client 1 публикува коментар, който съдържа скрипт. Макар скриптът да не се изпълнява веднага, съдържанието на коментара се записва в базата данни.

По-късно, когато друг потребител (напр. Client 2) отвори страницата с коментарите, сървърът връща съдържанието от базата данни без допълнителна проверка или пречистване.

В резултат, скриптът се изпълнява в браузъра на Client 2 с неговите потребителски права и в контекста на сайта.
### Demo
Имаме уязвимо ASP.NET Core чат приложение.

Потребител добавя

```html
<script>
alert('Hacked!')
</script>
```

След това се появява JavaScript изскачащ прозорец.

**With Image**

Имаме уязвимо JavaScript приложение за изображения.

Потребител добавя невалиден URL за изображение и добавя `onclick` събитие с JavaScript скрипт.

След това се появява JavaScript изскачащ прозорец.
### Why is XSS a Big Security Problem
Атакуващите могат:

Да откраднат бисквитки, session storage, local storage и други.

Да се представят като даден потребител, например чрез създаване на нов администраторски акаунт.

Да извършват действия от името на потребителя.

Да получат достъп до чувствителни данни на потребителя.

И други.

**Пример:**

Някой открива уязвимост в уебсайт, която позволява инжектиране на скриптове. 

Възползва се от нея и добавя зловреден скрипт.

Скриптът се задейства всеки път, когато потребител посети сайта. 

Информация като потребителско име, парола, бисквитки и други данни се изпращат към атакуващия.

Демонстрационен код има в демо папката.
### Protective measures
Razor изгледите по подразбиране осигуряват защита срещу XSS атаки.

Ако тази защита бъде заобиколена – например чрез `@Html.Raw(…)` – отговорността за сигурността преминава към разработчика.

Съществуват няколко важни правила, които трябва да се спазват, за да се гарантира сигурност:

Никога не трябва да се поставя непроверена информация директно в HTML изхода.

Преди да се включат недоверени данни някъде, трябва да се гарантира тяхната безопасност.

Това включва кодиране, парсване, валидация и проверка за зловредно съдържание.

Недоверени данни могат да се окажат на различни места в приложението:

URL адреси, HTML елементи, HTML атрибути, JavaScript код и други.

ASP.NET Core предоставя всички необходими механизми за защита на приложението.

Razor автоматично кодира целия изход, който идва от променливи.

Възможно е директно да се инжектират енкодери в изгледите и да се използват при нужда.

```csharp
@{ var untrustedInput = "<\"script\">"; }
@untrustedInput
// Output: &lt;&quot;script&quot;&gt;

@using System.Text.Encodings.Web;
@inject JavaScriptEncoder encoder;
@{ var untrustedInput = "<\"123\">"; }
<script> document.write("@encoder.Encode(untrustedInput)"); </script>
// Output: <script> document.write("\u003C\u0022123\u0022\u003E"); </script>
```

Могат да се използват и Encoder услугите, предоставени от ASP.NET Core:

`HtmlEncoder`  
`JavaScriptEncoder`  
`UrlEncoder`

Алтернативно, могат да се използват и статичните методи:

`WebUtility.HtmlEncode` и `WebUtility.HtmlDecode`
`WebUtility.UrlEncode` и `WebUtility.UrlDecode`

```csharp
<"123">        // original  
&#x3C;&#x22;123&#x22;&#x3E;  // HTML encoding  
\u003C\u0022123\u0022\u003E  // JavaScript encoding  
%3C%22123%22%3E  // URL encoding  
```
### `HtmlSanitizer`
`HtmlSanitizer` е .NET библиотека за пречистване на HTML фрагменти и документи от конструкции, които могат да доведат до XSS атаки.

[mganss/HtmlSanitizer: Cleans HTML to avoid XSS attacks](https://github.com/mganss/HtmlSanitizer)

Трябва да се инсталира NuGet пакета `HtmlSanitizer`, след което може да се използва по следния начин:

```csharp
var sanitizer = new HtmlSanitizer();

var html = @"<script>alert('xss')</script><div onload=""alert('xss')"""
 + @"style=""background-color: test"">Test<img src=""test.gif"""
 + @"style=""background-image: url(javascript:alert('xss')); margin: 10px""></div>";

var sanitized = sanitizer.Sanitize(html, "http://www.example.com");

// The expected output after sanitizing
Assert.That(sanitized, Is.EqualTo(@"<div style=""background-color: test"">"
 + @"Test<img style=""margin: 10px"" src=""http://www.example.com/test.gif""></div>"));
```
## SQL Injection
**Inject SQL Code in Unsafe Database Query**
Следните SQL команди се изпълняват:

Обичайно търсене (без SQL инжекция):

```sql
SELECT * FROM Messages WHERE MessageText LIKE '%JohnSnow%'
```

SQL инжектирано търсене (връща всички записи):

```sql
SELECT * FROM Messages WHERE MessageText LIKE '%%%%'
```

SQL инжектиране с INSERT команда:

```sql
SELECT * FROM Messages WHERE MessageText LIKE '%'; 
INSERT INTO Messages(MessageText, MessageDate) VALUES
('Hacked!!!', '1.1.1980') --%'
```

SQL инжектирано търсене с условие, което винаги е вярно:

```sql
SELECT * FROM Messages WHERE MessageText LIKE '%' or 1=1 --%'
```

Оригиналната SQL заявка:

```sql
String sqlQuery = "SELECT * FROM user WHERE name = '" + username + "' AND pass='" + password + "'";
```

Ако стойността на `username` е зададена на `Admin`, а `password` на `' OR '1'='1`, то резултатната заявка ще изглежда така:

```sql
SELECT * FROM user WHERE name = 'Admin' AND pass='' OR '1'='1'
```

Резултат:

Потребител с име **Admin** ще влезе в системата **без валидна парола**.

Причина:

Условието `OR '1'='1'` **винаги е вярно**, така че то обезсмисля всякаква проверка на паролата. Това е класически пример за **SQL инжекция**, която може да заобиколи автентикацията.
### Demo
**Normal Workflow:**

Имаме просто приложение с форма за вход, податлива на SQL инжекция.

Може да влезем с потребителско име **"Admin"** и парола **"`adminpass`"** – появява се съобщение за успешен вход.

Всички други комбинации на потребителско име и парола водят до съобщение за грешка.

**Attack Workflow:**

Сега използваме **SQL инжекция**, за да влезем с потребител "Admin", без да знаем паролата.

В полето за парола въвеждаме: `' OR '1'='1`

Това позволява успешен вход в системата без нужда от валидна парола.

Демонстрационен код има в демо папката.
### Protective measures
Не се конкатенира SQL с "+".

Използва се параметризиран SQL или съхранени процедури.

Escape-ват се и се почистват всички потребителски входни данни.

Никога не се свързваме с база данни с администраторски акаунт.

Не се съхраняват тайни в незашифрован вид.

Изключенията трябва да разкриват минимална информация.

**Sample Code**

Уязвим към SQL инжекция код:

```csharp
string sqlQuery = "SELECT * FROM Users WHERE username = '"
+ user.Username
+ "' AND Password = '"
+ user.Password + "'";

var userExists = this.data.Users.FromSqlRaw(sqlQuery).Any();

if (userExists)
{
    // User found
}
else
{
    // User not found
}
```

Същият код, пренаписан правилно с параметризирана заявка:

```csharp
var userExists = this.data.Users
    .Any(u => u.Username == user.Username && u.Password == user.Password);

if (userExists)
{
    // User found
}
else
{
    // User not found
}
```

Предпазване от SQL инжекции – примерен код.
#### Parameterized Queries
**Параметризирането на заявките е достатъчна мярка за защита срещу SQL инжекции**, тъй като ORM-ът валидира и обработва стойностите на параметрите безопасно. Все пак, от време на време се появяват доклади за уязвимости, при които е била пропусната инжекция. Това може да се случи, затова **е препоръчително редовно да обновяваме използваните пакети** и да следим за сигнали от доставчиците, като Microsoft, когато даден пакет е маркиран като уязвим (vulnerable).
Важно уточнение е, че стринга трябва да бъде **`FormattableString`**, а не просто обикновен **string**, за да може параметризирането да бъде ефективно и да се възползва от защитата срещу инжекции. Ако не използваме **`FormattableString`**, а просто обикновен string, заявката се изгражда като конкатениран текст и се изпраща към SQL сървъра като нормална заявка — тоест без параметри, което я прави уязвима на SQL инжекции.

Когато използваме **`FormattableString`**, ORM-ът или SQL клиента разпознава параметрите в заявката и ги изпраща отделно към SQL сървъра като параметризирани стойности. Така самата заявка в базата е със сигурни параметри, а не с директно вградени данни, което предотвратява инжекции.

С други думи:

- Обикновен **string** → опасно, директно вмъкване на стойности в заявката.
- **`FormattableString`** → сигурно, параметрите се изпращат отделно и се третират като стойности, а не като част от кода на заявката.

Именно това прави параметризирането ефективна защита срещу SQL инжекции.

**LINQ заявките в Entity Framework по подразбиране използват параметризирани SQL заявки** към базата.

Когато напишем нещо като:

```csharp
var user = db.Users.FirstOrDefault(u => u.Username == inputUsername);
```

Entity Framework **не вгражда директно `inputUsername` в SQL заявката**, а вместо това създава **параметър**:

```sql
SELECT TOP(1) * FROM Users WHERE Username = @__inputUsername_0
```

EF после подава стойността на `@__inputUsername_0` като отделен параметър.

Може ръчно да се параметризира заявка в Entity Framework с `SqlParameter` (или `DbParameter`). Това важи, когато се ползва `FromSqlRaw(...)`, който **не е автоматично безопасен**, ако се вкарват стойности директно в стринга.

```csharp
using Microsoft.Data.SqlClient; // For EF Core with SQL Server

string inputUsername = "Admin";

SqlParameter usernameParam = new SqlParameter("@username", inputUsername);

var users = db.Users
    .FromSqlRaw("SELECT * FROM Users WHERE Username = @username", usernameParam)
    .ToList();
```

Това генерира **параметризирана заявка** и е напълно безопасно.
## Cross-Site Request Forgery
**Submit a Form on Behalf of Unsuspecting User**

```csharp
<!-- SOME MULTI-COLOR USELESS CLICKBAIT CONTENT -->

<form action="http://good-banking-site.com/api/account" method="post">
	<input type="hidden" name="Transaction" value="withdraw">
	<input type="hidden" name="Amount" value="1000000">
	<input type="submit" value="Click to collect your prize!">
</form>
```

Cross-Site Request Forgery (CSRF / XSRF) представлява атака срещу сигурността в уеб среда чрез HTTP протокола.

CSRF е вид уязвимост, при която атакуващият се възползва от факта, че потребителят вече е автентикира (влязъл в акаунта си) в някое приложение — например уебсайта на банка.

Браузърът автоматично изпраща всички свързани **бисквитки** (cookies) със заявките към сайта, независимо дали заявката идва от истинския сайт или от злонамерен трети сайт.
### Demo
**Normal Workflow:**

Приложението е съвсем просто.

Потребителите могат да влизат в системата и да променят своята парола.

Няма защита срещу CSRF.

Приложението е достъпно на порт 5001.

Вход се извършва с потребителско име „guest“ и парола „guest123“.

Паролата може да бъде променена.

При успешна промяна се показва съобщение за успех на началната страница.

След това може да се влезе в системата с новата парола.

**Attack Workflow:**

Посещава се линк, който се намира на началната страница.

Той води към зловреден сайт.

При натискане на бутона [Click] се задейства атаката.

Зловредното приложение променя паролата чрез CSRF.

След това не е възможно да се влезе в системата със старите данни за вход.

Паролата е променена на „hacked!“.

Демонстрационен код има в демо папката.
### `AutoValidateAntiforgeryToken`
Tag Helper-ът `<form>` в ASP.NET Core автоматично добавя специално скрито поле към формата за защита от CSRF. За да бъде разпознат като Tag Helper, а не като обикновен HTML елемент, трябва да се използва поне един от специфичните `asp-` атрибути. В такъв случай Visual Studio ще оцвети тагa в зелено.

То съдържа произволна стойност, наречена anti-forgery token.

След това е необходимо тази стойност да се изисква при изпращане на заявката.

Това може да се приложи за конкретно действие. Може да се приложи и за всички действия в даден контролер. **Валидацията на анти-фалшификационния токен се използва предимно при POST заявки, където има риск от CSRF атаки.**

```csharp
[AutoValidateAntiforgeryToken]
public IActionResult SendMoney(…) { … }

[AutoValidateAntiforgeryToken]
public class ManageController : Controller
```

Възможно е да се приложи и глобално за цялото приложение.

```csharp
services.AddMvc(options =>
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
```

Anti-forgery токенът е **уникален за всяка сесия** и понякога дори за всяка форма. Когато потребителят зареди дадена страница с форма, сървърът:

1. **Генерира токен** и го записва някъде – обикновено в сесия, куки (cookie) или криптиран механизъм.
    
2. **Вгражда токена в HTML формата** като скрито поле.
    
3. При изпращане на формата, сървърът:
    
    - взема стойността от скритото поле.
        
    - също така взема стойността от сесията или куки-то.
        
    - и проверява дали двете съвпадат.

Ако **не съвпадат**, формата се отхвърля.

Атакуващият не може просто да копира токена, защото **няма достъп до HTML страницата и токена на жертвата**. Причината е:

- HTML съдържанието и скритото поле с токена се изпращат към браузъра на жертвата.
    
- Заради **Same-Origin Policy** зловредният сайт **не може да чете съдържанието** на страниците, заредени от друг домейн (в случая – от банката).
    
- Следователно, дори и да създаде фалшива форма, **атакуващият не знае валидния токен** на жертвата и не може да го вмъкне.

Анти-фалшификационният токен в ASP.NET Core **зависи от Data Protection ключове**, които се използват за подписване и валидация. Ако ключовете **липсват** или **не са достъпни** (напр. при рестартиране на приложението, липса на конфигурация или в production среда без персистиране), токенът няма да може да се валидира.

По подразбиране в development режим ключовете се пазят локално, но в production трябва **изрично да се конфигурира** място за съхранение – например папка, база, Azure или Redis.
### Protective measures
Използва се anti-forgery токен.

Добавя се допълнителна автентикация при чувствителни действия.

Задава се флагът `SameSite` за бисквитките.

```
Set-Cookie: CookieName=CookieValue; SameSite=Strict;
```

Следва се RESTful подход при проектиране на приложението.

Активира се защита чрез CORS.

**Примерен сценарий с банка:**

1. Потребителят се логва в истинския сайт на банката — `bank.com`. Браузърът съхранява **сесийната бисквитка** (например `sessionid=abc123`).
    
2. Потребителят е оставил сесията активна (не се е разлогнал) и междувременно посещава фалшив сайт — например `freemoney.com`, който прилича на банката, но не е реалният сайт.
    
3. В този фалшив сайт е вграден скрит HTML код, например:

```csharp
<form action="https://bank.com/transfer" method="POST">
    <input type="hidden" name="toAccount" value="HACKER_ACCOUNT" />
    <input type="hidden" name="amount" value="1000" />
    <input type="submit" value="Click here to claim your prize!" />
</form>
```

4. Ако потребителят кликне бутона (или ако формата се изпрати автоматично чрез JavaScript), браузърът ще направи реална заявка към `bank.com`, като **автоматично изпрати и сесийната бисквитка** (защото сайтът е доверен и вече е отворен).
    
5. Ако в системата на банката няма допълнителна проверка (като **CSRF токен**, допълнителна верификация или предупреждение), тогава заявката ще бъде приета като легитимна и парите ще бъдат преведени към сметката на атакуващия.

Банката "мисли", че тази заявка е изпратена доброволно от потребителя, защото изглежда идентична на нормална заявка и идва със съответната бисквитка.

**Как се защитава?**

- Чрез **CSRF токени** – уникални скрити стойности, които се включват във всяка форма и които не могат да бъдат познати от външен сайт.
    
- Чрез **допълнително потвърждение** – например изскачащ прозорец "Сигурни ли сте, че искате да преведете X лв. към Y?"
    
- Чрез **не се разчита само на cookies за автентикация**, а комбиниране с други механизми като headers, които външен сайт не може да изпрати.
## Parameter Tampering
**Changing Input Parameters at the Client Side**

Parameter Tampering е манипулация на параметрите, които се обменят между клиент и сървър.

Променят се query strings, request bodies или бисквитки.

Пропускат се проверки на данните или се инжектират допълнителни параметри.
### Demo
Има просто приложение, което показва данни по ID.

Не се извършва проверка на правата за достъп.

Хакер може да смени ID-то на прегледа в URL адреса.

Така получава достъп до данни на други потребители.

Демонстрационен код има в демо папката.
### Protective measures
Проверяват се входните параметри преди достъп до базата данни.

Формите в сайта съдържат вградена защита.

Използва се регулярни изрази (regex) за ограничаване или валидиране на данни.

Избягва се нежелана или скрита информация.

Криптират се бисквитките за сесията.

Една от най-важните защити срещу **parameter tampering** е да се провери дали **конкретният потребител има право да достъпва или променя ресурса**, за който е подадена заявката.

**По-конкретно, предпазването включва:**

Проверка на **идентичността** – кой е потребителят, направил заявката (чрез автентикация).

Проверка на **правата (авторизация)** – има ли този потребител достъп до конкретния ресурс (напр. чуждо ID в URL: `/Order/1234`).

Не трябва да се разчита само на скрити полета или frontend логика – attacker-ът може да ги промени.

**Пример:**

Потребител A вижда URL като:

```
GET /Invoices/1001
```

и решава да смени на:

```
GET /Invoices/1002
```

Без допълнителна проверка от страна на сървъра, това може да даде достъп до чужда фактура.

Решението е:

```csharp
if (invoice.UserId != currentUser.Id)
{
    return Forbid();
}
```

**Обобщение:**

За да се защитим от parameter tampering, трябва **винаги да се прави проверка дали текущият потребител има право да достъпи или промени дадения ресурс**, независимо какъв параметър е подаден в заявката.
## Cross Origin Resource Sharing (CORS)
Сигурността в браузъра предотвратява уеб страница да изпраща заявки към домейн, различен от този, който я е заредил (нейния origin).

Това ограничение се нарича Same-Origin Policy (SOP).

Тази политика също така пречи на зловредни сайтове да четат данни от нашия сайт.

Понякога обаче е необходимо да се позволи на други сайтове да заобиколят това ограничение.

Крос-домейн заявките към нашето приложение може да станат нужни в даден момент.

Тук идва на помощ Cross Origin Resource Sharing (CORS).

Тази защита работи само в браузъри, които спазват Same-Origin Policy.

Ако някой използва инструменти като Postman или друг клиент за директни HTTP заявки, тези ограничения не важат.

Затова е важно да се прилагат допълнителни сървърни проверки и автентикация, за да се предпази приложението от нежелани заявки независимо от клиента.

CORS е стандарт на W3C, който позволява на сървър да „отпусне“ ограничението на Same-Origin Policy (SOP).

С помощта на CORS сървърът може изрично да разреши някои cross-origin заявки.

Това не означава, че всички cross-origin заявки ще бъдат разрешени.

Два URL адреса имат еднакъв origin, ако имат

еднакви scheme, host и port (според RFC 6454).

Примери за URL-та с един и същи origin:

[https://example.com/foo.html](https://example.com/foo.html)

[https://example.com/bar.html](https://example.com/bar.html)

Примери за различен origin:

[https://example.net](https://example.net) — различен домейн.

[https://www.example.com/foo.html](https://www.example.com/foo.html) — различен субдомен.

[http://example.com/foo.html](http://example.com/foo.html) — различен scheme (http vs https).

[https://example.com:9000/foo.html](https://example.com:9000/foo.html) — различен порт.

**Пример за CORS**

Преди да изпрати основната заявка, клиентът прави предварителна заявка (preflight):

```
OPTIONS /resources HTTP/1.1
Host: api.example.com
Origin: example.com
Access-Control-Request-Method: DELETE
Access-Control-Request-Headers: Authorization
```

Тази preflight заявка проверява дали сървърът разрешава метода DELETE и заглавието Authorization за cross-origin заявка от example.com.

Сървърът отговаря с необходимите Access-Control-Allow-* хедъри, които показват кои методи и хедъри са разрешени.

```
HTTP/1.1 200 OK
Access-Control-Allow-Origin: *
Access-Control-Allow-Methods: DELETE
Access-Control-Allow-Headers: Authorization
```

Ако сървърът потвърди, клиентът изпраща реалната DELETE заявка със съответния Authorization хедър.

```
DELETE /resources HTTP/1.1
Host: api.example.com
Origin: example.com
Authorization: Bearer…
```

Така браузърът гарантира, че cross-origin заявките се извършват само ако сървърът е изрично разрешил това.

**CORS в ASP.NET Core се настройва**

Глобално чрез middleware

За конкретно действие (Action) или контролер чрез атрибут

Пример за глобална настройка:

```csharp
builder.Services.AddCors();

app.UseCors(builder =>
    builder.WithOrigins("http://example.com"));
```

Пример за разрешаване на CORS само за конкретно действие:

```csharp
[HttpGet]
[EnableCors("AllowSpecificOrigin")]
public ContentResult GetTest()
{
    return Content("test");
}
```

Пример за изключване на CORS за конкретно действие:

```csharp
[HttpGet]
[DisableCors]
public string Version()
{
    return "1.0.0";
}
```
# Misc
# ChatGPT
## `Html.Raw()`
In ASP.NET (particularly in Razor views), `Html.Raw()` is a method used to **output HTML markup without encoding it**. By default, Razor automatically HTML-encodes any content it outputs to protect against **cross-site scripting (XSS)**. However, sometimes you want to output HTML that **should not** be encoded — that’s when `Html.Raw()` is useful.

**Example**

```csharp
@{
    var message = "<strong>Hello, world!</strong>";
}

@message         // Outputs: &lt;strong&gt;Hello, world!&lt;/strong&gt;
@Html.Raw(message)  // Outputs: <strong>Hello, world!</strong>
```

**When to Use `Html.Raw()`**

Use it **only when you are sure** that the content is safe and **doesn't come from untrusted sources**, because you're bypassing Razor’s automatic protection against XSS.

**Summary**

- `Html.Raw()` tells Razor to **skip encoding** the output.
    
- It is useful for **injecting raw HTML**.
    
- **Be careful**: if used improperly with user input, it can open the door to XSS attacks.
## Tag Helpers
In a Razor View in ASP.NET Core MVC, the **color coding** in Visual Studio (or Visual Studio Code with proper extensions) gives you visual feedback on what kind of tag you're working with:

- ✅ **Green tags** (like `<form asp-action="..." method="post">` or `<input asp-for="..." />`) indicate you're using **Tag Helpers**. These are server-side components that generate HTML dynamically.
    
- 🔵 **Blue tags** (like `<div>`, `<span>`, `<input type="text" />` without any `asp-` attributes) are just **standard HTML tags**, which will be rendered as-is on the client side.

**So to summarize:**

|Tag Type|Appearance|Meaning|
|---|---|---|
|Tag Helper|Green|Razor syntax with `asp-*`|
|Standard HTML Tag|Blue|Plain HTML, no Razor logic|
# Bookmarks
[OWASP Top Ten | OWASP Foundation](https://owasp.org/www-project-top-ten/) - Индустриалният стандартен списък на десетте най-критични рискове за сигурността на уеб приложенията, публикуван от фондацията OWASP. Служи като ключова рамка за насочване към сигурно кодиране и архитектурни добри практики.

[Exploit Database - Exploits for Penetration Testers, Researchers, and Ethical Hackers](https://www.exploit-db.com/) - Публичен архив на известни уязвимости и експлойти.

[DotNet Security - OWASP Cheat Sheet Series](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html) - OWASP Cheat Sheet с най-добри практики за сигурност в .NET

[Rick Strahl's Web Log](https://weblog.west-wind.com/) - блог с полезна информация.

[mganss/HtmlSanitizer: Cleans HTML to avoid XSS attacks](https://github.com/mganss/HtmlSanitizer)

Completion: 29.05.2025