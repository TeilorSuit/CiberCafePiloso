using System;

namespace Domain
{
    public class ComputerUsageListing
    {
        public int CC_ID { get; set; }
        public string CC_PcIP { get; set; }
        public string CC_ClientID { get; set; }
        public DateTime CC_DateTime { get; set; }
        public int CC_TimeUsed { get; set; }
        // Opcional (si haces JOIN):
        public string ClientName { get; set; }
        public string PcNumber { get; set; }
    }
}
