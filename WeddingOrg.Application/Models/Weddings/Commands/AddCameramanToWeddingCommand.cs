using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Models.Weddings.Commands
{
    public record AddCameramanToWeddingCommand(int CameramanId, int WeddingId) : IRequest<int>;
    public class AddCameramanToWeddingCommandHandler : IRequestHandler<AddCameramanToWeddingCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public AddCameramanToWeddingCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<int> Handle(AddCameramanToWeddingCommand request, CancellationToken cancellationToken)
        {
            await _weddingsRepository.AddCameramanToWedding(request.WeddingId, request.CameramanId);
            return request.WeddingId;
        }
    }
}
