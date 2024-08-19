using IoTDataProcessing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDataProcessing.Infrastructure.Repositories
{
    public interface IDeviceDataRepository
    {
        Task AddAsync(DeviceData data);
        Task<IEnumerable<DeviceData>> GetAllAsync();
        Task<DeviceData> GetByIdAsync(int id);
    }
}
