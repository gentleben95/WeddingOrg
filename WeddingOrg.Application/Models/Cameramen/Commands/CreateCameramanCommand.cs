using FluentValidation;
using MediatR;
using WeddingOrg.Application.Models.Cameramen.DTOs;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Models.Cameramen.Commands
{
    public record CreateCameramanCommand(CameramanDto CameramanDto) : IRequest<CameramanDto>;
    

    public class CreateCameramanCommandValidator : AbstractValidator<CreateCameramanCommand>
    {
        public CreateCameramanCommandValidator()
        {
            RuleFor(x => x.CameramanDto.cameramanName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CameramanDto.cameramanFacebook).MaximumLength(60);
            RuleFor(x => x.CameramanDto.cameramanInstagram).MaximumLength(60);
        }
    }

    public class CreateCameramanCommandHandler : IRequestHandler<CreateCameramanCommand, CameramanDto>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public CreateCameramanCommandHandler(IWeddingsRepository weddingsRepository, IMediator mediator)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<CameramanDto> Handle(CreateCameramanCommand request, CancellationToken cancellationToken)
        {
            await _weddingsRepository.CreateCameraman(request.CameramanDto);
            return request.CameramanDto;
        }
    }
}
