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
# Bookmarks 

Completion: 15.11.2024