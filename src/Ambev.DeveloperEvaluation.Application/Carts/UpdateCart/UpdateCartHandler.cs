using Ambev.DeveloperEvaluation.ChainOfResponsibility.Chain;
using Ambev.DeveloperEvaluation.Domain.ChainOfResponsibility;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, ErrorOr<Updated>>
    {
        private const string ErrorCartNotFoundMessage = "Cart {0} not found";
        private const string ErrorUserNotMatchMessage = "User informed not matches cart user";

        readonly IMapper _mapper;
        readonly ICartRepository _cartRepository;
        readonly ICartItemRepository _cartItemRepository;
        readonly DbContext _context;
        public UpdateCartHandler(
            ICartRepository cartRepository, 
            ICartItemRepository cartItemRepository, 
            IMapper mapper,
            DbContext context
        )
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _context = context;
        }
        public async Task<ErrorOr<Updated>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = _mapper.Map<Cart>(request);

                var previousCart = await _cartRepository.GetByIdAsync(cart.Id, cancellationToken);

                if (previousCart is null) return Error.NotFound(
                    string.Format(ErrorCartNotFoundMessage, cart.Id)
                );

                if (previousCart.User.Id != cart.UserId) return Error.Validation(ErrorUserNotMatchMessage);

                var createListState = new ToCreateListState<CartItem>(previousCart.Items, cart.Items);
                var commandState = new CartItemsChain(createListState).Run();

                if (commandState is null) return Result.Updated;

                await _cartItemRepository.CreateRangeAsync(commandState.ToCreate,cancellationToken);
                _cartItemRepository.UpdateRange(commandState.ToUpdate);
                _cartItemRepository.RemoveRange(commandState.ToRemove);

                await _context.SaveChangesAsync(cancellationToken);

                return Result.Updated;
            }
            catch (DatabaseOperationException databaseOperationException)
            {
                return Error.Failure(databaseOperationException.Message);
            }
            catch (Exception exception)
            {
                return Error.Unexpected(exception.Message);
            }

        }
    }
}
