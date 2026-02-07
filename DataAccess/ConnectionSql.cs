using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnectionSql
    {
        protected SqlConnection getConnection()
        {
            return new SqlConnection(
                "Server=localhost\\SQLEXPRESS;" +
                "Database=CiberCafeDB;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;"
            );
        }
    }
}