using Carguero.Registration.Poc.Domain.Contracts.Services.Partners;
using Carguero.Registration.Poc.Domain.Core.Contracts;
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

        [HttpGet("{id:int}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "NotFound")]
        [SwaggerOperation(Summary = "Get an Driver by Driver ID", Description = "Request an Driver by it's Driver Id.")]
        public IActionResult GetByDriverId([FromRoute(Name = "id")] int id)
        {
            var result = _driverService.GetAll();

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
