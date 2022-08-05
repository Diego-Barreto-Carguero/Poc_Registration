namespace Carguero.Registration.Poc.Domain.Core.DataTransferObject
{
    public struct Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
