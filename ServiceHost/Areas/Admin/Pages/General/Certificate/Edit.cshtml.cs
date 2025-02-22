using GeneralManagement.Application.Contracts.Certificate;
using GeneralManagement.Application.Contracts.SocialMedia;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.Certificate
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
 
        public EditCertificate Command;
        public SelectList ListLanguage;
        private readonly ICertificateApplication _certificateApplication;
        private readonly ILanguageApplication _languageApplication;
        public EditModel(ICertificateApplication certificateApplication, ILanguageApplication languageApplication)
        {
            _certificateApplication = certificateApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet(long id)
        {
            Command = _certificateApplication.GetDetails(id);
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
        }
        public IActionResult OnPost(EditCertificate command)
        {
            if (ModelState.IsValid)
            {
                var result = _certificateApplication.Edit(command);
                if (result.IsSuccess)
                {
                    return RedirectToPage("./Index");
                }
                Message = result.Massage;
                Command = command;
                ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
                return Page();
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Command = command;
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
