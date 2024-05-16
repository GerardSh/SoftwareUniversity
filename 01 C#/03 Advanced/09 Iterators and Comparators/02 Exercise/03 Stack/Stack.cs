using System.Collections;

namespace ConsoleApp
{
    public class Stack<T> : IEnumerable<T>
    {
        List<T> list = new List<T>();

        public void Push(params T[] elements)
        {
            list.AddRange(elements);
        }

        public bool HasElements()
        {
            return list.Count > 0;
        }

        public T Pop()
        {
            T temp = list[list.Count - 1];

            list.RemoveAt(list.Count -1);

            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
