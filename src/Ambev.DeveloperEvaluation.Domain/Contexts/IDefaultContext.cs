using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain.Contexts
{
    public interface IDefaultContext
    {
        DbSet<User> Users { get; }
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
        DbSet<Cart> Carts { get; }
        DbSet<CartItem> CartItems { get; }
    }
}
