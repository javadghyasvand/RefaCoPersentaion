using System.Globalization;
using System.Threading.Tasks;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Identity.Pages.Account
{
    public class ConfirmRegistrationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ConfirmRegistrationModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            public string PhoneNumber { get; set; } 
            public string UserName { get; set; } 
            public string Token { get; set; }
        }
        public void OnGet(string phoneNumber, string userName)
        {
            Input.PhoneNumber = phoneNumber;
            Input.UserName = userName;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByNameAsync(Input.UserName);
            if (user != null)
            {
                var isTokenValid = await _userManager.VerifyTwoFactorTokenAsync(user, "Phone", Input.Token);
                if (isTokenValid)
                {
                    user.PhoneNumberConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    return RedirectToPage("Login");
                }
            }
            string errorMessage = LoginMessage.GetMessage("DuplicatedRecord",  CultureInfo.CurrentCulture.ToString());
            ModelState.AddModelError(string.Empty, errorMessage);
            return Page();
        }
    }
}
