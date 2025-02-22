
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_ShopQuery.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using My_ShopQuery.Contract.ProductCategory;
using System.Globalization;
using System.Xml.Linq;
using LanguageManagement.Infrastructure.EFCore;

namespace My_ShopQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;
        private readonly LanguageContext _langContext;

        public ProductCategoryQuery(ShopContext context, LanguageContext langContext)
        {
            _context = context;
            _langContext=langContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _langContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            return _context.ProductCategories.Include(x=>x.Products).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                Description = x.Description,
                Keyword = x.Keyword,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                LanguageId = x.LanguageId,
                Slug = x.Slug,
                Icon = x.Icon,
            }).Where(x => x.LanguageId==language).AsNoTracking()
                .OrderBy(x=>x.Id).Take(3).ToList();
        }

        public List<ProductCategoryQueryModel> GetAllCategory()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _langContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var categories = _context.ProductCategories.Include(x => x.Products).ThenInclude(x => x.Category).Select(
                x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products, language),
                    Slug = x.Slug,
                    LanguageId = x.LanguageId
                }).AsNoTracking();

            return categories.Where(x => x.LanguageId==language).ToList();
        }

        public ProductCategoryQueryModel GetProductCategoryWithProductsBy(string slug)
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _langContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage)!.Id;
            var category = _context.ProductCategories.Include(x => x.Products).ThenInclude(x => x.Category).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Keyword = x.Keyword,
                Slug = x.Slug,
                Products = MapProducts(x.Products, language),

            }).FirstOrDefault(x => x.Slug == slug);
            if (category != null)
            {
                foreach (var product in category.Products)
                {
                    product.CategorySlug = category.Slug;
                }
            }
            return category;
        }

        public static List<ProductQueryModel> MapProducts(List<Product> products, long language )
        {
            var product= products.Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Category = x.Category.Name,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                LanguageId = x.LanguageId

            });
            return product.Where(x=>x.LanguageId==language).ToList();
        }
    }
}