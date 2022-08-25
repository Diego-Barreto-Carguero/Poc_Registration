// <copyright file="BaseEntity.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

namespace Carguero.Registration.Poc.Domain.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
    }
}
