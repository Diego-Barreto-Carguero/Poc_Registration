// <copyright file="DriverResponseSample.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Api.Patterns.Models.V1;
using Swashbuckle.AspNetCore.Filters;

namespace Carguero.Registration.Poc.Api.Patterns.OpenApiSamples.V1
{
    internal record DriverResponseSample : IExamplesProvider<DriverResponse>, IExamplesProvider<List<DriverResponse>>
    {
        public DriverResponse GetExamples() => SeedData().First();

        List<DriverResponse> IExamplesProvider<List<DriverResponse>>.GetExamples() => SeedData();

        private List<DriverResponse> SeedData()
        {
            return new List<DriverResponse>()
            {
                new DriverResponse()
                {
                    Name = "Diego Barreto",
                    Cpf = "3334157412",
                    Rg = "320145540",
                    BirthDate = DateTime.Now
                },
                new DriverResponse()
                {
                    Name = "Cassiano Kuss",
                    Cpf = "365214111022",
                    Rg = "9959111444",
                    BirthDate = DateTime.Now.AddYears(-30)
                },
            };
        }
    }
}
