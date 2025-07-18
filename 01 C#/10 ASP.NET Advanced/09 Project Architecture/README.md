# General
## Web Application Designs
### Web vs Desktop vs Mobile vs IoT
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250603213804.png)

**Desktop Application**

PRO: Работи офлайн. Има достъп до системни ресурси.

CON: Налага се инсталиране и обновяване на всяко устройство поотделно.

**Mobile Application**

PRO: Достъпно е чрез app store. Може да работи офлайн. Има достъп до системни ресурси.

CON: Поддържат се различни платформи. Всяка актуализация изисква одобрение.

**Web Application**

PRO: Не се изисква изтегляне, инсталиране или обновяване.

CON: Необходима е интернет връзка. Има ограничен достъп до системните ресурси. 

Когато се търси достъп до системните ресурси на потребителската машина, браузърите умишлено ограничават такъв достъп с цел защита на потребителя. Най-разпространеното и практично решение към момента е използването на уеб сървър, който предоставя API. Към това API се изпращат заявки от уеб приложението, като същевременно сървърната страна разполага с необходимия достъп до системните ресурси.

Съществува и по-специализиран подход, който позволява директен достъп до системните ресурси на клиентската машина. Тази архитектура включва няколко компонента:

Необходимо е инсталирано десктоп приложение на клиентската машина.

Инсталира се и браузърен плъгин.

Уеб приложението комуникира с браузърния плъгин, който използва механизъм за междупроцесна комуникация (inter-process communication), за да обменя данни с десктоп приложението.

Десктоп приложението от своя страна има достъп до хардуера и системните ресурси.

Тази архитектура представлява хибриден модел между уеб и десктоп решение. От една страна има локално инсталирано приложение, от друга страна – уеб интерфейс, като връзката между двете се осъществява чрез браузърен плъгин. Това е сравнително надежден подход, тъй като осигурява възможност за автентикация както между уеб приложението и плъгина, така и между плъгина и десктоп приложението.

Алтернативно, би могло да се създаде уеб сървър, който работи на клиентската машина и има достъп до системните ресурси. Този вариант обаче крие сериозни рискове, тъй като такъв сървър може лесно да бъде компрометиран и използван за неоторизиран достъп до хардуера и данните на потребителя.

**Internet-of-Things Application**

PRO: Приложимо е за умни домове, носими устройства, автомобили, земеделие, градска инфраструктура и други.

CON: Необходимо е уеб свързване, за да се изпращат данни.
### Web Application Designs
**Web applications** са лесни за инсталиране, ползване и обновяване. Не са обвързани с конкретно устройство.

В повечето случаи се предпочитат пред настолните приложения.

Уеб приложенията включват два основни участника – клиент и сървър.

Съществуват два основни типа архитектура за уеб приложения.

**Multi-Page Application (MPA)** – традиционен подход, при който всяко действие зарежда нова страница. Има отделни страници и навигация между тях, като при всяко взаимодействие браузърът зарежда изцяло нова страница от сървъра.

**Single-Page Application (SPA)** – модерен подход, при който приложението зарежда само една страница, а съдържанието ѝ се обновява динамично чрез JavaScript. Вместо да се зареждат нови страници, се подменя част от съдържанието в същата страница при всяко действие на потребителя.
#### Multi-Page Applications
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250604095951.png)

**Multi-Page applications** работят по „традиционния“ начин. Всяка промяна изисква зареждане на нова страница в браузъра.

Основната част от presentation логиката на приложението се изпълнява на сървъра. HTML се рендира на сървъра и се връща като HTTP отговор.

Може да се използват AJAX и JavaScript за добавяне на логика в потребителския интерфейс от страна на клиента.

ASP.NET Core MVC и Razor Pages реализират този подход, използвайки Razor engine, за да рендерират HTML от страна на сървъра.

**Предимства на Multi-Page приложенията:**

Полезни са за всякакъв тип проекти.

Много добри и лесни за правилно SEO управление.

