using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Comment;
using My_ShopQuery.Contract.Events;
using My_ShopQuery.Contract.SocialMedia;

namespace ServiceHost.Pages.Event
{
    public class EventDetailsModel : PageModel
    {

        public EventsQueryModel EventQueryModel;
        public List<EventsQueryModel> EventQueryModelList;
        public List<SocialMediaQueryModel> SocialMediaQueryModels;
        private readonly IEventsQueryModel _eventQueryModel;
        private readonly ISocialMediaQueryModel _socialMediaQueryModel;

        public EventDetailsModel(IEventsQueryModel eventQueryModel, ISocialMediaQueryModel socialMediaQueryModel)
        {
            _eventQueryModel = eventQueryModel;
            _socialMediaQueryModel = socialMediaQueryModel;
        }

        public void OnGet(string id)
        {
            EventQueryModel = _eventQueryModel.GetDetailsBy(id);
            EventQueryModelList = _eventQueryModel.LatestEvents();
            SocialMediaQueryModels = _socialMediaQueryModel.SocialMediaList();
        }
    }

}
