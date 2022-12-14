// <copyright file="Tenant.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Core.Entities;

namespace Carguero.Registration.Poc.Domain.Patterns.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string StorageUrl { get; set; }

        public string StorageContainer { get; set; }

        public string Profile { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
