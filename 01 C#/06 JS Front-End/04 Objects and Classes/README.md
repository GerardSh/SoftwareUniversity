# General
## Objects
Обектите са много сходни с масивите, представляват колекция от данни и са структурен / референтен тип, държат се в heap паметта.

Обектите композират в себе си повече данни, както и масивите, където имаме индексиран списък от данни. В обектите данните се асоциират към стрингове в `kvp` - key value pair тип данни. 

Обектите са структура от свързани данни или функционалности, които са групирани по принадлежност към даден обект. Примерно имаме обект котка, която може да я опишем с години - int,  име - string, пол - boolean, списък от прегледи - array и тн, все различен тип данни, но свързани с конкретния обект. Това е и съществена разлика с масива, където данните са предимно групирани по тяхната еднотипност.

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

solve('John', 'Doe', 20);
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
## Sorting
В обектите, няма гаранция как ще бъдат подредени елементите. Обикновено подредбата е в реда в който са добавени пропъртитата, но в някои случаи се пренареждат, примерно ако заменим, изтрием стойности и тн. За да направим сортиране, първо трябва да конвертираме обектите към масив и след това да сортираме масива. За да създадем масива, може да ползваме метода `Object.entries(myObject)` и след това да го сортираме чрез метода `sort()`. А може да вземем само key-овете и да сортираме тях. Може да се прави и сортиране по стойност, а не по ключ, като единствената разлика е, че вместо да подаваме ключовете в `localeCompare()` метода, трябва да подадем стойностите.

```javascript
    let phonebook = {
        'Pesho': '0888888888',
        'Gosho': '0888888887',
        'Tosho': '0888888886'
    };

    // Sorting using entries by values
    let phonebookEntries = Object.entries(phonebook).sort((entryA, entryB) => entryA[1].localeCompare(entryB[1]));

    console.log('Sorted using entries by values');

    for (let [key, value] of phonebookEntries) {
        console.log(key, value);
    }

    // Sorting using entries by keys
    let phonebookEntries = Object.entries(phonebook).sort((entryA, entryB) => entryA[0].localeCompare(entryB[0]));

    // Alternative syntax, using destructuring where we can further omit valueA and valueB since they are not used
    let phonebookEntries2 = Object.entries(phonebook).sort(([keyA, valueA], [keyB, valueB]) => keyA.localeCompare(keyB));
    
    console.log('Sorted using entries by keys');

    for (let [key, value] of phonebookEntries) {
        console.log(key, value);
    }

    // Sorting using keys
    let sortedKeys = Object.keys(phonebook).sort((a, b) => a.localeCompare(b));

    console.log(`\r\nSorted using keys`);

    for (let key of sortedKeys) {
        console.log(key, phonebook[key]);
    }

    //Reconstructing object from the entries array
    let sortedPhonebook = Object.fromEntries(phonebookEntries);

    console.log(`\r\nOriginal object`);
    console.log(phonebook);

    console.log(`\r\Sorted object`);
    console.log(sortedPhonebook);
```

Как работи метода `sort()` има подробно обяснение в JavaScript file-a в папката с ресурси.

Ако искаме да обърнем масив в обект, може да ползваме метода `Object.fromEntries(myEntriesArray)`, но в този случай, ни трябва масив от двойки`[key, value]` какъвто създава и `Object.entries(myObject)` метода.
## Array and Object Destructuring
Както и при масивите и така и при обектите може да ползваме destructuring за да запишем стойностите на дадени пропъртита в променливи. Може освен стойностите да се взимат и ключовете.

```javascript
    // Array destructuring
    let arr = [1, 2, 3];
    const [x, y, z] = arr;
    // Equivalent to:
    const x2 = arr[0];
    const y2 = arr[1];
    const z2 = arr[2];

    // Object destructuring values only
    let obj = { a: 1, b: 2 };
    const { a, b } = obj;
    // Equivalent to:
    const a2 = obj.a;
    const b2 = obj.b;

    // Object destructuring keys and values
    for (let [key, value] of Object.entries(obj)) {
        console.log(key, value);
    }
```

Деструктурирането може да се използва директно като параметър на функции за приемане на масиви или обекти. Това прави кода по-кратък и четлив, защото можем директно да присвояваме стойностите на променливи, без да се налага да достъпваме елементите или пропъртитата ръчно вътре в тялото на функцията.

**Примери**

**Деструктуриране на Масив в Параметър на Функция**

```javascript
function printCoordinates([x, y]) {
    console.log(`X: ${x}, Y: ${y}`);
}

printCoordinates([10, 20]); // Output: X: 10, Y: 20
```

**Обяснение**: Тук `printCoordinates` приема масив с две стойности и директно ги деструктурира в променливите `x` и `y`.

**Деструктуриране на Обект в Параметър на Функция**

```javascript
function greet({ name, age }) {
    console.log(`Hello, ${name}! You are ${age} years old.`);
}

greet({ name: "Maria", age: 25 }); // Output: Hello, Maria! You are 25 years old.
```

**Обяснение**: В този случай функцията `greet` приема обект и директно деструктурира стойностите на пропъртитата `name` и `age`.

**Допълнителни Ползи**

Деструктурирането в параметрите на функцията е удобно, защото:

1. Намалява нуждата от допълнителен код за достъп до стойностите.
2. Улеснява четимостта и поддръжката на кода.
3. Позволява директно да определяме променливи само за стойностите, които са ни необходими, като избягваме излишни данни.

При деструктуриране на обект, взимаме стойностите на пропъртитата, като използваме името на ключа, но не се интересуваме от реда на ключовете. Ако въведем име на несъществуващ ключ, тази променлива ще бъде `undefined`. 
Има начин да сложим ново име на променлива, различно от името на ключа, трябва да се напише името на ключа, две точки и новото име. В примера долу създаваме променлива с име `university`, вместо `school`.
Може да ползваме и `...` rest оператора, за да съберем останалите пропъртита в обект, след като сме извлекли конкретни ключове от оригиналния обект.

