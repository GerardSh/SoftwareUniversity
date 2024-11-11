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
## Expression / Statement
Expression е всеки израз, който се изпълнява на един ред и връща стойност. Всичко може да е expression, примерно `true`, `5`,`(5)`, `5 + 5`, `true && false` и тн. Обикновено expression-ите имат финална стойност като резултат. Противоположното на expression е statement - `if`, `for`, `while` и тн. 
## Function Hoisting
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
## Function Invocation / Calling
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
## Returning Values
`return` е keyword, който веднага спира execution-a на една функция, тя спира на реда в който го срещне. Ако има код под return, той няма да бъде изпълнен. 

Всяка функция, която няма `return` връща по default - `undefined`. Това е така, защото в този случай, функцията не връща нищо, а `undefined` е стойността по подразбиране за липсващ резултат. Поради тази причина, когато ползваме в конзолата на browser-a, функция, която не връща стойност, получаваме автоматично `undefined`. Накрая на всяка функция, ако не сме сложили `return`, той е добавен автоматично. Ако сложим само `return`, това е равносилно все едно сме сложили `return undefined;`.

Когато имаме точка между две функции, реда на изпълнение е от ляво на дясно - `calculateSum(2, 3).toFixed(2);`. Това се нарича method chaining.

Върнатата стойност може:
Да бъде записана в променлива - `let max = getMax(5, 10);`
Да се използва в expression - `let total = getPrice() * quantity * 1.20;`
Да се подаде на друга функция. Когато имаме вложени функции, вътрешната се изпълнява първа и резултата бива подаден на следващата. - `multiply(getMax(5,10), 20);`
## Nested Functions
Това са функции, които са декларирани в други функции. Това не се прави обикновено. Живота на nested функцията, scope-a в който може да я извикаме е отварящата и затварящата scope-a на функцията в която е дефинирана. Ако имаме nested функции на повече нива, всяка вътрешна функция, може да извиква функции и променливи от всички външни функции, но външните функции имат достъп само до техните директни деца (ако тези функции са декларирани директно вътре в тях). Външните функции нямат достъп до променливите или други декларирани функции вътре във вътрешните им функции . Достъпът до променливите върви само в посока „надолу“ – всяка вътрешна функция може да вижда променливите или другите функции на своите "родителски" функции, но не и обратното.
Nested функциите се hoist-ват, ако са декларирани чрез function declaration. 
## Functional Programming in JS - First-Class Functions
Това е характеристика на функциите и всички функции в JS имат свойството да са такива. Това е пропърти, което функциите в JS имат и в много други езици нямат. Това означава, че всяка функция се държи като стойност и може да отиде навсякъде, където една стойност може да отиде.

```
"The term "first-class" means that something is just a value. A first-class function is one that can go anywhere that any other value can go - there are few to no restrictions."

Michael Fogus, Functional
```
### Passed as an argument
Една стойност, може да бъде подавана като аргумент на функция, което означава, че може да подадем и функция.

```javascript
function executeOperation(firstOperand, secondOperand, operation) {
    const result = operation(firstOperand, secondOperand);

    return result;
}

// Pass function by reference
function sum(a, b) {
    return a + b;
}

// Passing as reference
console.log(executeOperation(2, 1, sum));

// Declaring normal function in the argument, the name sum can be omitted
console.log(executeOperation(2, 1, function sum(x, y) { return x - y; }));

// Declaring а one row arrow function in the argument
console.log(executeOperation(2, 1, (x, y) => x * y));

// Declaring as an arrow function in the argument
console.log(executeOperation(2, 1, (x, y) => {
    return x / y;
}));
```

Първия и втория аргументи са стойности, а третият ни параметър очаква функция, която приема два аргумента `firstOperand` и `secondOperand` и връща резултат.
Има няколко начина, по които може да подадем функцията:
**По референция**: Подаваме съществуваща функция, която отговаря на очакваните параметри и тип на връщаната стойност. В примера това е функцията `sum`.- **Анонимна функция**: Можем да дефинираме анонимна функция директно в аргумента, като опростим кода, когато функцията не е нужно да се използва извън този контекст.
**Arrow функция (едноредова)**: Използва се кратка синтактична форма `(x, y) => x + y`, подходяща за прости операции.
**Arrow функция с блок**: Ако функцията е по-сложна и изисква няколко реда, използваме блокова структура `(x, y) => { return x + y; }`, като това добавя яснота.

