using Carguero.Registration.Poc.Domain.Entities.Partners;

namespace Carguero.Registration.Poc.Domain.Entities.Contacts
{
    public class Contact
    {
        public string? Email { get; set; } = default;

        public virtual Driver Driver { get; set; }
    }
}
