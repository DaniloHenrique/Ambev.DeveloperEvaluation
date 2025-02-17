using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using ErrorOr;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct
{
    public class ListProductHandler : IRequestHandler<ListProductQuery, ErrorOr<List<ListProductResult>>>
    {
        private const string CategoryNotFoundMessage = "Category {0} not found";

        readonly IMapper _mapper;
        readonly IProductRepository _productRepository;
        readonly ICategoryRepository _categoryRepository;

        public ListProductHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _productRepository = productRepository; 
            _categoryRepository = categoryRepository;  
        }

        private async Task<ErrorOr<List<ListProductResult>>> ListByCategoryHandle(string category, CancellationToken cancellationToken=default)
        {
            var found = await _categoryRepository.GetByDescriptionAsync(category,cancellationToken);

            if (found is null) return Error.NotFound(string.Format(CategoryNotFoundMessage, category));

            var products = await _productRepository.ListByCategoryAsync(found.Id,cancellationToken);

            return products
                .Select(p => _mapper.Map<ListProductResult>(p))
                .ToList();
        }
        public async Task<ErrorOr<List<ListProductResult>>> Handle(ListProductQuery request, CancellationToken cancellationToken=default)
        {
            try
            {
                var category = request.Category;

                if (category is null)
                {
                    var list = await _productRepository.ListAsync(cancellationToken);

                    return list
                        .Select(p=>_mapper.Map<ListProductResult>(p))
                        .ToList();   
                }

                return await ListByCategoryHandle(category, cancellationToken);
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
