using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccess;
using Domain;


namespace Domain
{
    public class ComputerUsageReport
    {
        public DateTime reportDate { get; private set; }
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }
        public List<ComputerUsageListing> usageListings { get; private set; }
        public List<UsageByHour> usageByHour { get; private set; }
        public List<UsageByClient> usageByClient { get; private set; }
        public double totalUsageTimeMinutes { get; private set; }

        public int createComputerUsageReport(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var usageDao = new ComputerUsageDao();
            var result = usageDao.getComputerUsage(fromDate, toDate);

            usageListings = new List<ComputerUsageListing>();
            totalUsageTimeMinutes = 0;

            foreach (DataRow row in result.Rows)
            {
                var usageRecord = new ComputerUsageListing()
                {
                    usageId = Convert.ToInt32(row["CC_ID"]),
                    pcIp = Convert.ToString(row["CC_PcIP"]),
                    clientId = Convert.ToString(row["CC_ClientID"]),
                    clientName = Convert.ToString(row["ClientName"]),
                    usageDateTime = Convert.ToDateTime(row["CC_DateTime"]),
                    timeUsed = Convert.ToInt32(row["CC_TimeUsed"])
                };
                usageListings.Add(usageRecord);
                totalUsageTimeMinutes += usageRecord.timeUsed;

                usageByHour = usageListings
                .GroupBy(u => u.usageDateTime.Hour)
                .Select(g => new UsageByHour
                {
                    hour = g.Key,
                    totalTimeUsed = g.Sum(u => u.timeUsed)
                })
                .OrderBy(x => x.hour)
                .ToList();

                usageByClient = usageListings
    .GroupBy(u => u.clientName)
    .Select(g => new UsageByClient
    {
        clientName = g.Key,
        countSessions = g.Count(),
        totalTimeUsed = g.Sum(u => u.timeUsed)
    })
    .OrderByDescending(x => x.totalTimeUsed)
    .ToList();

            }

            // Retorna cuántos registros se obtuvieron
            return usageListings.Count;
        }
    }
}
