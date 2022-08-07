using Carguero.Registration.Poc.Domain.Contracts.Services.Partners;
using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Models.Partners;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Carguero.Registration.Poc.Api.Controllers.V2
{
    /// <summary>
    /// Service responsible for all registration flows
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
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

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, "Created")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [SwaggerOperation(Summary = "Create an driver", Description = "Create a new driver from the requisition template")]
        public async Task<IActionResult> CreateSample([FromBody] DriverRequest driverRequest)
        {
            try
            {
                await _driverService.RegisterAsync(driverRequest);

                if (_notifier.HasNotification())
                {
                    return BadRequest(_notifier.GetNotifications());
                }

                return CreatedAtAction(default, default);
            }
            catch (Exception ex)
            {
                return BadRequest(_notifier.GetNotifications(ex));
            }
        }
    }
}
