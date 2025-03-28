using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsageByHour
    {
        public int Hour { get; set; }
        public int TotalTimeUsed { get; set; }  // en minutos
    }
}