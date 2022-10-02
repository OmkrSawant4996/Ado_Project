using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ado_Library;
using Ado_Library.Operations;

namespace Ado_Project
{
    public  class EmployeeSalesReport
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = NorthWind;Integrated Security=True";

        private static EmployeeSalesReportOperations _employeeSalesReport = new EmployeeSalesReportOperations(connectionString);
        public static void EmployeeSalesReports()
        {
            Console.Write("Enter From Date: ");
            DateTime fromDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter To Date: ");
            DateTime ToDate = DateTime.Parse(Console.ReadLine());
            Console.Clear();

            if (fromDate == null || ToDate == null)
            {
                Console.WriteLine("Empty String.....!");
                Console.WriteLine("Press enter to try again......");
                Console.ReadLine();
                Console.Clear();
                EmployeeSalesReports();
            }
            else
            {
                var emploeeReport = _employeeSalesReport.GetEmployeeSalesReport(fromDate, ToDate);

                foreach (var employee in emploeeReport)
                {
                    Console.WriteLine($"Employee Name: {employee.EmployeeName} \nOrder Id: {employee.OrderId} \nTotal order Count: {employee.OderCount}");
                    Console.WriteLine("===================================");
                }
            }

        }
    }
}
