using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Gallery;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.General.Gallery
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public GallerySearchModel SearchModel;
        public List<GalleryViewModel> GalleryViewModel;
        public SelectList ListLanguage;
        private readonly IGalleryApplication _galleryApplication;
        private readonly ILanguageApplication _languageApplication;


        public IndexModel(IGalleryApplication galleryApplication, ILanguageApplication languageApplication)
        {
            _galleryApplication = galleryApplication;
            _languageApplication = languageApplication;
        }
        public void OnGet(GallerySearchModel searchModel)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            GalleryViewModel = _galleryApplication.Search(searchModel);
        }
    }
}
