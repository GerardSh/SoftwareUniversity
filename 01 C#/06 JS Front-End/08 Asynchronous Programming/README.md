# General
## Synchronous Programming
Синхронното програмиране е линейно изпълняване на всеки ред код, който имаме в програмата. Всеки ред се изпълнява един след друг, имаме ясна последователност на всичките стъпки, по които работи кода. Това е основата на алгоритмичното мислене - да може да създадем алгоритъм представяйки си всичките стъпки напред.

На ниво памет и процеси, това означава, че има процес в паметта, който изпълнява нашия код, като това най-често се случва в една нишка - thread. Това е single процес, който има грижата да изпълнява всичките команди / инструкции в нашата програма. Това много често се нарича single threaded programming - програма която се изпълнява синхронно в една единствена нишка.
## Asynchronous Programming
В много езици, включително C#, това означава multi threaded programming, където постигаме асинхронност с използването на повече от една нишки. Във всяка нишка, кода се изпълнява синхронно, но цялостно погледнато, кода се изпълнява асинхронно, защото има повече от една нишки, които са асинхронни една спрямо друга, не се изчакват една друга. Thread management-a е малко сложен, защото трябва да знаем кога една нишка достъпва определени ресурси, защото другата нишка в този момент не може да ги достъпва. Ако достъпваме едни и същи данни, които трябва да са споделени между нишките, това означава че може да имаме много проблеми, наречени race conditions, с които трябва да се съобразяваме и с най-различни техники да се справяме с тях. С този management се занимават предимно опитни програмисти, които знаят как да решават възникналите проблеми. Изпълняването на код в паралел, създава своите големи предизвикателства.

Интересното при JS e, че е асинхронен, но не е multithreaded. Може да изпълняваме асинхронен код - докато някаква операция се свърши, да изпълняваме други операции, но без да е multithreaded. JS е single-threaded language. Възможността да изпълняваме асинхронно код в една нишка идва от Event Loop.
### Event Loop
Кода ни се изпълнява в стека. В него имаме Execution Context (контекст на изпълнение), в който дадена функция си изпълнява нещата, декларира си променливите докато не стигне до return. Всеки път, когато се извика функция, се създава нов контекст и се добавя в стека. След като функция приключи, контекстът ѝ се премахва от стека, а Garbage Collector-а изчиства паметта, която вече не е нужна (например променливи, които не са достъпни от други части на програмата) и така докато целия стек не се опразни.  
Преди това да се случи, ако в някоя от функциите сме искали да се изпълни дадена асинхронна операция, примерно направи заявка към даден сървър или прочети нещо от файловата система, това което се случва, е че тя не се изпълнява веднага, защото в стека се изпълнява синхронния код, там стои само синхронен код и няма как да стои асинхронен. Стека прави заявка към външна система - допълнителен worker, който е извън JS средата, делегира се на външни worker-и, които да свършат тази работа.  
Единственото разбирателство което имаме е след като се предаде дадена дълга функция - операция която ще изисква време, без да се интересуваме колко ще е то, а това което ни интересува е че когато бъде изпълнена, определена функционалност да бъде извикана обратно. Примерно функция, която наричаме `callback()` и която да се изпълни, когато worker-a приключи дадена операция.  
По същия начин както в DOM даваме функцията `addEventListener()` - казваме на browser-a който се явява worker-a, като види че потребителя е кликнал върху даден елемент, да изпълни определен listener. Реално JS делегира на browser-a тази задача - да изпълни дадената функция, когато е нужно и не се занимава повече. Когато worker-a приключи със задачата, без значение каква е, може да е изчакване за event, изчакване на някакъв timeout, може да е всичко, но когато приключи, той казва - готов съм да изпълня подадената функция. Въпроса е че тази функция не се изпълнява веднага и от worker-a, неговата работа е да каже че е готов на Event Loop-a, който е нещо като безкраен цикъл, който стои и се върти. Реално имаме отделна на стека структура, наречена Event Queue - опашка, в която се нарежда нашата функция. Ако е празно, ще бъде най-отпред, а ако не е, се нарежда на края на опашката. Функциите се поставят в Event Queue от външните механизми като системни таймери, I/O операции или браузърни API. EL ще изчака стека да се изпразни, тоест синхронния код трябва да приключи първо, тогава EL ще вземе функцията от опашката и ще я вкара в стека за изпълнение - ще вземе асинхронната функция, ще я вкара в стека и ще я изпълни синхронно. Всяка асинхронна операция ще се регистрира и като е готова, ще си чака времето. Това което трябва да разберем е, че във всеки един момент кода се изпълнява синхронно и EV се грижи да вкара асинхронни функции за синхронно изпълнение, защото имаме single thread.
## Synchronous vs Asynchronous Programming
Има три механизма за изпълнение на асинхронен код в JS, като това не е същото като concurrent или multithreaded, защото тогава изрично казваме че имаме повече от една нишка в която работи. Механизмите са:
### 1. Callback Functions 
Принципно това са функции, които се подават като аргументи на други функции. В контекста на асинхронното програмиране, функцията `setTimeout()`, приема callback функция, която ще бъде подадена към Event Queue-то Системният таймер след като изчака указаното време. След това ще подаде callback в Event Queue. Event Loop ще я вземе от опашката и ще я постави в Execution Stack, но само след като стекът се освободи от синхронния код. Това е асинхронна операция, ще се случи сватбата, след като се извърши нужната подготовка  
### 2. Promises
Това са обекти, които държат асинхронна операция и дават обещание за резултат в бъдещето. Принципа е че нещо, което ще се случи напред в бъдещето, ние получаваме обект, върху който казваме - когато това обещание се изпълни, направи това и това. Като пример от реалния свят, промисите са обекти в JS, които са много близки до обекта наречен годежен пръстен, който символизира обещанието и посвещението на един мъж към жена му. Пръстена е обекта на това обещание, а в JS обекта се нарича промис. Стъпвайки върху това обещание, човек започва да прави планове, примерно план за меден месец, след като настъпи сватбата или създаването на деца в рамките на една година. По същия начин в JS имаме промис, върху който може да планираме бъдещи действия.

