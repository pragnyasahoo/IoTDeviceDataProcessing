using IoTDataProcessing.Domain.Models;
using Microsoft.Azure.Devices.Client;
using System.Text;
using System.Threading.Tasks;
namespace IoTDataProcessing.Api.Service
{
    public class IoTHubService : IIoTHubService
    {
        private DeviceClient _deviceClient;

        public IoTHubService(IConfiguration configuration)
        {
            var connectionString = configuration["IoTHub:ConnectionString"];
            _deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt);
        }


        public async Task<string> ReceiveMessageAsync()
        {
            var message = await _deviceClient.ReceiveAsync();
            if (message == null) return null;

            var messageData = Encoding.ASCII.GetString(message.GetBytes());
            await _deviceClient.CompleteAsync(message);
            return messageData;
        }
    }
}