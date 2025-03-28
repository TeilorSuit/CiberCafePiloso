using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClientListing
    {
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public DateTime ClientBirthDate { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public bool ClientMemStatus { get; set; }  // Indica si tiene membresía activa
    }
}