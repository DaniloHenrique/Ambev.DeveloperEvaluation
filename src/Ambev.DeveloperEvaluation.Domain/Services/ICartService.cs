using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using ErrorOr;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface ICartService
    {
        ICartItemRepository CartItemRepository { get; }
        ICartRepository CartRepository { get; }

        Task<ErrorOr<Cart>> CreateCart(Cart cart,CancellationToken cancellationToken);
        Task<ErrorOr<Updated>> UpdateCart(Cart cart,CancellationToken cancellationToken);
        Task<ErrorOr<Deleted>> DeleteCart(Cart cart,CancellationToken cancellationToken);
        Task<ErrorOr<Cart>> GetById(int id, CancellationToken cancellationToken);
    }
}
