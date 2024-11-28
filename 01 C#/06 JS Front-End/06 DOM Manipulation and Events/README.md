# General
## Dom Manipulations 
Тези манипулации са възможността ни да създаваме, добавяме (закрепваме) и изтриваме елементи в DOM дървото.
Манипулирането става чрез методи, като информация за тях и как работят има във файла за JavaScript в папката с ресурси.

Имаме възможността да създадем нови елементи, които да добавим в DOM дървото. Това означава, че не разчитаме само на оригиналния HTML, който е пристигнал и браузъра го е parse-нал в DOM дърво, след което ние да модифицираме създадените елементи. Динамично може да създадем нов елемент и да го закрепим в DOM дървото. Примерно може да добавим нов item в даден списък. Може да създаваме елементите чрез Factory функция в която извикаме метода за създаване на елементи, това се нарича Factory Pattern.
Новосъздадения елемент, ще стои в паметта като обект, но няма да се визуализира на браузъра, докато не го добавим някъде. Връзката ни с обекта ще е чрез променлива, като по този начин, може да го модифицираме и сменяме неговите пропъртита. След като елемента е създаден и модифициран, трябва да го закачим някъде в DOM дървото, за да може да го видим на екрана. Позицията където ще го закачим в DOM дървото, определя позицията на елемента на екрана.

Втори начин да създаваме елементи е чрез клониране ползвайки функцията `cloneNode()`. Тази функция приема като аргумент дали да копира само елемента или да го копира заедно с всичките му деца, тоест целия сегмент от DOM дървото.

Текста който добавяме чрез `textContent` ще бъде escape-нат, а текста добавен чрез `innerHTML` ще бъде prase-нат, но това създава опасност от XSS атаки.

В раздела `Network` се показва оригиналният HTML, който браузърът е заредил от сървъра, без манипулации: `Inspect` -> `Network` -> `Preview` и `Response`
- `Preview`: Показва HTML като визуализирана структура (като дървото в DOM).
- `Response`: Показва оригиналния суров HTML код, изпратен от сървъра.
## The DOM Event
Events са механизъм който ни дава възможност да следим за определено събитие, което е възникнало, по време на използването на апликацията. Примерно след като апликацията се зареди в браузъра на клиента и се изпълни, потребителя може да започне да взаимодейства с нея - натиска бутон, изпраща форма, скролва, мести мишка и тн.
Ние може да слушаме за тези събития и да подаваме функции, които да се справят при възникването на даденото събитие, наричат се event handlers. Това прави нашия сайт интерактивен. 
### Event Types in DOM API
Имаме различни event types, които са разделени на групи:
#### Mouse 
`click` - задейства се, когато цъкнем върху произволен елемент на екрана, няма нужда да е input или button. Това е най-известния mouse event, 
`mouseover` - задейства се, когато курсора на мишката влезне в периметъра на даден елемент.
`mouseout` - задейства се, когато курсора на мишката излезе от периметъра на даден елемент.
`mousedown` - задейства се, когато сме натиснали бутона надолу, без да го отпуснем.
`mouseup` - задейства се, когато отпуснем натиснатия бутон на мишката.
#### Keyboard
`keypress` - задейства се при натискането на произволен клавиш.
`keydown` - задейства се при натискането на първата половина от `keypress` на произволен клавиш.
`keyup` - задейства се при натискането на втората половина от `keypress` на произволен клавиш.
#### Touch
`touchstart` - задейства се при докосване на екрана.
`touchend` - задейства се при прекратяване на докосването.
`touchmove` - задейства се при движение на пръста върху екрана.
`touchcancel` - задейства се при прекъсване на докосването от системата.
#### Focus
`focus (got focus)` - задейства се, когато елементът получи фокус.
`blur (lost focus)` - задейства се, когато елементът изгуби фокус. Много е полезно за валидации, примерно докато някой си попълва мейла, ще задейства валидацията след като загуби фокус от елемента и чак тогава да му изкара съобщение, ако има проблем.
#### DOM / UI
`load` - задейства се, когато страницата или даден ресурс е напълно зареден.
`unload` - задейства се, когато страницата започне да се затваря или напуска. Този event е deprecated.
`resize` - задейства се при промяна на размера на прозореца на браузъра.
`dragstart` - задейства се при започване на влачене на елемент.
`drop` - задейства се при пускане на влачен елемент.
#### Form
`input` - задейства се при всяка промяна на стойността на елемент за въвеждане (например, текстово поле).
`change` - задейства се, когато стойността на елемент за въвеждане бъде променена и потребителят излезе от полето (например, след промяна на стойността в текстово поле или селектор).
`submit` - задейства се при изпращане на форма.
`reset` - задейства се при нулиране на форма, връщайки стойностите на полетата им към началните стойности.

https://developer.mozilla.org/en-US/docs/Web/Events - пълен списък с events.
### Event Handling
Това е функция, която ще се изпълни след като определен event е възникнал и се нарича callback function. Добра практика е името на функцията да завършва с `EventHandler` или поне `Handler`, за да се разграничава от обикновени функции.

