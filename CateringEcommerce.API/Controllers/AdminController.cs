using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using CateringEcommerce.Domain.Models;
using CateringEcommerce.BAL;


namespace CateringEcommerce.API.Controllers
{
    [ApiController]
    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString() =>
            _configuration.GetConnectionString("DefaultConnection");

        AdminData adminData = new AdminData();

        [HttpGet]
        public IActionResult GetAll()
        {
            var Data = adminData.GetAllAdmin();

            return Ok(Data);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var Data = adminData.GetAdminById(Id);
            return Ok(Data);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            bool success = adminData.DeleteAdmin(Id);
            // if (!success)
            return Ok(success);
        }

        [HttpPost]
        public IActionResult Create(AdminModel adminModel)
        {
            var success = adminData.InsertAdminDetails(adminModel);
            return Ok(success);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, AdminModel adminModel)
        {
            var success = adminData.UpdateAdminDetails(Id, adminModel);
            return Ok(success);
        }

    }
}