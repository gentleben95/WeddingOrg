using Microsoft.AspNetCore.Mvc;
using WeddingOrg.Application.DTOs;
using WeddingOrg.Application.Interfaces;
using MediatR;
using WeddingOrg.Application.Models.Weddings.Queries;
using WeddingOrg.Application.Models.Weddings.DTOs;
using WeddingOrg.Application.Models.Weddings.Commands;
using WeddingOrg.Application.Models.Photographers.Queries;
using WeddingOrg.Domain.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeddingOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeddingsController : ControllerBase
    {
 
        private readonly IWeddingsRepository _weddingsRepository;
        private readonly IMediator _mediator;

        public WeddingsController(IWeddingsRepository weddingsRepository, IMediator mediator)
        {
            _weddingsRepository = weddingsRepository;
            _mediator = mediator;
        }
        // GET: api/<WeddingsController>
        [HttpGet]
        public async Task<IEnumerable<Wedding>> GetWeddings(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetWeddingsQuery());
        }

        //GET api/<WeddingsController>/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetWeddingsById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _mediator.Send(new GetWeddingByIdQuery(id));
            if (wedding == default) { return BadRequest($"Nie ma wesela z ID o numerze [{id}]"); }
            return Ok(wedding);
        }
        [HttpPost]
        public async Task<int> CreateWedding([FromBody] WeddingDto dto)
        {
            return await _mediator.Send(new CreateWeddingCommand(dto));
            
        }
        [HttpPut("{id}")]
        public async Task<int> ChangeWedding(int id, [FromBody] WeddingDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ChangeWeddingCommand(id, dto));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteWeddingById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _mediator.Send(new DeleteWeddingCommand(id));
            if (wedding == default) { return BadRequest($"Nie ma wesela z ID o numerze [{id}]"); }
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<int> AddPhotographerToWedding(int photographerId, int weddingId)
        {
            return await _mediator.Send(new AddPhotographerToWeddingCommand(photographerId, weddingId));

        }
        [HttpPut("{id}")]
        public async Task<int> AddCameramanToWedding(int cameramanId, int weddingId)
        {
            return await _mediator.Send(new AddCameramanToWeddingCommand(cameramanId, weddingId));
        }
        [HttpPut("{id}")]
        public async Task<int> AddRestaurantToWedding(int restaurantId, int weddingId)
        {
            return await _mediator.Send(new AddRestaurantToWeddingCommand(restaurantId, weddingId));
        }
    }
}