Функциите в JS се водят референтен тип данни. В паметта се създава подобна на object структура и може да се достъпи, точно както масивите и другите референтни типове данни. Името на функцията действа като променлива, която се съхранява в стека. Тази променлива съдържа референция (адрес) към паметта в heap-а, където функцията е записана. 
Подобно на обектите и масивите, функциите се предават **по референция**. Това означава, че когато подадем функция като аргумент или я присвоим на друга променлива, ние всъщност копираме само референцията (адреса) към функцията, а не самата функция.

За сравнение с C#:
- **Функциите са част от клас или структура**: В C# методите (функциите) принадлежат на класове или структури и не могат да съществуват като самостоятелни обекти, както в JavaScript. Методът се извиква върху обект (инстанция) или директно върху класа, ако е статичен.
- **Делегати**: В C# делегатите представляват вид обект, който съдържа референция към метод и се използва за предаване на методи като параметри. Делегатът е тип, който дефинира подписа на метода (входни параметри и връщан тип) и може да бъде използван за препратка към всеки метод със съвместим подпис.

В обобщение, делегатите в C# са най-близкият аналог до функциите в JavaScript като референтен тип, който позволява предаване и използване на функции. Въпреки това, те имат по-ограничена функционалност и структура, което ги прави по-малко динамични и по-типизирани в сравнение с гъвкавите функции като обекти в JavaScript.
### Return by another function
Върнатия тип, може да бъде функция, независимо по какъв начин декларирана, както се вижда в примера долу. 

```javascript
function buildOperation(operationName) {
    switch (operationName) {
        case 'sum':
            return function (a, b) {
                return a + b;
            }
        case 'subtract':
            return (a, b) => {
                return a - b;
            }
        case 'multiply':
            return (a, b) => a * b;
        case 'divide':
            return divide;
    }
}

function divide(a, b) {
    return a / b;
}

let sumOperation = buildOperation('sum');
console.log(sumOperation(2, 1));

sumOperation = buildOperation('subtract');
console.log(sumOperation(2, 1));

sumOperation = buildOperation('multiply');
console.log(sumOperation(2, 1));

sumOperation = buildOperation('divide');
console.log(sumOperation(2, 1));
```
### Assigned as a value to a variable
Може да декларираме променлива, на която да присвоим функция. Ползва се като нормална функция, като се достъпва чрез името на променливата. Трябва да се внимава, когато се извиква функцията, защото това може да стане, само след като е декларирана променливата, понеже нямаме hoisting.
## Arrow Functions
Това е съкратен (shorthand) синтаксис на запис за expression функция и се появява в JS през 2015г. Стрелковите функции са предназначени да бъдат компактни и функционално ограничени – тяхната цел е да бъдат бързи и кратки изрази. Липсата на име ги прави по-прости и насочени само към изпълнението на конкретна задача, без да имат собствен контекст или идентичност. Това ги отличава от обикновените функции, които могат да бъдат декларирани с име и съответно използвани като референции и в рекурсивни извиквания. 

```javascript
// Normal function converted to two arrow functions
const expressionNormal = function (number) {
    return number * 2;
}

// Arrow function with expression body
const arrowExpressionBody = (number) => number * 2;

// Arrow function with block body
const arrowBlockBody = (number) => {
    return number * 2;
}

console.log(expressionNormal(3));
console.log(arrowExpressionBody(3));
console.log(arrowBlockBody(3));
```

Има два начина на изписване:

**Съкратения (expression) :**
- Използва се за **едноредови изрази**, при които стойността се връща автоматично, без да е необходимо да се използва `return`.
- Този начин позволява само **едноредови изрази** и не поддържа конструкции като `if`, `for` и други блокови оператори. Но въпреки че е "едноредов", изразът може да бъде дълъг, стига да не изисква допълнителни операции. Може да се ползва тернарен оператор - `let arrowFunction = (a, b) => a > b ? a - b : b - a;`
- Ако параметъра е един, може да махнат скобите и да остане само параметъра - `const expressionBody = number => number * 2;`
- Ако са два или повече параметри, трябва да са в скоби и изредени със запетайки - `const expressionBody = (number, number2) => number * number2;`
**Разширен (block body) синтаксис :**
- При този начин на запис се използват **фигурни скоби** и **ключовата дума `return`**, когато трябва да върнем стойност.
- Този синтаксис позволява използването на **условни оператори, цикли и други блокови конструкции**.
## Naming Functions
Имената трябва да са значими и да се разбират ясно, да отговарят на въпроса какво прави функцията. 
Добрата практика при имената на функции е те да започват с глагол, който ясно показва какво действие извършва функцията, последван от съществително или обект, върху който се прилага това действие. Това прави кода по-четлив и интуитивен.
Трябва също името да е съобразено, спрямо останалите функции в приложението. Трябва да имаме конвенция, която да се спазва за всички имена и така някой външен човек, много бързо ще се ориентира.

