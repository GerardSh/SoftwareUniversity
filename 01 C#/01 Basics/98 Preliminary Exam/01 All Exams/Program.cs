//Exam Start time 10:08
//01.Christmas Preparation
//int paperRolls = int.Parse(Console.ReadLine());
//int clothRolls = int.Parse(Console.ReadLine());
//double glue = double.Parse(Console.ReadLine());
//double discount = int.Parse(Console.ReadLine());

//double paperPrice = paperRolls * 5.8;
//double clothPrice = clothRolls * 7.2;
//double gluePrice = glue * 1.2;

//double totalPrice = paperPrice + clothPrice + gluePrice;

//double priceWithDiscount = totalPrice * ((100 - discount) / 100);

//Console.WriteLine($"{priceWithDiscount:f3}");
////10:21:27 17.02.2024

//02.Bracelet Stand
//double dailyMoney = double.Parse(Console.ReadLine());
//double dailyIncome = double.Parse(Console.ReadLine());
//double periodExpenses = double.Parse(Console.ReadLine());
//double giftPrice = double.Parse(Console.ReadLine());

//double savedMoney = dailyMoney * 5;
//double earnedMoney = dailyIncome * 5;

//double totalSavedMoney = savedMoney + earnedMoney;
//totalSavedMoney -= periodExpenses;

//if (totalSavedMoney >= giftPrice)
//{
//    Console.WriteLine($"Profit: {totalSavedMoney:f2} BGN, the gift has been purchased.");
//}
//else
//{
//    Console.WriteLine($"Insufficient money: {giftPrice - totalSavedMoney:f2} BGN.");
//}
////10:27:53 17.02.2024

//03.Final Competition
//int numberDancers = int.Parse(Console.ReadLine());
//double score = double.Parse(Console.ReadLine());
//string season = Console.ReadLine();
//string country = Console.ReadLine();

//double moneyEarned = numberDancers * score;

//if (country == "Abroad")
//{
//    moneyEarned *= 1.5;
//}

//double expenses = 0;

//switch (country)
//{
//    case "Bulgaria":
//        {
//            switch (season)
//            {
//                case "summer":
//                    {
//                        expenses = 5;
//                    }
//                    break;
//                default:
//                    {
//                        expenses = 8;
//                    }
//                    break;
//            }
//        }
//        break;
//    default:
//        {
//            switch (season)
//            {
//                case "summer":
//                    {
//                        expenses = 10;
//                    }
//                    break;
//                default:
//                    {
//                        expenses = 15;
//                    }
//                    break;
//            }
//        }
//        break;
//}

//double moneyAfterExpenses = moneyEarned * ((100 - expenses) / 100);

//double charity = moneyAfterExpenses * 0.75;

//double moneyAfterCharity = moneyAfterExpenses - charity;

//double moneyPerDancer = moneyAfterCharity / numberDancers;

//Console.WriteLine($"Charity - {charity:f2}");
//Console.WriteLine($"Money per dancer - {moneyPerDancer:f2}");
////10:50:40 17.02.2024

//04.Exam
//int numberOfStudents = int.Parse(Console.ReadLine());

//int topStudents = 0;
//int betweenFourAndFive = 0;
//int betweenTheeAndFour = 0;
//int fail = 0;
//double average = 0;

//for (int i = 0; i < numberOfStudents; i++)
//{
//    double score = double.Parse(Console.ReadLine());

//    if (score < 3)
//    {
//        fail++;
//    }
//    else if (score < 4)
//    {
//        betweenTheeAndFour++;
//    }
//    else if (score < 5)
//    {
//        betweenFourAndFive++;
//    }
//    else
//    {
//        topStudents++;
//    }

//    average += score;
//}

//Console.WriteLine($"Top students: {1.0 * topStudents / numberOfStudents * 100:f2}%");
//Console.WriteLine($"Between 4.00 and 4.99: {1.0 * betweenFourAndFive / numberOfStudents * 100:f2}%");
//Console.WriteLine($"Between 3.00 and 3.99: {1.0 * betweenTheeAndFour / numberOfStudents * 100:f2}%");
//Console.WriteLine($"Fail: {1.0 * fail / numberOfStudents * 100:f2}%");
//Console.WriteLine($"Average: {average / numberOfStudents:f2}");
////11:06:40 17.02.2024

//05.Everest
//using Microsoft.VisualBasic;

//string input = Console.ReadLine();

//int daysPassed = 1;
//int metersClimbed = 5364;

//if (input == "Yes")
//    daysPassed++;

//while (input != "END" && daysPassed < 6)
//{
//    int dailyMeters = int.Parse(Console.ReadLine());
//    metersClimbed += dailyMeters;

//    if (metersClimbed >= 8848)
//    {
//        Console.WriteLine($"Goal reached for {daysPassed} days!");
//        return;
//    }

//    input = Console.ReadLine();


//    if (input == "Yes")
//    {
//        daysPassed++;
//    }
//}

//Console.WriteLine($"Failed!");
//Console.WriteLine(metersClimbed);
////11:34:35 17.02.2024

//06.Substitute
//int kNumber = int.Parse(Console.ReadLine());
//int lNumber = int.Parse(Console.ReadLine());
//int mNumber = int.Parse(Console.ReadLine());
//int nNumber = int.Parse(Console.ReadLine());

//int numberOfSubtitudes = 0;

//for (int i = kNumber; i <= 8; i++)
//{
//    for (int j = 9; j >= lNumber; j--)
//    {
//        for (int k = mNumber; k <= 8; k++)
//        {
//            for (int l = 9; l >= nNumber; l--)
//            {
//                if (i % 2 == 0 && k % 2 == 0 && j % 2 == 1 && l % 2 == 1)
//                {
//                    if (i == k && j == l)
//                    {
//                        Console.WriteLine("Cannot change the same player.");
//                    }
//                    else
//                    {
//                        Console.WriteLine($"{i}{j} - {k}{l}");

//                        if (++numberOfSubtitudes == 6)
//                        {
//                            return;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
////12:06:29 17.02.2024