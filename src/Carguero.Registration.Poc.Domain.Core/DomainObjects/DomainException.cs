namespace Carguero.Registration.Poc.Domain.Core.DomainObjects
{
    public class DomainException : Exception
    {
        public DomainException(string message = null)
            : base(message)
        {
        }
    }
}
