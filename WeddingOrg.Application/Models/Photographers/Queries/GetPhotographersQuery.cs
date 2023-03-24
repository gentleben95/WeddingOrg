using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Photographers.DTOs;
using WeddingOrg.Domain.Entities;

namespace WeddingOrg.Application.Models.Photographers.Queries
{
    public record GetPhotographersQuery : IRequest<IEnumerable<Photographer>>;  
    public class GetPhotographersQueryHandler : IRequestHandler<GetPhotographersQuery, IEnumerable<Photographer>>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetPhotographersQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<IEnumerable<Photographer>> Handle(GetPhotographersQuery request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.GetPhotographers(cancellationToken);

        }
    }
}
