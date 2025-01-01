using System;
using System.Data;

namespace Basic_C_Sharp
{
    public class DataTableDemo
    {
        public static void RunDataTableDemo()
        {
            // Step 1: Create a DataTable for Employees
            DataTable employeesTable = new DataTable("Employees");

            // Step 2: Define columns
            DataColumn idColumn = new DataColumn("EmployeeID", typeof(int))
            {
                AutoIncrement = true,
                AutoIncrementSeed = 1001, // Start ID from 1001
                AutoIncrementStep = 1
            };
            employeesTable.Columns.Add(idColumn);
            employeesTable.Columns.Add(new DataColumn("Name", typeof(string)) { MaxLength = 50 });
            employeesTable.Columns.Add(new DataColumn("Position", typeof(string)));
            employeesTable.Columns.Add(new DataColumn("Salary", typeof(decimal)));

            // Step 3: Add sample employee rows
            employeesTable.Rows.Add(null, "John Doe", "Manager", 75000.50m);
            employeesTable.Rows.Add(null, "Jane Smith", "Developer", 60000.00m);
            employeesTable.Rows.Add(null, "Samuel Brown", "Tester", 45000.25m);

            // Step 4: Display the initial Employee DataTable
            Console.WriteLine("Initial Employee Data:");
            DisplayDataTable(employeesTable);



            // Step 5: Add a new employee dynamically
            Console.WriteLine("\nAdding a new employee...");
            DataRow newEmployee = employeesTable.NewRow();
            newEmployee["Name"] = "Emily Davis";
            newEmployee["Position"] = "HR";
            newEmployee["Salary"] = 50000.00m;
            employeesTable.Rows.Add(newEmployee);

            employeesTable.Rows[0]["Name"] = "Updated John"; // Update a row
            employeesTable.Rows[2].Delete();                 // Delete a row

            // Step 6: Filter employees with salary > 50000
            Console.WriteLine("\nEmployees with Salary > 50000:");
            DataRow[] highSalaryEmployees = employeesTable.Select("Salary > 50000");
            foreach (DataRow row in highSalaryEmployees)
            {
                Console.WriteLine($"{row["EmployeeID"]}\t{row["Name"]}\t{row["Position"]}\t{row["Salary"]}");
            }

            // Step 7: Clone and Copy DataTable
            Console.WriteLine("\nCloning the Employees table (Structure only):");
            DataTable clonedTable = employeesTable.Clone();
            DisplayDataTable(clonedTable);

            Console.WriteLine("\nCopying the Employees table (Structure + Data):");
            DataTable copiedTable = employeesTable.Copy();
            DisplayDataTable(copiedTable);
        }

        
        private static void DisplayDataTable(DataTable table)
        {
            Console.WriteLine("Columns:");
            foreach (DataColumn column in table.Columns)
            {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine("\nRows:");
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
