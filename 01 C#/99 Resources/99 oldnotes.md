

Двоичното представяне на данните е удобно, тъй като нулата и единицата в електрониката могат да се реализират чрез логически схеми, в които нулата се представя като "няма ток" или например с напрежение -5V, а единицата се представя като "има ток" или например с напрежение +5V.

![](Pasted%20image%202023112.png)

Неявно (implicit) преобразуване на типове
Неявното (скритото) преобразуване на типове е възможно единствено, когато няма възможност от загуба на данни при преобразуването, т.е. когато конвертираме от тип с по-малък обхват към тип с по-голям обхват (например от int към long). За да направим неявно преобразуване, не е нужно да използваме какъвто и да е оператор и затова такова преобра-зуване се нарича още скрито (implicit). Преобразуването става автоматично от компилатора, когато присвояваме стойност от по-малък обхват в променлива с по-голям обхват или когато в израза има няколко типа с различен обхват. Тогава преобразуването става към типа с най-голям обхват.

Изрично (explicit) преобразуване на типове
Изричното преобразуване на типове (explicit typecasting) се използва винаги, когато има вероятност за загуба на данни. Когато конвертираме тип с плаваща запетая към целочислен тип, винаги има загуба на данни, идваща от премахването на дробната част и е задължително използването на изрично преобразуване (например double към long). За да направим такова конвертиране, е нужно изрично да използваме оператора за преобразуване на данни (type). Възможно е да има загуба на данни също, когато конвертираме от тип с по-голям обхват към тип с по-малък (double към float или long към int).

Какво представлява конзолата?
Конзолата представлява прозорец на операционната система, през който потребителите могат да си взаимодействат със системните програми на операционната система или с други конзолни приложения. Взаимодей-ствието се състои във въвеждане на текст от стандартния вход (най-често клавиатурата) или извеждане на текст на стандартния изход (най-често на екрана на компютъра). Тези действия са известни още като входно-изходни операции. Текстът, изписван на конзолата, носи определена информация и представлява поредица от символи изпратени от една или няколко програми.
За всяко конзолно приложение операционната система свързва устройства за вход и изход. По подразбиране това са клавиатурата и екрана, но те могат да бъдат пренасочвани към файл или други устройства.

Част от форматирането се определя от текущите настройки за "култура", които се взимат по подразбиране от регионалните настройки на операци-онната система. "Културите" са набор от правила, които са валидни за даден език или за дадена държава и които указват кой символ да се използва за десетичен разделител, как се изписва валутата и др. Например, за българската "култура" валутата се изписва като след сумата се добавя " лв.", докато за американската "култура" се изписва символът "$" преди сумата.

Енумерациите (изброени типове) представляват типове данни, които могат да приемат като стойност една измежду няколко предварително дефинирани възможни стойности (например седемте дни от седмицата).

Сравнение на референции към обекти
В .NET Framework съществуват референтни типове данни, които не съдър-жат директно стойността си (както числовите типове), а съдържат адрес от динамичната памет, където е записана стойността им. Такива типове са стринговете, масивите и класовете. Те имат поведение на указател към някакви стойности и могат да имат стойност null, т.е. липса на стойност. При сравняването на променливи от референтен тип се сравняват адресите, които те пазят, т.е. проверява се дали сочат на едно и също място в паметта, т.е. към един и същ обект.
Два указателя към обекти (референции) могат да сочат към един и същи обект или към различни обекти, или някой от тях може да не сочи никъде (да има стойност null). В следващия пример създаваме две променливи, които сочат към една и съща стойност (обект) в динамичната памет:
string str = "beer";
string anotherStr = str;
След изпълнението на този код двете променливи str и anotherStr ще сочат към един и същи обект (string със стойност "beer"), който се намира на някакъв адрес в динамичната памет (managed heap).