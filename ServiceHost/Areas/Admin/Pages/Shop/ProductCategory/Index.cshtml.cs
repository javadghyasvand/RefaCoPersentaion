using System.Collections.Generic;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryViewModel> ProductCategoryViewModels;
        public ProductCategorySearchModel SearchModel;
        public SelectList ListLanguage;
        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly ILanguageApplication _languageApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication,
            ILanguageApplication languageApplication)
        {
            _productCategoryApplication = productCategoryApplication;
            _languageApplication = languageApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            ProductCategoryViewModels = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductCategory
            {
                ListLanguage = _languageApplication.List()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductCategory commend)
        {
            OperationResult result =new OperationResult();
            if (ModelState.IsValid)
            {
                result = _productCategoryApplication.Create(commend);
                return new JsonResult(result);
            } 
            Partial("./Create", commend);
            return new JsonResult(result.NotValid());
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _productCategoryApplication.GetDetails(id);
            command.ListLanguage = _languageApplication.List();

            return Partial("./Edit", command);
        }

        public JsonResult OnPostEdit(EditProductCategory commend)
        {
            OperationResult result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _productCategoryApplication.Edit(commend);
                return new JsonResult(result);
            }
            Partial("./Create", commend);
            return new JsonResult(result.NotValid());
           
        }
    }
}