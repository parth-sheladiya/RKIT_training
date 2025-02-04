using System;

namespace BaseLibraryFeatures
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Creating an instance of MyList with integer elements
            MyList<int> list = new MyList<int>();

            // Adding elements to the list
            list.AddToList(1);
            list.AddToList(2);
            list.AddToList(3);
            list.AddToList(4);

            // get first item
            Console.WriteLine("First Item: " + list.GetFirstItem());
            // Removing an element from the list
            list.RemoveToList(1);

            // Displaying the elements in the list using a foreach loop
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}