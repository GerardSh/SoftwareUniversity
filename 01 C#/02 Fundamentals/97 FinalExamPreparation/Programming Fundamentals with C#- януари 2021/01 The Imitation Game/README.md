# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#String)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#String)

Стринга е поредица от символи. 

Ключовата дума string в C# map-ва към System.String в .Net платформата, която се състои и от други езици.

Когато една от операндите в даден expression e string, то + започва да ги конкатенира.

Всеки тип в езика C# наследява типа object. Има 4 основни метода, които всеки обект наследява, един от тях е `ToString()`, тоест абсолютно всеки обект в езика, може да бъде превърнат в стринг.
Ако от едната страна има стринг и бинарния + то за другия тип данни, ще бъде извикан метода му `ToString()` и ще се извърши конкатенация.

Конкатенацията е бавна, защото всички стрингове са immutable - read only, не могат да се променят. Ако променим даден стринг, то се алокира нова памет в heap-a с нов адрес и променливата взема новия адрес. Стария стринг остава в паметта, но нищо не сочи към него и garbage collector-a го изчиства по някое време.

Реално стринга е масив и може да бъде индексиран както всеки масив, но не може да се променя.

Всички стрингове са Unicode, това е кодова таблица с най-различни езици.

Може да преобразуваме от стринг към char[] и обратно:
```
char[] test = new char[] {'a','b' };

string test2 = new string (test);

char[] test3 = test2.ToCharArray();
```

Разликата между string.empty, "" и null е че null, няма референция към хийп-а, тотална липса на стойност. Нещо, която стойност е null не може да изпълнява каквито и да било действия и връща грешка `object reference not set..`

## [StringBuilder](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#StringBuilder)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240226130823.png)

String builder-a има капацитет където добавя стринговете. Нарича се буфер и затова работи по-бързо от конкатенацията.
Създава се като се направи нова инстанция на класа - `StringBuilder test = new StringBuilder();` в конструктора може да се зададе началния капацитет.
Понеже не е стринг, трябва да го превърнем първо в стринг, преди да може да го ползваме.

Също има индексатор, защото реално е масив от чарове, като стринга.
# Misc

# ChatGPT

# Bookmarks 
Course completed: 29.02.2023
