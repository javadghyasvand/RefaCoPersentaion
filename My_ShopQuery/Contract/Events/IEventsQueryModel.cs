using System.Collections.Generic;
using My_ShopQuery.Contract.Article;

namespace My_ShopQuery.Contract.Events
{
    public interface IEventsQueryModel
    {
        List<EventsQueryModel> LatestEvents();
        List<EventsQueryModel> GetAllEvents();
        EventsQueryModel GetDetailsBy(string slug);
    }
}