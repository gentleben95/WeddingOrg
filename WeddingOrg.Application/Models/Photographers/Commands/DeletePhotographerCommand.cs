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
    public record DeletePhotographerCommand(int PhotographerId) : IRequest<int>;
    public class DeletePhotographerCommandHandler : IRequestHandler<DeletePhotographerCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public DeletePhotographerCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<int> Handle(DeletePhotographerCommand request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.DeletePhotographerById(request.PhotographerId, cancellationToken);
        }
    }
}
