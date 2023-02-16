using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Cameramen.DTOs;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Photographers.DTOs;

namespace WeddingOrg.Application.Photographers.Queries
{
    public class GetPhotographersQuery : IRequest<PhotographerDto>
    {
    }
    public class GetPhotographerQueryHandler : IRequestHandler<GetPhotographersQuery, PhotographerDto>
    {
        private readonly IMapper _mapper;
        private readonly IWeddingsRepository _weddingsRepository;

        public GetPhotographerQueryHandler(IMapper mapper, IWeddingsRepository weddingsRepository)
        {
            _mapper = mapper;
            _weddingsRepository = weddingsRepository;
        }
        public async Task<PhotographerDto> Handle(GetPhotographersQuery request, CancellationToken cancellationToken)
        {
            var photographer = await _weddingsRepository.GetPhotographers(cancellationToken);
            var photographerDto = _mapper.Map<PhotographerDto>(photographer);
            return photographerDto;
        }
    }
}
