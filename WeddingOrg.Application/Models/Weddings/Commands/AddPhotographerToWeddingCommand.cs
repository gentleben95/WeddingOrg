using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Models.Weddings.Commands
{
    public record AddPhotographerToWeddingCommand(int PhotographerId, int WeddingId) : IRequest<int>;
    public class AddPhotographerToWeddingCommandHandler : IRequestHandler<AddPhotographerToWeddingCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public AddPhotographerToWeddingCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<int> Handle(AddPhotographerToWeddingCommand request, CancellationToken cancellationToken)
        {
            await _weddingsRepository.AddPhotographerToWedding(request.WeddingId, request.PhotographerId);
            return request.PhotographerId;
        }
    }
}
