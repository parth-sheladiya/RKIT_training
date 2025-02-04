using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    /// <summary>
    /// This class describe the use of LINQ Join Operator.
    /// </summary>
    public class JoinOperatorClass
    {
        /// <summary>
        /// This method demonstrates the use of LINQ's join operator to join Employee and Department lists.
        /// two list employee and departmenet
        /// </summary>
        public static void RunJoinOperatorClass()
        {
            // Creating an instance of JoinOperator to access employee and department data
            JoinOperator joinOperator = new JoinOperator();

            // LINQ Join query to join Employee and Department data based on DeptId and DepId
            var result = from d in joinOperator.dept
                         join e in joinOperator.emp
                         on d.DepId equals e.DeptId
                         select new
                         {
                             EmployeeName = e.Name,          // Selecting Employee Name
                             DepartmentName = d.DepName     // Selecting Department Name
                         };

            // Iterate over the result of the join and print the employee name and department name
            foreach (var item in result)
            {
                // Output the joined data (Employee Name and Department Name)
                Console.WriteLine(item.EmployeeName + " " + item.DepartmentName);
            }
        }

        /// <summary>
        /// This class contains the data sources for Employees and Departments.
        /// </summary>
        public class JoinOperator
        {
            // Data source for Employees
            public List<Employee> emp = new List<Employee>()
            {
                new Employee { EmpId=1, Name = "parth sheladiya", DeptId=1 },
                new Employee { EmpId=2, Name = "harit rabadiya", DeptId=1 },
                new Employee { EmpId=3, Name = "jeel gor", DeptId=2 },
                new Employee { EmpId=4, Name = "arpit patel", DeptId=2 },
                new Employee { EmpId=5, Name = "sahil radadiya", DeptId=3 }  // Employee without department (DeptId is 3)
            };

            // Data source for Departments
            public List<Department> dept = new List<Department>()
            {
                new Department { DepId=1, DepName="Software" },
                new Department { DepId=2, DepName="Finance" },
                new Department { DepId=3, DepName="Health" }
            };
        }

        /// <summary>
        /// This class defines the Employee structure with EmpId, Name, and DeptId.
        /// </summary>
        public class Employee
        {
            public int EmpId { get; set; }     // Employee ID
            public string Name { get; set; }    // Employee Name
            public int DeptId { get; set; }    // Department ID (Foreign Key)
        }

        /// <summary>
        /// This class defines the Department structure with DepId and DepName.
        /// </summary>
        public class Department
        {
            public int DepId { get; set; }     // Department ID
            public string DepName { get; set; } // Department Name
        }
    }
}
