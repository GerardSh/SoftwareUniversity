namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddable, IRemovable
    {
        List<string> list;

        public AddRemoveCollection()
        {
            list = new List<string>();
        }

        public int Add(string element)
        {
            list.Insert(0, element);

            return 0;
        }

        public string Remove()
        {
            string temp = list[list.Count - 1];

            list.RemoveAt(list.Count - 1);

            return temp;
        }
    }
}
