using MediatR;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Weddings.DTOs;

namespace WeddingOrg.Application.Models.Weddings.Queries
{
    public record GetWeddingsQuery : IRequest<IEnumerable<WeddingDto>>;
    public class GetWeddingsQueryHandler : IRequestHandler<GetWeddingsQuery, IEnumerable<WeddingDto>>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public GetWeddingsQueryHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<IEnumerable<WeddingDto>> Handle(GetWeddingsQuery request, CancellationToken cancellationToken)
        {
            var weddings = await _weddingsRepository.GetWeddings(cancellationToken);
            var weddingDto = weddings.Select(w =>
            {
                return new WeddingDto(w.DateOfSigningTheContract, w.DateOfTheWedding,
                    w.Bride.Name, w.Bride.PhoneNumber, w.Bride.Email, w.Bride.Instagram,
                    w.Groom.Name, w.Groom.PhoneNumber, w.Groom.Email, w.Groom.Instagram);
            });
            return weddingDto;
        }
    }
}
