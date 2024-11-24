# General
DOM (Document Object Model) - се използва посредством JavaScript и е отделна система, но двете вървят заедно и чрез тях може да създаваме апликации.
JS е инструмента, а DOM-а ни дава възможността да създаваме web апликации.
## Browser Object Model (BOM)
Браузъра ни дава възможност да достъпваме определени функционалности, които той има и ни ги предоставя през определен API, който е формиран като BOM.
Тези ресурси се достъпват през конкретни обекти, които ни дават възможност да манипулираме неща на ниво браузър.
### Window
Това е основния обект, който имаме на разположение в браузъра. Може да го видим в конзолата на браузъра, ако в глобалния scope напишем `window` или `this`. Имаме и shortcut / alias към него, който се нарича `globalThis`, който е стандартен начин да се достъпи глобалния обект във всяка среда, независимо дали е браузър или Node.js.
В Node.js и в браузъра имаме различни глобални обекти, с различна логика. `globalThis` е нещо като environment alias, който ако се намираме в браузър ще сочи към `window`, ако сме в Node.js ще сочи към `global`.

```javascript
// В браузър
console.log(globalThis === window); // true

// В Node.js
console.log(globalThis === global); // true

// Глобалният обект в различни среди е различен
console.log(typeof window); // "undefined" (в Node.js)
console.log(typeof global); // "undefined" (в браузър)
```

В целия BOM през глобалния обект, имаме достъп до различни обекти на разположение в браузъра, даващи функционалности. Някои от тях са:

`window.location` ни дава информация, за текущия location, в който се намираме - браузъра дава тази информация на клиента на кой URL се намира, какъв протокол достъпва и тн. Самия JS не може да ни даде такава информация, ако не беше браузъра, чрез BOM модела, който да ни даде възможност за достъп, до информацията. Това е възможно единствено в контекста на браузъра, който ни споделя тази информация и ние може да използваме.

`window.screen` - дава текущата информация на текущия екран на който се намираме.

`window.navigator` - предоставя информация за браузъра и устройството, на което се изпълнява скриптът. Това е обект, наричан също Navigator API, който съдържа различни свойства и методи за извличане на данни.

`window.history` - предоставя достъп до историята на сесията на браузъра (известна като History API). С него може да управляваме навигацията на потребителя в рамките на текущата сесия, като навигираме назад, напред или зареждаме определени страници. Примерно ако напишем `history.back();` това е равносилно да натиснем стрелката назад на браузъра.

Принципно няма нужда да пишем примерно `window.location`, може да напишем директно `location`, защото се разчита, че се взима от глобалния обект. Когато пишем името на дадено пропърти, то го търси като пропърти на глобалния обект. Реално в глобалния обект имаме пропърти с име `window`, което връща глобалния обект. Това е self референция и колкото и пъти да напишем `window.window.window...` винаги ще връща глобалния обект. 
### `var`
Ако декларираме променлива с `var` или просто напишем името на променливата без декларация - `let` / `const` / `var`, то ще  я вкара в глобалния обект. Това е една от причините да се избягва, защото може да създаде проблем с друго пропърти. `let` и `const` не добавят променливи към глобалния обект, дори когато се използват в глобалния scope. Това ги прави по-безопасни за използване. 
Когато не се намираме вътре в друга функция или блок от код (например условен оператор или цикъл), сме в глобалния скоуп. Това означава, че кодът, който пишем, е достъпен навсякъде в програмата ни, освен ако не е засенчен от променлива със същото име в локален скоуп.
## Document Object Model (DOM) - Document with a Logical Tree
- DOM е част от BOM, защото `window.document` (достъпно през обекта `window`) предоставя достъп до DOM дървото.
- BOM е по-обща концепция и включва всички обекти, свързани с браузъра, докато DOM е специфичен за работата с документите.
### Tree Data Structure
Дървото е йерархична структура от данни в програмирането, което е частен случай на граф. Графа е мрежа от nodes, които са свързани. За сравнение масива е линейна структура от данни, докато графа са разклонена такава.

