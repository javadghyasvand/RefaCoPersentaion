using GeneralManagement.Application.Contracts.AboutUs;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.AboutUs
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
 
        public EditAboutUs Command;
        public SelectList ListLanguage;
        private readonly IAboutUsApplication _aboutUsApplication;
        private readonly ILanguageApplication _languageApplication;

        public EditModel(IAboutUsApplication aboutUsApplication, ILanguageApplication languageApplication)
        {
            _aboutUsApplication = aboutUsApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet(long id)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Command = _aboutUsApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditAboutUs command)
        { var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _aboutUsApplication.Edit(command);
                return RedirectToPage("./Index");
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
