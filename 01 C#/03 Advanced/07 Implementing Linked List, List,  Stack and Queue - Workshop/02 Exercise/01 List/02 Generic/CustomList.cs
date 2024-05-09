using System;

namespace ImplementingCustomList
{
    public class CustomList<T>
    {
        private const int DefaultCapacity = 2;

        public T this[int i]
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

        private int capacity => items.Length;

        private T[] items = new T[DefaultCapacity];

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (Count == capacity)
            {
                Resize();
            }

            items[Count++] = element;
        }

        public void Print()
        {
            T[] tempArr = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                tempArr[i] = items[i];
            }

            Console.WriteLine(string.Join(", ", tempArr));
        }

        public T RemoveAt(int index)
        {
            if (!ValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            T removedValue = items[index];

            ShiftToLeft(index);

            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return removedValue;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(value))
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

            T temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        public void InsertAt(int index, T item)
        {
            if (!ValidIndex(index))
            {
                throw new IndexOutOfRangeException();
            }

            if (capacity == Count)
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
            T[] tempArr = new T[capacity * 2];

            for (int i = 0; i < capacity; i++)
            {
                tempArr[i] = items[i];
            }

            items = tempArr;
        }

        private void Shrink()
        {
            T[] tempArr = new T[capacity / 2];

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
