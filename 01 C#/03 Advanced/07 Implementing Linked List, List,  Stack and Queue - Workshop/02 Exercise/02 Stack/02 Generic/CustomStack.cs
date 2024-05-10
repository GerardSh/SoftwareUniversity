using System.Collections;

namespace ImplementingCustomStack
{
    public class CustomStack<T> 
        : IEnumerable<T>
    {
        const int InitialCapacity = 4;

        private T[] items { get; set; } = new T[InitialCapacity];

        public int Count { get; private set; }

        private int Capacity => items.Length;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Push(T item)
        {
            if (Count == Capacity)
            {
                Resize();
            }

            items[Count++] = item;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack empty.");
            }

            T lastItem = items[Count - 1];
            items[Count-- - 1] = default;

            if (Count <= Capacity / 4)
            {
                Shrink();
            }

            return lastItem;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack empty.");
            }

            return items[Count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        private void Shrink()
        {
            T[] tempArr = new T[Capacity / 4];

            for (int i = 0; i < Count; i++)
            {
                tempArr[i] = items[i];
            }

            items = tempArr;
        }

        private void Resize()
        {
            T[] tempArr = new T[Capacity * 2];

            for (int i = 0; i < Count; i++)
            {
                tempArr[i] = items[i];
            }

            items = tempArr;
        }
    }
}
