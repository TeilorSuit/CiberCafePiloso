using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsageByClient
    {
        public string clientName { get; set; }
        public int countSessions { get; set; }
        public int totalTimeUsed { get; set; }
    }
}
