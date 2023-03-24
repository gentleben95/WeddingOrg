using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Restaurants.DTOs;

namespace WeddingOrg.Application.Models.Restaurants.Commands
{
    public record ChangeRestaurantCommand(int RestaurantId, RestaurantDto RestaurantDto) : IRequest<int>;
    public class ChangeRestaurantCommandHandler : IRequestHandler<ChangeRestaurantCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public ChangeRestaurantCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }

        public async Task<int> Handle(ChangeRestaurantCommand request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.ChangeRestaurant(request.RestaurantId, request.RestaurantDto, cancellationToken);
        }
    }
}
