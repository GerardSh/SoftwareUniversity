namespace ImplementingCustomQueue
{
    internal class CustomQueue<T>
    {
        private const int InitialCapacity = 4;

        private const int FirstItemIndex = 0;

        public int Count { get; private set; }

        private T[] items { get; set; } = new T[InitialCapacity];

        private int Capacity => items.Length;

        public void Enqueue(T item)
        {
            if (Count == Capacity)
            {
                Resize();
            }

            items[Count++] = item;
        }

        public T Dequeue()
        {
            IsEmpty();

            T firstItem = items[FirstItemIndex];

            ShiftToLeft();

            items[Count-- - 1] = default;

            if (Count <= Capacity / 4)
            {
                Shrink();
            }

            return firstItem;
        }

        public T Peek()
        {
            IsEmpty();

            return items[FirstItemIndex];
        }

        public void Clear()
        {
            IsEmpty();

            items = new T[InitialCapacity];
            Count = 0;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        private void IsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue empty.");
            }
        }

        private void ShiftToLeft()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
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

            //Option 1
            //for (int i = 0; i < Count; i++)
            //{
            //    tempArr[i] = items[i];
            //}

            //Option 2
            items.CopyTo(tempArr, 0);

            items = tempArr;
        }
    }
}