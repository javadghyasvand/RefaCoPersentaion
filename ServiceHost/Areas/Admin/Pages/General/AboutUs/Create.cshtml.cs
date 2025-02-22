using GeneralManagement.Application.Contracts.AboutUs;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.AboutUs
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateAboutUs Command;
        public SelectList ListLanguage;
        private readonly IAboutUsApplication _aboutUsApplication;
        private readonly ILanguageApplication _languageApplication;

        public CreateModel(IAboutUsApplication aboutUsApplication, ILanguageApplication languageApplication)
        {
            _aboutUsApplication = aboutUsApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet()
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
        }

        public IActionResult OnPost(CreateAboutUs command)
        {
            var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _aboutUsApplication.Create(command);
                return RedirectToPage("./Index");
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();

        }
    }
}
