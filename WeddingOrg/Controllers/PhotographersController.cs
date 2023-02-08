using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Microsoft.AspNetCore.Server.IIS.Core;
using WeddingOrg.Domain.Entities;
using WeddingOrg.Application.DTOs;
using WeddingOrg.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeddingOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotographersController : ControllerBase
    {

        private readonly IWeddingsRepository _weddingsRepository;
        public PhotographersController(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        // GET: api/<WeddingsController>
        [HttpGet]
        public async Task<IEnumerable<Photographer>> GetPhotographers(CancellationToken cancellationToken = default)
        {
            var photographer = await _weddingsRepository.GetPhotographers(cancellationToken);
            return photographer;
        }

        //GET api/<WeddingsController>/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetPhotographerById(int id, CancellationToken cancellationToken)
        {
            var photographer = await _weddingsRepository.GetPhotographerById(id, cancellationToken);
            if (photographer == default) { return BadRequest($"Nie ma fotografa z ID o numerze [{id}]"); }
            return Ok(photographer + $"Znaleziono fotografa z ID o numerze [{id}]");
        }
        [HttpPost]
        public async Task<IActionResult> CreatePhotographer([FromBody] UpdatePhotographerDto dto)
        {
            await _weddingsRepository.CreatePhotographer(dto);
            return NoContent();
        }
        [HttpPut("{id}")]
        public void ChangePhotographer(int id, [FromBody] UpdatePhotographerDto dto, CancellationToken cancellationToken)
        {
            var photographer = _weddingsRepository.ChangePhotographer(id, dto, cancellationToken);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotographerById(int id, CancellationToken cancellationToken)
        {
            var photographer = await _weddingsRepository.DeletePhotographerById(id, cancellationToken);
            if (photographer == default) { return BadRequest($"Nie ma fotografa z ID o numerze [{id}]"); }
            return Ok();
        }
        [HttpPut("{weddingId}/concatenatephoto")]
        public async Task<IActionResult> AddPhotographerToWedding(int weddingId, [FromBody] int photographerId)
        {
            var photographer = await _weddingsRepository.AddPhotographerToWedding(weddingId, photographerId);
            if (photographer == default) { return NotFound($"Nie ma fotografa z ID o numerze [{photographerId}]"); }
            if (weddingId == default) { return NotFound($"Nie ma wesela z ID o numerze [{weddingId}]"); }
            return Ok();
        }
    }
}
