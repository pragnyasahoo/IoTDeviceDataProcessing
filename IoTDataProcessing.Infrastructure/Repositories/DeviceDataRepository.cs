

using IoTDataProcessing.Domain.Models;
using IoTDataProcessing.Infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace IoTDataProcessing.Infrastructure.Repositories
{
    public class DeviceDataRepository : IDeviceDataRepository
    {
        private readonly ApplicationDbContext _context;

        public DeviceDataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DeviceData data)
        {
            _context.DeviceData.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DeviceData>> GetAllAsync()
        {
            return await _context.DeviceData.ToListAsync();
        }

        public async Task<DeviceData> GetByIdAsync(int id)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Database context is not initialized.");
            }
            var deviceData = await _context.DeviceData.FindAsync(id);
            if (deviceData == null)
            {
                // Handle the case where data is not found
                throw new KeyNotFoundException($"DeviceData with ID {id} not found.");
            }
            return deviceData;
        }
    }
}