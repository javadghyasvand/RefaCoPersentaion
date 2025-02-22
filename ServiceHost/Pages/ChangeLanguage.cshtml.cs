using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ServiceHost.Pages
{
    public class ChangeLanguageModel : PageModel
    {
        public IActionResult OnGet(string culture)
        {
            // Set the language preference in a cookie
            Response.Cookies.Append("UserLanguage", culture, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });

            // Redirect back to the referring page or the home page
            //var referer = Request.Headers["Referer"].ToString();
            //return Redirect(!string.IsNullOrEmpty(referer) ? referer : "/");

            return Redirect("/");
        }
    }
}
