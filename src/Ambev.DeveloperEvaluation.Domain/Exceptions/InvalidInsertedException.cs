namespace Ambev.DeveloperEvaluation.Domain.Exceptions
{
    public class InvalidInsertedException:InvalidOperationException
    {
        public InvalidInsertedException() { }
        public InvalidInsertedException(string message) : base(message) { }
    }
}
