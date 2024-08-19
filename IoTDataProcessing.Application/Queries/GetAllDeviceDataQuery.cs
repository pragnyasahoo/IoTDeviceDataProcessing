using IoTDataProcessing.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDataProcessing.Application.Queries
{
    public class GetAllDeviceDataQuery : IRequest<IEnumerable<DeviceData>> { }
}
