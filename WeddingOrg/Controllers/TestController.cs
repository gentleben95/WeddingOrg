using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingOrg.DTOs;
using WeddingOrg.Models;
using WeddingOrg.Repositories;

namespace WeddingOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public TestController(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    // your code to handle GET request
        //    return Ok("Got it!");
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //    // your code to handle POST request
        //    return Ok("Received: " + value);
        //}
        [HttpGet]
        public async Task<IEnumerable<Wedding>> GetWeddings(CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.GetWeddings(cancellationToken);
            return wedding;
        }
        [HttpPost]
        public async Task<IActionResult> CreateWedding([FromBody] UpdateWeddingBrideGroomDto dto, CancellationToken cancellationToken)
        {
            await _weddingsRepository.CreateWeedingBrideGroom(dto, cancellationToken);
            return NoContent();
        }
    }
}
