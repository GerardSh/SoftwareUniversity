namespace FoodShortage
{
    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> list = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (elements.Length == 4)
                {
                    list.Add(new Citizen(elements[0], int.Parse(elements[1]), elements[2], elements[3]));
                }
                else
                {
                    list.Add(new Rebel(elements[0], int.Parse(elements[1]), elements[2]));
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string name = input;

                IBuyer buyer = list.FirstOrDefault(x => x.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(list.Sum(x=>x.Food));
        }
    }
}