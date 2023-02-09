using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Cameramen.DTOs;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Cameramen.Queries
{
    public class GetCameramanQuery : IRequest<CameramanDto>
    {
    }

    public class GetCameramanQueryHandler : IRequestHandler<GetCameramanQuery, CameramanDto>
    {
        private readonly IMapper _mapper;
        private readonly IWeddingsRepository _weddingsRepository;

        public GetCameramanQueryHandler(IMapper mapper, IWeddingsRepository weddingsRepository)
        {
            _mapper = mapper;
            _weddingsRepository = weddingsRepository;
        }
        public async Task<CameramanDto> Handle(GetCameramanQuery request, CancellationToken cancellationToken)
        {
            // Zwrócić pierwszego cameramana 
            var cameraman = await _weddingsRepository.GetCameramen(cancellationToken);
            var cameramanFirst = cameraman.First();
            var cameramanDto = _mapper.Map<CameramanDto>(cameramanFirst);
            //var cameramanDto = new CameramanDto(cameramanFirst.Name, cameramanFirst.Instagram, cameramanFirst.Facebook);
            return cameramanDto;            
        }
    }
}