При дърветата се спазват следните ограничения 
- всеки node може да има, но може и да няма деца. 
- всяко дете, може да има свои деца, но може да има максимум един родител с изключение на най-горния елемент, който се нарича root и няма родител.

Relationship-a е много важен, имаме:
- child - parent.
- siblings: имат общ родител.
- освен горните две, нямаме други взаимоотношения между nodes като дядовци, внуци, братовчеди и тн.
### DOM Tree
Всеки node е обект, който държи референция / има връзка към своя родител и своите деца, за да имаме проследимост и обхождане на дървото надолу нагоре.

Всеки обект в дървото е HTML елемент, затова се нарича често дърво от HTML елементи или DOM елементи. Всеки един от елементите, репрезентира конкретен HTML елемент. Всеки от обектите идва със своите пропъртита, методи и events.
Има две неща, които може да имаме в DOM дървото - HTML елементи, които са основното нещо и нодово (nodes), които са по-малко. Нодовете са текстови елементи, които не са обгърнати от конкретен елемент, но влизат в DOM дървото.
DOM не е специфично свързан с конкретен език, направен е като отделна спецификация, за да може да се ползва от повече езици, но на практика JS е единствения популярен език, който го ползва. Към момента това е доминиращия език и няма реална конкуренция.
### `NodeList` vs `HTMLCollection`
И двете са колекции от елементи, които са част от DOM дървото. `HTMLCollection` може да държи само HTML nodes , докато `NodeList` може да съдържа и други видове nodes, включително whitespaces и само текст. Реално всеки HTML елемент е node, но не всеки node е HTML елемент. И двете колекции може да се итерират, като има малка разлика в наличните методи.

`HTMLCollection` е live, докато `NodeList` може да бъде live или static. Live колекция означава че тя автоматично ще отрази в случай, че възникне промяна в DOM дървото. 
Ако искаме `NodeList` колекцията да е винаги live, трябва да ползваме `childNodes` върху конкретен родителски елемент, който сме взели например чрез `getElementById()`. Когато извикаме `childNodes` върху елемент, това ще върне live `NodeList` колекция, която включва всички директни деца (независимо от типа им) на този елемент.

Ако искаме да правим по-сложни модификации може да направим convert към array с метода `Array.from(myIterableCollection)`. Този метод трансформира всяка iterable колекция в масив.
### Accessing a Website Summary
Когато отворим даден сайт, браузъра праща http request към сървъра на който се hots-ва сайта и който връща html response - чист текст с html тагове. Този текст се зарежда в браузъра, който го parse-ва и създава DOM дървото. Елемент по елемент ги parse-ва и създава обекти от html елементите, които събира в DOM структурата. Реално html е йерархична дървовидна структура. При статичната колекция, резултата не се променя.

С `Ctrl + Shift + C` може да селектираме html елемент на сайта и с десен бутон да го запишем като променлива с име `temp1`. След това може да разгледаме неговите пропъртита, като използваме `console.dir(temp1)`. Примерно може да expand-нем родителя на елемента, след това може да видим и родителя на родителя и тн.

