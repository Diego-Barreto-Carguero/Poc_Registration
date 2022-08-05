using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Core.DomainObjects;
using Carguero.Registration.Poc.Domain.Core.Entities;
using Carguero.Registration.Poc.Domain.Entities.Addresses;
using Carguero.Registration.Poc.Domain.Entities.Contacts;
using Carguero.Registration.Poc.Domain.Entities.Vehicles;

namespace Carguero.Registration.Poc.Domain.Entities.Partners
{
    public class Driver : BaseEntity, IAggregationRoot
    {
        public Driver(int id, string name, string cpf, string rg, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Rg = rg;
            BirthDate = birthDate;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public virtual IEnumerable<Tenant> Tenant { get; set; }

        public void ValidateMinimumAgeDriver()
        {
            if (BirthDate.Subtract(DateTime.Today).Days >= 10)
            {
                throw new DomainException("Driver has no minimum age recommended");
            }
        }
    }
}
