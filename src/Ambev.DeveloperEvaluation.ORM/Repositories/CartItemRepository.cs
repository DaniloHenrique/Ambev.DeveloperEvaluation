using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using ErrorOr;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Database repository that handles operations over <see cref="CartItem"/> entity
    /// </summary>
    public class CartItemRepository : ICartItemRepository
    {
        DefaultContext Context { get; }
        /// <summary>
        /// Creates an instance of <see cref="CartItemRepository"/>
        /// </summary>
        /// <param name="context">Default Context of database</param>
        public CartItemRepository(DefaultContext context) 
        {
            Context = context;
        }
        /// <summary>
        /// Creates a set of <see cref="CartItem"/> records in database
        /// </summary>
        /// <param name="items">Set of <see cref="CartItem"/></param>
        /// <returns><see cref="Created"/></returns>
        /// <exception cref="DatabaseOperationException">Exception against database operation</exception>
        public async Task<Created> CreateRangeAsync(IEnumerable<CartItem> items, CancellationToken cancellationToken=default)
        {
            try
            {
                await Context.AddRangeAsync(items,cancellationToken);

                return Result.Created;
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
        /// <summary>
        /// Removes a set of <see cref="CartItem"/> records in database
        /// </summary>
        /// <param name="items">Set of <see cref="CartItem"/></param>
        /// <returns><see cref="Deleted"/></returns>
        /// <exception cref="DatabaseOperationException">Exception against database operation</exception>
        public Deleted RemoveRange(IEnumerable<CartItem> items)
        {
            try
            {
                Context.RemoveRange(items);

                return Result.Deleted;
            }
            catch (Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
        /// <summary>
        /// Update a set of <see cref="CartItem"/> records in database
        /// </summary>
        /// <param name="items">Set of <see cref="CartItem"/></param>
        /// <returns><see cref="Updated"/></returns>
        /// <exception cref="DatabaseOperationException">Exception against database operation</exception>
        public Updated UpdateRange(IEnumerable<CartItem> items)
        {
            try
            {
                Context.UpdateRange(items); 

                return Result.Updated;
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
    }
}