Използват последователни езици, инструменти и технологии.

**Недостатъци на Multi-Page приложенията:**

Front-end и back-end частите са силно свързани.

Разработката и поддръжката са сравнително сложни.

Изискват презареждане на страницата (и състоянието ѝ) при потребителски действия като навигация или изпращане на форма.
#### Single-Page Applications
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250604100034.png)

**Single-Page приложенията** изпълняват по-голямата част от потребителския интерфейс в браузъра. Това позволява разтоварване на сървъра, тъй като при голям брой потребители, сървърът не се натоварва с рендериране на HTML за всяка заявка. Вместо това, клиентската страна поема задачата да рендерира съдържанието, като сървърът просто предоставя нужните данни. Това прави архитектурата по-мащабируема и ефективна при натоварване. Така се прехвърля и по-малко информация, защото вместо целия рендериран HTML, се предава само JSON с нужните данни. Това намалява обема на трафика между клиента и сървъра и ускорява комуникацията, тъй като клиентът сам изгражда интерфейса въз основа на получените данни.

Не изискват презареждане на страницата по време на работа.

Цялото приложение е в една страница – съдържанието се променя динамично. Примери: Gmail, Facebook, Instagram и др.

SPA приложенията заявяват логика (JavaScript, шаблони) и данни поотделно.

**Back-end**: ASP.NET Core Web API, което връща данни във формат JSON.

**Front-end**: Angular, React, Vue.js, Blazor и др.

**Предимства на Single-Page приложенията:**

Анимирани, лесни за навигация и по-удобни за потребителя.

Бързи са – повечето ресурси се зареждат само веднъж.

Лесно се създава съответстващо мобилно приложение. Това важи и за MVC, при условие че бизнес логиката не е обвързана директно с контролерите, а е изнесена в отделни сървиси. Така back-end логиката може да бъде използвана от различни клиенти – уеб, мобилни или други.

Позволяват повторно използване на същия back-end.

**Недостатъци на Single-Page приложенията:**

Оптимизацията за търсачки (SEO) е трудна и сложна за реализация.

Бавно начално зареждане поради обемни front-end библиотеки и рамки.

В сравнение с „традиционните“ приложения, сигурността е по-слаба.

В повечето случаи се налага използването на две напълно различни технологии – за front-end и за back-end.
## Web Application Architectures
### Monolithic Applications
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250604143832.png)

**Monolithic приложенията** са еднослойни приложения.

Потребителският интерфейс и логиката за достъп до данни са комбинирани.

Това е най-простата форма на архитектура.

Деплоймънтът и поддръжката са сравнително лесни. Това се постига поради липсата на модулност и сложност.

Monolithic приложенията са подходящи за малки и средни проекти, когато обхватът на функционалността не изисква абстракции. 
### Service-Oriented Architectures (SOA)
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250604144146.png)

Обикновено включват функции в по-малки приложения (услуги).

Комуникацията се осъществява чрез SOAP/XML, WS.

Услугите комуникират чрез Enterprise Service Bus.

Услугите извършват множество дейности в рамките на един обхват на функционалност.

Всички услуги споделят една и съща база данни.
### Microservices
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250604221530.png)

**Microservices** са архитектура, базирана на множество малки приложения. Това е най-гъвкавата архитектура, но и най-трудна за деплой. Те са колекция от слабо свързани услуги. Размерът им трябва да бъде минимален.

**Микросървисната архитектура позволява непрекъснат деплоймънт (Continuous Deployment).** 

Микросървисите могат да се деплойват независимо един от друг. Пример за това е Amazon, където се извършват над 200 деплоймънта дневно.
Когато системата е разделена на множество малки и независими микросървиси, при промяна в един от тях (напр. `UserService`) е необходимо да се преминат само автоматизираните тестове, свързани с този конкретен компонент. По същия начин, QA екипът трябва да провери само него, което отнема минимално време. Това прави възможно бързото и често внедряване на промени в продукция.
Обратно, при монолитна архитектура всяка промяна изисква цялостно тестване на цялото приложение. QA екипът трябва да провери всички функционалности, което отнема значително време. Поради това деплоймънтът на монолитни приложения обикновено се извършва много по-рядко — веднъж на две седмици, месечно и т.н.

