using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.GeneralSetting;
using My_ShopQuery.Contract.Language;
using My_ShopQuery.Contract.Menu;
using My_ShopQuery.Contract.SiteLogo;
using My_ShopQuery.Contract.SocialMedia;

namespace ServiceHost.ViewComponents
{
    public class MobileNavbarViewComponent : ViewComponent
    {
        private readonly ISiteLogoQueryModel _siteLogoQueryModel;
        private readonly ISocialMediaQueryModel _socialMediaQuery;
        private readonly IGeneralSettingQueryModel _generalSettingQueryModel;
        private readonly ILanguageQueryModel _languageQueryModel;

        public MobileNavbarViewComponent(ILanguageQueryModel languageQueryModel, ISiteLogoQueryModel siteLogoQueryModel, ISocialMediaQueryModel socialMediaQuery, IGeneralSettingQueryModel generalSettingQueryModel)
        {
          
            _languageQueryModel = languageQueryModel;
            _siteLogoQueryModel = siteLogoQueryModel;
            _socialMediaQuery = socialMediaQuery;
            _generalSettingQueryModel = generalSettingQueryModel;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuQueryModel
            {
                SiteLogoQueryModel = _siteLogoQueryModel.GetLogo(),
                SocialMediaQueries = _socialMediaQuery.SocialMediaList(),
                LanguageQueries = _languageQueryModel.List(),
                GeneralSettingQuery = _generalSettingQueryModel.GeneralSettingQueryModel()
            };
            return View("MobileNavbar", result);
        }

    }
}
