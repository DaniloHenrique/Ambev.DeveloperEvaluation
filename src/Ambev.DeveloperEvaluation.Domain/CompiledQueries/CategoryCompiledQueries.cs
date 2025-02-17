using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain.CompiledQueries
{
    public static class CategoryCompiledQueries<TContext> where TContext:DbContext
    {
        public static Func<TContext,string,CancellationToken,Task<Category?>> GetByCategory
        {
            get => EF.CompileQuery(
                (TContext db, string description, CancellationToken cancellationToken) => db
                        .Set<Category>()
                        .FirstOrDefaultAsync(categories => categories.Description == description, cancellationToken)
                );
        }
    }
}
