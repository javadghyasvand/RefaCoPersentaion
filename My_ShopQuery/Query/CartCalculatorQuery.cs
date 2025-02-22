using System;
using System.Collections.Generic;
using System.Linq;
using DiscountManagement.Infrastructure.EFCore;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using My_ShopQuery.Contract.CartCalculator;
using ShopManagement.Application.Contracts.Order;

namespace My_ShopQuery.Query
{
    public class CartCalculatorQuery : ICartCalculator
    {
        private readonly DiscountContext _discountContext;
        /*private readonly IAuthHelper _authHelper;*/


        public CartCalculatorQuery( DiscountContext discountContext)
        {
            /*_authHelper = authHelper;*/
            _discountContext = discountContext;
        }

        public Cart ComputeCart(List<CartItem> cartItems)
        {
            var cart = new Cart();
            /*var currentAccountRole = _authHelper.CurrentAccount();*/

            var colleagueDiscounts = _discountContext.ColleagueDiscount.Where(x => !x.IsRemove).Select(x => new
            {
                x.DiscountRate,
                x.ProductId
            }).ToList();

            var customerDiscounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new
                {
                    x.DiscountRate,
                    x.ProductId
                }).ToList();

            /*foreach (var cartItem in cartItems)
            {
                if (currentAccountRole == RolesList.User)
                {
                    var colleagueDiscount = colleagueDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                    if (colleagueDiscount != null)
                        cartItem.DiscountRate = colleagueDiscount.DiscountRate;
                }
                else
                {
                    var customerDiscount = customerDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                    if (customerDiscount != null)
                        cartItem.DiscountRate = customerDiscount.DiscountRate;
                }

                cartItem.DiscountRate = cartItem.DiscountRate;
                cartItem.DiscountAmount = ((cartItem.TotalItemPrice * cartItem.DiscountRate) / 100);
                cartItem.ItemPayAmount = cartItem.TotalItemPrice - cartItem.DiscountAmount;
                cart.Add(cartItem);
            }*/

            return cart;
        }
    }
}