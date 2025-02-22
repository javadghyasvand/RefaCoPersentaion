using System.Globalization;
using System.Threading.Tasks;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Identity.Pages.Account
{
    public class LoginWithSmsModel : PageModel
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMessageService _smsService;
        private readonly IConfiguration _configuration;
        [TempData] public string ErrorMessage { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }

        public LoginWithSmsModel(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IMessageService smsService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _smsService = smsService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);
            if (user == null || !user.PhoneNumberConfirmed)
            {
                ErrorMessage = LoginMessage.GetMessage("PhoneNotRegistered", CultureInfo.CurrentCulture.Name); 
                ModelState.AddModelError(string.Empty, ErrorMessage);
                return Page();
            }

            // Generate an OTP token
            /*var token = await _userManager.GenerateUserTokenAsync(user, "Default", "PhoneLogin");*/
            var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Phone");

            // Send OTP via SMS
            await _smsService.SendSms(SmsTemplate.testi,PhoneNumber,token);

            TempData["PhoneNumber"] = PhoneNumber; // Store phone number for OTP verification
            return RedirectToPage("VerifyOtp");
        }

    }
}