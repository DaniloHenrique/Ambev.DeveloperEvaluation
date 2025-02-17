namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public abstract class BaseEntity<TKey> where TKey: unmanaged
    {
        public TKey Id { get;set; }
    }
}
