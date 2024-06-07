using System.Xml.Linq;

namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection
    {
        public int Used => list.Count;

        public override string Remove()
        {
            string temp = list[0];

            list.RemoveAt(0);

            return temp;
        }
    }
}
