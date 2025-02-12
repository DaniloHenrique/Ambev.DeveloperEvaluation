using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    public class GetCartHandler : IRequestHandler<GetCartCommand, GetCartResult?>
    {
        readonly IMapper _mapper;
        readonly ICartRepository _cartRepository;

        public GetCartHandler(IMapper mapper, ICartRepository cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<GetCartResult?> Handle(GetCartCommand request, CancellationToken cancellationToken)
        {
            var cart  = _mapper.Map<Cart>(request);

            var result = await _cartRepository.GetByIdAsync(cart.Id,cancellationToken);

            if (result is null) return null;

            var cartResult = _mapper.Map<GetCartResult>(result);

            return cartResult;
        }
    }
}
