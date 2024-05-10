namespace ImplementingCustomQueue
{
    internal class CustomQueue
    {
        private const int InitialCapacity = 4;

        private const int FirstItemIndex = 0;

        public int Count { get; private set; }

        private int[] items { get; set; } = new int[InitialCapacity];

        private int Capacity => items.Length;

        public void Enqueue(int item)
        {
            if (Count == Capacity)
            {
                Resize();
            }

            items[Count++] = item;
        }

        public int Dequeue()
        {
            IsEmpty();

            int firstItem = items[FirstItemIndex];

            ShiftToLeft();

            items[Count-- - 1] = default;

            if (Count <= Capacity / 4)
            {
                Shrink();
            }

            return firstItem;
        }

        public int Peek()
        {
            IsEmpty();

            return items[FirstItemIndex];
        }

        public void Clear()
        {
            IsEmpty();

            items = new int[InitialCapacity];
            Count = 0;
        }

        public void ForEach(Action<int> action)
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
            int[] tempArr = new int[Capacity / 4];

            for (int i = 0; i < Count; i++)
            {
                tempArr[i] = items[i];
            }

            items = tempArr;
        }

        private void Resize()
        {
            int[] tempArr = new int[Capacity * 2];

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