# General
[Methods Stack](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#Stack)

[Methods Queue](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#Queue)

[Commands Stack](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#Stack)

[Commands Queue](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#Queue)

При линейните структури от данни каквито са списъците и масивът, елементите са разположени последователно, като всеки елемент при тях е и индексиран/номериран. 

Новите линейни структури от данни в тази лекция са:
`Stack<t>` - (LIFO - last in, first out) - аналогията е на купчина чинии една върху друга, когато започнем да ги махаме, почваме от последната.
`Queue<t>` - (FIFO - first in, first out) - който дойде първи на опашката, първи ще бъде обслужен и ще си тръгне.

При стековете и опашките последователността на елементите не е толкова важна, там е важно кой елемент е влезнал последен и кой първи.
При тях пак добавяме елементите най-отзад, но при стековете нямаме достъп до предишните елементи, а само до последните, при опашките имаме достъп само до първия елемент, но не и следващите.
Това е и основната разлика със списъците, като реално стековете и опашките имат по-малко операции, но пък се извършват бързо Добавянето и махането на елементи е в точно определен ред, но е много бързо.

Вкарване на елемент при стека се нарича Push, махането е Pop, при опашката се нарича Enqueue, махането Dequeue.

Компютърната памет, също е разположена линейно, като един огромен масив и си има последователност и номерация, точно както масива, като част от него, се заделя за нашата програма.

Идемпотентна операция е тези която колкото и пъти да направим, не променя резултата си. Нещата отдолу имат логика която ползваме, те извикват друга логика и така до най-ниско ниво. Примерно ако ползваме open file което е специален метов в C#, а той извиква специален метод от операционната система Win32, който извиква специален метод от драйвера за файловата система, който на ниско ниво слиза и казва на хард диска какво да направи. Затова се нарича абстракция, пишейки на C# работим на почти най-високото ниво и нещата отдолу са вече готови, написани и проверени. Ако трябва да напишем от нула отварянето на файл, ще стане с хиляди редове, а не с един.
# Misc
Всяко нещо което може да бъде направено чрез рекурсия, може да бъде постигнато и чрез стек.

Кода който пишем в C# е на високо ниво, тоест стъпваме на готов код, който вече е написан.

C# е стек-ов език. 

Масива е базова структура, която представлява последователност от адреси в паметта на компютъра.

IEnumerable е интерфейс - който ни казва, какво може да прави дадената колекция. В дадения случай, означава че може да бъде foreach-ната. Можем да проверим дадена колекция, какви интерфейси имплементира в документацията, примерно Stack - [Stack Class (System.Collections.Generic) | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-8.0)

foreach е най-лесния начин да проверим стойностите на елементите в даден стек или опашка.

Разликата между Generic collection  като `Stack<T>` и просто `Stack` е че в Generic ние определяме типа на колекцията на мястото на `<T>` , докато Non-Generic е от тип object. Всички типове в C# наследяват object, но това не е удобно за работа когато ползваме колекция. Компилатора, не може да проверява грешките, които може да допуснем и доста други усложнения. MS препоръчват да се ползват само generic collections.
# ChatGPT
## Stack indexing
Isn't it more logical and natural that the last added element in the stack is residing on the last index in the internal array not the first 0?

ChatGPT
Yes, you're correct in the logical sense. Placing the most recently added element at the end of the internal array for a stack would align more with the natural flow of adding elements to a stack. Similarly, for a queue, it would make sense to have the first element added at the beginning of the internal array and subsequent elements placed further towards the end.

However, the choice of implementation details, including the arrangement of elements within the internal array, can vary based on factors such as performance considerations, memory management, and ease of implementation. In some implementations, it may be more efficient to manage the internal array in a way that the most recently added element is at index 0 for a stack or at the end for a queue.

While it might seem more intuitive to have the last added element at the end of the array, the choice of internal representation doesn't affect the external behavior of the stack or queue as long as the required operations (`Push`, `Pop` for `Stack`; `Enqueue`, `Dequeue` for `Queue`) are provided and work as expected.
## T[] array
what is t[] array in C#

ChatGPT
In C#, `T[]` represents a generic array type where `T` is a placeholder for any valid C# data type. This notation allows you to define arrays that can hold elements of a specific type, which can be specified when declaring or creating the array.
# Bookmarks 
Два много основополагащи курса на Николай Костов:

[High-Quality Code - YouTube](https://www.youtube.com/playlist?list=PLf5IBVXYNTwJO9dE-XR9-iKbp_kw3_ZQy)

[Data Structures and Algorithms - YouTube](https://www.youtube.com/playlist?list=PLf5IBVXYNTwLwDCbpFtQLj1_587a3asv5)

Web Basics курс:

[C# Web Basics - Workshop - Web Application. Advanced CSS - Bootstrap - май 2019 - Николай Костов - YouTube](https://www.youtube.com/watch?v=iG2UBr2fAqg&list=PLg6sCysjxHi2V49e08g5UPLTME8MOzRsc&index=1)

Полезна лекция как работи интернет, пак на Николай Костов:

[Internet Explained - YouTube](https://www.youtube.com/watch?v=1pSsIlU3T-s)

Бонус задача от текущата лекция:

[Бонус: Решаване на математически изрази със стекове - Софтуерен университет](https://softuni.bg/trainings/resources/video/64613/bonus-evaluate-math-expressions-using-stacks-csharp-advanced-september-2021/3483)

[Решаване на математически изрази със C# - YouTube](https://www.youtube.com/watch?v=3QOM0HJmakE&t=2s)

Course completion: 26.03.2024
