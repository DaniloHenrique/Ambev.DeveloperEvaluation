using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class AbstractService
    {
        protected DbContext Context { get; }

        protected AbstractService(DbContext context)
        {
            Context = context;
        }

        protected async Task Save(CancellationToken cancellationToken=default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
