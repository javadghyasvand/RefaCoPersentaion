using GeneralManagement.Application.Contracts.Certificate;
using GeneralManagement.Application.Contracts.SocialMedia;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.Certificate
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateCertificate Command =new CreateCertificate();
        public SelectList ListLanguage;
        private readonly ICertificateApplication _certificateApplication;
        private readonly ILanguageApplication _languageApplication;
        public CreateModel(ICertificateApplication certificateApplication, ILanguageApplication languageApplication)
        {
            _certificateApplication = certificateApplication;
            _languageApplication = languageApplication;
        }

        public void OnGet()
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
        }

        public IActionResult OnPost(CreateCertificate command)
        {
            if (ModelState.IsValid)
            {
                var result = _certificateApplication.Create(command);
                if (result.IsSuccess)
                {
                    return RedirectToPage("./Index");
                }
                Message = result.Massage;
                ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
                return Page();
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();

        }
    }
}
