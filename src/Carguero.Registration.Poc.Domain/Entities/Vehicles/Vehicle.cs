using Carguero.Registration.Poc.Domain.Core.Entities;
using Carguero.Registration.Poc.Domain.Entities.Partners;

namespace Carguero.Registration.Poc.Domain.Entities.Vehicles
{
    public class Vehicle : BaseEntity
    {
        public string? Plate { get; set; } = default;

        public virtual Driver Driver { get; set; }
    }
}
