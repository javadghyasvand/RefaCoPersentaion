using GeneralManagement.Application.Contracts.SocialMedia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.SocialMedia
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateSocialMedia Command =new CreateSocialMedia();
        private readonly ISocialMediaApplication _socialMediaApplication;
            
        public CreateModel(ISocialMediaApplication socialMediaApplication)
        {
            _socialMediaApplication = socialMediaApplication;
        }


        public void OnGet()
        {
           
        }

        public IActionResult OnPost(CreateSocialMedia command)
        {
            var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _socialMediaApplication.Create(command);
                return RedirectToPage("./Index");
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();

        }
    }
}
