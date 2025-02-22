using Microsoft.Extensions.Configuration;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _orderRepository;
        /*private  readonly  IAuthHelper _authHelper;*/
        private readonly IConfiguration _configuration;

        public OrderApplication(IOrderRepository orderRepository/*, IAuthHelper authHelper*/, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            /* _authHelper = authHelper;*/
            _configuration = configuration;
        }

        public long PlaceOrder(Cart cart)
        {
            /*var accountId = _authHelper.CurrentAccountId();*/
            /* var order = new Order(accountId,cart.TotalAmount,cart.DiscountAmount,cart.PayAmount);*/
            /*foreach (var cartItem in cart.ListCartItems)
            {
                var orderItem = new OrderItem(cartItem.Id, cartItem.Count, cartItem.UnitPrice, cartItem.DiscountRate);
                    order.Add(orderItem);
            }

            _orderRepository.Create(order);
            _orderRepository.SaveChanges();
            return order.Id;*/
            return 10;
        }

        public string PaymentSuccess(long orderId, long refId)
        {
            var order = _orderRepository.Get(orderId);
            order.PaymentSuccess(refId);
            var symbol = _configuration.GetSection("Symbol").Value;
            var issueTrackingNo = CodeGenerator.Generate(symbol);
            order.SetIssueTrackingNo(issueTrackingNo);

            _orderRepository.SaveChanges();
            return issueTrackingNo;
        }

        public double GetAmountBy(long id)
        {
            return _orderRepository.GetAmountBy(id);
        }
    }
}