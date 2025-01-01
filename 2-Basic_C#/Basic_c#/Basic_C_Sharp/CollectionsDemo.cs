using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Basic_C_Sharp
{
   public class CollectionDemo
    {
        public static void RunCollectionDemo()
        {
            #region ArrayList (Non-Generic Collection)
            Console.WriteLine("non-generic collection");
            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add("parth");
            arrayList.Add(2.34);
            arrayList.Add(40);
            arrayList.Remove(20);
            arrayList.Insert(1, 15);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            #endregion


            #region (Generic Collection)

            Console.WriteLine("generaic collection");
            List<int> num = new List<int>();
            num.Add(10);
            num.Add(20);
            num.Add(30);
            num.Add(40);


            foreach (int  i in num)
            {
                Console.WriteLine(i);
            }
            #endregion


            Console.WriteLine(" Dictionary<TKey, TValue> (Key-Value Pair)");
            Dictionary<int, string> students = new Dictionary<int, string>
            {
                {10,"parth" },
                {20 , "brijesh" },
                {30,"meet" }
            };

            foreach (var dKeyVal in students)
            {
                Console.WriteLine($"id: {dKeyVal.Key} , name: {dKeyVal.Value}  ");
            }


            Console.WriteLine("Queue<T> (FIFO)");

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("task1");
            queue.Enqueue("task2");
            queue.Enqueue("task3");

            Console.WriteLine("deque " + queue.Dequeue());
            Console.WriteLine("peek " + queue.Peek());


            Console.WriteLine("Stack<T> (LIFO)");

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());

            Console.WriteLine("HashSet<T> (Unique Elements)");


            HashSet<int> set = new HashSet<int> { 1, 2,2,4,5, 3, 3 };
            foreach (int item in set)
            {
                Console.WriteLine(item); 
            }

            Console.WriteLine("LINQ with Collections");
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

            foreach (int linNum in evenNumbers)
            {
                Console.WriteLine(linNum); 
            }



        }
    }
}
