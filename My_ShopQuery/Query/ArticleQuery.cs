using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BlogManagement.Infrastructure.EFCore;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Comment;
using ShopManagement.Infrastructure.EFCore;

namespace My_ShopQuery.Query
{
    public class ArticleQuery : IArticleQueryModel
    {
        private readonly BlogContext _blogContext;
        private readonly CommentContext _commentContext;
        private readonly LanguageContext _languageContext;

        public ArticleQuery(BlogContext blogContext, CommentContext commentContext, LanguageContext languageContext)
        {
            _blogContext = blogContext;
            _commentContext = commentContext;
            _languageContext = languageContext;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            if (_languageContext is { })
            {
                var language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
                var articles= _blogContext.Articles.Include(x => x.Category).Where(x => x.PublishDate <= DateTime.Now && x.LanguageId == language)
                    .Select(x => new ArticleQueryModel
                    {
                        Slug = x.Slug,
                        Picture = x.Picture,
                        PublishDate = x.PublishDate.ToFarsi(),
                        MetDescription = x.MetDescription,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        ShortDescription = x.ShortDescription,
                        CategoryName = x.Category.Name,
                        Title = x.Title
                    }).AsNoTracking().Take(3).ToList();
                return articles;
            }
            return  new List<ArticleQueryModel>();
        }

        public ArticleQueryModel GetDetailsBy(string slug)
        {
            var article = _blogContext.Articles.Include(x => x.Category).Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Slug = x.Slug,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.Category.Id,
                CategoryName = x.Category.Name,
                CategorySlug = x.Category.Slug,
                Description = x.Description,
                Keywords = x.Keywords,
                MetDescription = x.MetDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                CommentActive = x.CommentActive,

            }).FirstOrDefault(x => x.Slug == slug);
            //
            // if (article != null && article.Keywords != null)
            //     article.KeywordList = article.Keywords.Split("#").ToList();

            var comments = _commentContext.Comments
                .Where(x => x.OwnerId == article.Id && !x.IsCancel && x.IsConfirmed && x.Type == CommentType.Article).Select(x=>new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CommentDate = x.CreationDateTime.ToFarsi(),
                    Email = x.Email,
                    Message = x.Message,
                }).ToList();

            foreach (var comment in comments)
            {
                if (comment.ParentId > 0)
                {
                    comment.ParentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;
                }
            }

            if (article != null)
            {
                article.Comments = comments;
    
            }
            return article;
        }

        public List<ArticleQueryModel> Search(string value)
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            long language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            long shopType = ShopType.Product;
            var query = _blogContext.Articles.Select(x => new ArticleQueryModel()
            {
                Id = x.Id,
                Slug = x.Slug,
                Title = x.Title,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                LangugeId = x.LanguageId,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
            }).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Title.Contains(value) || x.ShortDescription.Contains(value) || x.Description.Contains(value));

            var articles = query.OrderByDescending(x => x.Id) ?? throw new ArgumentNullException("query.OrderByDescending(x => x.Id)");
            return articles.Where(x => x.LangugeId == language).ToList();
            
        }
    }
} 