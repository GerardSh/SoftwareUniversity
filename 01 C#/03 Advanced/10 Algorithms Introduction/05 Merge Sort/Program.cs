namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine(string.Join(" ", Split(list, 0, list.Count)));
        }

        static List<int> Split(List<int> list, int start, int end)
        {
            if (end - start == 1)
            {
                return new List<int>() { list[start] };
            }

            int middle = (start + end) / 2;

            List<int> sortedLeftPart = Split(list, start, middle);

            List<int> sortedRightPart = Split(list, middle, end);

            return Merge(sortedLeftPart, sortedRightPart);
        }

        static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> sortedList = new List<int>(left.Count + right.Count);

            int leftIndex = 0;
            int rightIndex = 0;
    
            for (int i = 0; i < left.Count + right.Count; i++)
            {
                if (leftIndex >= left.Count)
                {
                    sortedList.Add(right[rightIndex++]);
                    continue;
                }

                if (rightIndex >= right.Count)
                {
                    sortedList.Add(left[leftIndex++]);
                    continue;
                }

                if (left[leftIndex] <= right[rightIndex])
                {
                    sortedList.Add(left[leftIndex++]);
                }
                else
                {
                    sortedList.Add(right[rightIndex++]);
                }
            }

            return sortedList;
        }
    }
}