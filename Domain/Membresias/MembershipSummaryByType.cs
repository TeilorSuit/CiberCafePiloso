using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MembershipSummaryByType
    {
        public string MembershipName { get; set; }
        public int CountMemberships { get; set; }
        public double AverageDiscount { get; set; }
    }
}