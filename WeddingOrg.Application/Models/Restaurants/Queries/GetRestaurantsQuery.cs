using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Restaurants.DTOs;
using WeddingOrg.Domain.Entities;

namespace WeddingOrg.Application.Models.Restaurants.Queries
{
    public record GetRestaurantsQuery : IRequest<IEnumerable<Restaurant>>;
    public class GetRestaurantsQueryHandler : IRequestHandler<GetRestaurantsQuery, IEnumerable<Restaurant>>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetRestaurantsQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }

        public async Task<IEnumerable<Restaurant>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.GetRestaurants(cancellationToken);
        }
    }
}
