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
# Misc
# ChatGPT
# Bookmarks
[OWASP Top Ten | OWASP Foundation](https://owasp.org/www-project-top-ten/) - The industry standard list of the ten most critical web application security risks, published by the OWASP Foundation. Serves as a key framework for guiding secure coding and architectural best practices.

[Exploit Database - Exploits for Penetration Testers, Researchers, and Ethical Hackers](https://www.exploit-db.com/) - Public Archive of Known Vulnerabilities and Exploits.

[DotNet Security - OWASP Cheat Sheet Series](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html) - OWASP DotNet Security Best Practices Cheat Sheet.

Completion: 29.05.2025