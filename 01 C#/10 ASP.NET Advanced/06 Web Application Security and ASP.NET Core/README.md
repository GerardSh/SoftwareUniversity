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

Демонстрационен код има в демо папката.
### Why is XSS a Big Security Problem
Атакуващите могат:

Да откраднат бисквитки, session storage, local storage и други.

Да се представят като даден потребител, например чрез създаване на нов администраторски акаунт.

Да извършват действия от името на потребителя.

Да получат достъп до чувствителни данни на потребителя.

И други.
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
# Bookmarks
[OWASP Top Ten | OWASP Foundation](https://owasp.org/www-project-top-ten/) - The industry standard list of the ten most critical web application security risks, published by the OWASP Foundation. Serves as a key framework for guiding secure coding and architectural best practices.

[Exploit Database - Exploits for Penetration Testers, Researchers, and Ethical Hackers](https://www.exploit-db.com/) - Public Archive of Known Vulnerabilities and Exploits.

[DotNet Security - OWASP Cheat Sheet Series](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html) - OWASP DotNet Security Best Practices Cheat Sheet.

[Rick Strahl's Web Log](https://weblog.west-wind.com/)

Completion: 29.05.2025