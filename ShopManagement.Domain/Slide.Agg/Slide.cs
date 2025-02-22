using Microsoft.VisualBasic;
using My_Shop_Framework.Domain;

namespace ShopManagement.Domain.Slide.Agg
{
    public class Slide : EntityBase
    {
        public string Heading { get; private set; }
        public string BtnText { get; private set; }
        public string Text { get; private set; }
        public bool IsRemoved { get; private set; }
        public string Link { get; private set; }
        public long LanguageId { get; private set; }
        //public DateAndTime StartDate { get; private set; }
        //public DateAndTime EndDate { get; private set; }
        public Slide(string heading, string btnText, string link, long languageId, string text)
        {
            Heading = heading;
            BtnText = btnText;
            Link = link;
            LanguageId = languageId;
            Text = text;
            IsRemoved = false;
        }

        public void Edit( string heading,
            string text, string btnText,string link, long languageId)
        {
            Text = text;
            Heading = heading;
            BtnText = btnText;
            Link = link;
            LanguageId = languageId;
        }

        public void IsRemove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}