Когато html текста пристигне, браузъра започва да минава през всичките html елементи, parse-ва ги и създава обектите с цялата им информация, включително закача неговия родител, ако има деца закача и тях и тн. Реално след като пристигне html file-a, браузъра го parse-ва веднъж и създава DOM дървото, което се изобразява на екрана. Браузъра използва DOM за визуализация, не html-a. С други думи, html-a се използва от сървъра като текст, браузъра го обработва, извлича информация за всичките html елементи, създава ги като обекти, подрежда ги в DOM дървото и на негова база визуализира UI. 
Parse-ването на DOM се извършва еднократно, до следващата заявка, която правим. Когато DOM е създаден и визуализиран, всяка следваща промяна, например чрез JavaScript скрипт, ще се отрази бързо в потребителския интерфейс. Това е така, защото работата с обекти е значително по-бърза от работата с текст, а когато се направи промяна в DOM, тя се прилага мигновено в UI-то.
В `Elements` таба когато inspect-ваме в браузъра, реално виждаме DOM елементите, след като са били parse-нати вече. Изглежда като обикновен html текст, но не е, всички елементи които виждаме, са специфична визуализация на нашите обекти, които стоят в DOM дървото. Това е причината, поради която може да colapse-ваме и expand-ваме. Браузъра като е взел един елемент и го е parse-нал, знае кои са неговите деца и така знае какво да ни покаже, когато expand-ваме. Ако променим текста на някой елемент, това е manual update върху вече генерирания DOM който имаме, след като браузъра е parse-нал получения html от сървъра. Тази промяна ще се визуализира веднага на екрана, но ако refresh-нем браузъра, той ще направи нова заявка и ще създаде DOM дървото отново, което ще премахне нашата промяна. Може да променяме съдържание, да променяме позиции, да създаваме нови елементи или да изтриваме стари и тн. Точно тази възможност за бърза промяна е причината да се ползва JS.
В крайна сметка, цялата идея е че с помощта на JS, може да модифицираме DOM-а, което ще се отрази като промяна в UI. Вярно е че след всяко презареждане всичко ще се рестартира от начало, но това означава че след като страницата се зареди и се покаже даден интерфейс, потребителя може да натисне даден бутон, който да задейства JS функция, която да промени UI, което е в реакция на потребителското поведение. Това е и идеята, че имаме интеракция между потребителя и web application-а. Това е основата за създаването на динамични и web апликации.
## Including JS In HTML
Има няколко начина по които може да добавим JS в html:
1.  Inline - позволява ни да пишем JS код вътре в html file-a:

```html
<body>
    <h1>JS is DOM</h1>
    <script>
        console.log('Hello from JS in html file');
    </script>
</body>
```

Когато браузъра стигне до `<script>`, го изпълнява като JS код. Добре е тоя таг да се намира винаги накрая в `<body>` след стандартния html.

2. Importing from external file - добавяме файл, който браузъра изтегля като направи нова заявка и го изпълнява след като го получи:

HTML file:

```html
<body>
    <h1>JS is DOM</h1>
    <script src="script.js"></script>
</body>
```

JS file:

```javascript
console.log('Hello from external js file');
```

Този вариант се ползва по-често. Функциите от скрипт файловете са в глобалния скоуп и може да бъдат използвани от events и inline scripts.
Може да имаме повече от един файл, като има значение реда в който се включват. 
Добре е скрипта да е най-отдолу на `<body>` елемента, за да сме сигурни че всички DOM елементи са създадени, защото DOM елементите се създават отгоре надолу.

3. Event handler - може да пишем JS и в атрибута на button елемента `onclick`:

```html
<body>
    <h1>JS is DOM</h1>
    <button onclick="console.log('Hello from JS in <button>');">Click</button>
</body>
```

Кода се изпълнява когато бутона бъде натиснат. Използва се много рядко.
Това е и основната причина, стринговете да се пишат в единични кавички, защото атрибута е с двойни.
## Attributes and Properties
Атрибутите се дефинират от HTML а в DOM дървото имаме пропъртита. Обикновено те се map-ват едно към друго. Примерно ако имаме html атрибут `id`, то в DOM ще има `id` пропърти. Атрибутите стават пропъртита, когато се трансформират от html към обект, който е html елемент. Технически html атрибута и DOM пропъртито не са едно и също нещо, но практически почти никога няма да попаднем на разлика.
## DOM Manipulations
HTML DOM позволява на JS да променя съдържанието на html елементите:
- `innerHTML` - позволява добавяне или промяна на HTML съдържанието вътре в елемента. Не е безопасно, ако данните идват от външни източници, защото може да доведе до XSS атаки (вмъкване на зловреден код). 

