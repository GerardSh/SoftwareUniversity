//Miscellaneous
//Oscars ceremony
int rent = int.Parse(Console.ReadLine());

double rewards = rent * 0.70;
double ketering = rewards * 0.85;
double sounding = ketering / 2;

Console.WriteLine($"{rent + rewards + ketering + sounding:f2}");
Mountain Run

double recordInSeconds = double.Parse(Console.ReadLine());
double distanceInMeters = double.Parse(Console.ReadLine());
double timeInSecondsForMeter = double.Parse(Console.ReadLine());

double timeNeeded = distanceInMeters * timeInSecondsForMeter + (Math.Floor(distanceInMeters / 50) * 30);


if (timeNeeded < recordInSeconds)
{
    Console.WriteLine($"Yes! The new record is {timeNeeded:f2} seconds.");
}
else
{
    Console.WriteLine($"No! He was {timeNeeded - recordInSeconds:f2} seconds slower.");
}




//World Snooker Championship
string championshipStage = Console.ReadLine();
string ticketType = Console.ReadLine();
int ticketNumbers = int.Parse(Console.ReadLine());
char optionalPicture = char.Parse(Console.ReadLine());

double totalAmount = 0;

switch (ticketType)
{
    case "Standard":
        switch (championshipStage)
        {
            case "Quarter final":
                totalAmount = ticketNumbers * 55.5;
                break;
            case "Semi final":
                totalAmount = ticketNumbers * 75.88;
                break;
            case "Final":
                totalAmount = ticketNumbers * 110.10;
                break;
        }
        break;
    case "Premium":
        switch (championshipStage)
        {
            case "Quarter final":
                totalAmount = ticketNumbers * 105.2;
                break;
            case "Semi final":
                totalAmount = ticketNumbers * 125.22;
                break;
            case "Final":
                totalAmount = ticketNumbers * 160.66;
                break;
        }
        break;
    case "VIP":
        switch (championshipStage)
        {
            case "Quarter final":
                totalAmount = ticketNumbers * 118.9;
                break;
            case "Semi final":
                totalAmount = ticketNumbers * 300.40;
                break;
            case "Final":
                totalAmount = ticketNumbers * 400;
                break;
        }
        break;
}

if (totalAmount > 4000)
{
    totalAmount *= 0.75;
    optionalPicture = 'N';
}

else if (totalAmount > 2500)
{
    totalAmount *= 0.90;
}

if (optionalPicture == 'Y')
{
    totalAmount += (ticketNumbers * 40);
}

Console.WriteLine($"{totalAmount:f2}");




//Oscars
string actorsName = Console.ReadLine();
double academyPoints = double.Parse(Console.ReadLine());
int evaluators = int.Parse(Console.ReadLine());

const double pointsNeeded = 1250.5;

double totalPoints = academyPoints;


while (totalPoints < pointsNeeded && evaluators > 0)
{
    string evaluatorsName = Console.ReadLine();
    double evaluatorPoints = double.Parse(Console.ReadLine());
    totalPoints += evaluatorsName.Length * evaluatorPoints / 2;
    evaluators--;
}

if (totalPoints > pointsNeeded)
{
    Console.WriteLine($"Congratulations, {actorsName} got a nominee for leading role with {totalPoints:f1}!");
}
else
{
    Console.WriteLine($"Sorry, {actorsName} you need {pointsNeeded - totalPoints:f1} more!");
}




//Renovation
int wallHeight = int.Parse(Console.ReadLine());
int wallLenght = int.Parse(Console.ReadLine());
int notIncludedPercent = int.Parse(Console.ReadLine());
int paintLiters = 0;
double countRemainingPaintLiters = 0;

double roomSpace = wallHeight * wallLenght * 4 * ((100 - notIncludedPercent) / 100.00);

string input = Console.ReadLine();
while (input != "Tired!")
{
    paintLiters = int.Parse(input);
    countRemainingPaintLiters = paintLiters - roomSpace;
    roomSpace -= paintLiters;

    if (roomSpace <= 0)
    {
        break;
    }

    input = Console.ReadLine();
}

if (input == "Tired!")
{
    Console.WriteLine($"{roomSpace} quadratic m left.");
}
else if (countRemainingPaintLiters > 0)
{
    Console.WriteLine($"All walls are painted and you have {countRemainingPaintLiters} l paint left!");
}
else
{
    Console.WriteLine($"All walls are painted! Great job, Pesho!");
}




//Barcode Generator
int startNumber = int.Parse(Console.ReadLine());
int endNumber = int.Parse(Console.ReadLine());


int forthDigit = startNumber % 10;
startNumber /= 10;
int thirdDigit = startNumber % 10;
startNumber /= 10;
int secondDigit = startNumber % 10;
startNumber /= 10;
int firstDigit = startNumber % 10;
startNumber /= 10;

int forthDigit2 = endNumber % 10;
endNumber /= 10;
int thirdDigit2 = endNumber % 10;
endNumber /= 10;
int secondDigit2 = endNumber % 10;
endNumber /= 10;
int firstDigit2 = endNumber % 10;
endNumber /= 10;

bool isvalid = true;

for (int i1 = firstDigit; i1 <= firstDigit2; i1++)
{
    if (i1 % 2 == 0)
    {
        continue;
    }
    for (int i2 = secondDigit; i2 <= secondDigit2; i2++)
    {
        if (i2 % 2 == 0)
        {
            continue;
        }
        for (int i3 = thirdDigit; i3 <= thirdDigit2; i3++)
        {
            if (i3 % 2 == 0)
            {
                continue;
            }
            for (int i4 = forthDigit; i4 <= forthDigit2; i4++)
            {

                if (i4 % 2 == 0)
                {
                    continue;
                }
                else
                {
                    Console.Write($"{i1}{i2}{i3}{i4} ");
                }
            }
        }
    }
}




//Cinema Voucher
int vaucherValue = int.Parse(Console.ReadLine());


string input = Console.ReadLine();
int countTicketsBought = 0;
int countOtherItems = 0;

while (input != "End" && vaucherValue > 0)
{
    int itemPrice = 0;

    if (input.Length > 8)
    {
        itemPrice = input[0] + input[1];

        if (vaucherValue - itemPrice >= 0)
            countTicketsBought++;
    }
    else
    {
        itemPrice = input[0];
        if (vaucherValue - itemPrice >= 0)
            countOtherItems++;
    }

    vaucherValue -= itemPrice;

    if (vaucherValue > 0)
    {
        input = Console.ReadLine();
    }
}

