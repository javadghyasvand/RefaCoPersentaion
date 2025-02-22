using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Product;
using My_ShopQuery.Contract.ProductCategory;

namespace ServiceHost.Pages.Product
{
    public class ProductListModel : PageModel
    {
        private readonly IProductQueryModel _productQueryModel;
        private readonly IProductCategoryQuery _productCategoryQuery;
        public ProductListModel(IProductQueryModel productQueryModel, IProductCategoryQuery productCategoryQuery)
        {
            _productQueryModel = productQueryModel;
            _productCategoryQuery = productCategoryQuery;
        }

        public List<ProductCategoryQueryModel> ProductCategoryQueryModel { get; set; }
        public List<ProductQueryModel> ProductQueryModel { get; set; }


        public void OnGet(string id)
        {
            ProductQueryModel = _productQueryModel.List();
            ProductCategoryQueryModel=_productCategoryQuery.GetProductCategories();
        }
    }
}
