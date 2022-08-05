using Carguero.Registration.Poc.Domain.Core.Entities;
using Carguero.Registration.Poc.Domain.Entities.Partners;

namespace Carguero.Registration.Poc.Domain.Entities.Addresses
{
    public class Address : BaseEntity
    {
        public string? Logradouro { get; set; } = default;

        public string? Numero { get; set; } = default;

        public string? Complemento { get; set; } = default;

        public string? PontoReferencia { get; set; } = default;

        public int Cep { get; set; }

        public int CodigoMunicipio { get; set; }

        public int CodigoCidade { get; set; }

        public int CodigoPais { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
