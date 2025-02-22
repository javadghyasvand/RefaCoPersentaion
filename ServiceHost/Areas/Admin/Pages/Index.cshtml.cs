using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Infrastructure.EFCore;
using GeneralManagement.Application.Contracts.SiteLogo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages
{
   /* [Authorize]*/
    public class IndexModel : PageModel
    {
        public SiteLogoViewModel SiteLogo;
        public List<CommentViewModel> Comment =new List<CommentViewModel>();
        private ISiteLogoApplication _siteLogoApplication;
        private ICommentApplication _commentApplication;

        public IndexModel(ISiteLogoApplication siteLogoApplication, ICommentApplication commentApplication)
        {
            _siteLogoApplication = siteLogoApplication;
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            SiteLogo = _siteLogoApplication.GetSiteLogo();
            // Comment = _commentApplication.ByType(CommentType.Message);
        }
    }
}
