using System.Collections.Generic;
using InventoryManagement.Infrastructure.EfCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Infrastructure.EFCore;

namespace My_ShopQuery.Contract.CartCalculator
{
    public interface ICartCalculator
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }
}