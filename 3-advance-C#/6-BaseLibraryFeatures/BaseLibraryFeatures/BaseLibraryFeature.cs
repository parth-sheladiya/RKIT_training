using System;
using System.Collections.Generic;

namespace BaseLibraryFeatures
{
    /// <summary>
    /// Represents a custom list that extends the functionality of the generic List class
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public class MyList<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance of the MyList class
        /// </summary>
        public MyList() : base()
        {
            Console.WriteLine("MyList object created!");
        }

        /// <summary>
        /// Adds an item to the list
        /// </summary>
        /// <param name="item">The item to be added</param>
        public void AddToList(T item)
        {
            base.Add(item);
        }

        /// <summary>
        /// Counts total items manually without using built-in Count property
        /// </summary>
        public int CountItemsManual()
        {
            int count = 0;

            foreach (T item in this) 
            {
                count++; 
            }
            return count;
        }

        /// <summary>
        /// Removes an item from the list
        /// </summary>
        /// <param name="item">The item to be removed</param>
        public void RemoveToList(T item)
        {
            base.Remove(item);
        }

        /// <summary>
        /// Returns the first item in the list, or default if list is empty
        /// </summary>
        /// <returns>The first item in the list</returns>
        public T GetFirstItem()
        {
            if (this.CountItemsManual() > 0)
                return this[0]; 
            else
                return default(T);  
        }

    }
}