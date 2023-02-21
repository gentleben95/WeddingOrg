using MediatR;
using WeddingOrg.Application.Exceptions;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Models.Restaurants.Queries
{
    public record GetRestaurantByIdQuery(int restuarantId) : IRequest<int>;
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetRestaurantByIdQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }

        public async Task<int> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _weddingsRepository.GetRestaurantById(request.restuarantId, cancellationToken);
            if (restaurant == default)
            {
                throw new WeddingNotFoundException($"Restaurant with {request.restuarantId} does not exist.");
            }
            return restaurant.Id;
        }
    }
}
