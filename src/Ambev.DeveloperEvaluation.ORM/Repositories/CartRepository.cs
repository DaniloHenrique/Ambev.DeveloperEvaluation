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
            foreach(var item in entity.Items)
            {
                if (item.Id == 0)
                {
                    _context.Products.Attach(item.Product);
                    _context.CartItems.Add(item);
                }
                else
                {
                    _context.CartItems.Update(item);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public override async Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default)=>
            await _context
                .Carts
                .Include(c => c.User)
                .Include(c => c.Items).ThenInclude(i=>i.Product)
                .FirstOrDefaultAsync(cart => cart.Id == id,cancellationToken);
    }
}
