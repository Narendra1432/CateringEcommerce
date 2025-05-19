using CateringEcommerce.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace CateringEcommerce.BAL.BAL
{
    public class ManageUser
    {
        private readonly IDatabaseHelper _db;

        public ManageUser(IDatabaseHelper db)
        {
            _db = db;
        }

        public int CreateUser(string name, string email)
        {
            string query = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            SqlParameter[] parameters = {
            new SqlParameter("@Name", name),
            new SqlParameter("@Email", email)
            };
            return _db.ExecuteNonQuery(query, parameters);
        }

        public string GetUserEmail(int userId)
        {
            string query = "SELECT Email FROM Users WHERE Id = @Id";
            SqlParameter[] parameters = {
            new SqlParameter("@Id", userId)
        };
            return _db.ExecuteScalar(query, parameters)?.ToString();
        }
    }

}
