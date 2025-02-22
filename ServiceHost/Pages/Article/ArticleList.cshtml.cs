using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.ArticleCategory;

namespace ServiceHost.Pages.Article
{
    public class ArticleCategoryModel : PageModel
    {
        public List<ArticleQueryModel> Articles { get; set; }
        private readonly IArticleQueryModel _articleQuery;

        public ArticleCategoryModel(IArticleQueryModel articleQuery)
        {
            _articleQuery = articleQuery;
        }


        public void OnGet(string id)
        {
            Articles = _articleQuery.LatestArticles();
        }
    }
}
