using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Database repository that handles operations over <see cref="Cart"/> entity
    /// </summary>
    public class CartRepository : CrudRepository<DefaultContext, Cart, int>, ICartRepository
    {
        /// <summary>
        /// Creates instance of <see cref="CartRepository"/>
        /// </summary>
        /// <param name="context">Default Context of database</param>
        public CartRepository(DefaultContext context) : base(context)
        {
        }

        public override Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken=default)=>
            Context.Cart
                .Include(c=>c.User)
                .Include(c => c.Items)
                .ThenInclude(p=>p.Product)
                .FirstOrDefaultAsync(c=> c.Id == id);   

        public override async Task<IEnumerable<Cart>> ListAsync(CancellationToken cancellationToken=default) =>
            await Context.Cart
                .Include(c=>c.Items)
                .ToListAsync(cancellationToken);
    }
}
