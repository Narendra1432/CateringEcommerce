namespace CateringEcommerce.Domain.Models;

public class UserModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public long ContactNumber { get; set; }
    public string Address { get; set; }
}