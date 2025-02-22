using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ErrorPageModel : PageModel
    {
        public void OnGet()
        {
            Response.StatusCode = 500; // تعیین کد وضعیت خطا
        }
    }
}