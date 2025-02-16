namespace Ambev.DeveloperEvaluation.Domain.Exceptions
{
    public class InvalidInsertedException:DatabaseOperationException
    {
        public InvalidInsertedException() { }
        public InvalidInsertedException(string message) : base(message) { }
    }
}
