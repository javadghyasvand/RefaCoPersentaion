using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LanguageManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.Language;

namespace My_ShopQuery.Query
{
    public class LanguageQuery:ILanguageQueryModel
    {
        private readonly LanguageContext _languageContext;

        public LanguageQuery(LanguageContext languageContext)
        {
            _languageContext = languageContext;
        }

        public List<LanguageQueryModel> List()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var lang = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            switch (currentLanguage)
            {
                case "fa-IR":
                    return _languageContext.Languages.Select(x => new LanguageQueryModel()
                    {
                        Id = x.Id,
                        Language = x.LanguageTitle,
                        LanguageNameShowName = x.LanguageNameFa,
                    }).ToList();
                    break;

                case "en-US":
                    return _languageContext.Languages.Select(x => new LanguageQueryModel()
                    {
                        Id = x.Id,
                        Language = x.LanguageTitle,
                        LanguageNameShowName = x.LanguageNameEn,
                    }).ToList();
                    break;

                case "ru-RU":
                    return _languageContext.Languages.Select(x => new LanguageQueryModel()
                    {
                        Id = x.Id,
                        Language = x.LanguageTitle,
                        LanguageNameShowName = x.LanguageNameRu,
                    }).ToList();
                    break;
                case "ar":
                    return _languageContext.Languages.Select(x => new LanguageQueryModel()
                    {
                        Id = x.Id,
                        Language = x.LanguageTitle,
                        LanguageNameShowName = x.LanguageNameAr,
                    }).ToList();
                    break;
            }

            return new List<LanguageQueryModel>();
        }

        public LanguageQueryModel GetBy(string id)
        {
            return _languageContext.Languages.Select(x => new LanguageQueryModel()
            {
                Id = x.Id,
                Language = x.LanguageTitle
            }).FirstOrDefault(x=>x.Language==id);
        }
    }
}