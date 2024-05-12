namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            string[] elements = Console.ReadLine()
                .Split();

            var threeupleOne = new CustomThreeuple<string, string, string>();

            threeupleOne.ItemOne = $"{elements[0]} {elements[1]}";
            threeupleOne.ItemTwo = elements[2];

            for (int i = 3; i < elements.Length; i++)
            {
                threeupleOne.ItemThree += elements[i] + " ";
            }

            threeupleOne.ItemThree = threeupleOne.ItemThree.TrimEnd();

            elements = Console.ReadLine()
                .Split();

            var threeupleTwo = new CustomThreeuple<string, int, bool>();

            threeupleTwo.ItemOne = $"{elements[0]}";
            threeupleTwo.ItemTwo = int.Parse(elements[1]);

            if (elements[2] == "drunk")
            {
                threeupleTwo.ItemThree = true;
            }
            else
            {
                threeupleTwo.ItemThree = false;
            }

            elements = Console.ReadLine()
               .Split();

            var threeupleThree = new CustomThreeuple<string, double, string>();

            threeupleThree.ItemOne = elements[0];
            threeupleThree.ItemTwo = double.Parse(elements[1]);
            threeupleThree.ItemThree =(elements[2]);

            Console.WriteLine(threeupleOne);
            Console.WriteLine(threeupleTwo);
            Console.WriteLine(threeupleThree);
        }
    }
}