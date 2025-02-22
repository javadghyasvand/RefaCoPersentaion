using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.ProductCategory;

namespace ServiceHost.Pages.Product
{
    public class CategoryWithProductModel : PageModel
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public CategoryWithProductModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }


        public ProductCategoryQueryModel ProductCategoryQueryModel { get; set; }
        public List<ProductCategoryQueryModel> Category { get; set; }


        public void OnGet(string slug)
        {
            ProductCategoryQueryModel = _productCategoryQuery.GetProductCategoryWithProductsBy(slug);
            Category = _productCategoryQuery.GetAllCategory();
        }
    }
}
