using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.Product;


namespace ServiceHost.ViewComponents
{
    public class LatestProductViewComponent : ViewComponent
    {
        private readonly IProductQueryModel _productQueryModel;

        public LatestProductViewComponent(IProductQueryModel productQueryModel)
        {
            _productQueryModel = productQueryModel;
        }

        public IViewComponentResult Invoke()
        {
           var productQueryModel = _productQueryModel.GetLatestProduct();
            return View("LatestProduct", productQueryModel);
        }
    }
}