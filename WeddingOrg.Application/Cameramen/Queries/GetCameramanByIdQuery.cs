using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Cameramen.DTOs;
using WeddingOrg.Application.Exceptions;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Photographers.DTOs;
using WeddingOrg.Domain.Entities;

namespace WeddingOrg.Application.Cameramen.Queries
{
    public record GetCameramanByIdQuery(int Id) : IRequest<CameramanDto>;
    //public class GetCameramanByIdQuery : IRequest<CameramanDto>
    //{
    //    public int Id { get; set; }

    //    public GetCameramanByIdQuery(int id)
    //    {
    //        Id = id;
    //    }
    //}
    public class GetCameramanByIdQueryHandler : IRequestHandler<GetCameramanByIdQuery, CameramanDto>
    {
        private readonly IWeddingsRepository _photographerRepository;
        private readonly IMediator _mediator;

        public GetCameramanByIdQueryHandler(IWeddingsRepository photographerRepository, IMediator mediator)
        {
            _photographerRepository = photographerRepository;
            _mediator = mediator;
        }

        public async Task<CameramanDto> Handle(GetCameramanByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCameramenQuery());
            var output = result.
            //var cameraman = await _photographerRepository.GetCameramanById(request.Id, cancellationToken);
            //if (cameraman == default)
            //{
            //    throw new WeddingNotFoundException($"Photographer with {request.Id} does not exist.");
            //}

            //var cameramanDto = new CameramanDto(cameraman.Name, cameraman.Facebook, cameraman.Instagram);
            //return cameramanDto;
        }
    }
}
