// <copyright file="DriverAssertionConcern.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Patterns.Entities;

namespace Carguero.Registration.Poc.Domain.Patterns.AssertionConcern
{
    internal static class DriverAssertionConcern
    {
        public static bool AssertDriverIsNotNull(this Driver? driver, INotifier notifier)
        {
            if (driver is not null)
            {
                notifier.NotifyHandle($"Cpf {driver.Cpf} linked to the driver {driver.Name} already has an active registration");

                return true;
            }

            return false;
        }

        public static bool AssertDriverNull(this Driver driver, INotifier notifier)
        {
            if (driver is null)
            {
                notifier.NotifyHandle($"Driver not found");
                return true;
            }

            return false;
        }
    }
}
