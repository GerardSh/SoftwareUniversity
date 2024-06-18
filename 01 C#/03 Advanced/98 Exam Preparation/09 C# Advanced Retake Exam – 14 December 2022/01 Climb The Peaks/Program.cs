namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var mountainsByDifficulty = new Dictionary<string, int>()
            {
                {"Vihren", 80 },
                {"Kutelo", 90 },
                {"Banski Suhodol", 100},
                {"Polezhan", 60},
                {"Kamenitza", 70},
            };

            var mountainPeaks = new List<string>() { "Vihren", "Kutelo", "Banski Suhodol", "Polezhan", "Kamenitza" };
            var conqueredPeaks = new List<string>();

            var portions = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            var stamina = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            bool peaksClimbed = false;
            int days = 0;

            while (portions.Any() && stamina.Any() && days++ < 7)
            {
                int dailyPortion = portions.Pop();
                int dailyStamina = stamina.Dequeue();

                int sum = dailyPortion + dailyStamina;

                if (sum >= mountainsByDifficulty[mountainPeaks[0]])
                {
                    conqueredPeaks.Add(mountainPeaks[0]);
                    mountainPeaks.RemoveAt(0);

                    if (mountainPeaks.Count == 0)
                    {
                        peaksClimbed = true;
                        break;
                    }
                }
            }

            if (peaksClimbed)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (conqueredPeaks.Count > 0)
            {
            Console.WriteLine("Conquered peaks:");
            }

            foreach (var peak in conqueredPeaks)
            {
                Console.WriteLine(peak);
            }
        }
    }
}