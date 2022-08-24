// <copyright file="ServiceExtensions.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Patterns.Contracts.Repositories;
using Carguero.Registration.Poc.Infrastructure.Data.Repositories.Partners;
using Microsoft.Extensions.DependencyInjection;

namespace Carguero.Registration.Poc.Infrastructure.Data.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IDriverRepository, DriverRepository>();
        }
    }
}
