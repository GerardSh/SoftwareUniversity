decimal change = decimal.Parse(Console.ReadLine());

int coinCounter = 0;
int currentCoinCounter = 0;
if ((int)change / 2 > 0)
{
    coinCounter += (int)(change / 2);
    change = change - coinCounter * 2;
}

if ((int)change / 1 > 0)
{
    coinCounter += (int)(change / 1);
    change = change - 1;
}

if (change > 0)
    change *= 100;
if ((int)change / 50 > 0)
{
    coinCounter += (int)(change / 50);
    change = change - 50;
}
if ((int)change / 20 > 0)
{
    coinCounter += (int)(change / 20);
    currentCoinCounter += (int)(change / 20);
    change = change - 20 * currentCoinCounter;
}
if ((int)change / 10 > 0)
{
    coinCounter += (int)(change / 10);
    change = change - 10;
}
if ((int)change / 5 > 0)
{
    coinCounter += (int)(change / 5);
    change = change - 5;
}
currentCoinCounter = 0;
if ((int)change / 2 > 0)
{
    coinCounter += (int)(change / 2);
    currentCoinCounter += (int)(change / 2);
    change = change - 2 * currentCoinCounter;
}
if ((int)change / 1 > 0)
{
    coinCounter += (int)(change / 1);
    change = change - 1;
}

Console.WriteLine(coinCounter);

// Second variant

//double change = double.Parse(Console.ReadLine());

//int coins = 0;
//int changeInCoins = (int)(change * 100);


//while (changeInCoins > 0)
//{
//    if (changeInCoins / 200 > 0)
//    {
//        coins++;
//        changeInCoins -= 200;
//    }
//    else if (changeInCoins / 100 > 0)
//    {
//        coins++;
//        changeInCoins -= 100;
//    }
//    else if (changeInCoins / 50 > 0)
//    {
//        coins++;
//        changeInCoins -= 50;
//    }
//    else if (changeInCoins / 20 > 0)
//    {
//        coins++;
//        changeInCoins -= 20;
//    }
//    else if (changeInCoins / 10 > 0)
//    {
//        coins++;
//        changeInCoins -= 10;
//    }
//    else if (changeInCoins / 5 > 0)
//    {
//        coins++;
//        changeInCoins -= 5;
//    }
//    else if (changeInCoins / 2 > 0)
//    {
//        coins++;
//        changeInCoins -= 2;
//    }
//    else if (changeInCoins / 1 > 0)
//    {
//        coins++;
//        changeInCoins -= 1;
//    }
//}

//Console.WriteLine(coins);