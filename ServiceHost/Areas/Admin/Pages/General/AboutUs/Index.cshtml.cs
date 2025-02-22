using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.Articles;
using GeneralManagement.Application.Contracts.AboutUs;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.General.AboutUs
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public AboutUsSearchModel SearchModel;
        public List<AboutUsViewModel> AboutUsViewModels;
        public SelectList ListLanguage;
        private readonly IAboutUsApplication _aboutUsApplication;
        private readonly ILanguageApplication _languageApplication;

        public IndexModel(IAboutUsApplication aboutUsApplication, ILanguageApplication languageApplication)
        {
            _aboutUsApplication = aboutUsApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet(AboutUsSearchModel model)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            AboutUsViewModels = _aboutUsApplication.Search(model);
        }
    }
}
