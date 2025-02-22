using My_Shop_Framework.Domain;
using System.Reflection;

namespace GeneralManagement.Domain.SocialMediaAgg
{
    public class SocialMedia : EntityBase
    {
        public string Title { get; private set; }
        public string Icon { get; private set; }
        public string Link { get; private set; }

        public SocialMedia(string title, string icon, string link)
        {
            Title = title;
            Icon = icon;
            Link = link;
        }

        public void Edit(string title, string icon, string link)
        {
            Title = title;
            if (!string.IsNullOrWhiteSpace(icon))
                Icon = icon;
            Link = link;
        }
    }
}