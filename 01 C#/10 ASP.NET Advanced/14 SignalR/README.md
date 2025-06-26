# General
## Candidates, Live Communication, Benefits
### Real-Time Applications
Реалновремевите приложения представляват по същество приложения за комуникация на живо.

Те функционират в рамките на времето, което обикновено се възприема като незабавно.

Поддържат двупосочна комуникация между клиента и сървъра.

Реалновремеви приложения се използват в много случаи.

- Gaming

- Търгове, залагания

- Борсови котировки, криптовалути

- Имейл клиенти

- Социални мрежи, чатове

Реалновремевите приложения използват комуникация на живо, за да се оптимизира тяхната функционалност.

Това ги прави по-интерактивни и по-удобни за използване.

Комуникацията на живо често изисква допълнителни уеб протоколи.

Например комуникационния протокол WebSocket.

Комуникацията на живо изисква някои процеси, които са неестествени за HTTP.

Сървърът изпраща данни, без клиентът да е направил заявка за тях.

Тази функционалност е позната и като Server Push – включена е в HTTP/2.

Двупосочен трансфер на данни през едно единствено съединение (Full-Duplex).

Реалновремевите приложения решават много проблеми в света на уеб приложенията.

Бърза доставка на информация.

Не трябва да се презарежда страницата, за да се провери актуална информация в реално време.

Ръчното презареждане би било катастрофално за приложения за криптовалути или залагания.

Интерактивност, удобство и използваемост.

Не трябва да се презарежда чат, за да се провери дали приятел е изпратил съобщение.

В противен случай, клиентите няма да бъдат доволни от подобни нужди на функционалността.

Комуникацията на живо в момента е нещо много разпространено.

Гледа не на live-stream също се счита за комуникация на живо.

Комуникацията на живо вероятно се използва най-много в gaming индустрията.

Multiplayer игрите се нуждаят от жива връзка с играчите.

Съществуват много събития в самата игра, които изискват тази функционалност.

Няма да е особено подходящо играчите да трябва да рестартират играта, само за да разберат, че са загубили.

Дори и най-простата онлайн игра на шах използва комуникация на живо.
## Polling, Server-Sent Events, Remote Procedure Calls
### Polling
Polling е техника, при която клиентът заявява данни на определени интервали от време.

Новите данни се заявяват често и периодично.

Работи с HTTP заявки и отговори.

Обикновено съществуват два начина за Polling.
#### Short Polling
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250626120133.png)

AJAX-базиран таймер, който изпраща заявки през фиксирани интервали.

Short Polling изисква по-малко сървърни ресурси.

На практика е безполезен, ако е необходима незабавна нотификация за събитие от сървъра.

Изразходва интернет трафика на клиентите (ако е ограничен).
#### Long Polling
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250626120718.png)

Сървърът задържа заявката, докато не се появят нови данни.

Long Polling уведомява незабавно при събитие на сървъра.

Подходящ е по отношение на използвания трафик.

По-сложен е за разработване и поддръжка.

Изисква повече ресурси от страна на сървъра.
### Server-Sent Events
SSE е технология, която позволява на браузъра да получава автоматични актуализации от сървъра чрез HTTP връзка.

Клиентът не трябва да прави заявка, за да провери дали има налични актуализации.

Представлява еднопосочен канал.

SSE изисква начално ръкостискане.

Сървърът оставя отговора отворен:

Докато няма повече събития.

Докато връзката не бъде счетена за неактивна.

Докато клиентът не затвори изрично първоначалната заявка.
### WebSocket
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250626141803.png)

WebSocket е компютърен комуникационен протокол.

Осигурява двупосочни (full-duplex) комуникационни канали.

Каналите се осигуряват през една единствена TCP връзка.

WebSocket се различава от HTTP, въпреки че са съвместими.

