namespace Carguero.Registration.Poc.Domain.Models.Partners
{
    public record DriverResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime BirthDate { get; set; }
        public string? MyProperty { get; set; }
    }
}
