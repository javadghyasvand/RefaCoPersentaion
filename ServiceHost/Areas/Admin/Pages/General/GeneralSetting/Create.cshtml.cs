
using GeneralManagement.Application.Contracts.Faq;
using GeneralManagement.Application.Contracts.GeneralSetting;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.GeneralSetting
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateGeneralSetting Command;
        public SelectList ListLanguage;
        private readonly IGeneralSettingApplication _generalSettingApplication;
        private readonly ILanguageApplication _languageApplication;

        public CreateModel(IGeneralSettingApplication generalSettingApplication, ILanguageApplication languageApplication)
        {
            _generalSettingApplication = generalSettingApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet()
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
        }

        public IActionResult OnPost(CreateGeneralSetting command)
        {
            var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _generalSettingApplication.Create(command);
                return RedirectToPage("./Index");
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();

        }
    }
}
