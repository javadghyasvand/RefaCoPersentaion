using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BlogManagement.Domain.Articles.Agg;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EFCore;
using EventManagement.Domain.Event.Agg;
using EventManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_ShopQuery.Contract.Comment;
using My_ShopQuery.Contract.Events;

namespace My_ShopQuery.Query
{
    public class EventsQuery : IEventsQueryModel
    {
        private readonly EventContext _eventContext;
        private readonly CommentContext _commentContext;
        private readonly LanguageContext _languageContext;

        public EventsQuery(EventContext eventContext, CommentContext commentContext, LanguageContext languageContext)
        {
            _eventContext = eventContext;
            _commentContext = commentContext;
            _languageContext = languageContext;
        }

        public List<EventsQueryModel>LatestEvents()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            if (_languageContext != null)
            {
                var language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;

                var events = _eventContext.Events.Where(x => x.LanguageId == language)
                    .Select(x => new EventsQueryModel
                    {
                        Id = x.Id,
                        Slug = x.Slug,
                        Picture = x.Picture,
                        PublishDate = x.CreationDateTime.ToFarsi(),
                        ShortDescription = x.ShortDescription,
                        Title = x.Title,
                    }).AsNoTracking().Take(5).ToList();

                return events;
            }

            return new List<EventsQueryModel>();
        }

        public List<EventsQueryModel> GetAllEvents()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            if (_languageContext != null)
            {
                var language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
                return _eventContext.Events.Where(x => x.LanguageId == language)
                    .Select(x => new EventsQueryModel
                    {
                        Slug = x.Slug,
                        Picture = x.Picture,
                        PublishDate = x.CreationDateTime.ToFarsi(),
                        ShortDescription = x.ShortDescription,
                        Title = x.Title
                    }).AsNoTracking().ToList();
            }

            return new List<EventsQueryModel>();
        }


        EventsQueryModel IEventsQueryModel.GetDetailsBy(string slug)
        {
            var article = _eventContext.Events.Select(x => new EventsQueryModel
            {
                Id = x.Id,
                Slug = x.Slug,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Keywords = x.Keywords,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                MetDescription = x.MetDescription
            }).FirstOrDefault(x => x.Slug == slug);

            var comments = _commentContext.Comments
                .Where(x => x.OwnerId == article.Id && !x.IsCancel && x.IsConfirmed && x.Type == CommentType.Article)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CommentDate = x.CreationDateTime.ToFarsi(),
                    Email = x.Email,
                    Message = x.Message,
                }).ToList();

            foreach (var comment in comments)
            {
                if (comment.ParentId > 0)
                {
                    comment.ParentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;
                }
            }

            if (article != null)
            {
                article.Comments = comments;
             
            }
            return article;
        }
    }
}