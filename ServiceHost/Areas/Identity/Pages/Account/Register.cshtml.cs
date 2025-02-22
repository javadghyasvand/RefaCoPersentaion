// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ServiceHost.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IMessageService _smsService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IMessageService smsService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _smsService=smsService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public class InputModel
        {
            [EmailAddress(ErrorMessage = "The email format is not correct.")]
            public string Email { get; set; }
            [Required(ErrorMessage = "The value {0} is required.")]
            [Display(Name = "Name")]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "The value {0} is required.")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Required(ErrorMessage = "The value {0} is required.")]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [Required(ErrorMessage = "The value {0} is required.")]
            [Display(Name = "Mobile")]
            public string PhoneNumber { get; set; }
            [Required(ErrorMessage = "The value {0} is required.")]
            [Display(Name = "NationalCode")]
            public string NationalCode { get; set; }
            [Required(ErrorMessage = "The value {0} is required.")]
            [Display(Name = "Position")]
            public string Position { get; set; }
            [Required(ErrorMessage = "The value {0} is required.")]
            [Display(Name = "OrganizationName")]
            public string OrganizationName { get; set; }
        }



        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    UserName = Input.PhoneNumber,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    CreateDate = DateTime.Now,
                    IsApproved = false,
                    NationalCode = Input.NationalCode,
                    OrganizationName = Input.OrganizationName,
                    Position = Input.Position,  
                };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "DistributionUser");
                    if (!roleResult.Succeeded)
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return Page();
                    }
                    var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Phone");
                    await _smsService.SendSms(SmsTemplate.testi, user.PhoneNumber, token);
                    return RedirectToPage("ConfirmRegistration", new { phoneNumber = user.PhoneNumber,userName = user.UserName });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
