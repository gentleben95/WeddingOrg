using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Microsoft.AspNetCore.Server.IIS.Core;
using WeddingOrg.Domain.Entities;
using WeddingOrg.Application.DTOs;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Cameramen.DTOs;
using MediatR;
using WeddingOrg.Application.Cameramen.Queries;
using WeddingOrg.Application.Cameramen.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeddingOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameramenController : ControllerBase
    {

        private readonly IWeddingsRepository _weddingsRepository;
        private readonly IMediator _mediator;

        public CameramenController(IWeddingsRepository weddingsRepository, IMediator mediator)
        {
            _weddingsRepository = weddingsRepository;
            _mediator = mediator;
        }
        // GET: api/<WeddingsController>
        [HttpGet]
        public async Task<IEnumerable<CameramanDto>> GetCameramen(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetCameramenQuery());
        }

        //GET api/<WeddingsController>/5 
        [HttpGet("{id}")]
        public async Task<CameramanDto> GetCameramanById(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetCameramanByIdQuery(id));
        }
        [HttpPost]
        public async Task<CameramanDto> CreateCameraman([FromBody] CameramanDto dto)
        {
            return await _mediator.Send(new CreateCameramanCommand(dto));
        }
        [HttpPut("{id}")]
        public void ChangeWedding(int id, [FromBody] CameramanDto dto, CancellationToken cancellationToken)
        {
            _weddingsRepository.ChangeCameraman(id, dto, cancellationToken);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCameramanById(int id, CancellationToken cancellationToken)
        {
            var cameraman = await _weddingsRepository.DeleteCameramanById(id, cancellationToken);
            if (cameraman == default) { return BadRequest($"Nie ma kamerzysty z ID o numerze [{id}]"); }
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
