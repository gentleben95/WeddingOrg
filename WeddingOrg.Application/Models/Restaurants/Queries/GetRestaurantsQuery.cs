using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Restaurants.DTOs;

namespace WeddingOrg.Application.Models.Restaurants.Queries
{
    public record GetRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>;
    public class GetRestaurantsQueryHandler : IRequestHandler<GetRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetRestaurantsQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }

        public async Task<IEnumerable<RestaurantDto>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _weddingsRepository.GetRestaurants(cancellationToken);

            var restaurantDto = restaurant.Select(c =>
            {
                return new RestaurantDto(c.Name, c.Facebook, c.Instagram);
            });
            return restaurantDto;
        }
    }
}
