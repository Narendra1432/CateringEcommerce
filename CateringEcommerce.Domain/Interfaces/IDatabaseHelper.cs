
using Microsoft.Data.SqlClient;

namespace CateringEcommerce.Domain.Interfaces
{
    public interface IDatabaseHelper
    {
        int ExecuteNonQuery(string query, SqlParameter[] parameters = null);
        object ExecuteScalar(string query, SqlParameter[] parameters = null);
        SqlDataReader ExecuteReader(string query, SqlParameter[] parameters = null);
    }
}
