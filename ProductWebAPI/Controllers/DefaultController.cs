using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[Action]")]
        public IActionResult Login()
        {
            return Created("", new BuildToken().CreateToken());
        }

        [HttpGet("[Action]")]
        [Authorize]
        public IActionResult CustomerList()
        {
            return Ok("Müşteri listesine eriştiniz....");
        }
    }
}
