using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.LogoAgg
{
    public class SiteLogo : EntityBase
    {
        public string Title { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Link { get; private set; }
        public long LanguageId { get; private set; }
        public SiteLogo(string title, string picture, string pictureAlt, string pictureTitle, string link, long languageId)
        {
            Title = title;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Link = link;
            LanguageId = languageId;
        }

        public void Edit(string title, string picture, string pictureAlt, string pictureTitle, string link, long languageId)
        {
            Title = title;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Link = link;
            LanguageId = languageId;
        }
    }
}