// <copyright file="DriverRequestSample.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Api.Patterns.Models.V1;
using Swashbuckle.AspNetCore.Filters;

namespace Carguero.Registration.Poc.Api.Patterns.OpenApiSamples.V1
{
    internal record DriverRequestSample : IExamplesProvider<DriverRequest>
    {
        public DriverRequest GetExamples()
        {
            return new DriverRequest
            {
                Name = "Diego Barreto",
                Cpf = "3334157412",
                Rg = "320145540",
                BirthDate = DateTime.Now
            };
        }
    }
}
