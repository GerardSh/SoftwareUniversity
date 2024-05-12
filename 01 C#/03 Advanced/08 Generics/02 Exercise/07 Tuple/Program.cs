namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            string[] elements = Console.ReadLine()
                .Split();

            CustomTuple<string, string> tupleOne = new CustomTuple<string, string>();

            tupleOne.ItemOne = $"{elements[0]} {elements[1]}";
            tupleOne.ItemTwo = elements[2];

            elements = Console.ReadLine()
                .Split();

            CustomTuple<string, int> tupleTwo = new CustomTuple<string, int>();

            tupleTwo.ItemOne = $"{elements[0]}";
            tupleTwo.ItemTwo = int.Parse(elements[1]);

            elements = Console.ReadLine()
               .Split();

            CustomTuple<int, double> tupleThree = new CustomTuple<int, double>();

            tupleThree.ItemOne = int.Parse(elements[0]);
            tupleThree.ItemTwo = double.Parse(elements[1]);

            Console.WriteLine(tupleOne);
            Console.WriteLine(tupleTwo);
            Console.WriteLine(tupleThree);
        }
    }
}