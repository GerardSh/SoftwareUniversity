using System.Security.Cryptography;
using System.Xml.Linq;

namespace CollectionHierarchy
{
    class Program
    {
        public static void Main()
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] elementsToAdd = Console.ReadLine().Split();

            AddElements(elementsToAdd, addCollection);
            AddElements(elementsToAdd, addRemoveCollection);
            AddElements(elementsToAdd, myList);

            int elementsToRemoveCount = int.Parse(Console.ReadLine());

            RemoveElements(elementsToRemoveCount, addRemoveCollection);
            RemoveElements(elementsToRemoveCount, myList);
        }

        static void AddElements(string[] elementsToAdd, IAddable collection)
        {
            foreach (string element in elementsToAdd)
            {
                Console.Write(collection.Add(element) + " ");
            }

            Console.WriteLine();
        }

        static void RemoveElements(int elementsToRemoveCount,  IRemovable collection)
        {
            for (int i = 0; i < elementsToRemoveCount; i++)
            {
                Console.Write(collection.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}