# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#)

## Linked List

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240507091326.png)

Свързания списък е списък от елементи без индекси, които имат наредба - всеки елемент има дадена стойност, знае кой е неговия следващ и предишен елемент, като последния няма следващ, което се нарича null, а първия няма предишен. Винаги има връзка между елементите от първия до последния.

При едносвързан списък, елементите знаят само кой е следващия елемент. При него добавянето на елемент в началото е бърза операция, но премахването на елемент в края не е бързо. Той е идеалната имплементация на структурата данни Stack. Чрез двойно свързан списък, може да имплементираме структурата данни Queue.

За свързания списък, знаем две важни неща, кой е първия елемент и кой е последния. 
Добавянето на нов първи елемент става като направим нов елемент и го правим да сочи към предишния първи, а предишния да сочи към новия първи.

Двойно свързания списък е сходен със списъка, но с предимството, че премахването и добавянето на елементи в началото и края е много по-бързо, имат константна сложност и точно поради това го използваме. Не в средата или достъпването на произволна позиция, но в началото и края.

Използваме списък, защото взимането на елемент по индекс е с константна сложност, докато в свързания списък е от по-бавните операции.
## Generics
На един клас може да подаваме типове данни с които да работи и да стане template-ен клас:
` class Dog<T>`
Типа данни, става place holder, който се замества навсякъде в кода на класа, където поискаме.

```
  public class Dog<T>
    {
        public Dog() { }

        public string Name { get; set; }

        public T Value { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Dog<string> dog = new Dog<string>();       
        }
    }
```

Може да имаме class members от тип `T`, в примера горе `Value`. Kогато се създаде обект от тип `Dog`, `Value` ще бъде от типа данни подадени вътре в триъгълните скоби - string. `
# Misc
Test driven development - разработка на код, при която сме написали първо теста и поведението, което очакваме и после на база на написаното като тест, сверяваме дали написаното работи коректно.

Ако искаме да запазим ключова дума, примерно class като име на променлива, трябва да сложим `@` пред името: `int @class = 5;`
## Algorithm complexity

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240507094606.png)

Сложността на даден алгоритъм се определя от колко стъпки са нужни спрямо `n` - броя входни данни / елементи в масива и тн. 
Най-бързите са първите. 
Тези които правят няколко стъпки без да зависят от броя на елементите и да правят цикли са на първи ред в ляво а тези за двоично търсене са в дясно.
За линейно търсене са на втори ред в ляво, а всички сортиращи алгоритми са в дясно.
На трети ред е когато имаме матрици и трябва да ги обходим и тн.
## Garbage Collector
Когато заделяме памет за дадени променливи и в един момент спрем да ги ползваме, те трябва да бъдат изчистени от паметта и се наричат garbage. 
В езици като C++, за всяка референтна променлива която е направена и вече не се ползва, програмиста трябва да я изчисти с delete. Ако не се изчисти, се получават memory leaks, тоест неизчистена памет, която не може да се ползва. 
В C# процесът на изчистване е автоматизиран чрез GC, той минава и търси неща към които никой не сочи и няма да се използват в бъдеще. GC има вградени алгоритми за търсене, които отбелязват дадени неща като боклук и за изтриване. 
В три различни ситуации GC минава и освобождава маркираната памет, тоест прави delete вместо нас. 
Няма сценарии в който GC да изтрие нещо, което ще ползваме.
Първата ситуация е когато паметта на компютъра е намаляла, спира програмата за много кратко време, изчиства всичко и програмата продължава нататък.
Втората ситуация е когато ние го извикаме чрез метода `GC.Collect()`
Третата ситуация е когато направим много пъти `new`  или по негов алгоритъм прецени че е време да мине.

GC се занимава само с динамичната памет, статичната сама се менажира и самопочиства.
Разделя обектите на четири категории:

LOH - large object heap, големи обекти които са над определен размер.

L0 / gen0 - Oldest

L1 / gen1 - Medium

L2 / gen2 - Newest

Нещата в L2 са най-динамични и на-бързо влизат и излизат. Когато даден обект се задържи повече време, се измества в предишното ниво. Когато нещо се задържи по-дълго време, има по малка вероятност да бъде изчистено. GC работи най-много в L2 и най-малко в LOH.

Във всяко ниво има локатор за памет и когато някой поиска памет се заделя такава. В един момент дадена памет се освобождава и остава дупка в паметта и GC дефрагментира паметта и мести заетата памет на едно място и отново мести локатора на първата свободна памет. Това е нещо като масив с елементи, но с различна големина и като се махне даден елемент, задължително се пренареждат другите, за да няма дупки.
Заделянето на памет в C# е бързо, защото GC си дефрагментира паметта, когато е необходимо и си пази свободна памет, която е последователна и голяма. Когато някой поиска да задели памет, GC веднага я дава и мести локатора за памет.
# ChatGPT
## Class Indexer
An indexer in C# is a feature that allows instances of a class to be accessed as if they were arrays. It enables you to define special properties within a class that can be accessed using square brackets `[ ]`, similar to array access syntax. These properties are called indexers.

Indexers provide a way to access elements of a class based on an index or key, allowing you to encapsulate the logic for accessing elements within the class itself. They can be used to provide indexed access to collections, data structures, or other types of data within a class, enabling more intuitive and readable code.

ChatGPT

Sure! Here's a summary of our conversation about indexers:
1. **Introduction to Indexers**: We discussed that indexers in C# are special properties that allow instances of a class to be accessed as if they were arrays, using square brackets `[ ]`.
2. **Defining an Indexer**: I explained how to define an indexer within a class using the `this` keyword followed by the index parameters in square brackets `[ ]`.
3. **Usage of Indexers**: We talked about how indexers are commonly used to provide indexed access to elements of collections, but they can also be used in various other scenarios where indexed access to elements is needed.
4. **Example of Custom Indexer**: You provided an example of a custom indexer that provides indexed access to characters within a string, demonstrating that indexers can be used even without a collection.

Overall, indexers are a versatile feature in C# that enhance the usability and readability of your code by providing a familiar syntax for accessing elements within objects.

You
```
        public int this[int i]
        {
            get => items[i]; 
            set => items[i] = value;
        }