```javascript
// Create promise
const marriagePromise = new Promise((resolve, reject) =>
    setTimeout(() => {
        if (Math.random() < 0.5) {
            resolve('Just Married!');
        } else {
            reject('The marriage got canceled!');
        }
    }, 2000))

// Pending state
console.log(marriagePromise);

// Consume promise
marriagePromise
    .then((result) => { // Fulfilled state
        console.log(result);
    })
    .catch((reason) => { // Failed state
        console.log(reason);
    })
    .finally(() => {
        console.log('Pay the wedding');
    });
```

Промисите може да ги създаваме, ако ние искаме да създадем асинхронната операция, но това се налага рядко, по-често се консумират. Създават се с ключовата дума `new` и конструктора очаква функция, която се нарича `executor` и приема две функции, чрез нея се извършва конфигурацията.  На този екзекутор, се подават като аргументи функциите `resolve()` и `reject()`. `resolve()` приема стойност, а `reject()` приема reason. `resolve()` приема като аргумент резултат с който промиса ще се изпълни.
Промиса може да има 3 state-a:
- Pending -промиса очаква своето приключване.
- Fulfilled - промиса е приключил успешно, терминологията е resolve-нал се е.
- Failed - промиса се е провалил и има грешка.

Fulfilled и failed са крайни състояния, така нареченото settled състояние. До преди това е в статус pending.

Промиса се консумира с `then(callback)`. Върху промиса казваме - когато промиса се изпълни, тогава (`then`) изпълни подадената функция и вземи резултата, който получаваме от подадения аргумент в `resolve()` функцията на промис обекта.
За да хванем failed state, ползваме функцията `catch()`. 
Без значение дали промиса resolve-не или reject-не, `finally()` ще се изпълни веднага след това. Не зависимо кое от двете се изпълни, веднага след него ще се изпълни и `finally()`.

Принципа е че всеки промис, трябва да бъде catch-нат задължително. Никога не трябва да очакваме че асинхронна операция задължително ще успее. Трябва да се запасим за случай, че промиса не успее. Всеки един процес може да fail-не, ако е заявка към сървъра, може да се случат много проблеми, ако е към файловата система, може да се окаже че няма такъв файл и тн, затова е много важно да имаме catch state на промисите, защото се получава unhandled promise rejection, което може да доведе до некоректно поведение на приложението или дори до спиране на изпълнението му в определени случаи.

![](Pasted%20image%2020241203231544.png)

`executor()` е функция, която ще приема `resolve()` и `reject()` функциите, които като кажем `then()` на нашия промис, подаваме callback функция на `then()`, който `resolve()` ще извика когато се resolve-не. Същото важи и за `catch`-a, той ще извика `reject()`, ако промиса fail-не. 

С други думи, когато създадем нов промис, `executor()` ще бъде изпълнена веднага, и в нея ще се реши дали промисът ще бъде изпълнен успешно (чрез извикване на `resolve()`) или ще се провали (чрез извикване на `reject()`). След това, когато използваме `then()` върху промиса, той подава callback функция, която ще бъде извикана, когато промисът бъде "fulfilled" (т.е. когато бъде извикан `resolve()`). По същия начин, ако промисът се провали и бъде извикан `reject()`, тогава ще се изпълни функцията подадена към `catch()`.

