namespace CollectionHierarchy
{
    public class AddRemoveCollection : AddCollection, IRemovable
    {
        public virtual string Remove()
        {
            string temp = list[list.Count - 1];

            list.RemoveAt(list.Count - 1);

            return temp;
        }

        public override int Add(string element)
        {
            list.Insert(0, element);

            return 0;
        }
    }
}
