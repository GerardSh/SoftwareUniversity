namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var whiteTiles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var locationByTileArea = new Dictionary<int, string>()
            {
                {40, "Sink"},
                {50, "Oven"},
                {60, "Countertop"},
                {70, "Wall"},
            };

            var countByTiles = new SortedDictionary<string, int>();

            while (greyTiles.Any() && whiteTiles.Any())
            {
                int greyTile = greyTiles.Dequeue();
                int whiteTile = whiteTiles.Pop();

                int sum = 0;

                if (greyTile == whiteTile)
                {
                    sum = greyTile + whiteTile;

                    if (locationByTileArea.ContainsKey(sum))
                    {
                        string item = locationByTileArea[sum];

                        if (!countByTiles.ContainsKey(item))
                        {
                            countByTiles[item] = 0;
                        }

                        countByTiles[item]++;
                    }
                    else
                    {
                        if (!countByTiles.ContainsKey("Floor"))
                        {
                            countByTiles["Floor"] = 0;
                        }

                        countByTiles["Floor"]++;
                    }
                }
                else
                {
                    whiteTiles.Push(whiteTile / 2);
                    greyTiles.Enqueue(greyTile);
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var kvp in countByTiles.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}