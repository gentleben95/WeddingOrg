using FluentValidation;
using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Photographers.DTOs;

namespace WeddingOrg.Application.Models.Photographers.Commands
{
    public record CreatePhotographerCommand(PhotographerDto PhotographerDto) : IRequest<PhotographerDto>;
    public class CreatePhotographerCommandValidator : AbstractValidator<CreatePhotographerCommand>
    {
        public CreatePhotographerCommandValidator()
        {
            RuleFor(x => x.PhotographerDto.photographerName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.PhotographerDto.photographerFacebook).MaximumLength(60);
            RuleFor(x => x.PhotographerDto.photographerInstagram).MaximumLength(60);
        }
    }
    public class CreatePhotographerCommandHandler : IRequestHandler<CreatePhotographerCommand, PhotographerDto>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public CreatePhotographerCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<PhotographerDto> Handle(CreatePhotographerCommand request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.CreatePhotographer(request.PhotographerDto);
        }
    }
}
