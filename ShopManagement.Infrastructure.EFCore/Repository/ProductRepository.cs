using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductViewModel> Search(ProductSearchModel model)
        {
            var query = _shopContext.Products.Include(x => x.Category).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Picture = x.Picture,
                Category = x.Category.Name,
                CreationDate = x.CreationDateTime,
                LanguageId = x.LanguageId,

            });
            if (!string.IsNullOrWhiteSpace(model.Name))
                query = query.Where(x => x.Name.Contains(model.Name));
            if (model.CategoryId != 0)
                query = query.Where(x => x.CategoryId == model.CategoryId);
            if (model.LanguageId > 0)
                query = query.Where(x => x.LanguageId == model.LanguageId);
            return query.OrderByDescending(x=>x.Id).ToList();

        }

        public List<ProductViewModel> GetProducts()
        {
            return _shopContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditProduct GetDetails(long id)
        {
            return _shopContext.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                PictureAlt = x.PictureAlt,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                PictureString = x.Picture,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                LanguageId = x.LanguageId,
                StarBolt = x.StarBolt,
                CommentActive = x.CommentActive,
                
                
            }).FirstOrDefault(x => x.Id == id);
        }

        public ProductViewModel GetProduct(long id)
        {
            return _shopContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                LanguageId = x.LanguageId
            }).SingleOrDefault(x => x.Id == id);
        }

        public string GetProductName(long id)
        {
            return _shopContext.Products.SingleOrDefault(x => x.Id == id)?.Name;
        }

        public List<ProductViewModel> List()
        {
            return _shopContext.Products.Select(x => new ProductViewModel()
            {
                Id = x.Id,
               Name = x.Name,
            }).ToList();
        }
    }
}