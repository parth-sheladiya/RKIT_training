using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    /// <summary>
    /// this class is describe various type of element operator.
    /// </summary>
    public class ElementOperatorClass
    {
        /// <summary>
        /// different element operator
        /// </summary>
        public static void RunElementOperatorClass()
        {
            // create object
            ElementOperator elementOperator = new ElementOperator();

            // retrive first element 
            int showFirstElement = elementOperator.numbers.First(n=>n>40);
            Console.WriteLine("retrive first element is " + showFirstElement);

            // retrive first element or default
            // if list is empty then it will return 0 but do not give any error 
            int showFstDefEle = elementOperator.numbers.FirstOrDefault(n=>n>90);
            Console.WriteLine("retrive first element or default is " + showFstDefEle);

            // retrive last element
            // if list is empty then it will give error
            int showLastEle = elementOperator.numbers.Last();
            Console.WriteLine("retrive last element is " + showLastEle);

            // retrive last element or default
            int showLastDefEle = elementOperator.numbers.LastOrDefault();
            Console.WriteLine("retrive last element or default is " + showLastDefEle);

            // retrive element with specific index
            string showElementWithIndex = elementOperator.strings.ElementAt(3);
            Console.WriteLine("retrive element with specific index is " + showElementWithIndex);

            


            // it's mark to comment bcz single is must be a single element otherwise it will give error 
            // retrive single element
          //  int showSingleElement = elementOperator.numbers.Single(n>20);
          //  Console.WriteLine("retrive single element is " + showSingleElement);

            // retrive single element or default 
          // int showSingleElementDef = elementOperator.numbers.SingleOrDefault();
           // Console.WriteLine("retrive single element or default is " + showSingleElementDef);

            // retrive element with default empty
           // string showDefStr = elementOperator.strings.DefaultIfEmpty("sri lanka");
           // Console.WriteLine("retrive element with default empty is " + showDefStr);


        }

        /// <summary>
        /// data source class for element operator
        /// </summary>
        public class ElementOperator
        {

            // first of create source 
           public List<int> numbers = new List<int> { 10, 20, 30 ,40,50,60,70,80,90 };

           public List<string> strings = new List<string> { "US", "UK", "India", "Russia", "China", "Australia", "Argentina" };

        }
    }
}
