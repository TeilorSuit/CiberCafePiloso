using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Uso__ClientComputer_
{
    public class UsageListing
    {
        public int CC_ID { get; set; }
        public string CC_PcIP { get; set; }
        public string CC_ClientID { get; set; }
        public DateTime CC_DateTime { get; set; }
        public int CC_TimeUsed { get; set; }
        // Opcional: Nombre del cliente, etc., si devuelves con JOIN
    }
}