```javascript
element.innerHTML = "<p>Нов параграф</p>";
```

- `textContent` - добавя или променя само текстовото съдържание на елемента, без да интерпретира HTML тагове.

```javascript
element.textContent = "Чист текст";
```

- `value` - използва се за промяна на стойността на елементи като `<input>` или `<textarea>`.
- `style` - позволява директно задаване на CSS стилове за елемента.

```javascript
element.style.color = "red";
element.style.fontSize = "16px";
```

- и много други..

`textContent` и `innerHTML` позволяват промяна на съдържанието на HTML елементите, но имат ключови разлики:

1. `textContent`
    - Работи само с текста вътре в елемента.
    - Третира всички child елементи като обикновен текст.
    - Заменя или добавя текст, премахвайки всяка HTML структура.

```javascript
example.textContent = "Нов текст."; // Премахва всички дъщерни елементи и добавя "Нов текст."
```
        
2. `innerHTML`
    - Позволява четене или записване на HTML съдържание.
    - При промяна може да добавя или замества както текст, така и HTML елементи.
    - Не се препоръчва, защото може да въведе зловреден код (XSS атаки).

```javascript
example.innerHTML = "<p>Нов HTML елемент</p>"; // Заменя текущото съдържание с нов HTML.
```

Разлика:
- `textContent` е по-сигурен, защото работи само с текст.
- `innerHTML` е по-гъвкав, защото позволява работа с HTML структура.
## Targeting DOM Elements - Obtaining Element References
Чрез метода, може да таргетираме и да взимаме референция към елементите в DOM, след което може да ги манипулираме. Описани са във файла за JavaScript в папката с ресурси.
## Parents and Child Elements
Всеки DOM елемент освен root елемента `<html>` има родител, като той може да бъде достъпен през `parentElement` и `parentNode` пропъртитата. В 99% от случаите и двете ще връщат един и същи обект, само в две ситуации има разминаване:
- `<html>` root елемента `.parentElement` - ще върне `null`, а`.parentNode` ще върне целия DOM.
- `DocumentFragment` е специален обект в DOM, който представлява "лека" структура от възли, използвана за групиране на елементи без тяхното непосредствено добавяне в DOM дървото. `parentElement` е `null`, но `parentNode` сочи към фрагмента.

Децата на даден елемент може да бъдат достъпени с `.children` пропъртито, което държи `HTMLCollection` с всички деца.
## Control Content via Visibility
Съдържанието може да бъде скрито или разкрито като променим неговия display style.
Скриване на елемент - `element.style.display = 'none';`
Разкриване на елемент, трябва да сложим стойност различна от `none` - `element.style.display = '';`
## Match `n-th` Child
Понякога се налага да таргетираме елементи базирано на тяхното положение спрямо други подобни елементи. Има няколко начина:
- Index
- CSS selector

```javascript
const thirdLi = document.getElementsByTagName('li')[2]; // Using index
const thirdLi = document.querySelector('ul li:nth-child(3)'); // Using CSS selector
```
# Misc

# ChatGPT
## Global / Window Objects
The **global object in Node.js** and the **`window` object in the browser** share the **same architectural role** in their respective environments—they are the "global namespace" where globally accessible variables, functions, and properties are defined. However, they have **different sets of properties and methods tailored to their environments**.

**Key Points About the Architecture**

1. **Role as the Global Namespace**:
    
    - In the **browser**, the `window` object is the global namespace. Variables defined with `var` or functions declared globally automatically become properties of `window`.
    - In **Node.js**, the `global` object serves the same purpose, holding globally accessible properties like `process`, `require`, etc.
2. **Environment-Specific Properties**:
    
    - **Browser (`window`)**: Includes browser-specific APIs like `document`, `localStorage`, `fetch`, `onload`, and the DOM.
    - **Node.js (`global`)**: Includes Node.js-specific APIs like `process`, `Buffer`, `require`, and global timers (`setTimeout`, `setInterval`).
