using MediatR;
using IoTDataProcessing.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace IoTDataProcessing.Application.Commands
{
    public class CreateDeviceDataCommandHandler : IRequestHandler<CreateDeviceDataCommand, bool>
    {
        private readonly IDeviceDataRepository _repository;

        public CreateDeviceDataCommandHandler(IDeviceDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateDeviceDataCommand request, CancellationToken cancellationToken)
        {
              await _repository.AddAsync(request.DeviceData);
              return true;
        }

         
    }
}