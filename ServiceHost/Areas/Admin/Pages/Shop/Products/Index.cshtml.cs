using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> ProductViewModel;
        public SelectList ProductCategories;
        public SelectList ListLanguage;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly ILanguageApplication _languageApplication;


        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication, ILanguageApplication languageApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
            _languageApplication = languageApplication;
        }
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            ProductViewModel = _productApplication.Search(searchModel);
        }
    }
}
