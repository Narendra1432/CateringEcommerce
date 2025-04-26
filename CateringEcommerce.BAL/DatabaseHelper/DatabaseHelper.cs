using CateringEcommerce.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
namespace CateringEcommerce.BAL.DatabaseHelper
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public virtual int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (var connection = CreateConnection())
            using (var command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public virtual object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (var connection = CreateConnection())
            using (var command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteScalar();
            }
        }

        public virtual SqlDataReader ExecuteReader(string query, SqlParameter[] parameters = null)
        {
            var connection = CreateConnection();
            var command = new SqlCommand(query, connection);

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}