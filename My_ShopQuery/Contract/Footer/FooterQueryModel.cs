using System.Collections.Generic;
using My_ShopQuery.Contract.AboutUs;
using My_ShopQuery.Contract.ArticleCategory;
using My_ShopQuery.Contract.GeneralSetting;
using My_ShopQuery.Contract.Language;
using My_ShopQuery.Contract.ProductCategory;
using My_ShopQuery.Contract.SiteLogo;
using My_ShopQuery.Contract.SocialMedia;

namespace My_ShopQuery.Contract.Footer
{
    public class FooterQueryModel
    {

        public GeneralSettingQueryModel GeneralSettingQueryModel { get; set; }
        public AboutUsQueryModel AboutUsQueryModel { get; set; }
        public SiteLogoQueryModel SiteLogoQueryModel { get; set; }
        public List<SocialMediaQueryModel> SocialMediaQueries { get; set; }
        public List<LanguageQueryModel> LanguageQueries { get; set; }
    }
}