using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingOrg.Data;
using WeddingOrg.Models;
using WeddingOrg.Repositories;
using System.Collections;
using Microsoft.AspNetCore.Server.IIS.Core;
using WeddingOrg.DTOs;
using WeddingOrg.Views;

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
        public async Task<ActionResult<FullWeddingView>> GetWeddingsById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.GetWeddingById(id, cancellationToken);
            if (wedding == default) { return BadRequest($"Nie ma wesela z ID o numerze [{id}]"); }
            return Ok(wedding);
        }              
        [HttpPost]
        public async Task<IActionResult> CreateWedding ([FromBody]UpdateWeddingBrideGroomDto dto, CancellationToken cancellationToken)
        {
            await _weddingsRepository.CreateWeedingBrideGroom(dto, cancellationToken);
            return NoContent();
        }
        [HttpPut("{id}")]
        public void ChangeWedding(int id, [FromBody] UpdateWeddingDto dto, CancellationToken cancellationToken)
        {
            var wedding = _weddingsRepository.ChangeWedding(id, dto, cancellationToken);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeddingById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.DeleteWeddingById(id, cancellationToken);
            if (wedding == default) { return BadRequest($"Nie ma wesela z ID o numerze [{id}]"); }
            return Ok();
        }
        
    }
}
