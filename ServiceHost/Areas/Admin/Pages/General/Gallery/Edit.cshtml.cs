using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Gallery;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.Gallery
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public EditGallery Command;
        public List<GalleryViewModel> GalleryViewModels;
        public SelectList ListLanguage;
        private readonly IGalleryApplication _galleryApplication;
        private readonly ILanguageApplication _languageApplication;

        public EditModel(
            ILanguageApplication languageApplication, IGalleryApplication galleryApplication)
        {
            _languageApplication = languageApplication;
            _galleryApplication = galleryApplication;
        }


        public void OnGet(long id)
        { 
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Command = _galleryApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditGallery command)
        {
            if (ModelState.IsValid)
            {
                var result = _galleryApplication.Edit(command);
                if (result.IsSuccess)
                    return RedirectToPage("./Index");
                ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
                Message = result.Massage;
                return Page();
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}