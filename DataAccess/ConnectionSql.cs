using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnectionSql
    {

        protected SqlConnection getConnection()
        {
            // Aquí va tu cadena de conexión real
            return new SqlConnection("Data Source=DESKTOP-5IV4VE8\\SQLEXPRESS;Database=CiberPiloso;User id=sa;Password=123456");
        }
    }
}
