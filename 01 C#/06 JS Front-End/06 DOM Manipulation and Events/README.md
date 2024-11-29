# General
## DOM Manipulations 
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
## Event Types in DOM API
Имаме различни event types, които са разделени на групи:
### Mouse 
`click` - задейства се, когато цъкнем върху произволен елемент на екрана, няма нужда да е input или button. Това е най-известния mouse event, 
`mouseover` - задейства се, когато курсора на мишката влезне в периметъра на даден елемент.
`mouseout` - задейства се, когато курсора на мишката излезе от периметъра на даден елемент.
`mousedown` - задейства се, когато сме натиснали бутона надолу, без да го отпуснем.
`mouseup` - задейства се, когато отпуснем натиснатия бутон на мишката.
### Keyboard
`keypress` - задейства се при натискането на произволен клавиш.
`keydown` - задейства се при натискането на първата половина от `keypress` на произволен клавиш.
`keyup` - задейства се при натискането на втората половина от `keypress` на произволен клавиш.
### Touch
`touchstart` - задейства се при докосване на екрана.
`touchend` - задейства се при прекратяване на докосването.
`touchmove` - задейства се при движение на пръста върху екрана.
`touchcancel` - задейства се при прекъсване на докосването от системата.
### Focus
`focus (got focus)` - задейства се, когато елементът получи фокус.
`blur (lost focus)` - задейства се, когато елементът изгуби фокус. Много е полезно за валидации, примерно докато някой си попълва мейла, ще задейства валидацията след като загуби фокус от елемента и чак тогава да му изкара съобщение, ако има проблем.
### DOM / UI
`load` - задейства се, когато страницата или даден ресурс е напълно зареден.
`unload` - задейства се, когато страницата започне да се затваря или напуска. Този event е deprecated.
`resize` - задейства се при промяна на размера на прозореца на браузъра.
`dragstart` - задейства се при започване на влачене на елемент.
`drop` - задейства се при пускане на влачен елемент.
### Form
`input` - задейства се при всяка промяна на стойността на елемент за въвеждане (например, текстово поле).
`change` - задейства се, когато стойността на елемент за въвеждане бъде променена и потребителят излезе от полето (например, след промяна на стойността в текстово поле или селектор).
`submit` - задейства се при изпращане на форма.
`reset` - задейства се при нулиране на форма, връщайки стойностите на полетата им към началните стойности.

https://developer.mozilla.org/en-US/docs/Web/Events - пълен списък с events.
## Event Handling
Това е функция, която ще се изпълни след като определен event е възникнал и се нарича callback function. Добра практика е името на функцията да завършва с `EventHandler` или поне `Handler`, за да се разграничава от обикновени функции.

Има три начина за регистриране на event:
- HTML Attributes - използва се много рядко. Всички събития започват с `on` когато са в атрибута, вътре в кавичките се пише JS - ` <button onclick="htmlAttributeEventHandler()">`.
- DOM Element Properties - използва се сравнително рядко. След като вземем даден елемент, event-ите са изредени като пропъртита и започват с `on`. Трябва да подадем функция, която ще се изпълнява при натискане на бутона: `myElement.onclick = myFunction;}`. Този начин задава функция, която ще се изпълни при кликване на елемента. Това обаче презаписва всяка друга функция, която е била зададена за това събитие. Може да има само един обработчик на събитие за даден елемент, за събитие от типа `click` (или всяко друго).
- DOM event handler - най-често ползвания и препоръчителен начин, като добавянето и махането на event listeners става чрез методи. Подробна информация за тях има във файла за JavaScript в папката с ресурси.
## Event Object
Този обект ни дава допълнителна информация за обстоятелствата около възникването на event-a. Това е нещо като report, как точно е възникнал event-a. Той се подава като първи аргумент на функцията, която ще бъде изпълнена при възникване на събитието. Ако event-a е регистриран като HTML атрибут, трябва да напишем `event` като аргумент на функцията. Този обект се подава и е достъпен само в рамките на изпълнение на callback функцията. Вътре в обекта има пропъртита с много подробна информация - кой елемент, координатите на екрана, вида на събитието и други.
## this
this в контекста на events, сочи към `currentTarget`-a, ако е декларирано с function expression. Function expression-a създава context, който сочи върху елемента, за който се създаден event-a. Ако използваме стрелкови функции, `this` няма да сочи към `currentTarget` защото стрелковите функции нямат свое собствено `this`. Вместо това те унаследяват `this` от околната област (lexical scope), в която са декларирани. Затова те не могат да се използват, когато искаме `this` да е равно на `currentTarget`.

