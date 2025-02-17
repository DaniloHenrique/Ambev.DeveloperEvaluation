using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ErrorOr<CreateProductResult>>
    {
        readonly IMapper _mapper;
        readonly IProductRepository _productRepository;
        readonly ICategoryRepository _categoryRepository;
        readonly DbContext _context;
        public CreateProductHandler(
            IMapper mapper, 
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository,
            DbContext context
        ) 
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _context = context;
        }

        private async Task<Category> HandleCategory(string description, CancellationToken cancellationToken=default)
        {
            var category = await _categoryRepository.GetByDescriptionAsync(description, cancellationToken);

            if (category is not null)
            {
                _context.Set<Category>().Attach(category);

                return category;
            }

            category = new Category(description);

            await _categoryRepository.CreateAsync(category, cancellationToken);

            return category;
        }
        public async Task<ErrorOr<CreateProductResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken=default)
        {
            try
            {
                var validator = new CreateProductValidator();

                var validatorResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validatorResult.IsValid) throw new ValidationException(validatorResult.Errors);

                var product = _mapper.Map<Product>(request);

                product.Category = await HandleCategory(request.Category, cancellationToken);

                await _productRepository.CreateAsync(product, cancellationToken);

                await _context.SaveChangesAsync();

                return _mapper.Map<CreateProductResult>(product);
            }
            catch (InvalidOperationException invalidOperationError)
            {
                return Error.Validation(invalidOperationError.Message);
            }
            catch (DatabaseOperationException databaseOperationError)
            {
                return Error.Failure(databaseOperationError.Message);
            }
            catch (Exception error)
            {
                return Error.Unexpected(error.Message);
            }
        }
    }
}
