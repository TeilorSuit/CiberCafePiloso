using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsageByHour
    {
        public int hour { get; set; }           // 0-23
        public int totalTimeUsed { get; set; }  // en minutos
    }
}
