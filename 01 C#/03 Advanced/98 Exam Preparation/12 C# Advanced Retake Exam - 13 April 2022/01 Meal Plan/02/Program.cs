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
            int dailyMeal = 0;
            bool mealFinished = true;

            while (meals.Any() && calories.Any())
            {
                int dailyCalories = calories.Pop();

                if (mealFinished)
                {
                    string meal = meals.Peek();
                    dailyMeal = caloriesByFood[meal];
                    mealsEaten++;
                }

                int sum = dailyMeal - dailyCalories;

                if (sum > 0)
                {
                    mealFinished = false;
                    dailyMeal = sum;
                    if (calories.Count == 0)
                    {
                        meals.Dequeue();
                    }
                }
                else if (sum <= 0)
                {
                    mealFinished = true;
                    meals.Dequeue();

                    if (sum == 0)
                    {
                        continue;
                    }
                    else
                    {
                        calories.Push(sum * -1);
                    }
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