Console.WriteLine(countTicketsBought);
Console.WriteLine(countOtherItems);
Nested Loops - More Exercises




//Unique PIN Codes
int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
int number3 = int.Parse(Console.ReadLine());

for (int i = 2; i <= number1; i++)
{
    if (i % 2 != 0)
    {
        continue;
    }

    for (int i2 = 1; i2 <= number2; i2++)
    {
        bool i2Prime = true;
        for (int j = 2; j < i2 / 2 && i2Prime; j++)
        {

            if (i2 % j == 0)
            {
                i2Prime = false;
            }

        }

        if (i2 == 1 || i2 == 4)
        {
            i2Prime = false;
        }


        for (int i3 = 2; i3 <= number3 && i2Prime; i3++)
        {
            if (i3 % 2 == 0)
            {
                Console.WriteLine($"{i} {i2} {i3}");
            }
        }
    }
}




//Letters Combinations
char letter1 = char.Parse(Console.ReadLine());
char letter2 = char.Parse(Console.ReadLine());
char letter3 = char.Parse(Console.ReadLine());

int counter = 0;

for (char i = letter1; i <= letter2; i++)
{
    for (char i2 = letter1; i2 <= letter2; i2++)
    {
        for (char i3 = letter1; i3 <= letter2; i3++)
        {
            if (i != letter3 && i2 != letter3 && i3 != letter3)
            {
                Console.Write($"{i}{i2}{i3} ");
                counter++;
            }

            if (i == letter2 && i3 == letter2 && i2 == letter2)
                Console.Write(counter);
        }
    }
}




//Lucky Numbers
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= 9; i++)
{
    for (int i2 = 1; i2 <= 9; i2++)
    {
        for (int i3 = 1; i3 <= 9; i3++)
        {
            for (int i4 = 1; i4 <= 9; i4++)
            {
                if (i + i2 == i3 + i4 && n % (i + i2) == 0)
                {
                    Console.Write($"{i}{i2}{i3}{i4} ");
                }
            }
        }
    }
}




//Car Number
int n = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());


for (int i = n; i <= n2; i++)
{
    for (int i2 = n; i2 <= n2; i2++)
    {
        for (int i3 = n; i3 <= n2; i3++)
        {
            for (int i4 = n; i4 <= n2; i4++)
            {
                if (((i % 2 == 0 && i4 % 2 == 1) || (i % 2 == 1 && i4 % 2 == 0)) && i > i4 && (i2 + i3) % 2 == 0)
                {
                    Console.Write($"{i}{i2}{i3}{i4} ");
                }

            }
        }
    }
}




//Challenge the Wedding
//men
int n = int.Parse(Console.ReadLine());
//women
int n2 = int.Parse(Console.ReadLine());
//tables
int n3 = int.Parse(Console.ReadLine());

int countUsedTables = 0;

for (int i = 1; i <= n; i++)
{
    for (int i2 = 1; i2 <= n2; i2++)
    {
        if (countUsedTables < n3)
        {
            Console.Write($"({i} <-> {i2}) ");
            countUsedTables++;
        }
    }
}




//06.Wedding Seats
//last sector
char n = char.Parse(Console.ReadLine());
//number of rows in the first sector
int n2 = int.Parse(Console.ReadLine());
//number of rows on necheten rown
int n3 = int.Parse(Console.ReadLine());

int countAllRows = 0;


for (char i = 'A'; i <= n; i++)
{
    for (int i2 = 1; i2 <= n2; i2++)
    {
        if (i2 % 2 == 1)
        {
            for (char i3 = 'a'; i3 < (char)('a' + n3); i3++)
            {
                Console.WriteLine($"{i}{i2}{i3}");
                countAllRows++;
            }
        }
        else
        {
            for (char i3 = 'a'; i3 < (char)('a' + n3 + 2); i3++)
            {
                Console.WriteLine($"{i}{i2}{i3}");
                countAllRows++;
            }
        }

    }
    n2++;

}

Console.WriteLine(countAllRows);




//2
char n = char.Parse(Console.ReadLine());
//number of rows in the first sector
int n2 = int.Parse(Console.ReadLine());
//number of rows on necheten rown
int n3 = int.Parse(Console.ReadLine());

int countAllRows = 0;

for (char i = 'A'; i <= n; i++)
{
    for (int i2 = 1; i2 <= n2; i2++)
    {
        for (char i3 = 'a'; i3 < (char)('a' + n3); i3++)
        {
            Console.WriteLine($"{i}{i2}{i3}");
            countAllRows++;
            if (i2 % 2 == 0 && i3 == 'a')
            {
                n3 += 2;
            }
            if (i2 % 2 == 0 && i3 == (char)('a' + n3 - 1))
            {
                n3 -= 2;
            }
        }
    }
    n2++;
}

Console.WriteLine(countAllRows);




//Safe Passwords Generator
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

char symbol1 = (char)35;
char symbol2 = (char)64;

int passCounter = 0;

for (int i = 1; i <= a; i++)
{
    for (int i2 = 1; i2 <= b; i2++, symbol1++, symbol2++, passCounter++)
    {
        if (symbol1 == 56)
        {
            symbol1 = (char)35;
        }
        if (symbol2 == 97)
        {
            symbol2 = (char)64;
        }
        if (passCounter == c)
        {
            return;
        }
        Console.Write($"{symbol1}{symbol2}{i}{i2}{symbol2}{symbol1}|");
    }
}




//Secret Door's Lock
int n = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
int n3 = int.Parse(Console.ReadLine());

for (int i = 2; i <= n; i += 2)
{

    for (int i2 = 2; i2 <= n2; i2++)
    {
        bool isPrime = true;
        for (int prime = 2; prime < i2 && isPrime; prime++)

            if (i2 % prime == 0)
            {
                isPrime = false;
            }

        for (int i3 = 2; i3 <= n3 && isPrime; i3 += 2)
        {

            Console.WriteLine($"{i} {i2} {i3}");

        }
    }
}




//Sum of Two Numbers
int n = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
int n3 = int.Parse(Console.ReadLine());

