using System.Xml.Linq;

namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IUseable
    {
        public IReadOnlyCollection<string> Used => list;

        public override string Remove()
        {
            string temp = list[0];

            list.RemoveAt(0);

            return temp;
        }
    }
}
