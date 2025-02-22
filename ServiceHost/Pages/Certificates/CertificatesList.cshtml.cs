using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Certificate;

namespace ServiceHost.Pages.Certificates
{
    public class CertificatesListModel : PageModel
    {
        public List<CertificateQueryModel> Certificate { get; set; }
        private readonly ICertificateQueryModel _articleQuery;

        public CertificatesListModel(ICertificateQueryModel articleQuery)
        {
            _articleQuery = articleQuery;
        }


        public void OnGet()
        {
            Certificate = _articleQuery.GetCertificateList();
        }
    }
}
