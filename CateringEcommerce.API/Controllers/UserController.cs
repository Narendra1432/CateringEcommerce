using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using CateringEcommerce.Domain.Models;
using CateringEcommerce.BAL;


namespace CateringEcommerce.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString() =>
            _configuration.GetConnectionString("DefaultConnection");

        UserData userData = new UserData();

        [HttpGet]
        public IActionResult GetAll()
        {
            var Data = userData.GetAllUser();

            return Ok(Data);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var Data = userData.GetUserById(Id);
            return Ok(Data);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            bool success = userData.DeleteUser(Id);
            // if (!success)
            return Ok(success);
        }

        [HttpPost]
        public IActionResult Create(UserModel userModel)
        {
            var success = userData.InsertUserDetails(userModel);
            return Ok(success);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, UserModel userModel)
        {
            var success = userData.UpdateUserDetails(Id, userModel);
            return Ok(success);
        }

    }
}