using System;
using System.Collections.Generic;
using My_ShopQuery.Contract.Comment;

namespace My_ShopQuery.Contract.Events
{
    public class EventsQueryModel
    {
        public  long Id { get; set; }
        public string Title { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Slug { get;  set; }
        public string MetDescription { get;  set; }
        public string Keywords { get;  set; }
        public string CanonicalAddress { get;  set; }
        public long LanguageId { get;  set; }
        public string PublishDate { get;  set; }

        public List<CommentQueryModel> Comments { get; set; }
    }
}