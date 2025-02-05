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
            // this data is duplicate
            list.AddToList(1);
            list.AddToList(3);

            // get first item
            Console.WriteLine("First Item: " + list.GetFirstItem());
            // Removing an element from the list
            list.RemoveToList(1);

            list.RemoveToList(4);
            Console.WriteLine($"After Removing  Total Items: {list.CountItemsManual()}");

            int totalItems = list.CountItemsManual();
            Console.WriteLine($"Total items in list: {totalItems}");

            // Displaying the elements in the list using a foreach loop
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}