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
По същия начин както в DOM даваме функцията `addEventListener()` - казваме на browser-a който се явява worker-a, като види че потребителя е кликнал върху даден елемент, да изпълни определен listener. Реално JS делегира на browser-a тази задача - да изпълни дадената функция, когато е нужно и не се занимава повече. Когато worker-a приключи със задачата, без значение каква е, може да е изчакване за event, изчакване на някакъв timeout, може да е всичко, но когато приключи, той казва - готов съм да изпълня подадената функция. Въпроса е че тази функция не се изпълнява веднага и от worker-a, неговата работа е да каже че е готов на Event Loop-a, който е нещо като безкраен цикъл, който стои и се върти. Реално имаме отделна на стека структура, наречена Event Queue - опашка, в която се нарежда нашата функция. Ако queue-то е празно, ще бъде най-отпред, а ако не е, се нарежда на края на опашката. Функциите се поставят в Event Queue от външните механизми като системни таймери, I/O операции или браузърни API, когато условията за това са изпълнени. EL ще изчака стека да се изпразни, тоест синхронния код трябва да приключи първо, тогава EL ще вземе функцията от опашката и ще я вкара в стека за изпълнение - ще вземе асинхронната функция, ще я вкара в стека и ще я изпълни синхронно. Всяка асинхронна операция ще се регистрира и като е готова, ще си чака времето. Това което трябва да разберем е, че във всеки един момент кода се изпълнява синхронно и EV се грижи да вкара асинхронни функции за синхронно изпълнение, защото имаме single thread.
## Synchronous vs Asynchronous Programming
Има три механизма за изпълнение на асинхронен код в JS, като това не е същото като concurrent или multithreaded, защото тогава изрично казваме че имаме повече от една нишка в която работи. Механизмите са:
### 1. Callback Functions 
Принципно това са функции, които се подават като аргументи на други функции. В контекста на асинхронното програмиране, функцията `setTimeout()`, приема callback функция, която ще бъде подадена към Event Queue-то Системният таймер след като изчака указаното време. След това ще подаде callback в Event Queue. Event Loop ще я вземе от опашката и ще я постави в Execution Stack, но само след като стекът се освободи от синхронния код. Това е асинхронна операция, ще се случи сватбата, след като се извърши нужната подготовка.
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

Промисите може да ги създаваме, ако искаме да създадем асинхронната операция, но това се налага рядко, по-често се консумират. Създават се с ключовата дума `new` и конструктора очаква функция, която се нарича `executor` и приема две функции, чрез нея се извършва конфигурацията.  На този екзекутор, се подават като аргументи функциите `resolve()` и `reject()`. `resolve()` приема value, а `reject()` приема reason. `resolve()` приема като аргумент резултат с който промиса ще се изпълни.
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

За да обобщим:
- `executor()` е функцията, която се изпълнява веднага при създаване на промиса. Тя получава функциите `resolve()` и `reject()`, които са вътрешно генерирани в класа `Promise`.
- Когато промисът се изпълни успешно (извика се `resolve()`), функцията в `then()` ще бъде извикана.
- Когато промисът се провали (извика се `reject()`), функцията в `catch()` ще бъде извикана.

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
## How the Promise Constructor Works Internally
The `Promise` constructor defines `resolve` and `reject` internally, and these functions are not accessible outside the constructor. The executor function is provided by the user and runs in the user's code context, not inside the constructor's scope. To give the executor access to `resolve` and `reject`, the constructor explicitly passes them as arguments when calling the executor. This ensures the executor can interact with the internal promise state while maintaining encapsulation.

Here’s a simplified version of how the `Promise` constructor works:

```javascript
class Promise {
    constructor(executor) {
        // Internal state
        let state = "pending"; // Can be 'pending', 'fulfilled', or 'rejected'
        let value;             // The value of the fulfilled promise
        let reason;            // The reason for rejection

        // Internal resolve function
        const resolve = (result) => {
            if (state === "pending") {
                state = "fulfilled";
                value = result;
                console.log("Promise resolved with value:", value);
                // Execute `.then` callbacks here in the real implementation
            }
        };

        // Internal reject function
        const reject = (error) => {
            if (state === "pending") {
                state = "rejected";
                reason = error;
                console.log("Promise rejected with reason:", reason);
                // Execute `.catch` callbacks here in the real implementation
            }
        };

        // Call the executor and pass `resolve` and `reject` to it
        try {
            executor(resolve, reject);
        } catch (err) {
            // If the executor throws an error, reject the promise
            reject(err);
        }
    }
}
```

