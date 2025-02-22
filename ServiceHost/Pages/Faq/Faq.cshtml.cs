using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Events;
using My_ShopQuery.Contract.Faq;

namespace ServiceHost.Pages.Faq
{
    public class FaqModel : PageModel
    {
        public List<FaqQueryModel> Faq { get; set; }
        private readonly IFaqQueryModel _faqQuery;

        public FaqModel(IFaqQueryModel faqQuery)
        {
            _faqQuery = faqQuery;
        }


        public void OnGet()
        {
            Faq = _faqQuery.GetAll();
        }
    }
}
