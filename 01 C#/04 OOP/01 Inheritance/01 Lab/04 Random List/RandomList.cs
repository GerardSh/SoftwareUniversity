namespace ConsoleApp
{
    public class RandomList : List<string>
    {
        Random random = new Random();

        public string RandomString()
        {
            int number = random.Next(Count);

            string stringToReturn = this[number];

            RemoveAt(number);

            return stringToReturn;
        }
    }
}