```javascript
div.addEventListener('click', function(e) {
    console.log(this === e.currentTarget); // Always true
});
```
## Event Propagation
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241129164707.png)

Това е начина по който event-a, се разпространява в DOM дървото. При възникване на event има три фази:
- Capture - event-та обхожда дървото от горе на долу, почва от root елемента и стига до елемента където сме натиснали, ако event-a е бил `click`. 
- Target - най-вътрешния елемент, който сме натиснали.
- Bubble - event-та се връща обратно нагоре. Bubble-ва през всеки един от елементите, докато не стигне до root елемента.

По default - event listener-a работи на bubble фазата. Това може да се промени, като ползваме третия аргумент на `addEventListener()` функцията, като трябва да подадем `{ capture: true }`, като това ще накара event-тите да се изпълняват още в първата фаза. 
Ако няколко елемента имат добавени същите event listeners, event handlers ще се изпълняват в зависимост от фазата, в която се намира събитието (capture или bubble). Например:
    - Ако събитието се е записало в **capture** фазата, първи ще се изпълни event handler-a на родителския елемент, тъй като събитието пътува отгоре надолу.
    - Ако събитието е записано в **bubble** фазата (по подразбиране), първи ще се изпълни event handler-a на целевия елемент и след това ще се движи нагоре към родителите.

Ако имаме няколко елемента, които реагират на същото събитие, и те са свързани с различни event handlers, те няма да се изпълняват едновременно, но ще се изпълняват по реда, определен от фазите на разпространение. Ако искаме да се изпълни само за един от елементите, трябва да ползваме метода `event.stopPropagation()` намиращ се в event object-a. Този метод спира по-нататъшното му разпространение в DOM дървото, така че event handlers на събитието няма да се изпълнят за други елементи, които се намират в пътя му.
## Prevent Default
`event.preventDefault()` се използва, за да предотврати изпълнението на стандартното поведение на събитието. Това е полезно, когато не искаме браузърът да извърши действията, свързани с дадено събитие, като например изпращане на форма или навигиране по линк.

**Пример:**

- За да спрем изпращането на форма:

```javascript
document.querySelector('form').addEventListener('submit', function(event) {
    event.preventDefault();  // Предотвратява изпращането на формата
});
```

- За да предотвратим навигацията при клик върху линк:

```javascript
document.querySelector('a').addEventListener('click', function(event) {
    event.preventDefault();  // Предотвратява навигацията по линка
    alert('You clicked the link, but the page will not change!');
});
```

Използва се, когато искаме да пренапишем стандартното поведение на елементите и да го заменим с обработка на събития чрез JavaScript.
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
## Event Listener and Variable Snapshot in Loops: Best Practice Considerations
When adding event listeners inside a function that creates multiple elements (like list items), the listener captures the state of the variables (e.g., `aEl` and `liEl`) for each specific element, ensuring that each event listener refers to the correct element when triggered. However, this approach can violate the **coupling principle**, as the event listener is tightly coupled with the outer variables, making the code harder to maintain and test.

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

**Better Practice:**

A better approach is to use the event object passed to the event listener to access the target element, avoiding reliance on external variables and reducing tight coupling. This makes the code cleaner and easier to maintain.

**Improved Example:**

```javascript
function addItem() {
    const listEl = document.getElementById('items');
    const input = document.querySelector('input[type="text"][id="newItemText"]').value;
    const liEl = document.createElement('li');
    const aEl = document.createElement('a');

    aEl.setAttribute('href', '#');
    aEl.textContent = '[Delete]';
    aEl.addEventListener('click', (event) => {
        event.target.parentElement.remove();  // This removes the correct li element using the event object
    });

    liEl.textContent = input;
    liEl.append(aEl);
    listEl.append(liEl);
}
```

