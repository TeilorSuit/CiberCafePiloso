using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain;

namespace DataAccess
{
    public class ClientDao : ConnectionSql
    {
        public List<ClientListing> GetAllClients()
        {
            var lista = new List<ClientListing>();

            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        SELECT ClientID, ClientMemStatus, ClientName, ClientBirthDate, ClientPhone, ClientAddress 
                        FROM Clients";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var client = new ClientListing
                            {
                                ClientID = reader["ClientID"].ToString(),
                                ClientMemStatus = reader["ClientMemStatus"] != DBNull.Value && Convert.ToBoolean(reader["ClientMemStatus"]),
                                ClientName = reader["ClientName"].ToString(),
                                ClientBirthDate = Convert.ToDateTime(reader["ClientBirthDate"]),
                                ClientPhone = reader.IsDBNull(reader.GetOrdinal("ClientPhone")) ? string.Empty : reader["ClientPhone"].ToString(),
                                ClientAddress = reader.IsDBNull(reader.GetOrdinal("ClientAddress")) ? string.Empty : reader["ClientAddress"].ToString()
                            };
                            lista.Add(client);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