Има три начина за регистриране на event:
- HTML Attributes - използва се много рядко. Всички събития започват с `on` когато са в атрибута, вътре в кавичките се пише JS - ` <button onclick="htmlAttributeEventHandler()">`.
- DOM Element Properties - използва се сравнително рядко. След като вземем даден елемент, event-ите са изредени като пропъртита и започват с `on`. Трябва да подадем функция, която ще се изпълнява при натискане на бутона: `myElement.onclick = myFunction;}`. Този начин задава функция, която ще се изпълни при кликване на елемента. Това обаче презаписва всяка друга функция, която е била зададена за това събитие. Може да има само един обработчик на събитие за даден елемент, за събитие от типа `click` (или всяко друго).
- DOM event handler - най-често ползвания и препоръчителен начин, като добавянето и махането на event listeners става чрез методи. Подробна информация за тях има във файла за JavaScript в папката с ресурси.
### Event Object
Този обект ни дава допълнителна информация за обстоятелствата около възникването на event-a. Това е нещо като report, как точно е възникнал event-a. Той се подава като първи аргумент на функцията, която ще бъде изпълнена при възникване на събитието. Ако event-a е регистриран като HTML атрибут, трябва да напишем `event` като аргумент на функцията. Този обект се подава и е достъпен само в рамките на изпълнение на callback функцията. Вътре в обекта има пропъртита с много подробна информация - кой елемент, координатите на екрана, вида на събитието и други.

# Misc
# ChatGPT
## Best Practice for DOM Element Selection: Limiting Search Scope for Performance Optimization
 DOM selection methods like `querySelector()`, `querySelectorAll()`, `getElementById()`, `getElementsByClassName()`, and `getElementsByTagName()` can be executed on any parent element, not just the `document` object. These methods allow you to search for elements **within the context of a specific parent**, reducing unnecessary searches across the entire DOM.

**Why It's a Good Practice:**

- **Performance**: Using these methods on a parent element limits the scope of the search, preventing the browser from having to scan the entire DOM. This can significantly improve performance, especially in larger documents.
- **Efficiency**: By narrowing the search area, you avoid potential slowdowns caused by searching the whole document when only a specific section is relevant. This is particularly important in dynamic applications where DOM elements are frequently added or modified.

**Example:**

Instead of searching the entire document:

```javascript
const element = document.querySelector('.myClass');
```

You can limit the search to a specific parent:

```javascript
const parent = document.getElementById('parent');
const element = parent.querySelector('.myClass');
```

This approach helps to reduce computational overhead and optimize the performance of your web page.
## Databases for Persistent User Preferences and Data Storage
**You said:**

 We have events in JS so our web site can be interactive with the users, however we need data bases to store the results permanently and not only until the refresh of the website. Manipulating and working with DOM we can save results, we can modify settings and visibility of the site, but we need databases in case there is a need to save anything permanently right?

**ChatGPT said:**

 Exactly! Here's a breakdown of your observation:

1. **Interactivity with JavaScript and Events**:
- JavaScript and events allow your website to become interactive.
- You can respond to user actions (like clicks, form submissions, etc.) and modify the DOM dynamically to show/hide elements, update content, or even store temporary data in memory.
2. **Temporary Data in the DOM**:
- Using the DOM, you can temporarily store or modify data and change the appearance of your website.
- However, this data **only exists as long as the page is loaded**. When the user refreshes or closes the page, the data is lost.
3. **Need for Permanent Data Storage**:
- If you want to **save results permanently** (e.g., user preferences, form submissions, or high scores), you need a **database**.
- A database allows you to store and retrieve information across sessions, even if the user leaves the site and returns later.
4. **Ways to Handle Persistent Data**:
- **Databases**: For larger or more structured data that needs to persist and be shared between users (e.g., MySQL, MongoDB).
- **Local Storage or Cookies**: For smaller data that stays specific to the user's browser (e.g., saving settings or preferences).

**Why Databases are Essential:**

Imagine an e-commerce site:

- Without a database, the shopping cart would be cleared every time the user refreshes the page.
- With a database, the cart data can be saved and retrieved, ensuring a seamless user experience.

By combining JavaScript for interactivity and databases for persistence, you can create fully functional, interactive, and reliable web applications.
## Event Listener and Variable Snapshot 
When adding event listeners inside a function that creates multiple elements (like list items), the listener captures the state of the variables (e.g., `aEl` and `liEl`) for each specific element, ensuring that each event listener refers to the correct element when triggered.

**Example:**

```javascript
function addItem() {
    const listEl = document.getElementById('items');
    const input = document.querySelector('input[type="text"][id="newItemText"]').value;
    const liEl = document.createElement('li');
    const aEl = document.createElement('a');

    aEl.setAttribute('href', '#');
    aEl.textContent = '[Delete]';
    aEl.addEventListener('click', () => {
        liEl.remove();  // This removes the correct li element
    });

    liEl.textContent = input;
    liEl.append(aEl);
    listEl.append(liEl);
}
```

In this example, each `aEl` (Delete link) gets its own event listener that interacts with the specific `liEl` created. The inner function captures a snapshot of the `liEl` and `aEl` elements at the time they are created, ensuring the delete action removes the correct item.
# Bookmarks
https://developer.mozilla.org/en-US/docs/Web/Events - пълен списък с events.

Completion: 01.01.2024