using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Microsoft.AspNetCore.Server.IIS.Core;
using WeddingOrg.Domain.Entities;
using WeddingOrg.Application.DTOs;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Photographers.DTOs;
using WeddingOrg.Application.Models.Restaurants.DTOs;
using MediatR;
using WeddingOrg.Application.Models.Restaurants.Queries;
using WeddingOrg.Application.Models.Restaurants.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeddingOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
 
        private readonly IWeddingsRepository _weddingsRepository;
        private readonly IMediator _mediator;

        public RestaurantsController(IWeddingsRepository weddingsRepository, IMediator mediator)
        {
            _weddingsRepository = weddingsRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Restaurant>> GetRestaurants(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetRestaurantsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetRestaurantsById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _mediator.Send(new GetRestaurantByIdQuery(id));
            if (wedding == default) { return BadRequest($"Nie ma restauracji z ID o numerze [{id}]"); }
            return Ok(wedding + $"Znaleziono restaurację z ID o numerze [{id}]");
        }              
        [HttpPost]
        public async Task<RestaurantDto> CreateRestaurant ([FromBody]RestaurantDto dto)
        {
           return await _mediator.Send(new CreateRestaurantCommand(dto));
        }
        [HttpPut("{id}")]
        public async Task<int> ChangeRestaurant(int id, [FromBody] RestaurantDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ChangeRestaurantCommand(id, dto));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteRestaurantById(int id, CancellationToken cancellationToken)
        {
            var restaurant = await _mediator.Send(new DeleteRestaurantCommand(id));
            if (restaurant == default) { return BadRequest($"Nie ma restauracji z ID o numerze [{id}]"); }
            return Ok();
        }
    }
}
