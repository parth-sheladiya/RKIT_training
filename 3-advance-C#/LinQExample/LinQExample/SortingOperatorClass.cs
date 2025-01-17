﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    public class SortingOperatorClass
    {
        /// <summary>
        /// main method 
        /// 
        /// </summary>
        public static void RunSortingOperatorClass()
        {
            ClassSortingOperator clsSortingOprtr = new ClassSortingOperator();

            // first of use order by 
            var orderStudent = clsSortingOprtr.student.OrderBy(s => s.age);
            Console.WriteLine("orderstudent is ");

            foreach (var student in orderStudent)
            {
                Console.WriteLine($"Name: {student.name}, Age: {student.age}");
            }

            // orderby descing 
            var orderdesendingStudent = clsSortingOprtr.student.OrderByDescending(s => s.age);
            Console.WriteLine("order by descing is ");

            foreach (var student in orderdesendingStudent)
            {
                Console.WriteLine($"Name: {student.name}, Age: {student.age}");
            }


            // thenby 
            var thenStudent = clsSortingOprtr.student.OrderBy(p => p.age).ThenBy(p => p.name);
            Console.WriteLine("then by multiple condition is ");

            foreach (var student in orderdesendingStudent)
            {
                Console.WriteLine($"Name: {student.name}, Age: {student.age}");
            }

            // thenby 
            var thendescendingStudent = clsSortingOprtr.student.OrderBy(p => p.age).ThenByDescending(p => p.name);
            Console.WriteLine("then by descending condition is ");

            foreach (var student in orderdesendingStudent)
            {
                Console.WriteLine($"Name: {student.name}, Age: {student.age}");
            }



        }
        public class ClassSortingOperator
        {
            // data source for all operator 
            public List<(string name, int age)> student = new List<(string, int)>
            {
                ("Parth", 22),
                ("ankur", 39),
                ("Ravi", 21),
                ("keyur", 11),
                ("Maya", 89)
            };
        }
    }
}
