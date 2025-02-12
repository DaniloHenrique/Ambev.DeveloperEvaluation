using FluentValidation;
using System.Runtime.InteropServices;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(product => product.Price)
                .GreaterThan(0)
                .WithMessage("Product Price must be greater than zero");

            RuleFor(product => product.Title)
                .NotEmpty()
                .Length(5,50)
                .WithMessage("The Product Title must have at least 5 characters and a maximum of 50 characters.");

            RuleFor(product => product.Description)
                .NotEmpty()
                .Length(5,255)
                .WithMessage("The Product Description must have at least 5 characters and a maximum of 50 characters.");

            RuleFor(product => product.Category)
                .NotEmpty()
                .WithMessage("Product Category must be informed");
        }
    }
}
