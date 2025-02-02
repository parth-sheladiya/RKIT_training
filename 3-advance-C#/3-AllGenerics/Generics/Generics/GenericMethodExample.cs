using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericMethodExample
    {
        /// <summary>
        /// method is used to pass any type of data types
        /// </summary>
        /// <typeparam name="T">it is generic type parameter to avoid type casting</typeparam>
        /// <param name="item">it is paramter for types</param>
        public static void Print<T>(T item)
        {
            Console.WriteLine(item);
        }

     
    }
}
