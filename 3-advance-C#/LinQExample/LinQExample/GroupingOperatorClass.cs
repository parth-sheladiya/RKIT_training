using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQExample
{
    public class GroupingOperatorClass
    {
        public static void RunGroupingOperatorClass()
        {
            GroupingOperator groupingOperator = new GroupingOperator();

            // create group with city 
            var studentDetails = groupingOperator.res.GroupBy(a => a.city);

            // iterate group data sss
            foreach (var group in studentDetails)
            {
                // string interpolation  for city
                Console.WriteLine($"City: {group.Key}");
                foreach (var student in group)
                {
                    // string interpolation for name
                    Console.WriteLine($"  Name: {student.name}"); 
                }
            }
        }

        public class GroupingOperator
        {
            // first of create data source 
            public List<(string name, string city)> res = new List<(string name, string city)>
            {
                ("parth", "rajkot"),
                ("harit", "ahmedabad"),
                ("priyansh", "rajkot"),
                ("keyur", "morbi"),
                ("raj", "surat"),
                ("yash", "ahmedabad"),
                ("maulik", "morbi"),
                ("tirth", "rajkot")
            };
        }
    }
}
