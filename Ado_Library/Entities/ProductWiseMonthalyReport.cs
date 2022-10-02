using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Library.Entities
{
    public class ProductWiseMonthalyReport
    {
        public string ProductName { get; set; }
        public string Month { get; set; }
        public double TotalOrderPrice { get; set; }
    }
}
