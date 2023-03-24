using MediatR;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Models.Weddings.Commands
{
    public record DeleteWeddingCommand(int WeddingId) : IRequest<int>;
    public class DeleteWeddingCommandHandler : IRequestHandler<DeleteWeddingCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public DeleteWeddingCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }
        public async Task<int> Handle(DeleteWeddingCommand request, CancellationToken cancellationToken)
        {
            return await _weddingsRepository.DeleteWeddingById(request.WeddingId, cancellationToken);
        }
    }
}
