namespace ImplementingCustomStack
{
    internal class CustomStack
    {
        const int InitialCapacity = 4;

        private int[] items { get; set; } = new int[InitialCapacity];

        public int Count { get; private set; }

        private int Capacity => items.Length;

        public void Push(int item)
        {
            if (Count == Capacity)
            {
                Resize();
            }

            items[Count++] = item;
        }

        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack empty.");
            }

            int lastItem = items[Count - 1];
            items[Count-- - 1] = default;

            if (Count <= Capacity / 4)
            {
                Shrink();
            }

            return lastItem;
        }

        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack empty.");
            }

            return items[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
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

            for (int i = 0; i < Count; i++)
            {
                tempArr[i] = items[i];
            }

            items = tempArr;
        }
    }
}
