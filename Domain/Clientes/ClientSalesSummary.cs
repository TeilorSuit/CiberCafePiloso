using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClientSalesSummary
    {
        public string customer { get; set; }
        public int countSales { get; set; }
        public double totalSpent { get; set; }
    }
}