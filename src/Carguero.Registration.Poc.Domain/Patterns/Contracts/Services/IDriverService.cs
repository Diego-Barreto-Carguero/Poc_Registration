// <copyright file="IDriverService.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Patterns.Entities;

namespace Carguero.Registration.Poc.Domain.Patterns.Contracts.Services
{
    public interface IDriverService
    {
        public Task<IEnumerable<Driver>> GetDriverActiveByTenant(string cpf, int tenantId);

        public Task<Driver> GetDriverActiveByCpf(string cpf);

        public Task RegisterAsync(Driver driver);

        public Task UpdateDriverActiveAsync(string cpf);
    }
}
