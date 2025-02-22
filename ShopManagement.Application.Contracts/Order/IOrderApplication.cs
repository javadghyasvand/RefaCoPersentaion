namespace ShopManagement.Application.Contracts.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart  cart);
        string PaymentSuccess(long orderId,long refId);
        double GetAmountBy(long id);
    }
}