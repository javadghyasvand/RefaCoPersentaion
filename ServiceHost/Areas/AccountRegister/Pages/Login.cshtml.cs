using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.AccountRegister.Pages
{
    [Area("AccountRegister")]
    public class LoginModel : PageModel
    {
        [TempData] public string Login { get; set; }
        [TempData] public string Register { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; }

        private readonly IAccountApplication _accountApplication;

        public LoginModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public IActionResult OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
            return Page();
        }

        public IActionResult OnPost(Login command, string returnUrl = null)
        {
            var result = _accountApplication.Login(command);
            if (result.IsSuccess)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToPage("/Index");
                }
            }

            Login = result.Massage;
            return Page();








            //var result = _accountApplication.Login(command);
            //if (result.IsSuccess)
            //    return RedirectToPage("/Index");

            //Login = result.Massage;
            //return Page();
        }

        public IActionResult OnGetLogOut()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }

        //public IActionResult OnPostRegister(RegisterAccount command)
        //{
        //    var result = _accountApplication.Register(command);
        //    if (result.IsSuccess)
        //        return RedirectToPage("/Login");
        //    Register = result.Massage;
        //    return Page();
        //}
    }
}