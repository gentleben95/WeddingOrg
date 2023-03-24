using MediatR;
using WeddingOrg.Application.Exceptions;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Photographers.DTOs;

namespace WeddingOrg.Application.Models.Photographers.Queries
{
    public record GetPhotographerByIdQuery(int PhotographerId) : IRequest<PhotographerDto>;
    public class GetPhotographerByIdQueryHandler : IRequestHandler<GetPhotographerByIdQuery, PhotographerDto>
    {
        private readonly IWeddingsRepository _photographerRepository;

        public GetPhotographerByIdQueryHandler(IWeddingsRepository photographerRepository)
        {
            _photographerRepository = photographerRepository;
        }
        public async Task<PhotographerDto> Handle(GetPhotographerByIdQuery request, CancellationToken cancellationToken)
        {
            var photographer = await _photographerRepository.GetPhotographerById(request.PhotographerId, cancellationToken);
            if (photographer == default)
            {
                throw new WeddingNotFoundException($"Photographer with {request.PhotographerId} does not exist.");
            }
            var photographerDto = new PhotographerDto(photographer.Name, photographer.Facebook, photographer.Instagram);
            return photographerDto;
        }
    }
}
