using System.Diagnostics;

namespace ImplementDoublyLinkedList
{
    [DebuggerDisplay("Count = {Count}")]
    public class CustomDoublyLinkedList<T>
    {
        private LinkedListItem<T> first;

        private LinkedListItem<T> last;

        //Option 1
        public int Count { get; set; }

        //Option 2
        //public int Count
        //{
        //    get
        //    {
        //        int count = 0;
        //        var item = first;

        //        while (item != null)
        //        {
        //            count++;
        //            item = item.Next;
        //        }

        //        return count;
        //    }
        //}

        // Option 3 - recursion
        //public int Count
        //{
        //    get
        //    {
        //        int count = 0;
        //        var current = first;

        //        GetCount();

        //        return count;

        //        void GetCount()
        //        {
        //            if (current != null)
        //            {
        //                count++;
        //                current = current.Next;
        //                GetCount();
        //            }
        //        }
        //    }
        //}

        //Option 4 - recursion 2
        //public int Count
        //{
        //    get
        //    {
        //        return GetCount(first);
        //    }
        //}

        //int GetCount(LinkedListItem<T> item)
        //{
        //    if (item == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return 1 + GetCount(item.Next);
        //    }
        //}

        // Adds an element at the beginning of the collection
        public void AddFirst(T element)
        {
            var newItem = new LinkedListItem<T>(element);

            if (first == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                first.Previous = newItem;
                newItem.Next = first;
                first = newItem;
            }

            Count++;
        }

        // Adds an element at the end of the collection
        public void AddLast(T element)
        {
            var newItem = new LinkedListItem<T>(element);

            if (last == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                last.Next = newItem;
                newItem.Previous = last;
                last = newItem;
            }

            Count++;
        }

        // Removes the element at the beginning of the collection
        public T RemoveFirst()
        {
            if (first == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T value = first.Value;

            Count--;

            if (first == last)
            {
                first = null;
                last = null;  

                return value;
            }

            first = first.Next;
            first.Previous = null;

            return value;
        }

        // Removes the element at the end of the collection
        public T RemoveLast()
        {
            if (last == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T value = last.Value;

            Count--;

            if (first == last)
            {
                first = null;
                last = null;

                return value;
            }

            last = last.Previous;
            last.Next = null;

            return value;
        }

        // Goes through the collection and executes a given action
        public void ForEach(Action<T> action)
        {
            var currentItem = first;

            while (currentItem != null)
            {
                action(currentItem.Value);
                currentItem = currentItem.Next;
            }
        }

        // Returns the collection as an array
        public T[] ToArray()
        {
            T[] array = new T[Count];

            var currentItem = first;
            int index = 0;

            while (currentItem != null)
            {
                array[index++] = currentItem.Value;
                currentItem = currentItem.Next;
            }

            return array;
        }
    }
}