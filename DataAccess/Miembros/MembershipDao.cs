using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Domain;

namespace DataAccess
{
    public class MembershipDao : ConnectionSql
    {
        // Método para obtener todas las membresías
        public List<MembershipListing> GetAllMemberships()
        {
            var lista = new List<MembershipListing>();

            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        SELECT 
                            cm.CMID,
                            c.ClientID,
                            c.ClientName,
                            m.MembershipID,
                            m.MembershipName,
                            cm.CMStartDate,
                            cm.CMEndDate,
                            m.Discount
                        FROM ClientMembership cm
                        JOIN Clients c ON cm.CMClientID = c.ClientID
                        JOIN Membership m ON cm.CMMembershipID = m.MembershipID";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new MembershipListing
                            {
                                CMID = Convert.ToInt32(reader["CMID"]),
                                ClientID = reader["ClientID"].ToString(),
                                ClientName = reader["ClientName"].ToString(),
                                MembershipID = Convert.ToInt32(reader["MembershipID"]),
                                MembershipName = reader["MembershipName"].ToString(),
                                CMStartDate = Convert.ToDateTime(reader["CMStartDate"]),
                                CMEndDate = Convert.ToDateTime(reader["CMEndDate"]),
                                Discount = Convert.ToDouble(reader["Discount"])
                            };
                            lista.Add(item);
                        }
                    }
                }
            }
            return lista;
        }

        // Método para filtrar en memoria las membresías dentro del rango
        public List<MembershipListing> GetMembershipsInRangeInMemory(DateTime fromDate, DateTime toDate)
        {
            var memList = GetAllMemberships();
            var membershipsInRange = memList
                .Where(m => m.CMStartDate >= fromDate && m.CMEndDate <= toDate)
                .ToList();
            return membershipsInRange;
        }

        // Método para obtener membresías cuyo inicio y fin estén dentro del rango directamente en la consulta
        public List<MembershipListing> GetMembershipsInRange(DateTime fromDate, DateTime toDate)
        {
            var lista = new List<MembershipListing>();

            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        SELECT 
                            cm.CMID,
                            c.ClientID,
                            c.ClientName,
                            m.MembershipID,
                            m.MembershipName,
                            cm.CMStartDate,
                            cm.CMEndDate,
                            m.Discount
                        FROM ClientMembership cm
                        JOIN Clients c ON cm.CMClientID = c.ClientID
                        JOIN Membership m ON cm.CMMembershipID = m.MembershipID
                        WHERE (cm.CMStartDate >= @fromDate AND cm.CMStartDate <= @toDate)
                          AND (cm.CMEndDate >= @fromDate AND cm.CMEndDate <= @toDate)";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new MembershipListing
                            {
                                CMID = Convert.ToInt32(reader["CMID"]),
                                ClientID = reader["ClientID"].ToString(),
                                ClientName = reader["ClientName"].ToString(),
                                MembershipID = Convert.ToInt32(reader["MembershipID"]),
                                MembershipName = reader["MembershipName"].ToString(),
                                CMStartDate = Convert.ToDateTime(reader["CMStartDate"]),
                                CMEndDate = Convert.ToDateTime(reader["CMEndDate"]),
                                Discount = Convert.ToDouble(reader["Discount"])
                            };
                            lista.Add(item);
                        }
                    }
                }
            }
            return lista;
        }

        // Método para obtener un resumen de membresías agrupado por tipo
        public List<MembershipSummaryByType> GetMembershipSummaryByType()
        {
            var lista = GetAllMemberships();
            var summary = lista
                .GroupBy(m => m.MembershipName)
                .Select(g => new MembershipSummaryByType
                {
                    MembershipName = g.Key,
                    CountMemberships = g.Count(),
                    AverageDiscount = g.Average(m => m.Discount)
                })
                .ToList();
            return summary;
        }
    }
}
