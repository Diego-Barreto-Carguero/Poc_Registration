// <copyright file="IDriverService.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Patterns.Models.V1;

namespace Carguero.Registration.Poc.Domain.Patterns.Contracts.Services
{
    public interface IDriverService
    {
        public Task<IEnumerable<DriverResponse>> GetDriverActiveByTenant(string cpf, int tenantId);

        public Task<DriverResponse> GetDriverActiveByCpf(string cpf);

        public Task RegisterAsync(DriverRequest driverRequest);

        public Task UpdateDriverActiveAsync(string cpf);
    }
}
