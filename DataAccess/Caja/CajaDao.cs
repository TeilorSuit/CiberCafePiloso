using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccess;
using Domain;
using Domain.Caja;

public class CajaDao : ConnectionSql
{
    // Método que filtra cajas cuyo período de apertura/cierre cae en [fromDate, toDate]
    public List<CajaListing> getAllCajas(DateTime fromDate, DateTime toDate)
    {
        var lista = new List<CajaListing>();

        using (var connection = getConnection())
        {
            connection.Open();
            using (var command = new SqlCommand())
            {
                command.Connection = connection;

                // Ejemplo de filtro:
                //  - Si la FechaApertura está dentro del rango, la caja se incluye.
                //  - O si la FechaCierre no es nula y también está en el rango.
                // Ajusta la lógica según tu necesidad real.
                command.CommandText = @"
SELECT
    IdCaja,
    FechaApertura,
    MontoApertura,
    FechaCierre,
    MontoCierre,
    IdUsuarioApertura,
    IdUsuarioCierre,
    Estado,
    TotalIngresos,
    TotalGastos,
    Notas
FROM Caja
WHERE
    (FechaApertura >= @fromDate AND FechaApertura <= @toDate)
    OR
    (FechaCierre IS NOT NULL AND FechaCierre >= @fromDate AND FechaCierre <= @toDate)
";

                command.Parameters.AddWithValue("@fromDate", fromDate);
                command.Parameters.AddWithValue("@toDate", toDate);
                command.CommandType = CommandType.Text;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Asegúrate de que el orden de columnas en el SELECT coincida con los índices:
                        // 0 => IdCaja
                        // 1 => FechaApertura
                        // 2 => MontoApertura
                        // 3 => FechaCierre
                        // 4 => MontoCierre
                        // 5 => IdUsuarioApertura
                        // 6 => IdUsuarioCierre
                        // 7 => Estado
                        // 8 => TotalIngresos
                        // 9 => TotalGastos
                        // 10 => Notas
                        var caja = new CajaListing
                        {
                            IdCaja = reader.GetInt32(0),
                            FechaApertura = reader.GetDateTime(1),
                            MontoApertura = reader.GetDecimal(2),
                            FechaCierre = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            MontoCierre = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4),
                            IdUsuarioApertura = reader.GetInt32(5),
                            IdUsuarioCierre = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                            Estado = reader.GetBoolean(7),
                            TotalIngresos = reader.GetDecimal(8),
                            TotalGastos = reader.GetDecimal(9),
                            Notas = reader.IsDBNull(10) ? "" : reader.GetString(10)
                        };
                        lista.Add(caja);
                    }
                }
            }
        }
        return lista;
    }

    // Método para datos del gráfico (por ejemplo, sumar ingresos/gastos agrupados por día de Apertura)
    public List<CajaChart> getCajaGrafico(DateTime fromDate, DateTime toDate)
    {
        var lista = new List<CajaChart>();

        using (var connection = getConnection())
        {
            connection.Open();
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = @"
SELECT
    CONVERT(date, FechaApertura) AS Dia,
    SUM(TotalIngresos) AS SumaIngresos,
    SUM(TotalGastos)   AS SumaGastos
FROM Caja
WHERE
    FechaApertura >= @fromDate
    AND (FechaCierre IS NULL OR FechaCierre <= @toDate)
GROUP BY CONVERT(date, FechaApertura)
ORDER BY Dia
";
                command.Parameters.AddWithValue("@fromDate", fromDate);
                command.Parameters.AddWithValue("@toDate", toDate);
                command.CommandType = CommandType.Text;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cChart = new CajaChart
                        {
                            Dia = reader.GetDateTime(0),
                            SumaIngresos = reader.GetDecimal(1),
                            SumaGastos = reader.GetDecimal(2)
                        };
                        lista.Add(cChart);
                    }
                }
            }
        }
        return lista;
    }
}
