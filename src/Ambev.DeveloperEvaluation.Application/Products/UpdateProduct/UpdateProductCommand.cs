﻿using Ambev.DeveloperEvaluation.Domain.Contract;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductCommand : IProduct, IRequest<UpdateProductResult>
    {
        public string Title { get; set; } = string.Empty;
        public double Price { get ; set; }
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
