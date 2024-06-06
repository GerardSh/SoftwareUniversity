namespace BorderControl
{
    public class Program
    {
        public static void Main()
        {
            List<IIdentifiable> citizens = new List<IIdentifiable>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (elements.Length == 2)
                {
                    citizens.Add(new Robot(elements[0], elements[1]));
                }
                else
                {
                    citizens.Add(new Human(elements[0], int.Parse(elements[1]), elements[2]));
                }
            }

            string fakeIdNumber = Console.ReadLine();

            foreach (IIdentifiable citizen in citizens)
            {
                //Option 1
                //if (citizen.Id.Substring(citizen.Id.Length - fakeIdNumber.Length) == fakeIdNumber)
                //{
                //    Console.WriteLine(citizen.Id);
                //}

                //Option 2
                if (citizen.Id.EndsWith(fakeIdNumber))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}
