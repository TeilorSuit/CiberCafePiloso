using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain;

namespace DataAccess
{
    public class TransactionsDao : ConnectionSql
    {
        public List<SalesListing> GetSalesListing(DateTime fromDate, DateTime toDate)
        {
            var list = new List<SalesListing>();
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        SELECT 
                           t.TransID,
                           t.IdCaja,
                           t.TransType,
                           t.TransDateTime,
                           t.TransSUBTOTAL,
                           t.TransDiscount,
                           t.TransQuantity,
                           t.TransUserID,
                           t.TransServicePrice,
                           c.ClientName,
                           s.ServiceName
                        FROM Transactions t
                        JOIN Clients c ON t.TransClientID = c.ClientID
                        JOIN Services_Products s ON t.TransServiceID = s.ServiceID
                        WHERE t.TransDateTime BETWEEN @fromDate AND @toDate
                    ";
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var sale = new SalesListing()
                            {
                                orderId = Convert.ToInt32(reader["TransID"]),
                                // Asegúrate de que SalesListing tenga estas propiedades
                                IdCaja = Convert.ToInt32(reader["IdCaja"]),
                                TransType = reader["TransType"].ToString(),
                                orderDate = Convert.ToDateTime(reader["TransDateTime"]),
                                totalAmount = Convert.ToDouble(reader["TransSUBTOTAL"]),
                                discount = Convert.ToDouble(reader["TransDiscount"]),
                                quantity = Convert.ToInt32(reader["TransQuantity"]),
                                // Aunque TransUserID es numérico, lo convertimos a string si así lo requiere SalesListing
                                username = reader["TransUserID"].ToString(),
                                servicePrice = Convert.ToDouble(reader["TransServicePrice"]),
                                customer = reader["ClientName"].ToString(),
                                products = reader["ServiceName"].ToString()
                            };
                            list.Add(sale);
                        }
                    }
                }
            }
            return list;
        }
    }
}