**Всеки сървис комуникира директно с останалите, когато това е необходимо.**

Например:

- `PaymentService` трябва да получи информация от `OrderService`, за да извърши плащане.
    
- `DeliveryService` трябва да:
    
    - получи данни от `OrderService`, за да знае какво да достави,
        
    - се свърже с `PaymentService`, за да провери дали поръчката е платена,
        
    - вземе адреса на клиента от `UserService`.

В микросървисната архитектура сървисите могат да комуникират директно помежду си, без нужда от централен компонент като ESB (Enterprise Service Bus). Обикновено това се случва чрез REST API или HTTP заявки.

Все пак, в много реални проекти се използва **message queue** (напр. RabbitMQ, Kafka), която позволява **асинхронна комуникация** между сървисите. Това осигурява по-добра устойчивост и по-голяма гъвкавост при натоварване, макар че не е задължително изискване за микросървисна архитектура.

**Всяка услуга разполага със собствена база данни, което носи както предимства, така и предизвикателства.**

Едно от основните предизвикателства е свързано със събирането на данни от множество източници. Например, ако използвахме **една обща база**, `DeliveryService` би могъл да изпълни **една SQL заявка** с `JOIN`, която обединява:

- платените поръчки от `Order` таблицата,
    
- информацията за плащането от `Payment`,
    
- и адреса на потребителя от `Users`.

Така на база един резултат можехме директно да подготвим заявка за доставка.

Но когато **всяка услуга има собствена база**, процесът е по-сложен:

1. `DeliveryService` първо изпраща заявка към `PaymentService`, за да вземе **всички успешни плащания за днес**.
    
2. След това прави заявка към `OrderService`, за да получи **поръчките, свързани с тези плащания**.
    
3. Накрая се обръща към `UserService`, за да получи **адресите на потребителите**, свързани с тези поръчки.

Чак след тези три отделни комуникации (чрез HTTP или Unix socket), `DeliveryService` разполага с нужната информация, за да създаде заявките за доставка.

Този подход създава предизвикателства:

- Имаме нужда от правилна **последователност на заявките**,
    
- Трябва да се извършва **оптимизация на броя заявки** (например първо да вземем плащанията, защото са по-малко от поръчките),
    
- Увеличава се **сложността на логиката**, която иначе би се решавала с един `JOIN`.

Архитектурата с отделни бази осигурява **по-добра независимост и скалируемост**, но за сметка на **по-сложна комуникация и събиране на данни** между услугите.

Комуникацията се осъществява чрез REST, Web API, HTTP.

При монолитната архитектура деплойваме само едно приложение. При service-oriented архитектурата е относително просто, защото деплойваме няколко приложения. При монолита, каквото и да се случи, трябва да деплойнем цялото приложение наново и няма гъвкавост.

При service-oriented архитектурата има относителна гъвкавост — ако се промени даден метод, например свързан с Book Service, се качват всички методи само за тази част.

При микросървисите имаме пълна гранулираност, тъй като всеки микросървис изпълнява само една конкретна функция. При Netflix, например, има над 5000 микросървиса — реално това са 5000 отделни приложения и 5000 отделни бази данни. Обикновено всеки микросървис работи със собствена база данни.

Всеки метод се реализира като отделно приложение, което може да деплойнем самостоятелно. Базата данни на микросървисите е много проста и обикновено съдържа само няколко таблици.

При монолитната архитектура бихме имали една голяма база данни с хиляди таблици. При микросървисите задачата се разбива на по-малки части, които се решават независимо — както в математиката, където една сложна задача се решава като се раздели на няколко по-прости.

