# General
## Shortcuts
cw + Tab - изписва `Console.WriteLine();`

Ctrl + D - копира на нов ред.

if + down arrow + Tab - създава if блок-а

By default, Visual Studio comes with the following shortcuts for commenting:
>**Single Line Comment**: `Ctrl + K + C`
>
>**Block Comment**: `Ctrl + K + C`
>
>**Uncomment**: `Ctrl + K + U`

Ctrl + K  + F  - auto format the selected code lines

Ctrl + K  + D  - auto format all 

Ctrl + R + R - variable rename

Ctrl + Left click - показва съдържанието на метода.

Ctrl + Shift + Space докато курсора е вътре в метода, показва overloads, заедно с допълнителна информация за променливите, в зависимост върху кой аргумент попада курсора вътре в скобите. Трябва да преместваме наляво или надясно за да видим информацията на конкретен аргумент.

pro + Tab - създава ново автоматично property в класа.

Ctrl + Space - показва в азбучен ред, properties при инициализирането на обекта.

Ctrl + Del - изтрива надясно от курсора.

Ctrl + Backspace - изтрива наляво от курсора.

Ctrl + Arrow Keys - премества курсора с повече полета.


Debugging:
>F10 is used to execute the current line of code and move to the next line, skipping method calls.
>
>F11 is used to step into method calls and navigate into the called method's code.

Ctrl + .  - докато сме цъкнали някъде на реда където има нов метод, който още не е дефиниран, го създава.

Ctrl + backspace - изтрива предишния символ или дума.

При селектиране даден метод или тип данни и натиснем F1, ще ни отвори документацията с примери и обяснения.

Ако цъкнем от ляво на отваряща или от дясно на затваряща скоба, ще освети съответната противоположна скоба. Ако курсора е от ляво или дясно на дадена скоба, задържим Ctrl и натиснем `]`, курсора ще се премести до противоположната скоба.

`ctor + Tab` създава нов конструктор за класа. 
Може да селектираме няколко пропъртита и полета и да натиснем Ctrl + . - това ще ни създаде попълнен конструктор. Ако имаме създаден конструктор с параметри, може да ги селектираме и пак с Ctrl + . може да изберем да ни създаде пропърти или поле ще ни попълни конструктора.

`prop + Tab х 2` - създава property в класа. След като го създадем с натискане на Tab се придвижваме от типа данни към името. 
Ако задържим Shift и Tab прескачаме между името и типа на променливата.

`propfull + Tab х 2` - създава пълно пропърти, заедно с field-а.

`Alt + up/down arrow key` - премества дадения ред нагоре или надолу.

`Alt + Shift + up/down arrow key` - избираме на колко реда да пишем едновременно. Селектирането може да стане само с `Alt + Mouse select`.

При селектиране на даден метод, клас, променлива и тн, ако натиснем `F12` то ни вкарва в класа към който принадлежи. 

`Ctrl + Shift + A` - изкача прозорец за добавяне на нов item, за по-бързо може да се натисне долу в ляво `Show Compact View`.

`Ctrl + .` - отваря меню с предложения за автоматизации (Quick Actions), като добавяне на `using` директиви, генериране на код, създаване на конструктори, корекции на грешки и много други.

`Ctrl + Shift + C` - отваря class view, където може да разгледаме всички типове данни вътре в проекта.

`try + Tab x 2` - генерира try catch конструкция.

`Ctrl + Shift + Tab` - навигираме между отделните класове.

`Ctrl + Tab` - превключва между предишния отворен клас и сегашния.
# Misc
## region
Отделяне на парчета код където initialization е наименованието и може да бъде сменено:
```
#region initialization
//initialization block
#endregion
```
## Class Diagrams 
Визуализира йерархията в класовете. Трябва да се инсталира допълнително от 
Tools -> Get Tools and Features -> Individual components -> search and install Class Designer.
След това трябва да се добави в проекта - Add -> New Item -> Class Diagram.
Като го отворим, може да drag-нем папки и файлове с класове и ще се визуализира цялата им йерархия.
## Console
Конзолата по подразбиране използва OEM encoding, който зависи от настройките на системата и не винаги разпознава кирилица. Трябва да му променим encoding-a с тази команда:
`Console.OutputEncoding = Encoding.Unicode;`
or
`Console.OutputEncoding = Encoding.UTF8;`
## Task view
`Search -> Task List` - показва всички коментари, които започват с `TODO` с цел бързо да се намерят оставени за после задачи.
## Project files
Когато отворим project file, ще видим проекта описан в xml. Реално може чрез графичния интерфейс да манипулираме xml описанието.
# Bookmarks
