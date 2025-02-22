using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Product;
using ServiceHost.Pages.Article;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        public string Value;
        public List<ProductQueryModel> ProductQueryModel;
        public List<ArticleQueryModel> ArticleQueryModels;
        private readonly IProductQueryModel _productQueryModel;
        private readonly IArticleQueryModel _articleQueryModel;

        public SearchModel(IProductQueryModel productQueryModel, IArticleQueryModel articleQueryModel)
        {
            _productQueryModel = productQueryModel;
            _articleQueryModel = articleQueryModel;
        }
        public void OnGet(string value)
        {
            Value = value;
            ProductQueryModel = _productQueryModel.SearchProducts(value);
            ArticleQueryModels = _articleQueryModel.Search(value);

        }
    }
}
