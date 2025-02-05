namespace BaseLibraryFeatures
{
    class Program
    {
        public static void Main(string[] args)
        {// Creating an object of MyList and adding items
            MyCustomList<object> cusList = new MyCustomList<object>();

            // Adding allowed types
            cusList.Add("Hello");
            cusList.Add(123);
            cusList.Add(true);
            

            // Displaying the list
            Console.WriteLine("Items in the list:");
            cusList.Display();

            // cheking purpose datas
            Console.WriteLine("before float value add");
            cusList.Add(45.67);
            Console.WriteLine("after float value add");

        }
    }
}