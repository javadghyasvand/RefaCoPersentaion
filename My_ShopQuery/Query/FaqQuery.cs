using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.Faq;

namespace My_ShopQuery.Query
{
    public class FaqQuery:IFaqQueryModel
    {
        private readonly  GeneralContext _context;
        private readonly LanguageContext _languageContext;
        public FaqQuery(GeneralContext context, LanguageContext languageContext)
        {
            _context = context;
            _languageContext = languageContext;
        }

        public List<FaqQueryModel> GetAll()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            if (_languageContext != null)
            {
                var language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
                var faq = _context.Faqs.Select(x => new FaqQueryModel()
                {
                    Question = x.Question,
                    LanguageId = x.LanguageId,
                    Answer = x.Answer,
                    Id = x.Id,
                    IsRemoved = x.IsRemoved,
                });
                faq = faq.Where(x => x.IsRemoved == false && x.LanguageId == language);

                return faq.ToList();

            }

            return new List<FaqQueryModel>();
        }
    }
}