int counter = 0;
bool isFound = false;

for (int i = n; i <= n2 && !isFound; i++)
{
    for (int i2 = n; i2 <= n2 && !isFound; i2++)
    {
        counter++;

        if (i + i2 == n3)
        {
            Console.WriteLine($"Combination N:{counter} ({i} + {i2} = {n3})");
            isFound = true;
        }
    }
}

if (!isFound)
{
    Console.WriteLine($"{counter} combinations - neither equals {n3}");
}




//Profit
int n = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
int n3 = int.Parse(Console.ReadLine());
int n4 = int.Parse(Console.ReadLine());

for (int i = 0; i <= n; i++)
{
    for (int i2 = 0; i2 <= n2; i2++)
    {
        for (int i3 = 0; i3 <= n3; i3++)
        {
            if (i + i2 * 2 + i3 * 5 == n4)
            {
                Console.WriteLine($"{i} * 1 lv. + {i2} * 2 lv. + {i3} * 5 lv. = {n4} lv.");
            }
        }
    }
}




//HappyCat Parking
int days = int.Parse(Console.ReadLine());
int hours = int.Parse(Console.ReadLine());

double totalPrice = 0;

for (int i = 1; i <= days; i++)
{
    double price = 0;

    for (int j = 1; j <= hours; j++)
    {
        if (i % 2 == 0 && j % 2 != 0)
        {
            price += 2.5;
        }
        else if (i % 2 != 0 && j % 2 == 0)
        {
            price += 1.25;
        }
        else
        {
            price += 1;
        }
    }
    totalPrice += price;
    Console.WriteLine($"Day: {i} - {price:f2} leva");
}

Console.WriteLine($"Total: {totalPrice:f2} leva");




//The song of the wheels
int n = int.Parse(Console.ReadLine());

int counter = 0;
string password = " ";

for (int i = 1; i <= 9; i++)
{
    for (int i2 = 1; i2 <= 9; i2++)
    {
        for (int i3 = 1; i3 <= 9; i3++)
        {
            for (int i4 = 1; i4 <= 9; i4++)
            {
                if (i * i2 + i3 * i4 == n && i < i2 && i3 > i4)
                {
                    counter++;

                    Console.Write($"{i}{i2}{i3}{i4} ");

                    if (counter == 4) { password = $"Password: {i}{i2}{i3}{i4}"; }
                }
            }
        }
    }
}

if (password != " ")
{
    Console.WriteLine();
    Console.WriteLine(password);
}
else if (counter > 0)
{
    Console.WriteLine();
    Console.WriteLine("No!");
}
else
{
    Console.WriteLine("No!");
}




//Prime Pairs
int nStart = int.Parse(Console.ReadLine());
int n2Start = int.Parse(Console.ReadLine());
int nAddition = int.Parse(Console.ReadLine());
int n2Addition = int.Parse(Console.ReadLine());

int nEnd = nStart + nAddition;
int n2End = n2Start + n2Addition;

for (int i = nStart; i <= nEnd; i++)
{
    bool isPrimal = true;

    for (int primalCheck = 2; primalCheck < i && isPrimal; primalCheck++)
    {
        if (i % primalCheck == 0)
        {
            isPrimal = false;
        }
    }

    for (int j = n2Start; j <= n2End; j++)
    {
        bool isPrimal2 = true;

        for (int primalCheck = 2; primalCheck < j && isPrimal2; primalCheck++)
        {
            if (j % primalCheck == 0)
            {
                isPrimal2 = false;
            }
        }

        if (isPrimal && isPrimal2)
        {
            Console.WriteLine($"{i}{j}");
        }
    }
}




//Password Generator
int n = int.Parse(Console.ReadLine());
int l = int.Parse(Console.ReadLine());

for (int i = 1; i < n; i++)
{
    int number = 1;
    for (int i2 = 1; i2 < n; i2++)
    {
        for (int i3 = 97; i3 < 97 + l; i3++)
        {
            for (int i4 = 97; i4 < 97 + l; i4++)
            {
                for (int i5 = i > i2 ? i + 1 : i2 + 1; i5 <= n; i5++)
                {
                    Console.Write($"{i}{i2}{(char)i3}{(char)i4}{i5} ");
                }

            }
        }
    }
}




//Juicing diet
int respberries = int.Parse(Console.ReadLine());
int strawberries = int.Parse(Console.ReadLine());
int cherries = int.Parse(Console.ReadLine());
int juice = int.Parse(Console.ReadLine());

string finalresult = $"{0} Raspberries, {0} Strawberries, {0} Cherries. Juice: {0} ml.";
double producedJuice = 0;

for (int i = 0; i <= respberries; i++)
{
    for (int j = 0; j <= strawberries; j++)
    {
        for (int k = 0; k <= cherries; k++)
        {
            double currentJuice = i * 4.5 + j * 7.5 + k * 15;

            if (currentJuice <= juice && currentJuice > producedJuice)
            {
                producedJuice = currentJuice;
                finalresult = $"{i} Raspberries, {j} Strawberries, {k} Cherries. Juice: {producedJuice} ml.";
            }
        }
    }
}

Console.WriteLine(finalresult);
Programming Basics Online Exam - 18 and 19 July 2020




//Agency Profit
string airCompanyName = Console.ReadLine();
int numberTicketsAdults = int.Parse(Console.ReadLine());
int numberTicketsChildren = int.Parse(Console.ReadLine());
double netPriceAdult = double.Parse(Console.ReadLine());
double serviceTax = double.Parse(Console.ReadLine());

double netPriceChildren = netPriceAdult * 0.30;

double ticketSumAdult = netPriceAdult + serviceTax;
double ticketSumChild = netPriceChildren + serviceTax;

double sumAllTickets = numberTicketsAdults * ticketSumAdult + numberTicketsChildren * ticketSumChild;

double profit = sumAllTickets * 0.20;

Console.WriteLine($"The profit of your agency from {airCompanyName} tickets is {profit:f2} lv.");




//Add Bags
double luggagePrice = double.Parse(Console.ReadLine());
double luggageKg = double.Parse(Console.ReadLine());
int daysUntilTravel = int.Parse(Console.ReadLine());
int luggageNumber = int.Parse(Console.ReadLine());

double additionalLuggagePrice = 0;