Работи през стандартна връзка (ws://) и защитена чрез SSL (wss://).

Поддържа HTTP проксита и междинни сървъри.

WebSocket позволява предаване на потоци от съобщения върху TCP.

Поддържа се в повечето съвременни браузъри към днешна дата.

WebSocket въвежда напълно нов начин за двупосочна комуникация.

Двупосочната комуникация (браузър – сървър) със сигурност е удобство.

Преди WebSocket това се постига по-скоро по нестандартизиран начин, с помощта на временни технологии, като например Comet.

Комуникацията чрез WebSocket се инициира чрез обикновено ръкостискане.
### Remote Procedure Call
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250626152749.png)

Remote Procedure Call е техника за комуникация между процеси.

Софтуерът предизвиква изпълнение на процедура в различно адресно пространство.

Използва модела клиент-сървър.

Прилага се за директна (point-to-point) комуникация между приложения.

Понякога се нарича извикване на функция или подпрограма.

Remote Procedure Calls по природа са синхронни.

Изпращачът (клиентът) трябва да изчака резултата от изпълнителя (сървъра).

Съществуват обаче начини за постигане на конкурентност.

Когато се извършва RPC:

Името на процедурата и параметрите се предават през мрежата.

Сериализират се.

Процедурата се изпълнява и връща резултати.

Резултатите се предават обратно.

Сериализират се.

Процесът на изпълнение продължава.
## Adding Real-Time Functionality to Your Apps
### ASP.NET Core `SignalR`
ASP.NET Core `SignalR` е библиотека, която улеснява добавянето на комуникация в реално време в уеб приложения.

Една от най-силните страни на `SignalR` е, че се опитва да надгради връзката до WebSocket, ако това е възможно. Ако обаче страните не могат да се договорят, връзката автоматично преминава през други налични технологии – като Server-Sent Events (SSE) или Remote Procedure Call (RPC), и в краен случай – до Polling, който работи навсякъде, където има HTTP комуникация.

Използвайки `SignalR`, не е необходимо ръчно да се обработват всички възможни варианти за комуникация – библиотеката автоматично избира този, който е най-подходящ и наличен в конкретния момент.

Функционалността в реално време позволява съдържание от сървъра да се изпраща незабавно към клиентите.

Подходящи случаи за внедряване на `SignalR` включват:

Приложения, които изискват чести актуализации от сървъра.

Игри, социални мрежи, чатове, гласуване, търгове, карти и GPS и др.

Dashboards и monitoring apps – travel alerts, търговски актуализации и др.

Приложения за съвместна работа – Agile приложения, приложения за екипни срещи и др.

Приложения, които изискват нотификации – имейл, чат, социални мрежи.

`SignalR` предоставя API за създаване на RPC (викане на отдалечени процедури) от сървъра към клиента.

Тези RPC извикват JavaScript функции на клиентите и обратно.

RPC процедурите се извикват от .NET код от страна на сървъра.

Някои от основните функционалности на `SignalR` включват:

Автоматично управление на връзките.

Изпращане на съобщения едновременно до всички свързани клиенти (broadcast).

Изпращане на съобщения до конкретен клиент или група клиенти.

Мащабиране с цел поемане на нарастващ трафик (чрез Azure `SignalR` Service).

`SignalR` предоставя API, което позволява реализиране на RPC – сървърът може да извиква функции на клиента, а клиентът – на сървъра. Разликата е в комуникационния канал, през който се осъществява това.

`SignalR` се стреми да използва WebSocket като основен механизъм за двупосочна комуникация. Идеята е следната: имаме клиент и сървър, като сървърът иска да извика метод върху клиента. Тъй като сървърът по принцип не може сам да направи HTTP заявка към клиента, използва вече отворения комуникационен канал – WebSocket.

Когато клиентът се свърже със сървъра за първи път, сървърът може да върне отговор със заявка за „upgrade“ на връзката към WebSocket. Ако това бъде прието, се отваря постоянен WebSocket канал между клиента и сървъра. Именно този канал се използва за изпращане на RPC заявки от сървъра към клиента – подават се данни и на клиента се изпълнява определена функция.