In this improved version, we use the `event.target` property to reference the `aEl` that was clicked, which removes the corresponding `liEl`. This approach decouples the event listener from the outer variables, making the code more flexible and maintainable.
## Event Propagation
Event propagation is an essential concept in JavaScript that defines how an event flows through the DOM (Document Object Model) from the point where it originates (e.g., when you click on a button) to the root of the document, or vice versa.

**Detailed Breakdown of Event Propagation**

Event propagation refers to how events bubble up (or sometimes are captured before bubbling) through the DOM tree. When an event occurs (for example, a `click` event on a button), it doesn't just affect the target element (the button); it also affects its ancestors in the DOM tree, depending on the propagation phase.

The **three phases** of event propagation are:

1. **Capture Phase**
    - This phase starts from the **root** element and travels down to the target element where the event was triggered.
    - If an event listener is attached with the `capture: true` option, it listens during this phase.
    - The event starts at the `document` or the root of the DOM tree and propagates downwards to the actual element that triggered the event.
    - **This phase is the first one that runs when an event is triggered.**
2. **Target Phase**
    - This is the **exact moment** when the event reaches the target element.
    - If you're clicking on a button, this is where the event is fired on that button.
    - In this phase, the event is processed directly by the element that initiated the event.
3. **Bubble Phase**
    - After the event reaches the target element, it **bubbles up** from the target element to the root of the document (or until it encounters an element where the event is stopped).
    - In this phase, event listeners can listen for events and react as the event travels upwards.
    - By default, the event will bubble back up to the `document` (root) unless `stopPropagation()` is called to prevent further bubbling.

**When does the process start?**

The process of propagation starts when the **event occurs** on the target element (i.e., the event threshold is met). This means that when you click a button, for example, the event doesn’t immediately travel through the entire DOM. Instead:

1. **Capture Phase**: The event begins from the root element and moves **downwards** to the target element. This happens before the event reaches the target.
2. **Target Phase**: The event then triggers directly on the target element (the button).
3. **Bubble Phase**: After the event has reached the target element, it then **bubbles back up** from the target element towards the root element (document).

The event **does not start** traveling down until the event actually occurs (for example, a user clicking on an element), and it propagates based on the structure of the DOM.

**Visualizing Event Propagation**

Imagine this simple HTML structure:

```html
<div id="root">
  <div id="parent">
    <button id="target">Click me</button>
  </div>
</div>
```

Now, let's add event listeners in the Capture and Bubble phases:

```javascript
document.getElementById('root').addEventListener('click', () => {
  console.log('Root clicked (capture phase)');
}, { capture: true });

document.getElementById('parent').addEventListener('click', () => {
  console.log('Parent clicked (capture phase)');
}, { capture: true });

document.getElementById('target').addEventListener('click', () => {
  console.log('Target clicked (target phase)');
});

document.getElementById('parent').addEventListener('click', () => {
  console.log('Parent clicked (bubble phase)');
});

document.getElementById('root').addEventListener('click', () => {
  console.log('Root clicked (bubble phase)');
});
```

When you **click on the button** (id="target"), the event will propagate as follows:
1. **Capture Phase**:
    - The event will start at the `root` and travel down through the DOM to the `parent` and then to the `target` element. The event listeners in this phase will be triggered.
2. **Target Phase**:
    - The event will now trigger on the `target` element itself (i.e., the button).
3. **Bubble Phase**:
    - The event will then bubble back up from `target` to `parent` and then to `root`.

Here’s what the console output will look like:

```javascript
Root clicked (capture phase)
Parent clicked (capture phase)
Target clicked (target phase)
Parent clicked (bubble phase)
Root clicked (bubble phase)
```

**Key Points**

- **Capture** is the first phase, and it moves from the root to the target.
- **Target** is when the event hits the target element.
- **Bubble** is the last phase, where the event moves from the target back up the DOM.