**Example of Usage**

Now, here’s how you would use this `Promise` constructor:

```javascript
const promise = new Promise((resolve, reject) => {
    console.log("Executor is running...");

    const randomNumber = Math.random(); // Generate a random number

    if (randomNumber > 0.5) {
        resolve("Success! Random number is greater than 0.5");
    } else {
        reject("Failure! Random number is less than or equal to 0.5");
    }
});

// This would log either "Promise resolved with value..." or "Promise rejected with reason..."
```

**Key Points**

1. The `resolve` and `reject` methods are created **inside the constructor** and are bound to the internal state of the promise.
2. The executor function, written by the user, is **called by the constructor** with `resolve` and `reject` passed as arguments.
3. The executor itself runs in the user's code context, but it uses the `resolve` and `reject` functions to interact with the promise's internal state.

This structure keeps the promise's state encapsulated and ensures that only the provided `resolve` and `reject` methods can modify it.

**You Said:**

If i understand correctly right after the creation of the object, we already know if the promise is failed or not, because during the initialization of the promise object it is executing the executor method and it catches the state?

**ChatGPT Said:**

Yes, you’re correct! The **executor function** is executed **immediately** when the `Promise` object is created, and during its execution, the state of the promise (`pending`, `fulfilled`, or `rejected`) is determined.

Here’s the step-by-step breakdown of what happens:

**1. Promise Object Creation**

When you create a new `Promise`:

```javascript
const promise = new Promise((resolve, reject) => {
    // Executor logic runs immediately
    const randomNumber = Math.random();
    if (randomNumber > 0.5) {
        resolve("Success!"); // Fulfill the promise
    } else {
        reject("Failure!"); // Reject the promise
    }
});
```

- The `Promise` constructor is called.
- The `executor` function is passed to the constructor.
- Inside the constructor, the `executor` is invoked **immediately** with the `resolve` and `reject` functions as arguments.

**2. Determining the State**

- The promise starts in the `pending` state.
- Based on the logic in the executor:
    - If `resolve` is called, the state changes to `fulfilled`.
    - If `reject` is called, the state changes to `rejected`.
- Once the state is determined, it **cannot change** again (a promise is immutable after being settled).

**3. Example**

Let’s look at an example to visualize this:

```javascript
const promise = new Promise((resolve, reject) => {
    console.log("Executor is running...");

    const randomNumber = Math.random();

    if (randomNumber > 0.5) {
        resolve("Success!"); // Fulfill the promise
    } else {
        reject("Failure!"); // Reject the promise
    }
});

console.log("Promise created!");

// Attaching handlers
promise
    .then((result) => console.log("Resolved with:", result))
    .catch((error) => console.log("Rejected with:", error));
```

**Output:**

```
Executor is running...
Promise created!
Resolved with: Success!   // or
Rejected with: Failure!
```

**Key Points**

1. **Executor Runs Immediately**
    
    - As soon as the `Promise` object is created, the executor function runs.
    - This means that the promise's fate (fulfilled or rejected) is determined right away.
2. **State is Captured**
    
    - The `resolve` or `reject` function updates the state of the promise (to `fulfilled` or `rejected`).
    - The state transition happens during the execution of the executor.
3. **Asynchronous Behavior of Handlers**
    
    - Even though the state is determined immediately, the `.then` and `.catch` handlers won’t execute until the next JavaScript event loop tick (making promises asynchronous).

**When Would a Promise Not Be Settled Immediately?**

The promise's state might not be determined immediately if the executor contains asynchronous operations. For example:

```javascript
const promise = new Promise((resolve, reject) => {
    console.log("Starting async operation...");
    setTimeout(() => resolve("Done!"), 1000); // Fulfill after 1 second
});

console.log("Promise created!");

// Attaching handlers
promise.then((result) => console.log(result));
```

**Output:**

```
Starting async operation...
Promise created!
Done!    // Logs after 1 second
```

In this case:

- The promise remains in the `pending` state until the `setTimeout` completes.
- The executor is still executed immediately, but the state transition happens later.

**You Said:**

If there is no asynchronous operation, then the promise is settled immediately?

**ChatGPT Said:**

