using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingOrg.DTOs;

namespace WeddingOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            // your code to handle GET request
            return Ok("Got it!");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            // your code to handle POST request
            return Ok("Received: " + value);
        }
    }
}
