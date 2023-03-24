using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Exceptions;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Photographers.DTOs;

namespace WeddingOrg.Application.Models.Photographers.Commands
{
    public record ChangePhotographerCommand(int PhotographerId, PhotographerDto PhotographerDto) : IRequest<int>;
    public class ChangePhotographerCommandHandler : IRequestHandler<ChangePhotographerCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public ChangePhotographerCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<int> Handle(ChangePhotographerCommand request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.ChangePhotographer(request.PhotographerId, request.PhotographerDto, cancellationToken);
        }
    }
}
