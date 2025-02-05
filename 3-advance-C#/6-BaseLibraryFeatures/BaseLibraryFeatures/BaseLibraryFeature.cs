namespace BaseLibraryFeatures
{
    /// <summary>
    /// this is customlist it is in  include datatpe only  int, bool , string 
    /// </summary>
    /// <typeparam name="T">operator </typeparam>
    public class MyCustomList<T> : List<T>
    {
        private List<object> _items; 

        /// <summary>
        /// Initializes a new instance of the MyList class
        /// </summary>
        public MyCustomList() : base()
        {
            Console.WriteLine("MyList object created!");
            _items = new List<object>();
        }

        /// <summary>
        /// add is accept to store data int , str, bool
        /// </summary>
        /// <param name="value">value </param>
        public void Add(object value)
        {
            var typestrcheck = value.GetType() == typeof(string);
            var typeintcheck = value.GetType() == typeof(int);
            var typeboolcheck = value.GetType() == typeof(bool);
            

            // Allow strings, ints, bools, DateTime
            if (typestrcheck || typeintcheck || typeboolcheck )
            {
                _items.Add(value);
                Console.WriteLine($"{value} added to the list.");
            }
            else
            {
                throw new ArgumentException("Only string, int, bool types are allowed.");
            }
        }

        /// <summary>
        /// Display all items in the list
        /// </summary>
        public void Display()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }


    }
}
