using Carguero.Registration.Poc.Domain.Contracts.Services.Partners;
using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Models.Partners;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Carguero.Registration.Poc.Api.Controllers.V1
{
    /// <summary>
    /// Service responsible for all registration flows
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/drivers")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly INotifier _notifier;

        public DriverController(IDriverService driverService, INotifier notifier)
        {
            _driverService = driverService;
            _notifier = notifier;
        }

        [HttpGet("{cpf}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "NotFound")]
        [SwaggerOperation(Summary = "Get an Driver by Driver cpf", Description = "Request an Driver by it's Driver cpf.")]
        public IActionResult GetDriverActiveByName([FromRoute] string cpf)
        {
            var result = _driverService.GetDriverActiveByCpf(cpf);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok")]
        [SwaggerOperation(Summary = "Get an Driver by Driver cpf and tenantId", Description = "Returns the driver with the Associate Tenants.")]
        public IActionResult GetDriverActiveByTenant([FromQuery] string cpf, [FromQuery(Name = "tenant-id")] int tenantId)
        {
            var result = _driverService.GetDriverActiveByTenant(cpf, tenantId);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, "Created")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerOperation(Summary = "Create an driver", Description = "Create a new driver from the requisition template")]
        public IActionResult CreateSample([FromBody] DriverRequest driverRequest)
        {
            return CreatedAtAction(null, null);
        }
    }
}
