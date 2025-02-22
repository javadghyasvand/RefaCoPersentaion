using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Application.Contracts.Order
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PaymentMethod(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static List<PaymentMethod> GetList()
        {
            return new List<PaymentMethod>
            {
                new PaymentMethod(1, "پرداخت اینترنتی", "شما به درگاه اینترنتی  هدایت شده و مبل را واریز می نمایید"),
                new PaymentMethod(2, "پرداخت نقدی", "شماره کارت برای شما ارسال شده"),
            };
        }

        public static PaymentMethod GetBy(int id)
        {
            return GetList().FirstOrDefault(x => x.Id == id);
        }
    }
}