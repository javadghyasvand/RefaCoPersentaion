using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using LanguageManagement.Application.Contracts.Language;
using LanguageManagement.Domain.Language.Agg;
using My_Shop_Framework.Infrastructure;

namespace LanguageManagement.Infrastructure.EFCore.Repository
{
    public class LanguageRepository: RepositoryBase<long, Language>, ILanguageRepository
    {
        private readonly  LanguageContext _contextLanguage;
        public LanguageRepository(LanguageContext contextLanguage) : base(contextLanguage)
        {
            _contextLanguage = contextLanguage;
        }

        public Language GetBy(string userName)
        {
            return _contextLanguage.Languages.FirstOrDefault(x => x.LanguageTitle == userName);
        }

        public EditLanguage GetDetails(long id)
        {
            return _contextLanguage.Languages.Select(x => new EditLanguage
            {
                LanguageTitle = x.LanguageTitle,
                LanguageNameAr = x.LanguageNameAr,
                LanguageNameEn = x.LanguageNameEn,
                LanguageNameRu = x.LanguageNameRu,
                LanguageNameFa = x.LanguageNameFa,
                Id = x.Id,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<LanguageViewModel> List()
        {
            return _contextLanguage.Languages.Select(x => new LanguageViewModel
            {
                LanguageTitle = x.LanguageTitle,
                LanguageNameAr = x.LanguageNameAr,
                LanguageNameEn = x.LanguageNameEn,
                LanguageNameRu = x.LanguageNameRu,
                LanguageNameFa = x.LanguageNameFa,
                Id = x.Id,

            }).ToList();
        }
    }
}