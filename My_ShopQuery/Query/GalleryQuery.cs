using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.Galley;

namespace My_ShopQuery.Query
{
    public class GalleryQuery:IGalleryQueryModel
    {
        private  readonly  GeneralContext _generalContext;
        private readonly LanguageContext _languageContext;
        public GalleryQuery(GeneralContext generalContext, LanguageContext languageContext)
        {
            _generalContext = generalContext;
            _languageContext = languageContext;
        }

        public List<GalleryQueryModel> GetAll()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            if (_languageContext != null)
            {
                var language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
                var gallery = _generalContext.Galleries.Select(x => new GalleryQueryModel()
                {
                    LanguageId = x.LanguageId,
                    Description = x.Description,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    Title = x.Title,
                    DateTime = x.CreationDateTime
                    
                }).AsNoTracking();
              return gallery.Where(x => x.LanguageId == language).ToList();
            }
            return new List<GalleryQueryModel>();
        }
    }
}