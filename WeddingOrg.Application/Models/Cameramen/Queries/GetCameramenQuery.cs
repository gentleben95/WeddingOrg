using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Cameramen.DTOs;
using WeddingOrg.Domain.Entities;

namespace WeddingOrg.Application.Models.Cameramen.Queries
{
    public record GetCameramenQuery : IRequest<IEnumerable<Cameraman>>;
    public class GetCameramenQueryHandler : IRequestHandler<GetCameramenQuery, IEnumerable<Cameraman>>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetCameramenQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }

        public async Task<IEnumerable<Cameraman>> Handle(GetCameramenQuery request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.GetCameramen(cancellationToken);                       
        }
    }
}
