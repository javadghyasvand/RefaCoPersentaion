using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.AboutUs;
using My_ShopQuery.Contract.Certificate;

namespace ServiceHost.ViewComponents
{
    public class VideoViewComponent : ViewComponent
    {
        private readonly ICertificateQueryModel _certificateQueryModel;

        public VideoViewComponent(ICertificateQueryModel certificateQueryModel)
        {
            _certificateQueryModel = certificateQueryModel;
        }


        public IViewComponentResult Invoke()
        {
            var certificate = _certificateQueryModel.TakeCertificate();
            return View("Video", certificate);
        }
    }
}