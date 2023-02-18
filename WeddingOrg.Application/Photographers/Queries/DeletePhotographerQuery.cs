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

//namespace WeddingOrg.Application.Photographers.Queries
//{
//    public class DeletePhotographerQuery : IRequest<PhotographerDto>
//        {
//            public int Id { get; set; }
//        public DeletePhotographerQuery(int id)
//        {
//            Id = id;
//        }
//        }
//    public class DeletePhotographerQueryHandler : IRequestHandler<DeletePhotographerQuery, PhotographerDto>
//    {
//        private readonly IWeddingsRepository _weddingsRepository;
//        private readonly IMapper _mapper;

//        public DeletePhotographerQueryHandler(IWeddingsRepository weddingsRepository, CancellationToken cancellationToken, IMapper mapper)
//        {
//            _weddingsRepository = weddingsRepository;
//            _mapper = mapper;
//        }

//        public async Task<PhotographerDto> Handle(DeletePhotographerQuery request, CancellationToken cancellationToken)
//        {
//            var photographer = await _weddingsRepository.DeletePhotographerById(request.Id, cancellationToken);
//            var photographerDto = _mapper.Map<PhotographerDto>(photographer);
//            return photographerDto;
//        }
//    }
//}
