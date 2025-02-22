using System.Globalization;
using System.Linq;
using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.SiteLogo;

namespace My_ShopQuery.Query
{
    public class SiteLogoQuery:ISiteLogoQueryModel
    {
        private readonly GeneralContext _context;
        private readonly LanguageContext _languageContext;
        public SiteLogoQuery(GeneralContext context, LanguageContext languageContext)
        {
            _context = context;
            _languageContext = languageContext;
        }

        public SiteLogoQueryModel GetLogo()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            long language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var  logo =_context.SiteLogos.AsNoTracking().FirstOrDefault(x=>x.LanguageId== language);

            if (logo != null)
            {
                var logoQuery = new SiteLogoQueryModel()
                {
                    Title = logo.Title,
                    Picture = logo.Picture,
                    PictureTitle = logo.PictureTitle,
                    Link = logo.Link,
                    Id = logo.Id,
                    PictureAlt = logo.PictureAlt,
                };
                return logoQuery;
            }

            return new SiteLogoQueryModel();
        }
    }
}
