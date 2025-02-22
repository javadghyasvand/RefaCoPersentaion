
using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Product;


namespace ServiceHost.ViewComponents
{
    public class LatestArticlesViewComponent : ViewComponent
    {
       private readonly IArticleQueryModel _articleQueryModel;

        public LatestArticlesViewComponent(IArticleQueryModel articleQueryModel)
        {
            _articleQueryModel = articleQueryModel;
        }

        public IViewComponentResult Invoke()
        {
            var productQueryModel = _articleQueryModel.LatestArticles();
            return View("LatestArticels", productQueryModel);
        }
    }
}