Обикновено базата данни е основният bottleneck, защото колкото и бързи да са приложенията, ако имаме няколко приложения (както в service-oriented архитектурата), които ползват една и съща база, тя може да се претовари.

При микросървисите имаме отделна база данни за всеки микросървис и можем да разпределим тези бази на различни сървъри, което значително намалява риска от претоварване.

Това позволява да контролираме натоварването върху всеки компонент поотделно — например можем да стартираме 10 инстанции на даден "Order Service". Те ще използват 10 пъти повече ресурси, но ще увеличат производителността 10 пъти.

По този начин увеличаваме ресурсите само на проблемния компонент, а не на цялата система.

Можем да дублираме всяко парче толкова пъти, колкото ни трябва и когато ни трябва. Например ако знаем, че в определени дни от месеца ще има високо натоварване върху определена част от приложението, можем да деплойваме допълнителни сървъри само за тази част, а след това да ги махнем.

Това е много бърза и лесна операция и представлява голямо предимство на микросървисната архитектура.

Всяко парче комуникира през API, което елиминира coupling-а между тях.

Желателно е микросървисите да бъдат колкото се може по-малки. Целта на тази архитектура е, когато възникне нужда от скалиране, да можем да увеличим производителността **само на конкретното парче**, което е натоварено.

Разбира се, допълнителни ресурси ще се използват, но **само толкова, колкото изисква това малко парче**, а не цяла система.

Ако имаме по-голям микросървис, който съдържа повече логика, но ни трябва само част от него, няма как да скалираме само тази част — трябва да скалираме целия сървис. Това означава, че ще използваме повече ресурси, отколкото е реално необходимо и ефективността ще спадне.

Колкото по-голям е микросървисът, толкова по-лошо е съотношението между **производителност и използвани ресурси** при скалиране. Когато мултиплицираме даден сървис, **умножаваме и ресурса, който той заема**. Така че ако скалираме голям сървис, ще мултиплицираме голямо количество ресурс, което може да се окаже неефективно.

Обратно — ако микросървисът е малък и използва малко ресурси, скалирането му ще бъде по-леко, по-евтино и по-ефективно. Затова целим системата да бъде разделена на възможно най-малки и ясни функционални единици.

Разбира се, **трябва да се намери баланс** между:

- ефективното използване на ресурси
    
- скоростта на пускане на пазара (_time to market_)
    
- поддръжка и сложност

Твърде малки микросървиси могат да доведат до голямо количество комуникация и сложност, което увеличава разходите за разработка и поддръжка. Затова решението трябва да бъде **прагматично и съобразено с нуждите на проекта**.
### SOA vs Microservices
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250605190602.png)
### Example Microservices App
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250605190800.png)
## ASP.NET Core MVC vs Razor Pages
Освен MVC, ASP.NET Core предоставя и друг подход.

Появяват се Razor Pages – фреймуърк, наподобяващ Model-View-ViewModel.

Razor Pages наподобяват View Components.

Кодът за модела и контролера се включва директно в самата страница.

Позволява двупосочно обвързване (binding) на данни и опростена разработка.

Подходящо е за прости приложения.

Поддържа функционалност само за четене или елементарен вход на данни.

Единствената отговорност на всяка страница е ясно изразена.

**The MVC Approach**

Всяка MVC функционалност се състои от:

Шаблон за изглед (`.cshtml` файл), който показва данните на потребителя.

Контролер (`.cs` файл), който съдържа логиката за обработка на заявката и връзката между модела и изгледа.

Модел (`.cs` файл), който описва структурата на данните и може да включва бизнес логика или валидиране.

**The Razor Pages Approach**

Всяка Razor страница се състои от:

Шаблон за изглед (`.cshtml` файл), който действа като изглед.

Функционален `.cs` файл, който действа едновременно като модел и като екшън метод на контролера.
## AutoMapper
AutoMapper е библиотека, създадена с цел да улесни трансформирането на един обект в друг.

