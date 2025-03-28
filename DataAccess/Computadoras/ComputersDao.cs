using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain;

namespace DataAccess
{
    public class ComputersDao : ConnectionSql
    {
        public List<ComputerListing> GetAllComputers()
        {
            var lista = new List<ComputerListing>();
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        SELECT PcIp, PcNumber, PcStatus, PcInfo
                        FROM Computers";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var comp = new ComputerListing
                            {
                                PcIp = reader["PcIp"].ToString(),
                                PcNumber = reader["PcNumber"].ToString(),
                                PcStatus = reader["PcStatus"].ToString(),
                                PcInfo = reader["PcInfo"].ToString()
                            };
                            lista.Add(comp);
                        }
                    }
                }
            }
            return lista;
        }

        // Método para obtener el resumen de estado (para el gráfico)
        public List<ComputerStatusSummary> GetComputersStatusSummary()
        {
            var summary = new List<ComputerStatusSummary>();
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        SELECT PcStatus, COUNT(*) AS CountComputers
                        FROM Computers
                        GROUP BY PcStatus
                        ORDER BY PcStatus";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cs = new ComputerStatusSummary
                            {
                                PcStatus = reader["PcStatus"].ToString(),
                                CountComputers = Convert.ToInt32(reader["CountComputers"])
                            };
                            summary.Add(cs);
                        }
                    }
                }
            }
            return summary;
        }
    }
}