if (luggageKg < 10)
{
    additionalLuggagePrice = luggagePrice * 0.2;
}
else if (luggageKg <= 20)
{
    additionalLuggagePrice = luggagePrice * 0.5;
}
else
{
    additionalLuggagePrice = luggagePrice;
}

if (daysUntilTravel < 7)
{
    additionalLuggagePrice *= 1.4;
}
else if (daysUntilTravel <= 30)
{
    additionalLuggagePrice *= 1.15;
}
else
{
    additionalLuggagePrice *= 1.1;
}

Console.WriteLine($"The total price of bags is: {additionalLuggagePrice * luggageNumber:f2} lv.");




//Aluminum Joinery
int numberDograma = int.Parse(Console.ReadLine());
string typeDograma = Console.ReadLine();
string delivery = Console.ReadLine();

double discount = 1;
int singlePrice = 0;
double finalPrice = 0;

if (numberDograma < 10)
{
    Console.WriteLine("Invalid order");
}
else
{
    switch (typeDograma)
    {
        case "90X130":
            singlePrice = 110;
            if (numberDograma > 30 && numberDograma <= 60)
            {
                discount = 1 - 0.05;

            }
            else if (numberDograma > 60)
            {
                discount = 1 - 0.08;
            }
            break;
        case "100X150":
            singlePrice = 140;
            if (numberDograma > 40 && numberDograma <= 80)
            {
                discount = 1 - 0.06;
            }
            else if (numberDograma > 80)
            {
                discount = 1 - 0.10;
            }
            break;
        case "130X180":
            singlePrice = 190;
            if (numberDograma > 20 && numberDograma <= 50)
            {
                discount = 1 - 0.07;
            }
            else if (numberDograma > 50)
            {
                discount = 1 - 0.12;
            }
            break;
        case "200X300":
            singlePrice = 250;
            if (numberDograma > 25 && numberDograma <= 50)
            {
                discount = 1 - 0.09;
            }
            else if (numberDograma > 50)
            {
                discount = 1 - 0.14;
            }
            break;
    }

    finalPrice = numberDograma * singlePrice * discount;

    switch (delivery)
    {
        case "With delivery": finalPrice += 60; break;
    }

    if (numberDograma > 99)
    {
        discount = 1 - 0.04;
        finalPrice *= discount;
    }

    Console.WriteLine($"{finalPrice:f2} BGN");
}




//Balls
int nBalls = int.Parse(Console.ReadLine());
string colors = Console.ReadLine();

int points = 0;
int totalPoints = 0;
int red = 0;
int orange = 0;
int yellow = 0, white = 0, others = 0, black = 0;


for (int i = 0; i < nBalls; i++)
{
    if (colors == "red")
    {
        red++;
        totalPoints += 5;
    }
    else if (colors == "orange")
    {
        orange++;
        totalPoints += 10;
    }
    else if (colors == "yellow")
    {
        yellow++;
        totalPoints += 15;
    }

    else if (colors == "white")
    {
        white++;
        totalPoints += 20;
    }

    else if (colors == "black")
    {
        black++;
        totalPoints /= 2;
    }
    else
    {
        others++;
    }
    if (!(i == nBalls - 1))
    {
        colors = Console.ReadLine();
    }
}

Console.WriteLine($"Total points: {totalPoints}");
Console.WriteLine($"Red balls: {red}");
Console.WriteLine($"Orange balls: {orange}");
Console.WriteLine($"Yellow balls: {yellow}");
Console.WriteLine($"White balls: {white}");
Console.WriteLine($"Other colors picked: {others}");
Console.WriteLine($"Divides from black balls: {black}");




//Best Player
string playersName = Console.ReadLine();
int scoredGoals = 0;

int goalRecord = 0;
string bestPlayer = "";
bool hatTrick = false;

while (playersName != "END")
{

    scoredGoals = int.Parse(Console.ReadLine());

    if (scoredGoals > goalRecord)
    {
        goalRecord = scoredGoals;
        bestPlayer = playersName;

        if (scoredGoals > 2)
        {
            hatTrick = true;
        }
    }
    if (scoredGoals >= 10)
    {
        break;
    }

    playersName = Console.ReadLine();
}

Console.WriteLine($"{bestPlayer} is the best player!");

if (hatTrick)
{

    Console.WriteLine($"He has scored {goalRecord} goals and made a hat-trick !!!");
}
else
{
    Console.WriteLine($"He has scored {goalRecord} goals.");
}
Programming Basics Online Exam - 9 and 10 March 2019
Tennis Equipment

double priceForOneTennisRocket = double.Parse(Console.ReadLine());
int tennisRocketsNumber = int.Parse(Console.ReadLine());
int sportShoesNumber = int.Parse(Console.ReadLine());

double tennisRocketsTotal = priceForOneTennisRocket * tennisRocketsNumber;
double sportShoesPrice = priceForOneTennisRocket / 6;
double sportShoesPriceTotal = sportShoesNumber * sportShoesPrice;
double otherStuff = (tennisRocketsTotal + sportShoesPriceTotal) * 0.2;
double totalPrice = tennisRocketsTotal + sportShoesPriceTotal + otherStuff;

double playerExpenses = totalPrice / 8;
double sponsorsExpenses = playerExpenses * 7;

Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(playerExpenses)}");
Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsorsExpenses)}");




//High Jump
int neededHeight = int.Parse(Console.ReadLine());

bool isWinner = false;
int allJumpsCounter = 0;
int finalBarHeight = 0;

for (int i = neededHeight - 30; i <= neededHeight; i += 5)
{


    isWinner = false;

    for (int j = 0; j < 3 && !isWinner; j++)
    {
        int currentJump = int.Parse(Console.ReadLine());
        allJumpsCounter++;

        if (currentJump > i)
        {
            isWinner = true;
        }
    }

    finalBarHeight = i;

    if (!isWinner)
    {
        break;
    }

}

if (isWinner == false)
{

    Console.WriteLine($"Tihomir failed at {finalBarHeight}cm after {allJumpsCounter} jumps.");
}
else
{
    Console.WriteLine($"Tihomir succeeded, he jumped over {finalBarHeight}cm after {allJumpsCounter} jumps.");
}




//2
int targetHeight = int.Parse(Console.ReadLine());
int currentHeight = targetHeight - 30;