Може лесно да се интегрира в ASP.NET Core.

Добавя се като зависимост в контейнера за dependency injection.

Премахва нуждата от ръчно задаване на стойности на пропъртита.

Удобен е за използване в кода.

Предлага висока гъвкавост.

Позволява лесна конфигурация.

Използва се в милиони проекти.
### Setting
Настройване на AutoMapper в ASP.NET Core проект

Това действие автоматично инсталира основния NuGet пакет на AutoMapper.

AutoMapper се регистрира като зависимост в контейнера за dependency injection.

**AutoMapper настройка**

```powershell
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
```

```csharp
builder.Services.AddAutoMapper(typeof(Program));

public class HomeController : Controller
{
    private readonly IMapper mapper;

    public HomeController(IMapper mapper)
    {
        this.mapper = mapper;
    }

    // ...
}
```

> // `IMapper` се инжектира чрез конструктора, за да може да се използва за трансформиране на обекти.

**Използване на AutoMapper в ASP.NET Core проект**

`User` клас (модел от базата или домейн логиката)

```csharp
public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public string PasswordHash { get; set; }
}
```

`UserViewModel` (изглед модел, който не съдържа чувствителни данни)

```csharp
public class UserViewModel
{
    public string Name { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }
}
```

Mapping класът трябва да наследява `Profile`

```csharp
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Create mapping between User and UserViewModel
        CreateMap<User, UserViewModel>();
    }
}
```

**Без AutoMapper (ръчно мапване)**

```csharp
var viewModel = new UserViewModel
{
    Name = user.Name,
    Email = user.Email,
    Age = user.Age
};
```

**С AutoMapper (в бизнес логиката или контролер)**

```csharp
var viewModel = mapper.Map<UserViewModel>(user);
```

AutoMapper автоматично копира съвпадащите пропъртита между `User` и `UserViewModel`.
### Alternative
Имаме алтернативен подход, ако искаме да избегнем външна зависимост към AutoMapper. Ако mapping логиката е проста и няма да се повтаря често, може да я капсулираме директно в `ViewModel` класа.

- Избягва се нуждата от отделна конфигурация.
    
- Мапването става централизирано само веднъж — в конструктора или в статичен метод.
    
- Навсякъде в приложението може да се ползва лесно.

**Пример с конструктор**

```csharp
public class UserViewModel
{
    public string Name { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public UserViewModel(User user)
    {
        Name = user.Name;
        Email = user.Email;
        Age = user.Age;
    }
}

// Usage in service/controller
var user = new User { Name = "Ivan", Email = "ivan@abv.bg", Age = 30 };
var viewModel = new UserViewModel(user);
```

**Алтернативен вариант: статичен метод**

```csharp
public class UserViewModel
{
    public string Name { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public static UserViewModel FromUser(User user)
    {
        return new UserViewModel
        {
            Name = user.Name,
            Email = user.Email,
            Age = user.Age
        };
    }
}

// Usage in service/controller
var user = new User { Name = "Ivan", Email = "ivan@abv.bg", Age = 30 };
var viewModel = UserViewModel.FromUser(user);
```

**Предимства:**

- Централизирано мапване.
    
- Без външни библиотеки.
    
- По-ясен контрол какво се визуализира.

И при двата подхода:

- **се пише логиката веднъж**;
    
- **се избягва повтаряне**;
    
- **има нужда от поддръжка при промяна на моделите**.

Разликата е:

- дали предпочитаме **декларативна конфигурация** (AutoMapper)

- или **експлицитен контрол и прозрачност** (статичен метод).
## Abstracting the Data Access Logic
### Repository Pattern
Репозиторито е компонент, който капсулира логиката за достъп до данни. То предоставя интерфейс за четене, запис, промяна и изтриване на данни, без останалата част от приложението да е зависима от конкретната имплементация на базата данни.

