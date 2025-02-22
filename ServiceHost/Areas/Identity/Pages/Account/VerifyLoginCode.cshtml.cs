using System.Globalization;
using System.Threading.Tasks;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Identity.Pages.Account
{
    public class VerifyLoginCodeModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private string _errorMessage;

        public VerifyLoginCodeModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string PhoneNumber { get; set; }
            public string Token { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string phoneNumber)
        {
            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == Input.PhoneNumber);
            if (user != null)
            {
                var isTokenValid = await _userManager.VerifyTwoFactorTokenAsync(user, "Phone", Input.Token);
                if (isTokenValid)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("Index");
                }
            }
            _errorMessage = LoginMessage.GetMessage("InvalidToken", CultureInfo.CurrentCulture.Name);
            ModelState.AddModelError(string.Empty, _errorMessage);
            return Page();
        }
    }
}
