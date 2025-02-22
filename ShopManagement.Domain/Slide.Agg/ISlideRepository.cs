using System.Collections.Generic;
using My_Shop_Framework.Domain;
using ShopManagement.Application.Contracts.Slide;

namespace ShopManagement.Domain.Slide.Agg
{
    public interface ISlideRepository:IRepository<long,Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> Search(SliderSearchModel model);
    }
}