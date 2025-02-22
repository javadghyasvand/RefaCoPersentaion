using My_Shop_Framework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class OrderItem:EntityBase
    {
        public long ProductId { get; private set; }
        public long Count { get; private set; }
        public double UnitPrice { get; private set; }
        public int DiscountRate { get; private set; }
        public long OrderId { get; private set; }
        public Order Order { get; private set; }

        public OrderItem(long productId, long count, double unitPrice, int discountRate)
        {
            ProductId = productId;
            Count = count;
            UnitPrice = unitPrice;
            DiscountRate = discountRate;
        }
    }
}