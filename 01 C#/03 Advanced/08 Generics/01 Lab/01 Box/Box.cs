namespace BoxOfT
{
    public class Box<T>
    {
        Stack<T> items = new Stack<T>();

        public int Count => items.Count;

        public void Add(T element)
        {
            items.Push(element);
        }

        public T Remove()
        {
            return items.Pop();
        }
    }
}