Класическият Repository патърн предполага, че за всяка таблица (или агрегатен корен) се създава отделно репозитори. В него се дефинират методи като `GetById()`, `GetAll()`, `Add()`, `Update()`, `Delete()` и допълнителни действия, специфични за конкретния модел — например `ChangePrice()` за продукти.

Проблемът с този подход възниква, когато броят на таблиците стане голям (например 200). Това води до 200 отделни класа с поне по 4-5 метода, което увеличава значително поддръжката и дублира логиката.

Допълнително, EF Core вече предоставя Unit of Work и Repository поведения чрез `DbContext` и `DbSet`, което прави използването на собствени репозиториета в някои случаи излишно или дори контрапродуктивно.

По-добра практика е при необходимост да се използва **generic репозитори**, който обединява общата логика за работа с данни, и само при нужда да се добавят конкретни имплементации за специфични модели. Това позволява:

- Централизиране на достъпа до данните.
    
- Улесняване на бъдеща подмяна на базата или ORM-а.
    
- Минимизиране на дублиране и обем код.

Repository патърн е полезен, когато се прилага разумно — не е нужно всяка таблица да има собствен клас. Generic подходът е по-гъвкав и мащабируем, особено при по-големи приложения.

Централизират често използвана функционалност за достъп до данни.

Осигуряват по-добра поддръжка и възможност за тестване.

Разграничават инфраструктурата за достъп до данни от домейн слоя.

Позволяват зареждане на данни в паметта.

Данните се мапват от базата към домейн ентитита.

След като са в паметта, ентититата могат да се променят и да се запишат обратно.

Обикновено се имплементират конкретни двойки интерфейс-клас.

Съществуват и други подходи, като например използване на обобщени (generic) репозитори.
#### Generic Approach
```csharp
// Interface
public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> All();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<int> SaveChangesAsync();
}

// Implementation
public class EfRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly ApplicationContext context;
    private readonly DbSet<TEntity> dbSet;

    public EfRepository(ApplicationContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public IQueryable<TEntity> All() => dbSet;

    public void Add(TEntity entity) => dbSet.Add(entity);

    public void Update(TEntity entity)
    {
        dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        dbSet.Remove(entity);
    }

    public Task<int> SaveChangesAsync()
    {
        return context.SaveChangesAsync();
    }
}
```

Проблемът при класическата имплементация на `IRepository<TEntity>` е, че създава впечатление за изолираност на операциите – например, че `UserRepository.SaveChanges()` ще запише само промените по `User`. Реално обаче, `DbContext` следи всички ентити обекти в текущия обхват и при `SaveChanges()` ще запише всичко по всички обекти, които в момента се следят от `ChangeTracker`-а. Това поведение на `DbContext` като Unit of Work влиза в противоречие с подобна имплементация на `IRepository`.

**Алтернативен подход**

Централизирано, универсално `IRepository`, което не е обвързано с конкретен тип. Така ясно се комуникира, че `SaveChanges()` засяга всички промени в `DbContext`. По този начин, когато работим с няколко таблици, използваме едно общо репозитори и няма нужда да създаваме отделни за всяка от тях. Това позволява да се възползваме от вградената концепция за Unit of Work в Entity Framework и прави структурата на проекта по-ясна и поддържаема.

```csharp
// Interface
public interface IRepository
{
    Task AddAsync<T>(T entity) where T : class;
    Task UpdateAsync<T>(T entity) where T : class;
    Task DeleteAsync<T>(T entity) where T : class;
    IQueryable<T> GetAll<T>() where T : class;
    Task<int> SaveChangesAsync();
}

// Implementation
public class Repository : IRepository
{
    private readonly ApplicationDbContext context;

    public Repository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync<T>(T entity) where T : class
        => await context.Set<T>().AddAsync(entity);

    public Task UpdateAsync<T>(T entity) where T : class
    {
        context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync<T>(T entity) where T : class
    {
        context.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public IQueryable<T> GetAll<T>() where T : class
        => context.Set<T>();

    public async Task<int> SaveChangesAsync()
        => await context.SaveChangesAsync();
}
```

