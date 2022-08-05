using Carguero.Registration.Poc.Domain.Contracts.Services.Partners;
using Carguero.Registration.Poc.Domain.Services.Partners;
using Microsoft.Extensions.DependencyInjection;

namespace Carguero.Registration.Poc.Domain.Utils.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IDriverService, DriverService>();
        }
    }
}