```
Here `this[int i]` is taking the place of the name when its a standard property?

ChatGPT

Yes, precisely. In C#, `this[int i]` is the syntax used to define an indexer property. Instead of a standard property name, indexers use this syntax followed by the index parameters in square brackets `[ ]` to allow indexed access to elements of the class. This allows instances of the class to be accessed using square brackets `[ ]`, just like arrays, providing a convenient way to interact with elements within the class.
## Class Properties
You
The property just contains methods that retrieves and sets the value of a private field, it does not contain any value on its own right? when we change the private field, we can notice during debugging that the property also changes value, its because its always in sync with the private field, so whatever value the private field has it is immediately syncing with what the property shows?

ChatGPT

Yes, you're correct. In C#, properties are syntactic sugar over methods. When you define a property, you're essentially defining two methods, a getter and/or a setter, that allow you to retrieve and modify the value of a private field.

So, when you observe that a property's value changes when you modify the private field it corresponds to, it's because the property's getter method is returning the current value of that private field. This means that the property and the private field are always in sync, as you described.

```
public class MyClass
{
    private int myField;

    public int MyProperty
    {
        get
        {
            return myField;
        }
        set
        {
            myField = value;
        }
    }
}
```

In this example, `MyProperty` is a property with a private field `myField` as its backing store. When you access `MyProperty`, you're actually calling the getter method, which returns the current value of `myField`. Similarly, when you set `MyProperty`, you're calling the setter method, which assigns the new value to `myField`.

So, as you modify `myField`, the changes are reflected in the property because the getter method always returns the current value of `myField`. This ensures that the property and the private field are always synchronized.

You

By showing the property in the debugging window, it executes the getter on every step of the code to return the value of the field?

ChatGPT

Yes, that's correct. When you view a property in the debugging window, the debugger is executing the getter method associated with that property. This means that it's retrieving the current value of the private field associated with the property.

So, during debugging, whenever you see the value of a property displayed, it's actually the result of executing the getter method, which returns the current value of the private field. This allows you to observe the state of your object, including the values of its properties, as your code executes.

You

The getter execution happens in the background, without calling the get method explicitly?

ChatGPT

Yes, that's correct. During debugging, when you view the value of a property, the debugger automatically executes the getter method associated with that property in the background, without you needing to explicitly call the getter method in your code.

This is part of the functionality provided by the debugger to help you inspect the state of your program. The debugger retrieves the value of the property by executing its getter method and displays the result in the debugging window, allowing you to observe the current state of your object.
# Bookmarks 

Course completion: 09.05.2024
