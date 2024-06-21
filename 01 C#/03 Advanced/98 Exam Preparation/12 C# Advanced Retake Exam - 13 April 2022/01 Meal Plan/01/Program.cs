namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var caloriesByFood = new Dictionary<string, int>()
            {
                {"salad",350},
                {"soup", 490},
                {"pasta", 680},
                {"steak", 790},
            };

            int mealsEaten = 0;

            while (meals.Any() && calories.Any())
            {
                string meal = meals.Dequeue();
                int dailyCalories = calories.Pop();
                int dailyMeal = caloriesByFood[meal];

                int sum = dailyCalories - dailyMeal;

                if (sum > 0)
                {
                    calories.Push(sum);
                    mealsEaten++;
                    continue;
                }

                if (sum == 0)
                {
                    mealsEaten++;
                    continue;
                }

                dailyMeal = sum * -1;

                while (dailyMeal > 0 && calories.Any())
                {
                    dailyCalories = calories.Pop();

                    dailyMeal -= dailyCalories;

                    if (dailyMeal < 0)
                    {
                        mealsEaten++;
                        calories.Push(dailyMeal * -1);
                        break;
                    }
                    else if (dailyMeal == 0)
                    {
                        mealsEaten++;
                        meals.Dequeue();
                        break;
                    }
                }

                if (dailyMeal > 0)
                {
                    mealsEaten++;
                    break;
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}