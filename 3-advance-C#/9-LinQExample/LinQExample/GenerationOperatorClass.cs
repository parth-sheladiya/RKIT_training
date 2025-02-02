using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    public class GenerationOperatorClass
    {
        public static void RunGenerationOperatorClass()
        {
            GenerationOperator generationOperator = new GenerationOperator();

            // default value 
            var empRes = generationOperator.numbers.DefaultIfEmpty(50);

            Console.WriteLine("DefaultIfEmpty val is ");
            Console.WriteLine(empRes);

            // repeat value 

            // it only use to repeat
            // if we  can use list so we can create manully repete method using for loop
            var repValueRes = Enumerable.Repeat(5, 5).ToList();
            Console.WriteLine("repeted value is ");
            foreach (var item in repValueRes)
            {
                Console.WriteLine(item);
            }

            // range value 
            var rangeVal = Enumerable.Range(1, 10).ToList();
            Console.WriteLine("range value is ");
            foreach (var item in rangeVal)
            {
                Console.WriteLine(item);
            }
        }


        public class GenerationOperator
        {
            // first create source 
            public List<int> numbers = new List<int>();


        }
    }
}