using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public class Cart
    {
        public List<CartItem> ListCartItems { get; set; }
        public double  TotalAmount { get; set; }
        public double  DiscountAmount { get; set; }
        public double  PayAmount { get; set; }

        public Cart()
        {
            ListCartItems =new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            ListCartItems.Add(cartItem);
            TotalAmount += cartItem.TotalItemPrice;
            DiscountAmount += cartItem.DiscountAmount;
            PayAmount += cartItem.ItemPayAmount;
        }
    }
}