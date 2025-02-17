using Ambev.DeveloperEvaluation.Domain.Contract;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, ErrorOr<CreateCartResult>>
    {
        private const string ErrorUserNotFoundMessage = "User {0} not found";
        private const string CartItemMustBeAtMaximum20 = "Can't buy more than 20 identical itens";

        readonly IMapper _mapper;
        readonly ICartRepository _cartRepository;
        readonly IUserRepository _userRepository;
        readonly DbContext _context;
        public CreateCartHandler(
            ICartRepository cartRepository, 
            IUserRepository userRepository, 
            IMapper mapper,
            DbContext context
        )
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _context = context;
        }

        private async Task<ErrorOr<User>> GetUserHandler(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id, cancellationToken);

                if (user is not null) return user;

                var message = string.Format(ErrorUserNotFoundMessage, id);

                return Error.NotFound(description: message);
            }
            catch (Exception exception)
            {
                return Error.Failure(description: exception.Message);
            }
        }

        public async Task<ErrorOr<CreateCartResult>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = _mapper.Map<Cart>(request);

                var user = await GetUserHandler(cart.User.Id, cancellationToken);

                if (user.IsError) return user.FirstError;

                var isInvalidCartItem = new InvalidCartItemSpecification();

                if (cart.Items.Any(item=>isInvalidCartItem.IsSatisfiedBy(item))) 
                    return Error.Validation(description:CartItemMustBeAtMaximum20);    

                cart.User = user.Value;

                _context.Set<User>().Attach(cart.User);

                cart = await _cartRepository.CreateAsync(cart, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<CreateCartResult>(cart);
            }
            catch (InvalidOperationException invalidOperationError)
            {
                return Error.Validation(invalidOperationError.Message);
            }
            catch (Exception exception)
            {
                return Error.Failure(description: exception.Message);
            }
        }
    }
}
