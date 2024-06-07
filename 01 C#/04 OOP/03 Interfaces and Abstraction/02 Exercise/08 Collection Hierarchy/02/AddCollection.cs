namespace CollectionHierarchy
{
    public class AddCollection : IAddable
    {
        List<string> list;

        public AddCollection()
        {
            list = new List<string>();
        }

        public virtual int Add(string element)
        {
            list.Add(element);

            return list.Count - 1;
        }
    }
}
