namespace ConsoleApp
{
    public class Box<T>
        where T : IComparable<T>
    {
        public List<T> list = new List<T>();

        private T value;

        public void Add(T element)
        {
            list.Add(element);
        }

        public void AddValue(T value)
        {
            this.value = value;
        }

        public int CountElements()
        {
            return list.Count(x => x.CompareTo(value) > 0);
        }
    }
}