Когато често използваме `context.Set<T>()` в generic repository, повтаряме една и съща логика. Вместо това можем да създадем **private generic метод `DbSet<T>()`**, който централизира достъпа до `DbSet<T>`. Това прави кода по-чист, по-кратък и по-лесен за поддръжка.

```csharp
public class Repository
{
    private readonly ApplicationDbContext context;

    public Repository(ApplicationDbContext context)
    {
        this.context = context;
    }

    private DbSet<T> DbSet<T>() where T : class
    {
        return context.Set<T>();
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await DbSet<T>().AddAsync(entity);
    }

    public Task<IQueryable<T>> GetAllAsync<T>() where T : class
    {
        return Task.FromResult(DbSet<T>().AsQueryable());
    }

    public Task DeleteAsync<T>(T entity) where T : class
    {
        DbSet<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync<T>(T entity) where T : class
    {
        DbSet<T>().Update(entity);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}
```
## Object Relational Mapper (ORM)
### EF Core
Entity Framework Core е Object Relational Mapper (ORM).

Създава слой между приложението и източника на данни.

Картографира данните към релационни обекти.

EF Core предлага множество основни и удобни функционалности.

Генерира сложни и оптимизирани заявки за улеснение.

Превежда се от LINQ изрази и се кешира.

Управлява работната единица.

Следи промените в ентити обектите.
### Dapper
EF Core има цена за всички свои функционалности.

А тази цена е представянето (performance).

Все пак трябва да има по-бърза алтернатива.

Тук идва Dapper – micro ORM с отворен код.

Лек micro ORM с много висока производителност.

Dapper е „по-близо до метала“.

При работа с Dapper, SQL заявките се пишат ръчно. Dapper не предлага генератор на заявки или механизъм за автоматично изграждане на SQL като Entity Framework Core. 

Сложните заявки може да бъдат изключително трудни.

Не е подходящ за мързеливи разработчици.
### Databases
Разработката на приложение изисква избор на база данни.

Това е едно от най-важните решения при разработката.

Изборът е между релационна (SQL) и нерелационна (NoSQL) структура на данните.

SQL базите данни използват езика за структурирани заявки (SQL).

Включват дефиниране на данни, манипулиране на данни, заявки, програмиране и други.

NoSQL базите данни използват динамична схема за неструктурирани данни.

Данните могат да се съхраняват като колони, документи, графи или ключ-стойност двойки.
### SQL
SQL е изключително мощен, гъвкав и широко използван.

Представлява сигурен избор, особено при работа със сложни заявки.

Показва много висока производителност, дори при големи обеми от данни.

От друга страна, SQL може да бъде ограничаващ.

Необходими са предварително дефинирани схеми, които определят структурата на данните.

Всички данни трябва да отговарят на тази предварително зададена структура.

Това изисква значителна предварителна подготовка и планиране.
### NoSQL
Терминът NoSQL се използва за обозначаване на бази данни, които не са релационни и не използват задължително SQL като основен език за заявки, но това не изключва напълно използването на SQL или подобни на SQL синтаксиси в някои случаи.
NoSQL базите данни също имат своите предимства и недостатъци.

Могат да се създават документи без предварително дефинирана структура.

Всеки документ може да има своя уникална структура.

Полета могат да се добавят динамично, в движение.

Недостатъците също трябва да се имат предвид.

- Липса на стандартизация.

- Липса на консистентност на данните.
### SQL vs NoSQL
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250605232603.png)
# Misc
## Design Patterns History
Кристофър Александър (Christopher Alexander) е бил архитект и теоретик в областта на архитектурата и градоустройството. Той е един от пионерите, които са създали концепцията за **design patterns** — но първоначално в контекста на архитектурния дизайн, а не в софтуерното инженерство.

