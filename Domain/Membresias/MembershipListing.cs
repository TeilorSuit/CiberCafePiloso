using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MembershipListing
    {
        public int CMID { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public int MembershipID { get; set; }
        public string MembershipName { get; set; }
        public DateTime CMStartDate { get; set; }
        public DateTime CMEndDate { get; set; }
        public double Discount { get; set; }
    }
}