**What happens when an event is triggered?**

The process starts when the event is triggered (the mouse click, for example). **Propagation** starts immediately after the event is fired on the target element. The event "moves" from the root to the target element in the **capture phase**, then it hits the target element in the **target phase**, and then the event **bubbles back up** to the root in the **bubble phase**.

**Why is this important?**

- **Event listeners on capture**: If you want to handle events before they reach the target element, you can use the capture phase (by setting `{ capture: true }`).
- **Event listeners on bubble**: If you want to handle events after they are triggered on the target element (default behavior), you can use the bubble phase.
- **Stopping propagation**: You can stop the event from propagating using the `event.stopPropagation()` method, which will prevent the event from continuing to bubble or be captured.

In summary, **event propagation** defines the flow of an event in three phases: capture (downwards), target (at the target), and bubble (upwards). The event starts propagating from the root element down to the target, then bubbles back up. The exact time the propagation process starts is when the event is triggered, such as a user clicking an element.

**You said:**

This is only true if we have multiple nested elements which trigger the same event right? If it was only one element then there is not a difference?

**ChatGPT said:**

Yes, you are correct. The concepts of event propagation (capture, target, and bubble) become more noticeable and relevant when dealing with **multiple nested elements**. However, when the event is triggered on **only one element**, and that element does not have any parent or child elements with listeners for the same event, the event propagation process doesn't really have a noticeable effect.

**Here's why:**

1. **Single Element**:
    - If you have just a single element with an event listener (e.g., a button with a `click` event), the event **does not propagate**. There is no parent or child element for the event to move through.
    - In this case, the event will trigger directly on the target element (i.e., the button), and no capture or bubble phase occurs.
    - The event listener will just respond to the target element, and that's it. So, **in this case, there is no observable difference between capture, target, and bubble**.

```html
<button id="myButton">Click me!</button>
```

```javascript
document.getElementById('myButton').addEventListener('click', function() {
  console.log('Button clicked!');
});
```

2. **Multiple Nested Elements**:
    - If you have nested elements (e.g., a `div` inside another `div`), the event will **propagate** through the parent-child relationship, going through capture, target, and bubble phases.
    - For example, if both a parent `div` and a child `button` element are listening for a `click` event, the event will first go through the **capture phase** on the parent `div`, then reach the target (the `button`), and finally **bubble** back to the parent `div`.
    
```html
<div id="parent">
  <button id="child">Click me!</button>
</div>
```

```javascript
document.getElementById('parent').addEventListener('click', function() {
  console.log('Parent clicked (bubble phase)');
});

document.getElementById('child').addEventListener('click', function() {
  console.log('Button clicked (target phase)');
});
```

- **Capture phase**: The event first reaches the `parent` element.
- **Target phase**: Then the event reaches the `child` element (the button).
- **Bubble phase**: The event bubbles back to the `parent` element.

If you click the button, you will see the following output:

```javascript
Button clicked (target phase)
Parent clicked (bubble phase)
```

**Key Takeaway:**

- **Single element with one event listener**: There’s no real difference in event phases. The event simply gets triggered on that single element, and there are no parent or child elements for it to propagate through.
- **Multiple nested elements**: The event will propagate through the DOM hierarchy, triggering listeners in the capture, target, and bubble phases. This is when you see the effects of event propagation in action.

So, **event propagation** mainly becomes relevant when you have a **hierarchy of DOM elements** (parent-child relationships) with event listeners for the same event type. You can only achieve event propagation (capture and bubble phases) with the `addEventListener()` method. When you use **HTML attributes** or **directly setting event properties** (e.g., `onclick`), you can't take advantage of event propagation, including the capture and bubble phases.

**Stopping the Propagation**

The `event.stopPropagation()` method is used to prevent the event from propagating (bubbling or capturing) further in the DOM tree. When an event is triggered, it travels through the DOM from the root element to the target element (Capture phase), and then back up from the target element to the root (Bubble phase).

