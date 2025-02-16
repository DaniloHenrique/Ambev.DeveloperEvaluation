namespace Ambev.DeveloperEvaluation.Domain.Exceptions
{
    public class DatabaseOperationException:InvalidOperationException
    {
        public static string ErrorOnCreateMessage { get => "Invalid data to create {0}: {1}"; }
        public static string ErrorOnUpdateMessage { get => "{0}.Id: {1} not found"; }
        public static string ErrorOnDeleteMessage { get => "{0}.Id: {1} not found"; }

        public DatabaseOperationException():base(){}
        public DatabaseOperationException(string message):base(message) { }
    }
}
