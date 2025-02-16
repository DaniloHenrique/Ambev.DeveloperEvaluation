using Ambev.DeveloperEvaluation.Domain.Contexts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain.CompiledQueries
{
    public static class CategoryCompiledQueries<TContext> where TContext:DbContext, IDefaultContext
    {
        public static Func<TContext,string,CancellationToken,Task<Category?>> GetByCategory
        {
            get => EF.CompileQuery(
                (TContext db, string description, CancellationToken cancellationToken) => db
                        .Categories
                        .FirstOrDefaultAsync(categories => categories.Description == description, cancellationToken)
                );
        }
    }
}
