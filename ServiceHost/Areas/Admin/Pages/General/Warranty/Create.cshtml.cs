using GeneralManagement.Application.Contracts.Warranty;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.Warranty
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateWarranty Command =new CreateWarranty();
        public SelectList ListLanguage { get; set; }
        private readonly IWarrantyApplication _warrantyApplication;
        private readonly ILanguageApplication _languageApplication;
            
        public CreateModel( ILanguageApplication languageApplication, IWarrantyApplication warrantyApplication)
        {
            _languageApplication = languageApplication;
            _warrantyApplication = warrantyApplication;
        }


        public void OnGet()
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
        }

        public IActionResult OnPost(CreateWarranty command)
        {
            if (ModelState.IsValid)
            {
                var result = _warrantyApplication.Create(command);
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