int allJumpsCounter = 0;
int badJumpsCounter = 0;

while (currentHeight <= targetHeight)
{
    int jump = int.Parse(Console.ReadLine());
    allJumpsCounter++;

    if (jump > currentHeight)
    {
        currentHeight += 5;
        badJumpsCounter = 0;
    }
    else
    {
        badJumpsCounter++;

        if (badJumpsCounter == 3)
        {
            Console.WriteLine($"Tihomir failed at {currentHeight}cm after {allJumpsCounter} jumps.");
            return;
        }
    }


}

Console.WriteLine($"Tihomir succeeded, he jumped over {targetHeight}cm after {allJumpsCounter} jumps.");




//Basketball Tournament
string tournamentName;
int winCounter = 0;
int lostCounter = 0;
int allGames = 0;

while ((tournamentName = Console.ReadLine()) != "End of tournaments")
{
    int tournamentGames = int.Parse(Console.ReadLine());

    for (int i = 1; i <= tournamentGames; i++)
    {
        int desiTeam = int.Parse(Console.ReadLine());
        int otherTeam = int.Parse(Console.ReadLine());

        Console.WriteLine($"Game {i} of tournament {tournamentName}: {(desiTeam > otherTeam ? $"win with {desiTeam - otherTeam}" : $"lost with {otherTeam - desiTeam}")} points.");

        if (desiTeam > otherTeam)
        {
            winCounter++;
        }
        else
        {
            lostCounter++;
        }
    }

    allGames += tournamentGames;
}

Console.WriteLine($"{100.0 * winCounter / allGames:f2}% matches win");
Console.WriteLine($"{100.0 * lostCounter / allGames:f2}% matches lost");
Fitness Center

int numberOfVisitors = int.Parse(Console.ReadLine());
int back = 0;
int chest = 0;
int legs = 0;
int abs = 0;
int proteinShake = 0;
int proteinBar = 0;
int peopleTraining = 0;
int peopleBuying = 0;

for (int i = 0; i < numberOfVisitors; i++)
{
    string activity = Console.ReadLine();

    if (activity == "Back")
    {
        back++;
        peopleTraining++;
    }
    else if (activity == "Chest")
    {
        chest++;
        peopleTraining++;
    }
    else if (activity == "Legs")
    {
        legs++;
        peopleTraining++;
    }
    else if (activity == "Abs")
    {
        abs++;
        peopleTraining++;
    }
    else if (activity == "Protein shake")
    {
        proteinShake++;
        peopleBuying++;
    }
    else if (activity == "Protein bar")
    {
        proteinBar++;
        peopleBuying++;
    }
}

Console.WriteLine(back + " - back");
Console.WriteLine(chest + " - chest");
Console.WriteLine(legs + " - legs");
Console.WriteLine(abs + " - abs");
Console.WriteLine(proteinShake + " - protein shake");
Console.WriteLine(proteinBar + " - protein bar");
Console.WriteLine($"{100.0 * peopleTraining / numberOfVisitors:f2}% - work out");
Console.WriteLine($"{100.0 * peopleBuying / numberOfVisitors:f2}% - protein");




//Darts
string nameOfPlayer = Console.ReadLine();
string input;
int points = 301;
int successShots = 0, unsuccessShots = 0;

bool isWinner = false;


while (!isWinner && (input = Console.ReadLine()) != "Retire")
{
    int currentPoints = int.Parse(Console.ReadLine());

    if (input == "Single" && points - currentPoints >= 0)
    {
        points -= currentPoints;
        successShots++;
    }
    else if (input == "Double" && points - currentPoints * 2 >= 0)
    {
        points -= currentPoints * 2;
        successShots++;
    }
    else if (input == "Triple" && points - currentPoints * 3 >= 0)
    {
        points -= currentPoints * 3;
        successShots++;
    }
    else
    {
        unsuccessShots++;
    }

    if (points == 0)
    {
        isWinner = true;
    }
}

if (isWinner)
{
    Console.WriteLine($"{nameOfPlayer} won the leg with {successShots} shots.");
}
else
{
    Console.WriteLine($"{nameOfPlayer} retired after {unsuccessShots} unsuccessful shots.");
}




//Game Number Wars
string nameFirstPlayer = Console.ReadLine();
string nameSecondPlayer = Console.ReadLine();

int scoreFirstPlayer = 0;
int scoreSecondPlayer = 0;

string firstPlayerCard = Console.ReadLine();
string secondPlayerCard = Console.ReadLine();


bool isWinner = false;
bool isWinner1 = false;

while (firstPlayerCard != "End of game" && secondPlayerCard != "End of game" && !isWinner)
{

    int firstPlayerNumber = int.Parse(firstPlayerCard);
    int secondPlayerNumber = int.Parse(secondPlayerCard);

    if (firstPlayerNumber > secondPlayerNumber)
    {
        scoreFirstPlayer += firstPlayerNumber - secondPlayerNumber;
    }
    else if (firstPlayerNumber < secondPlayerNumber)
    {
        scoreSecondPlayer += secondPlayerNumber - firstPlayerNumber;
    }
    else
    {
        firstPlayerCard = Console.ReadLine();
        secondPlayerCard = Console.ReadLine();

        firstPlayerNumber = int.Parse(firstPlayerCard);
        secondPlayerNumber = int.Parse(secondPlayerCard);

        if (firstPlayerNumber > secondPlayerNumber)
        {
            isWinner1 = true;
        }

        isWinner = true;
    }

    if (!isWinner)
    {
        firstPlayerCard = Console.ReadLine();

        if (firstPlayerCard != "End of game")
        {
            secondPlayerCard = Console.ReadLine();

        }
    }
}

if (isWinner)
{
    Console.WriteLine("Number wars!");
    Console.WriteLine($"{(isWinner1 ? $"{nameFirstPlayer} is winner with {scoreFirstPlayer} points" : $"{nameSecondPlayer} is winner with {scoreSecondPlayer} points")}");
}
else
{
    Console.WriteLine($"{nameFirstPlayer} has {scoreFirstPlayer} points");
    Console.WriteLine($"{nameSecondPlayer} has {scoreSecondPlayer} points");
}
Programming Basics Online Exam - 15 and 16 June 2019
Movie Tickets

int a1 = int.Parse(Console.ReadLine());
int a2 = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());

