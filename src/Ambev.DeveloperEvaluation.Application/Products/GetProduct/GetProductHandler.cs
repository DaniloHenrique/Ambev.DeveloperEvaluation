using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, GetProductResult?>
    {
        readonly IMapper _mapper;
        readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetProductResult?> Handle(GetProductCommand request, CancellationToken cancellationToken) =>
            _mapper.Map<GetProductResult?>(await _productRepository.Get(request.Id,cancellationToken));
    }
}
