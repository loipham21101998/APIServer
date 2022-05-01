using DigitalPhotoPrinting.Models;
using DigitalPhotoPrinting.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace DigitalPhotoPrinting.Controllers
{
    [Route("api/image")]
    public class ImageController : Controller
    {
        IWebHostEnvironment webHostEnvironment;
        ImageService imageService;

        public ImageController(IWebHostEnvironment _webHostEnvironment, ImageService _imageService )
        {
            webHostEnvironment = _webHostEnvironment;
            imageService = _imageService;
            //httpContextAccessor = _httpContextAccessor;
        }
        //[Consumes("application/json")]
        //[Produces("application/json")]
        [HttpPost("upload/{accountName}/{accountId}")]
        public IActionResult Upload(IFormFile file,string accountName,int accountId)
        {
            try
            {
                //var baseURL = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host + httpContextAccessor.HttpContext.Request.PathBase;
                string dir = webHostEnvironment.WebRootPath + "\\Uploads\\" + accountName;
                //if (!Directory.Exists(dir))
                //{
                    Directory.CreateDirectory(dir);
                    var path = Path.Combine(dir, file.FileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                   
                //}
                //else
                //{
                //    Debug.WriteLine("Folder Already exists");
                //}

                return Ok(imageService.InsertImage(file.FileName, accountId,accountName));
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("order/{accountId}/{total}")]
        public IActionResult Order([FromBody] PrintOrder[] printOrder, int accountId,double total)
        {
            try
            {
                foreach(var print in printOrder)
                {
                    Debug.WriteLine("Account Id: " + print.AccountId);
                    Debug.WriteLine("Materail Name: " + print.MaterialName);
                    Debug.WriteLine("Image Name: " + print.ImageName);
                    Debug.WriteLine("Size: " +print.SizeName);
                    Debug.WriteLine("Quantity: " +print.Quantity);
                    Debug.WriteLine("Date: " + print.Date);
                    Debug.WriteLine("-------------------------------" );
                }
                return Ok(imageService.Order(printOrder, accountId, total));
            }
            catch
            {
                return BadRequest();
            }

        }

        [Produces("application/json")]
        [HttpGet("findall")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(imageService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }


        [Produces("application/json")]
        [HttpGet("allmaterial")]
        public IActionResult AllMaterial()
        {
            try
            {
                return Ok(imageService.AllMaterial());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("allsize")]
        public IActionResult AllSize()
        {
            try
            {
                return Ok(imageService.AllSize());
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
