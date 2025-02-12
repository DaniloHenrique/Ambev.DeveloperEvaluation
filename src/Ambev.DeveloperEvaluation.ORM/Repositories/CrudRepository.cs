using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public abstract class CrudRepository<Context, Entity, Key> : ICrudRepository<Entity, Key>
        where Entity : BaseEntity<Key>
        where Key : unmanaged
        where Context: DbContext
    {
        protected readonly Context _context;

        public CrudRepository(Context context)
        {
            _context = context;
        }

        protected abstract DbSet<Entity> GetDbSet { get; }

        public async virtual Task<Entity> CreateAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            GetDbSet.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
        public async virtual Task<IEnumerable<Entity>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await GetDbSet.ToListAsync(cancellationToken);

        public async Task<bool> RemoveAsync(Key id, CancellationToken cancellationToken = default)=>
            (await GetDbSet.Where(e=>e.Id.Equals(id)).ExecuteDeleteAsync(cancellationToken)) > 0;

        public virtual Task<Entity?> GetByIdAsync(Key id, CancellationToken cancellationToken = default) =>
            GetDbSet.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);

        public abstract Task<Entity> UpdateAsync(Entity entity, CancellationToken cancellationToken = default);
    }
}
