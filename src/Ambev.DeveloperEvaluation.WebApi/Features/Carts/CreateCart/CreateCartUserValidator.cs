using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartUserValidator:AbstractValidator<UserRequest>
    {
        public CreateCartUserValidator() 
        {
            RuleFor(c=>c.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("No user id found");
        }
    }
}
