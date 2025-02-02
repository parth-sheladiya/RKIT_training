using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    public class JoinOperatorClass
    {
        public static void RunJoinOperatorClass()
        {
            JoinOperator joinOperator = new JoinOperator();

            var result = from d in joinOperator.dept
                         join e in joinOperator.emp
                         on d.DepId equals e.DeptId
                         select new
                         {
                             EmployeeName = e.Name,
                             DepartmentName = d.DepName
                         };
            foreach (var item in result)
            {
                
                Console.WriteLine(item.EmployeeName  + item.DepartmentName);
            }
        }
        public class JoinOperator
        {
           public List<Employee> emp = new List<Employee>()
                {
                new Employee { EmpId=1,Name = "Akshay Tyagi", DeptId=1 },
                new Employee { EmpId=2,Name = "Vaishali Tyagi", DeptId=1 },
                new Employee { EmpId=3,Name = "Arpita Rai", DeptId=2 },
                new Employee { EmpId=4,Name = "Sateesh Alavala", DeptId =2},
                new Employee { EmpId=5,Name = "Madhav Sai"}
                };

           public  List<Department> dept = new List<Department>()
                    {
                       new Department{DepId=1,DepName="Software"},
                       new Department{DepId=2,DepName="Finance"},
                       new Department{DepId=3,DepName="Health"}
                    };
        }

       public class Employee
        {
            public int EmpId { get; set; }
            public string Name { get; set; }
            public int DeptId { get; set; }
        }

      public  class Department
        {
            public int DepId { get; set; }
            public string DepName { get; set; }
        }
    }
}
