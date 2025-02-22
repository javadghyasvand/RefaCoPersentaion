using GeneralManagement.Application.Contracts.Gallery;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore;

namespace ServiceHost.Areas.Admin.Pages.General.Gallery
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public CreateGallery Command;
        public SelectList ListLanguage;
        private readonly IGalleryApplication _galleryApplication;
        private readonly ILanguageApplication _languageApplication;

        public CreateModel(ILanguageApplication languageApplication, IGalleryApplication galleryApplication)
        {
            _languageApplication = languageApplication;
            _galleryApplication = galleryApplication;
        }

        public void OnGet()
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
       }

        public IActionResult OnPost(CreateGallery command)
        {
            if (ModelState.IsValid)
            {
                var result= _galleryApplication.Create(command);
                if (result.IsSuccess)
                {
                    return RedirectToPage("./Index");
                }
                Message = result.Massage;
                ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
                return Page();
            }
            Message = ValidationMessages.ReturnPageFail;
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            return Page();
        }
    }
}