3. **Shared Concepts**:
    
    - Both allow access to built-in JavaScript features, like `setTimeout`, `JSON`, `Promise`, etc., though these are not always implemented identically.
4. **Not Interchangeable**:
    
    - A property like `window.onload` exists only in the browser and has no counterpart in Node.js.
    - Similarly, `global.process` or `global.require` exists only in Node.js and has no counterpart in the browser.

**To Summarize:**

The **global object** in both environments plays the **same architectural role** as the top-level container for global properties and methods. They are **different in implementation**, reflecting the needs of their respective environments:

- Browser → `window`
- Node.js → `global`
## Working With The Browser Console
**You said:**

When we are working in the console in the browser it feels like every command we make is inside a console.log() method?

**ChatGPT said:**

Yes, that's a great observation! When you work in the browser's console, it does feel like every command you type gets "wrapped" in something like `console.log()` or similar. Here's why:

**How the Console Works**

1. **Immediate Evaluation and Output**:
    
    - When you type an expression in the console (e.g., `2 + 2`), the console **evaluates it immediately** and displays the result.
    - This happens because the console is designed to be interactive and to provide instant feedback for debugging purposes.
    
```javascript
2 + 2
// Output: 4
```
    
2. **Expression Results**:
    
    - The console automatically prints the result of any expression you type, similar to how `console.log()` would display it.
    - However, this behavior is specific to the console—it doesn't actually wrap your code in `console.log()`.
3. **Statements vs. Expressions**:
    
    - If you write a statement that doesn’t produce a value (like `let x = 10;`), the console doesn't "log" the result, because such statements return `undefined` by default.
    
```javascript
let x = 10; // Nothing is printed (returns undefined)
```
    
4. **Return Values**:
    
    - Behind the scenes, the console evaluates your command and displays the **return value** of the expression or statement.
    
**How is This Different from `console.log()`?**

- **`console.log()`** explicitly outputs a value to the console.
- When you type directly in the console, it shows the result of evaluating the expression, which isn't always the same as explicitly logging it.

```javascript
"Hello World";
// Output: "Hello World" (result of the expression)

console.log("Hello World");
// Output: "Hello World" (explicitly logged)
```

**Why Does It Feel Like `console.log()`?**

- The interactive behavior of the console is designed to help you see results immediately, so it often _feels_ like everything is logged.
- The browser console's job is to **help you debug**, so it tries to make outputs intuitive and immediate.

**Key Difference**

- Typing a command in the console shows the **result of evaluation**.
- Using `console.log()` explicitly prints something to the console.

**Conclusion**

The browser console evaluates and displays the results of expressions automatically, which makes it feel like you're working inside a `console.log()`. This is just a convenience provided by the console, designed to make debugging easier and faster.

**You said:**

Why the test var is not found?

```javascript
var test = 5; 
undefined
console.log(this.test); 
undefined
```

**ChatGPT said:**

The behavior you're observing relates to **how variables are added to the global object (`this` in the global scope)** in JavaScript. Let's break it down step by step:

**Key Points**

1. **`var` Variables and the Global Object (`window` or `this`)**
    
    - When you declare a variable with `var` in the global scope, it is added as a property of the global object (`window` in browsers).
    - However, in the browser's **console environment**, there can be slight differences in how global variables behave because of the REPL (Read-Eval-Print Loop) behavior.
2. **Accessing `test` via `window` or `this`**
    
    - If you're in the global scope, `this` refers to the global object (i.e., `window` in browsers).
    - Variables declared with `var` become properties of `window`.
    
```javascript
var test = 5;
console.log(window.test); // 5
console.log(this.test);   // 5
```
    
3. **Why Does `console.log(this.test)` Return `undefined`?**
    
    - In the **browser console**, the behavior can sometimes differ from writing a script directly in an HTML file or a standalone JS file.
    - This happens because in some cases, variables declared in the **console environment** don't get attached to `window` like they would in a regular script.
    
    If you test this in an actual script:
    