for (int i = a1; i <= a2 - 1; i++)
{
    for (int j = 1; j <= n - 1; j++)
    {
        for (int k = 1; k <= n / 2 - 1; k++)
        {
            if (i % 2 == 1 && (j + k + i) % 2 == 1)
                Console.WriteLine($"{(char)i}-{j}{k}{i}");
        }
    }
}




//Favorite Movie
string movieName;
int bestMovieScore = 0;
string bestMovie = "";
int movieCounter = 0;

while (movieCounter < 7 && (movieName = Console.ReadLine()) != "STOP")
{

    int movieScore = 0;
    for (int i = 0; i < movieName.Length; i++)
    {
        movieScore += movieName[i];

        if (movieName[i] > 91)
        {
            movieScore -= movieName.Length * 2;
        }
        else if (movieName[i] > 64)
        {
            movieScore -= movieName.Length;
        }
    }

    if (movieScore > bestMovieScore)
    {
        bestMovieScore = movieScore;
        bestMovie = movieName;
    }
    movieCounter++;

    if (movieCounter == 7)
    {
        Console.WriteLine("The limit is reached.");
    }
}

Console.WriteLine($"The best movie for you is {bestMovie} with {bestMovieScore} ASCII sum.");




//2
string movieName = Console.ReadLine();
int bestMovieScore = 0;
string bestMovie = "";
int movieCounter = 1;
int movieScore = 0;
int i = 0;

while (movieName != "STOP")
{

    movieScore += movieName[i];

    if (movieName[i] > 91)
    {
        movieScore -= movieName.Length * 2;
    }
    else if (movieName[i] > 64)
    {
        movieScore -= movieName.Length;
    }
    if (movieCounter == 7)
    {
        Console.WriteLine("The limit is reached.");
        break;
    }

    i++;

    if (i == movieName.Length)
    {
        if (movieScore > bestMovieScore)
        {
            bestMovieScore = movieScore;
            bestMovie = movieName;
        }
        movieCounter++;
        movieScore = 0;
        movieName = Console.ReadLine();
        i = 0;
    }
}

Console.WriteLine($"The best movie for you is {bestMovie} with {bestMovieScore} ASCII sum.");




//Series
double budget = double.Parse(Console.ReadLine());
int seriesNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < seriesNumber; i++)
{
    string seriesName = Console.ReadLine();
    double seriesPrice = double.Parse(Console.ReadLine());

    if (seriesName == "Thrones")
    {
        seriesPrice *= 0.50;
    }
    else if (seriesName == "Lucifer")
    {
        seriesPrice *= 0.60;
    }
    else if (seriesName == "Protector")
    {
        seriesPrice *= 0.70;
    }
    else if (seriesName == "TotalDrama")
    {
        seriesPrice *= 0.80;
    }
    else if (seriesName == "Area")
    {
        seriesPrice *= 0.90;
    }
    budget -= seriesPrice;
}

if (budget >= 0)
{
    Console.WriteLine($"You bought all the series and left with {budget:f2} lv.");
}
else
{
    Console.WriteLine($"You need {budget * -1:f2} lv. more to buy the series!");
}




//Movie Stars
double budget = double.Parse(Console.ReadLine());
string actorsName;

while (budget > 0 && (actorsName = Console.ReadLine()) != "ACTION")
{
    double payment = 0;

    if (actorsName.Length <= 15)
    {
        payment = double.Parse(Console.ReadLine());
    }
    else
    {
        payment = budget * 0.2;
    }

    budget -= payment;
}

if (budget >= 0)
{
    Console.WriteLine($"We are left with {budget:f2} leva.");
}
else
{
    Console.WriteLine($"We need {budget * -1:f2} leva for our actors.");
}




//Cinema
int capacity = int.Parse(Console.ReadLine());
string input;
bool capacityFull = false;

int allTicketsPrice = 0;

const int ticketPrice = 5;

while ((input = Console.ReadLine()) != "Movie time!")
{
    int numberVisitors = int.Parse(input);

    if (numberVisitors > capacity)
    {
        capacityFull = true;
        break;
    }

    int ticketsPrice = numberVisitors * ticketPrice;

    if (numberVisitors % 3 == 0)
    {
        ticketsPrice -= 5;
    }

    capacity -= numberVisitors;
    allTicketsPrice += ticketsPrice;

}

if (capacityFull)
{
    Console.WriteLine("The cinema is full.");
}
else
{
    Console.WriteLine($"There are {capacity} seats left in the cinema.");
}

Console.WriteLine("Cinema income - " + allTicketsPrice + " lv.");




//Movie Destination
double budget = double.Parse(Console.ReadLine());
string destination = Console.ReadLine();
string season = Console.ReadLine();
int n = int.Parse(Console.ReadLine());

double oneDayPrice = 0;
double discount = 1;

if (season == "Winter")
{
    if (destination == "Dubai")
    {
        oneDayPrice = 45000;
        discount = 0.7;
    }
    else if (destination == "Sofia")
    {
        oneDayPrice = 17000;
        discount = 1.25;
    }
    else if (destination == "London")
    {
        oneDayPrice = 24000;
    }
}
else if (season == "Summer")
{
    if (destination == "Dubai")
    {
        oneDayPrice = 40000;
        discount = 0.7;
    }
    else if (destination == "Sofia")
    {
        oneDayPrice = 12500;
        discount = 1.25;
    }
    else if (destination == "London")
    {
        oneDayPrice = 20250;
    }
}

double cost = n * oneDayPrice * discount;

if (budget >= cost)
{
    Console.WriteLine($"The budget for the movie is enough! We have {budget - cost:f2} leva left!");
}
else
{
    Console.WriteLine($"The director needs {cost - budget:f2} leva more!");
}




//Programming Basics Online Exam - 28 and 29 March 2020
int tournirDays = int.Parse(Console.ReadLine());

string input;
int daysWon = 0;
int daysLost = 0;
double totalMoney = 0;

for (int i = 0; i < tournirDays; i++)
{
    int gamesWon = 0;
    int gamesLost = 0;
    double moneyForTheDay = 0;


    while ((input = Console.ReadLine()) != "Finish")
    {
        string result = Console.ReadLine();

        if (result == "win")
        {
            moneyForTheDay += 20;
            gamesWon++;

        }
        else
        {
            gamesLost++;
        }
    }

    if (gamesWon > gamesLost)
    {
        moneyForTheDay *= 1.1;
        daysWon++;
    }
    else
    {
        daysLost++;
    }

    totalMoney += moneyForTheDay;

}

