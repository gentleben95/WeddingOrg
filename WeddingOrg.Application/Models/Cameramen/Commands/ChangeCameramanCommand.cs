using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Cameramen.DTOs;

namespace WeddingOrg.Application.Models.Cameramen.Commands
{
    public record ChangeCameramanCommand(int CameramanId, CameramanDto CameramanDto) : IRequest<CameramanDto>;

    public class ChangeCameramanCommandValidator : AbstractValidator<ChangeCameramanCommand>
    {
        public ChangeCameramanCommandValidator()
        {
            RuleFor(x => x.CameramanDto.cameramanName).MaximumLength(50);
            RuleFor(x => x.CameramanDto.cameramanFacebook).MaximumLength(60);
            RuleFor(x => x.CameramanDto.cameramanInstagram).MaximumLength(60);
        }
    }
    public class ChangeCameramanCommandHandler : IRequestHandler<ChangeCameramanCommand, CameramanDto>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public ChangeCameramanCommandHandler(IWeddingsRepository weddingsRepository, IMediator mediator)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<CameramanDto> Handle(ChangeCameramanCommand request, CancellationToken cancellationToken)
        {
            await _weddingsRepository.ChangeCameraman(request.CameramanId, request.CameramanDto, cancellationToken);
            return request.CameramanDto;
        }
    }
}
