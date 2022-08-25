// <copyright file="DriverController.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using AutoMapper;
using Carguero.Registration.Poc.Api.Patterns.Models.V1;
using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Patterns.Contracts.Services;
using Carguero.Registration.Poc.Domain.Patterns.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Carguero.Registration.Poc.Api.Controllers.V1
{
    /// <summary>
    /// Service responsible for all registration flows.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/drivers")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Forbidden")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly INotifier _notifier;
        private readonly IMapper _mapper;

        public DriverController(IDriverService driverService, INotifier notifier, IMapper mapper)
        {
            _driverService = driverService;
            _notifier = notifier;
            _mapper = mapper;
        }

        [HttpGet("{cpf}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", type: typeof(DriverResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "NotFound")]
        [SwaggerOperation(Summary = "Get an Driver by Driver cpf", Description = "Request an Driver by it's Driver cpf.")]
        public async Task<IActionResult> GetDriverActiveByName([FromRoute] string cpf)
        {
            var result = await _driverService.GetDriverActiveByCpf(cpf);

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpGet("{cpf}/tenants")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", type: typeof(List<DriverResponse>))]
        [SwaggerOperation(Summary = "Get an Driver by Driver cpf and tenantId", Description = "Returns the driver with the Associate Tenants.")]
        public async Task<IActionResult> GetDriverActiveByTenant([FromQuery] string cpf, [FromQuery(Name = "tenant-id")] int tenantId)
        {
            var result = await _driverService.GetDriverActiveByTenant(cpf, tenantId);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, "Created")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerOperation(Summary = "Create an Driver", Description = "Create a new Driver from the requisition template")]
        public async Task<IActionResult> CreateDriver([FromBody] DriverRequest driverRequest)
        {
            try
            {
                await _driverService.RegisterAsync(_mapper.Map<Driver>(driverRequest));

                if (_notifier.HasNotification())
                    return BadRequest(_notifier.GetNotifications());

                return CreatedAtAction(default, default);
            }
            catch (Exception ex)
            {
                return BadRequest(_notifier.GetNotifications(ex));
            }
        }

        [HttpPut("{cpf}")]
        [SwaggerResponse(StatusCodes.Status201Created, "Created")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerOperation(Summary = "Update an driver", Description = "Update a new driver from the requisition template")]
        public async Task<IActionResult> UpdateDriver([FromRoute(Name = "cpf")] string cpf, [FromBody] DriverRequest driverRequest)
        {
            return CreatedAtAction(null, null);
        }

        [HttpPatch("{cpf}/active")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "NoContent")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerOperation(Summary = "Partial Update of an driver", Description = "Partial Update of an driver by it's cpf.")]
        public async Task<IActionResult> ActiveDriver([FromRoute] string cpf)
        {
            await _driverService.UpdateDriverActiveAsync(cpf);
            return CreatedAtAction(null, null);
        }

        [HttpDelete("{cpf}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "NoContent")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerOperation(Summary = "Delete one driver", Description = "Delete one item of driver by it's cpf.")]
        public async Task<IActionResult> DeleteDriver([FromRoute] string cpf)
        {
            return CreatedAtAction(null, null);
        }
    }
}
