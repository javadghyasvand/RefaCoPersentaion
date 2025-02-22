using System.Collections.Generic;
using GeneralManagement.Application.Contracts.SiteLogo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.General.SiteLogo
{
   
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<SiteLogoViewModel> LogoViewModel;

        private readonly ISiteLogoApplication _siteLogoApplication;

        public IndexModel(ISiteLogoApplication siteLogoApplication)
        {
            _siteLogoApplication = siteLogoApplication;
        }

        public void OnGet()
        {
            LogoViewModel = _siteLogoApplication.GetSiteLogoList();
        }


    }
}
