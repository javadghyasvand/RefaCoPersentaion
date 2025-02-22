using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BlogManagement.Domain.Articles.Agg;
using BlogManagement.Infrastructure.EFCore;
using LanguageManagement.Domain.Language.Agg;
using LanguageManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.ArticleCategory;

namespace My_ShopQuery.Query
{
    public class ArticleCategoryQuery:IArticleCategoryQueryModel
    {
        private readonly BlogContext _blogContext;
        private readonly LanguageContext _langContext;
        public ArticleCategoryQuery(BlogContext blogContext, LanguageContext langContext)
        {
            _blogContext = blogContext;
            _langContext=langContext;
        }

        public ArticleCategoryQueryModel GetArticleCategory(string slug)
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var lang = _langContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var articulateCategories = _blogContext.ArticulateCategories.Include(x=>x.Articles).Select(x=>new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Slug = x.Slug,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                CountArticle = x.Articles.Count,

                Articles = MapArticles(x.Articles, lang),

            }).FirstOrDefault(x=>x.Slug==slug);
            if (articulateCategories != null)
            {
                articulateCategories.KeywordList = articulateCategories.Keywords.Split("#").ToList();
              
            }
            return articulateCategories;
        }

        private static List<ArticleQueryModel> MapArticles(List<Articles> articles, long languageId)
        {
            
            return articles.Select(x => new ArticleQueryModel
            {

                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                LangugeId = x.LanguageId

            }).Where(x=>x.LangugeId==languageId).ToList();
        }

        public List<ArticleCategoryQueryModel> GetArticleCategoryQueryModels()
        {
            var currentlang = CultureInfo.CurrentCulture.ToString();
            var lang = _langContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentlang).Id;

            return _blogContext.ArticulateCategories.Include(x=>x.Articles).Select(x => new ArticleCategoryQueryModel
            {
                Name = x.Name,
                Id = x.Id,
                Slug = x.Slug,
                CountArticle = x.Articles.Count,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                LanguageId=x.LanguageId,
                
            }).Where(x=>x.LanguageId==lang).ToList();
        }
    }
}