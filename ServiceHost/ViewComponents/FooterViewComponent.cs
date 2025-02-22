using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.AboutUs;
using My_ShopQuery.Contract.ArticleCategory;
using My_ShopQuery.Contract.Footer;
using My_ShopQuery.Contract.GeneralSetting;
using My_ShopQuery.Contract.Language;
using My_ShopQuery.Contract.ProductCategory;
using My_ShopQuery.Contract.SiteLogo;
using My_ShopQuery.Contract.SocialMedia;

namespace ServiceHost.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly IGeneralSettingQueryModel _generalSettingQueryModel;
        private readonly ISiteLogoQueryModel _siteLogoQueryModel;
        private readonly ISocialMediaQueryModel _socialMediaQuery;
        private readonly IAboutUsQueryModel _aboutUsQueryModel;

        public FooterViewComponent(IProductCategoryQuery productCategoryQuery, IArticleCategoryQueryModel articleCategoryQueryModel,
            ISiteLogoQueryModel siteLogoQueryModel, ISocialMediaQueryModel socialMediaQuery,IGeneralSettingQueryModel generalSettingQueryModel, IAboutUsQueryModel aboutUsQueryModel)
        {
            _siteLogoQueryModel = siteLogoQueryModel;
            _socialMediaQuery = socialMediaQuery;
            _generalSettingQueryModel = generalSettingQueryModel;
            _aboutUsQueryModel = aboutUsQueryModel;
        }

        public IViewComponentResult Invoke()
        {
            var result = new FooterQueryModel()
            {
                GeneralSettingQueryModel = _generalSettingQueryModel.GeneralSettingQueryModel(),
                SiteLogoQueryModel = _siteLogoQueryModel.GetLogo(),
                SocialMediaQueries = _socialMediaQuery.SocialMediaList(),
                AboutUsQueryModel = _aboutUsQueryModel.AboutUs()
            };
            return View("Footer", result);
        }


    }
}
