using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Cameramen.DTOs;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Domain.Entities;

namespace WeddingOrg.Application.Cameramen.Queries
{
    public class GetCameramenQuery : IRequest<CameramanDto>
    {
    }

    public class GetCameramanQueryHandler : IRequestHandler<GetCameramenQuery, CameramanDto>
    {
        private readonly IMapper _mapper;
        private readonly IWeddingsRepository _weddingsRepository;

        public GetCameramanQueryHandler(IMapper mapper, IWeddingsRepository weddingsRepository)
        {
            _mapper = mapper;
            _weddingsRepository = weddingsRepository;
        }
        public async Task<CameramanDto> Handle(GetCameramenQuery request, CancellationToken cancellationToken)
        {
            var cameraman = await _weddingsRepository.GetCameramen(cancellationToken);
            var cameramanDto = _mapper.Map<CameramanDto>(cameraman);
            return cameramanDto;            
        }
    }
}
