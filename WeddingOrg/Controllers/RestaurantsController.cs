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
    public class RestaurantsController : ControllerBase
    {
 
        private readonly IWeddingsRepository _weddingsRepository;

        public RestaurantsController(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Restaurant>> GetRestaurants(CancellationToken cancellationToken = default)
        {
            var restaurant = await _weddingsRepository.GetRestaurants(cancellationToken);
            return restaurant;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetRestaurantsById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.GetRestaurantById(id, cancellationToken);
            if (wedding == default) { return BadRequest($"Nie ma restauracji z ID o numerze [{id}]"); }
            return Ok(wedding + $"Znaleziono restaurację z ID o numerze [{id}]");
        }              
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant ([FromBody]UpdateRestaurantDto dto)
        {
            await _weddingsRepository.CreateRestaurant(dto);
            return NoContent();
        }
        [HttpPut("{id}")]
        public void ChangeRestaurant(int id, [FromBody] UpdateRestaurantDto dto, CancellationToken cancellationToken)
        {
            var wedding = _weddingsRepository.ChangeRestaurant(id, dto, cancellationToken);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.DeleteWeddingById(id, cancellationToken);
            if (wedding == default) { return BadRequest($"Nie ma restauracji z ID o numerze [{id}]"); }
            return Ok();
        }
        [HttpPut("{weddingId}/concatenaterestaurant")]
        public async Task<IActionResult> AddRestaurantToWedding(int weddingId, [FromBody] int restaurantId, CancellationToken cancellationToken)
        {
            var restaurant = await _weddingsRepository.AddRestaurantToWedding(weddingId, restaurantId, cancellationToken);
            if (restaurant == default) { return NotFound($"Nie ma restauracji z ID o numerze [{restaurantId}]"); }
            if (weddingId == default) { return NotFound($"Nie ma wesela z ID o numerze [{weddingId}]"); }
            return Ok();
        }
    }
}
