using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.Support;
using My_ShopQuery.Contract.Video;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorialManagement.Infrastructure.EfCore;

namespace My_ShopQuery.Query
{
    public class VideoQueryModel : IVideoQueryModel
    {
        private readonly TutorialContext _generalContext;
        private readonly LanguageContext _languageContext;

        public VideoQueryModel(TutorialContext generalContext, LanguageContext languageContext)
        {
            _generalContext = generalContext;
            _languageContext = languageContext;
        }

        public List<IntroductionVideoQueryModel> GetIntroductionQuery()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var query = _generalContext.IntroductionVideos.Select(x => new IntroductionVideoQueryModel
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                Link = x.Link,
                Poster = x.Poster,
            }).AsNoTracking().Where(x => x.LanguageId == language).ToList();
            if (query.Any())
                return query;
            return new List<IntroductionVideoQueryModel>();
        }

        public List<TutorialVideoQueryModel> GetTutorialQuery()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var query = _generalContext.TutorialVideos.Select(x => new TutorialVideoQueryModel
            {
             Id = x.Id, 
             TitleAr = x.TitleAr ?? string.Empty,
             TitleEn = x.TitleEn ?? string.Empty,
             TitleRu = x.TitleRu ?? string.Empty,
             TitleFa = x.TitleFa ?? string.Empty,
             PosterStr = x.Poster ?? string.Empty,
             LinkFa = x.LinkFa ?? string.Empty,
             LinkAr = x.LinkAr ?? string.Empty,
             LinkEn = x.LinkEn ?? string.Empty,
             LinkRu = x.LinkRu ?? string.Empty,
            });
            
            return query.ToList();
        }
    }
}