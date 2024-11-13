# General
## Objects
Обектите са много сходни с масивите, представляват колекция от данни и са структурен / референтен тип, държат се в heap паметта.

Обектите композират в себе си повече данни, както и масивите, където имаме индексиран списък от данни. В обектите данните се асоциират към стрингове в `kvp` - key value pair тип данни. 

Обектите са структура от свързани данни или функционалности, които са групирани по принадлежност към даден обект. Примерно имаме обект котка, която може да я опишем примерно с години - int,  име - string, пол - boolean, списък от прегледи - array и тн, все различен тип данни, но свързани с конкретния обект. Това е и съществена разлика с масива, където данните са предимно групирани по тяхната еднотипност.

Всеки обект може да бъде характеризиран от пропъртита и / или методи, които може да има в себе си. Те може да бъдат добавяни и изтривани динамично (dynamic property), по време на runtime.

Списък с методи и какво правят има в папката с ресурси във файла за JavaScript.
### Properties
Представляват двойки ключ и стойност в обекта. Стойностите в обекта, се достъпват по стрингове, може да имаме ключа `name` и стойността `Pesho`. Всяко property си има ключ и стойност, може да ги наричаме още и property name и property value.
### Methods
Това са функции, които са част от обекта и му предоставят определени функционалности. Метода не е нищо повече от функция, която стои в обект. Може да присвояваме функции като стойности на пропъртитата. За да извикаме метода, трябва да извикаме обекта и да ползваме dot syntax:

```javascript
    function swingTail(name) {
        console.log(`${name} is swinging his tail!`);
    }

    const play = (name) => console.log(`${name} is playing!`);

    let dog = {
        name: 'Hero',
        bark: function () { // Function expression syntax
            console.log(`${this.name} is barking!`);
        },
        sleep: () => console.log('zZz'), // Arrow function syntax - `this` context is lost and cannot be used
        swingTail: swingTail, // Assigning function by reference
        play: play, // Assigning function by reference
        eat() { // Object method notation
            console.log(this.name, 'is eating!');
        },
    };

    dog.bark();
    dog.sleep();
    dog.swingTail('Hero');
    dog.play('Hero');
    dog.eat();
    dog.walking = function () { // Adding method to an already defined object
        console.log(this.name, 'is walking!'); // `this` is working because its correctly pointing to the dog object
    };

    dog.walking();
```

Ако ползваме arrow функция, не може да ползваме `this` чрез което се посочват други пропъртита в обекта, защото arrow функциите не създават собствен контекст за `this`. Вместо това, `this` в arrow функцията ще реферира към външния контекст, който може да не е самият обект, а например глобалния обхват или обхвата на функцията, в която е дефиниран обектът. Това е една от ключовите разлики между обикновените функции и arrow функциите, при които `this` не се задава спрямо обекта, а наследява контекста от мястото на дефиниция на функцията.

Object method notation е предпочитания начин за дефиниране на метод и работи само вътре в обекта. Чрез този синтаксис, IntelliSense се усеща че това е метод и ни го показва правилно в лилаво в едитора. 

Може да се добавят и методи на вече дефинирани обекти, но не може да се ползва object method notation.

Долната черта е валиден символ за имената на пропъртитата (идентификаторите) - `first_name`.
### Literal
Литерала на обекта е отваряща и затваряща къдрава скоба, където може да описваме пропъртитата - `let cat = {}; // empty object`
### Object Definition
От ляво изписваме ключа, който няма нужда да е в кавички и от дясно стойността.

```javascript
   let cat = { name: 'Purka', age: 10 };
```

Това е обект с две пропъртита, където при първото ключа е `name`, а стойността е string `Purka`, второто пропърти ключа е `age` със стойност number 10. Когато правим обекти с повече от две пропъртита е добре да смъкнем всяко пропърти на отделен ред. 

В JS може да имаме trialing запетая дори след последното пропърти.

При принтиране на конзолата в VS Code, обекта е в къдрави скоби, за да се различава от стринг.

Може да дефинираме и празни обекти, на които да добавим в runtime стойности:

```javascript
    let person = {};

    // Set property dinamically (runtime)
    person.name = 'Pesho';
    person.age = 20;
    person.isMale = true;

    console.log(person);
```

Има два начина за достъпване и присвояване на стойности, чрез dot и bracket notations:

```javascript
    let person = {};

    // Set and access property with dot notation
    person.name = 'Pesho';
    console.log(person.name);

    // Access property with bracket notation
    person['age'] = 20;
    console.log(person['age']);
```

Когато се ползва bracket notation, ключа на пропъртито трябва да е в кавички. Bracket notation се ползва, примерно ако подаваме ключа като променлива, през повечето време се ползва dot syntax.

Когато присвояваме стойност на дадено пропърти, ако то не съществува, ще го създаде със съответната стойност, ако съществува, ще му смени стойността. Това важи и ако по време на декларирането на обекта, сложим даден key два или повече пъти, ще запише последната му стойност.

