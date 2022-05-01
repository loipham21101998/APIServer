using DigitalPhotoPrinting.Models;
using DigitalPhotoPrinting.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPhotoPrinting.Controllers
{
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private AdminService adminService;
        public AdminController(AdminService _adminService)
        {
            adminService = _adminService;
        }

        [Produces("application/json")]
        [HttpGet("findallorder")]
        public IActionResult FindAllOrder()
        {
            try
            {
                return Ok(adminService.FindAllOrder());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findorderdetails/{orderId}")]
        public IActionResult FindOrderDetails(int orderId)
        {
            try
            {
                return Ok(adminService.FindOrderDetails(orderId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("update")]
        public IActionResult Update([FromBody]  Material material)
        {
            try
            {
                return Ok(adminService.UpdateMaterial(material));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
