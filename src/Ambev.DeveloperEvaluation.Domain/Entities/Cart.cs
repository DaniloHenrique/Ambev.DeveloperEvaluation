﻿using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : BaseIdentityEntity
    {
        public Cart() 
        {
            Date = DateTime.UtcNow;
        }

        public DateTime Date { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public User User { get; set; } = null!;
        public Guid UserId { get; set; }

        public Sale? Sale { get; set; }
    }
}
