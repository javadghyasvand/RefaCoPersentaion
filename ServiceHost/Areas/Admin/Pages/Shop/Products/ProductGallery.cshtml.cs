using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products
{
    public class ProductGalleryModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<ProductPictureViewModel> ProductPictures;
        public ProductPictureSearchModel SearchModel;
        public ProductViewModel Product;

        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;

        public ProductGalleryModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }


        public void OnGet(long id)
        {
            Product = _productApplication.GetProduct(id);
            ProductPictures = _productPictureApplication.ListBy(id);
        }

        public IActionResult OnGetCreatePicture(long id)
        {
            var command = new CreateProductPicture
            {
                ProductId = id,
                ProductName = _productApplication.GetProductName(id)
            };
            return Partial("./CreatePicture", command);
        }

        public JsonResult OnPostCreatePicture(CreateProductPicture commend)
        {
            var result = _productPictureApplication.Create(commend);
            return new JsonResult(result);
        }

        public IActionResult OnGetEditPicture(long id)
        {
            var productPicture = _productPictureApplication.GetDetails(id);
            productPicture.Products = _productApplication.GetProducts();
            productPicture.ProductName = _productApplication.GetProductName(id);
            return Partial("./EditPicture", productPicture);
        }
        public JsonResult OnPostEditPicture(EditProductPicture commend)
        {
            var result = _productPictureApplication.Edit(commend);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productPictureApplication.IsRemove(id);
            var product = _productPictureApplication.GetBy(id);
            if (result.IsSuccess)

                return RedirectToPage("./ProductGallery", new { id = product.ProductId });
            Message = result.Massage;
            return RedirectToPage("./ProductGallery", new { id = product.ProductId });
        }
        public IActionResult OnGetRestore(long id)
        
        {
            var result = _productPictureApplication.Restore(id);
            var product = _productPictureApplication.GetBy(id);
            if (result.IsSuccess)
                return RedirectToPage("./ProductGallery",new {id= product.ProductId});
            Message = result.Massage;
            return RedirectToPage("./ProductGallery", new { id = product.ProductId });
        }
    }
}
