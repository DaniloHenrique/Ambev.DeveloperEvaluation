using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using ErrorOr;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ErrorOr<GetProductResult>>
    {
        private const string ProductNotFoundMessage = "Product {0} not found";

        readonly IMapper _mapper;
        readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<GetProductResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

                if (product is null) return Error.NotFound(string.Format(ProductNotFoundMessage, request.Id);

                return _mapper.Map<GetProductResult>(product);
            }
            catch (DatabaseOperationException databaseOperationError)
            {
                return Error.Failure(description: databaseOperationError.Message);
            }
            catch (Exception error)
            {
                return Error.Unexpected(description: error.Message);
            }
        }
    }
}