```javascript
    let person = { name: "John", age: 30, school: 'SoftUni', gender: 'male', country: 'Bulgaria', city: 'Sofia' };
    const { name, age, school: university, sex, ...rest } = person;  // Извличаме стойностите по ключовете 'name' и 'age', а останалите стойности ги слагаме в отделен обект, чрез rest оператора

    console.log(name); // "John"
    console.log(age);  // 30
    console.log(university);  // SoftUni 
    console.log(sex);  // undefined 
    console.log(rest); // {gender: 'male', country: 'Bulgaria', city: 'Sofia'}
    console.log(typeof (rest)); // object
```

В горния пример, деструктурирахме обекта `person` на няколко променливи, като всички оставащи пропъртита събрахме в нов обект чрез оператора `rest`.

При масивите деструктурирането се прави на базата на позициите (индекси) в масива:

```javascript
let arr = [1, 2, 3];
const [x, y, z, h] = arr; // Вземаме стойностите в същия ред на позициите

console.log(x); // 1
console.log(y); // 2
console.log(z); // 3
console.log(h); // undefined
```

**Заключение:**

При обектите деструктурирането извлича стойностите на пропъртитата, като се базира на имената на ключовете, позицията им няма значение. Докато при масивите стойностите се извличат според реда на елементите, имената на променливите нямат значение.
## Classes
Класовете са механизъм, който дава възможност за създаване на еднотипни обекти. Класа е като шаблон за обекти и дефинира тяхната структурата и поведение.

Обект създаден от клас се нарича инстанция на този клас. Реално това са стандартни JS обекти, но имат гаранция за тяхната структура, защото произлизат от даден клас. Има ситуации, където ако имаме логика в конструктора на класа да се създават обекти с различни пропъртита. Примерно ако имаме клас животно, където конструктора приема вида на животното и спрямо него, създава различни пропъртита. В тези ситуации, макар дадени обекти да произлизат от един и същи клас, те ще имат различна структура.

Класовете се създават с ключовата дума `class` и името на класа, което трябва да бъде PascalCase. Това е и едно от местата в JS където се нарушава конвенцията да се изписват идентификаторите с camelCase.

```javascript
    class Dog {

        constructor(name, breed, age) {
            this.name = name;
            this.breed = breed;
            this.age = age;
        }

        makeSound() {
            console.log('bark');
        }
    }

    let firstDog = new Dog('Hero', 'Swiss Shepard', 5);
    let secondDog = new Dog('Axel', 'German Shepard', 12);

    console.log(firstDog); // Dog {name: 'Hero', breed: 'Swiss Shepard', age: 5}

    firstDog.makeSound();
}
```
### Constructor
Класовете имат конструктор - метод който се извиква автоматично, за да създаде обекта. За разлика от C# където конструктора е с името на класа, в JS се казва `constructor()`. В конструктора можем да добавим параметри, които се задават при създаването на нов обект.
Може да имаме само един конструктор в клас, но като варианти за workaround можем да използваме следните подходи:
- **Default parameter values**: Да зададем стойности по подразбиране за параметрите на конструктора.
- **Conditional logic в конструктора**: Да добавим логика, която обработва различни типове аргументи или комбинации от параметри.
- **Factory methods**: Да създадем статични методи, които връщат нови обекти, базирани на различни входни данни.
### Default Properties
Ако искаме в класа ни да има пропъртита, които не се дефинират в конструктора, трябва да напишем името на пропъртито и да му дадем стойност. Ако не му дадем стойност, ще бъде undefined. Желателно е да се слагат преди конструктора. Интерпретатора първо ще инициализира тези пропъртита и после ще влезне в конструктора да инициализира пропъртитата вътре. Може да следваме принципа където, ако слагаме default стойности ги позиционираме пропъртитата извън конструктора, а ако стойностите биват подадени като аргументи на конструктора, тогава  ги слагаме вътре в него.

```javascript
    class MyClass {
        myProperty = 0;
        myProperty2;
        
        constructor(myProperty3) {
            this.myProperty3 = myProperty3;
        };
    }

    console.log(new MyClass(3)); // MyClass {myProperty: 0, myProperty2: undefined, myProperty3: 0}
```
### `this` Keyword
`this` в контекста на клас, сочи към текущата инстанция с която работим в момента. Обекта, който ще бъде създаден, ще има пропърти `name`, което ще е равно на променливата `name` в конструктора. Променливата в конструктора и пропъртито може да имат различни имена.
### `new` Operator
С оператора `new` създаваме инстанция на класа. Това което получаваме е съвсем нормален обект, за който важат всички правила и ограничения за обектите в JS. Единствено пред обекта, може да видим че се вижда името на класа, от който е бил създаден.

За да можем да създадем обект, класовете трябва да бъдат дефинирани преди реда, на който се създава обектът, защото в JavaScript няма hoisting за класове. Това означава, че класовите декларации не се "вдигат" в началото на кода, както става с функциите. Ако опитаме да използваме клас преди неговото дефиниране, ще получим `ReferenceError`.
### Methods
Методите се добавят почти както method notation-a, но с разликата че не се слагат запетайки между отделните членове на класа.
В примера метода `makeSound()` е инстанционен метод, който се достъпва само през инстанциите на класа. Може да имаме и статични методи и пропъртита, като трябва да напишем `static` keyword-a преди метода или пропъртито.

```javascript
class MyClass {
    // Static property
    static staticProperty = 'I am a static property';

    // Instance property
    instanceProperty = 'I am an instance property';

    // Static method
    static staticMethod() {
        console.log('This is a static method.');
    }

    // Instance method
    instanceMethod() {
        console.log('This is an instance method.');
    }
}

// Accessing static property and method directly from the class
console.log(MyClass.staticProperty);  // Output: I am a static property
MyClass.staticMethod();               // Output: This is a static method.

// Creating an instance of the class
let obj = new MyClass();

// Accessing instance property and method through the instance
console.log(obj.instanceProperty);  // Output: I am an instance property
obj.instanceMethod();                 // Output: This is an instance method.

// You cannot access static properties or methods through an instance
// console.log(obj.staticProperty);  // Error: Cannot read property 'staticProperty' of undefined
// obj.staticMethod();              // Error: obj.staticMethod is not a function
```
### Private Methods and Properties
Може да имаме и private методи и пропъртита, като преди името им се слага `#`.  Така не могат да бъдат модифицирани или достъпени отвънка, но само от вътре в класа.

