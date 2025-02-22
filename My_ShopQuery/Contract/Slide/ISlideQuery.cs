using System.Collections.Generic;

namespace My_ShopQuery.Contract.Slide
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlidesList();
    }
}