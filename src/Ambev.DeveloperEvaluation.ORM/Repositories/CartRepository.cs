using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartRepository : CrudRepository<DefaultContext, Cart, int>, ICartRepository
    {
        public CartRepository(DefaultContext context) : base(context)
        {
        }

        protected override DbSet<Cart> GetDbSet => _context.Carts;

        private void DisableState(Cart entity)
        {
            if (entity.User != null)
            {
                _context.Users.Attach(entity.User);
            }
        }

        public override async Task<Cart> CreateAsync(Cart entity, CancellationToken cancellationToken = default)
        {
            DisableState(entity);

            return await base.CreateAsync(entity, cancellationToken);
        }

        public override async Task<Cart> UpdateAsync(Cart entity, CancellationToken cancellationToken = default)
        {
            var threads = entity
                .Items
                .Select(i => _context
                    .CartItems
                    .Where(cart => cart.Id == entity.Id)
                    .ExecuteUpdateAsync(c => c
                        .SetProperty(p=>p.Quantity,i.Quantity)
                        .SetProperty(p=>p.ProductId,i.ProductId)
                    )
                );

            await Task.WhenAll(threads);

            return entity;
        }
    }
}
