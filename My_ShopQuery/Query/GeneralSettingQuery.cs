using System.Globalization;
using System.Linq;
using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.GeneralSetting;

namespace My_ShopQuery.Query
{
    public class GeneralSettingQuery : IGeneralSettingQueryModel
    {
        private readonly GeneralContext _context;
        private readonly LanguageContext _languageContext;

        public GeneralSettingQuery(GeneralContext context, LanguageContext languageContext)
        {
            _context = context;
            _languageContext = languageContext;
        }

        public GeneralSettingQueryModel GeneralSettingQueryModel()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();

            long language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var general = _context.GeneralSettings.Select(x => new GeneralSettingQueryModel
            {
                Id = x.Id,
                Address = x.Address,
                LanguageId = x.LanguageId,
                PhoneNumbers = x.PhoneNumbers,
                PostalCode = x.PostalCode,
                SiteTitle = x.SiteTitle,
                Email = x.AdminEmail,
                MapLink = x.MapLink,
                MetaDescription = x.MetaDescription,
                MetaKeywords = x.MetaKeywords,
                BaladLink = x.BaladLink,
                WaysLink = x.WaysLink,
                GoogleLink = x.GoogleLink
                
            }).SingleOrDefault(x => x.LanguageId == language);

            if (general == null)
            {
                return new GeneralSettingQueryModel();
            }

            return general;
        }
    }
}