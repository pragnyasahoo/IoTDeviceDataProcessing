using IoTDataProcessing.Application.Commands;
using IoTDataProcessing.Application.Queries; 
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTDataProcessing.Domain.Models;
using MediatR;
using static IoTDataProcessing.Application.Queries.GetAllDeviceDataQuery;
using Microsoft.AspNetCore.Authorization;

namespace IoTDataProcessing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class DeviceDataController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DeviceDataController> _logger;

        public DeviceDataController(IMediator mediator, ILogger<DeviceDataController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("receive")]
        public async Task<IActionResult> Post([FromBody] DeviceData deviceData)
        {
            _logger.LogInformation("Saving  device data...");
            var command = new CreateDeviceDataCommand { DeviceData = deviceData };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Fetching device data...");

            var query = new GetAllDeviceDataQuery();
            var data = await _mediator.Send(query);
            return Ok(data);
        }
    }
}