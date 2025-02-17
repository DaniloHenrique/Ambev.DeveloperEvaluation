using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ErrorOr<Updated>>
    {
        readonly IMapper _mapper;
        readonly IProductRepository _productRepository;
        readonly ICategoryRepository _categoryRepository;
        readonly DbContext _context;

        public UpdateProductHandler(
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


        private async Task<Category> HandleCategory(string description, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.GetByDescriptionAsync(description, cancellationToken);

            if (category is not null)
            {
                category.Description = description;

                _context.Set<Category>().Attach(category);

                return category;
            }

            category = new Category(description);

            await _categoryRepository.CreateAsync(category, cancellationToken);

            return category;
        }
        public async Task<ErrorOr<Updated>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new UpdateProductValidator();

                var validatorResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validatorResult.IsValid) throw new ValidationException(validatorResult.Errors);


                var product = _mapper.Map<Product>(request);

                product.Category = await HandleCategory(request.Category, cancellationToken);


                var updated = await _productRepository.UpdateAsync(product, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);


                return updated;
            }
            catch(ValidationException validationException)
            {
                return Error.Validation(description:validationException.Message);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                return Error.Validation(description: invalidOperationException.Message);
            }
            catch (Exception error)
            {
                return Error.Unexpected(description:error.Message);
            }
        }
    }
}