if (daysWon > daysLost)
{
    totalMoney *= 1.2;
}

Console.WriteLine($"You {(daysWon > daysLost ? "won" : "lost")} the tournament! Total raised money: {totalMoney:f2}");




//Suitcases Load
double totalCapacity = double.Parse(Console.ReadLine());

int luggageCounter = 0;
double sumLuggageSpace = 0;

string input = "";


while ((input = Console.ReadLine()) != "End")
{

    luggageCounter++;
    double currentLuggageSpace = double.Parse(input);

    if (luggageCounter % 3 == 0)
    {
        currentLuggageSpace *= 1.1;
    }

    sumLuggageSpace += currentLuggageSpace;

    if (totalCapacity < sumLuggageSpace)
    {
        luggageCounter--;
        break;
    }
}


if (input == "End")
{
    Console.WriteLine("Congratulations! All suitcases are loaded!");
}
else
{
    Console.WriteLine("No more space!");
}

Console.WriteLine($"Statistic: {luggageCounter} suitcases loaded.");




//Care of Puppy
int allFood = int.Parse(Console.ReadLine());

allFood *= 1000;
int dailyFoodTotal = 0;

string input;
while ((input = Console.ReadLine()) != "Adopted")
{
    int dailyFood = int.Parse(input);

    dailyFoodTotal += dailyFood;
}

if (allFood - dailyFoodTotal >= 0)
{
    Console.WriteLine($"Food is enough! Leftovers: {allFood - dailyFoodTotal} grams.");
}
else
{
    Console.WriteLine($"Food is not enough. You need {dailyFoodTotal - allFood} grams more.");
}




//Programming Basics Online Exam - 6 and 7 April 2019
//Movie Ratings
int numberMovies = int.Parse(Console.ReadLine());

string movieName = Console.ReadLine();
decimal movieRating = decimal.Parse(Console.ReadLine());

decimal highestRating = movieRating;
decimal lowestRating = movieRating;
decimal sumAllRatings = movieRating;
string highestName = movieName;
string lowestName = movieName;


for (int i = 1; i < numberMovies; i++)
{
    movieName = Console.ReadLine();
    movieRating = decimal.Parse(Console.ReadLine());

    if (movieRating >= highestRating)
    {
        highestRating = movieRating;
        highestName = movieName;
    }
    else if (movieRating < lowestRating)
    {
        lowestRating = movieRating;
        lowestName = movieName;
    }

    sumAllRatings += movieRating;
}

Console.WriteLine($"{highestName} is with highest rating: {highestRating}");
Console.WriteLine($"{lowestName} is with lowest rating: {lowestRating}");
Console.WriteLine($"Average rating: {sumAllRatings / numberMovies:f1}");
Programming Basics Online Exam - 20 and 21 April 2019




//Easter Decoration
int numberClients = int.Parse(Console.ReadLine());
double totalPrice = 0;

for (int i = 0; i < numberClients; i++)
{
    string product;
    int itemCount = 0;
    double priceClient = 0;


    while ((product = Console.ReadLine()) != "Finish")
    {
        itemCount++;

        if (product == "basket")
        {
            priceClient += 1.5;
        }
        else if (product == "wreath")
        {
            priceClient += 3.8;
        }
        else
        {
            priceClient += 7;
        }
    }
    if (itemCount % 2 == 0)
    {
        priceClient *= 0.8;
    }

    totalPrice += priceClient;

    Console.WriteLine($"You purchased {itemCount} items for {priceClient:f2} leva.");
}

Console.WriteLine($"Average bill per client is: {totalPrice / numberClients:f2} leva.");




//Easter Competition
int numberKozunak = int.Parse(Console.ReadLine());
int bestRating = 0;
string bestBaker = "";


for (int i = 0; i < numberKozunak; i++)
{
    string bakerName = Console.ReadLine();
    string input;
    int sumRating = 0;

    while ((input = Console.ReadLine()) != "Stop")
    {
        int rating = int.Parse(input);
        sumRating += rating;
    }

    Console.WriteLine($"{bakerName} has {sumRating} points.");
    if (sumRating > bestRating)
    {
        bestBaker = bakerName;
        bestRating = sumRating;
        Console.WriteLine($"{bakerName} is the new number 1!");
    }
}

Console.WriteLine($"{bestBaker} won competition with {bestRating} points!");




//Programming Basics Online Retake Exam - 2 and 3 May 2019
//Division Without Remainder
int numbers = int.Parse(Console.ReadLine());
int p1 = 0;
int p2 = 0;
int p3 = 0;

for (int i = 0; i < numbers; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    if (currentNumber % 2 == 0)
    {
        p1++;
    }
    if (currentNumber % 3 == 0)
    {
        p2++;
    }
    if (currentNumber % 4 == 0)
    {
        p3++;
    }
}

Console.WriteLine($"{100.00 * p1 / numbers:f2}%");
Console.WriteLine($"{100.00 * p2 / numbers:f2}%");
Console.WriteLine($"{100.00 * p3 / numbers:f2}%");




//Tourist Shop
double budget = double.Parse(Console.ReadLine());

string product;
int productCounter = 0;
double allProductsPrice = 0;

while (allProductsPrice <= budget && (product = Console.ReadLine()) != "Stop")
{
    productCounter++;

    double productPrice = double.Parse(Console.ReadLine());

    if (productCounter % 3 == 0)
    {
        productPrice *= 0.5;
    }

    allProductsPrice += productPrice;

    if (allProductsPrice > budget)
    {
        Console.WriteLine("You don't have enough money!");
        Console.WriteLine($"You need {allProductsPrice - budget:f2} leva!");
    }
}
if (budget >= allProductsPrice)
{
    Console.WriteLine($"You bought {productCounter} products for {allProductsPrice:f2} leva.");
}




//Programming Basics Online Exam - 6 and 7 July 2019
//The Most Powerful Word
string word;

int highestSum = 0;
string powerWord = "";

