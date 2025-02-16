using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

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
    }
}
