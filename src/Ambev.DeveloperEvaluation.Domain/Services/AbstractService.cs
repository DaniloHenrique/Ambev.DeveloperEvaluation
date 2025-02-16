using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class AbstractService<TContext>
        where TContext : DbContext
    {
        protected TContext Context { get; }

        protected AbstractService(TContext context)
        {
            Context = context;
        }

        protected async Task Save(CancellationToken cancellationToken=default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
