using System.Collections.Generic;

namespace My_ShopQuery.Contract.ArticleCategory
{
    public interface IArticleCategoryQueryModel
    {
        ArticleCategoryQueryModel GetArticleCategory(string slug);
        List<ArticleCategoryQueryModel> GetArticleCategoryQueryModels();
    }
}