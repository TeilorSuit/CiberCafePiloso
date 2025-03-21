using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class OrderDao : ConnectionSql
    {
        public DataTable getSalesOrder(DateTime fromDate, DateTime toDate)
        {
            using (var connection = getConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    // Ajusta la consulta a la nueva estructura de Transactions
                    command.CommandText = @"
                        SELECT 
                            t.TransID, 
                            t.TransDateTime,
                            t.TransClientID,
                            t.TransServicesID,
                            t.TransDescrip,
                            t.TransSubTotal,    -- Reemplaza TransPaidMoney
                            t.TransDiscount,
                            t.TransQuantity,
                            t.TransUsername,
                            t.TransTotal,       -- Si deseas usar el total final
                            s.ServiceName,
                            s.ServicePrice,
                            c.ClientName
                        FROM Transactions t
                        INNER JOIN Clients c ON t.TransClientID = c.ClientID
                        INNER JOIN Services_Products s ON t.TransServicesID = s.ServiceID
                        WHERE t.TransDateTime BETWEEN @fromDate AND @toDate
                    ";

                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.CommandType = CommandType.Text;

                    var table = new DataTable();
                    using (var reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                    return table;
                }
            }
        }
    }
}
