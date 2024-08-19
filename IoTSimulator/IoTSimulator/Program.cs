using System.Text; 
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
namespace IoTSimulator
{
    class Program
    {
        private static readonly string connectionString = "YOUR_IOT_HUB_CONNECTION_STRING";
        private static readonly string deviceId = "YOUR_DEVICE_ID";
        private static readonly int numberOfMessages = 100;

        static async Task Main(string[] args)
        {
            var serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            for (int i = 0; i < numberOfMessages; i++)
            {
                var message = GenerateIoTMessage();
                var messageString = JsonConvert.SerializeObject(message);
                var messageBytes = Encoding.ASCII.GetBytes(messageString);
                var cloudMessage = new Message(messageBytes);

                await serviceClient.SendAsync(deviceId, cloudMessage);
                Console.WriteLine($"Message sent: {messageString}");
                await Task.Delay(1000); // Delay between messages
            }
        }

        private static DeviceMessage GenerateIoTMessage()
        {
            return new DeviceMessage
            {
                DeviceId = deviceId,
                Timestamp = DateTime.UtcNow,
                Temperature = 20 + new Random().NextDouble() * 10, // Random temperature between 20 and 30
                Humidity = 30 + new Random().NextDouble() * 20 // Random humidity between 30 and 50
            };
        }
    }

    class DeviceMessage
    {
        public string DeviceId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}