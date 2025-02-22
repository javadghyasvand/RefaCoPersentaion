
using GeneralManagement.Application.Contracts.Faq;
using GeneralManagement.Application.Contracts.GeneralSetting;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.GeneralSetting
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public EditGeneralSetting Command;
        public SelectList ListLanguage;
        private readonly IGeneralSettingApplication _generalSettingApplication;
        private readonly ILanguageApplication _languageApplication;

        public EditModel(ILanguageApplication languageApplication, IGeneralSettingApplication generalSettingApplication1)
        {
            _languageApplication = languageApplication;
            _generalSettingApplication = generalSettingApplication1;
        }


        public void OnGet(long id)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Command = _generalSettingApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditGeneralSetting command)
        { var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _generalSettingApplication.Edit(command);
                return RedirectToPage("./Index");
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