За да го обобщим:
- `executor()` е функцията, която се изпълнява веднага при създаване на промиса. Тя получава функциите `resolve()` и `reject()`.
- Когато промисът се изпълни успешно (извика се `resolve()`), функцията в `.then()` ще бъде извикана.
- Когато промисът се провали (извика се `reject()`), функцията в `.catch()` ще бъде извикана.

Популярни методи с информация за тях и как работят има във файла за JavaScript в папката с ресурси.
### 3. Async Functions.

![](Pasted%20image%2020241203141627.png)

Асинхронното програмиране позволява няколко парчета код, да се изпълнят в паралел по едно и също време.
При синхронния код, преди да се изпълни друга операция, трябва да изчакаме текущата да свърши, докато при асинхронния сценарии ги пускаме паралелно и всичките ще отнемат общо време, колкото е времето на най-дългата. В примера синхронното изпълнение ще отнеме 45 секунди, докато при асинхронното ще е 20 секунди.

Асинхронен код се изпълнява всеки път, когато имаме по-дълго изпълняваща се функционалност - long running process, който зависи особено от външни системи. Например зависи от заявка до сървъра - интернета може да е слаб, сървъра да е забил или да е натоварен и да му трябва повече време да отработи request-a и тн. Важното е нашата програма да не блокира, както би станало при синхронен код - програмата ще блокира и ще чака изпълнението на дългата операция, докато при асинхронния програмата не спира работата до пристигане на отговора от сървъра.

```javascript
function callback() {
    debugger;
    console.log('Second');
}

function main() {
    debugger;
    console.log('First');

    setTimeout(callback, 0);

    console.log('Third');
}

main();

// Output:
// First
// Third
// Second
```

В примера дефинираме callback функция, която се нарича така, защото това е функция, която ще подадем на асинхронна операция, която да се изпълни, когато операцията е приключила. Един вид, обади се обратно, когато изпълниш функцията. Де факто ние делегираме на външен worker да отброи една секунда, след което да върне подадената callback функция за изпълнение. 
Дори да сложим 0 секунди `setTimeout(callback, 0);`, то пак callback функцията ще се изпълни последна. 
Важно уточнение е че `setTimeout()` функцията не е самият worker, а по-скоро инструмент за регистрация на асинхронна задача. Реалната работа на worker-а (например изчакването на 0 секунди) се изпълнява от системния таймер или външния механизъм, който поддържа асинхронните операции.

Ключовото е да разберем, че имаме синхронен и асинхронен код.
Синхронния код е:

1. Декларираме функция.
2. Изпълняваме `console.log('First')`
3. Регистрираме асинхронна функция за изпълнение `setTimeout(callback, 0)`. Синхронния код тука е регистрацията на функцията за след някакво време, без значение колко е то. Функцията ще бъде асинхронно изпълнена. Единствената синхронна част на този ред е да се подаде callback функцията и да се изпълни след определеното време. Дори това да е 0 секунди, принципа остава същия и синхронния код си продължава надолу. Стека ще изпълни първо асинхронния код и чак когато се опразни, ще дойде асинхронния код и ще се изпълни отново като синхронен, така докато не се опразни и Event Queue-то.
4. Изпълняваме `console.log('Third')
5. Последната функция в стека приключва и Garbage Collector-a изчиства целия стек. През това време, worker-a на който сме дали callback функцията я е подал на Event Loop-a, който я е сложил в Event Queue-то. След като стека се опразни, EL взима callback функцията от EQ и я подава към стека. Реално callback функцията бива подадена в EQ веднага, но колко време ще мине до изпразването на стека и EQ, няма гаранция. Гаранцията в примера е че функцията ще се изпълни след поне минимум времето което сме сложили, но няма гаранция че ще е след точно толкова време.

По време на debugging, може да видим, че след като се изпразни стека, чак тогава ще влезнем в `callback()`.
# Misc
# ChatGPT
## Synchronous vs. Asynchronous in Promises

1. **Code Inside the Executor Function (`new Promise((resolve, reject) => { ... })`)**
    - This code is executed **synchronously** as soon as the promise is created.
    - For example:
        
```javascript
const promise = new Promise((resolve, reject) => {
    console.log('Synchronous code in executor');
    resolve('Done!');
});
console.log('This runs after creating the promise');

// Output:
// Synchronous code in executor
// This runs after creating the promise
```
        
2. **Code in `.then`, `.catch`, or `.finally`**
    - These handlers are always executed **asynchronously**, even if the promise is already resolved.
    - The handlers are queued in the **microtask queue** and executed after the current synchronous code is finished.
        
        Example:

```javascript
const promise = new Promise((resolve) => {
    resolve('Done!');
});

