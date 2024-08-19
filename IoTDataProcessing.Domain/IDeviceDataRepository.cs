using IoTDataProcessing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDataProcessing.Domain
{
    public interface IDeviceDataRepository
    {
        Task AddAsync(DeviceData data);
        Task<IEnumerable<DeviceData>> GetByDeviceIdAsync(string deviceId, DateTime startDate, DateTime endDate);
    }
}
