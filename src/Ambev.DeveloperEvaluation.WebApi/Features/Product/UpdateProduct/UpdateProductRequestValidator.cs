using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct
{
    public class UpdateProductRequestValidator:AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator() 
        {
            RuleFor(product => product.Price)
                .GreaterThan(0)
                .WithMessage("Product Price must be greater than zero");

            RuleFor(product => product.Title)
                .NotEmpty()
                .Length(5, 50)
                .WithMessage("The Product Title must have at least 5 characters and a maximum of 50 characters.");

            RuleFor(product => product.Description)
                .NotEmpty()
                .Length(5, 255)
                .WithMessage("The Product Description must have at least 5 characters and a maximum of 50 characters.");

            RuleFor(product => product.Category)
                .NotEmpty()
                .WithMessage("Product Category must be informed");

            When(product => product.Image is not null, () =>
                RuleFor(product => product.Image)
                    .Matches(@"\bhttps?:\/\/(?:www\.)?[a-zA-Z0-9-]+(?:\.[a-zA-Z]{2,})+(?:\/[^\s]*)?\.(?:jpg|jpeg|png|gif|bmp|webp|svg)\b")
                    .WithMessage("Image must be a valid image url")
            );
        }
    }
}
