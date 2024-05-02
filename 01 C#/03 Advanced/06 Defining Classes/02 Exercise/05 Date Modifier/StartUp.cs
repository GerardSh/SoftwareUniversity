namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            string[] dates = new string[2];

            dates[0] = Console.ReadLine();
            dates[1] = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            dateModifier.GetDateDifference(dates);

            Console.WriteLine(dateModifier.DateDifference);
        }
    }
}