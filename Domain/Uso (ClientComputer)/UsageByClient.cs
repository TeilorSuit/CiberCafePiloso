using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsageByClient
    {
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public int TotalSessions { get; set; }
        public int TotalTimeUsed { get; set; }  // en minutos
    }
}
