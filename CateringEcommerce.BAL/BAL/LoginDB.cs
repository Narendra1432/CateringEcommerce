using CateringEcommerce.Domain.Interfaces;

namespace CateringEcommerce.BAL.BAL
{
    public class LoginDB
    {
        private readonly IDatabaseHelper _db;

        public LoginDB(IDatabaseHelper db)
        {
            _db = db;
        }
    }
}
