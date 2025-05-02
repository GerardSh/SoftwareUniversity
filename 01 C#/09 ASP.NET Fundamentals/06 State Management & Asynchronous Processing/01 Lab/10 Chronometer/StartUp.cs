using System;
using System.Threading.Tasks;

public class StartUp
{
    public static async Task Main()
    {
        IChronometer chronometer = new Chronometer();
        Console.WriteLine("Chronometer started. Awaiting commands...");

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "exit")
            {
                chronometer.Stop();
                break;
            }

            switch (command)
            {
                case "start":
                    await Task.Run(() => chronometer.Start());
                    break;

                case "stop":
                    chronometer.Stop();
                    break;

                case "lap":
                    string lapTime = chronometer.Lap();
                    Console.WriteLine($"Lap: {lapTime}");
                    break;

                case "laps":
                    var laps = chronometer.Laps;
                    if (laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                    }
                    else
                    {
                        Console.WriteLine("Laps:");
                        for (int i = 0; i < laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {laps[i]}");
                        }
                    }
                    break;

                case "time":
                    Console.WriteLine(chronometer.GetTime);
                    break;

                case "reset":
                    chronometer.Reset();
                    Console.WriteLine("Chronometer reset.");
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }

        Console.WriteLine("Chronometer stopped.");
    }
}
