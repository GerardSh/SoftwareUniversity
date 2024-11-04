# General
## Functions Overview
Функциите са отделяне на наименувано парче код / subprogram, което изпълнява някаква задача и бихме искали да преизползваме.
Ако пишем последователен код, без отделяне на методи, в един момент ще стане невъзможно за поддръжка, ориентиране, лесно чупливо, трудно за разширяване и промяна. Целта е да разпределяме на различни части и отговорности нашия код и функциите са един от основните начини за постигането на това. Това е част от качеството на кода, а качеството е по-важно дори от бързодействието и производителността. Обикновено колкото по-производителен е един код, толкова е по-некачествен.

**Single Responsibility Principle - SRP**
Една функция трябва да прави само това, което името й казва че прави, а името описва всичко, което функцията прави. Трябва да е строго фокусирана към изпълняването на една конкретна задача, ако са необходими много думи, за да се опише всичко което прави, това означава че има повече задачи, които изпълнява и е хубаво да се фрагментира.

```
There are only two hard things in Computer Science: cache invalidation and naming things.

-- Phil Karlton
```

След като декларираме една функция, може да я извикаме колкото искаме пъти. 

Функциите приемат параметри - това са входните данни и е добре тя да зависи изцяло от тях.

**Naming convention**
Общото правило е да се ползва `camelCase`.
## Why Use Functions
Разделя големи проблеми на малки парчета, което води до по-добра организация и подобрява четимостта и разбираемостта на кода.
Чрез използването на функции, спазваме принципа DRY (don't repeat yourself) - не трябва да copy paste-ваме едно и също парче код на няколко места, защото ако се наложи промяна, трябва да я направим на повече от едно място.

Дори когато имаме на пръв поглед излишна функция като:

```javascript
function printText(text) {
    console.log(text);
}
```

Може да изглежда като, че е по-добре да се ползва директно `console.log(text)` вместо да се прави цяла функция за това.
Но ако утре, по някаква причина се реши `printText()` вместо да печата на конзолата, вече да печата във файлове, ние трябва да променим само `printText()` функцията, без да трябва да променяме нищо друго. Идеята на `printText()` е че знае как да печата текста, до вчера е печатал на конзолата, а когато се наложи, на друго място. Въобще няма да има нужда дори да се замислим на колко места се е ползвала тази функция. Ако бяхме ползвали `console.log()` трябваше да намерим всички места, за да ги променим.
## Declaring Function
Функциите може да се декларират по два начина:

1. **Function declaration**

```javascript
function printText(text) {
    console.log(text);
} // Does not need a semicolon
```

**Hoisting**: могат да бъдат извиквани преди да са дефинирани.

2. **Function expression**
Function expression е деклариране на променлива, която е равна на дадена функция:

```javascript
// Anonymous function
let printText = function (text) {
    console.log(text);
}; // Needs a semicolon

// The same as the above, using an arrow function
let printText = (text) => console.log(text);

// Named function
let printText = function print(text) {
    console.log(text);
}; // Needs a semicolon

// Using existing function
let printText = console.log;
```

Във функционалните изрази, функцията може да бъде анонимна (без име) или именувана. Анонимните функции обикновено се използват за предаване на функции в параметри или за присвояване на функции на променливи. Използването на именувана функция има своите ползи главно при debugging, self documentation, scoping и тн. Може да се ползва и при рекурсия, макар че рекурсията може да се постигне и чрез името на променливата:

```javascript
let factorial = function fact(n) {
    if (n <= 1) return 1;
    
    // Both of these are valid ways to call the function recursively:
    return n * fact(n - 1); // Recursive call using the name 'fact'
    return n * factorial(n - 1); // Recursive call using the variable name 'factorial'
};

console.log(factorial(5)); // Outputs: 120
```

**Not Hoisted**: не могат да бъдат извиквани преди да са дефинирани.

Функциите могат да имат параметри (входни данни) изредени със запетайка, ако са повече от един.

Може да слагаме default стойности на параметрите, но те трябва да са след задължителните параметри - `function myFunction(mandatoryParam, optionalParam = 1)`

Функциите винаги връщат стойност (custom or default).
### Expression / Statement
Expression е всеки израз, който се изпълнява на един ред и връща стойност. Всичко може да е expression, примерно `true`, `5`,`(5)`, `5 + 5`, `true && false` и тн. Обикновено expression-ите имат финална стойност като резултат. Противоположното на expression е statement - `if`, `for`, `while` и тн. 
### Function Hoisting
Hoisting (повдигане) в JavaScript е механизъм, при който декларациите на функции (и променливи) се "повдигат" в горната част на своята обхватна (scope) среда преди изпълнението на кода. Това означава, че можете да извикаме функция, преди да я декларираме в кода.
Примерно ако функцията е декларирана някъде надолу в кода, пак може да бъде извикана. Това показва че JS не е стандартен интерпретатор, но използва комбинация от интерпретиране и компилиране. Интерпретатора е програма която взима JS скрипта и почва да чете редовете от горе на долу. JS има предварителна леко компилационна стъпка, където преминава през целия код и всички намерени функции, ще ги пренесе най отгоре в scope-а. С други думи,  на pre execution фаза, ще декларира функциите и по време на execution фазата, когато ще мине отгоре надолу по скрипта, той вече е декларирал функциите и може да ги изпълни към момента на извикване.
Hoisting-а ни позволява да не се интересуваме от мястото където сме декларирали функцията и мястото от където я извикваме.

Hoisting важи само за декларации на функции, а не за функции, създадени с функционални изрази (function expressions):

```javascript
console.log(myFunction()); // Throws an error: myFunction is not a function

var myFunction = function() {
    return "Hello, World!";
};
```

В този случай `myFunction` ще бъде `undefined` при извикването, защото функцията е присвоена на променливата след извикването.

**JIT Компилация**
Важно е да се отбележи, че JavaScript не само интерпретира, но и компилира код в машинен код по време на изпълнението (Just-In-Time компилация), което подобрява производителността на скриптовете.
### Function Invocation / Calling
Без значение как е декларирана функцията, извикването й става по име и подаване на аргумент, ако има такъв. Аргументите са стойностите, които се подават по време на извикването, а параметрите са променливите, които стоят в декларираната функция. Има функции, които нямат параметри, а само изпълняват някаква задача. Параметрите са си нормални променливи, които използваме в тялото на функцията.

Пример на function calling която е декларирана чрез expression:

```javascript
let printText = function (text) {
    console.log(text);
}; 

printText('Some text...')
```

Трябва да се внимава, ако функцията е декларирана чрез expression, да се извиква след декларацията, защото не подлежат hoisting.

Няма никакъв проблем да имаме функция, която вътре в себе си да извиква други функции или дори да извиква себе си, което се нарича рекурсия.
# Misc
# ChatGPT
## Functions as Variables
You can think of functions in JavaScript (and in programming languages in general) as first-class objects that are treated as reference types. Here’s a breakdown of how this analogy works and some relevant concepts:

1. **First-Class Objects**: In JavaScript, functions are first-class citizens, which means they can be treated like any other variable. You can assign them to variables, pass them as arguments to other functions, and return them from functions.

```javascript
 const myFunction = function() {
    console.log("Hello, world!");
};
```

2. **Holds a Block of Code**: Just as a variable holds a value, a function holds a block of code that can be executed when the function is called. When you define a function, you're essentially creating a reference to a piece of executable code.
3. **Memory Storage**: Functions are stored in memory (specifically in the heap), similar to how objects are stored. When a function is declared, it is allocated memory where the code resides.

**Retrieving the Function**

1. **Function Reference**: When you assign a function to a variable or pass it as an argument, you’re not copying the entire function; you’re passing a reference to that function. This means you’re effectively getting a pointer to the memory location where the function’s code is stored.

```javascript
function add(a, b) {
    return a + b;
}

const sum = add; // sum now holds a reference to the add function
console.log(sum(2, 3)); // Outputs: 5
```

2. **Calling the Function**: When you call a function (e.g., `add(2, 3)`), the JavaScript engine looks up the reference to the function in memory and executes the code located at that address.

**Conclusion**

In summary, you can say that functions are like variables that hold a piece of code. They are stored in heap memory, and through a variable (the function reference), you can retrieve and execute the code. This characteristic allows for powerful programming paradigms such as higher-order functions, callbacks, and functional programming techniques in JavaScript.
## Statements and Expressions in JavaScript:

**Expressions**

- **Definition**: A piece of code that evaluates to a value.
- **Characteristics**:
    - Can be used as part of statements.
    - Examples: `5`, `x + 3`, `"Hello World"`, `true && false`.
    - Return a value when evaluated.

**Statements**

- **Definition**: A complete command that performs an action but does not return a value.
- **Characteristics**:
    - Control the flow of the program.
    - Examples: `if`, `for`, `while`, `function declarations`.
    - Typically end with a semicolon (`;`), but not always required for expressions.

**Key Difference**

- **Value vs Action**: Expressions evaluate to a value, while statements perform an action without returning a value.
# Bookmarks 