Имаме и shorthand syntax за присвояване на стойности, когато името на ключа съвпада с променливата, няма нужда да пишем стойностите, това важи и за методи:

```javascript
function solve(firstName, lastName, age) {
    let isMale = true;

    const sleep = () => console.log('zZz');

    let person = {
        firstName,
        lastName,
        age,
        isMale,
        sleep,
    };

    console.log(person);
    person.sleep();

}

solve('Gerard', 'Shahin', 20);
```
## JSON - JavaScript Object Notation
Това е формат на данни, който най-често се използва за прехвърляне на данни. Когато искаме да прехвърлим данни от едно място на друго, трябва да ги сериализараме - да ги обърнем в текстов формат, за да може да се прехвърлят лесно. JSON е такъв текстов формат, който ни позволява да прехвърляме данни, без значение от къде на къде. Използва се най-вече за прехвърляне на обекти, между клиент сървър, сървъри и тн, тъй като е лек и лесен за парсване от машини.

Този стандарт произлиза от начина по който работят обектите в JS. Взет е стандартния синтаксис за обектите в JS, но са го дефинирали по-строго.
JSON се е наложил над XML, който се е използвал за същата цел, тъй като е по-лек и лесен за работа, заради по-малкото излишни символи. YAML е друг такъв стандарт, който е дори по-лек и от JSON, но се използва най-вече в конфигурационни файлове. JSON остава по-популярен за обмен на данни, особено в уеб приложенията.

JSON е независим от конкретен език, защото е интегриран във всички, примерно чрез библиотеки и вграден механизъм, който подържа JSON out of the box.
JS също има вградени функционалности за работи с JSON. Когато се види един JSON файл, лесно се разбира какво съдържа, за разлика от XML file.

JSON много често се ползва за exchange на данни между browser и server.

**Пример:**

```json
{
  "name": "Ivan",
  "age": 25,
  "grades": {
      "Math": [2.50, 3.50],
      "Chemistry": [4.50]
  }
}

{ 
  // Invalid - не може да имаме повече от един root елемент
}
```

Имаме задължителни къдрави скоби, които дефинират общия JSON, може да имаме само един root елемент, освен ако не ги сложим в масив. Вътре имаме пропъртита, като отново са пропърти име и пропърти стойност.

Имената на пропъртитата, трябва задължително да са в двойни кавички.

Подържат се различни типове и структури като string, number, object, array и тн.

Може да имаме и nested обекти, `grades` в примера, в който имаме оценки, като всеки от предметите държи масив.

Trailing запетайките не са позволени.

Jason-a може да е в масив и така може да имаме повече от един елемент.

```json
[
    {
        "name": "Ivan",
        "age": 25
    },
    {
        "name": "Petar",
        "age": 30
    }
]
```

Пример за конвертиране / сериализиране на обект в JSON и обратното му конвертиране пак в нов обект:

```json
    let dog = {
        name: 'Hero',
        age: 5,
        breed: 'Swiss Shepard',
        bark: function () { console.log(this.name, 'barking'); }
    };

    // Converts object to json
    let dogJSON = JSON.stringify(dog);

    console.log(dogJSON); // Method not included
    console.log(typeof (dogJSON)); // string

    // Convert json to new objects not related to the original dog object in any way
    let dogFromJSON = JSON.parse(dogJSON);
    let dogFromJSON2 = JSON.parse(dogJSON);

    console.log(dog == dogFromJSON); // false
    console.log(dogFromJSON == dogFromJSON2); // false
```

JSON резултатът е текстова стойност, която може да бъде изпратена през мрежа или записана в файл, но не е директно обект.

Списък с методи и какво правят има в папката с ресурси във файла за JavaScript.
## Associative Arrays
Масив в който елементите не се индексират по индекси, а със стринг. Пример е ако имаме телефонен указател, където зад всеки номер стои име. Имаме множество имена, които се асоциират към определени номера. 

В JS асоциативния масив е просто обект. Оригинално обекта е разнородни данни, които са свързани помежду си, защото описват един конкретен обект примерно куче. Асоциативния масив, запазва възможността за асоциация на стринг към стойност, но е еднороден в смисъла на списъчните данни - стойностите са от еднакъв тип. 

В JS няма отделна колекция наречена речник, но използва обектите.

Асоциативния масив държи двойки `[key => value]`, които са пропъртита.

Key-a е стринг, тъй като в обект задължително трябва да е стринг. Ако искаме key-a да може да държи други типове освен стринг, в JS има друга колекция, наречена map, но в повечето случаи, стрингов key ни върши работа. Стойността може да бъде от всеки тип.

Декларирането става по същия начин както обекта, с разликата че имаме еднородност на данните.

Ако искаме да добавим стойността на дадена променлива като ключ, може да го направим чрез динамично задаване на ключове, като ползваме bracket notation  - слагаме променливата в квадратни скоби `[]`:

```javascript
    let emergencyContact = '0888888888';
    
    let phonebook = {
        [emergencyContact]: 'Pesho',
        '0888888887': 'Gosho',
        '0888888886': 'Tosho'
    };
```
### Manipulating Associative Arrays
За да проверим дали има стойност, зад определен ключ, може да ползваме if проверка:

```javascript
    let phonebook = {
        'Pesho': '0888888888',
        'Gosho': '0888888887',
        'Tosho': ' 0888888886'
    };

    if (phonebook['Pesho']) {
        console.log('Pesho has phone');
    }
```

Ако няма резултат, най-вероятно е  празен стринг `''`, `null` или `undefined`. При тази проверка, се гледа само стойността, ако искаме да проверим конкретно даден key, независимо от стойността, се ползва метода `hasOwnProperty(key)`. 

Ако искаме да изтрием дадено пропърти, се ползва оператора  `delete myObject['key]`, като освен bracket notation, работи и dot notation.

Списък с допълнителни методи и какво правят има в папката с ресурси във файла за JavaScript.
## Using for-in
Тази конструкция се ползва да итерира обекти, защото минава през ключовете. Ако се ползва на обикновен масив, връща индекса на дадения елемент, но може да има непредвидено поведение, тъй като `for-in` обхожда всички собствени свойства на обекта (включително тези, които не са стандартни елементи на масива).

```javascript
    let phonebook = {
        '0888888888': 'Pesho',
        '0888888887': 'Gosho',
        '0888888886': 'Tosho'
    };

    for (let key in phonebook) {
        console.log(`Key ${key} with value ${phonebook[key]}`);
    }
```

`for-in` не използва вътрешен итератор (по начина, по който работят масивите и други обекти в JavaScript, като например `Map` и `Set`). Вместо това, той директно обхожда собствените свойства на обекта, като използва съществуващите му ключове (индекси). В случая с масиви, `for-in` всъщност се използва за обхождане на индексите (ключовете) като текстови стойности, а не самите стойности на елементите.
    
Итератори обикновено се използват за обхождане на колекции, които следват по-формален протокол. Например, масивите имат вграден итератор, който може да бъде използван чрез `for-of` или `Array.prototype.forEach`. Итераторите осигуряват механизъм за обход, който не зависи от ключовете или индексите, а от самите елементи. Ако нашия обект няма итератор, не може да ползваме `for-of` върху него. Това е много подобно на enumerator-а в C#.
# Misc
## Identifiers
Имаме идентификатори на функции, променливи и пропъртита, като всички имат еднакви правила:
- Не могат да започват с числа, но може да започват с долна черта.
- Мога да имат числа и долна черта, както и `$`.
- Ако искаме да имаме нелегален символ в името на пропърти на обект, трябва да се декларира със стринг, примерно ако искаме да сложим тире - `'first-name': 'Pesho'` Така може и интервал да се сложи. Достъпването на пропъртита с нелегални символи, става само чрез bracket syntax.
- В по-стари библиотеки, когато пропърти започне с `_` това е знак че е служебно пропърти и не трябва да се пипа, символично като private property.
# ChatGPT
## JS Objects Similar To C# Dictionaries
**JavaScript objects** are much more similar to **C# dictionaries** than to **C# objects** (i.e., classes with properties).

**Here's a comparison:**

In JavaScript, objects are essentially collections of **key-value pairs**, where keys are typically strings (or symbols) and values can be any data type (like strings, numbers, arrays, etc.).

```javascript
const person = {
  name: "Alice",
  age: 25,
  isStudent: true
};
```

This is very much like a **C# `Dictionary<string, object>`**, where keys are strings and values can be any type:

```csharp
var person = new Dictionary<string, object>
{
    { "name", "Alice" },
    { "age", 25 },
    { "isStudent", true }
};
```

Both JavaScript objects and C# dictionaries allow you to dynamically add keys and values, and access values using keys.

**JavaScript Objects vs. C# Classes with Properties:**

On the other hand, **C# classes with properties** are more rigid and structured. They are used to define specific types of data, where the keys (properties) and their types are defined at compile-time, and typically require getter and setter methods (though C# can auto-implement them).

For example:

```csharp
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsStudent { get; set; }
}

var person = new Person
{
    Name = "Alice",
    Age = 25,
    IsStudent = true
};
```

In this case, the keys (e.g., `Name`, `Age`, `IsStudent`) and their types are strictly defined, unlike in a dictionary or JavaScript object.

**Key Takeaways:**

- **JavaScript objects** are closer to **C# dictionaries** in terms of flexibility and how they store key-value pairs dynamically.
- **C# classes with properties** are more structured and predefined, with a fixed set of properties (keys) and associated types, whereas JavaScript objects and C# dictionaries are more flexible and can have arbitrary keys and values.

So, yes, JavaScript objects are **more similar to C# dictionaries** than to C# objects (i.e., classes with properties).
# Bookmarks 