Exactly! If there is no asynchronous operation inside the executor function, the promise is settled **immediately** during its creation. This means the promise's state transitions from `pending` to either `fulfilled` or `rejected` synchronously, as the executor function completes.

Here’s an example to clarify:

**Synchronous Executor**

```javascript
const promise = new Promise((resolve, reject) => {
    console.log("Executor is running...");
    
    const randomNumber = Math.random();

    if (randomNumber > 0.5) {
        resolve("Success!"); // Immediately fulfill
    } else {
        reject("Failure!"); // Immediately reject
    }
});

console.log("Promise created!");

// Attaching handlers
promise
    .then((value) => console.log("Promise resolved with:", value))
    .catch((error) => console.log("Promise rejected with:", error));
```

 **Output**

For example, if `randomNumber` is `0.8`:

```
Executor is running...
Promise created!
Promise resolved with: Success!
```

If `randomNumber` is `0.3`:

```
Executor is running...
Promise created!
Promise rejected with: Failure!
```

**Key Behavior**

1. The **executor runs immediately**, and `resolve` or `reject` is called synchronously, so the promise is settled before the `Promise` constructor finishes execution.
2. The `.then` or `.catch` handlers are registered **after** the promise has already settled.
3. **Promise handlers are always asynchronous**:
    - Even if the promise is settled immediately, the `.then` or `.catch` callbacks will run in the next JavaScript event loop tick.

**Explanation of Asynchronous Handlers**

Even though the promise is settled synchronously, the handlers (`.then` or `.catch`) execute asynchronously. Here's an example to demonstrate:

```javascript
const promise = new Promise((resolve, reject) => {
    resolve("Immediate success!"); // Synchronously settle the promise
});

console.log("After promise creation"); // This logs before `.then` is executed

promise.then((value) => console.log(value));
```

**Output:**

```
After promise creation
Immediate success!
```

**Why?**

The `.then` or `.catch` handlers always run asynchronously to ensure consistent behavior, regardless of whether the promise settles synchronously or asynchronously. This is part of the **microtask queue** in JavaScript's event loop.

**Key Takeaway**

- If there’s no asynchronous operation in the executor, the promise is settled immediately during its creation.
- However, the `.then` or `.catch` callbacks will always be executed in the next event loop tick, ensuring predictable behavior.
## Understanding `.then()`

In JavaScript, promises are used to handle asynchronous operations. When you call `.then()` on a promise, you provide two callbacks: one for when the promise is resolved (fulfilled) and one for when it is rejected. These callbacks are executed depending on the state of the promise.

Here’s a simplified representation of how `.then()` works, including how the promise state (pending, fulfilled, or rejected) impacts the execution:

**1. Synchronous Nature of `.then()`**

The `.then()` method itself is always executed synchronously, meaning the JavaScript interpreter will enter `.then()` during the execution of the current synchronous code, whether the promise is already resolved or not.

- If the promise is already fulfilled or rejected when `.then()` is called, the corresponding callback (`onFulfilled` or `onRejected`) is added to the micro-task queue and will be executed asynchronously, after the current synchronous code finishes. Even though the promise's state is already settled, the callback will not execute immediately but will be processed in the next available micro-task cycle.
- If the promise is still pending (i.e., there’s an asynchronous operation inside the executor function), the `.then()` method will not execute the callback right away. Instead, the callback is queued to be executed later when the promise settles (either resolves or rejects).

**2. When the Promise is Fulfilled or Rejected**

- If the promise is already resolved at the time `.then()` is called, the callback (`onFulfilled` or `onRejected`) is executed immediately. However, this is still done asynchronously using `Promise.resolve().then()`, meaning it is placed in the micro-task queue to be executed after the current synchronous code finishes.
- If the promise is pending at the time `.then()` is called, the callback is stored in the internal callback queue of the promise. This queue holds the functions until the promise is resolved or rejected. Once the promise settles, the callback functions are taken from this queue and executed.

**3. The Triggering Mechanism**

The triggering mechanism that ensures the `.then()` callbacks are executed is inside the `resolve()` and `reject()` methods of the promise. These methods are called inside the executor function when the asynchronous operation (e.g., `setTimeout`, network request) finishes.

- Once the `resolve()` or `reject()` method is called, it:
    - Settles the promise, changing its state from "pending" to either "fulfilled" or "rejected".
    - Calls the `executeCallbacks()` method (or similar) to execute any stored callbacks in the promise’s internal queue. This ensures that the appropriate callback for `.then()` is executed after the promise is settled.
    - The `resolve()` and `reject()` functions do not block execution; they simply mark the promise as settled, and the actual callback execution happens asynchronously after the current call stack is cleared.