По същество, `SignalR` е RPC framework – инструмент, който позволява извикване на отдалечени функции. За пренос на информация използва най-ефективния наличен транспортен механизъм – в идеалния случай WebSocket, но ако това не е възможно, автоматично преминава към други технологии като Server-Sent Events или Polling, в зависимост от възможностите на клиента.

`SignalR` поддържа три техники за реализиране на реално време комуникация (RTC):

`WebSockets`.

Server-Sent Events.

Long Polling.

`SignalR` автоматично избира най-подходящия транспортен метод.

Изборът се извършва според възможностите на сървъра и клиента.
### ASP.NET Core `SignalR` Hubs
`SignalR` използва хъбове за установяване на комуникация между клиент и сървър.

Хъбът представлява high-level pipeline.

Позволява на клиента и сървъра да извикват методи един върху друг. Така както клиентът може да извиква RPC, който се намира на сървъра, така и сървърът може да извиква RPC, който се намира на клиента.

Хъбовете извикват клиентски код чрез изпращане на съобщения.

Тези съобщения съдържат името на метода и параметрите.

Обектите, изпратени като параметри, се десериализират.

Клиентът се опитва да открие метод с даденото име.

Когато клиентът открие метода, подава му параметрите.

Може да се подават строго типизирани параметри към методите.

Това позволява свързване на модел (model binding) на сървъра и обратно.

Тези параметри се десериализират чрез конфигуриран протокол.

`SignalR` предоставя два вградени протокола за хъбове.

Текстов протокол, базиран на JSON.

Бинарен протокол, базиран на `MessagePack`.

`MessagePack` обикновено създава по-малки съобщения, сравнено с JSON формата.
#### `MessagePack`
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250626182112.png)
`MessagePack` е ефективен бинарен формат за сериализация.

Подобен е на JSON, но е по-бърз и по-компактен.

Позволява обмен на данни между различни програмни езици.

Малките цели числа се кодират само в един байт.

Кратките низове обикновено изискват само един допълнителен байт, освен самото съдържание на низа.
#### Class Hub
API-то на `SignalR` Hubs предоставя клас `Hub`, който може да се използва в приложенията.

Класът `Hub` управлява връзките, групите и съобщенията.

Автоматично се справя и с интеграцията на системата за идентичност.

Това осигурява удобство и улеснява разработката на Hubs.

Класът `Hub` съдържа няколко полезни пропъртита:

`Context`, `Clients` и `GroupManager`.

Класът `Hub` включва методи за улавяне на събития, свързани с връзките.

`OnConnectedAsync()` и `OnDisconnectedAsync()`.
##### Context
Контекстът на Hub-а е представен чрез свойството `Context`.

Съдържа свойства с информация за текущата връзка.

Най-важните свойства, предоставени от `Context`, са:

`ConnectionId` – Връща уникалното ID за връзката.

`UserIdentifier` – Връща идентификатора на потребителя – `ClaimTypes.NameIdentifier`.

`User` – Връща `ClaimsPrincipal`, асоцииран с текущия потребител.

`Items` – Връща колекция от двойки ключ-стойност, използвана за споделяне на данни.

Контекстът съдържа също методите `GetHttpContext` и `Abort`.
##### Clients
Клиентите на Hub-а са представени чрез свойството `Clients`.

Съдържа свойства за комуникация между сървъра и клиентите.

Най-важните членове, предоставени от `Clients`, са:

`All` – Извиква метод на всички свързани клиенти.

`Caller` – Извиква метод на клиента, който е извикал метода на хъба.

`Others` – Извиква метод на всички свързани клиенти, с изключение на клиента, който е направил извикването.

`Clients` съдържа и много други методи за филтриране на клиенти.

Тези методи помагат да се посочат конкретни клиенти.
##### `GroupManager`
Мениджърът на групи е представен чрез свойството `Groups`.

Съдържа свойства за управление на групиране на клиенти.

Клиенти могат да бъдат добавяни към конкретна група чрез `AddToGroupAsync()`.

