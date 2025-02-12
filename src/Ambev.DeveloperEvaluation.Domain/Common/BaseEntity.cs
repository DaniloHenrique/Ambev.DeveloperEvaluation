namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public abstract class BaseEntity<Key> where Key: unmanaged
    {
        public Key Id { get;set; }
    }
}
