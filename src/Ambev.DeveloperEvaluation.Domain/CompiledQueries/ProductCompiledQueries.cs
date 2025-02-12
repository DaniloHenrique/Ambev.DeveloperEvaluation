using Ambev.DeveloperEvaluation.Domain.Contexts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain.CompiledQueries
{
    public class ProductCompiledQueries<TContext> where TContext : DbContext,IDefaultContext
    {
        public static Func<TContext, int, IEnumerable<Product>> ListProductByCategoryQuery
        {
            get =>
                EF.CompileQuery(
                    (TContext db, int categoryId) => db
                        .Products
                        .Include(p=>p.Rating)
                        .Where(p => p.Category.Id == categoryId)
                );
        }
    }
}
