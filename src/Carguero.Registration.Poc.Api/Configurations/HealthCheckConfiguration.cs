using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;


namespace Carguero.Registration.Poc.Api.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static void AddConfigureHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(5);
                options.MaximumHistoryEntriesPerEndpoint(10);
                options.AddHealthCheckEndpoint("Registrtion API Health Checks", "/health");
            }).AddInMemoryStorage();
        }

        public static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = p => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/dashboard";
                options.AddCustomStylesheet("./custom.css");
            });
        }
    }
}
