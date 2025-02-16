using Ambev.DeveloperEvaluation.Domain.Common;
using ErrorOr;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICrudRepository<Entity, Key>
        where Entity : BaseEntity<Key>
        where Key : unmanaged
    {
        Task<Entity> CreateAsync(Entity entity, CancellationToken cancellationToken = default);
        Task<Updated> UpdateAsync(Entity entity, CancellationToken cancellationToken = default);
        Task<Deleted> RemoveAsync(Entity id, CancellationToken cancellationToken = default);
        Task<Entity> GetByIdAsync(Key id, CancellationToken cancellationToken = default);
        Task<IList<Entity>> ListAsync(CancellationToken cancellationToken = default);
    }
}
