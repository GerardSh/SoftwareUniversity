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
## Functions and Input Parameters
За JS не е естествено да се чете през конзолата, понеже няма как да стане в browser-a, затова JS начина е да се направи функция, която 
ще приема input-a като параметър и ще се подава на функцията. Обикновено се кръщава `solve`.
## Printing to the Console
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241019142356.png)

**console.log()**
Изписване на конзолата, еквивалент на `Console.WriteLine();`
Може да ползваме конкатенация, както и интерполация. Интерполацията позволява да вмъкваме променливи директно в низове. В JavaScript за това използваме шаблонни низове, които се обозначават с **обратни кавички** (`` ` ``), и вмъкваме променливите с `${}`.
Метода `.toFixed(n)` е като `F2` в C#, примерно `firstNumber.ToString("F2")`. Използва се за да форматира числото, без да му променя стойността. 
## Data Types and Variables
```javascript
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
Boolean, null, undefined, number, String, Symbol, BigInt.
#### Number
Еквивалента на числовите типове в C# като double, decimal, long, int, short и тн. Работи с двойна точност подобно на double в повечето езици. Няма еквивалент на decimal.
#### BigInt
Ако ни трябва точен тип, но работи само с integers, няма дробни числа.
Може да декларираме BigInt по два начина:

```javascript
let bigNumber = BigInt('9007199254740992');
let bigNumber2 = 9007199254740992n;
```

Литерала завършва с `n`.
#### Boolean
Има само две стойности - true и false.
#### String
Имаме три начина за изписването на string:

```javascript
let singleQuoteLiteral = 'Pesho';
let doubleQuoteLiteral = "Gosho";
let templateLiteral = `Stamat`;
```

single quote се използва най-често, за да се разграничава от атрибутите в HTML. В JS няма char тип данни.
#### Undefined
Ако декларираме променлива, без да я инициализираме, то стойността на тази променлива е `undefined`. Типа на променливата, също е `undefined`.
#### Null
Тази стойност, не се слага автоматично, трябва ние ръчно да я сложим. Разликата с `undefined` е, че когато сложим `null` ние показваме, че имаме някаква идея, докато `undefined` е недефинирана променлива. Ползвайки `null`, отбелязваме намерение да сложим някаква стойност по някое време.
При сравнение:

```javascript
console.log(null == undefined);  //true
console.log(null !== undefined); //true
console.log(null === undefined); //false
console.log(null != undefined);  //false
```
#### Literals
Литерала е начина по който изписваме стойността от даден тип, за да може интерпретатора да разбере от какъв тип е точно. По литерала разбира какъв е типа.
#### NaN (Not a Number)
Служебна стойност, която е от тип number, но показва че не е number. Примерно ако искаме да parse-нем стринг, който не е число, върната стойност ще бъде `NaN`.
#### Infinity
Много рядко се ползва и е по добре да се ползва `MAX_SAFE_INTEGER`. Може да имаме и negative - `-infinity`
### Reference Тypes
Включва, Objects, Functions и Arrays.
## JavaScript Syntax
Дефиниране на променливи чрез `let` примерно `let age = 18;` което буквално означава - нека променливата `age` да е равна на 18.
Променливите не се интересуват от типа данни, който ще бъде записан в тях. Това е все едно да имаме един вид буркани и в него слагаме каквото си искаме, докато в C# имаме буркан за всяко нещо, което искаме да сложим. Променливата не се интересува от типа който ще бъде запаметен от нея, а типа си го носи единствено самата стойност

```javascript
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

Имаме още два начина чрез които може да декларираме променливи - `var` и `const`. 
`var` не се ползва вече, това е стария начин за деклариране.
`const` е променлива, която не може да сменя своята стойност.
## Variable Scope
Scope-a на `const` и `let` променливите е block и се дефинира от най-близките отварящи и затварящи къдрави скоби `{}`.  Променливата може да се достъпва само в рамките на тези скоби. 
При `var`, имаме function scope и може да се достъпва дори извън къдравите скоби. Това е една от причините да не ползваме var, защото не е добра практика.
### Casting numbers
Има 4 начина чрез които да cast-нем стринг в число видни горе в примера. Препоръчително е да ползваме `Number()`.
`parseFloat()` и `parseInt()` имат предимството, че ако string-a започва с число, то ще вземе числото и няма да върне `NaN`.
Примерно при `parseFloat('3test')`, ще върне числото 3.
## Operators
### Arithmetic
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241019211442.png)

Трябва да се прави разлика между addition + и concatenation +, защото когато събираме число с друго число но тип стринг, тогава реално не се случва събиране но конкатенация - `console.log(5 + '10');` ще е равно на 510

В JS делението между две числа, дори и да са цели (integers), винаги ще връща дробно число, ако резултатът не е цяло число - 9 / 2 = 4.5
Това се различава от поведението в C#, където делението между цели числа връща цяло число - 9 / 2 = 4
В JS, за целочислено деление трябва да се използват допълнителни методи, ако искаме да закръглим резултата до цяло число, например с `Math.floor()`, `Math.ceil()` или `Math.trunc()`.

Модулното деление работи както е в C# - 9 % 2 = 1

Exponentiation e оператор за степенуване  - 10 ** 2 = 100
В C# степенуването обикновено се прави с помощта на метода `Math.Pow`.
### Comparison
Имаме unary оператори имаме само един операнд - `!`, `typeof`, `++`, `--`
При binary операторите имаме два операнда - `+`, `-`, `*`, `/`, `==`, `===`
При ternary оператора имаме три операнда.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241020130427.png)

`==` equality - equality with coercion. Aко сравняваме 1 == '1' резултата ще е true, заради coercion. Coercion е способността на JS да обърне един тип в друг тип - примерно когато сравняваме number и string, JS ги приравнява в един и същи тип и тогава ги сравнява.
`===` identity - equality without coercion. Това забранява на JS да променя типовете и затова  1 == '1'  връща false.
`!=` inequality - inequality with coercion. Връща true, ако стойностите са различни, като coercion е разрешен.
`!==` inequality - strict inequality without coercion. Връща true, ако стойностите са различни, като coercion не е разрешен.
`Ternary` - това е все едно if statement - ако израза в ляво връща true, върни числото от ляво на `:` ако е false от дясно.
### Logical
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020241020145928.png)

В JSи C# операторът NOT (`!`) работи по един и същи начин — променя стойността от true на false и обратно.
В JS имаме - **Двоен оператор NOT (`!!`)**:
- Използва се за явна конверсия на всяка стойност в булева стойност.
- Първият `!` преобразува стойността в `true` или `false`, а вторият `!` я обръща отново.
- Често се използва за проверка на наличието на стойности и за уверяване, че функцията връща булева стойност.

```javascript
console.log(!!1);          // true
console.log(!!0);          // false
console.log(!!"hello");    // true
console.log(!!null);       // false
```

Важно правило е че comparison операторите, имат по-голям приоритет от logical операторите. Когато имаме израз, първо се изпълняват те и тогава логическите. Например, в израза `5 > 3 || 4 < 2` операторите за сравнение `5 > 3` и `4 < 2` ще се изчислят първо, след което резултатът от тях ще бъде обработен от логическия оператор `||`. Аритметичните оператори са с по-голям приоритет от comparison операторите. Скобите са с най-голям приоритет.
### Typeof
Връща типа на всичките променливи или стойности. При примитивни типове, ще получим съответния тип. Когато `typeof` се използва с референтни типове, като обекти или масиви, ще върне `"object"`:

- `typeof {}` ще върне `"object"`
- `typeof []` ще върне `"object"` - може да ползваме  - `Array.isArray()`
- `typeof function() {}` ще върне `"function"` (функциите са специален вид обекти)
### Incremental
- **Оператори**: И двата езика използват increment (`++`) и decrement (`--`) оператори в prefix и postfix форма, с еднакво поведение при увеличаване или намаляване на стойността.
- **Postfix (`x++`, `x--`)**: Връща оригиналната стойност преди increment/decrement.
- **Prefix (`++x`, `--x`)**: Връща новата стойност след increment/decrement.

**Основни Разлики:**

1. **Типова Система**:
    - **JavaScript**: Динамичната типизация позволява операции с различни типове с имплицитна типова конверсия.
    - **C#**: Статичната типизация налага типова безопасност, което води до грешки при компилация за неточни типове.
2. **Имплицитна Типова Конверсия**:
    - **JavaScript**: Може да increment/decrement string-ове, които представляват числа (например, `"5"` става `6`).
    - **C#**: Показва грешка при компилация, ако опитаме incrementing/decrementing нечислени типове.

В обобщение, въпреки че increment и decrement операторите функционират по подобен начин в двата езика, разликите произтичат основно от динамичната типизация и имплицитната типова конверсия в JavaScript в контекста на статичната типизация в C#.
## Conditional Statement
if-else конструкциите в JS работят почти идентично на тези в C#. Единствената основна разлика е в стила на поставяне на къдравите скоби, който е малко по-свободен в JS.

```javascript
let a = 5;

if (a > 5) {
    console.log(1);
} else if (a == 5) {
    console.log(2);
} else {
    console.log(3);
}
```
## Switch-case Statement
Switch-case конструкцията също е много подобна на C#, като основната логика е същата.

```javascript
switch (color) {
    case 'red':
        console.log(1);
        break;
    case 'blue':
        console.log(2);
        break;
    default:
        console.log(0);
        break;
}
```

Ако няма `break` след даден `case`, изпълнението ще продължи и следващите блокове също ще се изпълнят, дори ако те не съответстват на условието. Това явление се нарича "fall-through" и се среща само в езиците като JavaScript (в C# fall-through не е позволен).
## Truthy and Falsy Values
Всички съществуващи стойности, може да се разделят на две групи - truthy и falsy. Всяка стойност може да се преобразува в true или false. 
Един начин да обърнем към boolean дадена стойност е примерно с вградената функция - `Boolean('Pesho');
Друг начин е с двоен not оператор - `!!'Pesho`, защото ако е само един `!` ще върне обратната стойност, затова трябва да са два `!!`.

Falsy стойности:
- `false`
- `0` (нулата)
- `-0` (отрицателната нула)
- `0n` (нулев BigInt)
- `""` (празен стринг)
- `null`
- `undefined`
- `NaN` (Not-a-Number)

Truthy стойности:
Всички останали стойности, които не са falsy, се интерпретират като `true`. Примери включват:
- Ненулеви числа (например `1`, `-1`, `3.14`)
- Ненулеви BigInt числа
- Непразни стрингове (например `'Pesho'`, `' '`)
- Обекти и масиви (дори празни) (например `{}`, `[]`)

В JS се ползва много тази концепция, защото спестява код:

```javascript
let firstName = 'Pesho';

if (firstName != null) {
    // Do something..
}

// Less code using Truthy and Falsy

if (!!firstName) {
    // Do something..
}
```

В JS операторите `&&` (логическо "и") и `||` (логическо "или") могат да се използват не само за логически операции, но и за контролиране на стойности, което също спомага за спестяване на код.

**Оператор `&&` (логическо "и")**

Когато използваме `&&`, той връща последната стойност, ако всички стойности преди него са истинни (truthy). Ако някоя от стойностите е falsy, връща първата falsy стойност.

```javascript
let a = true;
let b = true;
let c = false;

let result = a && b; // Връща true, защото и двете са true
console.log(result); // true

let result2 = a && c; // Връща false, защото c е false
console.log(result2); // false
```

В контекста на проверка:

```javascript
let firstName = 'Pesho';
let lastName = 'Ivanov';

let fullName = firstName && lastName; // Връща 'Ivanov', защото firstName е истинно
console.log(fullName); // 'Ivanov'
```

**Оператор `||` (логическо "или")**

Когато използваме `||`, той връща първата истинна стойност (truthy), или последната стойност, ако всички са falsy.

```javascript
let a = false;
let b = true;

let result = a || b; // Връща true, защото b е true
console.log(result); // true

let result2 = a || false; // Връща false, защото и двете са falsy
console.log(result2); // false
```

В контекста на проверка:

```javascript
let firstName = '';
let lastName = 'Ivanov';

let fullName = firstName || lastName; // Връща 'Ivanov', защото firstName е празен (falsy)
console.log(fullName); // 'Ivanov'
```

**Заключение**

Тази концепция за `&&` и `||` е много полезна в JavaScript, тъй като ни позволява да контролираме стойности и да пишем по-компактни условия. Вместо да пишем дълги if-else конструкции, можем да използваме тези оператори, за да постигнем същия ефект с по-малко код.
## Loops
Работят по същия начин като в C#, с разликата, че вместо типовете като **int** се използва **let** или **var** за деклариране на променливи:

```javascript
for (let i = 0; i < 5; i++) {
    console.log(i);
}

let i = 5;

while (i >= 0) {
    console.log(i--);
}

i = 5;

do {
    console.log(i--);
}
while (i >= 0) 
```
## Debugging Techniques
- **Breakpoints**:
    - Breakpoints се поставят на конкретни редове в кода и когато дебъгерът достигне този ред, изпълнението спира. Това позволява да инспектираме състоянието на програмата по време на изпълнение.
    - **`F5`**: Стартира процеса на дебъгване. Ако имаме breakpoints, програмата ще спре на първия такъв.
    - **`F10` (Step Over)**: Изпълнява следващия ред код без да навлиза в подфункции. Полезно е, когато искаме да избегнем навлизането в детайлите на всяка функция.
- **Call Stack**:
    - **Call Stack** показва списък с функции, които са били извикани до този момент. Това ни дава възможност да следим как сме стигнали до текущия момент в кода. Ако сме в дълбока вложена функция, можем да проследим предишните извиквания и да видим как сме попаднали там.
- **Watch**:
    - В панела **Watch** можем да добавим променливи или изрази, които да следим. Това е полезно за проследяване на стойности по време на изпълнение на програмата, без да се налага да спираме на breakpoint на всеки ред.
- **Local и Global контексти**:
    
    - **Local**: Показва всички променливи и стойности, които са видими в текущия контекст (функцията или блока, в който се намираме).
    - **Global**: Показва глобалните променливи, които са достъпни във всяка част на програмата.
- **Step Into/Step Over/Step Out**:
    
    - **`F11` (Step Into)**: Влиза вътре във функцията, която се извиква на текущия ред.
    - **`Shift + F11` (Step Out)**: Излиза от текущата функция и се връща на мястото, откъдето е извикана.
    - **`F10` (Step Over)**: Продължава изпълнението на следващия ред, без да влиза вътре в функцията, ако текущият ред съдържа извикване на функция.
- **Debugger Statement**:
    
    - Когато поставим `debugger;` в кода, това работи като ръчно зададен breakpoint. Когато дебъгърът стигне до този ред, изпълнението ще спре, също както при стандартен breakpoint.
- **Reload Debugger**:
    
    - В някои дебъгери (например в браузърите и в VS Code) има възможност да рестартираме процеса на дебъгване и да презаредим кода, без да затваряме дебъгъра. Това е полезно, ако искаме да започнем отначало, след като сме направили промени в кода.
- **Ctrl + F5**: Стартира програмата без дебъгване, което означава, че тя ще се изпълни директно, без да спира на breakpoints.
### Strict Mode
Активира се с добавяне на `'use strict';` в началото на скрипта или в началото на функция.
Почти не се ползва. По стриктен е от обикновения интерпретатор и ни пази от някои грешки, като например директно да добавим стойност на променлива, без да я декларираме - `test = 5;`. Ако сме активирали strict mode, ще върне грешка, иначе ще работи, но не е препоръчително.
# Misc

# ChatGPT
## Node.js and VS Code
To effectively use JavaScript (JS) for development, you typically need both Node.js and Visual Studio Code (VS Code), and they serve different purposes:

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
## String Type
In JavaScript, **strings** are indeed considered **primitive types**, while in C#, **strings** are **reference types**, but both are **immutable**.

**Key Differences:**

- **JavaScript**:

    - **Primitive Type**: A string in JavaScript is a primitive type, meaning it’s a basic data type and is immutable (cannot be changed after creation).
    - Despite being a primitive type, JavaScript allows string objects to have methods (e.g., `.length`, `.toUpperCase()`) thanks to **autoboxing**—JavaScript temporarily treats the string as an object to use methods.
- **C#**:

    - **Reference Type**: In C#, strings are reference types, stored on the heap, and also immutable. Even though strings are reference types, they behave somewhat like value types in that when you modify a string, a new instance is created, and the original is not altered.

**Summary:**

- In **JavaScript**, strings are **primitive** types but have object-like behavior due to autoboxing.
- In **C#**, strings are **reference types** but are **immutable**—once a string is created, its content cannot be changed directly.
## Stack / Heap
In JavaScript, whether a **string** (or any variable) is stored in the **stack** or the **heap** depends on its type and the context in which it is used. Here's how it works:

1. **Primitive Types (including strings)**:

- **Primitive values** like strings, numbers, booleans, `null`, `undefined`, and `symbol` are generally stored **in the stack**. These are simple, immutable values that have a fixed size, which makes them suitable for stack storage.
- When you declare a string, the **reference** to the value is stored in the stack. If the string is small and primitive, the **value** itself is often stored on the stack.

2. **Reference Types**:

- **Objects**, **arrays**, and **functions** in JavaScript are stored in the **heap**, because they can grow in size and require dynamic memory allocation.
- For reference types, the **reference** (or pointer) to the object is stored on the stack, while the actual data is stored in the heap.

3. **String Storage Specifics**:

- While strings are **primitive types** in JavaScript and their reference is typically stored on the stack, if a string is too large, the JavaScript engine might store it in the **heap** and store a reference (or pointer) to the string in the stack.
- JavaScript engines (like V8) are highly optimized, so they may move strings between the stack and heap based on the size and usage to optimize performance.

**In Summary:**

- **Small strings** (as primitive values) are typically stored **on the stack**.
- **Larger strings** may have their data stored in the **heap**, with a reference to the string stored in the stack.

In contrast, **in C#**, since strings are reference types, they are always stored on the heap, but a reference (pointer) to the string is stored on the stack.
## Functions - Methods Difference
In JavaScript, the terms **function** and **method** are often used interchangeably, but they have distinct meanings based on context. Here’s a breakdown of the differences along with examples:

**Function**

A **function** is a standalone block of code designed to perform a particular task. It can be defined globally or within another function, and it does not belong to any object.

**Example of a Function:**

```javascript
// Function declaration
function greet(name) {
    return `Hello, ${name}!`;
}

// Function call
console.log(greet('Alice')); // Output: Hello, Alice!
```

**Method**

A **method** is a function that is associated with an object. In JavaScript, when a function is a property of an object, it is referred to as a method. Methods are called on objects, and they can access and modify the object's properties.

**Example of a Method:**

```javascript
// Object with a method
const person = {
    name: 'Bob',
    greet: function() {
        return `Hello, ${this.name}!`;
    }
};

// Method call
console.log(person.greet()); // Output: Hello, Bob!
```

**Key Differences**

1. **Context**:
    
    - A **function** can be defined independently and called anywhere in the code.
    - A **method** is defined as part of an object and is called on that object.
2. **Binding**:
    
    - A **function** does not have an implicit reference to an object.
    - A **method** has access to the object it belongs to via the `this` keyword, allowing it to access and manipulate the object’s properties.
3. **Use Cases**:
    
    - Functions are used for reusable blocks of code that can perform specific tasks.
    - Methods are used to define behaviors for objects, encapsulating functionality related to that object.

**Summary**

- Use a **function** when you need a reusable code block that doesn’t rely on any particular object.
- Use a **method** when you want a function that operates on the properties of a specific object.

**You said:**

In correlation to C# a JS method is like when we have instance of an class in C#, which have instanced methods, while JS function is like the static methods in a class in C#?

**ChatGPT said:**

Yes, you can think of it that way in the context of C#. Here’s how the analogy works between JavaScript and C#:

**JavaScript:**

- **Function**: A standalone block of code that can be defined globally or within another function. It is not tied to any object.
- **Method**: A function that is a property of an object. Methods are often used in conjunction with object instances, allowing access to the object's properties through the `this` keyword.

**C#:**

- **Static Method**: A method that belongs to the class itself rather than an instance of the class. It can be called without creating an instance of the class.
- **Instance Method**: A method that belongs to an instance of a class. It can access instance variables and other instance methods within the same class.

**Example Comparison:**

**JavaScript Example:**

```javascript
// Function (similar to a static method in C#)
function staticFunction() {
    return "This is a static function.";
}

// Method (similar to an instance method in C#)
const obj = {
    instanceMethod: function() {
        return "This is an instance method.";
    }
};

// Calling the function and the method
console.log(staticFunction());  // Output: This is a static function.
console.log(obj.instanceMethod()); // Output: This is an instance method.
```

**C# Example:**

```csharp
public class MyClass
{
    // Static method
    public static string StaticMethod()
    {
        return "This is a static method.";
    }

    // Instance method
    public string InstanceMethod()
    {
        return "This is an instance method.";
    }
}

// Usage
class Program
{
    static void Main(string[] args)
    {
        // Calling the static method
        Console.WriteLine(MyClass.StaticMethod()); // Output: This is a static method.

        // Creating an instance to call the instance method
        MyClass myClassInstance = new MyClass();
        Console.WriteLine(myClassInstance.InstanceMethod()); // Output: This is an instance method.
    }
}
```

**Summary of the Analogy:**

- **JavaScript Functions** are akin to **C# Static Methods** because they are not tied to any object instance and can be called directly.
- **JavaScript Methods** are akin to **C# Instance Methods** because they are functions that operate on instances of objects and can access instance-specific properties and behaviors.

This analogy helps clarify how functions and methods operate in both languages, emphasizing their relationship to objects and classes.

**You said:**

However even static methods are part of a class in C# where in JS they are not part of any class?

**ChatGPT said:**

You're correct! While both static methods in C# and functions in JavaScript can be called without instantiating an object, they have different relationships to classes or objects. Let’s break this down further:

**C# Static Methods:**

- **Part of a Class**: Static methods are defined within a class and are associated with that class. They can be called using the class name without needing to create an instance of the class.
- **Access to Static Members**: Static methods can only access static members (fields, properties, methods) of the class. They cannot access instance members directly.

**JavaScript Functions:**

- **Not Necessarily Part of a Class**: JavaScript functions can exist independently of any object or class. They can be declared in the global scope or inside other functions, but they don't need to be part of a class.
- **Function as First-Class Citizens**: Functions in JavaScript are first-class citizens, meaning they can be assigned to variables, passed as arguments, and returned from other functions.

**Summary of the Key Differences:**

1. **Class Association**:
    
    - **C# Static Methods**: Always part of a class.
    - **JavaScript Functions**: Can exist independently without being part of a class or object.
2. **Call Syntax**:
    
    - **C# Static Methods**: Called using the class name.
    - **JavaScript Functions**: Called by their name if in scope, regardless of class or object association.
3. **Context**:
    
    - **C# Static Methods**: Can only access static data and methods of the class.
    - **JavaScript Functions**: Can access variables in their own scope and the global scope but do not have an inherent association with instance properties unless defined as methods within an object.

**Conclusion:**

While the concept of static methods in C# and standalone functions in JavaScript may appear similar because they both can be called without an instance, the key distinction lies in their association with classes and how they are utilized within their respective languages.

**You said:**

So functions in JS have the same height in hierarchy as classes, delegates, enums and etc. which are top level data types?

**ChatGPT said:**

Yes, that's a good way to conceptualize it! In terms of **hierarchical importance** and **data type categorization**, functions in JavaScript can indeed be viewed as being on the same level as classes, delegates, and enums in C#. Here's a clearer breakdown of this hierarchy and relationship:

**Hierarchical Comparison**

1. **JavaScript**:
    
    - **Functions**:
        - First-class citizens that can be assigned to variables, passed as arguments, and returned from other functions. They are a fundamental building block of JavaScript and essential for defining behavior.
    - **Objects**:
        - Functions are objects in JavaScript, and they can have properties and methods. This means they can be treated like other top-level data types.
    - **Classes (ES6)**:
        - In JavaScript, classes are syntactical sugar over functions and prototypes. They provide a way to create objects and define methods, but they are fundamentally built on the concept of functions.
2. **C#**:
    
    - **Classes**:
        - Fundamental constructs for object-oriented programming, allowing for the creation of objects, methods, and properties.
    - **Delegates**:
        - Type-safe function pointers that allow methods to be treated as first-class citizens, enabling callback functionality.
    - **Enums**:
        - Special types that define a set of named constants, providing a way to work with a group of related values.

**Summary of Hierarchy:**

In both languages, you can consider the following as top-level data types:

- **JavaScript**:
    - Functions
    - Objects (including instances of classes)
    - Classes (ES6 syntax)
- **C#**:
    - Classes
    - Delegates
    - Enums

**Conceptual Parity:**

- **Functions in JavaScript** are comparable to **classes, delegates, and enums in C#** in that they serve as core building blocks for structuring programs.
- They provide a way to encapsulate behavior, just as classes encapsulate state and behavior, delegates encapsulate method references, and enums encapsulate named constants.

**Conclusion:**

So, your understanding that **functions in JavaScript hold the same hierarchical significance as classes, delegates, and enums in C#** is correct. They are all essential constructs that facilitate different programming paradigms within their respective languages. Functions in JavaScript, due to their first-class nature, play a particularly central role, much like classes do in C#.

**You said:**

functions in JS are most similar to delegates in C#?

**ChatGPT said:**

Yes, that's a valid observation! Functions in JavaScript are indeed most similar to **delegates** in C# in terms of their behavior and usage. Here's a detailed comparison to highlight the similarities and some distinctions:

**Similarities Between JavaScript Functions and C# Delegates**

1. **First-Class Citizens**:
    
    - **JavaScript Functions**: Functions can be assigned to variables, passed as arguments to other functions, returned from functions, and stored in data structures. This flexibility allows them to be treated like any other value.
    - **C# Delegates**: Delegates are also first-class entities. They are types that define references to methods with a particular parameter list and return type, allowing methods to be passed around as parameters.
2. **Encapsulation of Behavior**:
    
    - **JavaScript Functions**: Functions can encapsulate behavior, allowing you to define what actions to perform when called.
    - **C# Delegates**: Delegates encapsulate references to methods, enabling you to define a method signature and invoke methods indirectly.
3. **Use in Callbacks**:
    
    - Both JavaScript functions and C# delegates are commonly used for callback mechanisms. For instance, when an asynchronous operation completes, a function or delegate can be called to handle the result.

**Example Comparison**

**JavaScript Function Example:**

```javascript
// JavaScript function as a callback
function sayHello(name) {
    return `Hello, ${name}!`;
}

// Higher-order function that takes another function as an argument
function greet(callback, name) {
    return callback(name);
}

// Using the function as a delegate
console.log(greet(sayHello, 'Alice')); // Output: Hello, Alice!
```

**C# Delegate Example:**

```csharp
using System;

// Delegate definition
public delegate string GreetDelegate(string name);

public class Program
{
    // Method that matches the delegate signature
    public static string SayHello(string name)
    {
        return $"Hello, {name}!";
    }

    // Higher-order method that takes a delegate as an argument
    public static string Greet(GreetDelegate greetMethod, string name)
    {
        return greetMethod(name);
    }

    public static void Main(string[] args)
    {
        // Using the delegate
        GreetDelegate greetDelegate = new GreetDelegate(SayHello);
        Console.WriteLine(Greet(greetDelegate, "Alice")); // Output: Hello, Alice!
    }
}
```

**Key Points:**

- **Syntax and Structure**: While the syntax and underlying structure differ (functions in JavaScript vs. delegates in C#), the conceptual use cases are quite similar.
- **Flexibility**: Both provide flexibility in how behaviors are defined and invoked, allowing for clean, modular code.
- **Event Handling**: Delegates in C# are commonly used in event handling, similar to how functions are used in JavaScript for event listeners.

**Conclusion:**

Functions in JavaScript and delegates in C# share significant similarities, particularly in how they encapsulate behavior and are used as first-class entities. This comparison highlights how both languages allow for flexible and modular coding practices through these constructs.
## String and Number Operations
In JavaScript, the behavior of arithmetic operations with strings and numbers varies depending on the operator used:

1. **Addition (`+`)**:
    
    - If **both operands are numbers**, it performs **regular addition**.
    - If **one operand is a string**, the `+` operator performs **string concatenation**.
    - Example:
        
```javascript
'5' + 2  // Output: '52' (concatenation)
5 + 2    // Output: 7 (addition)
```
        
2. **Other Operators (`*`, `/`, `-`)**:
    
    - These operators attempt to **coerce** a string into a number when used with a string.
    - If the string can be converted to a number, the operation is performed.
    - If the string cannot be converted, the result is `NaN` (Not-a-Number).
    - Example:
        
```javascript
'5' * 2  // Output: 10 (multiplication)
'abc' - 2  // Output: NaN (invalid string-to-number conversion)
```

Key Points:

- **Addition (`+`)**: Performs **concatenation** if any operand is a string.
- **Other operators**: Always attempt to convert strings into numbers; if conversion fails, they return `NaN`.
# Bookmarks 
[ECMA-262 - Ecma International](https://ecma-international.org/publications-and-standards/standards/ecma-262/)

[Node.js — Download Node.js®](https://nodejs.org/en/download/prebuilt-installer)

Completion: 20.10.2024