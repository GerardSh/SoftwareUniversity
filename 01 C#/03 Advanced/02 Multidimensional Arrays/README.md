# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#Multidimensional%20Arrays)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#Multidimensional%20Arrays.)

## Multidimensional arrays
Многомерните масиви, са всъщност таблица от редове и колони или иначе казано, масив от масиви.
Дефинират се както обикновен масив, с разликата че се добавя запетая в квадратните скоби `[,]` където от лявата страна са броя на редовете, а от дясната е тяхната дължина, тоест колоните. Примерно, многомерен масив `[5,5]` може да бъде репликиран с 5 обикновени масива от по 5 елемента.

Всички принципи и правила за работа с обикновените масиви, важат и при многомерните. За да достъпим даден елемент, трябва да посочим на кой ред и колона се намира. Първия елемент е винаги `[0,0]` а последните при масив с 5 реда и 5 колони е `[4,4]`, защото и при редовете и при колоните, броенето започва от 0.

Ако искаме да добавим трето измерение или повече, трябва да сложим още една запетайка в скобите. Примерно, ако имаме книга от 1000 страници, с 40 реда всяка и 20 колони и искаме да намерим къде се намира дадена буква в нея, то трябва да знаем на коя страница се намира, на кой ред и на коя колона. Което представено в масив би изглеждало така - `new book char[1000,40,20]`. Ако ни трябва втората буква, която се намира на трета страница, трети ред, то трябва да достъпим индекс `book[2,2,1]`

Веднага след като инициализираме даден многомерен масив, както и при обикновения, всичките му елементи биват достъпни и напълнени с default стойности, ако не сме им задали такива.

Когато имаме една променлива, имаме 0 измерения, когато имаме масив, едно измерение, двумерен масив - две измерения и тн. При обикновен масив, това в геометрията е все едно да имаме една черта и дадена точка, която може да бъде разположена навсякъде по чертата. При многомерен масив от две измерения, това е все едно да имаме една равнина, където точката може да се движи във всички посоки. А при триизмерен масив, все едно имаме равнина но и с дълбочина.

В математиката матрица е многомерен масив, а вектор е едномерен.

Инициализиране:
```
int[,] table = {
    {1, 2, 3, 4}, // row 0 values
    {5, 6, 7, 8}  // row 1 values
};
```

Rank - означава да вземем броя на измеренията, има го като property.

Записването на информация в многомерния масив, става само с for цикли - колкото измерения имаме, толкова for-a.
## Jagged arrays
Назъбените масиви, са масиви от масиви и се декларират с допълнителни квадратни скоби. Всеки от вътрешните масиви, трябва да се инициализира, преди да може да се ползва.
Достъпването и присвояването на елементите става с две последователни квадратни скоби, където първо посочваме индекса на масива и после индекса на елемента в него:
```
string[][] jaggedArray = new string[10][];
jaggedArray[0] = new string[4];
jaggedArray[1] = new string[5];
jaggedArray[2] = new string[3];

jaggedArray[1][2] = "test";

Console.WriteLine(jaggedArray[1][2]);
```

foreach връща масив като елемент.

Основната разлика с многомерните масиви е, че тук всеки ред може да има различна дължина и трябва да се инициализира преди да може да се ползва, докато при многомерните масиви, всички редове имат еднаква дължина и са инициализирани при създаването на масива.
# Misc
Когато инициализираме масив/матрица в C#, то паметта която се отделя в РАМ-а е занулена, тоест цялата останала информация на този блок памет се изтрива и се заменя с default стойностите на типа масив, който създаваме. Ако е целочислен това е 0, string и обекти е null. Примерно в C++, след като сме ползвали дадена променлива и повече няма да ни трябва, то трябва да я занулим сами.

В assembly цялата РАМ се явява масив и имаме достъп до паметта, по индекс. Ръчно трябва да си заделяме и следим пространство за масив, къде започва и къде свършва и тн.

Interoperability - през interop, програми написани на различни езици, могат да си комуникират.
# ChatGPT

# Bookmarks 
[Console Game Live Demo - Tetris Part 1 - Николай Костов - YouTube](https://www.youtube.com/watch?v=_-JyqwaLjVM)

[Console Game Live Demo - Tetris Part 2 - Николай Костов - YouTube](https://www.youtube.com/watch?v=lWsm3ZTSnt0)

[Console Game Live Demo - Tetris Part 3 (Final) - Николай Костов - YouTube](https://www.youtube.com/watch?v=VBxFekjsGPc)

[C# OOP - Tetris with OOP - Part 1 - октомври 2019 - Николай Костов - YouTube](https://www.youtube.com/watch?v=SmDNHr3uL-E)

[C# OOP - Tetris with OOP - Part 2 - октомври 2019 - Николай Костов - YouTube](https://www.youtube.com/watch?v=v2mEpgxSB6A)

[C# OOP - C# Tetris with OOP - Part 3 - октомври 2019 - Николай Костов - YouTube](https://www.youtube.com/watch?v=IjO38LeZuHY)

[Бонус: Игра Тетрис - част 1](https://softuni.bg/trainings/resources/video/64702/bonus-creating-tetris-part-1-csharp-advanced-september-2021/3483)

Course completion: 12.04.2024
