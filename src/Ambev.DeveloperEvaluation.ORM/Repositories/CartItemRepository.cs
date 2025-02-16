using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using ErrorOr;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        DefaultContext Context { get; }

        public CartItemRepository(DefaultContext context) 
        {
            Context = context;
        }

        public async Task<Created> CreateRangeAsync(IEnumerable<CartItem> items)
        {
            try
            {
                await Context.AddRangeAsync(items);

                return Result.Created;
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }

        public Deleted RemoveRange(IEnumerable<CartItem> items)
        {
            try
            {
                Context.RemoveRange(items);

                return Result.Deleted;
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }

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