```javascript
var test = 5;
console.log(this.test); // 5
```
    
    In the console, however, `test` may not behave as a global property due to how the console isolates variables.
    
4. **Difference Between Declared and Assigned Variables**
    
    - If you assign a value to an undeclared variable (without `var`, `let`, or `const`), it **automatically** becomes a property of `window`.
    
```javascript
test2 = 10; // No declaration
console.log(this.test2); // 10
```
    
**REPL (Console) Specific Behavior**

- In the console, variables declared with `var` sometimes don't attach to `window` immediately because the console isolates execution contexts to prevent polluting the global object.

**What About `this.a`?**

- Since you didn’t declare or assign any variable named `a`, `this.a` is `undefined`.

**Summary**

- The console may behave slightly differently compared to executing code in a script.
- In a regular script:
    - `var test = 5;` attaches `test` to `window` (or `this` in the global scope).
    - `console.log(this.test);` would return `5`.
- In the browser console, **REPL behavior** can prevent `var` variables from attaching to `window` immediately. Instead, they might behave more like `let` or `const` for isolation purposes.
## CSS vs. JavaScript
-  While **CSS** is a declarative language for styling HTML elements, **JavaScript** is a programming language used for dynamic behavior. Although JavaScript can manipulate styles directly (e.g., changing element properties like width, height, or background color), **CSS** is optimized for styling and is more efficient for these tasks.
    
- **Why Both are Needed**:
    
    - **CSS** provides a **clean, efficient** way to style elements and is applied by the browser's rendering engine. It is optimized for performance, as the browser can apply styles in parallel to rendering.
    - **JavaScript** allows for **dynamic changes** to the page, such as handling events, user input, and complex animations. However, manipulating styles via JavaScript can be **slower** and more resource-intensive because it requires more processing, such as recalculating layout and repainting elements.
- **Performance Cost**:
    
    - **CSS** operates at a **lower performance cost** when it comes to styling and layout changes, as the browser can handle it more efficiently.
    - **JavaScript** can achieve similar effects (like animations or changing styles), but it may involve more overhead because it requires interaction with the DOM, reflow/repaint cycles, and recalculating styles. This can slow down performance, especially with complex or frequent changes.
- **In Theory**: JavaScript can achieve almost everything CSS can, but using **CSS** for styling and layout is more optimal, while **JavaScript** should be used for dynamic behavior and interactivity. Combining both allows for **efficient design** and **dynamic interaction** without compromising performance.
    
**You said:**

CSS operations also change the DOM directly right? its just hidden from us because its declarative?

**ChatGPT said:**

Yes, you're correct. **CSS operations** do indeed affect the DOM, but this process is **abstracted from us** and is done in a more efficient, declarative way.

**Here's how it works:**

- **CSS** defines the **style rules** for elements, like colors, layout, dimensions, etc. These styles are applied by the browser’s rendering engine to the corresponding **DOM nodes** (HTML elements).
- When CSS rules are applied, the **browser manipulates the DOM** in terms of **visual presentation**. This happens behind the scenes as part of the **render tree** creation, where the browser calculates how elements should appear on the page.
- CSS operations can also trigger **layout recalculations** (reflow) or **repainting** when styles change (e.g., changing the width or position of an element). This still involves the DOM, but it's more optimized and less manual than directly manipulating the DOM through JavaScript.

**Key Differences:**

- **CSS** is a **declarative** language, meaning you describe how elements should appear (e.g., `color`, `width`), and the browser takes care of the actual modifications to the DOM’s **visual representation** without explicitly altering the structure.
- **JavaScript** is **imperative**, meaning you directly instruct the browser to change or manipulate elements, which could involve more direct changes to the DOM, leading to potential performance costs (like triggering layout recalculations).

**In summary:**

