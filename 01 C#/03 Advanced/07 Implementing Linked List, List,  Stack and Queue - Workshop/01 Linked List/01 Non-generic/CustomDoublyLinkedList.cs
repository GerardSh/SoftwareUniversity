namespace ImplementDoublyLinkedList
{
    public class CustomDoublyLinkedList
    {
        private LinkedListItem first;

        private LinkedListItem last;

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

        //int GetCount(LinkedListItem item)
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
        public void AddFirst(int element)
        {
            var newItem = new LinkedListItem(element);

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
        public void AddLast(int element)
        {
            var newItem = new LinkedListItem(element);

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
        public int RemoveFirst()
        {
            if (first == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int value = first.Value;

            if (first == last)
            {
                first = null;
                last = null;

                return value;
            }

            first = first.Next;
            first.Previous = null;

            Count--;

            return value;
        }

        // Removes the element at the end of the collection
        public int RemoveLast()
        {
            if (last == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int value = last.Value;

            if (first == last)
            {
                first = null;
                last = null;

                return value;
            }

            last = last.Previous;
            last.Next = null;

            Count--;

            return value;
        }

        // Goes through the collection and executes a given action
        public void ForEach(Action<int> action)
        {
            var currentItem = first;

            while (currentItem != null)
            {
                action(currentItem.Value);
                currentItem = currentItem.Next;
            }
        }

        // Returns the collection as an array
        public int[] ToArray()
        {
            int[] array = new int[Count];

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