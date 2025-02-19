﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using ErrorOr;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartItemRepository
    {
        Task<Created> CreateRangeAsync(IEnumerable<CartItem> items, CancellationToken cancellationToken=default);
        Deleted RemoveRange(IEnumerable<CartItem> items);
        Updated UpdateRange(IEnumerable<CartItem> items);
    }
}
