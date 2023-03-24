using MediatR;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Models.Restaurants.Commands
{
    public record DeleteRestaurantCommand(int RestaurantId) : IRequest<int>;
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public DeleteRestaurantCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }

        public async Task<int> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.DeleteRestaurantById(request.RestaurantId, cancellationToken);
        }
    }
}
