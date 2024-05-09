namespace ImplementDoublyLinkedList
{
   public class LinkedListItem
    {
        public override string ToString()
        {
            return Value.ToString();
        }

        public LinkedListItem(int value)
        {
            Value = value;
        }

        public LinkedListItem? Previous { get; set; }

        public LinkedListItem? Next { get; set; }

        public int Value { get; set; }
    }
}