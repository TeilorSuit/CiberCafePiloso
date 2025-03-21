using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ComputerUsageDao : ConnectionSql
    {
        public DataTable getComputerUsage(DateTime fromDate, DateTime toDate)
        {
            using (var connection = getConnection())
            {
                connection.Open();
                // Depurar el rango
                Console.WriteLine("fromDate: " + fromDate.ToString("yyyyMMdd HH:mm:ss"));
                Console.WriteLine("toDate: " + toDate.ToString("yyyyMMdd HH:mm:ss"));

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    // Ajustar la consulta a la tabla ClientComputer con CC_DateTime y CC_TimeUsed
                    command.CommandText = @"
                        SELECT 
                            cc.CC_ID,
                            cc.CC_PcIP,
                            cc.CC_ClientID,
                            c.ClientName,
                            cc.CC_DateTime,
                            cc.CC_TimeUsed
                        FROM ClientComputer cc
                        INNER JOIN Clients c ON cc.CC_ClientID = c.ClientID
                        WHERE cc.CC_DateTime BETWEEN @fromDate AND @toDate
                    ";

                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.CommandType = CommandType.Text;

                    var table = new DataTable();
                    using (var reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                    Console.WriteLine("DAO - getComputerUsage: Filas devueltas = " + table.Rows.Count);
                    return table;
                }
            }
        }
    }
}
