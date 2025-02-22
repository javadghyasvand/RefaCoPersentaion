using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class NotFoundModel : PageModel
    {
        public void OnGet()
        {
            Response.StatusCode = 404; // تعیین کد وضعیت 404
        }
    }
}