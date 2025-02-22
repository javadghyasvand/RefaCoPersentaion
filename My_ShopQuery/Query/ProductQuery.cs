using System;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_ShopQuery.Contract.Product;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;
using CommentManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.Comment;
using ShopManagement.Domain.ProductPictureAgg;
using System.Globalization;
using LanguageManagement.Infrastructure.EFCore;
using LanguageManagement.Domain.Language.Agg;

namespace My_ShopQuery.Query
{
    public class ProductQuery : IProductQueryModel
    {
        private readonly ShopContext _contextShopShop;
        private readonly CommentContext _commentContext;
        private readonly LanguageContext _languageContext;

        public ProductQuery(ShopContext contextShopShop, CommentContext commentContext, LanguageContext languageContext)
        {
            _contextShopShop = contextShopShop;
            _commentContext = commentContext;
            _languageContext = languageContext;
        }
        public List<ProductQueryModel> List()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            long language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var products = _contextShopShop.Products.Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                LanguageId = x.LanguageId,

            }).ToList();
            return products.Where(x => x.LanguageId == language).ToList();
        }
        public List<ProductQueryModel> GetLatestProduct()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            long language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var products = _contextShopShop.Products.Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                LanguageId = x.LanguageId,

            }).ToList();
            return products.Where(x => x.LanguageId == language).Take(5).ToList();
        }

        public List<ProductQueryModel> SearchProducts(string value)
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            long language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var query = _contextShopShop.Products.Include(x => x.Category).Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Category = x.Category.Name,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                CategorySlug = x.Category.Slug,
                LanguageId = x.LanguageId
            }).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x =>
                    x.Name.Contains(value) || x.ShortDescription.Contains(value) || x.Description.Contains(value));
            var products = query.OrderByDescending(x => x.Id);
            return products.Where(x=> x.LanguageId == language).ToList();
        }

        public List<ProductQueryModel> GetList()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            long language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var query = _contextShopShop.Products.Select(x => new ProductQueryModel()
            {
                Id = x.Id,
                Name = x.Name,
                LanguageId = x.LanguageId
            });
            return query.Where(x=>x.LanguageId==language).ToList();
        }

        public List<ProductQueryModel> GetListWithCategory(long id)
        {
            throw new System.NotImplementedException();
        }

        public ProductQueryModel GetBy(long id)
        {
            return _contextShopShop.Products.Select(x=>new  ProductQueryModel()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
        }

        public ProductQueryModel GetProductDetails(string slug)
        {
            var product = _contextShopShop.Products.Include(x => x.Category).Include(x => x.ProductPictures).Select(x =>
                new ProductQueryModel
                {
                    Category = x.Category.Name,
                    CategoryId = x.Category.Id,
                    Name = x.Name,
                    Id = x.Id,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    MetaDescription = x.MetaDescription,
                    CategorySlug = x.Category.Slug,
                    Description = x.Description,
                    ShortDescription = x.ShortDescription,
                    Keywords = x.Keywords, 
                    StarBolt = x.StarBolt,
                    Manual = x.Manual,
                    CommentActive = x.CommentActive,
                    Pictures = MapProductPicture(x.ProductPictures),
                }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);
            if (product != null)
                product.KeywordList = product.Keywords.Split("#").ToList();
            if (product == null)
                return new ProductQueryModel();


            product.Comments = _commentContext.Comments
                .Where(x => !x.IsCancel)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Product)
                .Where(x => x.OwnerId == product.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    Name = x.Name,
                    CommentDate = x.CreationDateTime.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();
            product.ProductList = _contextShopShop.Products
                .Where(x => x.CategoryId == product.CategoryId && x.Id != product.Id)
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new ProductQueryModel()
                {
                    Id = x.Id,
                    Slug = x.Slug,
                    Name = x.Name,
                    Picture = x.Picture,
                    CategoryId = x.CategoryId,
                })
                .Take(4)
                .ToList();
            // product.ProductList = _contextShopShop.Products.Select(x => new ProductQueryModel()
            // {
            //     Id = x.Id,
            //     Slug = x.Slug,
            //     Name = x.Name,
            //     Picture = x.Picture,
            //     CategoryId = x.CategoryId,
            // }).Where(x => x.CategoryId == product.CategoryId && x.Id != product.Id).Take(4).ToList();
            return product;
        }


        private static List<ProductPictureQueryModal> MapProductPicture(List<ProductPicture> xProductPictures)
        {
            return xProductPictures.Select(x => new ProductPictureQueryModal
            {
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).Where(x => !x.IsRemoved).ToList();
        }
    }
}