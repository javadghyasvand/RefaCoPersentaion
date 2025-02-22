using GeneralManagement.Application.Contracts.AboutUs;
using GeneralManagement.Application.Contracts.SocialMedia;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.SocialMedia
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
 
        public EditSocialMedia Command;
        private readonly ISocialMediaApplication _socialMediaApplication;

        public EditModel(ISocialMediaApplication socialMediaApplication)
        {
            _socialMediaApplication = socialMediaApplication;
        }


        public void OnGet(long id)
        {
            Command = _socialMediaApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditSocialMedia command)
        { var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _socialMediaApplication.Edit(command);
                return RedirectToPage("./Index");
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
