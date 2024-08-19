using IoTDataProcessing.Domain.Models;
using IoTDataProcessing.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDataProcessing.Application.Queries
{
    public class GetAllDeviceDataQueryHandler : IRequestHandler<GetAllDeviceDataQuery, IEnumerable<DeviceData>>
    {
        private readonly IDeviceDataRepository _repository;

        public GetAllDeviceDataQueryHandler(IDeviceDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DeviceData>> Handle(GetAllDeviceDataQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}