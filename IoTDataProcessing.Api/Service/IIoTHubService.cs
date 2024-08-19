using IoTDataProcessing.Domain.Models;

namespace IoTDataProcessing.Api.Service
{
    public interface IIoTHubService
    {
        Task<string> ReceiveMessageAsync();
    }
}
