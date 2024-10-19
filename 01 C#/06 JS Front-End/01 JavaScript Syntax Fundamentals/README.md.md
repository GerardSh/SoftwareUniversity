# General
## History
JS е създаден през 1995г с името `Mocha`, когато web съдържанието е било изключително статично, нещо подобно на Wikipedia - текстове, картинки и линкове. Нямало е нищо динамично. Целта на JS е точно да даде динамика, да даде възможност да се правят допълнително динамични features. Замислен е да бъде лесен за ползване. Към момента е най-популярния език в света за ползване. След време му сменят името на `LiveScript`, но след това решават отново да го прекръстят на `JavaScript` заради популярността на `Java`.

Стандартизира се през 1997г, като стандарта се нарича `ECMAScript` - документация където се описва как точно JS трябва да работи, за да може всеки един от browser-ите да го изпълнява по един и същи начин. Всеки browser си има собствен интерпретатор, който интерпретира JS кода.
Различните версии на стандарта са се наричали първоначално ES1, ES2 и тн. След 2009 година, новите версии се наименуват и по името на годината ES2015, ES2016 и тн, като и двете наименувания са официални.

[ECMA-262 - Ecma International](https://ecma-international.org/publications-and-standards/standards/ecma-262/)
## What is JavaScript
Език от високо ниво, който е сърцевината на World Wide Web. 

JS позволява интерактивни web приложения. Скучните web страници може да станат интерактивни, от тук се заражда думата апликация, защото има неща, които взаимодействат с потребителското поведение. JS е основната технология, която позволява това.

JS е скриптов език. Също така е interpreted (интерпретиран) език - директно се чете и изпълнява кода, докато C# е compiled (компилиран) език - където  се преминава през междинна компилация и превеждане до междинен код, който се изпълнява в последствие. Върху JS може да се ползва TypeScript, който прави типизиран синтаксис, който се компилира до обикновен JS. 

През developer tools на browser-a - Console, получаваме достъп до вътрешния интерпретатор, който изпълнява JS. Подаваме му код, който ще го изпълни и ще ни върне резултат веднага. Освен в browser-а 
### Client / Server
В web имаме два участника - client и server, които комуникират помежду си. Обикновено клиента е browser - software който прави заявка през web, до web server - software който стои и слуша за заявки. JS стои основно в client  страна, той е текстов файл, който ще бъде получен и изпълнен от browser-a. В този курс ще се учи client JS.
### SPA - Single Page Application
Application който се зарежда само веднъж, без да се презарежда, но динамично вътре с помощта на JS се презарежда съдържанието. Това важи за повечето апликации, като Gmail, Facebook, Instagram и тн. Това дава приятен user experience UX, защото всичко се зарежда бързо. SPA приложенията нямаше да са възможни, ако нямаше JS, защото съдържанието се генерира на клиента а не чакаме сървъра да ни отговори с новото съдържание.
## Features
C-like syntax (curly-brackets, identifiers, operator) - много сходен с езици като C#, Java, C, C++ и други.  

Multy-paradigm (imperative, functional, OOP) - не е строго ориентиран в една парадигма. C# и Java са строго ориентирани към OOP, докато OOP на JS е много по-слабо, докато функционалното програмиране е много по засегнато.

Dynamic typing - променливите нямат типове, но стойностите имат типове. Може на една променлива, да й присвоим дадена стойност, след това да й присвоим стойност от друг тип данни. Това няма да доведе до грешка или предупреждение.
## Node.js
Browser-a е средата за изпълнение на JS, а Node.js е друг runtime, който трябва да си инсталираме. Препоръчително е да изтеглим LTS (long term support) версията - [Node.js — Download Node.js®](https://nodejs.org/en/download/prebuilt-installer)
Използва V8 JavaScript engine интерпретатор, който е част от chromium - open source browser engine. Chromium е комплект от всичко нужно, за да може да работи browser-a и понеже е open source, са взели интерпретатора му и са го сложили в Node.js. Същата интерпретация която имаме в chrome, ще имаме и в Node.js. Примерно Firefox използва друг интерпретатор. 
Node.js позволява да инсталираме пакети.
## Visual Studio Code
При инсталацията трябва да посочим двете опции започващи с `Add "Open with Code" action..`,  за да може да посочим дадена папка и да я отворим директно с VS Code. JS файловете са текстови файлове, които трябва да завършват с `.js` за да бъде разпознат от редактора, че това не е просто текстов файл, а файл където ще пишем JS. По разширението VS Code се ориентира какво пишем, за да го highlight-ва правилно.
## JavaScript Syntax
### let
Дефиниране на променливи чрез `let` примерно `let age = 18;` което буквално означава - нека променливата `age` да е равна на 18.
Променливите не се интересуват от типа данни, който ще бъде записан в тях. Това е все едно да имаме един вид буркани и в него слагаме каквото си искаме, докато в C# имаме буркан за всяко нещо, което искаме да сложим. Променливата не се интересува от типа който ще бъде запаметен от нея, а типа си го носи единствено самата стойност

```js
// Variable declaration
let age = 18;
let firstName = 'Gosho';
let isMale = true;

// Basic solve function

function solve(num1, num2) {
    console.log(num1 + num2);
}

// Execute solve function
solve(1, 2);

// Print on the console
console.log('My name is ' + firstName + '!');
console.log(`My name is ${firstName}!`);

// Fix numbers 
let firstNumber = 3;
let secondNumber = 3.14159265359;
console.log(firstNumber.toFixed(2));
console.log(secondNumber.toFixed(2));
```
## Functions and Input Parameters
За JS не е естествено да се чете през конзолата, понеже няма как да стане в browser-a, затова JS начина е да се направи функция, която 
ще приема input-a като параметър и ще се подава на функцията. Обикновено се кръщава `solve`.
## Printing to the Console
**console.log()**

![](Pasted%20image%2020241019142356.png)

Изписване на конзолата, еквивалент на `Console.WriteLine();`
Може да ползваме конкатенация, както и интерполация. Интерполацията позволява да вмъкваме променливи директно в низове. В JavaScript за това използваме шаблонни низове, които се обозначават с **обратни кавички** (`` ` ``), и вмъкваме променливите с `${}`.
Метода `toFixed()` е като `F2` в C#, примерно `firstNumber.ToString("F2")`. Използва се за да форматира числото, без да му променя стойността. 
## Data Types and Variables
```js
let integerNumber = 10;
let decimalNumber = 3.14;
let negativeNumber = -10;
let maxPreciseNumber = Number.MAX_SAFE_INTEGER;
let maxDoublePrecisionNumber = Number.MAX_VALUE;
let notANumber = NaN;
let infinity = Infinity;

// String
let singleQuoteLiteral = 'Pesho';
let doubleQuoteLiteral = "Gosho";
let templateLiteral = `Stamat`;

// Undefined
let undf = undefined;

// Null
let empty = null;

// BigInt
let bigNumber = BigInt('9007199254740992');
let bigNumber2 = 9007199254740992n;

// Unisg const
const firstName = "Gerard";

// Block scope
if (true) {
    let schoolName = 'SoftUni'; // variable has block scope
}

// console.log(schoolName); Throws error not defined

// Outer block scope
if (true) {
    let outerVariable = 100;

    if (true) {
        let innerVariable = '200';
        console.log(outerVariable);
    }

    // console.log(innerVariable); // Throws error not defined
}

// Cast string to number
let intNumber = parseInt('1');
let floatNumber =  parseFloat('3.14');
let parsedNumber = Number('3.14')
let plusNumber = +'3.14';
console.log(intNumber);
console.log(floatNumber);
console.log(parsedNumber);
console.log(plusNumber);
console.log(typeof(plusNumber));

// NaN
console.log(Number('Pesho'));
```

Имаме два типа данни - примитивни (value types) и reference types / structure types.
### Primitive
Boolean, null undefined, number, String, Symbol, BigInt.
#### Number
Еквивалента на числовите типове в C# като double, decimal, long, int, short и тн. Работи с двойна точност подобно на double в повечето езици. Няма еквивалент на decimal.
#### BigInt
Ако ни трябва точен тип, но работи само с integers, няма дробни числа.
Може да декларираме BigInt по два начина:

```js
let bigNumber = BigInt('9007199254740992');
let bigNumber2 = 9007199254740992n;
```

Литерала завършва с `n`.
#### Boolean
Има само две стойности - true и false.
#### String
Имаме три начина за изписването на string:

```js
let singleQuoteLiteral = 'Pesho';
let doubleQuoteLiteral = "Gosho";
let templateLiteral = `Stamat`;
```

single quote се използва най-често, за да се разграничава от атрибутите в HTML. В JS няма char тип данни.
#### Literals
Литерала е начина по който изписваме стойността от даден тип, за да може интерпретатора да разбере от какъв тип е точно. По литерала разбира какъв е типа.
#### NaN (Not a Number)
Служебна стойност, която е от тип number, но показва че не е number. Примерно ако искаме да parse-нем стринг, който не е число, върната стойност ще бъде `NaN`.
#### Infinity
Много рядко се ползва и е по добре да се ползва `MAX_SAFE_INTEGER`. Може да имаме и negative - `-infinity`
### Reference Тypes
Включва, Objects, Functions и Arrays.
## Variable Scope
Имаме три начина чрез които може да декларираме променливи - `let`, `var` и `const`. 
`var` не се ползва вече, това е стария начин за деклариране.
`const` е променлива, която не може да сменя своята стойност.

Scope-a на `const` и `let` променливите е block и се дефинира от най-близките отварящи и затварящи къдрави скоби `{}`.  Променливата може да се достъпва само в рамките на тези скоби. 
При `var`, имаме function scope и може да се достъпва дори извън къдравите скоби. Това е една от причините да не ползваме var, защото не е добра практика.
### Casting numbers
Има 4 начина чрез които да cast-нем стринг в число видни горе в примера. Препоръчително е да ползваме `Number()`.
`parseFloat()` и `parseInt()` имат предимството, че ако string-a започва с число, то ще вземе числото и няма да върне `NaN`.
Примерно при `parseFloat('3test')`, ще върне числото 3.
## Arithmetic Operators
![](Pasted%20image%2020241019211442.png)

Трябва да се прави разлика между addition + и concatenation +, защото когато събираме число с друго число но тип стринг, тогава реално не се случва събиране но конкатенация - `console.log(5 + '10');` ще е равно на 510.
# Misc

# ChatGPT
## Node.js and VS Code
to effectively use JavaScript (JS) for development, you typically need both Node.js and Visual Studio Code (VS Code), and they serve different purposes:

1. **Node.js**:
    
    - **Purpose**: It's a runtime environment that allows you to run JavaScript on the server side. It enables you to use JavaScript for backend development, build command-line tools, and run JavaScript applications outside the browser.
    - **Usage**: You can run your JavaScript code directly in the terminal using Node.js, which is especially useful for developing applications like web servers, REST APIs, and more.
2. **Visual Studio Code (VS Code)**:
    
    - **Purpose**: It's a powerful code editor that supports multiple programming languages, including JavaScript. It provides features like syntax highlighting, debugging, version control integration, and a rich ecosystem of extensions.
    - **Usage**: You use VS Code to write, edit, and manage your JavaScript files. It also allows you to run your JavaScript code through an integrated terminal, making it easier to develop applications.

**How They Relate**

- **Development Environment**: Node.js serves as the runtime for executing your JavaScript code, while VS Code acts as the environment where you write and manage your code.
- **Integration**: You can run Node.js commands and scripts directly from the terminal in VS Code, allowing for a seamless development experience.

**Summary**

If you're planning to develop applications using JavaScript, having both Node.js and VS Code installed will give you a complete setup for both frontend and backend development.
## JavaScript VS C# Execution
**JS**

1. **Direct Execution**:
    
    - When you write JavaScript code, it is often executed directly by the JavaScript engine (like V8 in Node.js or browser engines).
    - There is no intermediary step to create a separate executable file; the code is read and executed line by line.
2. **Just-In-Time (JIT) Compilation**:
    
    - While JS is interpreted, modern JavaScript engines use a technique called Just-In-Time (JIT) compilation. This means that parts of the code are compiled to machine language at runtime, improving performance.
    - The engine optimizes the code during execution, translating it into machine language as needed, allowing for faster execution without the need for a separate compilation step beforehand.
3. **Dynamic Nature**:
    
    - JavaScript is dynamically typed and can be modified at runtime, allowing for more flexibility but also introducing potential runtime errors.

**C#**

1. **Compilation to Intermediate Language (IL)**:
    
    - In C#, you write code in a `.cs` file, which is then compiled into an Intermediate Language (IL) using a compiler (like Roslyn).
    - This IL code is not directly machine code; it's a platform-agnostic binary that requires further execution by the Common Language Runtime (CLR).
2. **Execution via CLR**:
    
    - The CLR takes the IL code and translates it into machine language just before it runs, using a process similar to JIT compilation.
    - The CLR manages memory, provides type safety, and handles exceptions, which are additional layers of abstraction that JavaScript does not have in the same way.
3. **Static Typing**:
    
    - C# is statically typed, meaning types are checked at compile time. This can prevent certain types of runtime errors and helps optimize the generated machine code.

**Summary**

- **JavaScript**: The source code is executed directly by an interpreter (the JavaScript engine) with parts being compiled to machine code at runtime. This leads to more flexibility and rapid development but can also result in performance variability.
    
- **C#**: The source code is compiled into IL, which is then executed by the CLR, providing additional features like type safety and memory management.
    

In essence, JavaScript can be seen as being more immediate and dynamic, while C# provides a structured, compiled approach with additional runtime safeguards and optimizations.

**You said:**

The downside is that we don't have compile errors and thus its more error prone

**ChatGPT said:**

Absolutely, you've captured one of the key downsides of using JavaScript compared to statically typed languages like C#. Here are some points to elaborate on this:

**Downsides of JavaScript's Dynamic Nature**

1. **Runtime Errors**:
    
    - In JavaScript, type checking is done at runtime. This means that errors related to types (like trying to call a method on `undefined` or using the wrong data type) will only show up when that piece of code is executed, which can lead to unexpected crashes or bugs in production.
2. **Less Predictability**:
    
    - Because types are determined at runtime, the behavior of the code can be less predictable. For example, a variable can change types during execution, leading to bugs that are often hard to trace.
3. **Limited IDE Support**:
    
    - While modern IDEs (like Visual Studio Code) have great support for JavaScript, they can’t always catch all errors before you run the code. They rely on features like type inference or static analysis, which may not cover all cases.
4. **Debugging Complexity**:
    
    - Debugging can be more complex in JavaScript because you might not catch certain errors until a specific code path is executed. This can lead to lengthy debugging sessions, especially in larger codebases.

**Advantages of C# and Similar Languages**

1. **Compile-Time Errors**:
    
    - In C#, type checking and other validations happen at compile time. This allows many errors to be caught early in the development process, before the code is run.
2. **IDE Features**:
    
    - Tools like Visual Studio offer extensive IntelliSense support, making it easier to catch errors as you write code. The IDE can provide better autocompletion, suggestions, and refactoring options due to the statically typed nature of the language.
3. **Predictable Behavior**:
    
    - Because types are explicitly declared, the behavior of C# code is generally more predictable. This can lead to fewer surprises during execution.
4. **Easier Refactoring**:
    
    - Refactoring is often safer and more manageable in statically typed languages, as the compiler can help identify where changes may affect the codebase.

**Conclusion**

While JavaScript offers flexibility and rapid development, it comes at the cost of increased potential for runtime errors. Developers often adopt practices such as unit testing, using TypeScript (a superset of JavaScript that adds static typing), or employing linters to catch errors early in the development cycle. These strategies can help mitigate some of the downsides of JavaScript's dynamic nature, making it more robust for larger applications.

**You said:**

So we may have an error in some particular place in the code, but because we have not used it, it will be undetected until it is used at some point, where with compiling the file first, the error would be detected before the file is compiled.

**ChatGPT said:**

Exactly! You’ve summarized it perfectly. Here’s a more detailed breakdown of this concept:

**Error Detection in JavaScript vs. C#**

1. **JavaScript (Dynamic Typing)**:
    
    - **Runtime Errors**: In JavaScript, errors often manifest only when a specific piece of code is executed. For example, if you have a function that expects a string but receives `undefined`, the error won’t occur until that function is actually called with the invalid argument.
    - **Testing is Crucial**: This means extensive testing is necessary to ensure that all code paths are exercised. If a particular section of the code is never tested, any potential errors in that section remain undetected until that code is invoked in a live environment.
    - **Common Scenario**: For instance, if you have a function that manipulates user input and you don't test it with invalid input, you might not realize there’s a flaw until users encounter it in production.
2. **C# (Static Typing)**:
    
    - **Compile-Time Errors**: In C#, the compiler checks for type errors, syntax errors, and other issues before the code runs. If you try to assign a string to an integer variable, for example, the compiler will catch this error at compile time and prevent the program from being built until it’s fixed.
    - **Immediate Feedback**: This allows developers to receive immediate feedback on their code, which can significantly reduce the number of runtime errors. They can fix issues as they write the code, rather than discovering them later during execution.
    - **Common Scenario**: For example, if a C# function expects an integer and you pass a string, the compiler will raise an error before you even attempt to run the program, making it easier to catch mistakes early.

**Conclusion**

The distinction between compile-time and runtime error detection is fundamental to how JavaScript and C# operate. JavaScript's flexibility allows for quick development and iteration, but it requires careful testing to catch errors. In contrast, C#'s static typing provides a safety net that can lead to more reliable code by catching errors before the program runs.

Developers often use testing frameworks, type checking (like TypeScript), and best practices in JavaScript to mitigate these risks, making it more manageable and robust over time.
## JS Engines
The version of the JavaScript engine (which compiles and executes JavaScript code) can depend on the browser or environment hosting it. Here's how it breaks down in relation to Roslyn:

**JavaScript Engines and Browsers**

1. **JavaScript Engines**:
    - Each browser has its own JavaScript engine that determines which features and ECMAScript versions are supported. For example:
        - **V8** in Google Chrome and Node.js
        - **SpiderMonkey** in Mozilla Firefox
        - **JavaScriptCore** in Safari
        - **Chakra** (previously used in Microsoft Edge, now replaced by V8)
2. **Browser Versions**:
    - Different versions of browsers may implement various features of the ECMAScript specification. For example, a newer version of Chrome may support the latest JavaScript features (like optional chaining or nullish coalescing), while an older version of Firefox might not.

**Comparison with Roslyn**

- **Roslyn Compiler**:
    - The Roslyn compiler for C# allows you to use specific language features based on its version, independent of the .NET Framework version being used (to some extent). For example, newer versions of C# may introduce features that require a compatible Roslyn compiler, but the .NET Framework can maintain backward compatibility with older C# code.
- **JavaScript Engines**:
    - Similarly, JavaScript engines interpret and execute code based on their version and the JavaScript features they support. For example, if you're using features from ECMAScript 2020 in your JavaScript code, the engine (or the browser) must support those features for the code to execute properly.

 **Summary**

- The **JavaScript engine version** can be influenced by the browser or environment in which it runs, just as the **Roslyn compiler version** dictates the C# features you can use.
- Both systems aim to provide the necessary tooling and runtime support for their respective languages, but the JavaScript ecosystem is more fragmented due to the variety of engines and browser implementations.

So, in essence, the JavaScript engine serves a similar role to the Roslyn compiler, but the support for features can vary based on the browser or environment rather than being tied to a single framework version like .NET.

**You said:**

When we install VS Code, we have access to the JS engine after installing the node.js?

**ChatGPT said:**

Yes, that's correct! When you install **Visual Studio Code** and then install **Node.js**, you gain access to the JavaScript engine (specifically, the V8 engine that Node.js is built on) directly from within the VS Code environment.

**Accessing the JavaScript Engine in VS Code**

- **Integrated Terminal**:
- In VS Code, you can open the integrated terminal (using `Ctrl + J` or through the menu) and run JavaScript files using Node.js by executing commands like:

```bash
node filename.js
```

- This allows you to execute JavaScript code written in your files directly within the terminal.
- **Development**:

    - You can create JavaScript files in VS Code, write your code, and run it using Node.js, which leverages the V8 engine to execute the code.
- **Real-Time Feedback**:

    - You can also use debugging features in VS Code to set breakpoints and inspect your JavaScript code as it runs, providing a comprehensive development experience.

**Summary**

Installing Node.js gives you access to the JavaScript engine, enabling you to run and develop JavaScript applications within Visual Studio Code seamlessly. This setup is particularly useful for server-side JavaScript development and allows you to utilize the rich ecosystem of Node.js packages and frameworks.

# Bookmarks 
[ECMA-262 - Ecma International](https://ecma-international.org/publications-and-standards/standards/ecma-262/)

[Node.js — Download Node.js®](https://nodejs.org/en/download/prebuilt-installer)
