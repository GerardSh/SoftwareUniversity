using System.Collections;

namespace ConsoleApp
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        List<T> list;

        int index = 0;

        public ListyIterator(List<T> list)
        {
            this.list = list;
        }

        public bool Move()
        {
            if (index < list.Count - 1)
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index < list.Count - 1;
        }

        public void Print()
        {
            if (list.Count > 0)
            {
                Console.WriteLine(list[index]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}