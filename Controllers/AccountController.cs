using DigitalPhotoPrinting.Models;
using DigitalPhotoPrinting.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPhotoPrinting.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        AccountService accountService;

        public AccountController(AccountService _accountService)
        {
           accountService = _accountService;
        }



        [Produces("application/json")]
        [HttpGet("login/{username}/{password}")]
        public IActionResult Login(string username,string password)
        {
            try
            {
                return Ok(accountService.Login(username, password));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findall")]
        public IActionResult Findall()
        {
            try
            {
                return Ok(accountService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Account account)
        {
            try
            {
                return Ok(accountService.Create(account));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpPost("find/{username}")]
        public IActionResult Find(string username)
        {
            try
            {
                return Ok(accountService.Find(username));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
