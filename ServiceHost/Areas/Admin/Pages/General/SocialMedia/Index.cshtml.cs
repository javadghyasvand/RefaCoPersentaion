using System.Collections.Generic;
using GeneralManagement.Application.Contracts.SocialMedia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.General.SocialMedia
{
   
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<SocialMediaViewModel> SocialMediaViewModel;

        private readonly ISocialMediaApplication _socialMediaApplication;

        public IndexModel(ISocialMediaApplication socialMediaApplication)
        {
            _socialMediaApplication = socialMediaApplication;
        }


        public void OnGet()
        {
            SocialMediaViewModel = _socialMediaApplication.ListSocial();
        }

    }
}
