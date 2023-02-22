using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Models.Weddings.Commands
{
    public record AddRestaurantToWeddingCommand(int RestaurantId, int WeddingId) : IRequest<int>;
    public class AddRestaurantToWeddingCommandHandler : IRequestHandler<AddRestaurantToWeddingCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public AddRestaurantToWeddingCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<int> Handle(AddRestaurantToWeddingCommand request, CancellationToken cancellationToken)
        {
            await _weddingsRepository.AddRestaurantToWedding(request.WeddingId, request.RestaurantId);
            return request.RestaurantId;
        }
    }
}
