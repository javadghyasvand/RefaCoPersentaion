
using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.Slide;

namespace ServiceHost.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SliderViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slides = _slideQuery.GetSlidesList();
            return View("Slider", slides);
        }
    }
}