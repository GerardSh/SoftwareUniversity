List<double> list = Console.ReadLine().Split().Select(double.Parse).ToList();

for (int i = 0; i < list.Count - 1; i++)
{
    if (list[i] == list[i + 1])
    {
        list.Insert(i, list[i] + list[i + 1]);
        list.Remove(list[i + 1]);
        list.Remove(list[i + 1]);

        i = -1;
    }
}

Console.WriteLine(string.Join(" ", list));

////2
//List<double> list = Console.ReadLine().Split().Select(double.Parse).ToList();

//for (int i = 0; i < list.Count - 1; i++)
//{
//    if (list[i] == list[i + 1])
//    {
//        list[i] *= 2;
//        list.RemoveAt(i + 1);

//        i = -1;
//    }
//}

//Console.WriteLine(string.Join(" ", list));