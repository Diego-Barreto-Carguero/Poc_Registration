// <copyright file="DriverResponse.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

namespace Carguero.Registration.Poc.Api.Patterns.Models.V1
{
    public record DriverResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
