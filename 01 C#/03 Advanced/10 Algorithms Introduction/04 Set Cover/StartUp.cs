namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine()
                  .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();

            int numberOfSets = int.Parse(Console.ReadLine());

            List<int[]> sets = new List<int[]>(numberOfSets);

            for (int i = 0; i < numberOfSets; i++)
            {
                int[] currentArray = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                sets.Add(currentArray);
            }

            List<int[]> selectedSets = ChooseSets(sets, universe);

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (int[] set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>(sets.Count);

            while (universe.Count > 0)
            {
                //Option 1
                int[] longestSet = sets.OrderByDescending(s => s.Count(n => universe.Contains(n))).FirstOrDefault();

                //Option 2
                //int[] longestSet = null;
                //int maxCount = 0;

                //for (int i = 0; i < sets.Count; i++)
                //{
                //    int currentCount = 0;

                //    foreach (int n in universe)
                //    {
                //        foreach (int x in sets[i])
                //        {
                //            if (n == x)
                //            {
                //                currentCount++;
                //                break;
                //            }
                //        }
                //    }

                //    if (currentCount > maxCount)
                //    {
                //        maxCount = currentCount;
                //        longestSet = sets[i];
                //    }
                //}

                selectedSets.Add(longestSet);
                sets.Remove(longestSet);

                foreach (int number in longestSet)
                {
                    universe.Remove(number);
                }
            }

            return selectedSets;
        }
    }
}