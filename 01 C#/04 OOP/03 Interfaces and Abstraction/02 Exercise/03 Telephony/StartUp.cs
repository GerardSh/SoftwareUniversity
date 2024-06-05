namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Any(x => !char.IsNumber(x)))
                    {
                        throw new ArgumentException("Invalid number!");
                    }

                    if (phoneNumber.Length == 10)
                    {
                        smartPhone.Call(phoneNumber);
                    }
                    else
                    {
                        stationaryPhone.Call(phoneNumber);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (string website in websites)
            {
                try
                {
                    if (website.Any(x => char.IsNumber(x)))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }

                    smartPhone.Browsing(website);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
