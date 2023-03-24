using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Weddings.DTOs;
using WeddingOrg.Domain.Entities;

namespace WeddingOrg.Application.Models.Weddings.Queries
{
    public record GetWeddingsQuery : IRequest<IEnumerable<Wedding>>;
    public class GetWeddingsQueryHandler : IRequestHandler<GetWeddingsQuery, IEnumerable<Wedding>>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetWeddingsQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<IEnumerable<Wedding>> Handle(GetWeddingsQuery request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.GetWeddings(cancellationToken);

        }
    }
}
