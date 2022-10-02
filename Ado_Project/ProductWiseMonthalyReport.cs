using Ado_Library.Entities;
using Ado_Library.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Project
{
    public class ProductWiseMonthalyReport
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = NorthWind;Integrated Security=True";

        private static ProductWiseMonthalyReportOperation _ProductWiseMonthalyReportOperation = new ProductWiseMonthalyReportOperation(connectionString);

        public static void MonthlyReport()
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter month: ");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Clear();
            if(productName == null || month == 0 || month == null || year == 0 || year == null)
            {
                Console.WriteLine("Invalid Input....!");
                Console.WriteLine("Press enter to try again......");
                Console.ReadLine();
                Console.Clear();
                MonthlyReport();

            }
            else
            {
                var monthlyReport = _ProductWiseMonthalyReportOperation.GetProductWiseMonthalyReport(productName, month, year);

                Console.WriteLine("Prodect Name \t\t\t Month \t\t\t Total Order Price");

                foreach (var report in monthlyReport)
                {
                    Console.WriteLine($"{report.ProductName} \t\t\t {report.Month} \t\t\t {report.TotalOrderPrice}");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                }
            }

            
        }
    }
}
