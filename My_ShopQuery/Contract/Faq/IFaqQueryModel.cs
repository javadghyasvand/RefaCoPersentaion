using System.Collections.Generic;
using My_ShopQuery.Contract.Events;

namespace My_ShopQuery.Contract.Faq
{
    public interface IFaqQueryModel
    {
        List<FaqQueryModel> GetAll();
    }
}