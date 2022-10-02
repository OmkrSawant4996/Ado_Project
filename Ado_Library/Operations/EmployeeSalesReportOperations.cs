using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ado_Library.Entities;

namespace Ado_Library.Operations
{
    public class EmployeeSalesReportOperations
    {
        private string _connectionString;
        public EmployeeSalesReportOperations(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<EmployeeSalesReport> GetEmployeeSalesReport(DateTime fromDate, DateTime toDate)
        {
            List<EmployeeSalesReport> employeeSalesReports = new List<EmployeeSalesReport>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"EXECUTE dbo.[EmployeeSalesReport] '{fromDate}', '{toDate}'", connection);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmployeeSalesReport employeeSalesReport = new EmployeeSalesReport();
                    employeeSalesReport.EmployeeName = reader.GetString(0);
                    employeeSalesReport.OrderId = reader.GetInt32(1);
                    employeeSalesReport.OderCount = reader.GetInt32(2);

                    employeeSalesReports.Add(employeeSalesReport);
                }

                connection.Close();

            }

            return employeeSalesReports;
        }
    }
}
