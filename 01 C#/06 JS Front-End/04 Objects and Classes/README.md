# General
## Objects
Обектите са много сходни с масивите, представляват колекция от данни и са структурен / референтен тип, държат се в heap паметта.
Обектите композират в себе си повече данни, както и масивите, където имаме индексиран списък от данни. В обектите данните се асоциират към стрингове в `kvp` - key value pair тип данни. 
Обектите са структура от свързани данни или функционалности, които са групирани по принадлежност към даден обект. Примерно имаме обект котка, която може да я опишем примерно с години - int,  име - string, пол - boolean, списък от прегледи - array и тн, все различен тип данни, но свързани с конкретния обект. Това е и съществена разлика с масива, където данните са предимно групирани по тяхната еднотипност.
Всеки обект може да бъде характеризиран от пропъртита и / или методи, които може да има в себе си. Те може да бъдат добавяни и изтривани динамично, по време на runtime 
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
Литерала на обекта е отваряща и затваряща къдрава скоба, където може да описваме стойностите - `let cat = {}; // empty object`
### Object Definition
От ляво изписваме ключа, който няма нужда да е в кавички и от дясно стойността.

```javascript
   let cat = { name: 'Purka', age: 10 };
```

Това е обект с две пропъртита, където при първото ключа е `name`, а стойността е string `Purka`, второто пропърти ключа е `age` със стойност number 10.
Когато правим обекти с повече от две пропъртита е добре да смъкнем всяко пропърти на отделен ред. В JS може да имаме trialing запетая дори след последното пропърти.
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

Има два начина за достъпване и присвояване на стойности, чрез dot и bracket syntax:

```javascript
    let person = {};

    // Set and access property with dot syntax
    person.name = 'Pesho';
    console.log(person.name);

    // Access property with bracket syntax
    person['age'] = 20;
    console.log(person['age']);
```

Когато се ползва bracket syntax, ключа на пропъртито трябва да е в кавички. Bracket syntax се ползва, примерно ако подаваме ключа като променлива, през повечето време се ползва dot syntax.

Когато присвояваме стойност на дадено пропърти, ако то не съществува, ще го създаде със съответната стойност, ако съществува, ще му смени стойността.

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
```

Имаме задължителни къдрави скоби, които дефинират общия JSON, може да имаме само един root елемент.
Вътре имаме пропъртита, като отново са пропърти име и пропърти стойност.
Имената на пропъртитата, трябва задължително да са в двойни кавички.
Подържат се различни типове и структури като string, number, object, array и тн.
Може да имаме и nested обекти, `grades` в примера, в който имаме оценки, като всеки от предметите държи масив.
# Misc
## Identifiers
Имаме идентификатори на функции, променливи и пропъртита, като всички имат еднакви правила.
Не могат да започват с числа, но може да започват с долна черта.
Мога да имат числа и долна черта, както и `$`.
Ако искаме да имаме нелегален символ в името на пропърти на обект, трябва да се декларира със стринг, примерно ако искаме да сложим тире - `'first-name': 'Pesho'` Така може и интервал да се сложи. Достъпването на пропъртита с нелегални символи, става само чрез bracket syntax.
В по-стари библиотеки, когато пропърти започне с `_` това е знак че е служебно пропърти и не трябва да се пипа, символично като private property.
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