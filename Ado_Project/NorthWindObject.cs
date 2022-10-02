using Ado_Library.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Project
{
    internal class NorthWindObject
    {
        public static void NorthWind()
        {
            Console.WriteLine("====== NorthWind ======");
            Console.WriteLine("1. Employee Sales Report \n2. product Wise Monthaly Report \n3. Weekly Sales Report");
            string userInput = Console.ReadLine();

            if(userInput == "1")
            {
                EmployeeSalesReport.EmployeeSalesReports();
            }
            else if(userInput == "2")
            {
                ProductWiseMonthalyReport.MonthlyReport();
            }
            else if(userInput == "3")
            {

            }
            else
            {
                Console.WriteLine("Invalid Input.....!");
                Console.WriteLine("Press enter to try again......");
                Console.ReadLine();
                Console.Clear();
                NorthWind();
            }
        }

        
    }
}
