namespace Carguero.Registration.Poc.Domain.Models.Partners
{
    public record DriverRequest
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
