namespace BorderControl
{
    public class Program
    {
        public static void Main()
        {
            List<IIdentifiable> citizensAndRobots = new List<IIdentifiable>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (elements.Length == 2)
                {
                    citizensAndRobots.Add(new Robot(elements[0], elements[1]));
                }
                else
                {
                    citizensAndRobots.Add(new Citizen(elements[0], int.Parse(elements[1]), elements[2]));
                }
            }

            string fakeIdNumber = Console.ReadLine();

            foreach (IIdentifiable citizenOrRobot in citizensAndRobots)
            {
                //Option 1
                //if (citizenOrRobot.Id.Substring(citizenOrRobot.Id.Length - fakeIdNumber.Length) == fakeIdNumber)
                //{
                //    Console.WriteLine(citizenOrRobot.Id);
                //}

                //Option 2
                if (citizenOrRobot.Id.EndsWith(fakeIdNumber))
                {
                    Console.WriteLine(citizenOrRobot.Id);
                }
            }
        }
    }
}
