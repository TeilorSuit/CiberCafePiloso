namespace Domain
{
    public class ComputerUsageListing
    {
        public int usageId { get; set; }
        public string pcIp { get; set; }
        public string clientId { get; set; }
        public string clientName { get; set; }
        public System.DateTime usageDateTime { get; set; }
        public int timeUsed { get; set; }
    }
}
