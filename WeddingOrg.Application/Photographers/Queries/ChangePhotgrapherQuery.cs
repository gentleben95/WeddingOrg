//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WeddingOrg.Application.Cameramen.DTOs;
//using WeddingOrg.Application.Interfaces;
//using AutoMapper;
//using WeddingOrg.Application.Photographers.DTOs;
//using WeddingOrg.Application.Exceptions;

//namespace WeddingOrg.Application.Photographers.Queries
//{
//    public class ChangePhotographerQuery1 : IRequest<PhotographerDto>
//        {
//            public int Id { get; set; }
//        public ChangePhotographerQuery1(int id)
//        {
//            Id = id;
//        }
//        }
//    public class ChangePhotographerQuery1Handler : IRequestHandler<ChangePhotographerQuery1, PhotographerDto>
//    {
//        private readonly IWeddingsRepository _weddingsRepository;
//        private readonly IMapper _mapper;

//        public ChangePhotographerQuery1Handler(IWeddingsRepository weddingsRepository, CancellationToken cancellationToken, IMapper mapper)
//        {
//            _weddingsRepository = weddingsRepository;
//            _mapper = mapper;
//        }

//        public async Task<PhotographerDto> Handle(ChangePhotographerQuery1 request, CancellationToken cancellationToken)
//        {
//            var photographer = await _weddingsRepository.DeletePhotographerById(request.Id, cancellationToken);
//            var photographerDto = _mapper.Map<PhotographerDto>(photographer);
//            if (photographer == default)
//            {
//                throw new WeddingNotFoundException($"Photographer with {request.Id} does not exist.");
//            }
//            return photographerDto;
//        }
//    }
//}
