using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Cameramen.Commands;
using WeddingOrg.Application.Models.Weddings.DTOs;

namespace WeddingOrg.Application.Models.Weddings.Commands
{
    public record CreateWeddingCommand(WeddingDto WeddingDto) : IRequest<int>;
    public class CreateWeddingCommandValidator : AbstractValidator<CreateWeddingCommand>
    {
        public CreateWeddingCommandValidator()
        {
            RuleFor(x => x.WeddingDto.dateOfTheWedding).NotEmpty().MaximumLength(50)
                .NotEmpty()
                .Matches("^[0-9!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/? ]+$")
                .WithMessage("Only numbers and signs are allowed.");
            RuleFor(x => x.WeddingDto.dateOfSigningTheContract).MaximumLength(60)
                .NotEmpty()
                .Matches("^[0-9!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/? ]+$")
                .WithMessage("Only numbers and signs are allowed."); ;
            RuleFor(x => x.WeddingDto.brideName).MaximumLength(40)
                .NotEmpty()
                .Matches("^[a-zA-Z ]+$")
                .WithMessage("Only letters (upper or lowercase) are allowed.");
            RuleFor(x => x.WeddingDto.bridePhoneNumber).MaximumLength(20)
                .Matches("^[0-9!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/? ]+$")
                .WithMessage("Only numbers and signs are allowed.");
            RuleFor(x => x.WeddingDto.brideEmail).MaximumLength(50);
            RuleFor(x => x.WeddingDto.brideInstagram).MaximumLength(50);
            RuleFor(x => x.WeddingDto.groomName).MaximumLength(40)
                .NotEmpty()
                .Matches("^[a-zA-Z ]+$")
                .WithMessage("Only letters (upper or lowercase) are allowed.");
            RuleFor(x => x.WeddingDto.groomPhoneNumber).MaximumLength(20)
                .Matches("^[0-9!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/? ]+$")
                .WithMessage("Only numbers and signs are allowed.");
            RuleFor(x => x.WeddingDto.groomEmail).MaximumLength(50);
            RuleFor(x => x.WeddingDto.groomInstagram).MaximumLength(50);
        }
    }
    public class CreateWeddingCommandHandler : IRequestHandler<CreateWeddingCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public CreateWeddingCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<int> Handle(CreateWeddingCommand request, CancellationToken cancellationToken)
        {
            var wedding = await _weddingsRepository.CreateWeddingBrideGroom(request.WeddingDto);
            return wedding;
        }
    }
}
