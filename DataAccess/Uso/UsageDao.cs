using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain;

namespace DataAccess
{
    public class UsageDao : ConnectionSql
    {
        // --------------------------------------------------------------------------------
        // MÉTODO 1: LISTADO DE SESIONES
        // --------------------------------------------------------------------------------
        public List<ComputerUsageListing> GetUsageSessions(DateTime fromDate, DateTime toDate)
        {
            var list = new List<ComputerUsageListing>();
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    // CAMBIO REALIZADO: Adaptación a tu Base de Datos real
                    // 1. CC_StartTime se disfraza de 'CC_DateTime'
                    // 2. Calculamos 'CC_TimeUsed' restando EndTime - StartTime
                    // 3. Convertimos CC_PcID a texto para llenar el hueco de 'CC_PcIP'
                    command.CommandText = @"
                        SELECT 
                            cc.CC_ID,
                            CAST(cc.CC_PcID AS varchar(20)) AS CC_PcIP, 
                            cc.CC_ClientID,
                            cc.CC_StartTime AS CC_DateTime, 
                            ISNULL(DATEDIFF(MINUTE, cc.CC_StartTime, cc.CC_EndTime), 0) AS CC_TimeUsed,
                            c.ClientName,
                            comp.PcNumber
                        FROM ClientComputer cc
                        LEFT JOIN Clients c ON cc.CC_ClientID = c.ClientID
                        -- Nota: El Join con Computers es delicado porque no tienes IP en la tabla PC. 
                        -- Intentamos unir por lo que haya, pero usamos LEFT JOIN para que no falle si no coincide.
                        LEFT JOIN Computers comp ON CAST(cc.CC_PcID AS varchar(20)) = comp.PcIp 
                        WHERE cc.CC_StartTime >= @fromDate 
                          AND (cc.CC_EndTime IS NULL OR cc.CC_EndTime <= @toDate)";

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
                                CC_TimeUsed = reader["CC_TimeUsed"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CC_TimeUsed"]),
                                ClientName = reader["ClientName"] == DBNull.Value ? "Desconocido" : reader["ClientName"].ToString(),
                                PcNumber = reader["PcNumber"] == DBNull.Value ? "PC-" + reader["CC_PcIP"].ToString() : reader["PcNumber"].ToString()
                            };
                            list.Add(usage);
                        }
                    }
                }
            }
            return list;
        }

        // --------------------------------------------------------------------------------
        // MÉTODO 2: USO POR HORA (GRÁFICO)
        // --------------------------------------------------------------------------------
        public List<UsageByHour> GetUsageByHour(DateTime fromDate, DateTime toDate)
        {
            var list = new List<UsageByHour>();
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    // CAMBIO REALIZADO: Usamos CC_StartTime y calculamos la suma de minutos al vuelo
                    command.CommandText = @"
                        SELECT DATEPART(HOUR, CC_StartTime) AS UsageHour,
                               SUM(DATEDIFF(MINUTE, CC_StartTime, ISNULL(CC_EndTime, GETDATE()))) AS TotalTimeUsed
                        FROM ClientComputer
                        WHERE CC_StartTime >= @fromDate 
                          AND CC_StartTime <= @toDate
                        GROUP BY DATEPART(HOUR, CC_StartTime)
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
                                Hour = reader["UsageHour"] == DBNull.Value ? 0 : Convert.ToInt32(reader["UsageHour"]),
                                TotalTimeUsed = reader["TotalTimeUsed"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalTimeUsed"])
                            };
                            list.Add(u);
                        }
                    }
                }
            }
            return list;
        }

        // --------------------------------------------------------------------------------
        // MÉTODO 3: CLIENTES FRECUENTES
        // --------------------------------------------------------------------------------
        public List<UsageByClient> GetFrequentClients(DateTime fromDate, DateTime toDate)
        {
            var list = new List<UsageByClient>();
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    // CAMBIO REALIZADO: Ajuste de nombres de columnas y cálculo de SUMA
                    command.CommandText = @"
                        SELECT 
                            cc.CC_ClientID,
                            MAX(c.ClientName) as ClientName, -- Usamos MAX para evitar problemas en el GROUP BY
                            COUNT(*) AS TotalSessions,
                            SUM(DATEDIFF(MINUTE, cc.CC_StartTime, ISNULL(cc.CC_EndTime, GETDATE()))) AS TotalTimeUsed
                        FROM ClientComputer cc
                        LEFT JOIN Clients c ON cc.CC_ClientID = c.ClientID
                        WHERE cc.CC_StartTime >= @fromDate 
                          AND cc.CC_StartTime <= @toDate
                        GROUP BY cc.CC_ClientID
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
                                ClientName = reader["ClientName"] == DBNull.Value ? "Sin Nombre" : reader["ClientName"].ToString(),
                                TotalSessions = Convert.ToInt32(reader["TotalSessions"]),
                                TotalTimeUsed = reader["TotalTimeUsed"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalTimeUsed"])
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