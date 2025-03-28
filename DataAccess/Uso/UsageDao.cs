using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain;

namespace DataAccess
{
    public class UsageDao : ConnectionSql
    {
        // Retorna la lista de sesiones de uso cuya "sesión completa" (inicio + tiempo usado) se encuentre en el rango [fromDate, toDate].
        public List<ComputerUsageListing> GetUsageSessions(DateTime fromDate, DateTime toDate)
        {
            var list = new List<ComputerUsageListing>();
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    // La consulta filtra aquellas sesiones donde:
                    // - La fecha de inicio (CC_DateTime) es mayor o igual a @fromDate
                    // - La fecha de fin calculada (CC_DateTime + CC_TimeUsed en minutos) es menor o igual a @toDate.
                    command.CommandText = @"
                        SELECT 
                            cc.CC_ID,
                            cc.CC_PcIP,
                            cc.CC_ClientID,
                            cc.CC_DateTime,
                            cc.CC_TimeUsed,
                            c.ClientName,
                            comp.PcNumber
                        FROM ClientComputer cc
                        LEFT JOIN Clients c ON cc.CC_ClientID = c.ClientID
                        LEFT JOIN Computers comp ON cc.CC_PcIP = comp.PcIp
                        WHERE cc.CC_DateTime >= @fromDate 
                          AND DATEADD(MINUTE, cc.CC_TimeUsed, cc.CC_DateTime) <= @toDate";
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usage = new ComputerUsageListing
                            {
                                CC_ID = Convert.ToInt32(reader["CC_ID"]),
                                CC_PcIP = reader["CC_PcIP"].ToString(),
                                CC_ClientID = reader["CC_ClientID"].ToString(),
                                CC_DateTime = Convert.ToDateTime(reader["CC_DateTime"]),
                                CC_TimeUsed = Convert.ToInt32(reader["CC_TimeUsed"]),
                                ClientName = reader["ClientName"] == DBNull.Value ? "" : reader["ClientName"].ToString(),
                                PcNumber = reader["PcNumber"] == DBNull.Value ? "" : reader["PcNumber"].ToString()
                            };
                            list.Add(usage);
                        }
                    }
                }
            }
            return list;
        }

        // Método para agrupar uso por hora (para el gráfico)
        public List<UsageByHour> GetUsageByHour(DateTime fromDate, DateTime toDate)
        {
            var list = new List<UsageByHour>();
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        SELECT DATEPART(HOUR, CC_DateTime) AS UsageHour,
                               SUM(CC_TimeUsed) AS TotalTimeUsed
                        FROM ClientComputer
                        WHERE CC_DateTime >= @fromDate 
                          AND DATEADD(MINUTE, CC_TimeUsed, CC_DateTime) <= @toDate
                        GROUP BY DATEPART(HOUR, CC_DateTime)
                        ORDER BY UsageHour";
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var u = new UsageByHour
                            {
                                Hour = Convert.ToInt32(reader["UsageHour"]),
                                TotalTimeUsed = Convert.ToInt32(reader["TotalTimeUsed"])
                            };
                            list.Add(u);
                        }
                    }
                }
            }
            return list;
        }

        // Método para agrupar uso por cliente (para clientes frecuentes)
        public List<UsageByClient> GetFrequentClients(DateTime fromDate, DateTime toDate)
        {
            var list = new List<UsageByClient>();
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        SELECT 
                            cc.CC_ClientID,
                            c.ClientName,
                            COUNT(*) AS TotalSessions,
                            SUM(cc.CC_TimeUsed) AS TotalTimeUsed
                        FROM ClientComputer cc
                        LEFT JOIN Clients c ON cc.CC_ClientID = c.ClientID
                        WHERE cc.CC_DateTime >= @fromDate 
                          AND DATEADD(MINUTE, cc.CC_TimeUsed, cc.CC_DateTime) <= @toDate
                        GROUP BY cc.CC_ClientID, c.ClientName
                        ORDER BY TotalTimeUsed DESC";
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var u = new UsageByClient
                            {
                                ClientID = reader["CC_ClientID"].ToString(),
                                ClientName = reader["ClientName"].ToString(),
                                TotalSessions = Convert.ToInt32(reader["TotalSessions"]),
                                TotalTimeUsed = Convert.ToInt32(reader["TotalTimeUsed"])
                            };
                            list.Add(u);
                        }
                    }
                }
            }
            return list;
        }
    }
}
