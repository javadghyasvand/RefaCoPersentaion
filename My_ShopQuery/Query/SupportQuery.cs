using System.Globalization;
using System.Linq;
using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.GeneralSetting;
using My_ShopQuery.Contract.Language;
using My_ShopQuery.Contract.Support;

namespace My_ShopQuery.Query
{
    public class SupportQuery : ISupportQueryModel
    {
        private readonly GeneralContext _generalContext;
        private readonly LanguageContext _langContext;

        public SupportQuery(GeneralContext generalContext, LanguageContext langContext)
        {
            _generalContext = generalContext;
            _langContext = langContext;
        }

        public SupportQueryModel GetSupportQuery()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _langContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var warranty = _generalContext.Warranty.Select(a => new SupportQueryModel()
            {
                Title = a.Title,
                Description = a.Description,
                LanguageId = a.LanguageId,
                
            });

            return warranty.FirstOrDefault(x => x.LanguageId == language);
        }
    }
}