promise.then((value) => {
    console.log(value);
});

console.log('This runs first');

// Output:
// This runs first 
// Done!
```

**Key Points:**
- The **executor function** runs synchronously when the promise is created.
- The **handlers (`.then`, `.catch`, `.finally`)** always run asynchronously, even if the promise resolves immediately.
- This behavior ensures consistent execution order in JavaScript's single-threaded environment.
### What Happens in a Promise
1. **Executor Function (`(resolve, reject) => {}`):**
    - This runs **synchronously** when the `Promise` object is created.
    - Everything you write outside `resolve` or `reject` in the executor runs **immediately**.
2. **`resolve()` and `reject()` Functions:**
    - These **trigger the fulfillment or rejection of the promise**.
    - They do not execute asynchronously themselves. Instead, they schedule the `.then` or `.catch` handlers to run **asynchronously** via the **microtask queue**.

**Simplified Breakdown Example:**

```javascript
const promise = new Promise((resolve, reject) => {
    console.log('1. This runs immediately'); // Synchronous
    resolve('Done!'); // Schedules .then handler asynchronously
    console.log('2. This runs immediately after resolve'); // Synchronous
});

promise.then((value) => {
    console.log(`3. This runs asynchronously: ${value}`);
});

console.log('4. This runs immediately after the promise is created');
```

**Output Explanation:**

1. `1. This runs immediately` → Runs when the `Promise` is created (synchronous).
2. `2. This runs immediately after resolve` → Runs immediately after `resolve()` is called (still synchronous).
3. `4. This runs immediately after the promise is created` → Runs after the executor is done (synchronous code).
4. `3. This runs asynchronously: Done!` → Runs after the current synchronous code finishes (asynchronously).

**Key Takeaway:**

- **Synchronous**: The executor and any code inside it (except for handlers).
- **Asynchronous**: Handlers (`.then`, `.catch`, `.finally`) are always asynchronous.

**You said:**

So `resolve()` and `reject()` functions inside the `executor()` execute synchronously, but their purpose is to settle the promise and queue the handlers, which will always execute asynchronously?

**ChatGPT said:**

Exactly! Here's a refined breakdown of how it works:

1. **`resolve` and `reject`:**
    - These **execute synchronously**.
    - Their main job is to **mark the Promise as "settled"** (fulfilled or rejected) and to queue up the `.then`, `.catch`, or `.finally` handlers to be executed later.
2. **Handlers (`.then`, `.catch`, `.finally`):**
    - These are **always executed asynchronously**.
    - Even if the `Promise` is already resolved or rejected, the handlers will still wait until the current synchronous code (and any pending tasks in the stack) is finished.
    - Handlers are queued in the **microtask queue** and will run as soon as the call stack is clear.

**Example for Clarity:**

```javascript
const promise = new Promise((resolve, reject) => {
    console.log('1. Executor starts');
    resolve('Data'); // Synchronous
    console.log('2. Executor ends');
});

promise.then((data) => {
    console.log(`3. Handler executed: ${data}`); // Asynchronous
});

console.log('4. After promise is created');
```

**Output:**

1. `1. Executor starts`
2. `2. Executor ends`
3. `4. After promise is created`
4. `3. Handler executed: Data`

**Why?**

- When `resolve('Data')` is called:
    - It **synchronously marks the Promise as resolved**.
    - It schedules the `.then` handler to run **asynchronously**.
- `.then` waits in the **microtask queue** and runs after all synchronous code is completed.

This separation ensures **non-blocking behavior**, which is the core principle of asynchronous programming in JavaScript.

**You said:**

This object offers a mechanism to handle two possible outcomes based on a condition we define. If the condition succeeds, we call `resolve`; if it fails, we call `reject`.

**ChatGPT said:**

Yes, that's a good way to summarize it! The Promise object essentially acts as a mechanism to represent the eventual completion (or failure) of an asynchronous operation. Here's a refined explanation based on your summary:

- **If the condition is successful** (e.g., the operation completes successfully), you call `resolve(value)`. This settles the Promise in the "fulfilled" state and schedules the `.then()` handler to run asynchronously with the provided `value`.
    
- **If the condition fails** (e.g., an error occurs), you call `reject(reason)`. This settles the Promise in the "rejected" state and schedules the `.catch()` handler to run asynchronously with the provided `reason`.

The executor function you pass to the Promise (`new Promise((resolve, reject) => {...})`) is where you define the logic to determine success or failure, and based on that, you choose whether to call `resolve` or `reject`. When working with promises, we generally define some condition or logic in the executor function, and based on its outcome, we either call `resolve` to indicate success or `reject` to indicate failure. This mechanism enables us to handle asynchronous operations in a structured way.
# Bookmarks
Completion: 04.12.2024