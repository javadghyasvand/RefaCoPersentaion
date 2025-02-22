// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

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
    public class VerifyOtpModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string _errorMessage;
        [BindProperty]
        public string VerificationCode { get; set; }

        public VerifyOtpModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPost()
        {
            var phoneNumber = TempData["PhoneNumber"] as string;
            if (phoneNumber == null)
            {
                _errorMessage = LoginMessage.GetMessage("SessionExpired", CultureInfo.CurrentCulture.Name);
                ModelState.AddModelError(string.Empty, _errorMessage);
                return RedirectToPage("LoginWithSms");
            }
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user == null)
            {
                _errorMessage = LoginMessage.GetMessage("UserNotFound", CultureInfo.CurrentCulture.Name);
                ModelState.AddModelError(string.Empty, _errorMessage);
                return Page();
            }
            // Verify the OTP
            /* var isCodeValid = await _userManager.VerifyTwoFactorTokenAsync(user, "Default", "PhoneLogin", VerificationCode);*/
            var isCodeValid = await _userManager.VerifyTwoFactorTokenAsync(user, "Phone", VerificationCode);
            if (isCodeValid)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("Index");
            }
            _errorMessage = LoginMessage.GetMessage("InvalidToken", CultureInfo.CurrentCulture.Name);
            ModelState.AddModelError(string.Empty, _errorMessage);
            return Page();
        }
    }
}
