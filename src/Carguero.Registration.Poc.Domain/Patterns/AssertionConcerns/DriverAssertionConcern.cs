// <copyright file="DriverAssertionConcern.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Patterns.Entities;

namespace Carguero.Registration.Poc.Domain.Patterns.AssertionConcern
{
    internal static class DriverAssertionConcern
    {
        public static bool ValidateDriverExists(this Driver? driver, INotifier _notifier)
        {
            if (driver is not null)
            {
                _notifier.NotifyHandle($"Cpf {driver.Cpf} linked to the driver {driver.Name} already has an active registration");

                return true;
            }

            return false;
        }
    }
}
