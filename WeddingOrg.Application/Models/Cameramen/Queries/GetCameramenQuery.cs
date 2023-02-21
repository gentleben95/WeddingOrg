using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Cameramen.DTOs;

namespace WeddingOrg.Application.Models.Cameramen.Queries
{
    public record GetCameramenQuery : IRequest<IEnumerable<CameramanDto>>;
    public class GetCameramenQueryHandler : IRequestHandler<GetCameramenQuery, IEnumerable<CameramanDto>>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetCameramenQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }

        public async Task<IEnumerable<CameramanDto>> Handle(GetCameramenQuery request, CancellationToken cancellationToken)
        {
            var cameramen = await _weddingsRepository.GetCameramen(cancellationToken);

            var cameramanDto = cameramen.Select(c =>
            {
                return new CameramanDto(c.Name, c.Facebook, c.Instagram);
            });

            return cameramanDto;
        }
    }
}
