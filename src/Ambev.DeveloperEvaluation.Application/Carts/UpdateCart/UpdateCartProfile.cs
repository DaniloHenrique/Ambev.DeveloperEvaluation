﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartProfile:Profile
    {
        public UpdateCartProfile()
        {
            CreateMap<UpdateCartItemCommand, CartItem>();
            CreateMap<UpdateCartCommand, Cart>();
        }
    }
}
