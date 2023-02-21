using Microsoft.AspNetCore.Mvc;
using MediatR;
using WeddingOrg.Application.Models.Photographers.Queries;
using WeddingOrg.Application.Models.Photographers.DTOs;
using WeddingOrg.Application.Models.Photographers.Commands;

namespace WeddingOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotographersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhotographersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<WeddingsController>
        [HttpGet]
        public async Task<IEnumerable<PhotographerDto>> GetPhotographers(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetPhotographersQuery());
        }

        //GET api/<WeddingsController>/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetPhotographerById(int id, CancellationToken cancellationToken)
        {
            var photographer = await _mediator.Send(new GetPhotographerByIdQuery(id));
            if (photographer == default) { return BadRequest($"Nie ma fotografa z ID o numerze [{id}]"); }
            return Ok(photographer + $"Znaleziono fotografa z ID o numerze [{id}]");
        }
        [HttpPost]
        public async Task<IActionResult> CreatePhotographer([FromBody] PhotographerDto dto)
        {
            await _mediator.Send(new CreatePhotographerCommand(dto));
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<int> ChangePhotographer(int id, [FromBody] PhotographerDto dto)
        {
            return await _mediator.Send(new ChangePhotographerCommand(id, dto));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeletePhotographerById(int id, CancellationToken cancellationToken)
        {
            var photographer = await _mediator.Send(new DeletePhotographerCommand(id));
            if (photographer == default) { return BadRequest($"Nie ma fotografa z ID o numerze [{id}]"); }
            return Ok();
        }
    }
}
