using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Certificate;
using My_ShopQuery.Contract.SocialMedia;

namespace ServiceHost.Pages.Certificates
{
    public class CertificatesDetailsModel : PageModel
    {

        public CertificateQueryModel CertificateQueryModel;
        public List<CertificateQueryModel> CertificateList;
        public List<SocialMediaQueryModel> SocialMediaQueryModels;

        private readonly ICertificateQueryModel _certificateQueryModel;
        private readonly ISocialMediaQueryModel _socialMediaQueryModel;

        public CertificatesDetailsModel(ICertificateQueryModel certificateQueryModel, ISocialMediaQueryModel socialMediaQueryModel)
        {
            _certificateQueryModel = certificateQueryModel;
            _socialMediaQueryModel = socialMediaQueryModel;
        }


        public void OnGet(long id)
        {
            CertificateQueryModel = _certificateQueryModel.GetCertificate(id);
            CertificateList = _certificateQueryModel.GetCertificateList();
            SocialMediaQueryModels = _socialMediaQueryModel.SocialMediaList();
        }

    }

}
