
using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.ArticleCategory;
using My_ShopQuery.Contract.Product;
using My_ShopQuery.Contract.ProductCategory;

namespace ServiceHost.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery  _productCategoryQuery;

        public CategoriesViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }


        public IViewComponentResult Invoke()
        {
            var productCategory = _productCategoryQuery.GetProductCategories();
            return View("Categories", productCategory);
        }
    }
}