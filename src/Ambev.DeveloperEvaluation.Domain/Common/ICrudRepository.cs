using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public interface ICrudRepository<Entity, Key>
        where Entity : BaseEntity<Key>
        where Key : unmanaged
    {
        Task<Entity> CreateAsync(Entity entity, CancellationToken cancellationToken = default);
        Task<Entity> UpdateAsync(Entity entity, CancellationToken cancellationToken = default);
        Task<Entity?> GetByIdAsync(Key id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Entity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<bool> RemoveAsync(Key id, CancellationToken cancellationToken = default);
    }
}
