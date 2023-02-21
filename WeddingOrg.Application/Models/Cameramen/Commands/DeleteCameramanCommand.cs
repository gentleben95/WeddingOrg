using FluentValidation;
using MediatR;
using WeddingOrg.Application.Interfaces;

namespace WeddingOrg.Application.Models.Cameramen.Commands
{
    public record DeleteCameramanCommand(int CameramanId) : IRequest<int>;

    public class DeleteCameramanCommandValidator : AbstractValidator<DeleteCameramanCommand>
    {
        public DeleteCameramanCommandValidator()
        {

        }
    }

    public class DeleteCameramanCommandHandler : IRequestHandler<DeleteCameramanCommand, int>
    {
        private readonly IWeddingsRepository _weddingsRepository;

        public DeleteCameramanCommandHandler(IWeddingsRepository weddingsRepository)
        {
            _weddingsRepository = weddingsRepository;
        }

        public async Task<int> Handle(DeleteCameramanCommand request, CancellationToken cancellationToken)
        {
            await _weddingsRepository.DeleteCameramanById(request.CameramanId, cancellationToken);
            return request.CameramanId;
        }
    }
}
