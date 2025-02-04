using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQExample
{
    /// <summary>
    /// This class demonstrates the use of LINQ Grouping Operators.
    /// Grouping operators allow us to group data based on a specific key (e.g., city).
    /// </summary>
    public class GroupingOperatorClass
    {
        /// <summary>
        /// This method demonstrates how to group students based on their city using LINQ's GroupBy() method.
        /// 1. Groups students based on the city they belong to.
        /// 2. Iterates over each group and displays the city name.
        /// 3. Iterates over students in each group and displays their names.
        /// </summary>
        public static void RunGroupingOperatorClass()
        {
            // Creating an instance of GroupingOperator to access student data
            GroupingOperator groupingOperator = new GroupingOperator();

            // 1 Group students by city
            var studentDetails = groupingOperator.res.GroupBy(a => a.city);

            //  Iterate over each group (city-wise grouping)
            foreach (var group in studentDetails)
            {
                //  Display city name 
                Console.WriteLine($"City: {group.Key}");

                //  Iterate over each student in the current group
                foreach (var student in group)
                {
                    //  Display student name
                    Console.WriteLine($"  Name: {student.name}");
                }
            }
        }

        /// <summary>
        /// This class contains the student data source with names and their respective cities.
        /// </summary>
        public class GroupingOperator
        {
            // Data source
            public List<(string name, string city)> res = new List<(string name, string city)>
            {
                ("Parth", "Rajkot"),
                ("Harit", "Ahmedabad"),
                ("Priyansh", "Rajkot"),
                ("Keyur", "baroda"),
                ("Raj", "Surat"),
                ("Yash", "Ahmedabad"),
                ("Maulik", "Morbi"),
                ("Tirth", "Rajkot")
            };
        }
    }
}
