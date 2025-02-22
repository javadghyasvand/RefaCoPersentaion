using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.ArticleCategory;
using My_ShopQuery.Contract.Language;
using My_ShopQuery.Contract.Menu;
using My_ShopQuery.Contract.ProductCategory;
using My_ShopQuery.Contract.SiteLogo;
using My_ShopQuery.Contract.SocialMedia;

namespace ServiceHost.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly ILanguageQueryModel _languageQueryModel;
        //private readonly IArticleCategoryQueryModel _articleCategoryQueryModel;
        //private readonly ISiteLogoQueryModel _siteLogoQueryModel;
        //private readonly ISocialMediaQueryModel _socialMediaQuery;


        public NavbarViewComponent(IProductCategoryQuery productCategoryQuery, IArticleCategoryQueryModel articleCategoryQueryModel,
            ISiteLogoQueryModel siteLogoQueryModel, ISocialMediaQueryModel socialMediaQuery, ILanguageQueryModel languageQueryModel)
        {
            _productCategoryQuery = productCategoryQuery;
            _languageQueryModel = languageQueryModel;
            //_articleCategoryQueryModel = articleCategoryQueryModel;
            //_siteLogoQueryModel = siteLogoQueryModel;
            //_socialMediaQuery = socialMediaQuery;

        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuQueryModel
            {
                
                ProductCategoryQueryModels = _productCategoryQuery.GetProductCategories(),
                LanguageQueries = _languageQueryModel.List(),
                //SiteLogoQueryModel = _siteLogoQueryModel.GetLogo(),
                //SocialMediaQueries = _socialMediaQuery.SocialMediaList(),

                //ArticleCategoryQueryModels = _articleCategoryQueryModel.GetArticleCategoryQueryModels(),
            };
            return View("Navbar", result);
        }

    }
}
