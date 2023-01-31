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
    public class CameramenController : ControllerBase
    {

        private readonly IWeddingsRepository _weddingsRepository;

        public CameramenController(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        // GET: api/<WeddingsController>
        [HttpGet]
        public async Task<IEnumerable<Cameraman>> GetCameramen(CancellationToken cancellationToken = default)
        {
            var cameraman = await _weddingsRepository.GetCameramen(cancellationToken);
            return cameraman;
        }

        //GET api/<WeddingsController>/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetCameramanById(int id, CancellationToken cancellationToken)
        {
            var cameraman = await _weddingsRepository.GetCameramanById(id, cancellationToken);
            if (cameraman == default) { return BadRequest($"Nie ma kamerzysty z ID o numerze [{id}]"); }
            return Ok(cameraman + $"Znaleziono kamerzysty z ID o numerze [{id}]");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCameraman([FromBody] UpdateCameramanDto dto)
        {
            await _weddingsRepository.CreateCameraman(dto);
            return NoContent();
        }
        [HttpPut("{id}")]
        public void ChangeWedding(int id, [FromBody] UpdateCameramanDto dto, CancellationToken cancellationToken)
        {
            var wedding = _weddingsRepository.ChangeCameraman(id, dto, cancellationToken);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCameramanById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.DeleteWeddingById(id, cancellationToken);
            if (wedding == default) { return BadRequest($"Nie ma kamerzysty z ID o numerze [{id}]"); }
            return Ok();
        }
        [HttpPut("{weddingId}/concatenatecamera")]
        public async Task<IActionResult> AddCameramanToWedding(int weddingId, [FromBody] int cameramanId)
        {
            var cameraman = await _weddingsRepository.AddCameramanToWedding(weddingId, cameramanId);
            if (cameraman == default) { return NotFound($"Nie ma kamerzysty z ID o numerze [{cameramanId}]"); }
            if (weddingId == default) { return NotFound($"Nie ma wesela z ID o numerze [{weddingId}]"); }
            return Ok();
        }
    }
}