Клиенти могат да бъдат премахвани от конкретна група чрез `RemoveFromGroupAsync()`.

Групирането на клиенти помага при изпращане на съобщения към конкретна аудитория.

В реалновремевите приложения рядко е необходимо да се излъчва съобщение към всички клиенти.
##### `SignalR` Notes
Кодът на `SignalR` е асинхронен, за да се осигури максимална скалируемост.

Използва се `await`, когато се извикват асинхронни методи, които зависят от Hub-а.

Асинхронните методи могат да се провалят, ако Hub методът завърши първи.

Методите в Hub-а могат да връщат произволен тип и да приемат произволни параметри.

`SignalR` се грижи за сериализацията и десериализацията.

Hub-овете са временни (transient).

Не трябва да се съхранява състояние в свойство на класа на Hub-а.

Всяко извикване на метод в Hub-а се изпълнява в нова инстанция на Hub-а.
## Creating a Very Simplistic Chat Application
### Including `SignalR` in ASP.NET Core
Създава се празен проект.

В `Solution Explorer` се щраква с десния бутон върху проекта,  
избира се `Add` → `Client-Side Library`.

Конфигуриране на `SignalR`

```csharp
using SignalRChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add SignalR services to the container.
builder.Services.AddSignalR();

var app = builder.Build();

// Map the ChatHub endpoint.
app.MapHub<ChatHub>("/chatHub");
```

`ChatHub.cs `class file

```csharp
using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    // This method is called when a client sends a message.
    public async Task SendMessage(string user, string message)
    {
        // Broadcast the message to all connected clients.
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
```

Класът `ChatHub` наследява класа `Hub` от SignalR.

Класът `Hub` управлява връзките, групите и съобщенията.

Методът `SendMessage` може да бъде извикан от всеки свързан клиент.

Той изпраща полученото съобщение до всички клиенти.

JavaScript (Клиентски) код – `chat.js`

```javascript
// Create a connection to the hub.
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Client-side ReceiveMessage event. This will trigger when the back-end calls the ReceiveMessage method.
connection.on("ReceiveMessage", function (user, message) {
    // Handle the received message here.
});

// Start the connection and enable the send button if successful.
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

// Send message DOM event. This will trigger the back-end SendMessage method.
document.getElementById("sendButton").addEventListener("click", function (event) {
    // Logic to send the message goes here.
});

// This handler runs when the server calls the "ReceiveMessage" method.
connection.on("ReceiveMessage", function (user, message) {
    // Create a new list item element for the message.
    var li = document.createElement("li");

    // Append the list item to the message list on the page.
    document.getElementById("messagesList").appendChild(li);

    // Set the text content of the list item.
    li.textContent = `${user} says ${message}`;
});

// This handler runs when the user clicks the "Send" button.
document.getElementById("sendButton").addEventListener("click", function (event) {
    // Get the user's name and message input values.
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    // Invoke the "SendMessage" method on the server.
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });

    // Prevent the form from submitting and refreshing the page.
    event.preventDefault();
});
```
# Misc
# ChatGPT
## Server-to-Client RPC
In real-time applications (like chat apps or live notifications), it's possible for **both the client and server to call methods on each other**. This is achieved using technologies that support **bi-directional communication**, such as **`WebSockets`** or **`SignalR`**.

**Key Idea:**

- **The client registers methods** (handlers) when the connection is first established.
    
- **The server can later call those methods** by sending a message that includes the method name and any required data.
    
- The client listens for such messages and executes the corresponding method.

**Example:**

With **`SignalR`** (a .NET library that wraps `WebSockets`):

- Client:
    
```javascript
connection.on("ShowData", function(data) {
    // This method is triggered by the server
    displayInUI(data);
});
```

- Server:
    
```csharp
await Clients.Client(connectionId).SendAsync("ShowData", newData);
```

**Summary:**

> The **server "calls" a method on the client** by sending a message that **targets a method name** which has already been registered in the client’s code when the connection was first established.
# Bookmarks
Completion: 26.06.2025