using System.Diagnostics;

public class StartUp
{
    public static void Main()
    {
        var chronometer = new Chronometer();
        string command;

        Console.WriteLine("Chronometer started. Awaiting commands...");

        while ((command = Console.ReadLine()) != "exit")
        {
            switch (command)
            {
                case "start":
                    Task.Run(() =>
                    {
                        chronometer.Start();
                    });
                    break;

                case "stop":
                    chronometer.Stop();
                    break;

                case "lap":
                    Console.WriteLine($"Lap: {chronometer.Lap()}");
                    break;

                case "laps":
                    var laps = chronometer.Laps;
                    if (laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                    }
                    else
                    {
                        Console.WriteLine("Laps: ");
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
