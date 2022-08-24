// <copyright file="ServiceExtensions.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Patterns.Contracts.Services;
using Carguero.Registration.Poc.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Carguero.Registration.Poc.Domain.Patterns.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPatternService(this IServiceCollection services)
        {
            services.AddScoped<IDriverService, DriverService>();
        }
    }
}
