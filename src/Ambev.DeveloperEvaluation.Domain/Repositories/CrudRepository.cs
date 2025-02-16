using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public abstract class CrudRepository<TContext,TEntity,TKey>
        where TKey : unmanaged
        where TEntity : BaseEntity<TKey>
        where TContext : DbContext
    {
        public string EntityName { get; }

        protected TContext Context { get; }

        protected DbSet<TEntity> EntitySet { get=>Context.Set<TEntity>(); }

        protected CrudRepository(TContext context) { 
            Context = context;
            EntityName = typeof(TEntity).Name;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var entry = await EntitySet.AddAsync(entity, cancellationToken);

                if (entry.State == EntityState.Added) return entity;

                var message = string.Format(
                    DatabaseOperationException.ErrorOnCreateMessage,
                    typeof(TEntity).Name,
                    entity.ToString()
                );

                throw new InvalidInsertedException(message);
            }
            catch (InvalidInsertedException invalidInsertedException)
            {
                InvalidOperationException invalidOperationException = invalidInsertedException;

                throw invalidOperationException;
            }
            catch (Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
        public virtual async Task<Updated> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var entry = await Task.Run(() => EntitySet.Update(entity));

                if (entry.State == EntityState.Modified) return Result.Updated;

                var message = string.Format(
                    DatabaseOperationException.ErrorOnUpdateMessage,
                    typeof(TEntity).Name,
                    entity.Id
                );

                throw new RecordNotFoundException(message);
            }
            catch (RecordNotFoundException recordNotFoundException)
            {
                InvalidOperationException invalidOperationException = recordNotFoundException;

                throw invalidOperationException;
            }
            catch (Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
        public virtual async Task<Deleted> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var entry = await Task.Run(()=>EntitySet.Remove(entity));

                if (entry.State == EntityState.Deleted) return Result.Deleted;

                var message = string.Format(
                    DatabaseOperationException.ErrorOnDeleteMessage,
                    typeof(TEntity).Name,
                    entity.Id
                );

                throw new RecordNotFoundException(message);
            }
            catch (RecordNotFoundException recordNotFoundException)
            {
                InvalidOperationException invalidOperationException = recordNotFoundException;  
                
                throw invalidOperationException;
            }
            catch (Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
        public virtual async Task<TEntity> GetByIdAsync(TKey id,CancellationToken cancellationToken)
        {
            try
            {
                var found = await EntitySet.FirstOrDefaultAsync(predicate => predicate.Id.Equals(id), cancellationToken);

                if (found is not null) return found;

                var message = string.Format(
                    RecordNotFoundException.NotFoundMessage,
                    typeof(TEntity).Name,
                    id
                );

                throw new RecordNotFoundException(message); 
            }
            catch(RecordNotFoundException recordNotFoundException)
            {
                InvalidOperationException invalidOperationException = recordNotFoundException;

                throw invalidOperationException;
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
        public virtual async Task<IList<TEntity>> ListAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await EntitySet.ToListAsync();
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
    }
}
