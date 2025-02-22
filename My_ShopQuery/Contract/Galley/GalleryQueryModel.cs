using System;

namespace My_ShopQuery.Contract.Galley
{
    public class GalleryQueryModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public long LanguageId { get; set; }
        public DateTime DateTime { get; set; }
    }
}