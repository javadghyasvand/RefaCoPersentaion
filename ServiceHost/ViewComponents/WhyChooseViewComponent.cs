using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.Certificate;

namespace ServiceHost.ViewComponents
{
    public class WhyChooseViewComponent : ViewComponent
    {
        private readonly ICertificateQueryModel _certificateQueryModel;

        public WhyChooseViewComponent(ICertificateQueryModel certificateQueryModel)
        {
            _certificateQueryModel = certificateQueryModel;
        }


        public IViewComponentResult Invoke()
        {
            var certificate = _certificateQueryModel.TakeCertificate();
            return View("WhyChoose", certificate);
        }
    }
}