**Closures**: The `resolve()` and `reject()` methods capture the promise's state through closures, allowing them to modify the promise's state and trigger callback executions asynchronously after the execution context (executor function) finishes.

**4.  How `.then()` Works Internally**

When `.then()` is called on a promise:

- If the promise is already settled (resolved or rejected), the callback is scheduled to run asynchronously using `Promise.resolve().then()` (this ensures that the callback doesn't block the current execution and gets added to the micro-task queue).
- If the promise is pending, the callback is pushed to the internal queue of the promise. The callback will be executed later once the promise is settled by calling `resolve()` or `reject()`.
- In both cases, the callback (`onFulfilled` or `onRejected`) is executed after the current synchronous code finishes, ensuring that all code runs in the proper order.

 **5. No Asynchronous Operation in Executor**

If there is no asynchronous operation in the executor function (e.g., no `setTimeout` or network request), the promise is immediately resolved or rejected. However, `.then()` will **always** execute synchronously in the sense that it is called during the execution of the current synchronous code.

- **If the promise is already settled (resolved or rejected)** when `.then()` is called, the callback function provided to `.then()` will **not execute immediately**. Instead, it is placed in the **micro-task queue**, and will be executed asynchronously after the current call stack is cleared, i.e., once all synchronous code has finished running.

- **If the promise is not settled yet** (i.e., still pending) when `.then()` is called, the callback function is added to the internal queue and will be executed later when the promise settles.

So, even if there is no asynchronous operation in the promise executor, `.then()` guarantees that the callback will always execute asynchronously, placed in the micro-task queue. The function in `.then()` is not executed immediately, but rather after the current synchronous code finishes and the micro-task queue is processed.

This means `.then()` is always asynchronous, regardless of the promise being settled immediately or after an asynchronous operation.

**Visual Representation**

Here’s a simplified flow of how `.then()` works in different scenarios:

**Scenario 1: Promise is already resolved**

```javascript
let promise = Promise.resolve("Resolved!");

promise.then((result) => {
  console.log(result); // "Resolved!" is logged
});

console.log("This is synchronous");
```

1. Synchronous code runs first, logging "This is synchronous".
2. The promise is already resolved when `.then()` is called, so `onFulfilled` runs asynchronously, and "Resolved!" is logged after the synchronous code.

**Scenario 2: Promise is still pending**

```javascript
let promise = new Promise((resolve) => {
  setTimeout(() => {
    resolve("Resolved after 2 seconds");
  }, 2000);
});

promise.then((result) => {
  console.log(result); // "Resolved after 2 seconds" is logged
});

console.log("This is synchronous");
```

1. Synchronous code runs first, logging "This is synchronous".
2. The promise is pending while the `setTimeout` function runs.
3. The `.then()` callback is queued and will be executed after the promise resolves, even though `.then()` was called synchronously.

**Internal Flow:**

1. `.then()` is called.
2. If the promise is resolved or rejected, `Promise.resolve().then()` queues the callback.
3. If the promise is pending, the callback is added to the internal queue.
4. Once the promise settles (either fulfilled or rejected), the `resolve()` or `reject()` function triggers the callback execution. The callback is then moved from the internal queue to the micro-task queue for execution after the current synchronous code finishes.

**.then() with Error Handling**

Two Callbacks in `.then()`: The `.then()` method can take two callbacks: one for the fulfilled state (`onFulfilled`) and one for the rejected state (`onRejected`), but you can define only the first one. For better error handling, `.catch()` can be used instead of providing the `onRejected` callback in `.then()`. This keeps the code cleaner and handles errors separately.

**Summary of Closures and Triggering Mechanism**

- **Closures**: `resolve()` and `reject()` capture the promise’s state through closures, preserving the state and enabling asynchronous execution of the callbacks after the promise is settled.
- **Callback Queue**: If the promise is still pending when `.then()` is called, the callback is pushed into the internal queue. Once the promise settles, the callbacks in the queue are executed.
## Understanding `resolve()` and `reject()` in Promises
In JavaScript, promises are used to handle asynchronous operations and represent a value that may be available now, or in the future. The `resolve()` and `reject()` methods are part of the promise executor function, and they are key mechanisms for changing the internal state of a promise.

**1. Simple Mechanism for Changing State**

The primary role of `resolve()` and `reject()` is to transition the promise's state from **pending** to either **fulfilled** (resolved) or **rejected**.

- **`resolve(value)`**: This method updates the promise's state from "pending" to "fulfilled" and assigns a value to the promise's internal `value` property. This value is passed to the `onFulfilled` callback in `.then()`. Even if the promise resolves immediately (without any asynchronous operation), the state will be set instantly, but the callbacks will still execute asynchronously.
    
- **`reject(reason)`**: This method updates the promise's state from "pending" to "rejected" and assigns a reason (typically an error) to the promise's internal `reason` property. This reason is passed to the `onRejected` callback in `.catch()`. Like `resolve()`, `reject()` can be called immediately to change the promise's state, and the callbacks will still be executed asynchronously.

Even if there is no asynchronous operation (like a `setTimeout` or a network request) in the promise's executor, `resolve()` or `reject()` will instantly change the state of the promise from pending to resolved or rejected. This means that the promise will be settled immediately, but callbacks provided by `.then()` or `.catch()` will still execute asynchronously, as JavaScript places them in the micro-task queue.

**2. Callbacks Always Executed Asynchronously**

Regardless of whether the promise is immediately resolved or rejected, the callbacks you provide to `.then()` or `.catch()` will always execute asynchronously. Here’s why:

When `.then()` or `.catch()` is called, JavaScript queues the provided callback functions to run asynchronously. Even if the promise is already settled (either resolved or rejected), the callbacks will not execute immediately. They will be executed after the current synchronous code completes, ensuring non-blocking behavior.

This is because `.then()` and `.catch()` use the **micro-task queue**, which is processed after the current execution context and before rendering or handling other events in the event loop. Therefore, the callbacks are guaranteed to run asynchronously, even if the promise was already resolved or rejected at the moment `.then()` or `.catch()` was called.

**3. Visual Example**

Consider a scenario where there is no asynchronous operation in the executor:

```javascript
let promise = new Promise((resolve, reject) => {
  // No asynchronous operation, resolve is called instantly
  resolve("Promise resolved immediately!");
});

promise.then((result) => {
  console.log(result);  // "Promise resolved immediately!" is logged asynchronously
});

console.log("This is synchronous.");
```

- The promise is resolved immediately by calling `resolve()` inside the executor.
- The promise transitions from pending to fulfilled instantly.
- However, the callback inside `.then()` is placed in the micro-task queue, and it will be executed asynchronously after the synchronous code (like `console.log("This is synchronous.")`) finishes executing.

**Output:**

```
This is synchronous.
Promise resolved immediately!
```

**4. Key Points**

- `resolve()` and `reject()` are mechanisms that simply change the state of the promise and add a value or reason to the internal promise properties (`value` and `reason`).
- These methods can immediately settle a promise, even if there is no asynchronous operation in the executor.
- Regardless of when the promise is settled, the callbacks inside `.then()` or `.catch()` are always executed asynchronously, ensuring that they do not block the main thread and are handled in the next available micro-task cycle.

**5. Why This Matters**

This design allows promises to handle both synchronous and asynchronous code uniformly. Even if the promise resolves instantly (without asynchronous code in the executor), callbacks will still execute asynchronously. This ensures consistent behavior and prevents blocking of the main thread, which is a core feature of promises in JavaScript. It enables non-blocking execution of subsequent code after promise resolution or rejection, ensuring smooth asynchronous operations.
## Simple Representation of the `Promise` Class
This structure focuses on how the `resolve()`, `reject()`, and `.then()` methods interact with the promise's state and internal callback queues.

```javascript
class MyPromise {
  constructor(executor) {
    this.state = 'pending'; // The initial state of the promise
    this.value = undefined; // The value or reason passed to resolve or reject
    this.reason = undefined;
    this.callbacks = []; // Queue for storing .then() callbacks

    // Call the executor function, which contains the logic for resolving/rejecting
    executor(this.resolve.bind(this), this.reject.bind(this));
  }

  // Resolve the promise, transitioning the state to "fulfilled"
  resolve(value) {
    if (this.state === 'pending') {
      this.state = 'fulfilled';
      this.value = value;

      // Execute the callbacks in the queue asynchronously
      this.executeCallbacks();
    }
  }

  // Reject the promise, transitioning the state to "rejected"
  reject(reason) {
    if (this.state === 'pending') {
      this.state = 'rejected';
      this.reason = reason;

      // Execute the callbacks in the queue asynchronously
      this.executeCallbacks();
    }
  }

  // Method to store the callback functions and execute them once the promise settles
  executeCallbacks() {
    // Callbacks will be executed after the current synchronous code finishes
    setTimeout(() => {
      // Execute all callbacks based on the current state (fulfilled or rejected)
      this.callbacks.forEach(callback => {
        if (this.state === 'fulfilled') {
          callback.onFulfilled(this.value);
        } else if (this.state === 'rejected') {
          callback.onRejected(this.reason);
        }
      });
    }, 0);
  }

  // .then() method to add callbacks for the fulfilled and rejected states
  then(onFulfilled, onRejected) {
    // Return a new promise to allow chaining
    return new MyPromise((resolve, reject) => {
      const handleFulfilled = (value) => {
        try {
          if (onFulfilled) {
            const result = onFulfilled(value);
            resolve(result); // Resolve the new promise with the result of onFulfilled
          } else {
            resolve(value); // If no onFulfilled, just resolve with the value
          }
        } catch (error) {
          reject(error); // If an error occurs in the callback, reject the promise
        }
      };

      const handleRejected = (reason) => {
        try {
          if (onRejected) {
            const result = onRejected(reason);
            resolve(result); // Resolve the new promise with the result of onRejected
          } else {
            reject(reason); // If no onRejected, just reject with the reason
          }
        } catch (error) {
          reject(error); // If an error occurs in the callback, reject the promise
        }
      };

      if (this.state === 'fulfilled') {
        handleFulfilled(this.value); // If the promise is already fulfilled, execute immediately
      } else if (this.state === 'rejected') {
        handleRejected(this.reason); // If the promise is already rejected, execute immediately
      } else {
        // If the promise is still pending, store the callbacks
        this.callbacks.push({
          onFulfilled: handleFulfilled,
          onRejected: handleRejected,
        });
      }
    });
  }
}
```

**Key Points in the Structure:**

- **State and Value/Reason:** The `state` property tracks whether the promise is pending, fulfilled, or rejected. The `value` and `reason` hold the resolution value or rejection reason, respectively.
- **Callbacks Queue:** The `callbacks` array stores functions to be executed when the promise settles (either fulfilled or rejected).
- **`resolve()` and `reject()` Methods:** These methods change the promise’s state from "pending" to either "fulfilled" or "rejected." After this, they trigger the execution of stored callbacks by calling `executeCallbacks()`.
- **`executeCallbacks()` Method:** This method processes the callbacks in the `callbacks` array asynchronously (in a micro-task). It ensures that callbacks are executed after the synchronous code has finished executing.
- **`.then()` Method:** This method accepts two callback functions: one for when the promise is fulfilled and one for when it is rejected. If the promise has already settled, the appropriate callback is immediately executed. Otherwise, the callbacks are stored in the `callbacks` queue to be run later when the promise settles.

**Explanation of How `.then()` Works with This Class:**

1. **If the Promise is Already Settled:**
    - The appropriate callback (`onFulfilled` or `onRejected`) is executed immediately via `executeCallbacks()`. This still happens asynchronously, which is why we use `setTimeout` to move the callbacks to the micro-task queue.
2. **If the Promise is Still Pending:**
    - The `then()` method stores the callback functions (`onFulfilled` and `onRejected`) in the `callbacks` array. Once the promise settles (via `resolve()` or `reject()`), the `executeCallbacks()` method is called, which will then trigger the appropriate callback asynchronously.

**Visual Flow:**

1. **Creating the Promise:** The `new MyPromise()` constructor is invoked with an executor function that defines how the promise is settled (either with `resolve()` or `reject()`).
2. **Resolving or Rejecting:** The `resolve()` or `reject()` methods are called, which change the promise's state.
3. **Handling Callbacks:** The `.then()` method is used to provide callbacks. If the promise is already settled, the callbacks are executed asynchronously. If the promise is pending, the callbacks are stored and executed when the promise settles.

This class structure should help provide a clearer understanding of how promises work internally, based on the explanations provided earlier.
## Promise Chaining and `.then()` Method
**1. Chaining `.then()` Calls**

- Chaining `.then()` methods allows you to process the resolved value of a promise step by step.
- Each `.then()` receives the resolved value from the previous `.then()` and can transform or process it further.

**2. `.then()` Always Returns a Promise**

- **Key Point:** `.then()` always returns a promise.
    - If you return a regular value (e.g., a number or string), JavaScript wraps it in a resolved promise.
    - If you don't return anything, `.then()` returns the original promise, making chaining pointless as the same value is passed forward.
    - If you return another promise, the next `.then()` waits for it to resolve.

**3. Scenarios of Using `.then()`**

- **Returning a Value:**
    
    - If you return a regular value (e.g., `result + 5`), `.then()` wraps it in a resolved promise. The next `.then()` receives the resolved value.
    
    Example:
    
```javascript
Promise.resolve(5)
  .then((result) => {
    return result + 5;  // Returns a resolved promise with value 10
  })
  .then((newResult) => {
    console.log(newResult); // Logs 10
  });
```
    
- **Not Returning Anything:**
    
    - If you don’t return anything, the promise from the previous `.then()` is passed forward, and the next `.then()` gets the same value.
    
    Example:
    
```javascript
Promise.resolve(5)
  .then((result) => {
    return result + 5;  // Returns a resolved promise with value 10
  })
  .then((newResult) => {
    console.log(newResult); // Logs 10
  });
```


- **Returning a Promise:**
    
    - If you return a promise, the next `.then()` waits for that promise to resolve before continuing.
    
    Example:
    
```javascript
Promise.resolve(5)
  .then((result) => {
    return new Promise((resolve) => resolve(result + 5));  // Returns a new promise
  })
  .then((newResult) => {
    console.log(newResult); // Logs 10, after the promise resolves
  });
```

**4. Why Use Multiple `.then()`s?**

- Chaining multiple `.then()` calls is useful to:
    - Modify or transform the promise’s value step by step.
    - Ensure asynchronous tasks execute in sequence, with each `.then()` handling the result of the previous task.
    - Make the code cleaner and more readable compared to nested callbacks or individual `.then()` calls.

**Key Takeaways:**

- **Each `.then()` transforms the promise's resolved value**, and this is the basis for promise chaining.
- **The value returned from each `.then()` affects the next `.then()` in the chain**, either by returning a new value, the same value, or a promise.

By understanding this, you can handle multiple asynchronous tasks more effectively, passing data and managing errors smoothly through each step of your code.
## Summary of How `.catch()` Works in Promises
1. **Purpose of `.catch()`**:
    - The `.catch()` method is used to handle errors (rejections) in a promise chain.
    - It acts as an error handler for rejected promises or exceptions thrown inside `.then()` callbacks.
2. **Error Propagation**:
    - If a promise in the chain is rejected, the error will propagate down to the nearest `.catch()` handler.
    - `.catch()` catches errors in both:
        - Promises that are explicitly rejected.
        - Errors thrown inside a `.then()` callback (e.g., if you throw an exception inside the `.then()` function).
3. **Placement in the Chain**:
    - You can place `.catch()` at the end of a promise chain to handle any errors that occur at any step before it.
    - If there’s no `.catch()` and an error occurs, the promise chain will fail silently or unhandled, depending on how the promise is written.
4. **Chaining Behavior**:
    - Just like `.then()`, `.catch()` returns a promise.
    - If there’s no error, `.catch()` simply passes through the resolved value to the next `.then()` or `.catch()`.
    - If there is an error, `.catch()` will handle it, and you can return a new value or promise to continue the chain.
5. **Error Handling Flow**:
    - If there’s an error in any promise, or if any `.then()` callback throws an error, `.catch()` catches it and allows you to decide how to proceed with the error (e.g., log the error, return a default value, etc.).
    - `.catch()` ensures that the error doesn't stop the rest of the promise chain from executing.

**Example**

```javascript
Promise.resolve(5)
  .then((result) => {
    console.log(result);  // Logs: 5
    return result + 5;  // Resolves to 10
  })
  .then((result) => {
    console.log(result);  // Logs: 10
    throw new Error("Something went wrong!");  // Error thrown here
  })
  .catch((error) => {
    console.log(error.message);  // Logs: Something went wrong!
  });
```

**Key Points:**

- **`.catch()` is specifically for handling rejected promises or errors.**
- It can catch errors from previous promises or from any `.then()` callback that throws an exception.
- It returns a promise, so you can continue chaining.
- The error is caught and processed, and the chain can proceed with new values or continue with an alternative flow.
# Bookmarks
Completion: 04.12.2024