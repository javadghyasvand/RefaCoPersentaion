using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using My_Shop_Framework.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel model);
        string GetSlugById(long id);
    }
}
