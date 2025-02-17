using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
    {
        readonly IMapper _mapper;
        readonly ICartRepository _cartRepository;

        public UpdateCartHandler(IMapper mapper, ICartRepository cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }
        public async Task<UpdateCartResult> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = _mapper.Map<Cart>(request);

            var updated = await _cartRepository.UpdateAsync(cart);

            return new UpdateCartResult
            {
                Success = (updated is not null)
            };

        }
    }
}
