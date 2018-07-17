using System.Data;
using System.Data.SqlClient;

namespace CustomerSave.Common
{
    public class DatabaseHelper
    {
        public static IDbConnection GetConnection()
        {
            string connString = @"Data Source=(localdb)\MsSqlLocalDB;Initial Catalog=CustomerSave_Default_v1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);

            return connection;
        }
    }
}