В дадени ситуации, когато искаме бързо да оправим нещо, е приемливо да използваме име от сорта на `dirtyHack` но е добре да сложим и коментар показващ че това е hot fix.

Трябва да се спазва `camelCase` в имената с някои изключения.

Ако не може да измислим добро име, това е индикатор, че може би функцията не е добре написана, примерно прави прекалено много неща и тн.

Колко специфично трябва да е името - дали да е общо или специфично, зависи от контекста. Примерно ако имаме само едно нещо в цялата апликация, което наричаме report, няма нужда да го уточняваме повече, но ако има много различни, трябва да сме по специфични, за да е ясно какъв е report-a. В тези случаи не е проблем името да се състои от повече думи. Това правило важи за всички идентификатори, не само функции. Спазването на това правило, помага за по-доброто документиране на кода. Примерно ако сме във функция с име `analyzeCustomStatementReports()`, няма нужда променливата вътре да се казва `const customStatementAnnualReport`, а може да бъде просто `report` или `annualReport`, ако ще имаме и друг вид report-и, примерно `monthlyReport`. В случая името на функцията дава контекста в който се намираме. Идеята е да не се прекалява с даването на информация, когато е излишно и не допринася за повече яснота, но само натоварва. Друг пример за кратко кръщаване на идентификатори е когато имат кратък lifespan, примерно една променлива се използва само веднъж след като е дефинирана. В такива случаи, може да си позволим да ги кръщаваме с кратки имена.
Абревиатурите в имената, може да се ползват само в тривиални случаи, като например `HTML`, като може да бъдат записани примерно в комбинация с `input`, като `inputHtml` или `inputHTML` и двете са правилни.
## Naming Function Parameters
Имената на параметрите обикновено са съществителни или комбинация от прилагателни и съществителни, за да опишат по-точно какво представя дадения параметър. Този подход помага за по-добра четимост и яснота на кода.

1. **Съществителни**:
    - `age`
    - `price`
    - `quantity`
    - `user`
    - `list`
2. **Прилагателни + Съществителни**:
    - `maxSpeed`
    - `userName`
    - `isActiveUser`
    - `totalAmount`
    - `firstItem`

 Както при функциите, променливите и всички идентификатори и тук имената трябва да са `camelCase`.
## Functions - Best Practices
Функцията трябва да изпълнява една добре дефинирана цел и името й трябва да го отразява.
Трябва да се избягват функции с повече редове от един екран, като това е груб ориентир. По дългите функции, трябва да се разделят на под функции.
Стандарта за дължината на редовете преди да се прехвърли кода на нов ред е от около 80 до 140 col's / символа на един ред.
## Code Structure and Code Formatting
Функциите трябва да са разделени от един ред, като добра практика. След всеки блок на код, също трябва да се слага празен ред, освен ако блока не свършва и веднага след него свършва друг блок.
Празен ред може да се слага и когато искаме да разделим логически на по-малки парчета кода в един блок.
Винаги трябва да има един празен ред на края на файла, като това може да се автоматизира чрез `Insert Final Newline` настройката в Settings на VS Code.
Причини за това са:
- **POSIX стандарти**: Според POSIX стандартите, текстовите файлове трябва да завършват с нов ред. Това може да предотврати неочаквани проблеми при обработката на файлове от различни инструменти.
- **По-добра съвместимост с Git**: Git и други системи за контрол на версиите могат да открият проблеми, ако в края на файла няма нов ред.

`Shift + Alt + F` - форматира файл-a, може да се направи след всеки save да се изпълнява автоматично.

Препоръчително е да се ползват къдравите скоби в блоковите конструкции. При `if` и други конструкции, може да не се ползват, но не е добра практика. Ако няма скоби, само първия ред след `if` ще бъде част от него, но следващите няма да бъдат.

