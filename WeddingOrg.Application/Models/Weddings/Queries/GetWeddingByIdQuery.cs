using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Models.Weddings.Queries
{
    public record GetWeddingByIdQuery(int weddingId) : IRequest<int>;
    public class GetWeddingByIdQueryHandler : IRequestHandler<GetWeddingByIdQuery, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetWeddingByIdQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<int> Handle(GetWeddingByIdQuery request, CancellationToken cancellationToken)
        {
            var wedding =  await _weddingsRepository.GetWeddingById(request.weddingId, cancellationToken);
            return wedding.Id;
        }
    }
}