while ((word = Console.ReadLine()) != "End of words")
{
    int wordSum = 0;

    for (int i = 0; i < word.Length; i++)
    {
        wordSum += word[i];
    }

    if (word[0] == 97 || word[0] == 'e' || word[0] == 'i' || word[0] == 'o' || word[0] == 'u' || word[0] == 'y' ||
        word[0] == 'A' || word[0] == 'E' || word[0] == 'I' || word[0] == 'O' || word[0] == 'U' || word[0] == 'Y')
    {
        wordSum *= word.Length;
    }
    else
    {
        wordSum /= word.Length;
    }

    if (wordSum > highestSum)
    {
        highestSum = wordSum;
        powerWord = word;
    }
}

Console.WriteLine($"The most powerful word is {powerWord} - {highestSum}");




//Name Game
string name;
int highestScore = 0;
string bestPlayerName = "";

while ((name = Console.ReadLine()) != "Stop")
{
    int score = 0;

    for (int i = 0; i < name.Length; i++)
    {
        int currentNumber = int.Parse(Console.ReadLine());

        if (currentNumber == name[i])
        {
            score += 10;
        }
        else
        {
            score += 2;
        }
    }

    if (score >= highestScore)
    {
        highestScore = score;
        bestPlayerName = name;
    }
}

Console.WriteLine($"The winner is {bestPlayerName} with {highestScore} points!");




//Football Tournament
string soccerTeam = Console.ReadLine();
int gamesPlayed = int.Parse(Console.ReadLine());
int teamScore = 0;

int win = 0;
int draw = 0;
int lost = 0;

for (int i = 0; i < gamesPlayed; i++)
{
    char results = char.Parse(Console.ReadLine());

    if (results == 'W')
    {
        teamScore += 3;
        win++;
    }
    else if (results == 'D')
    {
        teamScore += 1;
        draw++;
    }
    else
    {
        lost++;
    }
}

if (gamesPlayed == 0)
{
    Console.WriteLine($"{soccerTeam} hasn't played any games during this season.");
}
else
{
    Console.WriteLine($"{soccerTeam} has won {teamScore} points during this season.");
    Console.WriteLine($"Total stats:");
    Console.WriteLine($"## W: {win}");
    Console.WriteLine($"## D: {draw}");
    Console.WriteLine($"## L: {lost}");
    Console.WriteLine($"Win rate: {100.00 * win / gamesPlayed:f2}%");
}




//PC Game Shop
int soldGames = int.Parse(Console.ReadLine());

int hearthstone = 0;
int fornite = 0;
int overwatch = 0;
int others = 0;

for (int i = 0; i < soldGames; i++)
{
    string gameName = Console.ReadLine();

    if (gameName == "Hearthstone")
    {
        hearthstone++;
    }
    else if (gameName == "Fornite")
    {
        fornite++;
    }
    else if (gameName == "Overwatch")
    {
        overwatch++;
    }
    else
    {
        others++;
    }
}

Console.WriteLine($"Hearthstone - {100.0 * hearthstone / soldGames:f2}%");
Console.WriteLine($"Fornite - {100.0 * fornite / soldGames:f2}%");
Console.WriteLine($"Overwatch - {100.0 * overwatch / soldGames:f2}%");
Console.WriteLine($"Others - {100.0 * others / soldGames:f2}%");




//Club
double targetProfit = double.Parse(Console.ReadLine());

string coctailName;
double totalPrice = 0;

while ((coctailName = Console.ReadLine()) != "Party!")
{
    int numberCoctails = int.Parse(Console.ReadLine());

    double coctailsPrice = coctailName.Length * numberCoctails;

    if (coctailsPrice % 2 == 1)
    {
        coctailsPrice *= 0.75;
    }

    totalPrice += coctailsPrice;

    if (totalPrice >= targetProfit)
    {
        Console.WriteLine("Target acquired.");
        break;
    }
}

if (coctailName == "Party!")
{
    Console.WriteLine($"We need {targetProfit - totalPrice:f2} leva more.");
}
Console.WriteLine($"Club income - {totalPrice:f2} leva.");




//Misc
//On time for the exam
int examHour = int.Parse(Console.ReadLine());
int examMinute = int.Parse(Console.ReadLine());
int arrivalHour = int.Parse(Console.ReadLine());
int arrivalMinute = int.Parse(Console.ReadLine());

int diff = examHour * 60 + examMinute - (arrivalHour * 60 + arrivalMinute);
int diffHours = Math.Abs(diff / 60);
int diffMin = Math.Abs(diff % 60);

string status = "";
string beforeAfter = "";

if (diff < 0)
{
    status = "Late";
    beforeAfter = "after";

}

else if (diff <= 30)
{
    status = "On time";
    beforeAfter = "before";
}
else
{
    status = "Early";
    beforeAfter = "before";
}

string firstPart = "";

diff = Math.Abs(diff);

if (diff >= 60)
{
    if (diffMin < 10)
        firstPart = $"{diffHours}:0{diffMin} hours";
    else
    {
        firstPart = $"{diffHours}:{diffMin} hours";
    }
}
else
{
    firstPart = $"{diff} minutes";
}
Console.WriteLine(status);
if (diff != 0)
{
    Console.WriteLine($"{firstPart} {beforeAfter} the start");
}




//Random drawing
int n = 59;

int half = n / 2 + 1;
int counter = 0;

for (int i = 1; i <= n; i++)
{
    for (int j = 1; j <= n; j++)
    {
        if (i < half)
        {
            if (i == half - 3)
            {
                if (j >= half - counter && j <= half + counter)
                {
                    if (j == half)
                    {
                        Console.Write("s");
                    }
                    else
                        Console.Write("h");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            else if (j == half - counter || j == half + counter)
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(" ");
            }
        }
        else if (i == half)
        {
            if (j == 1 || j == n)
            {
                Console.Write("*");
            }

            else
                Console.Write("&");
        }
        else
        {
            if (i == half + 3)
            {
                if (j >= half - counter + 1 && j <= half + counter - 1)
                {
                    if (j == half)
                    {
                        Console.Write("s");
                    }
                    else
                        Console.Write("h");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            else if (j == half - counter + 1 || j == half + counter - 1)
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(" ");
            }
        }
    }

    if (i < half)
    {
        counter++;
    }
    else if (i > half)
    {
        counter--;
    }

    Console.WriteLine();
}