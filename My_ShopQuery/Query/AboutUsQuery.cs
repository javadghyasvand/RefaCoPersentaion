using System.Collections.Generic;
using BlogManagement.Infrastructure.EFCore;
using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.AboutUs;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace My_ShopQuery.Query
{
    public class AboutUsQuery:IAboutUsQueryModel
    {
        private readonly GeneralContext _generalContext;
        private readonly LanguageContext _langContext;

        public AboutUsQuery(GeneralContext generalContext, LanguageContext langContext)
        {


            _generalContext = generalContext;
            _langContext = langContext;
        }


        public  AboutUsQueryModel AboutUs()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _langContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            return _generalContext.AboutUs.Select(a => new AboutUsQueryModel
                {
                    Title = a.Title,
                    Description = a.Description,
                    ShortDescription = a.ShortDescription,
                    History = a.History,
                    Id = a.Id,
                    LanguageId = a.LanguageId,
                    Poster = a.Poster,
                    Video = a.Video
                }).AsNoTracking().SingleOrDefault(x=>x.LanguageId == language);
        }
    }
}