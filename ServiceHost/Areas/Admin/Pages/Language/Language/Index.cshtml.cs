using System.Collections.Generic;
using AccountManagement.Application.Contracts.Account;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Language.Language
{
   
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<LanguageViewModel> Language;
        public SelectList Owner;
        private readonly ILanguageApplication _languageApplication;

        public IndexModel(ILanguageApplication languageApplication)
        {
            _languageApplication = languageApplication;
        }


        public void OnGet(AccountSearchModel searchModel)
        {
           
            Language = _languageApplication.List();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }

        public JsonResult OnPostCreate(CreateLanguage commend)
        {
            var result = _languageApplication.Create(commend);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var language = _languageApplication.GetDetails(id);
            return Partial("./Edit", language);
        }
        public JsonResult OnPostEdit(EditLanguage commend)
        {
            var result = _languageApplication.Edit(commend);
            return new JsonResult(result);
        }

    }
}
