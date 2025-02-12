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

        public override Task<Cart> CreateAsync(Cart entity, CancellationToken cancellationToken = default)
        {
            _context.CartItems.AddRange(entity.Items);

            return base.CreateAsync(entity, cancellationToken);
        }
    }
}
