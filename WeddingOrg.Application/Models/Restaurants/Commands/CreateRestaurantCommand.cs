using FluentValidation;
using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Photographers.Commands;
using WeddingOrg.Application.Models.Restaurants.DTOs;

namespace WeddingOrg.Application.Models.Restaurants.Commands
{
    public record CreateRestaurantCommand(RestaurantDto RestaurantDto) : IRequest<RestaurantDto>;
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(x => x.RestaurantDto.restaurantName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.RestaurantDto.restaurantFacebook).MaximumLength(60);
            RuleFor(x => x.RestaurantDto.restaurantInstagram).MaximumLength(60);
        }
    }
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, RestaurantDto>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public CreateRestaurantCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<RestaurantDto> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.CreateRestaurant(request.RestaurantDto);
        }
    }
}