```javascript
class MyClass {
    // Private property
    #privateProperty = 'This is a private property';

    // Private method
    #privateMethod() {
        console.log('This is a private method.');
    }

    // Public method
    publicMethod() {
        console.log('This is a public method.');
        console.log('Accessing private property:', this.#privateProperty);  // Accessing the private property
        this.#privateMethod();  // Calling the private method
    }

    // Getter for private property
    getPrivateProperty() {
        return this.#privateProperty;
    }
}

let obj = new MyClass();
obj.publicMethod();  // Access private property and method via public method

// Accessing private property and method outside the class will result in errors
// console.log(obj.#privateProperty);  // SyntaxError: Private field '#privateProperty' must be declared in an enclosing class
// obj.#privateMethod();  // SyntaxError: Private method '#privateMethod' is not accessible outside class

console.log(obj.getPrivateProperty());  // Access private property via a public getter method
```

Може да имаме комбинация между `static` и `private` пропъртита и методи. Те могат да бъдат достъпени само от вътре в класа и то през статичен публичен метод.

```javascript
class MyClass {
    // Private static property
    static #privateStaticProperty = 'This is a private static property';

    // Private static method
    static #privateStaticMethod() {
        console.log('This is a private static method.');
    }

    // Public static method to access private static property and method
    static publicStaticMethod() {
        console.log('Accessing private static property:', MyClass.#privateStaticProperty);
        MyClass.#privateStaticMethod();

        // Using 'this' keyword works as well
        console.log('Accessing private static property:', this.#privateStaticProperty);
        this.#privateStaticMethod();
    }
}

MyClass.publicStaticMethod();  // Access the private static property and method through a public static method

// Accessing private static property and method outside the class will result in errors
// console.log(MyClass.#privateStaticProperty);  // SyntaxError: Private field '#privateStaticProperty' must be declared in an enclosing class
// MyClass.#privateStaticMethod();  // SyntaxError: Private static method '#privateStaticMethod' is not accessible outside class
```

По подобие на C# и тук може да имаме getters и setters, които са методи.

```javascript
class MyClass {
    #internalProperty = 'internal value';

    // Getter
    get internalProperty() {
        return this.#internalProperty;
    }

    // Setter
    set internalProperty(value) {
        this.#internalProperty = value;
    }
}

let obj = new MyClass();

console.log(obj.internalProperty); // Getting the old value of the internal property

obj.internalProperty = 'new internal value' // Setting the new value of the internal property

console.log(obj.internalProperty); // Getting the new value of the internal property
```

