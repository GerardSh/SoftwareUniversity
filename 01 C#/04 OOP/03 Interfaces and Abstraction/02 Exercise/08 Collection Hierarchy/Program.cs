using System.Xml.Linq;

namespace CollectionHierarchy
{
    class Program
    {
        public static void Main()
        {

            string[] elements = Console.ReadLine().Split();

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            AddElements(addCollection, elements);
            AddElements(addRemoveCollection, elements);
            AddElements(myList, elements);

            int elementsToRemoveCount = int.Parse(Console.ReadLine());

            RemoveElements(addRemoveCollection, elementsToRemoveCount);
            RemoveElements(myList, elementsToRemoveCount);
        }

        public static void AddElements(AddCollection collection, string[] elements)
        {
            foreach (string element in elements)
            {
                Console.Write(collection.Add(element) + " ");
            }

            Console.WriteLine();
        }

        public static void RemoveElements(AddRemoveCollection collection, int elementsToRemoveCount)
        {

            for (int i = 0; i < elementsToRemoveCount; i++)
            {
                Console.Write(collection.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}