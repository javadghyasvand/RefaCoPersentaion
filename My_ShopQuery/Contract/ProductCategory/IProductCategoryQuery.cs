using System.Collections.Generic;

namespace My_ShopQuery.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetAllCategory();
        ProductCategoryQueryModel GetProductCategoryWithProductsBy(string slug);
    }
}