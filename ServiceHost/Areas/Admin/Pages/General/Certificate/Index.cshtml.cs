using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Certificate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.General.Certificate
{
   
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<CertificateViewModel> CertificateViewModels;

        private readonly ICertificateApplication _certificateApplication;

        public IndexModel(ICertificateApplication certificateApplication)
        {
            _certificateApplication = certificateApplication;
        }


        public void OnGet()
        {
            CertificateViewModels = _certificateApplication.GetList();
        }

    }
}
