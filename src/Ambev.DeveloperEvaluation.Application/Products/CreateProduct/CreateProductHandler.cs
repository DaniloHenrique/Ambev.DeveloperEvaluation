using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        readonly IMapper _mapper;
        readonly IProductRepository _productRepository;

        public CreateProductHandler(IMapper mapper, IProductRepository productRepository) 
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            var result = await _productRepository.CreateAsync(product,cancellationToken);

            return _mapper.Map<CreateProductResult>(result);
        }
    }
}
