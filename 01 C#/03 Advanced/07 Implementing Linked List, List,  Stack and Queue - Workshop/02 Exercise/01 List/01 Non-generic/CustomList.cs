using System;

namespace ImplementingCustomList
{
    public class CustomList
    {
        private const int DefaultCapacity = 2;

        public int this[int i]
        {
            get
            {
                if (ValidIndex(i))
                {
                    return items[i];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (ValidIndex(i))
                {
                    items[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        private int Capacity => items.Length;

        private int[] items = new int[DefaultCapacity];

        public int Count { get; private set; }

        public void Add(int element)
        {
            if (Count == Capacity)
            {
                Resize();
            }

            items[Count++] = element;
        }

        public void Print()
        {
            Console.WriteLine(string.Join(" ", items));
        }

        public int RemoveAt(int index)
        {
            if (!ValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            int removedValue = items[index];

            ShiftToLeft(index);

            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return removedValue;
        }

        public bool Contains(int value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (!ValidIndex(firstIndex) || !ValidIndex(secondIndex))
            {
                throw new IndexOutOfRangeException();
            }

            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        public void InsertAt(int index, int item)
        {
            if (!ValidIndex(index))
            {
                throw new IndexOutOfRangeException();
            }

            if (Capacity == Count)
            {
                Resize();
            }

            ShiftToRight(index);

            items[index] = item;

            Count++;
        }

        private void ShiftToLeft(int index)
        {
            //Option 1
            //int[] tempArr = new int[items.Length];

            //for (int i = 0; i < Count - 1; i++)
            //{
            //    if (i < index)
            //    {
            //        tempArr[i] = items[i];
            //    }
            //    else if (i >= index)
            //    {
            //        tempArr[i] = items[i + 1];
            //    }
            //}

            //items = tempArr;

            //Option 2
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default;
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }
        }

        private void Resize()
        {
            int[] tempArr = new int[Capacity * 2];

            for (int i = 0; i < Capacity; i++)
            {
                tempArr[i] = items[i];
            }

            items = tempArr;
        }

        private void Shrink()
        {
            int[] tempArr = new int[Capacity / 2];

            for (int i = 0; i < Count; i++)
            {
                tempArr[i] = items[i];
            }

            items = tempArr;
        }

        private bool ValidIndex(int index)
        {
            return index >= 0 && index < Count;
        }
    }
}
