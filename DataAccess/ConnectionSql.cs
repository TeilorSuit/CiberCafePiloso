using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnectionSql
    {

        protected SqlConnection getConnection()
        {
            // Aquí va tu cadena de conexión real
            return new SqlConnection("Data Source=teilor\\SQLEXPRESS;Database=CiberCafeDB;User id=teilor;Password=teilor");
        }
    }
}