Възможно е да се комбинират `private`, `static` и `get` / `set`.
Към момента в JS няма `protected` модификатор за достъп, както и няма интерфейси.
### Inheritance
Класовете могат да наследяват други класове, като един от новите начини е да се ползва ключовата дума `extends`. 
Извикването на метод или конструктор от базовия клас, става чрез ключовата дума `super`.
Няма модификатор за достъп `protected` в JavaScript (както има в C#), така че трябва да се разчита на други подходи за контрол на достъпа.

```javascript
class Animal {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    makeSound() {
        console.log(`${this.name} is making a generic sound`);
    }

    sleep() {
        console.log('zZz');
    }
}

class Dog extends Animal {
    constructor(name, age, breed) {
        super(name, age); // Calling the Animal class constructor
        this.breed = breed;
    }

    swingTail() {
        console.log(`${this.name} swings his tail!`);
    }

    makeSound() { // Implementing a new version of the Animal class makeSound() method, this is called method overriding
        super.makeSound(); // Calling the base class method
        console.log('Bark!');
    }
}

dog = new Dog('Hero', 5, 'Swiss Shepard');
dog.swingTail(); // Accessing the newly added in the Dog class swingTail() method
dog.makeSound(); // Accessing the Dog class implementation of the makeSound() method
dog.sleep(); // Accessing the inherited sleep() method from the Animal class
console.log(`The name of the dog is ${dog.name}!`); // Accessing the inherited property from the Animal class
```
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
## Arrow Functions and Object Literals

When using arrow functions:

1. **Without `{}`**:
    - The arrow function **automatically returns** the value.
    - If you're returning an object literal, wrap it in parentheses `(...)` to avoid confusion with a code block.
2. **With `{}`**:
    - JavaScript treats `{}` as a **code block**.
    - You must use `return` explicitly to return a value.

**Simple Examples**

1. **Concise Body (Automatic Return):**

```javascript
const result = [1, 2, 3].map(x => ({ number: x })); 
// Returns: [{ number: 1 }, { number: 2 }, { number: 3 }]
```

2. **Block Body (Explicit Return):**

```javascript
const result = [1, 2, 3].map(x => { return { number: x }; });
// Returns: [{ number: 1 }, { number: 2 }, { number: 3 }]
```

3. **What Causes an Error:**

```javascript
const result = [1, 2, 3].map(x => { number: x }); 
// Throws an error because JavaScript thinks it's a code block without a return.
```

## `this` Keyword
The `this` keyword in JavaScript refers to the context in which a function is executed. It is a way to access the object that is currently executing the code, and its value is determined by how a function is called. The value of `this` can vary depending on the situation:

1. **Global Context (Outside any function)**
In the global execution context (i.e., outside of any function or object), `this` refers to the global object.

- In a **browser** environment, `this` refers to the `window` object.
- In **Node.js**, `this` refers to the global object.

```javascript
console.log(this); // In a browser, it logs the window object
```

2. **Inside a Regular Function**
In a regular function (not inside an object), the value of `this` depends on how the function is called.

- In **strict mode** (`'use strict';`), `this` will be `undefined`.
- Without strict mode, `this` refers to the global object (in a browser, the `window` object).

```javascript
function example() {
  console.log(this); // In non-strict mode, it logs the global object (window in the browser)
}

example();
```

3. **Inside an Object Method**
When `this` is used inside a method (a function that is a property of an object), it refers to the object that called the method.

```javascript
const person = {
  name: 'John',
  greet() {
    console.log(this.name); // 'this' refers to the 'person' object
  }
};

person.greet(); // Logs 'John'
```

4. **Inside a Constructor Function (Class/Constructor)**
When `this` is used in a constructor function (or in a class method), it refers to the newly created instance of the object.

```javascript
function Person(name) {
  this.name = name; // 'this' refers to the new object created
}

const john = new Person('John');
console.log(john.name); // 'John'
```

5. **Arrow Functions**
In arrow functions, `this` **does not** have its own context. Instead, it **inherits** `this` from the surrounding (lexical) context. This is often used to maintain the value of `this` from the outer scope.

```javascript
const person = {
  name: 'John',
  greet: function() {
    setTimeout(() => {
      console.log(this.name); // 'this' refers to the 'person' object, not the global context
    }, 1000);
  }
};

person.greet(); // Logs 'John' after 1 second
```

6. **Explicit Binding (call, apply, bind)**
You can explicitly set the value of `this` using the `call()`, `apply()`, and `bind()` methods.

- **`call()`** and **`apply()`**: These methods immediately invoke the function with a specified `this` value.
- **`bind()`**: This method returns a new function with the specified `this` value, but does not invoke it immediately.

```javascript
function greet() {
  console.log(this.name);
}

const person = { name: 'John' };

greet.call(person);  // Logs 'John'
greet.apply(person); // Logs 'John'

const boundGreet = greet.bind(person);
boundGreet();  // Logs 'John'
```

7. **Event Handlers**
When `this` is used inside an event handler, it typically refers to the DOM element that triggered the event.

```javascript
const button = document.querySelector('button');
button.addEventListener('click', function() {
  console.log(this); // 'this' refers to the button element
});
```

8. **Class Methods**
In classes, `this` refers to the instance of the class, i.e., the object created from the class.

```javascript
class Person {
  constructor(name) {
    this.name = name;
  }

  greet() {
    console.log(this.name); // 'this' refers to the instance of the class
  }
}

const john = new Person('John');
john.greet(); // Logs 'John'
```

**Key Points:**
- **Global context**: `this` refers to the global object (`window` in browsers).
- **In methods**: `this` refers to the object the method is called on.
- **In constructors**: `this` refers to the newly created object.
- **Arrow functions**: `this` refers to the surrounding context.
- **Explicit binding**: Use `call()`, `apply()`, or `bind()` to explicitly set `this`.

Understanding how `this` works in JavaScript is essential for managing object-oriented code, handling events, and working with dynamic contexts.
### Behave Like An Object
In JavaScript, **`this`** refers to the **current execution context**, which is the **global object** (e.g., `window` in browsers) in the global scope (non-strict mode). During debugging, **`this`** behaves like an object, containing properties such as global variables. You can inspect its current values just like other objects.

However, **`this`** is a reserved keyword, and you cannot create a variable named `this`. Attempting to do so will result in a syntax error:

```javascript
var this = [1, 2, 3];  // SyntaxError: Unexpected token 'this'
```

The value of **`this`** changes depending on the context:

- In the global scope (non-strict mode), **`this`** refers to the global object (e.g., `window` in browsers).
- Inside a function, **`this`** refers to the object that called the function (or is set explicitly with `call`, `apply`, or `bind`).
- In **strict mode** or **modules**, **`this`** is `undefined` in functions.

For example:

```javascript
var name = 'Pesho';
console.log(this.name);  // 'Pesho' (this refers to the global object)

function example() {
  console.log(this.name);  // undefined, because 'this' refers to the function's context
}
example();
```

In summary, **`this`** behaves like an object that holds global properties, and its value changes depending on the execution context. You can inspect it during debugging, but **`this`** cannot be used as a variable name.
### Debugging - Local / Global Sections
During debugging, the **Local** and **Global** sections capture the **execution context** and show how **`this`** behaves at different points in the code.
- **Global Context (Outside any function)**:
    - When you're not inside any function, you're still in the global execution context.
    - In **Node.js** or similar environments, the **Local section** will contain properties like:
        - `__dirname`: The directory name of the current module.
        - `__filename`: The file name of the current module.
        - `exports`: The object that will be exported from the module.
        - `module`: The current module object.
        - `require`: The function used to import modules.
    - **`this`** in the global context typically points to a generic **`Object`**, not directly to the global object itself (like `window` in browsers). This is why you see `this` pointing to an empty object with `[[prototype]] = Object`.
- **Inside a Function**:
    - **`this`** will behave according to the function's context:
        - In **non-strict mode**, **`this`** will often refer to the global object (in browsers, `window`), or the function's own `this` if it's an object method.
        - In **strict mode**, **`this`** will be `undefined`.

**Debugging Steps:**
1. **Global Context**: When outside a function, the **Local section** will show global properties like `__dirname`, `__filename`, `exports`, `module`, and `require` (in Node.js). **`this`** points to a plain object (`Object`), and you won't directly see the global object (like `window` in the browser) in this context.
2. **Inside a Function**: When inside a function, the **Local `functionName`** section will appear, and **`this`** may point to the global object (non-strict mode) or be `undefined` (strict mode). It will also show **function-specific variables** and will reflect the scope of that function.

**Key Takeaway:**
- In **Node.js** or similar environments, the **Local section** in the debugger outside functions can include additional properties (`__dirname`, `module`, etc.) that are part of the Node.js global context.
- **`this`** in the global context points to an **empty object** (with `[[prototype]] = Object`), not directly to the global object (`window` in browsers).
## Private Field Scope Issue
In JavaScript, when classes are defined inside functions, private fields (denoted with `#`) may unintentionally be accessible across different instances of the class within the same scope. This happens because, despite being defined as private, private fields aren't isolated to individual instances when the class is scoped within a function. This could be seen as a design flaw, as it violates the principle of encapsulation—private fields should only be accessible within their own instance, not from other instances in the same scope. The issue arises due to the flexibility of JavaScript, but it could be addressed by strengthening the encapsulation rules for private fields, especially in function-scoped classes. By defining the class inside the `solve` function, you're essentially putting the class in the local scope of that function. This means all variables (including private fields like `#myPrivateProperty`) are scoped to that function, which might allow some unintended behavior when you try to access the private fields. Normally, private fields are meant to be scoped to individual instances, but this scope collision can cause the JavaScript engine to behave unexpectedly.

Here's a simple example demonstrating the potential issue with private fields in function-scoped classes:

```javascript
function solve() {
    class MyClass {
        #myPrivateProperty = 5;

        constructor(value) {
            this.value = value;
            if (value === 3) {
                this.#myPrivateProperty = 2;
            }
        }

        test() {
            console.log(test2.#myPrivateProperty); // Accessing another instance's private field
        }
    }

    let test = new MyClass(3);
    let test2 = new MyClass(5);
    
    test.test();  // Logs: 5
    test2.test(); // Logs: 5
}

solve();
```

**Explanation:**

- The class `MyClass` defines a private field `#myPrivateProperty`.
- `test` and `test2` are two instances of `MyClass`, but the private field is accessible across instances within the same scope of the `solve()` function.
- This behavior is unexpected because private fields should be isolated to each instance, but the class is scoped inside a function, leading to shared access to private fields across instances.
## Inheritance
In JavaScript, inheritance is a way to create a new class from an existing class, allowing the new class to reuse, modify, or extend the properties and methods of the parent class. This is achieved using the `extends` keyword and the concept of prototypal inheritance. Here's an overview:

1. **Class Inheritance** (ES6+ Syntax)
The `extends` keyword is used to create a subclass that inherits from a parent class.

```javascript
class Animal {
    constructor(name) {
        this.name = name;
    }

    makeSound() {
        console.log(`${this.name} makes a sound.`);
    }
}

class Dog extends Animal {
    constructor(name, breed) {
        super(name); // Call the parent class constructor
        this.breed = breed;
    }

    bark() {
        console.log(`${this.name} barks loudly!`);
    }
}

const dog = new Dog('Rex', 'Labrador');
dog.makeSound(); // Rex makes a sound.
dog.bark();      // Rex barks loudly!
```

2. **Prototype-Based Inheritance**
Before ES6, inheritance in JavaScript was implemented using prototypes.

```javascript
function Animal(name) {
    this.name = name;
}

Animal.prototype.makeSound = function () {
    console.log(`${this.name} makes a sound.`);
};

function Dog(name, breed) {
    Animal.call(this, name); // Inherit properties
    this.breed = breed;
}

// Inherit methods
Dog.prototype = Object.create(Animal.prototype);
Dog.prototype.constructor = Dog;

Dog.prototype.bark = function () {
    console.log(`${this.name} barks loudly!`);
};

const dog = new Dog('Rex', 'Labrador');
dog.makeSound(); // Rex makes a sound.
dog.bark();      // Rex barks loudly!
```

3. **Overriding Methods**
Child classes can override parent methods by defining a method with the same name.

```javascript
class Animal {
    makeSound() {
        console.log('Generic animal sound');
    }
}

class Dog extends Animal {
    makeSound() {
        console.log('Woof!');
    }
}

const dog = new Dog();
dog.makeSound(); // Woof!
```

4. **Accessing Parent Methods**
You can access a parent class's methods using the `super` keyword.

```javascript
class Animal {
    makeSound() {
        console.log('Generic animal sound');
    }
}

class Dog extends Animal {
    makeSound() {
        super.makeSound(); // Call the parent class method
        console.log('Woof!');
    }
}

const dog = new Dog();
dog.makeSound(); 
// Generic animal sound
// Woof!
```

5. **Static Inheritance**
Static methods and properties are inherited by subclasses as well.

```javascript
class Animal {
    static info() {
        console.log('Animals are living beings.');
    }
}

class Dog extends Animal {}

Dog.info(); // Animals are living beings.
```

6. **Prototypal Nature**
Under the hood, even with `class` syntax, JavaScript inheritance relies on prototypes. When a method or property is not found on an object, JavaScript looks up the prototype chain until it finds the method/property or reaches `null`.

**Key Notes:**
- **Single Inheritance**: JavaScript classes support single inheritance, meaning a class can only directly extend one parent class.
- **Mixins for Multiple Behaviors**: To achieve multiple inheritance-like behavior, JavaScript uses mixins (functions or objects that can be shared between classes).
- Parent methods can always be accessed via `super`, but only within the context of child classes.
## Prototypes
In JavaScript, **prototypes** are a mechanism by which objects inherit properties and methods from other objects. Every JavaScript object has an internal link to another object called its **prototype**, which acts as a fallback for property and method lookups. This is part of JavaScript's **prototypal inheritance** system.

1. **Understanding the Prototype Chain**
- Each object has a hidden internal property called `[[Prototype]]`, which can be accessed via the `__proto__` property (though not recommended).
- When you try to access a property or method on an object and it doesn’t exist, JavaScript checks the object’s prototype.
- If the property or method still isn’t found, JavaScript continues up the **prototype chain** until it reaches `null` (the end of the chain).

2. **Prototype in Action**

```javascript
const obj = { name: 'John' };

console.log(obj.toString()); // [object Object]

// 'toString' is not a property of obj, so JavaScript looks in obj's prototype.
// obj's prototype is Object.prototype, which has the toString method.
```

3. **Creating Objects with Prototypes**
You can explicitly set the prototype of an object when creating it using `Object.create`.

```javascript
const animal = {
    makeSound() {
        console.log('Generic animal sound');
    }
};

const dog = Object.create(animal); // dog inherits from animal
dog.bark = function () {
    console.log('Woof!');
};

dog.makeSound(); // Generic animal sound
dog.bark();      // Woof!
```

4. **Prototype Property on Functions**
Every JavaScript function has a `prototype` property, which is used when the function is used as a constructor.

```javascript
function Animal(name) {
    this.name = name;
}

Animal.prototype.makeSound = function () {
    console.log(this.name + ' makes a sound.');
};

const dog = new Animal('Rex');
dog.makeSound(); // Rex makes a sound.
```

The dog object inherits the `makeSound()` method from `Animal.prototype`.

5. **Changing the Prototype**
The `Object.setPrototypeOf` method allows you to change the prototype of an existing object.

```javascript
const animal = {
    makeSound() {
        console.log('Generic animal sound');
    }
};

const dog = { bark: () => console.log('Woof!') };

Object.setPrototypeOf(dog, animal);

dog.makeSound(); // Generic animal sound
dog.bark();      // Woof!
```

6. **Prototype Inheritance in Classes**
In ES6 classes, prototypes are used under the hood for inheritance.

```javascript
class Animal {
    makeSound() {
        console.log('Generic animal sound');
    }
}

class Dog extends Animal {
    bark() {
        console.log('Woof!');
    }
}

const dog = new Dog();
dog.makeSound(); // Generic animal sound
dog.bark();      // Woof!
```

7. **Prototype Chain Diagram**
Here’s a simplified prototype chain for an object:

```javascript
dog -> Animal.prototype -> Object.prototype -> null
```

8. **Key Points About Prototypes**
- **Prototype Sharing**: Methods defined on the prototype are shared among all instances of the object.
- **Avoid Overuse**: Directly modifying `__proto__` or the prototype chain dynamically can hurt performance and is generally discouraged.
- **Custom Methods**: You can extend built-in prototypes like `Array` or `String`, but this is also generally discouraged as it can lead to conflicts.

**Summary**
Prototypes are a core concept in JavaScript’s object model. They allow objects to share behavior and support the inheritance system, enabling features like method sharing and prototype chains. Understanding prototypes is key to mastering JavaScript inheritance and object behavior.
## Anonymous Objects
Declaring objects in JavaScript is conceptually similar to creating **anonymous objects** in C#. Here's a comparison:

**JavaScript Objects**
In JavaScript, you can declare an object using curly braces `{}`. These objects can have properties and methods, and their structure is defined directly when you create them.

```javascript
let person = {
    name: "John",
    age: 30,
    greet: function() {
        console.log(`Hello, my name is ${this.name}`);
    }
};
```

**C# Anonymous Objects**
In C#, you can create **anonymous objects** using the `new {}` syntax. These objects are immutable and used often in LINQ queries or quick encapsulations.

```csharp
var person = new 
{
    Name = "John",
    Age = 30
};

// Accessing properties
Console.WriteLine($"Hello, my name is {person.Name}");
```

**Key Differences**

1. **Mutability**
- **JavaScript**: Objects are mutable; you can add, modify, or delete properties dynamically.
- **C#**: Anonymous objects are immutable; their properties can't be changed after creation.
2. **Methods**
- **JavaScript**: Objects can have methods directly assigned as properties.
- **C#**: Anonymous objects do not support methods; you can only define properties.
3. **Usage Context**
- **JavaScript**: Objects are a fundamental building block, used everywhere in the language.
- **C#**: Anonymous objects are typically used for temporary data encapsulation or query projections, not as a general-purpose structure.

**Analogy**
Think of JavaScript objects as **dynamic anonymous objects** that you can freely modify, whereas C# anonymous objects are **fixed snapshots** of data.
## Scope
Scope determines **where variables, functions, and objects are accessible** in your code. It defines the boundaries or context within which a piece of code can reference a variable or function.

**Types of Scope in JavaScript**
1. **Global Scope**
    - Variables declared **outside of any function or block** are in the global scope.
    - These variables can be accessed from anywhere in your program.

    **Example:**
    
```javascript
let globalVar = 'I am global';

function printGlobal() {
    console.log(globalVar); // Accessible here
}

printGlobal(); // Logs: 'I am global'
console.log(globalVar); // Logs: 'I am global'
```
    
2. **Function Scope**
    - Variables declared inside a function are only accessible within that function.
    - These variables are created when the function is called and destroyed when it finishes execution.
    
    **Example:**
    
```javascript
function exampleFunction() {
    let functionScopedVar = 'I am inside the function';
    console.log(functionScopedVar); // Logs: 'I am inside the function'
}

exampleFunction();
console.log(functionScopedVar); // Error: functionScopedVar is not defined
```
    
3. **Block Scope** (Introduced with `let` and `const` in ES6)
    
    - Variables declared inside a block (`{}`) are only accessible within that block.
    - A block can be part of a function, a loop, or an `if` statement.
    
    **Example:**
    
```javascript
{
    let blockScopedVar = 'I am block scoped';
    console.log(blockScopedVar); // Logs: 'I am block scoped'
}

console.log(blockScopedVar); // Error: blockScopedVar is not defined
```
    
4. **Lexical Scope**
    
    - Variables are accessible based on where they are declared in the **source code**, not where they are executed.
    - This means inner functions can access variables from their **parent scope**.
    
    **Example:**
    
```javascript
function outerFunction() {
    let outerVar = 'I am in the outer scope';

    function innerFunction() {
        console.log(outerVar); // Accessible here
    }

    innerFunction(); // Logs: 'I am in the outer scope'
}

outerFunction();
```
    
5. **Module Scope** (Introduced in ES6 Modules)
    
    - Variables declared in an ES6 module file are scoped to that file. They are not accessible in other files unless explicitly exported.
    
**Example (File A):**
    
```javascript
export let moduleVar = 'I am in the module';
```

**Example (File B):**

```javascript
import { moduleVar } from './FileA.js';
console.log(moduleVar); // Logs: 'I am in the module'
```

**Key Concepts in Scope**

1. **Hoisting**

    - Variables declared with `var` are "hoisted" to the top of their scope, but their value is `undefined` until the assignment.
    - Variables declared with `let` and `const` are also hoisted, but they remain in a "temporal dead zone" and are not accessible until their declaration is encountered.
    
    **Example:**
    
```javascript
console.log(x); // undefined
var x = 10;

console.log(y); // Error: Cannot access 'y' before initialization
let y = 20;
```
    
2. **Closure**
    
    - A closure is created when an inner function "remembers" variables from its outer scope, even after the outer function has finished executing.
    
    **Example:**
    
```javascript
function outerFunction() {
    let count = 0; // This is a variable in the outer scope

    return function innerFunction() {
        count++; // The inner function uses the 'count' variable
        return count; // The inner function "remembers" the variable
    };
}

let counter = outerFunction(); // outerFunction runs, and innerFunction is returned
console.log(counter()); // 1
console.log(counter()); // 2
console.log(counter()); // 3
```

3. **The Global Object**
    
    - In browsers, variables declared globally become properties of the `window` object (if not using `let` or `const`).
    - Avoid polluting the global scope as it can lead to bugs.
    
    **Example:**
    
```javascript
var globalVar = 'I am on the window';
console.log(window.globalVar); // 'I am on the window'
```

**Analogy for Scope**

Think of scope as **rooms in a house**:

- **Global scope** is like the **living room**, where everyone has access.
- **Function scope** is like a **bedroom**, where only the occupant (function) has access.
- **Block scope** is like a **closet** inside a room, accessible only to people inside that specific room.
- **Lexical scope** is like a window—you can see outside and access what's there, but people outside can't see into your private room.
### Explaining the Scope of Closures
```javascript
function outerFunction() {
    let count = 0; // This is a variable in the outer scope

    return function innerFunction() {
        count++; // The inner function uses the 'count' variable
        return count; // The inner function "remembers" the variable
    };
}

let counter = outerFunction(); // outerFunction runs, and innerFunction is returned
console.log(counter()); // 1
console.log(counter()); // 2
console.log(counter()); // 3
```

**Step 1:** `outerFunction` is called.
    - Inside `outerFunction`, the variable `count` is created with the value `0`.
    - `outerFunction` then **returns `innerFunction`** (but doesn't execute it yet).
**Step 2:** Assign the returned `innerFunction` to `counter`.
    - Now, `counter` is essentially the `innerFunction`, but it "remembers" the `count` variable from `outerFunction`.
**Step 3:** Call `counter()` multiple times.
    - Each time `counter()` is called, it:
        1. **Accesses** the `count` variable (still "remembered").
        2. Increments the value of `count`.
        3. Returns the new value of `count`.
4. Even though `outerFunction` has finished executing, the variable `count` is still "alive" because `innerFunction` keeps a **reference** to it. This is the **closure**.

**Simpler Analogy**

Imagine you’re in a house:

- **Outer function:** This is the **kitchen** where a cookie jar (`count`) exists.
- **Inner function:** You take the cookie jar out of the kitchen and keep it with you. Now you can still **use the jar and add cookies** even after you leave the kitchen.

The inner function (`counter`) still remembers where the cookie jar (`count`) came from, even if the kitchen (outer function) is locked up.

**Why Are Closures Useful?**

Closures allow you to:

**Preserve state:** Like in our example, `count` persists between function calls.
**Create private variables:** Variables in the closure scope are not directly accessible from outside.
**Encapsulate functionality:** Closures are widely used in event handlers, callbacks, and module patterns.

**Do Closures Always Require Two Functions?**

Closures conceptually **require two scopes**:

1. The **outer scope** (to declare the variables to be captured).
2. The **inner scope** (to use and "remember" those variables).

This is why you always see two functions in closure examples. However, they don’t always have to be **explicitly nested**.

**Closures Without Explicit Nesting**

Sometimes, closures can occur in less obvious forms.

**Example in C# LINQ:**

```csharp
var numbers = new[] { 1, 2, 3 };
int multiplier = 2; // Outer scope variable

var query = numbers.Select(x => x * multiplier); // Lambda creates a closure
foreach (var result in query)
{
    Console.WriteLine(result); // Outputs: 2, 4, 6
}
```

- The lambda `x => x * multiplier` captures `multiplier` from the outer scope.
- Even though `Select` executes later, it still "remembers" the `multiplier` variable.

Here, the **outer function** is implicit (the scope containing `multiplier`), but the same principles of closure apply.

**Why Closures Retain Variables**

Closures work because the **inner function keeps a reference** to the variables of the outer function, not a copy. This reference ensures the variables remain alive as long as the inner function exists.

- In JavaScript: The inner function remembers the outer scope's **execution context**.
- In C#: The compiler generates a **hidden class** (closure object) to store the captured variables.

**Final Takeaway**

To create a closure:

1. Define an **outer function** that initializes variables.
2. Define an **inner function** that uses those variables.
3. **Return the inner function** from the outer function.

This pattern ensures that variables in the outer function’s scope are remembered and can be modified by the inner function, even after the outer function has exited.
## Context
In programming, **context** generally refers to the environment in which code is executed. Specifically, in JavaScript, **context** most often refers to the value of the special variable `this`, which is determined by how a function is called or invoked.

Here’s a more detailed explanation of **context** in different programming scenarios:

**1. In JavaScript: Context is About `this`**

In JavaScript, the context is tied to the value of the `this` keyword. The value of `this` is determined by **how** a function is called, and it can refer to different objects depending on the invocation.

**How `this` Works (Execution Context):**

- **Global Context:** When a function is called in the **global scope**, `this` usually refers to the global object. In a browser, it’s typically the `window` object.

```javascript
function globalContext() {
    console.log(this); // In a browser, 'this' refers to the window object
}
globalContext();
```

- **Object Context:** When a function is called as a method of an object, `this` refers to the object the function is called on.

```javascript
const person = {
    name: 'Alice',
    greet: function() {
        console.log(this.name); // 'this' refers to the 'person' object
    }
};
person.greet(); // 'this' is the person object, so 'this.name' is 'Alice'
```

- **Constructor Context:** When a function is used as a constructor (using the `new` keyword), `this` refers to the newly created object.
 
```javascript
function Person(name) {
    this.name = name;
}

const john = new Person('John');
console.log(john.name); // 'this' refers to the new 'john' object, so 'john.name' is 'John'
```

- **Explicit Binding (`call`, `apply`, `bind`):** JavaScript allows you to **explicitly set the context** using methods like `call()`, `apply()`, and `bind()`.
  
```javascript
function greet() {
    console.log(this.name);
}

const person = { name: 'Alice' };
greet.call(person); // Explicitly sets 'this' to the 'person' object
```

**2. Context in Other Languages:**

While the term "context" is most commonly used in JavaScript in relation to `this`, other programming languages may use it to refer to the environment in which code executes, or the set of available variables, objects, or data.

**In C#:**

Context often refers to **the current execution environment**, which can include things like:

- **Execution Context:** The state of the program at a particular point in time (e.g., which method is being called, which object is being referenced).
- **Synchronization Context:** A special object used in asynchronous programming (like in `async` methods) to manage thread synchronization.

For example, in **asynchronous programming**, the **synchronization context** ensures that a continuation (like updating the UI) happens on the correct thread.

**3. Context in Closures:**

In closures (especially in JavaScript), context refers to the environment (or the scope) in which a function is created and executed. It often refers to how variables are captured by the inner function and how `this` behaves when the inner function is invoked.

For example:

```javascript
function outerFunction() {
    let outerVar = 'I am outside';
    return function innerFunction() {
        console.log(outerVar); // inner function has access to outerVar because of the closure
    };
}

const closure = outerFunction();
closure(); // 'I am outside' is remembered in the closure, even after outerFunction finishes
```

In this example, the **context** of `innerFunction` refers to the scope where `outerVar` was declared, and even though `outerFunction` has finished executing, the inner function still has access to its variables.

**4. General Context in Programming:**

Beyond JavaScript, **context** can refer to:

- The **execution environment** of a program.
- The **state** of a program when a certain operation occurs.
- The **variables, parameters, and conditions** under which a function or block of code operates.

For instance, in Python, the context can refer to the **call stack** or the **namespace** that holds the variables and functions during execution.

**Summary of Context in Programming:**

- **In JavaScript:** The context is most commonly about the value of `this`, and it is determined by how a function is called.
- **In general programming:** Context refers to the environment and state in which code is executed, including the variables, objects, or execution flow at that time.
### Capturing The Context During Debugging
During debugging, the **Local** and **Global** sections capture the **execution context** and show how **`this`** behaves at different points in the code. Here's how this works:

Debugging Context Captured:

1. **Local Section**:
    
    - The **Local section** displays the **variables and state** specific to the current scope.
        - Outside of functions (in the global context), this section will show global variables, objects, and runtime-specific properties (like `__dirname`, `exports` in Node.js).
        - Inside a function, the **Local section** will show **function-specific variables** and will reflect the scope of that function.
2. **Global Section**:
    
    - The **Global section** shows the properties of the **global object** (e.g., `window` in browsers or `global` in Node.js).
    - This section allows you to inspect global variables and functions available in the environment.
3. **Closure Section** (if visible):
    
    - If you're dealing with **closures**, you might see a **Closure section** that shows **variables from the outer scope** that are captured by the inner function, even after the outer function has executed.
    - This section highlights how closures maintain access to variables outside their scope, allowing the inner function to "remember" these values.

**Key Points:**

- **Execution Context**: During debugging, the **Local** and **Global** sections represent different levels of the **execution context**:
    - **Local**: Current scope (global or function-specific).
    - **Global**: Global scope and properties.
- **Closure Section**: If a closure is involved, you'll see a **Closure section** that helps track the captured variables from the outer function's scope.

**Conclusion:**

- Yes, these sections in the debugger effectively **capture and represent the execution context** at different points in your code.
- They help you understand the current state of variables and **how `this` behaves** based on where you are in the code (global scope, function, or closure).
## Scope / Context Relation
**Scope** refers to the **visibility and lifetime** of variables or functions. It determines where in your code a particular variable or function can be accessed or used.

- **Local Scope:** A variable or function is accessible only within the block of code where it’s defined (e.g., inside a function or a loop).
- **Global Scope:** A variable or function can be accessed anywhere in the program.
- **Lexical Scope:** The scope in which a function is defined. This is important in closures because the inner function retains access to the variables in the outer scope where it was created.

**Example of Scope:**

```javascript
let x = 10;  // Global scope

function foo() {
    let y = 20; // Local scope of function foo
    console.log(x); // x is accessible here
    console.log(y); // y is accessible here
}

foo();

console.log(x); // Accessible outside foo, because x is in the global scope
console.log(y); // Error! y is not accessible outside foo
```

**Context**, on the other hand, refers to the **environment** in which a function is executed. This often involves the **value of `this`** inside a function, which can change depending on how the function is invoked.

- In JavaScript, **`this`** refers to the **execution context** of the function. It can point to different objects depending on how the function is called (e.g., method of an object, global context, or explicitly set with `bind()`, `call()`, or `apply()`).

**Example of Context:**

```javascript
function myFunction() {
    console.log(this); // 'this' refers to the context in which the function is called
}

myFunction(); // In the global context, 'this' refers to the global object (window in browsers)

const obj = {
    name: 'Object Context',
    myMethod: myFunction
};

obj.myMethod(); // 'this' refers to the 'obj' object because the method is called on 'obj'
```

**Key Differences:**

- **Scope** is about **where** a variable is accessible (its visibility), while **context** is about **what** an expression or function refers to during execution (usually through `this`).
- **Scope** is determined at the time of **function creation** (lexical scoping), while **context** is determined at the time of **function execution**.

**Analogy:**

- **Scope** is like the **room** where you can use certain items (variables). If the item is in a specific room, you can access it only when you're in that room.
- **Context** is like the **owner of the room**. Depending on who enters the room (the function call), the room’s **owner** (context) might change, but the objects in the room (variables) are still the same.

Conclusion:

- **Scope** controls **what variables** are available in which part of your code.
- **Context** controls **what `this` refers to** during function execution.

Though they often intersect (especially in closures), they are separate concepts that serve different purposes in understanding how code behaves.
# Bookmarks
Completion: 15.11.2024