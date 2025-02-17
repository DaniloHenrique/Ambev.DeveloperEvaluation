using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Frozen;

namespace Ambev.DeveloperEvaluation.Domain.CompiledQueries
{
    public class ProductCompiledQueries<TContext> where TContext : DbContext
    {
        public static Func<TContext, int, CancellationToken, Task<List<Product>>> ListByCategoryQueryAsync
        {
            get =>
                EF.CompileQuery(
                    (TContext db, int categoryId, CancellationToken cancellationToken) => db
                        .Set<Product>()
                        .Include(p => p.Rating)
                        .Where(p => p.Category.Id == categoryId)
                        .ToListAsync(cancellationToken)  
                );
        }
    }
}
