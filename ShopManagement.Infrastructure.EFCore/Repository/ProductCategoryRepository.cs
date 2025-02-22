using System.Collections.Generic;
using System.Linq;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _shopContext.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                PictureString = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                IconString = x.Icon,
                Slug = x.Slug,
                LanguageId = x.LanguageId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel model)
        {
            var query = _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                LanguageId = x.LanguageId
            });
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
                return query.OrderByDescending(x => x.Id).ToList();
            }

            if (model.LanguageId > 0)
            {
                query = query.Where(x => x.LanguageId == model.LanguageId);
                return query.OrderByDescending(x => x.Id).ToList();
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public string GetSlugById(long id)
        {
            return _shopContext.ProductCategories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id)
                ?.Slug;
        }
    }
}