By calling `event.stopPropagation()` in an event handler, you stop this propagation, so the event will not trigger other handlers on parent or child elements in the DOM tree.

**Example:**

```javascript
document.getElementById('parent').addEventListener('click', function() {
    console.log('Parent clicked!');
});

document.getElementById('child').addEventListener('click', function(event) {
    console.log('Child clicked!');
    event.stopPropagation();  // Stops the event from reaching the parent
});
```

In this case, when the child element is clicked, the event stops at the child and doesn’t propagate to the parent. The parent handler will not be triggered.

**Execution steps**

When multiple elements are affected by the same event (e.g., a `click` on nested elements), a **single event object** is created and travels through the DOM in three phases: **capture**, **target**, and **bubble**. During this travel, you can:

1. Control at which phase the event listener should activate (using the `capture` option in `addEventListener`).
2. Stop the event from continuing to propagate to other elements using methods like `event.stopPropagation()` or `event.stopImmediatePropagation()`.

This mechanism ensures that events are efficiently managed and can be customized based on the application’s needs.

1. **Default Behavior**: By default, event listeners execute during the **bubble phase**, not the capture phase. You don't need to specify anything special for this behavior—it’s the default for `addEventListener`.
2. **Bubble Phase Execution**:
    - After the event reaches the **most nested target element** (the element where the event originated), it starts the bubble phase.
    - The event "bubbles up" from the target element to its ancestors, executing event handlers attached to each ancestor in the order they are encountered during the upward traversal.
3. **Target Element is First**: Since the bubbling phase begins at the **target element**, the event handler attached to the target is executed first.
4. **Then Ancestors**: The event continues bubbling up, triggering the handlers of ancestor elements in sequence, moving toward the root element.

**Key Example:**

```html
<div id="outer">
  <div id="inner"></div>
</div>

<script>
  const outerDiv = document.getElementById("outer");
  const innerDiv = document.getElementById("inner");

  outerDiv.addEventListener("click", () => console.log("Outer DIV"), false);
  innerDiv.addEventListener("click", () => console.log("Inner DIV"), false);
</script>
```

If you click on the `innerDiv`, you’ll see:

```css
Inner DIV
Outer DIV
```

This happens because:
- **Inner DIV** executes first (it’s the target).
- **Outer DIV** executes afterward, as the event "bubbles" up.

**Summary:**

- **Bubble phase** starts after the event reaches the **most nested element (target)**.
- The **target element's handler** executes first, followed by handlers of ancestors, in the order of their relationship in the DOM tree.
## Closures and Retained Variables in Event Listeners
1. **Retained Variables**: Closures retain all variables from the outer scope, including primitives and objects. These variables persist in memory as long as the closure (e.g., an event listener) exists.
2. **Shared Values**:
    - If multiple event listeners are created from the same closure, they share the same variables, meaning updates to the variable by one listener affect all others.
    - This is because closures capture references to the variables, not copies.
3. **Isolated Variables**:
    - To give each event listener its own variable, create separate closures for each listener. This can be achieved using an IIFE or block-scoped variables (e.g., `let`).
4. **Primitives vs. Objects**:
    - **Objects**: Changes are reflected everywhere because closures retain references to them.
    - **Primitives**: Stored directly in the closure and updated in the shared scope.
5. **Key Example**:

```javascript
let sharedValue = 0;

document.querySelectorAll('button').forEach(btn => {
    btn.addEventListener('click', () => {
        sharedValue++; // Shared by all buttons
        console.log(sharedValue);
    });
});
```

All buttons share and modify the same `sharedValue`.

1. **To Avoid Sharing**: Use isolated closures:

```javascript
document.querySelectorAll('button').forEach((btn, index) => {
    btn.addEventListener('click', (() => {
        let counter = 0; // Unique to each button
        return () => {
            counter++;
            console.log(`Button ${index}: ${counter}`);
        };
    })());
});
```

Closures ensure variables are retained, but shared behavior depends on whether you design for shared or isolated scopes.
# Bookmarks
https://developer.mozilla.org/en-US/docs/Web/Events - пълен списък с events.

Completion: 29.11.2024