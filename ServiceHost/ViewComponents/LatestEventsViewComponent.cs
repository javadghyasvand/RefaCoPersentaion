
using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Events;
using My_ShopQuery.Contract.Product;


namespace ServiceHost.ViewComponents
{
    public class LatestEventsViewComponent: ViewComponent
    {
        private readonly IEventsQueryModel _eventsQueryModel;

        public LatestEventsViewComponent(IEventsQueryModel eventsQueryModel)
        {
            _eventsQueryModel = eventsQueryModel;
        }


        public IViewComponentResult Invoke()
        {
            var events = _eventsQueryModel.LatestEvents();
            return View("LatestEvents", events);
        }
    }
}