using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

        public async virtual Task<bool> RemoveAsync(Key id, CancellationToken cancellationToken = default)
        {
            var e = await GetByIdAsync(id, cancellationToken);

            if (e is null) return false;

            GetDbSet.Remove(e);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public virtual Task<Entity?> GetByIdAsync(Key id, CancellationToken cancellationToken = default) =>
            GetDbSet.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);

        public async virtual Task<Entity> UpdateAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            GetDbSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
