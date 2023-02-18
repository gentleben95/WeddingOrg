//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WeddingOrg.Application.Cameramen.DTOs;
//using WeddingOrg.Application.Exceptions;
//using WeddingOrg.Application.Interfaces;
//using WeddingOrg.Application.Photographers.DTOs;
//using WeddingOrg.Domain.Entities;

//namespace WeddingOrg.Application.Photographers.Queries
//{
//    public class GetPhotographerByIdQuery : IRequest<PhotographerDto>
//    {
//        public int Id { get; set; }

//        public GetPhotographerByIdQuery(int id)
//        {
//            Id = id;
//        }
//    }
//    public class GetPhotographerByIdQueryHandler : IRequestHandler<GetPhotographerByIdQuery, PhotographerDto>
//    {
//        private readonly IWeddingsRepository _photographerRepository;

//        public GetPhotographerByIdQueryHandler(IWeddingsRepository photographerRepository, CancellationToken cancellationToken)
//        {
//            _photographerRepository = photographerRepository;
//        }

//        public async Task<PhotographerDto> Handle(GetPhotographerByIdQuery request, CancellationToken cancellationToken)
//        {
//            var photographer = await _photographerRepository.GetPhotographerById(request.Id, cancellationToken);
//            if (photographer == default)
//            {
//                throw new WeddingNotFoundException($"Photographer with {request.Id} does not exist.");
//            }

//            var photographerDto = new PhotographerDto(photographer.Name, photographer.Facebook, photographer.Instagram);
//            return photographerDto;
//        }
//    }
//}
