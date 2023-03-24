using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Application.Models.Weddings.DTOs;

namespace WeddingOrg.Application.Models.Weddings.Commands
{
    public record ChangeWeddingCommand(int WeddingId, WeddingDto WeddingDto) : IRequest<int>;
    public class ChangeWeddingCommandHanlder : IRequestHandler<ChangeWeddingCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public ChangeWeddingCommandHanlder(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<int> Handle(ChangeWeddingCommand request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.ChangeWedding(request.WeddingId, request.WeddingDto, cancellationToken);
        }
    }
}
