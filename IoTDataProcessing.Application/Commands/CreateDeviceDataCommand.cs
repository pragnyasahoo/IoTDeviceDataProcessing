using IoTDataProcessing.Domain.Models;
using MediatR; 


namespace IoTDataProcessing.Application.Commands
{
    public class CreateDeviceDataCommand : IRequest<bool>
    {
        public required DeviceData DeviceData { get; set; }
    }
} 
