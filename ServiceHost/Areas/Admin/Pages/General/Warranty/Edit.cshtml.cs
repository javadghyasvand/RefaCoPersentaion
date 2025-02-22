using GeneralManagement.Application.Contracts.SocialMedia;
using GeneralManagement.Application.Contracts.Warranty;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.Warranty
{
    public class EditModel : PageModel
    {


        [TempData] public string Message { get; set; }
        public SelectList ListLanguage { get; set; }
        private readonly IWarrantyApplication _warrantyApplication;
        private readonly ILanguageApplication _languageApplication;
        public EditWarranty Command;

        public EditModel(IWarrantyApplication warrantyApplication, ILanguageApplication languageApplication)
        {
            _warrantyApplication = warrantyApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet(long id)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Command = _warrantyApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditWarranty command)
        {
            if (ModelState.IsValid)
            {
                var result = _warrantyApplication.Edit(command);
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