Неговата книга _A Pattern Language_ (1977) представя набор от повторяеми решения на архитектурни и градоустройствени проблеми, които са формализирани като "шаблони" (patterns). Тези идеи по-късно са адаптирани от програмисти и дизайнери на софтуер за решаване на архитектурни проблеми в софтуера, особено след като през 1994 г. Gang of Four (`GoF`) публикуват книгата _Design Patterns: Elements of Reusable Object-Oriented Software_, която ги прилага за програмиране.

Обобщено:

- Кристофър Александър е **архитект** и теоретик.

- Той създава **design patterns** за архитектурата и дизайна на градове/сгради.

- Неговите идеи вдъхновяват **software design patterns**.

**Целта не е сляпо следване на шаблони, а вътрешно разбиране на духа им** — и след това човек е свободен да ги надрасне.
# ChatGPT
## Coexisting API and MVC Projects in One Solution
Even if both your **API** and **MVC** projects are part of the **same Visual Studio solution**, they are:

✅ **Independent applications**

- Each has its **own `Program.cs`, `Startup.cs` (or `builder` setup)**, its own routing, middleware, etc.
    
- When you **run them**, each project spins up its **own server process** — typically hosted by **Kestrel**, and they listen on **different ports by default** (like `https://localhost:5001` and `https://localhost:5002`).

✅ **They don’t know about each other unless you make them**

- Being in the same solution is only for **convenience** (e.g. shared projects, easier development/debugging).
    
- Unless they explicitly **call each other** (e.g. MVC frontend makes HTTP calls to the API), they don’t interact.

**Example setup:**

```
MySolution/
│
├── MyApiProject/           → Runs on localhost:5001
├── MyMvcProject/           → Runs on localhost:5002
└── SharedModels/           → Optional shared library for DTOs, etc.
```

**What this means for routing:**

If both projects define `/products/details/5`, that's **totally fine** — they are on different ports and don't overlap.

**They only "conflict" when:**

- You deploy both to the **same domain and port**, e.g., on IIS or behind a reverse proxy, **without** configuring separate base paths.
    
- In that case, the web server needs to know:
    
    - `/api/...` → send to the API
        
    - everything else → send to the MVC app

They’re separate web servers unless you glue them together.
## Areas
In an **MVC project**, the idea of **Areas** is to help organize large applications by **logically grouping related functionality into separate sections**.

🔹 **What is an Area in MVC?**

An **Area** is like a **mini-MVC structure within the main MVC application**. Each Area has its own:

- **Controllers**
    
- **Views**
    
- **Models** (optional)
    
- **Routes**

This structure mirrors the main `Controllers`, `Views`, and `Models` folders of the app but scoped to a particular section.

🔹 **Why use Areas?**

When your application grows large and has many controllers and views, it becomes hard to manage. **Areas solve this by modularizing** the app.

**Example Use Cases:**

- Admin panel (`/Admin`)
    
- Customer section (`/Customer`)
    
- Staff-only dashboard (`/Staff`)
    
- API versions (`/Api/V1`, `/Api/V2`)

🔹 **Folder Structure Example:**

```
/Areas
    /Admin
        /Controllers
            - HomeController.cs
        /Views
            /Home
                - Index.cshtml
        /Models

/Customer
    /Controllers
    /Views
    /Models

/Controllers
/Views
```

🔹 **Routing in Areas**

Each Area must register its own routes. This is often done in a class like `AdminAreaRegistration.cs`:

```csharp
public class AdminAreaRegistration : AreaRegistration
{
    public override string AreaName => "Admin";

    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "Admin_default",
            "Admin/{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional }
        );
    }
}
```

🔹 **Accessing an Area**

The route includes the Area name:

```
/Admin/Home/Index  
/Customer/Orders/List
```

✅ **Summary**

**Areas** help keep your MVC project clean and maintainable by **dividing it into modular sections**, each with its own MVC triad. They’re ideal for **large projects with logically distinct parts**.
# Bookmarks
Completion: 05.06.2025