- **CSS does change the DOM** in terms of **visual representation** and layout, but the changes are managed automatically by the browser, making them more efficient than manual changes through JavaScript.
- The key advantage of CSS is that it allows for efficient, declarative styling, while JavaScript is more suited for **dynamic interactions** and complex behavior, often with a higher performance cost.
## DOM Element Properties, Attributes and Styles
1. **Attributes as Main Properties**:  
    In the context of the DOM, HTML attributes (e.g., `id`, `class`, `src`, `href`) are considered the core properties that define the element’s identity or fundamental characteristics. These are set directly in the HTML markup and can be accessed and modified in JavaScript.
    
    - Examples:
        - `id="box"` becomes the `id` property of the DOM object (`element.id`).
        - `class="container"` becomes the `className` property (`element.className`).
2. **CSS Properties as Style Object Properties**:  
    CSS properties (e.g., `height`, `width`, `color`, `font-size`) define the appearance of an element and are generally set via external CSS or inline styles. These properties are stored in the **style object** in JavaScript, which represents the element's inline styles.
    
    - Example:
        - `style="height: 100px;"` becomes part of the style object in JavaScript (`element.style.height`).
3. **Key Differences**:
    
    - **Attributes (Main Properties)**:
        - Define the core configuration of an element.
        - Directly accessible in JavaScript (e.g., `element.id`, `element.className`).
        - Defined in the HTML markup.
    - **CSS Properties (Style Object Properties)**:
        - Control the visual presentation of an element.
        - Defined by CSS or inline styles.
        - Accessible via the `style` object in JavaScript (e.g., `element.style.height`, `element.style.color`).
4. **Computed Styles**:  
    CSS properties are dynamically computed by the browser, based on a combination of external styles, inline styles, inherited styles, and browser defaults. These computed values are not directly stored in the DOM element object but are calculated at runtime. You can access the computed styles using `window.getComputedStyle()`.
    
    - Example: To access computed styles:
        
```javascript
let computedStyle = window.getComputedStyle(element);
console.log(computedStyle.fontSize); // Logs computed font-size value
```
        
5. **How We Can Think About It**:
    
    - **HTML attributes** (like `id`, `class`, etc.) give the element its identity or core properties and are accessible directly in JavaScript.
    - **CSS properties** (stored in the style object) affect the visual presentation of the element and can be accessed and modified dynamically in JavaScript.

**Final Summary:**

- **Attributes** (e.g., `id`, `class`) define the identity and basic configuration of elements and are stored as properties on the DOM object.
- **CSS properties** (e.g., `height`, `color`) define the visual appearance and are stored in the element’s **style object**, but the final computed styles are calculated dynamically by the browser.
## Including Script Files
Once you include a script file inside an HTML document, the functions and variables defined in that script become globally accessible throughout the HTML page, provided the script is included in the global scope (i.e., not inside a module or a specific function).

**Key Points:**

1. **Global Access**: If your JavaScript file is included like this:
    
```html
<script src="script.js"></script>
```
    
    All functions and variables declared in the file are available globally, meaning you can call them from anywhere in your HTML or other JavaScript files.
    
2. **Order of Execution**:
    
    - If you include the script in the `<head>` section, the browser loads and executes it before rendering the `<body>` content. If the script tries to access elements that haven't been rendered yet, you might encounter errors.
    - To ensure the script runs after the DOM is ready, you can:
        - Place the `<script>` tag just before the closing `</body>` tag.
        - Use the `defer` attribute:
            
```html
<script src="script.js" defer></script>
```
            
3. **Calling from HTML**: Functions can be called directly from event attributes, like in your example:
    
```html
<button onclick="editElement(document.getElementById('e1'), 'placeholder', 'new text')">
    Edit Element
</button>
```
    
4. **Scope Considerations**:
    
    - If the script is a **module** (declared with `type="module"`), its functions and variables are not globally accessible:
        
```html
<script type="module" src="script.js"></script>
```
        
        You must explicitly export and import functions or variables.
5. **Overwriting and Conflicts**: If multiple scripts define functions or variables with the same name, the last included script overwrites earlier ones. Use namespaces or modules to prevent conflicts.

