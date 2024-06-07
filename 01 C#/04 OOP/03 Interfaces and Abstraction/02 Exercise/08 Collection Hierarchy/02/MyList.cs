namespace CollectionHierarchy
{
    public class MyList : IAddable, IRemovable
    {
        List<string> list;

        public MyList()
        {
            list = new List<string>();
        }

        public int Used => list.Count;

        public int Add(string element)
        {
            list.Insert(0, element);

            return 0;
        }

        public string Remove()
        {
            string temp = list[0];

            list.RemoveAt(0);

            return temp;
        }
    }
}
