using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Photographers.DTOs;

namespace WeddingOrg.Application.Models.Photographers.Queries
{
    public record GetPhotographersQuery : IRequest<IEnumerable<PhotographerDto>>;  
    public class GetPhotographerQueryHandler : IRequestHandler<GetPhotographersQuery, IEnumerable<PhotographerDto>>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetPhotographerQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<IEnumerable<PhotographerDto>> Handle(GetPhotographersQuery request, CancellationToken cancellationToken)
        {
            var photographer = await _weddingsRepository.GetPhotographers(cancellationToken);
            var photographerDto = photographer.Select(p =>
            {
                return new PhotographerDto(p.Name, p.Facebook, p.Instagram);
            });
            return photographerDto;
        }
    }
}
