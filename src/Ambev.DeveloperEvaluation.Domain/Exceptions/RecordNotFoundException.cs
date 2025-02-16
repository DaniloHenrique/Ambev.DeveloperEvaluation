namespace Ambev.DeveloperEvaluation.Domain.Exceptions
{
    public class RecordNotFoundException : DatabaseOperationException
    {
        public static string NotFoundMessage { get => "{0}.Id = {1} not found"; }
        public RecordNotFoundException() { }
        public RecordNotFoundException(string message) : base(message) { }
    }
}
