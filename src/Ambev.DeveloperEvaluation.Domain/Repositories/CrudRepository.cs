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

        /// <summary>
        /// Creates <see cref="TEntity"/> record in database
        /// </summary>
        /// <param name="entity"><see cref="TEntity"/> to be inserted</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns><see cref="TEntity"/> inserted</returns>
        /// <exception cref="DatabaseOperationException">Error against a database operation</exception>
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
        /// <summary>
        /// Updates <see cref="TEntity"/> record in database
        /// </summary>
        /// <param name="entity"><see cref="TEntity"/> to be updated</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns><see cref="TEntity"/> updated</returns>
        /// <exception cref="DatabaseOperationException">Error against a database operation</exception>
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
        /// <summary>
        /// Removes <see cref="TEntity"/> record in database
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Updated"/></returns>
        /// <exception cref="DatabaseOperationException">Error against a database operation</exception>
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
        /// <summary>
        /// Retrieves <see cref="TEntity"/> by its identification in database
        /// </summary>
        /// <param name="id">Database identification</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns><see cref="TEntity"/> or null if it not exists</returns>
        /// <exception cref="DatabaseOperationException">Error against a database operation</exception>
        public virtual async Task<TEntity?> GetByIdAsync(TKey id,CancellationToken cancellationToken)
        {
            try
            {
                return await EntitySet.FirstOrDefaultAsync(predicate => predicate.Id.Equals(id), cancellationToken);
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
        /// <summary>
        /// Retrieves all <see cref="TEntity"/> records in database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of <see cref="TEntity"/></returns>
        /// <exception cref="DatabaseOperationException">Error against a database operation</exception>
        public virtual async Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await EntitySet.ToArrayAsync(cancellationToken);
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
    }
}
