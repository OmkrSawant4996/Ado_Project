using Ado_Library.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Library.Operations
{
    public class ProductWiseMonthalyReportOperation
    {
        private string _connectionString;
        public ProductWiseMonthalyReportOperation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<ProductWiseMonthalyReport> GetProductWiseMonthalyReport(string productName, int month, int year)
        {
            List<ProductWiseMonthalyReport> productWiseMonthalyReports = new List<ProductWiseMonthalyReport>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"EXECUTE dbo.[ProductReport] '{productName}', '{month}', {year}", connection);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductWiseMonthalyReport productWiseMonthalyReport = new ProductWiseMonthalyReport();
                    productWiseMonthalyReport.ProductName = reader.GetString(0);
                    productWiseMonthalyReport.Month = reader.GetString(1);
                    productWiseMonthalyReport.TotalOrderPrice = reader.GetDouble(2);

                    productWiseMonthalyReports.Add(productWiseMonthalyReport);
                }

                connection.Close();

            }

            return productWiseMonthalyReports;
        }
    }
}
