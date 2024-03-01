# General

### Оператори
![image](https://github.com/GerardSh/SoftwareUniversity/assets/17376533/4d60332c-8c3a-4c89-8f66-8f5a28cb0746)



Операторите в C# могат да бъдат разделени в няколко различни категории: 	
- Аритметични – също както в математиката, служат за извършване на прости математически операции. 	
- Оператори за присвояване – позволяват присвояването на стойност на променливите. 	
- Оператори за сравнение – дават възможност за сравнение на два литерала и/или променливи. 	
- Логически оператори – оператори за работа с булеви типове данни и булеви изрази. 	
- Побитови оператори – използват се за извършване на операции върху двоичното представяне на числови данни. 	
- Оператори за преобразуване на типовете – позволяват преобразу-ването на данни от един тип в друг. 	
	
![](Pasted%20image%202023117.png)

![](Pasted%20image%202023116.png)
![](Pasted%20image%2020231123161621.png)
### Променливи
![](Pasted%20image%202023115.png)

# Misc

## Home work
### Exercises Lab
1 
```
double number = double.Parse(Console.ReadLine());

if (number >= 5.5)
{
    Console.WriteLine("Excellent!");
} 
```

2
```
int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());

if (number1 >= number2)
{
    Console.WriteLine(number1);
}
else
{
    Console.WriteLine(number2);
}
```

3
```
int number = int.Parse(Console.ReadLine());

if (number % 2 == 0)
{
    Console.WriteLine("even");
}
else
{
    Console.WriteLine("odd");
}
```

4
```
string password = Console.ReadLine();

if (password == "s3cr3t!P@ssw0rd")
{
    Console.WriteLine("Welcome");
}
else
{
    Console.WriteLine("Wrong password!");
}
```

5
```
int number = int.Parse(Console.ReadLine());

if (number < 100)
{
    Console.WriteLine("Less than 100");
}
else if (number > 99 && number < 201)
{
    Console.WriteLine("Between 100 and 200");
}
else
{
    Console.WriteLine("Greater than 200");
}
```

6
```
if (number <= 10)
{
    Console.WriteLine("slow");
}
else if (number <= 50)
{
    Console.WriteLine("average");
}
else if (number <= 150)
{
    Console.WriteLine("fast");
}
else if (number <= 1000)
{
    Console.WriteLine("ultra fast");
}
else
{
    Console.WriteLine("extremely fast");
}
```

7
```
string figure = Console.ReadLine();

if (figure == "square")
{
    double sideLenght = double.Parse(Console.ReadLine());
    sideLenght = sideLenght * sideLenght;
    Console.WriteLine($"{sideLenght:F3}");
}
else if (figure == "rectangle")
{
    double sideA = double.Parse(Console.ReadLine());
    double sideB = double.Parse(Console.ReadLine());
    double multiply = sideA * sideB;
    Console.WriteLine($"{multiply:f3}");
}
else if (figure == "circle")
{
    double radius = double.Parse(Console.ReadLine());
    radius = radius * radius * Math.PI;
    Console.WriteLine($"{radius:f3}");
}
else if (figure == "triangle")
{
    double sideLenght = double.Parse(Console.ReadLine());
    double sideHeight = double.Parse(Console.ReadLine());
    double s = sideLenght * sideHeight/2;
    Console.WriteLine($"{s:f3}");
}
```
### Additional Exercises
1.
```
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

double min = (a + b + c) / 60;
double sec = (a + b + c) % 60;

if (sec < 10)
{
    Console.WriteLine($"{min}:0{sec}");
}

else
{
    Console.WriteLine($"{min}:{sec}");
}
```
2.
```
int numb = int.Parse(Console.ReadLine());
double bonus;

if (numb <= 100)
{
    bonus = 5;
}
else if (numb <= 1000)
{
    bonus = numb * 0.2;
}
else
{
    bonus = numb * 0.1;
}

if (numb%2==0)
{
    bonus = bonus + 1;
}

if (numb % 10 == 5)
{
    bonus += 2;
}
Console.WriteLine(bonus);
Console.WriteLine(numb+bonus);
```
3.
```
int hours = int.Parse(Console.ReadLine());
int minutes = int.Parse(Console.ReadLine());

minutes += 15;
if (minutes > 59)
{
    hours += 1;
    minutes -= 60;
    if (hours == 24)
    {
        hours = 0;
    }
}

if (minutes <10)
Console.WriteLine($"{hours}:0{minutes}");
else
Console.WriteLine($"{hours}:{minutes}");
```
4.
```
double excursionPrice = double.Parse(Console.ReadLine());
int pazel = int.Parse(Console.ReadLine());
int dolls = int.Parse(Console.ReadLine());
int bears = int.Parse(Console.ReadLine());
int minion = int.Parse(Console.ReadLine());
int trucks = int.Parse(Console.ReadLine());
int sum = pazel + dolls + bears + minion + trucks;


double pazelPrice = pazel * 2.60;
double dollsPrice = dolls * 3.0;
double bearsPrice = bears * 4.1;
double minionPrice = minion * 8.2;
double trucksPrice = trucks * 2.0;
double sumPrice = pazelPrice + dollsPrice + bearsPrice + minionPrice + trucksPrice;

if (sum >= 50)
{
    sumPrice -= sumPrice * 0.25;
    //sumPrice *= 0.75;
}
sumPrice *= 0.90;

if (sumPrice >= excursionPrice)
{
    Console.WriteLine($"Yes! {sumPrice - excursionPrice:f2} lv left.");
}
else
{
    Console.WriteLine($"Not enough money! {excursionPrice - sumPrice:f2} lv needed.");
}
```
5.
```
double budget = double.Parse(Console.ReadLine());
int stuff = int.Parse(Console.ReadLine());
double uniformStuffPrice = double.Parse(Console.ReadLine())*stuff;

double decor = budget * 0.10;

if (stuff > 150)
{
    uniformStuffPrice *= 0.9;
}
if (uniformStuffPrice + decor > budget)
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {uniformStuffPrice+decor - budget:f2} leva more.");
}
else
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {budget - (uniformStuffPrice+decor):f2} leva left.");
}
```
6.
```
double record = double.Parse(Console.ReadLine());
double meters = double.Parse(Console.ReadLine());
double secondsPerMeter = double.Parse(Console.ReadLine());


// every 15m 12.5 seconds delay
double delay = Math.Floor((meters / 15))*12.5;
double timeNeeded = meters * secondsPerMeter + delay;
if (timeNeeded < record)
{
    Console.WriteLine($" Yes, he succeeded! The new world record is {timeNeeded:f2} seconds.");
}
else
{
    Console.WriteLine($"No, he failed! He was {timeNeeded - record:f2} seconds slower.");
}
```
7.
```
double budget = double.Parse(Console.ReadLine());
int videoCards = int.Parse(Console.ReadLine());
int processors = int.Parse(Console.ReadLine());
int ram = int.Parse(Console.ReadLine());

int videoCardsPrice = videoCards * 250;
double processorsPrice = processors * videoCardsPrice * 0.35;
double ramPrice = ram * videoCardsPrice * 0.1;
double totalPrice = videoCardsPrice + processorsPrice + ramPrice;

if (videoCards > processors)
{
    totalPrice *= 0.85;
}

if (totalPrice <= budget)
{
    Console.WriteLine($"You have {budget - totalPrice:f2} leva left!");
}
else
{
    Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva more!");
}
```
8.
```
string seriesName = Console.ReadLine();
int episodeDuration = int.Parse(Console.ReadLine());
int brakeDuration = int.Parse(Console.ReadLine());

double lunchTime = brakeDuration / 8d;
double relaxTime = brakeDuration / 4d;

if (episodeDuration <= brakeDuration - (lunchTime + relaxTime))
    Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(brakeDuration - (lunchTime + relaxTime) - episodeDuration)} minutes free time.");
else
    Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(episodeDuration - (brakeDuration - (lunchTime + relaxTime)))} more minutes.");
```

# Bookmarks
