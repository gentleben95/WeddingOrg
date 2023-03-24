using MediatR;
using WeddingOrg.Application.Exceptions;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Cameramen.DTOs;

namespace WeddingOrg.Application.Models.Cameramen.Queries
{
    public record GetCameramanByIdQuery(int Id) : IRequest<CameramanDto>;

    public class GetCameramanByIdQueryHandler : IRequestHandler<GetCameramanByIdQuery, CameramanDto>
    {
        private readonly IWeddingsRepository _photographerRepository;
        private readonly IMediator _mediator;

        public GetCameramanByIdQueryHandler(IWeddingsRepository photographerRepository)
        {
            _photographerRepository = photographerRepository;
        }

        public async Task<CameramanDto> Handle(GetCameramanByIdQuery request, CancellationToken cancellationToken)
        {
            var cameraman = await _photographerRepository.GetCameramanById(request.Id, cancellationToken);
            if (cameraman == default)
            {
                throw new WeddingNotFoundException($"Cameraman with ID nr {request.Id} does not exist.");
            }
            var cameramanDto = new CameramanDto(cameraman.Name, cameraman.Facebook, cameraman.Instagram);
            return cameramanDto;
        }
    }
}
