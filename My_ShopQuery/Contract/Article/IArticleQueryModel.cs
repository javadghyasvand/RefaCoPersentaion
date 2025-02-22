using System.Collections.Generic;

namespace My_ShopQuery.Contract.Article
{
    public interface IArticleQueryModel
    {
        List<ArticleQueryModel> LatestArticles();
        ArticleQueryModel GetDetailsBy(string slug);
        List<ArticleQueryModel> Search(string value);
    }
}