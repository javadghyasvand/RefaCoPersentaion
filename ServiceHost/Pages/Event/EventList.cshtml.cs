using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Events;

namespace ServiceHost.Pages.Event
{
    public class EventModel : PageModel
    {
        public List<EventsQueryModel> Events { get; set; }
        private readonly IEventsQueryModel _articleQuery;

        public EventModel(IEventsQueryModel articleQuery)
        {
            _articleQuery = articleQuery;
        }


        public void OnGet(string id)
        {
            Events = _articleQuery.GetAllEvents();
        }
    }
}
