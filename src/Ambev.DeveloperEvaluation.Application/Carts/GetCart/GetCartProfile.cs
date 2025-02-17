﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    public class GetCartProfile:Profile
    {
        public GetCartProfile()
        {
            CreateMap<GetCartQuery, Cart>();
            CreateMap<Cart, GetCartResult>(); 
        }
    }
}
