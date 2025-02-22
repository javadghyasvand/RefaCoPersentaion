using GeneralManagement.Application.Contracts.AboutUs;
using GeneralManagement.Application.Contracts.SiteLogo;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.SiteLogo
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateSiteLogo Command;
        public SelectList ListLanguage;
        private readonly ISiteLogoApplication _siteLogoApplication;
        private readonly ILanguageApplication _languageApplication;

        public CreateModel(ILanguageApplication languageApplication, ISiteLogoApplication siteLogoApplication)
        {
            _languageApplication = languageApplication;
            _siteLogoApplication = siteLogoApplication;
        }


        public void OnGet()
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
        }

        public IActionResult OnPost(CreateSiteLogo command)
        {
            if (ModelState.IsValid)
            {
                var result = _siteLogoApplication.Create(command);
                if (result.IsSuccess)
                    return RedirectToPage("./Index");
                ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
                Message = result.Massage;
                return Page();
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}