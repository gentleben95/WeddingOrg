using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingOrg.Data;
using WeddingOrg.Models;
using WeddingOrg.Repositories;
using System.Collections;
using Microsoft.AspNetCore.Server.IIS.Core;
using WeddingOrg.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeddingOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeddingsController : ControllerBase
    {
 
        private readonly IWeddingsRepository _weddingsRepository;

        public WeddingsController(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        // GET: api/<WeddingsController>
        [HttpGet]
        public async Task<IEnumerable<Wedding>> GetWeddings(CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.GetWeddings(cancellationToken);
            return wedding;
        }

        //GET api/<WeddingsController>/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetWeddingsById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.GetWeddingsById(id, cancellationToken);
            if (wedding == default) { return BadRequest($"Nie ma wesela z ID numer [{id}]"); }
            return Ok(wedding + $"Znaleziono wesele z ID numer [{id}]");
        }              
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody]UpdateWholeWeddingDto dto, CancellationToken cancellationToken)
        {
            await _weddingsRepository.CreateWeedingBGPCR(dto, cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.DeleteWeddingById(id, cancellationToken);
            if (wedding == default) { return BadRequest($"Nie ma wesela z ID numer [{id}]"); }
            return Ok();
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
        // DELETE api/<WeddingsController>/5

        //POST api/<WeddingsController>
        //[HttpPost]
        //public void Post(string contractId,
        //    string brideName, string bridePhoneNumber,
        //    string brideEmail, string brideInstagram,
        //    string groomName, string groomPhoneNumber,
        //    string groomEmail, string groomInstagram)
        //{
        //    _weddingsRepository.CreateWedding(contractId);
        //    _weddingsRepository.CreateBride(brideName, bridePhoneNumber, brideEmail, brideInstagram);
        //    _weddingsRepository.CreateGroom(groomName, groomPhoneNumber, groomEmail, groomInstagram);

        //}
    }
}
