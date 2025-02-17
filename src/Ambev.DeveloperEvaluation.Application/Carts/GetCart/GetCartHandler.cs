using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using ErrorOr;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    public class GetCartHandler : IRequestHandler<GetCartQuery, ErrorOr<GetCartResult>>
    {
        private const string ErrorCartNotFoundMessage = "Cart {0} not found";

        readonly IMapper _mapper;
        readonly ICartRepository _cartRepository;

        public GetCartHandler(IMapper mapper, ICartRepository cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<ErrorOr<GetCartResult>> Handle(GetCartQuery request, CancellationToken cancellationToken=default)
        { 
            try
            {
                var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);

                if (cart is null) return Error.NotFound(description: string.Format(ErrorCartNotFoundMessage, request.Id));

                return _mapper.Map<GetCartResult>(cart);
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