Трябва да се избягват дълги линии и сложни expressions. Ако има много operations per line, е добре да се разделят на повече променливи. Освен функциите, но и променливите, служат и като документация. Примерно един много сложен математически expression, може да се раздели на последователност от по малки expressions и така по-лесно се проследява логиката. 
### Indentation
Има различни стандарти за индентация - чрез интервали, където табовете представляват просто интервали. Това е предпочитания вариант, но в IDE-то може да се нагласи да ползва и табулация като символ, който е различен от интервал. При използването на интервали, двата популярни стандарта са 2 и 4 интервала за таб, като това също се настройва от IDE-то. При по-малка индентация както е при 2 интервала, кода се сбива повече и позволява по-голямо nest-ване, отколкото при ползването на 4 интервала. Така наречените never nesters дори слагат по 8 интервала с цел да се избягва nest-ването. Never nesting-а според много програмисти, означава по-качествен и чист код.

Кода който принадлежи на функция и другите блокови конструкции, трябва да е с един tab разстояние навътре, за повече яснота. Това не е задължително, но е препоръчително.
# Misc
## IIFE - Immediately Invoked Function Expression
Това е начин за създаване и изпълнение на функция веднага, без да е необходимо да я присвояваме на променлива. Това е полезно, когато искаме да изпълним код, но не ни е нужна референция към самата функция след това.

**Как работи IIFE:**

- **IIFE** се дефинира като **function expression**, който е обграден със скоби, а след това веднага след дефиницията се извиква чрез добавяне на още скоби.
- Основната цел на IIFE е да създаде изолирана среда (scope) за изпълнение на код, така че вътрешните променливи да не замърсяват глобалния обхват.

```javascript
((a, b) => console.log(a + b))(1, 2);

(function test(a, b) {
    console.log(a + b);
})(1, 2);
```

**Какво прави IIFE полезно:**

- **Изолация на обхвата**: Параметрите и променливите вътре в IIFE са достъпни само в рамките на тази функция, което помага да се предотврати замърсяването на глобалния обхват.
- **Обработване на начален код**: Често се използва за изпълнение на еднократни операции или инициализация, без да оставя излишни променливи в глобалния обхват.
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
## Statements and Expressions in JavaScript
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
## Function Names Are Scoped Identifiers
in JavaScript as well in C#, when you declare a function with a name (a **named function declaration**), that name acts as an identifier (or variable) within its scope. This means you cannot reuse that name for a different variable in the same scope.

For example:

```javascript
function calculate() {
    // function body
}

// Trying to declare a variable with the same name in the same scope will cause an error
let calculate = 5; // This will throw an error: SyntaxError: Identifier 'calculate' has already been declared
```

However, you can reuse the function name in different scopes without conflict. For instance, inside a different function, you could use the same name for a variable:

```javascript
function calculate() {
    // function body
}

function anotherFunction() {
    let calculate = 10; // This is allowed because it's in a different scope
    console.log(calculate); // Outputs 10
}
```

In general, JavaScript treats named function declarations like variable declarations (they’re hoisted to the top of their scope), so they must have unique names within the same scope.
## Higher-Order Functions
In JavaScript (and many other programming languages), **higher-order functions** are functions that either take other functions as arguments, return functions as results, or do both. This ability makes JavaScript highly flexible, allowing developers to write modular, reusable code. Higher-order functions are fundamental to functional programming concepts and can enable efficient, readable, and clean code.

Here's how they work:

1. **Taking Functions as Arguments**
- Functions like `.map`, `.filter`, and `.forEach` in JavaScript accept functions as arguments to process elements in an array. These passed functions are called _callback functions_.

```javascript
const numbers = [1, 2, 3, 4, 5];
const squared = numbers.map(num => num * num); // [1, 4, 9, 16, 25]
```

In this example, `.map` is a higher-order function that takes a function `(num => num * num)` as an argument to apply to each element in the `numbers` array.

2. **Returning Functions**
- Some functions generate and return other functions, allowing for customization and delayed execution.

```javascript
function multiplier(factor) {
    return function(number) {
        return number * factor;
    };
}

const double = multiplier(2);
console.log(double(5)); // 10
```

Here, `multiplier` is a higher-order function that returns a function. The returned function `double` multiplies any input by 2.

3. **Combining Functions**
- Since higher-order functions can take and return functions, they can be composed to create more complex behaviors.

```javascript
const add = x => y => x + y;
const add5 = add(5);
console.log(add5(10)); // 15
```

Higher-order functions are powerful for creating dynamic, modular, and reusable code, especially in situations where we want to perform actions on data collections or create pipelines of functions.
# Bookmarks 

Completion: 07.11.2024