**Best Practice:**

Use **modules** or avoid polluting the global scope to maintain clean and maintainable code, especially in larger projects.
## Flow of Script Execution
1. **Sequential Execution**:
    - The browser parses the HTML file from top to bottom.
    - When it encounters a `<script>` tag, it pauses the parsing of the HTML, fetches the script file (if it's external), and executes it immediately before moving to the next line in the HTML.
2. **Shared Global Scope**:
    - By default, JavaScript files included in the same HTML page share the same **global scope** (`window` object).
    - Variables and functions declared in the first script file are accessible in subsequent script files, as if all the code were in one file.

**Example:**

**script.js:**

```javascript
let sharedVariable = "I'm shared!";
function sharedFunction() {
    console.log("Function from script.js");
}
```

**script2.js:**

```javascript
console.log(sharedVariable); // Access variable from script.js
sharedFunction(); // Call function from script.js
```

**HTML:**

```html
<script src="script.js"></script>
<script src="script2.js"></script>
```

**Result:**

- When the browser executes `script2.js`, it can access `sharedVariable` and `sharedFunction` because they were declared in `script.js`, which was executed first.

**Important Notes:**

1. **Order Matters**:
    
    - If `script2.js` tries to access something declared in `script.js` before `script.js` is included, it will throw an error because it hasn’t been defined yet.
2. **Isolated Scope**:
    
    - If you want to isolate the scopes of your scripts, you can use techniques like **IIFE (Immediately Invoked Function Expressions)** or **modules** (e.g., with `type="module"`).
3. **Asynchronous and Deferred Scripts**:
    
    - Adding attributes like `async` or `defer` to `<script>` tags can change the way scripts are executed, potentially affecting the flow.

In the example, the behavior we observe is due to both scripts sharing the same global scope and being executed sequentially as per their order in the HTML.
## Debugger
Using the `debugger` statement is one of the simplest ways to trigger debugging directly in your program when working in the browser. It pauses the execution of your script at the point where the `debugger` statement is encountered, allowing you to inspect variables, the call stack, and the overall program state.

**How `debugger` Works:**
1. Open your browser's Developer Tools (usually `F12` or `Ctrl+Shift+I` on Windows/Linux, `Cmd+Opt+I` on macOS).
2. Write `debugger;` in your code at the point where you want execution to pause.
3. When the browser executes that line, it halts execution and opens the debugging interface in Developer Tools.
4. From there, you can step through your code, inspect variables, and analyze your program's behavior.

JavaScript Code:

```javascript
function calculateSum(a, b) {
    let sum = a + b;
    debugger; // Pauses execution here
    return sum;
}

calculateSum(5, 10);
```

**Steps:**
1. Run this script in the browser (e.g., linked in an HTML file).
2. When the `debugger` line is reached, the script pauses.
3. In the Developer Tools:
    - You can inspect the values of `a`, `b`, and `sum`.
    - Use the "Step Over", "Step Into", or "Step Out" buttons to navigate through the code.

**Benefits of Using `debugger`:**
1. **Direct Control**: Allows you to pinpoint exactly where you want to pause execution.
2. **No Breakpoint Setup Needed**: Eliminates the need to manually set breakpoints in the Developer Tools.
3. **Quick and Easy**: Particularly useful for debugging smaller scripts or specific problematic sections.

**Alternative: Setting Breakpoints in Developer Tools**

For more robust debugging, you can:

1. Open the **Sources** tab in Developer Tools.
2. Navigate to the script file.
3. Click on the line number where you want to pause execution to set a breakpoint.

This approach avoids modifying your code with `debugger;` statements and is better for larger or production environments.

**Important Notes:**

- **Avoid Leaving `debugger` in Production Code**: The `debugger` statement will pause the script execution for all users in their browsers if left in production, which can cause significant issues.
- Use it as a temporary debugging tool during development and remove it afterward.
# Bookmarks 
Completion: 23.11.2024