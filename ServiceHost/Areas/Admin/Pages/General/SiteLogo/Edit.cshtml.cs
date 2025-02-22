using GeneralManagement.Application.Contracts.AboutUs;
using GeneralManagement.Application.Contracts.SiteLogo;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceHost.Areas.Admin.Pages.General.SiteLogo
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public EditSiteLogo Command;
        public SelectList ListLanguage;
        private readonly ISiteLogoApplication _siteLogoApplication;
        private readonly ILanguageApplication _languageApplication;

        public EditModel(ILanguageApplication languageApplication, ISiteLogoApplication siteLogoApplication)
        {
            _languageApplication = languageApplication;
            _siteLogoApplication = siteLogoApplication;
        }


        public void OnGet(long id)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Command = _siteLogoApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditSiteLogo command)
        {
            if (ModelState.IsValid)
            {
                var result = _siteLogoApplication.Edit(command);
                if (result.IsSuccess)
                    return RedirectToPage("./Index");
                Command = command;
                 ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
                Message = result.Massage;
                return Page();
            }
            Command = command;
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}