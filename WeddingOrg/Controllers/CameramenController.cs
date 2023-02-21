using Microsoft.AspNetCore.Mvc;
using MediatR;
using WeddingOrg.Application.Models.Cameramen.Queries;
using WeddingOrg.Application.Models.Cameramen.Commands;
using WeddingOrg.Application.Models.Cameramen.DTOs;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeddingOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameramenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CameramenController(IMediator mediator)
        {
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
        public async Task<ActionResult<CameramanDto>> ChangeWedding(int id, [FromBody] CameramanDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ChangeCameramanCommand(id, dto));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteCameramanById(int id, CancellationToken cancellationToken)
        {
            var cameraman = await _mediator.Send(new DeleteCameramanCommand(id));
            if (cameraman == default) { return BadRequest($"Nie ma kamerzysty z ID o numerze [{id}]"); }
            return Ok();
        }
    }
}
